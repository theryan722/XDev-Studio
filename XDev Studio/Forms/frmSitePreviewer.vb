Friend Class frmSitePreviewer

    Private Sub check_topmost_CheckedChanged(sender As Object, e As EventArgs) Handles check_topmost.CheckedChanged
        If check_topmost.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

    Public Sub PreviewWebsite(ByVal url As String)
        txt_website.Text = FixURL(url)
        If txt_website.Text IsNot "" Then
            Previewer1.StartRender(FixURL(txt_website.Text))
        End If
    End Sub

    Private Sub frmSitePreviewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
    End Sub

    Private Sub frmSitePreviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmManager
    End Sub

    Private Function FixURL(ByVal url As String) As String
        If Not url.StartsWith("http://") Then
            Return "http://" & url
            txt_website.Text = "http://" & url
        Else
            Return url
        End If
    End Function

    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        Try
            If txt_website.Text IsNot "" Then
                Previewer1.StartRender(FixURL(txt_website.Text))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub txt_website_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_website.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_preview.PerformClick()
        End If
    End Sub
End Class