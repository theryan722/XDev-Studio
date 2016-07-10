Friend Class Tab_TestBrowser

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        WebBrowser1.Refresh()
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        WebBrowser1.Stop()
    End Sub

    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub ForwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForwardToolStripMenuItem.Click
        WebBrowser1.GoForward()
    End Sub

    Public Sub DisplayHtml(ByVal html As String)
        WebBrowser1.Navigate("about:blank")
        If WebBrowser1.Document IsNot Nothing Then
            WebBrowser1.Document.Write(String.Empty)
        End If
        WebBrowser1.DocumentText = html
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        URLToolStripMenuItem.Text = "URL: " & WebBrowser1.Url.ToString
    End Sub
End Class