Friend Class frmLock
    Dim okaytoclose As Boolean = False
    Private Sub frmLock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If okaytoclose = True Then
            Me.Owner = Nothing
            frmManager.UnlockStudio()
            frmManager.Focus()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmLock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmManager
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        If MsgBox("If you cancel, the studio will be closed. Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Cancel Unlock") = MsgBoxResult.Yes Then
            okaytoclose = True
            frmManager.closebecauselock = True
            frmManager.Close()

        End If
    End Sub

    Private Sub btn_unlock_Click(sender As Object, e As EventArgs) Handles btn_unlock.Click
        If txt_pass.Text = My.Settings.set_applockpassword Then
            okaytoclose = True
            Me.Close()
        Else
            MsgBox("Invalid password entered. Please try again.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            txt_pass.Text = ""
        End If
    End Sub
End Class