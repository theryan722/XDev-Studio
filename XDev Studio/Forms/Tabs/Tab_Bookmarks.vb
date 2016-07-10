Imports WeifenLuo.WinFormsUI.Docking

Friend Class Tab_Bookmarks
    Dim flist As New List(Of SearchObject)

    Private Sub LoadBookmarks()
        ListBox1.Items.Clear()
        flist.Clear()
        If My.Settings.set_codebookmarks.Count > 0 Then
            For Each item As String In My.Settings.set_codebookmarks
                Dim arr As String() = item.Split("|")
                Dim newb As New SearchObject(arr(0), arr(1), LanguageEnum.ConvertExtensionToEnum(System.IO.Path.GetExtension(arr(1))))
                flist.Add(newb)
                If arr(2).Length > 50 Then
                    ListBox1.Items.Add("Line: " & arr(0) & " | " & arr(1) & " | " & arr(2).Substring(0, 50) & "...")
                Else
                    ListBox1.Items.Add("Line: " & arr(0) & " | " & arr(1) & " | " & arr(2))
                End If
            Next
        End If
    End Sub

    Private Sub DeleteSelectedItem()
        If ListBox1.Items.Count > 0 And ListBox1.SelectedIndex >= 0 Then
            If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to remove this bookmark?", "Remove Bookmark", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                My.Settings.set_codebookmarks.RemoveAt(ListBox1.SelectedIndex)
                LoadBookmarks()
            End If
        End If
    End Sub

    Private Sub GoToSelectedItem()
        Try
            If ListBox1.Items.Count > 0 And ListBox1.SelectedIndex >= 0 Then
                Dim found As Boolean = False
                For Each item As DockContent In frmManager.DockPanel1.Documents
                    If frmManager.IsCodeEditor(item) Then
                        If CType(item, Tab_CodeEditor).GetFileLocation = flist(ListBox1.SelectedIndex).GetFileLocation Then
                            item.Activate()
                            CType(item, Tab_CodeEditor).GetCurrentEditor().Focus()
                            CType(item, Tab_CodeEditor).GetCurrentEditor().GotoLine(flist(ListBox1.SelectedIndex).GetSearchLine)
                            found = True
                            Exit For
                        End If
                    End If
                Next
                If found = False Then
                    Tabs.AddCode(flist(ListBox1.SelectedIndex).GetFileLocation)
                    'GoToSelectedItem()
                    CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Focus()
                    CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GotoLine(flist(ListBox1.SelectedIndex).GetSearchLine)
                End If
            End If

            'If ListBox1.Items.Count > 0 And ListBox1.SelectedIndex >= 0 Then
            '    Dim index As DockContent = frmManager.GetSpecificCodeEditorByFileLocation(flist(ListBox1.SelectedIndex).GetFileLocation)
            '    If index Is Nothing Then
            '        Tabs.AddCode(My.Computer.FileSystem.ReadAllText(flist(ListBox1.SelectedIndex).GetFileLocation), flist(ListBox1.SelectedIndex).GetFileLanguage, flist(ListBox1.SelectedIndex).GetFileLocation)
            '        'CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().GoTo.Line(flist(lb_results.SelectedIndex).GetSearchLine)
            '        CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().Focus()
            '        CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().Caret.LineNumber = flist(ListBox1.SelectedIndex).GetSearchLine - 1
            '    Else
            '        frmManager.SetActiveForm(index)
            '        'CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().GoTo.Line(flist(lb_results.SelectedIndex).GetSearchLine)
            '        CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().Focus()
            '        CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().Caret.LineNumber = flist(ListBox1.SelectedIndex).GetSearchLine - 1
            '    End If
            'End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub Tab_Bookmarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookmarks()
    End Sub

    Private Sub GoToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToToolStripMenuItem.Click
        GoToSelectedItem()
    End Sub

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If ListBox1.Items.Count > 0 And ListBox1.SelectedIndex >= 0 Then
            If e.KeyCode = Keys.Delete Then
                DeleteSelectedItem()
            ElseIf e.KeyCode = Keys.Enter Then
                GoToSelectedItem()
            End If
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        GoToSelectedItem()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        LoadBookmarks()
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to remove ALL bookmarks?", "Remove All Bookmarks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            My.Settings.set_codebookmarks.Clear()
            LoadBookmarks()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        DeleteSelectedItem()
    End Sub
End Class