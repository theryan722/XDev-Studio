Public Class pnlNotificationCenter
    Dim total As Integer = 0
    Public Enum IconType
        [Error]
        Warning
        Info
    End Enum

#Region "Methods"

    Private Sub LoadFromSettings()
        ListView1.Items.Clear()
        For Each item As String In My.Settings.set_notifications
            Dim bb() As String = item.Split("|")
            If bb(0) = "Info" Then
                ListView1.Items.Add(bb(1), 0)
            ElseIf bb(0) = "Error" Then
                ListView1.Items.Add(bb(1), 1)
            ElseIf bb(0) = "Warning" Then
                ListView1.Items.Add(bb(1), 2)
            Else
                ListView1.Items.Add(bb(1), 0)
            End If
            total += 1
            UpdateTitle()
        Next
    End Sub

    Private Sub RemoveFromSettings(ByVal notification As ListViewItem)
        If notification.ImageIndex = 0 Then
            If My.Settings.set_notifications.Contains("Info|" & notification.Text) Then
                My.Settings.set_notifications.Remove("Info|" & notification.Text)
            End If
        ElseIf notification.ImageIndex = 1 Then
            If My.Settings.set_notifications.Contains("Error|" & notification.Text) Then
                My.Settings.set_notifications.Remove("Error|" & notification.Text)
            End If
        ElseIf notification.ImageIndex = 2 Then
            If My.Settings.set_notifications.Contains("Warning|" & notification.Text) Then
                My.Settings.set_notifications.Remove("Warning|" & notification.Text)
            End If
        End If
    End Sub

    Private Sub UpdateTitle()
        Me.Text = "Notifications [" & total & "]"
    End Sub

    Public Sub AddNotification(ByVal txt As String, Optional notificationicon As IconType = IconType.Info)
        If My.Settings.set_storenotifications Then
            Dim bb As String = ""
            If notificationicon = IconType.Info Then
                bb = "Info|"
            ElseIf notificationicon = IconType.[Error] Then
                bb = "Error|"
            Else
                bb = "Warning|"
            End If
            bb &= "txt"
            My.Settings.set_notifications.Add(bb)
        End If
        If notificationicon = IconType.Info Then
            ListView1.Items.Add(txt, 0)
        ElseIf notificationicon = IconType.[Error] Then
            ListView1.Items.Add(txt, 1)
        ElseIf notificationicon = IconType.Warning Then
            ListView1.Items.Add(txt, 2)
        End If
        total += 1
        UpdateTitle()
    End Sub

#End Region

#Region "pnlNotificationCenter"

    Private Sub pnlNotificationCenter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.set_storenotifications Then
            LoadFromSettings()
        End If
        UpdateTitle()
    End Sub

#End Region

#Region "Context Menu Strip"

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If ListView1.SelectedItems.Count > 0 Then
            My.Computer.Clipboard.SetText(ListView1.SelectedItems(0).Text)
        End If
    End Sub

    Private Sub RemoveNotificationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveNotificationToolStripMenuItem.Click
        If ListView1.SelectedItems.Count > 0 Then
            RemoveFromSettings(ListView1.SelectedItems(0))
            ListView1.Items.RemoveAt(ListView1.SelectedIndices(0))
            total -= 1
            UpdateTitle()
        End If
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        My.Settings.set_notifications.Clear()
        ListView1.Clear()
        total = 0
        UpdateTitle()
    End Sub

#End Region

End Class