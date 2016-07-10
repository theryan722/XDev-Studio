Imports System.ComponentModel.Design

Friend Class Tab_HexViewer

    Dim bv As New ByteViewer()

    Private Sub Tab_HexViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Controls.Add(bv)
        bv.BringToFront()
        bv.Dock = DockStyle.Fill
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Filter = frmManager.GetFileFilter()
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            bv.SetFile(newb.FileName)
        End If
    End Sub

    Private Sub SaveToFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToFileToolStripMenuItem.Click
        Dim newb As New SaveFileDialog
        newb.Filter = frmManager.GetFileFilter()
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            bv.SaveToFile(newb.FileName)
        End If
    End Sub

End Class