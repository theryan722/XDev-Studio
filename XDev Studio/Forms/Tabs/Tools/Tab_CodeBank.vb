Imports System.IO

Friend Class Tab_CodeBank

    Private reclist As New List(Of String)

#Region "Methods"

    Private Sub CopyFromFileLocation(ByVal floc As String)
        Try
            My.Computer.Clipboard.SetText(My.Computer.FileSystem.ReadAllText(floc))
            MetroFramework.MetroMessageBox.Show(frmManager, "Copied source to clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub DeleteFile(ByVal floc As String)
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to delete this file?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                System.IO.File.Delete(floc)
                RefreshListBox()
            Catch ex As Exception
                Logger.WriteError(ex)
            End Try
        End If
    End Sub

    Private Sub LoadFile(ByVal floc As String)
        Try
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(floc)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub RefreshListBox()
        Try
            ListBox1.Items.Clear()
            reclist.Clear()
            TextBox1.Clear()
            Dim di As New IO.DirectoryInfo(XDev.Path.Locator.GetWorkspacePath & "\CodeBank")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For Each dra As FileInfo In diar1
                reclist.Add(dra.FullName)
                ListBox1.Items.Add(Path.GetFileNameWithoutExtension(dra.ToString))
            Next
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

#End Region

#Region "ListBox"

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If ListBox1.SelectedIndex <> -1 Then
                DeleteFile(reclist(ListBox1.SelectedIndex))
            End If
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        If ListBox1.SelectedIndex <> -1 Then
            CopyFromFileLocation(reclist(ListBox1.SelectedIndex))
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then
            LoadFile(reclist(ListBox1.SelectedIndex))
        End If
    End Sub

#End Region

#Region "Top Panel"

    Private Sub txt_newfile_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_newfile.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_addnewfile.PerformClick()
        End If
    End Sub

    Private Sub btn_addnewfile_Click(sender As Object, e As EventArgs) Handles btn_addnewfile.Click
        If txt_newfile.Text <> "" Then
            If Not File.Exists(XDev.Path.Locator.GetWorkspacePath & "\CodeBank\" & txt_newfile.Text & ".xdcb") Then
                My.Computer.FileSystem.WriteAllText(XDev.Path.Locator.GetWorkspacePath & "\CodeBank\" & txt_newfile.Text & ".xdcb", "", False)
                RefreshListBox()
            Else
                MetroFramework.MetroMessageBox.Show(frmManager, "Error: File already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btn_savechanges_Click(sender As Object, e As EventArgs) Handles btn_savechanges.Click
        If ListBox1.SelectedIndex <> -1 Then
            Try
                My.Computer.FileSystem.WriteAllText(reclist(ListBox1.SelectedIndex), TextBox1.Text, False)
            Catch ex As Exception
                Logger.WriteError(ex)
            End Try
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Error: No file selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

#Region "Context Menu Strips"

#Region "Listbox"

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If ListBox1.SelectedIndex <> -1 Then
            DeleteFile(reclist(ListBox1.SelectedIndex))
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If ListBox1.SelectedIndex <> -1 Then
            CopyFromFileLocation(reclist(ListBox1.SelectedIndex))
        End If
    End Sub

    Private Sub OpenInNewEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInNewEditorToolStripMenuItem.Click
        If ListBox1.SelectedIndex <> -1 Then
            Tabs.AddCodeWithoutFile(My.Computer.FileSystem.ReadAllText(reclist(ListBox1.SelectedIndex)))
        End If
    End Sub

    Private Sub OpenInNewNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInNewNotepadToolStripMenuItem.Click
        If ListBox1.SelectedIndex <> -1 Then
            If ListBox1.SelectedIndex <> -1 Then
                Tabs.AddNotepad(My.Computer.FileSystem.ReadAllText(reclist(ListBox1.SelectedIndex)))
            End If
        End If
    End Sub

#End Region

#Region "Textbox"

    Private Sub SaveChangesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveChangesToolStripMenuItem.Click
        btn_savechanges.PerformClick()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim newb As New FontDialog
        newb.Font = TextBox1.Font
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Font = newb.Font
        End If
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem1.Click
        TextBox1.Copy()
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        TextBox1.SelectAll()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        TextBox1.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        TextBox1.Paste()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        TextBox1.Undo()
    End Sub

    Private Sub OpenInNewEditorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenInNewEditorToolStripMenuItem1.Click
        Tabs.AddCodeWithoutFile(TextBox1.Text)
    End Sub

    Private Sub OpenInNewNotepadToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenInNewNotepadToolStripMenuItem1.Click
        Tabs.AddNotepad(TextBox1.Text)
    End Sub

    Private Sub OpenSelectionInNewEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSelectionInNewEditorToolStripMenuItem.Click
        Tabs.AddCodeWithoutFile(TextBox1.SelectedText)
    End Sub

    Private Sub OpenSelectionInNewNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSelectionInNewNotepadToolStripMenuItem.Click
        Tabs.AddNotepad(TextBox1.SelectedText)
    End Sub

#End Region

#End Region

#Region "Tab_CodeBank"

    Private Sub Tab_CodeBank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshListBox()
    End Sub

#End Region

End Class