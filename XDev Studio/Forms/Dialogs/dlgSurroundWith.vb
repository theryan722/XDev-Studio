Friend Class dlgSurroundWith

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub frmSurroundWith_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormPosition.CenterForm(Me, frmManager)
    End Sub
End Class