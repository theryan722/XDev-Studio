Imports System.Diagnostics

Friend Class Tab_ProcessViewer
    Private Sub Tab_ProcessViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()
        Timer1.Start()
    End Sub

    Private Sub RefreshList()
        Dim MachineName As String = System.Environment.MachineName.ToString
        Dim Prc() As Process
        Dim i As Integer
        Dim lvwP As ListViewItem
        Try
            lvwProcesses.Items.Clear()

            Prc = Process.GetProcesses(MachineName)

            For i = 0 To UBound(Prc)
                lvwP = lvwProcesses.Items.Add(Prc(i).ProcessName)

                If MachineName <> System.Environment.MachineName Then
                    lvwP.SubItems.Add("Unavailable...")
                    lvwP.SubItems.Add("Unavailable...")
                    lvwP.SubItems.Add(Prc(i).Id)
                Else
                    lvwP.SubItems.Add(Prc(i).MainWindowTitle)
                    lvwP.SubItems.Add(Prc(i).Responding)
                    lvwP.SubItems.Add(Prc(i).Id)
                    lvwP.SubItems.Add(Prc(i).PrivateMemorySize64)
                End If

            Next
        Catch
            MetroFramework.MetroMessageBox.Show(frmManager, "Error gathering process information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        RefreshList()
    End Sub

    Private Sub btn_resume_Click(sender As Object, e As EventArgs) Handles btn_resume.Click
        Timer1.Enabled = True
    End Sub

    Private Sub btn_pause_Click(sender As Object, e As EventArgs) Handles btn_pause.Click
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RefreshList()
    End Sub
End Class