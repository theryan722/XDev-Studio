Friend Class frmProfileInfo

#Region "Buttons"

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ProfileManager.LogoutCurrentProfile()
        Me.Close()
    End Sub

#End Region

#Region "Methods"

    Public Sub LoadInfo()
        lblName.Text = CurrentProfile.Name
        lblFolderLocation.Text = CurrentProfile.Folder
        ToolTip1.SetToolTip(lblFolderLocation, lblFolderLocation.Text)
    End Sub

#End Region

    Private Sub frmProfileInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInfo()
        FormPosition.CenterForm(Me)
    End Sub

    Private Sub lblFolderLocation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblFolderLocation.LinkClicked
        'System.Diagnostics.Process.Start("explorer.exe", "/select," & CurrentProfile.Folder)
        My.Computer.Clipboard.SetText(CurrentProfile.Folder)
        NotificationManager.DisplayNotification("Copied user folder path to clipboard!", False)
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If CurrentProfile.Password = "!NONE!" Then
            If MsgBox("Are you sure you want to delete this profile?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Delete Profile") = MsgBoxResult.Yes Then
                ProfileManager.DeleteProfile(CurrentProfile.Name)
                Me.Close()
            End If
        Else
            Dim b As String = InputBox("Enter this profiles password to continue.", "Enter Password", "")
            If b = CurrentProfile.Password Then
                If MsgBox("Are you sure you want to delete this profile?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Delete Profile") = MsgBoxResult.Yes Then
                    ProfileManager.DeleteProfile(CurrentProfile.Name)
                    Me.Close()
                End If
            Else
                MsgBox("Invalid Password!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error")
            End If
        End If
    End Sub

    Private Sub btnSwitchUser_Click(sender As Object, e As EventArgs) Handles btnSwitchUser.Click
        ProfileManager.LogoutCurrentProfile()
        Me.Close()
        frmProfileSelect.Show()
    End Sub

End Class