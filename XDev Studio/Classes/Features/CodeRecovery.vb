Imports System.IO
Imports WeifenLuo.WinFormsUI.Docking

Friend Class CodeRecovery

    Private Shared Function NoDuplicates(ByVal txt As String) As Boolean
        Dim ret As Boolean = True
        Try
            Dim di As New IO.DirectoryInfo(XDev.Path.Locator.GetWorkspacePath & "\CodeRecovery")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For Each dra As FileInfo In diar1
                Dim t As String = My.Computer.FileSystem.ReadAllText(dra.FullName)
                If t = txt Then
                    ret = False
                End If
            Next
            Return ret
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Function

    Private Shared Sub SaveCode(ByVal txt As String, ByVal filename As String)
        Dim fileloc As String = XDev.Path.Locator.GetWorkspacePath & "\CodeRecovery\" & filename & "_" & DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss") & ".xdcr"
        Dim t As Task = Task.Factory.StartNew(Sub()
                                                  Try
                                                      If NoDuplicates(txt) Then
                                                          My.Computer.FileSystem.WriteAllText(fileloc, txt, False)
                                                          Logger.Write("CodeRecovery: Saved snapshot of code from '" & filename & "'")
                                                      End If
                                                  Catch ex As Exception
                                                      Logger.WriteError(ex)
                                                  End Try
                                              End Sub)

    End Sub

    Public Shared Sub SaveSnapshot(ByVal editor As XDockContent)
        If TypeOf editor Is Tab_CodeEditor Then
            Dim a As String = CType(editor, Tab_CodeEditor).TextBox1.Text
            Dim b As String = CType(editor, Tab_CodeEditor).GetFileName
            If b = "" Then
                b = "Untitled"
            End If
            If a <> "" Then
                SaveCode(a, b)
            End If
        ElseIf TypeOf editor Is Tab_Notepad Then
            Dim a As String = CType(editor, Tab_Notepad).TextBox1.Text
            Dim b As String = CType(editor, Tab_Notepad).GetFileName
            If b = "" Then
                b = "Untitled"
            End If
            If a <> "" Then
                SaveCode(a, b)
            End If
        End If
    End Sub

    Public Shared Sub SaveSnapshotsForAllOpenDocuments()
        Try
            If frmManager.AtLeastOneEditor Then
                For Each item As DockContent In frmManager.DockPanel1.Documents
                    SaveSnapshot(item)
                Next
            End If
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

End Class
