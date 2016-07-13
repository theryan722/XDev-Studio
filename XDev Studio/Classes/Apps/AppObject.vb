Imports System.Xml

Friend Class AppObject

#Region "Properties"

    Property Name As String

    Property FileLoc As String

    Property Command As String
    Property Arguments As String

#End Region

    Public Sub New()
        'do nothing
    End Sub

    Public Sub New(ByVal fname As String, ByVal fcommand As String, ByVal fargs As String, Optional ByVal floc As String = "")
        Name = fname
        Command = fcommand
        Arguments = fargs
        FileLoc = floc
    End Sub

#Region "Methods"

#Region "Arguments"

    Private Function GetFixedArgumentText() As String
        Dim finarg As String = Arguments
        finarg = finarg.Replace("$st$", GetSelectedText)
        finarg = finarg.Replace("$cf$", GetFileLocation)
        finarg = finarg.Replace("$cd$", GetText)
        finarg = finarg.Replace("$wsloc$", XDev.Path.Locator.GetWorkspacePath)
        finarg = finarg.Replace("$ploc$", My.Settings.temp_projlocation)
        finarg = finarg.Replace("$dloc$", XDev.Path.Locator.GetDataPath)
        finarg = finarg.Replace("$aloc$", XDev.Path.Locator.GetAppPath)
        Return finarg
    End Function

    Private Function GetSelectedText() As String
        If frmManager.IsNotepad Then
            Return CType(frmManager.DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
        ElseIf frmManager.IsCodeEditor Then
            Return CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
        Else
            Return ""
        End If
    End Function

    Private Function GetFileLocation() As String
        If frmManager.IsNotepad Then
            Return CType(frmManager.DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation()
        ElseIf frmManager.IsCodeEditor Then
            Return CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation()
        Else
            Return ""
        End If
    End Function

    Private Function GetText() As String
        If frmManager.IsNotepad Then
            Return CType(frmManager.DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Text
        ElseIf frmManager.IsCodeEditor Then
            Return CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text
        Else
            Return ""
        End If
    End Function

#End Region

    Public Sub DeleteFile()
        Try
            System.IO.File.Delete(FileLoc)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Public Sub WriteAppFile()
        Try
            Dim bb As String
            If FileLoc = "" Then
                bb = XDev.Path.Locator.GetDataPath & "\Apps\" & Name & ".xaf"
            ElseIf System.IO.Path.GetFileNameWithoutExtension(FileLoc) <> Name Then
                System.IO.File.Delete(FileLoc)
                bb = XDev.Path.Locator.GetDataPath & "\Apps\" & Name & ".xaf"
            Else
                bb = XDev.Path.Locator.GetDataPath & "\Apps\" & Name & ".xaf"
            End If
            FileLoc = bb

            Dim writer As New XmlTextWriter(bb, System.Text.Encoding.UTF8)
            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            '--------------------
            writer.WriteStartElement("XDevApp")
            writer.WriteStartElement("Name")
            writer.WriteString(Name)
            writer.WriteEndElement()
            writer.WriteStartElement("Command")
            writer.WriteString(Command)
            writer.WriteEndElement()
            writer.WriteStartElement("Arguments")
            writer.WriteString(Arguments)
            writer.WriteEndElement()
            writer.WriteEndElement()
            writer.Close()
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Public Sub RunApp()
        Try
            Logger.Write("Running app '" & Name & "'")
            System.Diagnostics.Process.Start(Command, GetFixedArgumentText)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

#End Region

End Class
