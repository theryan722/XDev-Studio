Friend Class frmAbout

    Private Sub frmAbout_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
        frmManager.Focus()
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmManager
        MetroLabel1.Text = "Version: " & Application.ProductVersion
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        System.Diagnostics.Process.Start("https://github.com/theryan722/XDev-Studio")
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub

    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
    End Sub

    Private Sub btn_pssversion_Click(sender As Object, e As EventArgs) Handles btn_pssversion.Click
        MsgBox("PSS Version: " & My.Resources.PSSVersion, MsgBoxStyle.OkOnly, "PSS Version")
    End Sub
End Class