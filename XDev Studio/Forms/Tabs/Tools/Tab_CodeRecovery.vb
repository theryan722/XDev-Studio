Imports System.IO

Friend Class Tab_CodeRecovery

    Private reclist As New List(Of String)

#Region "Methods"

    Private Sub DeleteFile(ByVal floc As String)
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to delete this recovery file? '" & Path.GetFileName(floc) & "'", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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
            Dim di As New IO.DirectoryInfo(XDev.Path.Locator.GetWorkspacePath & "\CodeRecovery")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For Each dra As FileInfo In diar1
                reclist.Add(dra.FullName)
                ListBox1.Items.Add(dra)
            Next
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

#End Region

#Region "Listbox"

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If ListBox1.SelectedIndex <> -1 Then
                DeleteFile(reclist(ListBox1.SelectedIndex))
            End If
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then
            LoadFile(reclist(ListBox1.SelectedIndex))
        End If
    End Sub

#End Region

#Region "Top Panel"

    Private Sub btn_clearallrecoveryfiles_Click(sender As Object, e As EventArgs) Handles btn_clearallrecoveryfiles.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to delete ALL recovery files?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                ListBox1.Items.Clear()
                reclist.Clear()
                TextBox1.Clear()
                Dim di As New IO.DirectoryInfo(XDev.Path.Locator.GetWorkspacePath & "\CodeRecovery")
                Dim diar1 As IO.FileInfo() = di.GetFiles()
                For Each dra As FileInfo In diar1
                    System.IO.File.Delete(dra.FullName)
                Next
            Catch ex As Exception
                Logger.WriteError(ex)
            End Try
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

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshListBox()
    End Sub

#End Region

#Region "Textbox"

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
    End Sub

    Private Sub OpenInNewEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInNewEditorToolStripMenuItem.Click
        If TextBox1.Text <> "" Then
            Tabs.AddCodeWithoutFile(TextBox1.Text)
        End If
    End Sub

    Private Sub OpenInNewNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInNewNotepadToolStripMenuItem.Click
        If TextBox1.Text <> "" Then
            Tabs.AddNotepad(TextBox1.Text)
        End If
    End Sub

#End Region

#End Region

#Region "Tab_CodeRecovery"

    Private Sub Tab_CodeRecovery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshListBox()
    End Sub

#End Region

End Class