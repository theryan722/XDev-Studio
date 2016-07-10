Imports System.IO

Public Class dlgQuickOpen

    Private Sub dlgQuickOpen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.Directory.Exists(My.Settings.set_quickopen_folder) Then
            txt_file.Text = My.Settings.set_quickopen_folder & ""
        Else
            txt_file.Text = XDev.Path.Locator.GetWorkspacePath & "\"
        End If
        txt_file.Focus()
        txt_file.SelectionStart = Len(txt_file.Text)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim newb As New FolderBrowserDialog
        newb.ShowNewFolderButton = False
        If Directory.Exists(txt_file.Text) Then
            newb.SelectedPath = txt_file.Text
        End If
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_file.Text = newb.SelectedPath & "\"
            My.Settings.set_quickopen_folder = newb.SelectedPath
        End If
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        If txt_file.Text <> "" AndAlso IO.File.Exists(txt_file.Text) Then
            Try
                Tabs.AddCode(txt_file.Text)
                Me.Close()
            Catch ex As Exception
                Logger.WriteError(ex)
            End Try
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Please fill out the fields properly and make sure the file or directory exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs)
        txt_file.Text = XDev.Path.Locator.GetWorkspacePath & "\"
        My.Settings.set_quickopen_folder = "WORKSPACE"
        txt_file.Focus()
    End Sub

    Private Sub txt_file_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_file.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOpen.PerformClick()
        End If
    End Sub

End Class