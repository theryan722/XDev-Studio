Friend Class Tab_WebBrowser

    Public Sub DisplayHyperlinks(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs)
        Dim url As String = e.ToElement.GetAttribute("href")
        ToolStripStatusLabel1.Text = url
    End Sub

    Private Sub btn_Back_Click(sender As Object, e As EventArgs) Handles btn_Back.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub btn_Forward_Click(sender As Object, e As EventArgs) Handles btn_Forward.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub btn_Stop_Click(sender As Object, e As EventArgs) Handles btn_Stop.Click
        WebBrowser1.Stop()
    End Sub

    Private Sub btn_Refresh_Click(sender As Object, e As EventArgs) Handles btn_Refresh.Click
        WebBrowser1.Refresh()
    End Sub

    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click
        WebBrowser1.Navigate(My.Settings.set_browserhome)
    End Sub

    Private Sub btn_Navigate_Click(sender As Object, e As EventArgs) Handles btn_Navigate.Click
        Try
            WebBrowser1.Navigate(TextBox1.Text)
            TextBox1.Items.Add(WebBrowser1.Url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        AddHandler WebBrowser1.Document.MouseOver, AddressOf Me.DisplayHyperlinks
        Dim b As String = WebBrowser1.DocumentTitle
        If b.Length > 20 Then
            Me.Parent.Text = b.Substring(0, 20) & "... - WebBrowser"
        Else
            Me.Parent.Text = b & " - WebBrowser"
        End If
        TextBox1.Text = WebBrowser1.Url.ToString
        Me.DockHandler.ToolTipText = WebBrowser1.Url.ToString
    End Sub

    Public Sub LoadURL(ByVal url As String)
        WebBrowser1.Navigate(url)
    End Sub

    Private Sub Tab_WebBrowser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        WebBrowser1.Stop()
    End Sub

    Private Sub Tab_WebBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate(My.Settings.set_browserhome)
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_Navigate.PerformClick()
        End If
    End Sub

    Private Sub btn_openwebsiteinwebbrowser_Click(sender As Object, e As EventArgs) Handles btn_openwebsiteinwebbrowser.Click
        Try
            System.Diagnostics.Process.Start(WebBrowser1.Url.ToString)
        Catch
        End Try
    End Sub
End Class