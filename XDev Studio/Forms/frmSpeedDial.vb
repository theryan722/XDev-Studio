Imports WeifenLuo.WinFormsUI.Docking

Friend Class frmSpeedDial
    Dim sdlist As New List(Of SDObject)
    '----------------------Image Locations--------------------
    Dim loc_bookmark As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_bookmark.png"
    Dim loc_calendar As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_calendar.png"
    Dim loc_documentation As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_documentation.png"
    Dim loc_editor As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_editor.png"
    Dim loc_filedownloader As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_filedownloader.png"
    Dim loc_codemetrics As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_metrics.png"
    Dim loc_notepad As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_notepad.png"
    Dim loc_sitepreviewer As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_preview.png"
    Dim loc_processviewer As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_processviewer.png"
    Dim loc_rss As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_rss.png"
    Dim loc_tips As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_tips.png"
    Dim loc_universalsearch As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_universalsearch.png"
    Dim loc_webbrowser As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_webbrowser.png"
    Dim loc_options As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_options.png"
    Dim loc_presentationmode As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_presentationmode.png"
    Dim loc_exitstudio As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_exitstudio.png"
    Dim loc_newinstance As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_newinstance.png"
    Dim loc_tasks As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_tasks.png"
    Dim loc_log As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_log.png"
    Dim loc_colorpicker As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_colorpicker.png"
    Dim loc_imagemapper As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_imagemapper.png"
    Dim loc_serviceviewer As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_service.png"
    Dim loc_wysiwygeditor As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_wysiwygeditor.png"
    Dim loc_taskscheduler As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_taskscheduler.png"
    Dim loc_systemterminal As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_systemterminal.png"
    Dim loc_pictureviewer As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_pictureviewer.png"
    Dim loc_largefileeditor As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_largefileeditor.png"
    Dim loc_filerecovery As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_filerecovery.png"
    Dim loc_filehistory As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_filehistory.png"
    Dim loc_differenceviewer As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_differenceviewer.png"
    Dim loc_diagrammer As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_diagrammer.png"
    Dim loc_codebank As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_codebank.png"
    Dim loc_appmanager As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_appmanager.png"
    Dim loc_netconverter As String = XDev.Path.Locator.GetAppPath & "\Engine\SpeedDial\72_netconverter.png"

#Region "frmSpeedDial"

    Private Sub frmSpeedDial_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        sdlist.Clear()
    End Sub

    Private Sub frmSpeedDial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormPosition.CenterForm(Me, frmManager)
        Me.BackColor = My.Settings.set_speeddial_backcolor
        LoadSpeedDialButtons()
        LoadButtons()
    End Sub

    Private Sub frmSpeedDial_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub

#End Region

