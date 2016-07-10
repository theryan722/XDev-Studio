Friend Class frmColorPicker

    Private Sub frmColorPicker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
        frmManager.Focus()
    End Sub

    Private Sub frmColorPicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmManager
    End Sub

    Private Sub check_topmost_CheckedChanged(sender As Object, e As EventArgs) Handles check_topmost.CheckedChanged
        If check_topmost.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub
End Class