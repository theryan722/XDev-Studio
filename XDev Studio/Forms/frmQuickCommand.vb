Friend Class frmQuickCommand

    Private Sub LoadCommands()
        Try
            lb_commands.Items.Clear()
            For Each item As QCObject In QuickCommandLoader.GetQuickCommandList
                lb_commands.Items.Add(item.Text)
            Next
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub frmQuickCommand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCommands()
        FormPosition.CenterForm(Me, frmManager)
        check_closeafterexecute.Checked = My.Settings.set_quickcommand_closeafterexecute
        txt_search.Focus()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Function StringFound(ByVal source As String, ByVal ftxt As String) As Boolean
        Return source.IndexOf(ftxt, 0, StringComparison.CurrentCultureIgnoreCase) > -1
    End Function

    Private Sub btn_execute_Click(sender As Object, e As EventArgs) Handles btn_execute.Click
        If lb_commands.SelectedIndex <> -1 Then
            ExecuteCommand(lb_commands.SelectedItem)
        End If
    End Sub

    Private Sub lb_commands_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lb_commands.MouseDoubleClick
        btn_execute.PerformClick()
    End Sub

    Private Sub ExecuteCommand(ByVal cmd As String)
        For Each item As QCObject In QuickCommandLoader.GetQuickCommandList
            If item.Text = cmd Then
                item.MenuItem.PerformClick()
            End If
        Next
        If check_closeafterexecute.Checked Then
            Me.Close()
        End If
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        lb_commands.Items.Clear()
        For Each item As QCObject In QuickCommandLoader.GetQuickCommandList
            If StringFound(item.Text, txt_search.Text) Then
                lb_commands.Items.Add(item.Text)
            End If
        Next
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        txt_search.Clear()
    End Sub

    Private Sub check_closeafterexecute_CheckedChanged(sender As Object, e As EventArgs) Handles check_closeafterexecute.CheckedChanged
        My.Settings.set_quickcommand_closeafterexecute = check_closeafterexecute.Checked
        My.Settings.Save()
    End Sub
End Class