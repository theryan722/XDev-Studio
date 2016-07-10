Imports System.IO

Friend Class frmProfileCreate

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        MsgBox("This is the folder where dialogs will automatically open to for opening/saving files.", MsgBoxStyle.OkOnly, "Help")
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Dim newb As New FolderBrowserDialog
        newb.ShowNewFolderButton = True
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_folder.Text = newb.SelectedPath
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        Dim ret As Boolean = True
        If txt_name.Text = "" Or txt_folder.Text = "" Or File.Exists(XDev.Path.Locator.GetDataPath & "\Profiles\" & txt_name.Text & ".xdup") Then
            ret = False
        End If
        Return ret
    End Function

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If ValidateFields() Then
            If Not IO.Directory.Exists(txt_folder.Text) Then
                IO.Directory.CreateDirectory(txt_folder.Text)
            End If
            Dim tpassword As String = txt_password.Text
            If tpassword = "" Then
                tpassword = "!NONE!"
            End If
            ProfileManager.CreateProfile(txt_name.Text, tpassword, txt_folder.Text)
            ProfileManager.LoadProfile(txt_name.Text)
            frmProfileSelect.RefreshProfiles()
            Me.Close()
        Else
            MsgBox("Please make sure you fill out the form correctly. Please make sure the user does not exist and that the folder location is valid.", MsgBoxStyle.OkOnly, "Error")
        End If
    End Sub

    Private Sub frmProfileCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormPosition.CenterForm(Me, frmManager)
        txt_name.Text = ""
        txt_password.Text = ""
        txt_folder.Text = ""
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        txt_folder.Text = XDev.Path.Locator.GetWorkspacePath & "\Profiles\" & txt_name.Text
    End Sub
End Class