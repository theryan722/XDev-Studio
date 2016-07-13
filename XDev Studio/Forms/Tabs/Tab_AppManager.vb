Imports System.IO

Friend Class Tab_AppManager

    Private _applist As New List(Of AppObject)

#Region "Methods"

    Private Function CreateAppObjectFromFile(ByVal floc As String) As AppObject
        Try
            Dim b As New AppObject
            Dim xml = XDocument.Load(floc)
            b.Name = xml.<XDevApp>.<Name>.Value
            b.Command = xml.<XDevApp>.<Command>.Value
            b.Arguments = xml.<XDevApp>.<Arguments>.Value
            b.FileLoc = floc
            Return b
        Catch ex As Exception
            Logger.WriteError(ex)
            Return Nothing
        End Try
    End Function

    Private Function CheckIfFieldsValid() As Boolean
        Return Not (txt_name.Text = "" And txt_command.Text = "")
    End Function

    Private Sub GetAppsList()
        lb_apps.Items.Clear()
        _applist.Clear()
        Dim bb As String() = Directory.GetFiles(XDev.Path.Locator.GetDataPath + "\Apps", "*.xaf")
        Dim newb As ICollection(Of AppObject) = New List(Of AppObject)(bb.Count)
        For Each item As String In bb
            _applist.Add(CreateAppObjectFromFile(item))
        Next
        For Each item As AppObject In _applist
            lb_apps.Items.Add(item.Name)
        Next
    End Sub

    Private Sub RefreshLB()
        lb_apps.Items.Clear()
        For Each item As AppObject In _applist
            lb_apps.Items.Add(item.Name)
        Next
    End Sub

#End Region

#Region "Tab_AppManager"

    Private Sub Tab_AppManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAppsList()
    End Sub

#End Region

#Region "lb_apps"

    Private Sub lb_apps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_apps.SelectedIndexChanged
        If lb_apps.SelectedIndex <> -1 Then
            txt_name.Text = _applist(lb_apps.SelectedIndex).Name
            txt_command.Text = _applist(lb_apps.SelectedIndex).Command
            txt_arguments.Text = _applist(lb_apps.SelectedIndex).Arguments
        Else
            txt_name.Text = ""
            txt_command.Text = ""
            txt_arguments.Text = ""
        End If
    End Sub

#End Region

#Region "Buttons"

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        _applist.Add(New AppObject("New App", "", ""))
        RefreshLB()
    End Sub

    Private Sub btn_remove_Click(sender As Object, e As EventArgs) Handles btn_remove.Click
        If lb_apps.SelectedIndex <> -1 Then
            _applist(lb_apps.SelectedIndex).DeleteFile()
            _applist.RemoveAt(lb_apps.SelectedIndex)
            RefreshLB()
        End If
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            For Each item As AppObject In _applist
                item.WriteAppFile()
            Next
            If MetroFramework.MetroMessageBox.Show(frmManager, "Saved changes! In order for these changes to take effect you must restart XDev Studio. Would you like to do so now?", "Applied Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                frmManager.Close()
                frmManager.NewInstanceToolStripMenuItem.PerformClick()
            End If
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub btn_apply_Click(sender As Object, e As EventArgs) Handles btn_apply.Click
        If lb_apps.SelectedIndex <> -1 Then
            If CheckIfFieldsValid() Then
                _applist(lb_apps.SelectedIndex).Name = txt_name.Text
                _applist(lb_apps.SelectedIndex).Command = txt_command.Text
                _applist(lb_apps.SelectedIndex).Arguments = txt_arguments.Text
                RefreshLB()
                MetroFramework.MetroMessageBox.Show(frmManager, "Applied changes to App '" & txt_name.Text & "'", "Applied Changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroFramework.MetroMessageBox.Show(frmManager, "Please make sure all fields are filled out properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

#End Region

End Class