#Region "Methods"

    Private Sub LoadButtons()
        Try
            bn_sd_0.BackgroundImage = Image.FromFile(sdlist(0).GetImage)
            ToolTip1.SetToolTip(bn_sd_0, sdlist(0).GetAction)

            bn_sd_1.BackgroundImage = Image.FromFile(sdlist(1).GetImage)
            ToolTip1.SetToolTip(bn_sd_1, sdlist(1).GetAction)

            bn_sd_2.BackgroundImage = Image.FromFile(sdlist(2).GetImage)
            ToolTip1.SetToolTip(bn_sd_2, sdlist(2).GetAction)

            bn_sd_3.BackgroundImage = Image.FromFile(sdlist(3).GetImage)
            ToolTip1.SetToolTip(bn_sd_3, sdlist(3).GetAction)

            bn_sd_4.BackgroundImage = Image.FromFile(sdlist(4).GetImage)
            ToolTip1.SetToolTip(bn_sd_4, sdlist(4).GetAction)

            bn_sd_5.BackgroundImage = Image.FromFile(sdlist(5).GetImage)
            ToolTip1.SetToolTip(bn_sd_5, sdlist(5).GetAction)

            bn_sd_6.BackgroundImage = Image.FromFile(sdlist(6).GetImage)
            ToolTip1.SetToolTip(bn_sd_6, sdlist(6).GetAction)

            bn_sd_7.BackgroundImage = Image.FromFile(sdlist(7).GetImage)
            ToolTip1.SetToolTip(bn_sd_7, sdlist(7).GetAction)

            bn_sd_8.BackgroundImage = Image.FromFile(sdlist(8).GetImage)
            ToolTip1.SetToolTip(bn_sd_8, sdlist(8).GetAction)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub PerformAction(ByVal ind As Integer)
        Try
            Dim act As String = sdlist(ind).GetAction
            If act = "Bookmarks" Then
                Tabs.AddBookmarks()
            ElseIf act = "Calendar" Then
                Tabs.AddCalendar()
            ElseIf act = "Documentation" Then
                frmManager.LocalToolStripMenuItem.PerformClick()
            ElseIf act = "Code Editor" Then
                Tabs.AddCode()
            ElseIf act = "File Downloader" Then
                Tabs.AddFileDownloader()
            ElseIf act = "Code Metrics" Then
                Tabs.AddCodeMetrics()
            ElseIf act = "Notepad" Then
                Tabs.AddNotepad()
            ElseIf act = "Site Previewer" Then
                frmManager.SitePreviewerToolStripMenuItem.PerformClick()
            ElseIf act = "Process Viewer" Then
                Tabs.AddProcessViewer()
            ElseIf act = "RSS Reader" Then
                Tabs.AddRSSReader()
            ElseIf act = "Tips" Then
                frmManager.TipsToolStripMenuItem.PerformClick()
            ElseIf act = "Universal Search" Then
                Tabs.AddUniversalSearch()
            ElseIf act = "Web Browser" Then
                Tabs.AddWebBrowser()
            ElseIf act = "Options" Then
                Tabs.AddOptions()
            ElseIf act = "Presentation Mode" Then
                frmManager.PresentationModeToolStripMenuItem.PerformClick()
            ElseIf act = "Exit Studio" Then
                frmManager.ExitToolStripMenuItem.PerformClick()
            ElseIf act = "New Instance" Then
                frmManager.NewInstanceToolStripMenuItem.PerformClick()
            ElseIf act = "Tasks" Then
                Tabs.AddTasks()
            ElseIf act = "Color Picker" Then
                Dim newb As New frmColorPicker
                newb.Show()
            ElseIf act = "Image Mapper" Then
                Tabs.AddImageMapper()
            ElseIf act = "Log" Then
                Tabs.AddLogManager()
            ElseIf act = "Service Viewer" Then
                Tabs.AddServiceViewer()
            ElseIf act = "WYSIWYG Editor" Then
                Tabs.AddWYSIWYGEditor()
            ElseIf act = "Task Scheduler" Then
                Tabs.AddTaskScheduler()
            ElseIf act = "System Terminal" Then
                pnlSystemTerminal.ShowPanel(frmManager.DockPanel1, DockState.DockBottom)
            ElseIf act = "Picture Viewer" Then
                pnlImageViewer.ShowPanel(frmManager.DockPanel1, DockState.DockRight)
            ElseIf act = "Large File Editor" Then
                Tabs.AddLargeFileEditor()
            ElseIf act = "File Recovery" Then
                Tabs.AddCodeRecovery()
            ElseIf act = "File History" Then
                Tabs.AddFileHistory()
            ElseIf act = "Difference Viewer" Then
                Tabs.AddDifferenceViewer()
            ElseIf act = "Diagrammer" Then
                Tabs.AddDiagrammer()
            ElseIf act = "CodeBank" Then
                Tabs.AddCodeBank()
            ElseIf act = "App Manager" Then
                Tabs.AddAppManager()
            ElseIf act = ".Net Code Converter" Then
                Tabs.AddNetConverter()
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
        Me.Close()
    End Sub

    Private Sub LoadSpeedDialButtons()
        Try
            For Each item As String In My.Settings.set_speeddial
                Dim simg As String = ""
                Dim saction As String = ""
                If item = "Bookmarks" Then
                    simg = loc_bookmark
                    saction = item
                ElseIf item = "Calendar" Then
                    simg = loc_calendar
                    saction = item
                ElseIf item = "Documentation" Then
                    simg = loc_documentation
                    saction = item
                ElseIf item = "Code Editor" Then
                    simg = loc_editor
                    saction = item
                ElseIf item = "File Downloader" Then
                    simg = loc_filedownloader
                    saction = item
                ElseIf item = "Code Metrics" Then
                    simg = loc_codemetrics
                    saction = item
                ElseIf item = "Notepad" Then
                    simg = loc_notepad
                    saction = item
                ElseIf item = "Site Previewer" Then
                    simg = loc_sitepreviewer
                    saction = item
                ElseIf item = "Process Viewer" Then
                    simg = loc_processviewer
                    saction = item
                ElseIf item = "RSS Reader" Then
                    simg = loc_rss
                    saction = item
                ElseIf item = "Tips" Then
                    simg = loc_tips
                    saction = item
                ElseIf item = "Universal Search" Then
                    simg = loc_universalsearch
                    saction = item
                ElseIf item = "Web Browser" Then
                    simg = loc_webbrowser
                    saction = item
                ElseIf item = "Options" Then
                    simg = loc_options
                    saction = item
                ElseIf item = "Presentation Mode" Then
                    simg = loc_presentationmode
                    saction = item
                ElseIf item = "Exit Studio" Then
                    simg = loc_exitstudio
                    saction = item
                ElseIf item = "New Instance" Then
                    simg = loc_newinstance
                    saction = item
                ElseIf item = "Tasks" Then
                    simg = loc_tasks
                    saction = item
                ElseIf item = "Color Picker" Then
                    simg = loc_colorpicker
                    saction = item
                ElseIf item = "Image Mapper" Then
                    simg = loc_imagemapper
                    saction = item
                ElseIf item = "Log" Then
                    simg = loc_log
                    saction = item
                ElseIf item = "Service Viewer" Then
                    simg = loc_serviceviewer
                    saction = item
                ElseIf item = "WYSIWYG Editor" Then
                    simg = loc_wysiwygeditor
                    saction = item
                ElseIf item = "Task Scheduler" Then
                    simg = loc_taskscheduler
                    saction = item
                ElseIf item = "System Terminal" Then
                    simg = loc_systemterminal
                    saction = item
                ElseIf item = "Picture Viewer" Then
                    simg = loc_pictureviewer
                    saction = item
                ElseIf item = "Large File Editor" Then
                    simg = loc_largefileeditor
                    saction = item
                ElseIf item = "File Recovery" Then
                    simg = loc_filerecovery
                    saction = item
                ElseIf item = "File History" Then
                    simg = loc_filehistory
                    saction = item
                ElseIf item = "Difference Viewer" Then
                    simg = loc_differenceviewer
                    saction = item
                ElseIf item = "Diagrammer" Then
                    simg = loc_diagrammer
                    saction = item
                ElseIf item = "CodeBank" Then
                    simg = loc_codebank
                    saction = item
                ElseIf item = "App Manager" Then
                    simg = loc_appmanager
                    saction = item
                ElseIf item = ".Net Code Converter" Then
                    simg = loc_netconverter
                    saction = item
                End If
                sdlist.Add(New SDObject(simg, saction))
            Next
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

