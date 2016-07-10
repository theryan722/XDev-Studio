Friend Class RecentFilesManager

    Public Shared Sub AddFile(ByVal loc As String)
        If My.Settings.set_recentfiles.Contains(loc) = False Then
            If My.Settings.set_recentfiles.Count = 10 Then
                My.Settings.set_recentfiles.RemoveAt(0)
                My.Settings.set_recentfiles.Add(loc)
            Else
                My.Settings.set_recentfiles.Add(loc)
            End If
        End If
        My.Settings.Save()
        UpdateRecentFilesMenu()
    End Sub

    Public Shared Sub RemoveFile(ByVal loc As String)
        My.Settings.set_recentfiles.Remove(loc)
        My.Settings.Save()
        UpdateRecentFilesMenu()
    End Sub

    Public Shared Sub ClearRecentFiles()
        My.Settings.set_recentfiles.Clear()
        My.Settings.Save()
        HideAllRecentFilesMenuItems()
        ResetNames()
    End Sub

    Private Shared Sub ResetNames()
        frmManager.rf0.Text = "RF0"
        frmManager.rf1.Text = "RF1"
        frmManager.rf2.Text = "RF2"
        frmManager.rf3.Text = "RF3"
        frmManager.rf4.Text = "RF4"
        frmManager.rf5.Text = "RF5"
        frmManager.rf6.Text = "RF6"
        frmManager.rf7.Text = "RF7"
        frmManager.rf8.Text = "RF8"
        frmManager.rf9.Text = "RF9"
    End Sub

    Public Shared Sub HideAllRecentFilesMenuItems()
        frmManager.rf0.Visible = False
        frmManager.rf1.Visible = False
        frmManager.rf2.Visible = False
        frmManager.rf3.Visible = False
        frmManager.rf4.Visible = False
        frmManager.rf5.Visible = False
        frmManager.rf6.Visible = False
        frmManager.rf7.Visible = False
        frmManager.rf8.Visible = False
        frmManager.rf9.Visible = False
        frmManager.ClearToolStripMenuItem.Visible = False
        frmManager.ToolStripSeparator56.Visible = False
    End Sub

    Public Shared Sub UpdateRecentFilesMenu()
        Try
            If My.Settings.set_recentfiles.Count = 0 Then
                HideAllRecentFilesMenuItems()
                ResetNames()
            Else
                Dim b As Integer = My.Settings.set_recentfiles.Count
                HideAllRecentFilesMenuItems()
                frmManager.ClearToolStripMenuItem.Visible = True
                frmManager.ToolStripSeparator56.Visible = True
                Select Case b
                    Case 1
                        frmManager.rf0.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                    Case 2
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                    Case 3
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        frmManager.rf2.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                        frmManager.rf2.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(2))
                        frmManager.rf2.ToolTipText = My.Settings.set_recentfiles(2)
                    Case 4
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        frmManager.rf2.Visible = True
                        frmManager.rf3.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                        frmManager.rf2.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(2))
                        frmManager.rf2.ToolTipText = My.Settings.set_recentfiles(2)
                        frmManager.rf3.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(3))
                        frmManager.rf3.ToolTipText = My.Settings.set_recentfiles(3)
                    Case 5
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        frmManager.rf2.Visible = True
                        frmManager.rf3.Visible = True
                        frmManager.rf4.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                        frmManager.rf2.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(2))
                        frmManager.rf2.ToolTipText = My.Settings.set_recentfiles(2)
                        frmManager.rf3.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(3))
                        frmManager.rf3.ToolTipText = My.Settings.set_recentfiles(3)
                        frmManager.rf4.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(4))
                        frmManager.rf4.ToolTipText = My.Settings.set_recentfiles(4)
                    Case 6
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        frmManager.rf2.Visible = True
                        frmManager.rf3.Visible = True
                        frmManager.rf4.Visible = True
                        frmManager.rf5.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                        frmManager.rf2.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(2))
                        frmManager.rf2.ToolTipText = My.Settings.set_recentfiles(2)
                        frmManager.rf3.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(3))
                        frmManager.rf3.ToolTipText = My.Settings.set_recentfiles(3)
                        frmManager.rf4.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(4))
                        frmManager.rf4.ToolTipText = My.Settings.set_recentfiles(4)
                        frmManager.rf5.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(5))
                        frmManager.rf5.ToolTipText = My.Settings.set_recentfiles(5)
                    Case 7
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        frmManager.rf2.Visible = True
                        frmManager.rf3.Visible = True
                        frmManager.rf4.Visible = True
                        frmManager.rf5.Visible = True
                        frmManager.rf6.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                        frmManager.rf2.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(2))
                        frmManager.rf2.ToolTipText = My.Settings.set_recentfiles(2)
                        frmManager.rf3.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(3))
                        frmManager.rf3.ToolTipText = My.Settings.set_recentfiles(3)
                        frmManager.rf4.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(4))
                        frmManager.rf4.ToolTipText = My.Settings.set_recentfiles(4)
                        frmManager.rf5.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(5))
                        frmManager.rf5.ToolTipText = My.Settings.set_recentfiles(5)
                        frmManager.rf6.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(6))
                        frmManager.rf6.ToolTipText = My.Settings.set_recentfiles(6)
                    Case 8
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        frmManager.rf2.Visible = True
                        frmManager.rf3.Visible = True
                        frmManager.rf4.Visible = True
                        frmManager.rf5.Visible = True
                        frmManager.rf6.Visible = True
                        frmManager.rf7.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                        frmManager.rf2.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(2))
                        frmManager.rf2.ToolTipText = My.Settings.set_recentfiles(2)
                        frmManager.rf3.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(3))
                        frmManager.rf3.ToolTipText = My.Settings.set_recentfiles(3)
                        frmManager.rf4.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(4))
                        frmManager.rf4.ToolTipText = My.Settings.set_recentfiles(4)
                        frmManager.rf5.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(5))
                        frmManager.rf5.ToolTipText = My.Settings.set_recentfiles(5)
                        frmManager.rf6.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(6))
                        frmManager.rf6.ToolTipText = My.Settings.set_recentfiles(6)
                        frmManager.rf7.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(7))
                        frmManager.rf7.ToolTipText = My.Settings.set_recentfiles(7)
                    Case 9
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        frmManager.rf2.Visible = True
                        frmManager.rf3.Visible = True
                        frmManager.rf4.Visible = True
                        frmManager.rf5.Visible = True
                        frmManager.rf6.Visible = True
                        frmManager.rf7.Visible = True
                        frmManager.rf8.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                        frmManager.rf2.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(2))
                        frmManager.rf2.ToolTipText = My.Settings.set_recentfiles(2)
                        frmManager.rf3.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(3))
                        frmManager.rf3.ToolTipText = My.Settings.set_recentfiles(3)
                        frmManager.rf4.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(4))
                        frmManager.rf4.ToolTipText = My.Settings.set_recentfiles(4)
                        frmManager.rf5.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(5))
                        frmManager.rf5.ToolTipText = My.Settings.set_recentfiles(5)
                        frmManager.rf6.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(6))
                        frmManager.rf6.ToolTipText = My.Settings.set_recentfiles(6)
                        frmManager.rf7.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(7))
                        frmManager.rf7.ToolTipText = My.Settings.set_recentfiles(7)
                        frmManager.rf8.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(8))
                        frmManager.rf8.ToolTipText = My.Settings.set_recentfiles(8)
                    Case 10
                        frmManager.rf0.Visible = True
                        frmManager.rf1.Visible = True
                        frmManager.rf2.Visible = True
                        frmManager.rf3.Visible = True
                        frmManager.rf4.Visible = True
                        frmManager.rf5.Visible = True
                        frmManager.rf6.Visible = True
                        frmManager.rf7.Visible = True
                        frmManager.rf8.Visible = True
                        frmManager.rf9.Visible = True
                        '-------Text----
                        frmManager.rf0.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(0))
                        frmManager.rf0.ToolTipText = My.Settings.set_recentfiles(0)
                        frmManager.rf1.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(1))
                        frmManager.rf1.ToolTipText = My.Settings.set_recentfiles(1)
                        frmManager.rf2.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(2))
                        frmManager.rf2.ToolTipText = My.Settings.set_recentfiles(2)
                        frmManager.rf3.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(3))
                        frmManager.rf3.ToolTipText = My.Settings.set_recentfiles(3)
                        frmManager.rf4.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(4))
                        frmManager.rf4.ToolTipText = My.Settings.set_recentfiles(4)
                        frmManager.rf5.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(5))
                        frmManager.rf5.ToolTipText = My.Settings.set_recentfiles(5)
                        frmManager.rf6.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(6))
                        frmManager.rf6.ToolTipText = My.Settings.set_recentfiles(6)
                        frmManager.rf7.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(7))
                        frmManager.rf7.ToolTipText = My.Settings.set_recentfiles(7)
                        frmManager.rf8.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(8))
                        frmManager.rf8.ToolTipText = My.Settings.set_recentfiles(8)
                        frmManager.rf9.Text = System.IO.Path.GetFileName(My.Settings.set_recentfiles(9))
                        frmManager.rf9.ToolTipText = My.Settings.set_recentfiles(9)
                End Select
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub
End Class
