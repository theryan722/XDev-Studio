Friend Class Tab_Welcome

    Private Sub btn_newproject_Click(sender As Object, e As EventArgs) Handles btn_newproject.Click
        frmManager.NewProjectToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btn_newfile_Click(sender As Object, e As EventArgs) Handles btn_newfile.Click
        frmManager.FileToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub btn_openproject_Click(sender As Object, e As EventArgs) Handles btn_openproject.Click
        frmManager.OpenProjectToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btn_openfile_Click(sender As Object, e As EventArgs) Handles btn_openfile.Click
        frmManager.OpenFileToolStripMenuItem.PerformClick()
    End Sub

    Private Sub btn_bionetworkshome_Click(sender As Object, e As EventArgs) Handles btn_bionetworkshome.Click
        System.Diagnostics.Process.Start("http://www.bionetworkscorp.net/")
    End Sub

    Private Sub btn_bionetworkssupport_Click(sender As Object, e As EventArgs) Handles btn_bionetworkssupport.Click
        System.Diagnostics.Process.Start("http://www.bionetworkscorp.net/support")
    End Sub

    Private Sub check_showatstartup_CheckedChanged(sender As Object, e As EventArgs) Handles check_showatstartup.CheckedChanged
        If check_showatstartup.Checked = True Then
            My.Settings.set_startuptab = "Welcome"
        Else
            My.Settings.set_startuptab = "Editor"
        End If
    End Sub

    Private Sub Tab_Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.set_recentprojects.Count > 0 Then
            For Each item As String In My.Settings.set_recentprojects
                Try
                    listbox_recentprojects.Items.Add(ProjectReader.GetProjectName(item))
                Catch
                End Try
            Next
        End If
        If My.Settings.set_startuptab = "Welcome" Then
            check_showatstartup.Checked = True
        Else
            check_showatstartup.Checked = False
        End If
        If My.Settings.set_displaywelcomeimage Then
            Try
                If My.Settings.set_welcomeimagestyle = "Tile" Then
                    PictureBox1.BackgroundImageLayout = ImageLayout.Tile
                ElseIf My.Settings.set_welcomeimagestyle = "Center" Then
                    PictureBox1.BackgroundImageLayout = ImageLayout.Center
                ElseIf My.Settings.set_welcomeimagestyle = "Stretch" Then
                    PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
                ElseIf My.Settings.set_welcomeimagestyle = "Zoom" Then
                    PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
                End If
                PictureBox1.BackgroundImage = Image.FromFile(My.Settings.set_welcomeimagelocation)
            Catch ex As Exception
            End Try
        Else
            PictureBox1.Hide()
        End If
    End Sub

    Private Sub btn_clearrecentprojects_Click(sender As Object, e As EventArgs) Handles btn_clearrecentprojects.Click
        listbox_recentprojects.Items.Clear()
        My.Settings.set_recentprojects.Clear()
        My.Settings.Save()
    End Sub

    Private Sub listbox_recentprojects_DoubleClick(sender As Object, e As EventArgs) Handles listbox_recentprojects.DoubleClick
        Try
            If listbox_recentprojects.Items.Count > 0 And listbox_recentprojects.SelectedIndex >= 0 Then
                Dim d As Integer = listbox_recentprojects.SelectedIndex
                frmManager.LoadProject(My.Settings.set_recentprojects(d))
            End If
        Catch
        End Try
    End Sub
End Class