#End Region

#Region "SpeedDial Buttons"

#Region "0"

    Private Sub bn_sd_0_MouseClick() Handles bn_sd_0.MouseClick
        PerformAction(0)
    End Sub

    Private Sub bn_sd_0_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_0.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_0_MouseClick()
        End If
    End Sub

#End Region

#Region "1"

    Private Sub bn_sd_1_MouseClick() Handles bn_sd_1.MouseClick
        PerformAction(1)
    End Sub

    Private Sub bn_sd_1_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_1.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_1_MouseClick()
        End If
    End Sub

#End Region

#Region "2"

    Private Sub bn_sd_2_MouseClick() Handles bn_sd_2.MouseClick
        PerformAction(2)
    End Sub

    Private Sub bn_sd_2_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_2.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_2_MouseClick()
        End If
    End Sub

#End Region

#Region "3"

    Private Sub bn_sd_3_MouseClick() Handles bn_sd_3.MouseClick
        PerformAction(3)
    End Sub

    Private Sub bn_sd_3_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_3.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_3_MouseClick()
        End If
    End Sub

#End Region

#Region "4"

    Private Sub bn_sd_4_MouseClick() Handles bn_sd_4.MouseClick
        PerformAction(4)
    End Sub

    Private Sub bn_sd_4_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_4.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_4_MouseClick()
        End If
    End Sub

#End Region

#Region "5"

    Private Sub bn_sd_5_MouseClick() Handles bn_sd_5.MouseClick
        PerformAction(5)
    End Sub

    Private Sub bn_sd_5_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_5.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_5_MouseClick()
        End If
    End Sub

#End Region

#Region "6"

    Private Sub bn_sd_6_MouseClick() Handles bn_sd_6.MouseClick
        PerformAction(6)
    End Sub

    Private Sub bn_sd_6_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_6.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_6_MouseClick()
        End If
    End Sub

#End Region

#Region "7"

    Private Sub bn_sd_7_MouseClick() Handles bn_sd_7.MouseClick
        PerformAction(7)
    End Sub

    Private Sub bn_sd_7_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_7.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_7_MouseClick()
        End If
    End Sub

#End Region

#Region "8"

    Private Sub bn_sd_8_MouseClick() Handles bn_sd_8.MouseClick
        PerformAction(8)
    End Sub

    Private Sub bn_sd_8_MouseHover(sender As Object, e As EventArgs) Handles bn_sd_8.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            Call bn_sd_8_MouseClick()
        End If
    End Sub

#End Region

#Region "Cancel"

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

    Private Sub btn_cancel_MouseHover(sender As Object, e As EventArgs) Handles btn_cancel.MouseHover
        If My.Settings.set_speeddial_mousehover Then
            btn_cancel.PerformClick()
        End If
    End Sub

#End Region

#End Region

End Class