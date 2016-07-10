Imports System.IO
Imports System.Text
Imports XDev.CompilerHelper
'-----------------
Imports Microsoft.CSharp
Imports Microsoft.VisualBasic
Imports System.CodeDom.Compiler
Imports System.Reflection

Friend Class LanguageCompiler

    Private Shared NetAssemblies As New List(Of String)


#Region "Java"

    'ECJ-4.5M7
    Public Shared Function CompileJavaWithOutput(ByVal javafile As String, ByVal run As Boolean) As List(Of String)
        Logger.Write(Logger.TypeOfLog.Code, "Attempting to compile " & Path.GetFileName(javafile) & " using the ECJ compiler.")
        Dim retlist As New List(Of String)
        retlist.Add("")
        retlist.Add("")
        'Dim classloc As String = Path.GetDirectoryName(javafile) + "\"
        'If Not System.IO.Directory.Exists(Path.GetDirectoryName(javafile) + "\Compiled") Then
        '    System.IO.Directory.CreateDirectory(Path.GetDirectoryName(javafile) + "\Compiled")
        'End If
        '---------
        Dim sb As New System.Text.StringBuilder
        sb.AppendLine("@echo off")
        sb.AppendLine("SET PATH=%PATH%;" & My.Settings.set_javaclasspath)
        sb.AppendLine("echo Beginning compiling " & Path.GetFileName(javafile) & " ...")
        sb.AppendLine("echo ====================")
        sb.AppendLine("java -jar " & """" & XDev.Path.Locator.GetAppPath & "\Engine\Compile\Java\ecj.jar" & """" & " " & javafile)
        'sb.AppendLine("pause")
        '-------
        System.IO.File.WriteAllText(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Java\BAT\cj.bat", sb.ToString())
        'System.Diagnostics.Process.Start(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Java\cj.bat")
        '------------
        'Dim before As String = Path.GetDirectoryName(javafile) + "\" + Path.GetFileNameWithoutExtension(javafile) + ".class"
        'System.IO.File.Copy(before, XDev.Path.Locator.GetAppPath + "\Engine\Compile\Temp\" + Path.GetFileNameWithoutExtension(javafile) + ".class")
        'System.IO.File.Delete(before)
        'System.IO.File.Move(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Temp\" + Path.GetFileNameWithoutExtension(javafile) + ".class", Path.GetDirectoryName(javafile) + "\Compiled\" + Path.GetFileNameWithoutExtension(javafile) + ".class")
        'System.IO.File.Delete(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Java\cj.bat")
        '------------------------
        Try
            Dim process = New Process()
            process.StartInfo.FileName = XDev.Path.Locator.GetAppPath + "\Engine\Compile\Java\BAT\cj.bat"
            process.StartInfo.Arguments = ""
            process.StartInfo.UseShellExecute = False
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            'process.StartInfo.RedirectStandardInput = True
            process.Start()
            Dim outputReader As StreamReader = process.StandardOutput
            Dim errorReader As StreamReader = process.StandardError
            retlist(0) = outputReader.ReadToEnd()
            retlist(1) = errorReader.ReadToEnd()
            process.WaitForExit()
            If retlist(1).Contains("ERROR") = False Then
                retlist(0) += vbNewLine
                retlist(0) += "[COMPILED " & Path.GetFileName(javafile) & "...]"
            End If

            If run Then
                retlist(0) += vbNewLine
                retlist(0) += "Running " & Path.GetFileName(javafile) & "..."
                RunJavaClass(javafile)
            End If
            Return retlist
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Sub RunJavaClass(ByVal javafile As String)
        If File.Exists(Path.GetDirectoryName(javafile) & "\" & Path.GetFileNameWithoutExtension(javafile) & ".class") Then
            Try
                Logger.Write(Logger.TypeOfLog.Code, "Attempting to run " & Path.GetFileName(javafile))
                Dim sb As New System.Text.StringBuilder
                sb.AppendLine("@echo off")
                sb.AppendLine("SET PATH=%PATH%;" & My.Settings.set_javaclasspath)
                sb.AppendLine("cd " & Path.GetDirectoryName(javafile))
                sb.AppendLine("java " & Path.GetFileNameWithoutExtension(javafile))
                'sb.AppendLine("pause")
                System.IO.File.WriteAllText(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Java\BAT\rj.bat", sb.ToString())
                System.Diagnostics.Process.Start(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Java\BAT\rj.bat")
                'System.IO.File.Delete(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Java\rj.bat")
            Catch ex As Exception
                Logger.WriteError(ex)
            End Try
        End If
    End Sub

#End Region

#Region "CPP"

    Private Shared processOutput As StringBuilder = Nothing

    Public Shared Function CompileCPPWithOutput(ByVal cppfile As String, ByVal run As Boolean) As String()
        Logger.Write(Logger.TypeOfLog.Code, "Attempting to compile " & Path.GetFileName(cppfile) & " using the GCC C++ compiler.")
        Dim getret(2) As String
        Try

            Dim sb As New System.Text.StringBuilder
            sb.AppendLine("@echo off")
            sb.AppendLine("SET PATH=%PATH%;" & XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\bin")
            sb.AppendLine("echo Beginning compiling " & Path.GetFileName(cppfile) & " ...")
            sb.AppendLine("echo ====================")
            sb.AppendLine("g++ -g -Wall " & """" & cppfile & """" & " -o " & """" & Path.GetDirectoryName(cppfile) & "\" & Path.GetFileNameWithoutExtension(cppfile) & ".exe" & """")
            'sb.AppendLine("pause")
            System.IO.File.WriteAllText(XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\ccpp.bat", sb.ToString())
            getret = Launch.LaunchAndGetOutputErrors(XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\ccpp.bat")
            If getret(1).Contains("error") = False Then
                getret(0) += vbNewLine
                getret(0) += "[COMPILED " & Path.GetFileName(cppfile) & "...]"
            End If
            If run Then
                getret(0) += vbNewLine
                getret(0) += "Running " & Path.GetFileName(cppfile) & "..."
                RunCPPEXE(cppfile)
            End If
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
        Return getret

    End Function

    Private Shared Sub OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
        ' Collect the sort command output.
        If Not String.IsNullOrEmpty(outLine.Data) Then
            ' Add the text to the collected output.
            processOutput.AppendLine(outLine.Data)
        End If
    End Sub


    Public Shared Sub CompileCPP(ByVal cppfile As String)

        '---------
        Dim sb As New System.Text.StringBuilder
        sb.AppendLine("@echo off")
        sb.AppendLine("SET PATH=%PATH%;" & XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\bin")
        sb.AppendLine("g++ -v " & """" & cppfile & """" & " -o " & """" & Path.GetDirectoryName(cppfile) & "\" & Path.GetFileNameWithoutExtension(cppfile) & ".exe" & """")
        sb.AppendLine("pause")

        '-------
        System.IO.File.WriteAllText(XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\ccpp.bat", sb.ToString())
        System.Diagnostics.Process.Start(XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\ccpp.bat")
        'CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).AddToOutput("Compilation complete.")
        '------------
        'Try
        '    Dim process = New Process()
        '    process.StartInfo.FileName = XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\ccpp.bat"
        '    process.StartInfo.Arguments = ""
        '    process.StartInfo.UseShellExecute = False
        '    process.StartInfo.CreateNoWindow = True
        '    process.StartInfo.RedirectStandardOutput = True
        '    process.StartInfo.RedirectStandardError = True
        '    process.StartInfo.RedirectStandardInput = True
        '    process.Start()
        '    Dim outputReader As StreamReader = process.StandardOutput
        '    Dim errorReader As StreamReader = process.StandardError
        '    'b(0) = outputReader.ReadToEnd()
        '    'b(1) = errorReader.ReadToEnd()
        '    CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).SetOutput(outputReader.ReadToEnd())
        '    CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).SetErrors(errorReader.ReadToEnd())
        '    'outputReader.Close()
        '    'errorReader.Close()
        '    process.WaitForExit()
        '    'Return b
        'Catch
        '    'Return Nothing
        'End Try
    End Sub

    Public Shared Sub RunCPPEXE(ByVal cppfile As String)
        If File.Exists(Path.GetDirectoryName(cppfile) & "\" & Path.GetFileNameWithoutExtension(cppfile) & ".exe") Then
            Logger.Write(Logger.TypeOfLog.Code, "Attempting to run " & Path.GetFileName(cppfile))
            System.Diagnostics.Process.Start(Path.GetDirectoryName(cppfile) & "\" & Path.GetFileNameWithoutExtension(cppfile) & ".exe")
        End If
    End Sub

#End Region

#Region "C"

    Public Shared Function CompileCWithOutput(ByVal cfile As String, ByVal run As Boolean) As String()
        Logger.Write(Logger.TypeOfLog.Code, "Attempting to compile " & Path.GetFileName(cfile) & " using the GCC C compiler.")
        Dim getret(2) As String
        Dim sb As New System.Text.StringBuilder
        sb.AppendLine("@echo off")
        sb.AppendLine("SET PATH=%PATH%;" & XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\bin")
        sb.AppendLine("echo Beginning compiling " & Path.GetFileName(cfile) & " ...")
        sb.AppendLine("echo ====================")
        sb.AppendLine("gcc -g -Wall " & cfile & " -o " & Path.GetDirectoryName(cfile) & "\" & Path.GetFileNameWithoutExtension(cfile) & ".exe")
        'sb.AppendLine("pause")
        System.IO.File.WriteAllText(XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\cc.bat", sb.ToString())
        getret = Launch.LaunchAndGetOutputErrors(XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\cc.bat")
        If getret(1).Contains("error") = False Then
            getret(0) += vbNewLine
            getret(0) += "[COMPILED " & Path.GetFileName(cfile) & "...]"
        End If
        If run Then
            getret(0) += vbNewLine
            getret(0) += "Running " & Path.GetFileName(cfile) & "..."
            RunCEXE(cfile)
        End If
        Return getret
    End Function

    Public Shared Sub CompileC(ByVal cfile As String)
        'Dim retlist As New List(Of String)
        'retlist.Add("")
        'retlist.Add("")
        '---------
        Dim sb As New System.Text.StringBuilder
        sb.AppendLine("@echo off")
        sb.AppendLine("SET PATH=%PATH%;" & XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\bin")
        sb.AppendLine("echo Beginning compiling " & Path.GetFileName(cfile) & " ...")
        sb.AppendLine("echo ====================")
        sb.AppendLine("gcc " & """" & cfile & """" & " -o " & """" & Path.GetDirectoryName(cfile) & "\" & Path.GetFileNameWithoutExtension(cfile) & ".exe" & """")
        sb.AppendLine("pause")
        '-------
        System.IO.File.WriteAllText(XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\cc.bat", sb.ToString())
        System.Diagnostics.Process.Start(XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\cc.bat")
        'Try
        '    Dim process = New Process()
        '    process.StartInfo.FileName = XDev.Path.Locator.GetAppPath + "\Engine\Compile\CPP\BAT\cc.bat"
        '    process.StartInfo.Arguments = ""
        '    process.StartInfo.UseShellExecute = False
        '    process.StartInfo.CreateNoWindow = True
        '    process.StartInfo.RedirectStandardOutput = True
        '    process.StartInfo.RedirectStandardError = True
        '    'process.StartInfo.RedirectStandardInput = True
        '    process.Start()
        '    Dim outputReader As StreamReader = process.StandardOutput
        '    Dim errorReader As StreamReader = process.StandardError
        '    retlist(0) = outputReader.ReadToEnd()
        '    retlist(1) = errorReader.ReadToEnd()
        '    process.WaitForExit()
        '    Return retlist
        'Catch
        '    Return Nothing
        'End Try
        '------------
    End Sub

    Public Shared Sub RunCEXE(ByVal cfile As String)
        If File.Exists(Path.GetDirectoryName(cfile) & "\" & Path.GetFileNameWithoutExtension(cfile) & ".exe") Then
            Logger.Write(Logger.TypeOfLog.Code, "Attempting to run " & Path.GetFileName(cfile))
            System.Diagnostics.Process.Start(Path.GetDirectoryName(cfile) & "\" & Path.GetFileNameWithoutExtension(cfile) & ".exe")
        End If
    End Sub

#End Region

#Region ".NET"

#Region "C#"

    Public Shared Function CompileCSharpCodeWithOutput(ByVal csfile As String, ByVal entrypoint As String, ByVal assemblies As List(Of String), ByVal compileaswinforms As Boolean, ByVal run As Boolean) As String
        Dim getret As String = ""
        Try
            Dim CodeDomProvider1 As CodeDomProvider = New Microsoft.CSharp.CSharpCodeProvider
            Dim Parameters As New CompilerParameters()
            Parameters.GenerateExecutable = True
            Parameters.OutputAssembly = Path.GetDirectoryName(csfile) & "\" & Path.GetFileNameWithoutExtension(csfile) & ".exe"
            Parameters.MainClass = entrypoint
            Parameters.IncludeDebugInformation = True
            For Each asm As String In NetAssemblies
                Parameters.ReferencedAssemblies.Add(asm)
            Next
            For Each asm As String In assemblies
                Parameters.ReferencedAssemblies.Add(asm)
            Next
            If compileaswinforms Then
                Parameters.CompilerOptions = "/t:winexe"
            End If
            Dim code As [String] = My.Computer.FileSystem.ReadAllText(csfile)
            Dim results As CompilerResults = CodeDomProvider1.CompileAssemblyFromSource(Parameters, code)
            Dim output As String = ""
            If results.Errors.Count > 0 Then
                For Each err As CompilerError In results.Errors
                    output = output & err.ToString() + vbLf
                Next
            End If
            If output = "" Then
                output += "[COMPILED " & Path.GetFileName(csfile) & "...]" & vbNewLine
            End If
            For Each out As String In results.Output
                output = output & out + vbLf
            Next

            getret = output
            If run Then
                getret += vbNewLine
                getret += "Running " & Path.GetFileName(csfile) & "..."
                RunCSharpEXE(csfile)
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Code, ex)
        End Try
        Return getret
    End Function

    Public Shared Sub RunCSharpEXE(ByVal csfile As String)
        If File.Exists(Path.GetDirectoryName(csfile) & "\" & Path.GetFileNameWithoutExtension(csfile) & ".exe") Then
            Logger.Write(Logger.TypeOfLog.Code, "Attempting to run " & Path.GetFileName(csfile))
            System.Diagnostics.Process.Start(Path.GetDirectoryName(csfile) & "\" & Path.GetFileNameWithoutExtension(csfile) & ".exe")
        End If
    End Sub

#End Region

#Region "VB.Net"

    Public Shared Function CompileVBNetCodeWithOutput(ByVal vbfile As String, ByVal entrypoint As String, ByVal assemblies As List(Of String), ByVal compileaswinforms As Boolean, ByVal run As Boolean) As String
        Dim getret As String = ""
        Try
            Dim CodeDomProvider1 As CodeDomProvider = New Microsoft.VisualBasic.VBCodeProvider
            Dim Parameters As New CompilerParameters()
            Parameters.GenerateExecutable = True
            Parameters.OutputAssembly = Path.GetDirectoryName(vbfile) & "\" & Path.GetFileNameWithoutExtension(vbfile) & ".exe"
            Parameters.MainClass = entrypoint
            Parameters.IncludeDebugInformation = True
            For Each asm As String In NetAssemblies
                Parameters.ReferencedAssemblies.Add(asm)
            Next
            For Each asm As String In assemblies
                Parameters.ReferencedAssemblies.Add(asm)
            Next
            If compileaswinforms Then
                Parameters.CompilerOptions = "/t:winexe"
            End If
            Dim code As [String] = My.Computer.FileSystem.ReadAllText(vbfile)
            Dim results As CompilerResults = CodeDomProvider1.CompileAssemblyFromSource(Parameters, code)
            Dim output As String = ""
            If results.Errors.Count > 0 Then
                For Each err As CompilerError In results.Errors
                    output = output & err.ToString() + vbLf
                Next
            End If
            If output = "" Then
                output += "[COMPILED " & Path.GetFileName(vbfile) & "...]" & vbNewLine
            End If
            For Each out As String In results.Output
                output = output & out + vbLf
            Next

            getret = output
            If run Then
                getret += vbNewLine
                getret += "Running " & Path.GetFileName(vbfile) & "..."
                RunVBEXE(vbfile)
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Code, ex)
        End Try
        Return getret
    End Function

    Public Shared Sub RunVBEXE(ByVal vbfile As String)
        If File.Exists(Path.GetDirectoryName(vbfile) & "\" & Path.GetFileNameWithoutExtension(vbfile) & ".exe") Then
            Logger.Write(Logger.TypeOfLog.Code, "Attempting to run " & Path.GetFileName(vbfile))
            System.Diagnostics.Process.Start(Path.GetDirectoryName(vbfile) & "\" & Path.GetFileNameWithoutExtension(vbfile) & ".exe")
        End If
    End Sub

#End Region

#End Region

    Public Shared Sub InitializeNetLanguages()
        Try
            Dim FormsRefPath As String = "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Windows.Forms.dll"
            Dim asm As Assembly = Assembly.LoadFile(FormsRefPath)
            NetAssemblies.Add(LCase(asm.Location))
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Code, ex)
        End Try
    End Sub

#Region "Custom"
    Public Shared Function CompileCustomWithOutput(ByVal customfile As String, ByVal run As Boolean) As String()
        Logger.Write(Logger.TypeOfLog.Code, "Attempting to compile " & Path.GetFileName(customfile) & " using the custom compiler.")
        Dim getret(2) As String
        Dim sb As New System.Text.StringBuilder
        sb.AppendLine("@echo off")
        If My.Settings.set_customcompilerpathvar IsNot "" Then
            sb.AppendLine("SET PATH=%PATH%;" & My.Settings.set_customcompilerpathvar)
        Else
            sb.AppendLine("cd " & My.Settings.set_customcompilerloc)
        End If
        sb.AppendLine("echo Beginning compiling [Custom Compiler]" & Path.GetFileName(customfile) & " ...")
        sb.AppendLine("echo ====================")
        If My.Settings.set_customcompilerrequiressecondfile Then
            sb.AppendLine(My.Settings.set_customcompilercommand & " " & My.Settings.set_customcompilerparams & " " & """" & customfile & """" & " " & """" & Path.GetDirectoryName(customfile) & "\" & Path.GetFileNameWithoutExtension(customfile) & My.Settings.set_customcompilerextension & """")
        Else
            sb.AppendLine(My.Settings.set_customcompilercommand & " " & My.Settings.set_customcompilerparams & " " & """" & customfile & """")
        End If

        'sb.AppendLine("pause")
        System.IO.File.WriteAllText(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Custom\cc.bat", sb.ToString())
        getret = Launch.LaunchAndGetOutputErrors(XDev.Path.Locator.GetAppPath + "\Engine\Compile\Custom\cc.bat")
        If run Then
            RunCustom(customfile)
        End If
        Return getret
    End Function
    Public Shared Sub RunCustom(ByVal customfile As String)
        Logger.Write(Logger.TypeOfLog.Code, "Attempting to run " & Path.GetFileName(customfile))
        System.Diagnostics.Process.Start(Path.GetDirectoryName(customfile) & "\" & Path.GetFileName(customfile) & My.Settings.set_customcompilerextension)
    End Sub

#End Region

End Class
