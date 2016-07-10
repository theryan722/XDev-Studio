Imports System.IO

Friend Class pnlFavorites

#Region "Methods"

    Private Sub OpenFavorite()
        If ListBox1.SelectedIndex <> -1 Then
            Tabs.AddCode(My.Settings.set_favorites(ListBox1.SelectedIndex))
        End If
    End Sub

    Private Sub RefreshFavorites()
        ListBox1.Items.Clear()
        For Each item As String In My.Settings.set_favorites
            ListBox1.Items.Add(Path.GetFileName(item) & "|" & item)
        Next
    End Sub

    Private Sub RemoveFavorite()
        If ListBox1.SelectedIndex <> -1 Then
            My.Settings.set_favorites.RemoveAt(ListBox1.SelectedIndex)
            RefreshFavorites()
        End If
    End Sub

#End Region

#Region "Context Menu Strip"

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshFavorites()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFavorite()
    End Sub

    Private Sub AddFavoriteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFavoriteToolStripMenuItem.Click
        pnl_addfavorite.Show()
        txt_fileloc.Focus()
    End Sub
    Private Sub RemoveFavoriteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveFavoriteToolStripMenuItem.Click
        RemoveFavorite()
    End Sub

#End Region

#Region "Add Favorite"

    Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        Dim newb As New OpenFileDialog
        newb.Filter = frmManager.GetFileFilter()
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_fileloc.Text = newb.FileName
        End If
    End Sub

    Private Sub txt_fileloc_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_fileloc.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_add.PerformClick()
        End If
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        txt_fileloc.Clear()
        pnl_addfavorite.Hide()
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        If System.IO.File.Exists(txt_fileloc.Text) Then
            My.Settings.set_favorites.Add(txt_fileloc.Text)
            My.Settings.Save()
            RefreshFavorites()
            txt_fileloc.Clear()
            pnl_addfavorite.Hide()
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Please make sure the file exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

#Region "pnlFavorites"

    Private Sub pnlFavorites_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshFavorites()
    End Sub

#End Region

#Region "Listbox1"

    Private Sub ListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenFavorite()
        ElseIf e.KeyCode = Keys.Delete Then
            RemoveFavorite()
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        OpenFavorite()
    End Sub

#End Region

End Class