Option Strict On

Imports Edanmo.TaskScheduler
Imports MetroFramework

Friend Class Tab_TaskScheduler

    Private m_TaskScheduler As New TaskCollection()

    Private Sub RefreshList()
        Dim TaskName As String

        lstTasks.Items.Clear()

        For Each TaskName In m_TaskScheduler
            If Not TaskName.ToLower.StartsWith("googleupdate") AndAlso Not TaskName.ToLower.StartsWith("adobe") Then
                lstTasks.Items.Add(TaskName)
            End If
        Next

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstTasks.SelectedIndex > -1 Then

            If MetroMessageBox.Show(frmManager, "The operation can't be undone. Are you sure you want to delete """ & lstTasks.SelectedItem.ToString() & """?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                m_TaskScheduler.Remove(lstTasks.SelectedItem.ToString())
                RefreshList()
            End If

        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim sTaskName As String
        Dim oTask As Task

        If dlgOpenFile.ShowDialog() = DialogResult.OK Then

            sTaskName = InputBox("Type the task name", , "My New Task")

            Try

                oTask = m_TaskScheduler.Add(sTaskName & ".job", ".NET Task Scheduler Test Application")

                With oTask

                    ' Set the exe path
                    .ApplicationName = dlgOpenFile.FileName

                    .Flags = Task.TaskFlags.Interactive
                    .Creator = "UTMAG Demo"

                    ' Add a m_TaskScheduler
                    With .Triggers.Add()
                        .TriggerType = Trigger.Types.Daily
                        .BeginDay = Date.Today
                        .StartTime = Now
                        .Flags = Trigger.TriggerFlags.HasEndDate
                        .EndDay = Date.Parse("9999/12/31")
                    End With

                    ' Save the task
                    .Save()

                    .ShowProperties()

                End With

                RefreshList()

            Catch ex As Exception
                Stop
            End Try

        End If
    End Sub

    Private Sub btnProperties_Click(sender As Object, e As EventArgs) Handles btnProperties.Click
        If lstTasks.SelectedIndex > -1 Then

            Dim oTask As Task

            oTask = m_TaskScheduler.Item(CStr(lstTasks.SelectedItem))
            oTask.ShowProperties(Me)

            RefreshList()

        End If
    End Sub

    Private Sub btnRunNow_Click(sender As Object, e As EventArgs) Handles btnRunNow.Click
        Dim Task As Edanmo.TaskScheduler.Task

        Task = m_TaskScheduler.Item(CStr(lstTasks.SelectedItem))
        Task.Run()
        Task.Dispose()
    End Sub

    Private Sub lstTasks_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstTasks.SelectedIndexChanged

        Dim Task As Edanmo.TaskScheduler.Task
        Dim Trigger As Edanmo.TaskScheduler.Trigger

        Task = m_TaskScheduler.Item(CStr(lstTasks.SelectedItem))

        lblInfo_0.Text = Task.ApplicationName
        lblInfo_1.Text = Task.CommandLine
        txtComments.Text = Task.Comment
        lblInfo_2.Text = Flags(Task.Flags)
        lblInfo_3.Text = Task.LastRunTime.ToString("F")
        lblInfo_4.Text = Task.NextRunTime.ToString("F")
        lblInfo_5.Text = Task.Creator

        lstSchedules.Items.Clear()
        For Each Trigger In Task.Triggers
            lstSchedules.Items.Add(Trigger.Text)
        Next

        Task.Dispose()

    End Sub

    Private Function Flags(ByVal F As Task.TaskFlags) As String
        Dim T As String

        If (F And Task.TaskFlags.DeleteWhenDone) <> 0 Then T = T & "Delete When Done - "
        If (F And Task.TaskFlags.Disabled) <> 0 Then T = T & "Disabled - "
        If (F And Task.TaskFlags.DontStartIfOnBatteries) <> 0 Then T = T & "Don't Start If On Batteries - "
        If (F And Task.TaskFlags.Hidden) <> 0 Then T = T & "Hidden - "
        If (F And Task.TaskFlags.Interactive) <> 0 Then T = T & "Interactive - "
        If (F And Task.TaskFlags.KillIfGoingOnBatteries) <> 0 Then T = T & "Kill If Going On Batteries - "
        If (F And Task.TaskFlags.KillOnIdleEnd) <> 0 Then T = T & "Kill On Idle End - "
        If (F And Task.TaskFlags.StartOnlyIfIdle) <> 0 Then T = T & "Start Only If Idle - "

        Flags = T

    End Function

    Private Sub Tab_TaskScheduler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshList()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        btnAdd.PerformClick()
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropertiesToolStripMenuItem.Click
        btnProperties.PerformClick()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        btnDelete.PerformClick()
    End Sub

    Private Sub RunNowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunNowToolStripMenuItem.Click
        btnRunNow.PerformClick()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        btnRefresh.PerformClick()
    End Sub
End Class