Imports WeifenLuo.WinFormsUI.Docking

Friend Class frmWindows
    Public Sub RefreshList()
        Try
            lst.Items.Clear()
            For Each doc As DockContent In frmManager.DockPanel1.Documents
                Dim lvi As New ListViewItem
                lvi.Text = doc.Text
                lvi.Tag = doc
                lvi.ImageIndex = 0
                lst.Items.Add(lvi)
                If CType(frmManager.DockPanel1.ActiveDocument, DockContent) Is doc Then lvi.Selected = True
                lst.Refresh()
            Next
        Catch
        End Try
    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub

    Private Sub frmWindows_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
    End Sub

    Private Sub frmWindows_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Owner = frmManager
            lst.View = View.Details
            lst.GridLines = False
            lst.FullRowSelect = True
            lst.HideSelection = False
            lst.MultiSelect = True
            lst.Columns.Add("Window")
            lst.Columns(0).Width = 200
            For Each doc As DockContent In frmManager.DockPanel1.Documents
                Dim lvi As New ListViewItem
                lvi.Text = doc.Text
                lvi.Tag = doc
                lvi.ImageIndex = 0
                lst.Items.Add(lvi)
            Next
        Catch
        End Try
    End Sub

#Region "Context Menu Strip"

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub

    Private Sub ActivateWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateWindowToolStripMenuItem.Click
        Try
            Dim doc As DockContent = CType(lst.SelectedItems(0).Tag, DockContent)
            If doc IsNot Nothing Then
                doc.Activate()
            End If
            RefreshList()
        Catch
        End Try
    End Sub

    Private Sub CloseWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseWindowToolStripMenuItem.Click
        Try
            Dim doc As DockContent = CType(lst.SelectedItems(0).Tag, DockContent)
            If doc IsNot Nothing Then
                doc.Close()
            End If
            RefreshList()
        Catch
        End Try
    End Sub

#End Region

    Private Sub lst_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lst.MouseDoubleClick
        Try
            Dim doc As DockContent = CType(lst.SelectedItems(0).Tag, DockContent)
            If doc IsNot Nothing Then
                doc.Activate()
            End If
            RefreshList()
        Catch
        End Try
    End Sub
End Class