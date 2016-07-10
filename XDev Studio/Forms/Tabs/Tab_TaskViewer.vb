Friend Class Tab_TaskViewer
    Dim todotasks As Integer = 0
    Dim completetasks As Integer = 0

#Region "Refresh"

    Private Sub RefreshTasks()
        todotasks = 0
        completetasks = 0
        listbox_taskscomplete.Items.Clear()
        listbox_taskstodo.Items.Clear()

        For Each item As String In My.Settings.set_tasklistcomplete
            listbox_taskscomplete.Items.Add(item)
            completetasks += 1
        Next
        For Each item As String In My.Settings.set_tasklisttodo
            listbox_taskstodo.Items.Add(item)
            todotasks += 1
        Next
        Tab_Tasks.Text = "Tasks (" & todotasks & ")"
        Tab_CompleteTasks.Text = "Complete Tasks (" & completetasks & ")"
    End Sub

    Private Sub RefreshComplete()
        completetasks = 0
        listbox_taskscomplete.Items.Clear()
        For Each item As String In My.Settings.set_tasklistcomplete
            listbox_taskscomplete.Items.Add(item)
            completetasks += 1
        Next
        Tab_CompleteTasks.Text = "Complete Tasks (" & completetasks & ")"
    End Sub

    Private Sub RefreshToDo()
        todotasks = 0
        listbox_taskstodo.Items.Clear()
        For Each item As String In My.Settings.set_tasklisttodo
            listbox_taskstodo.Items.Add(item)
            todotasks += 1
        Next
        Tab_Tasks.Text = "Tasks (" & todotasks & ")"
    End Sub

#End Region

    Private Sub frmTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshTasks()
    End Sub

#Region "Tabs"

#Region "Tasks"

    Private Sub btn_addtodo_Click(sender As Object, e As EventArgs) Handles btn_addtodo.Click
        Dim toadd As String = InputBox("Please enter a new task.", "New Task", "")
        If toadd = "" Then
            'do nothing
        Else
            My.Settings.set_tasklisttodo.Add(toadd)
            RefreshToDo()
        End If
    End Sub

    Private Sub RemoveSelectedTodo()
        If listbox_taskstodo.Items.Count > 0 And listbox_taskstodo.SelectedIndex >= 0 Then
            My.Settings.set_tasklisttodo.Remove(listbox_taskstodo.SelectedItem)
            RefreshTasks()
        End If
    End Sub

    Private Sub btn_removetodo_Click(sender As Object, e As EventArgs) Handles btn_removetodo.Click
        RemoveSelectedTodo()
    End Sub

    Private Sub btn_copytodo_Click(sender As Object, e As EventArgs) Handles btn_copytodo.Click
        If listbox_taskstodo.Items.Count > 0 And listbox_taskstodo.SelectedIndex >= 0 Then
            My.Computer.Clipboard.SetText(listbox_taskstodo.SelectedItem)
            MetroFramework.MetroMessageBox.Show(frmManager, "Task Copied to Clipboard!", "Copy Task", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_refreshtodo_Click(sender As Object, e As EventArgs) Handles btn_refreshtodo.Click
        RefreshToDo()
    End Sub

    Private Sub btn_marktodo_Click(sender As Object, e As EventArgs) Handles btn_marktodo.Click
        If listbox_taskstodo.Items.Count > 0 And listbox_taskstodo.SelectedIndex >= 0 Then
            My.Settings.set_tasklisttodo.Remove(listbox_taskstodo.SelectedItem)
            My.Settings.set_tasklistcomplete.Add(listbox_taskstodo.SelectedItem)
            RefreshTasks()
        End If
    End Sub

    Private Sub listbox_taskstodo_KeyDown(sender As Object, e As KeyEventArgs) Handles listbox_taskstodo.KeyDown
        If listbox_taskstodo.Items.Count > 0 And listbox_taskstodo.SelectedIndex >= 0 Then
            If e.KeyCode = Keys.Delete Then
                RemoveSelectedTodo()
            End If
        End If
    End Sub

#End Region

#Region "Completed Tasks"

    Private Sub listbox_taskscomplete_KeyDown(sender As Object, e As KeyEventArgs) Handles listbox_taskscomplete.KeyDown
        If listbox_taskscomplete.Items.Count > 0 And listbox_taskscomplete.SelectedIndex >= 0 Then
            If e.KeyCode = Keys.Delete Then
                RemoveSelectedComplete()
            End If
        End If
    End Sub

    Private Sub RemoveSelectedComplete()
        If listbox_taskscomplete.Items.Count > 0 And listbox_taskscomplete.SelectedIndex >= 0 Then
            My.Settings.set_tasklistcomplete.Remove(listbox_taskscomplete.SelectedItem)
            RefreshTasks()
        End If
    End Sub

    Private Sub btn_removecomplete_Click(sender As Object, e As EventArgs) Handles btn_removecomplete.Click
        RemoveSelectedComplete()
    End Sub

    Private Sub btn_copycomplete_Click(sender As Object, e As EventArgs) Handles btn_copycomplete.Click
        If listbox_taskscomplete.Items.Count > 0 And listbox_taskscomplete.SelectedIndex >= 0 Then
            My.Computer.Clipboard.SetText(listbox_taskscomplete.SelectedItem)
            MetroFramework.MetroMessageBox.Show(frmManager, "Task Copied to Clipboard!", "Copy Task", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btn_refreshcomplete_Click(sender As Object, e As EventArgs) Handles btn_refreshcomplete.Click
        RefreshComplete()
    End Sub

    Private Sub btn_markcomplete_Click(sender As Object, e As EventArgs) Handles btn_markcomplete.Click
        If listbox_taskscomplete.Items.Count > 0 And listbox_taskscomplete.SelectedIndex >= 0 Then
            My.Settings.set_tasklistcomplete.Remove(listbox_taskscomplete.SelectedItem)
            My.Settings.set_tasklisttodo.Add(listbox_taskscomplete.SelectedItem)
            RefreshTasks()
        End If
    End Sub

#End Region

#End Region

#Region "Contextmenu"

#Region "Tasks"

    Private Sub RemoveTaskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveTaskToolStripMenuItem.Click
        btn_removetodo.PerformClick()
    End Sub

    Private Sub CopyTaskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyTaskToolStripMenuItem.Click
        btn_copytodo.PerformClick()
    End Sub

    Private Sub MarkTaskAsCompleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkTaskAsCompleteToolStripMenuItem.Click
        btn_marktodo.PerformClick()
    End Sub

#End Region

#Region "Complete"

    Private Sub RemoveTaskToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveTaskToolStripMenuItem1.Click
        btn_removecomplete.PerformClick()
    End Sub

    Private Sub CopyTaskToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyTaskToolStripMenuItem1.Click
        btn_copycomplete.PerformClick()
    End Sub

    Private Sub MarkTaskAsIncompleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkTaskAsIncompleteToolStripMenuItem.Click
        btn_markcomplete.PerformClick()
    End Sub

#End Region

#End Region

End Class