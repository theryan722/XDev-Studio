Public Class GlobalClipboardHistoryUpdater

    Public Shared Sub AddToAllEditors(ByVal txt As String)
        If Not My.Settings.temp_performancemode Then
            If Not My.Settings.set_clipboardhistory.Contains(txt) Then
                My.Settings.set_clipboardhistory.Add(txt)
            End If
            If frmManager.AtLeastOneCodeEditor() Then
                For Each item As XDockContent In frmManager.DockPanel1.Documents
                    If frmManager.IsCodeEditor(item) Then
                        CType(item, Tab_CodeEditor).AddToClipboardHistory(txt)
                    End If
                Next
            End If
        End If
    End Sub

    Public Shared Sub ClearForAllEditors()
        If Not My.Settings.temp_performancemode Then
            My.Settings.set_clipboardhistory.Clear()
            If frmManager.AtLeastOneCodeEditor() Then
                For Each item As XDockContent In frmManager.DockPanel1.Documents
                    If frmManager.IsCodeEditor(item) Then
                        CType(item, Tab_CodeEditor).ClearClipboardHistory()
                    End If
                Next
            End If
        End If
    End Sub

End Class
