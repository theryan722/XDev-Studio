Friend Class frmAbout

    'Launch github page
   Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        System.Diagnostics.Process.Start("https://github.com/theryan722/XDev-Studio")
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub

    'Copy license info to clipboard
    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(TextBox1.Text)
    End Sub
    
End Class