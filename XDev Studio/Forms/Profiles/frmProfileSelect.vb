Imports System.IO

Friend Class frmProfileSelect

    Public Sub RefreshProfiles()
        Try
            ListBox1.Items.Clear()
            PictureBox1.BackgroundImage = My.Resources._96_profile
            Dim di As New IO.DirectoryInfo(XDev.Path.Locator.GetDataPath & "\Profiles")
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            For Each dra As FileInfo In diar1
                ListBox1.Items.Add(Path.GetFileNameWithoutExtension(dra.ToString))
            Next
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        MetroButton2.PerformClick()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        frmProfileCreate.ShowDialog()
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        If ListBox1.SelectedIndex <> -1 Then
            If ProfileManager.GetPassword(ListBox1.SelectedItem) = "!NONE!" Then
                ProfileManager.LoadProfile(ListBox1.SelectedItem)
                Me.Close()
                Dim newb As New BN.Toast.ToastForm(2000, "Loaded profile '" & CurrentProfile.Name & "'")
                newb.Height = "30"
                newb.TopMost = True
                newb.Show()
            Else
                Dim b As String = InputBox("Please enter the password to login to this profile.", "Password", "")
                If b = ProfileManager.GetPassword(ListBox1.SelectedItem) Then
                    ProfileManager.LoadProfile(ListBox1.SelectedItem)
                    Me.Close()
                    Dim newb As New BN.Toast.ToastForm(2000, "Loaded profile '" & CurrentProfile.Name & "'")
                    newb.Height = "30"
                    newb.TopMost = True
                    newb.Show()
                Else
                    MsgBox("Invalid Password!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error")
                End If
            End If
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshProfiles()
    End Sub

    Private Sub frmProfileSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshProfiles()
        FormPosition.CenterForm(Me, frmManager)
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LoginToSelectedProfileAtStartupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToSelectedProfileAtStartupToolStripMenuItem.Click
        If ListBox1.SelectedIndex <> -1 Then
            My.Settings.set_profilestartup = ListBox1.SelectedItem
            MsgBox("This profile will automatically be logged in at application startup.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Profile")
        End If
    End Sub

    Private Sub DoNotAutomaticallyLoginToAProfileAtStartupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoNotAutomaticallyLoginToAProfileAtStartupToolStripMenuItem.Click
        My.Settings.set_profilestartup = ""
        MsgBox("No profile will be automatically logged in at startup.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Profile")
    End Sub
End Class