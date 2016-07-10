Friend Class pnlImageViewer

    Private Sub btn_open_Click(sender As Object, e As EventArgs) Handles btn_open.Click
        Dim newb As New OpenFileDialog
        newb.Filter = "Picture Files(*.bmp;*.gif;*jpg;*.png)|*.bmp;*.gif;*.jpg;*.png|BMP files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif|JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_fileloc.Text = newb.FileName
            openimage(newb.FileName)
        End If
    End Sub

    Private Sub openimage(ByVal imgloc As String)
        Try
            PictureBox1.BackgroundImage = Image.FromFile(imgloc)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub txt_fileloc_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_fileloc.KeyDown
        If e.KeyCode = Keys.Enter Then
            openimage(txt_fileloc.Text)
        End If
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        PictureBox1.BackgroundImage = Nothing
    End Sub

    Private Sub BackgroundColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackgroundColorToolStripMenuItem.Click
        Dim newb As New ColorDialog
        newb.Color = PictureBox1.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackColor = newb.Color
        End If
    End Sub

    Private Sub DecheckLayout()
        NoneToolStripMenuItem.Checked = False
        TileToolStripMenuItem.Checked = False
        CenterToolStripMenuItem.Checked = False
        StretchToolStripMenuItem.Checked = False
        ZoomToolStripMenuItem.Checked = False
    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoneToolStripMenuItem.Click
        DecheckLayout()
        NoneToolStripMenuItem.Checked = True
        PictureBox1.BackgroundImageLayout = ImageLayout.None
    End Sub

    Private Sub TileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileToolStripMenuItem.Click
        DecheckLayout()
        TileToolStripMenuItem.Checked = True
        PictureBox1.BackgroundImageLayout = ImageLayout.Tile
    End Sub

    Private Sub CenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CenterToolStripMenuItem.Click
        DecheckLayout()
        CenterToolStripMenuItem.Checked = True
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
    End Sub

    Private Sub StretchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StretchToolStripMenuItem.Click
        DecheckLayout()
        StretchToolStripMenuItem.Checked = True
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Sub ZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem.Click
        DecheckLayout()
        ZoomToolStripMenuItem.Checked = True
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
    End Sub
End Class