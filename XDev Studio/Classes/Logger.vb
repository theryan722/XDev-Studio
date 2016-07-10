Friend Class Logger
    Private Shared codeloc As String = XDev.Path.Locator.GetDataPath + "\Logs\log_code.txt"
    Private Shared studioloc As String = XDev.Path.Locator.GetDataPath + "\Logs\log_studio.txt"
    Private Shared pluginloc As String = XDev.Path.Locator.GetDataPath + "\Logs\log_plugin.txt"
    Enum TypeOfLog
        Studio
        Plugin
        Code
    End Enum
    Public Shared Sub Write(ByVal msg As String)
        Try
            Dim objWriter As New System.IO.StreamWriter(studioloc, True)
            objWriter.WriteLine(DateTime.Now.ToString() & " | " & msg)
            objWriter.Close()
        Catch
        End Try
    End Sub

    Public Shared Sub Write(ByVal logtype As TypeOfLog, ByVal msg As String)
        If logtype = TypeOfLog.Studio Then
            Try
                Dim objWriter As New System.IO.StreamWriter(studioloc, True)
                objWriter.WriteLine(DateTime.Now.ToString() & " | " & msg)
                objWriter.Close()
            Catch
            End Try
        ElseIf logtype = TypeOfLog.Plugin Then
            Try
                Dim objWriter As New System.IO.StreamWriter(pluginloc, True)
                objWriter.WriteLine(DateTime.Now.ToString() & " | " & msg)
                objWriter.Close()
            Catch
            End Try
        ElseIf logtype = TypeOfLog.Code Then
            Try
                Dim objWriter As New System.IO.StreamWriter(codeloc, True)
                objWriter.WriteLine(DateTime.Now.ToString() & " | " & msg)
                objWriter.Close()
            Catch
            End Try
        End If
    End Sub

    Public Shared Sub WriteError(ByVal ex As Exception)
        Try
            Dim orig As String = ex.ToString
            Dim pub As String = orig.Remove(orig.IndexOf("--- End of inner exception stack trace ---"))
            Dim objWriter As New System.IO.StreamWriter(studioloc, True)
            objWriter.WriteLine(DateTime.Now.ToString() & " | ERROR: " & pub)
            objWriter.Close()
        Catch
        End Try
    End Sub

    Public Shared Sub WriteError(ByVal logtype As TypeOfLog, ByVal ex As Exception)
        If logtype = TypeOfLog.Studio Then
            Try
                Dim orig As String = ex.ToString
                Dim pub As String = orig.Remove(orig.IndexOf("--- End of inner exception stack trace ---"))
                Dim objWriter As New System.IO.StreamWriter(studioloc, True)
                objWriter.WriteLine(DateTime.Now.ToString() & " | ERROR: " & pub)
                objWriter.Close()
            Catch
            End Try
        ElseIf logtype = TypeOfLog.Plugin Then
            Try
                Dim orig As String = ex.ToString
                Dim pub As String = orig.Remove(orig.IndexOf("--- End of inner exception stack trace ---"))
                Dim objWriter As New System.IO.StreamWriter(pluginloc, True)
                objWriter.WriteLine(DateTime.Now.ToString() & " | ERROR: " & pub)
                objWriter.Close()
            Catch
            End Try
        ElseIf logtype = TypeOfLog.Code Then
            Try
                Dim orig As String = ex.ToString
                Dim pub As String = orig.Remove(orig.IndexOf("--- End of inner exception stack trace ---"))
                Dim objWriter As New System.IO.StreamWriter(codeloc, True)
                objWriter.WriteLine(DateTime.Now.ToString() & " | ERROR: " & pub)
                objWriter.Close()
            Catch
            End Try
        End If
    End Sub

    Public Shared Sub ClearLog(ByVal logtype As TypeOfLog)
        If logtype = TypeOfLog.Code Then
            Dim objWriter As New System.IO.StreamWriter(codeloc)
            objWriter.WriteLine(DateTime.Now.ToString() & " | " & "===PREVIOUS LOG HISTORY CLEARED===")
            objWriter.Close()
        ElseIf logtype = TypeOfLog.Plugin Then
            Dim objWriter As New System.IO.StreamWriter(pluginloc)
            objWriter.WriteLine(DateTime.Now.ToString() & " | " & "===PREVIOUS LOG HISTORY CLEARED===")
            objWriter.Close()
        ElseIf logtype = TypeOfLog.Studio Then
            Dim objWriter As New System.IO.StreamWriter(studioloc)
            objWriter.WriteLine(DateTime.Now.ToString() & " | " & "===PREVIOUS LOG HISTORY CLEARED===")
            objWriter.Close()
        End If
    End Sub
End Class
