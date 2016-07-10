Friend Class Tab_WYSIWYGEditor

    Private Sub Tab_WYSIWYGEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("file:///" & XDev.Path.Locator.GetAppPath & "\Engine\Tools\WYSIWYG\index.html")
    End Sub

End Class