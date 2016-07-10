Friend Class frmProjectInfo

#Region "Methods"
    Private Sub RefreshTextView()
        Text_view.Clear()
        Text_view.Text = "Project Name: " & ProjectReader.GetProjectName & vbNewLine & vbNewLine & "Project Version: " & ProjectReader.GetProjectVersion & vbNewLine & vbNewLine & "Project License: " & ProjectReader.GetProjectLicense & vbNewLine & vbNewLine & "Project Language: " & LanguageEnum.ConvertEnumToReadable(ProjectReader.GetProjectLanguage) & vbNewLine & vbNewLine & "Developer: " & ProjectReader.GetDeveloperName & vbNewLine & vbNewLine & "Developer Contact: " & ProjectReader.GetDeveloperContact & vbNewLine & vbNewLine & "Developer Website: " & ProjectReader.GetDeveloperWebsite
    End Sub

    Private Sub RefreshEditBoxes()
        txt_contact.Text = ProjectReader.GetDeveloperContact()
        txt_developer.Text = ProjectReader.GetDeveloperName()
        txt_projlicense.Text = ProjectReader.GetProjectLicense()
        txt_projname.Text = ProjectReader.GetProjectName()
        txt_projver.Text = ProjectReader.GetProjectVersion()
        txt_website.Text = ProjectReader.GetDeveloperWebsite()
        combo_projlang.Text = ProjectReader.GetProjectLanguage()
    End Sub

#End Region

#Region "Tabs"

#Region "Tab: View"
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Text_view.Copy()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshTextView()
    End Sub
#End Region

#Region "Tab: Edit"
    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        RefreshEditBoxes()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        ProjectWriter.SetDeveloperContact(txt_contact.Text)
        ProjectWriter.SetDeveloperName(txt_developer.Text)
        ProjectWriter.SetDeveloperWebsite(txt_website.Text)
        ProjectWriter.SetProjectLanguage(LanguageEnum.ConvertReadableToEnum(combo_projlang.Text))
        ProjectWriter.SetProjectLicense(txt_projlicense.Text)
        ProjectWriter.SetProjectName(txt_projname.Text)
        ProjectWriter.SetProjectVersion(txt_projver.Text)
        ProjectWriter.SetProjectLocation(txt_projlocation.Text)
        MetroFramework.MetroMessageBox.Show(frmManager, "Saved Project Details!", "Project Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#End Region

    Private Sub frmProjectInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
    End Sub

    Private Sub frmProjectInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmManager
        RefreshTextView()
        RefreshEditBoxes()
    End Sub

    Private Sub check_topmost_CheckedChanged(sender As Object, e As EventArgs) Handles check_topmost.CheckedChanged
        If check_topmost.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

End Class