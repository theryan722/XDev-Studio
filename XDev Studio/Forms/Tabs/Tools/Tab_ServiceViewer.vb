Friend Class Tab_ServiceViewer


#Region "Methods"

    Private Sub StopService(ByVal ServiceName As String)
        Dim ListSvcs() As ServiceProcess.ServiceController
        Dim SingleSvc As ServiceProcess.ServiceController

        ListSvcs = SingleSvc.GetServices

        Try
            For Each SingleSvc In ListSvcs
                If UCase(SingleSvc.ServiceName) = UCase(ServiceName) Then
                    SingleSvc.Stop()
                    ReadSvcs()
                    Exit For
                End If
            Next
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub StartService(ByVal ServiceName As String)
        Dim ListSvcs() As ServiceProcess.ServiceController
        Dim SingleSvc As ServiceProcess.ServiceController

        ListSvcs = SingleSvc.GetServices

        Try
            For Each SingleSvc In ListSvcs
                If UCase(SingleSvc.ServiceName) = UCase(ServiceName) Then
                    SingleSvc.Start()
                    ReadSvcs()
                    Exit For
                End If
            Next
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Public Sub ReadSvcs()
        Dim ListSvcs() As ServiceProcess.ServiceController
        Dim SingleSvc As ServiceProcess.ServiceController
        Dim LVW As ListViewItem

        ListSvcs = SingleSvc.GetServices

        lvwServices.Items.Clear()
        Try
            For Each SingleSvc In ListSvcs
                LVW = lvwServices.Items.Add(SingleSvc.DisplayName)
                LVW.SubItems.Add(SingleSvc.ServiceName)
                LVW.SubItems.Add(SingleSvc.Status.ToString)
                LVW.SubItems.Add(SingleSvc.ServiceType.ToString)
            Next
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

#End Region

#Region "Context Menu Strip"

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        cmdStop.PerformClick()
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        cmdStart.PerformClick()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        cmdRefresh.PerformClick()
    End Sub

#End Region

#Region "Bottom Panel"

    Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
        If lvwServices.SelectedItems(0).Text <> "" Then
            StopService(lvwServices.SelectedItems(0).SubItems(1).Text)
        End If
    End Sub

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        If lvwServices.SelectedItems(0).Text <> "" Then
            StartService(lvwServices.SelectedItems(0).SubItems(1).Text)
        End If
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        ReadSvcs()
    End Sub

#End Region

#Region "Listview"

    Private Sub lvwServices_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwServices.Click
        If lvwServices.SelectedItems(0).Text <> "" Then
            Select Case lvwServices.SelectedItems(0).SubItems(2).Text
                Case "Stopped"
                    cmdStop.Enabled = False
                    cmdStart.Enabled = True
                    StopToolStripMenuItem.Enabled = False
                    StartToolStripMenuItem.Enabled = True
                Case "Running"
                    cmdStop.Enabled = True
                    cmdStart.Enabled = False
                    StopToolStripMenuItem.Enabled = True
                    StartToolStripMenuItem.Enabled = False

                Case Else
                    cmdStop.Enabled = False
                    cmdStart.Enabled = False
                    StopToolStripMenuItem.Enabled = False
                    StartToolStripMenuItem.Enabled = False
            End Select
        End If
    End Sub

#End Region

    Private Sub Tab_ServiceViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadSvcs()
    End Sub

End Class