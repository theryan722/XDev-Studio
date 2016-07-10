Friend Class pnlToolbars

#Region "Context Menu Strip"

#Region "Toolbars"

    Private Sub ShowAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAllToolStripMenuItem.Click
        ShowAllToolbars()
    End Sub

    Private Sub HideAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideAllToolStripMenuItem.Click
        HideAllToolbars()
    End Sub

    Private Sub StudioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudioToolStripMenuItem.Click
        If tbStudio.Visible Then
            tbStudio.Visible = False
            If My.Settings.set_displayedtoolbars.Contains("Studio") Then
                My.Settings.set_displayedtoolbars.Remove("Studio")
            End If
        Else
            tbStudio.Visible = True
            If My.Settings.set_displayedtoolbars.Contains("Studio") = False Then
                My.Settings.set_displayedtoolbars.Add("Studio")
            End If
        End If
        CheckAppropriateToolbars()
    End Sub

    Private Sub EditingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditingToolStripMenuItem.Click
        If tbEditing.Visible Then
            tbEditing.Visible = False
            If My.Settings.set_displayedtoolbars.Contains("Editing") Then
                My.Settings.set_displayedtoolbars.Remove("Editing")
            End If
        Else
            tbEditing.Visible = True
            If My.Settings.set_displayedtoolbars.Contains("Editing") = False Then
                My.Settings.set_displayedtoolbars.Add("Editing")
            End If
        End If
        CheckAppropriateToolbars()
    End Sub

    Private Sub ZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem.Click
        If tbZoom.Visible Then
            tbZoom.Visible = False
            If My.Settings.set_displayedtoolbars.Contains("Zoom") Then
                My.Settings.set_displayedtoolbars.Remove("Zoom")
            End If
        Else
            tbZoom.Visible = True
            If My.Settings.set_displayedtoolbars.Contains("Zoom") = False Then
                My.Settings.set_displayedtoolbars.Add("Zoom")
            End If
        End If
        CheckAppropriateToolbars()
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click
        If tbFind.Visible Then
            tbFind.Visible = False
            If My.Settings.set_displayedtoolbars.Contains("Find") Then
                My.Settings.set_displayedtoolbars.Remove("Find")
            End If
        Else
            tbFind.Visible = True
            If My.Settings.set_displayedtoolbars.Contains("Find") = False Then
                My.Settings.set_displayedtoolbars.Add("Find")
            End If
        End If
        CheckAppropriateToolbars()
    End Sub

    Private Sub ToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem.Click
        If tbTools.Visible Then
            tbTools.Visible = False
            If My.Settings.set_displayedtoolbars.Contains("Tools") Then
                My.Settings.set_displayedtoolbars.Remove("Tools")
            End If
        Else
            tbTools.Visible = True
            If My.Settings.set_displayedtoolbars.Contains("Tools") = False Then
                My.Settings.set_displayedtoolbars.Add("Tools")
            End If
        End If
        CheckAppropriateToolbars()
    End Sub

    Private Sub ProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectToolStripMenuItem.Click
        If tbProject.Visible Then
            tbProject.Visible = False
            If My.Settings.set_displayedtoolbars.Contains("Project") Then
                My.Settings.set_displayedtoolbars.Remove("Project")
            End If
        Else
            tbProject.Visible = True
            If My.Settings.set_displayedtoolbars.Contains("Project") = False Then
                My.Settings.set_displayedtoolbars.Add("Project")
            End If
        End If
        CheckAppropriateToolbars()
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        If tbView.Visible Then
            tbView.Visible = False
            If My.Settings.set_displayedtoolbars.Contains("View") Then
                My.Settings.set_displayedtoolbars.Remove("View")
            End If
        Else
            tbView.Visible = True
            If My.Settings.set_displayedtoolbars.Contains("View") = False Then
                My.Settings.set_displayedtoolbars.Add("View")
            End If
        End If
        CheckAppropriateToolbars()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        If tbPrint.Visible Then
            tbPrint.Visible = False
            If My.Settings.set_displayedtoolbars.Contains("Print") Then
                My.Settings.set_displayedtoolbars.Remove("Print")
            End If
        Else
            tbPrint.Visible = True
            If My.Settings.set_displayedtoolbars.Contains("Print") = False Then
                My.Settings.set_displayedtoolbars.Add("Print")
            End If
        End If
        CheckAppropriateToolbars()
    End Sub

#End Region

#End Region

#Region "Methods"

    Private Sub RefreshToolbars()
        HideAllToolbars()
        For Each item As String In My.Settings.set_displayedtoolbars
            If item = "Studio" Then
                tbStudio.Visible = True
            ElseIf item = "Editing" Then
                tbEditing.Visible = True
            ElseIf item = "Zoom" Then
                tbZoom.Visible = True
            ElseIf item = "Find" Then
                tbFind.Visible = True
            ElseIf item = "Tools" Then
                tbTools.Visible = True
            ElseIf item = "Project" Then
                tbProject.Visible = True
            ElseIf item = "View" Then
                tbView.Visible = True
            ElseIf item = "Print" Then
                tbPrint.Visible = True
            End If
        Next
        CheckAppropriateToolbars()
    End Sub

    Private Sub HideAllToolbars()
        UncheckAllToolbars()
        tbStudio.Visible = False
        tbEditing.Visible = False
        tbZoom.Visible = False
        tbFind.Visible = False
        tbTools.Visible = False
        tbProject.Visible = False
        tbView.Visible = False
        tbPrint.Visible = False
    End Sub

    Private Sub ShowAllToolbars()
        CheckAllToolbars()
        tbStudio.Visible = True
        tbEditing.Visible = True
        tbZoom.Visible = True
        tbFind.Visible = True
        tbTools.Visible = True
        tbProject.Visible = True
        tbView.Visible = True
        tbPrint.Visible = True
    End Sub

    Private Sub CheckAppropriateToolbars()
        StudioToolStripMenuItem.Checked = tbStudio.Visible
        EditingToolStripMenuItem.Checked = tbEditing.Visible
        ZoomToolStripMenuItem.Checked = tbZoom.Visible
        FindToolStripMenuItem.Checked = tbFind.Visible
        ToolsToolStripMenuItem.Checked = tbTools.Visible
        ProjectToolStripMenuItem.Checked = tbProject.Visible
        ViewToolStripMenuItem.Checked = tbView.Visible
        PrintToolStripMenuItem.Checked = tbPrint.Visible
    End Sub

    Private Sub UncheckAllToolbars()
        StudioToolStripMenuItem.Checked = False
        EditingToolStripMenuItem.Checked = False
        ZoomToolStripMenuItem.Checked = False
        FindToolStripMenuItem.Checked = False
        ToolsToolStripMenuItem.Checked = False
        ProjectToolStripMenuItem.Checked = False
        ViewToolStripMenuItem.Checked = False
        PrintToolStripMenuItem.Checked = False
    End Sub

    Private Sub CheckAllToolbars()
        StudioToolStripMenuItem.Checked = True
        EditingToolStripMenuItem.Checked = True
        ZoomToolStripMenuItem.Checked = True
        FindToolStripMenuItem.Checked = True
        ToolsToolStripMenuItem.Checked = True
        ProjectToolStripMenuItem.Checked = True
        ViewToolStripMenuItem.Checked = True
        PrintToolStripMenuItem.Checked = True
    End Sub

#End Region

#Region "Toolbars"

#Region "Studio"

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        frmManager.OpenFileToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        frmManager.OpenProjectToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        frmManager.SaveToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        frmManager.SaveAsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Tabs.AddCode()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        frmManager.NewProjectToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        frmManager.OptionsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        frmManager.LocalToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Editing"

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        frmManager.UndoToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        frmManager.RedoToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        frmManager.CutToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        frmManager.CopyToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        frmManager.PasteToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        frmManager.SelectAllToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        frmManager.ClearAllToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        frmManager.CommentToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        frmManager.UncommentToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton24_Click(sender As Object, e As EventArgs) Handles ToolStripButton24.Click
        frmManager.DecreaseToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton25_Click(sender As Object, e As EventArgs) Handles ToolStripButton25.Click
        frmManager.IncreaseToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Zoom"

    Private Sub ToolStripButton18_Click(sender As Object, e As EventArgs) Handles ToolStripButton18.Click
        frmManager.DefaultToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        frmManager.InToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        frmManager.OutToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Find"

    Private Sub ToolStripButton21_Click(sender As Object, e As EventArgs) Handles ToolStripButton21.Click
        frmManager.FindReplaceToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        frmManager.GotoToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub ToolStripButton23_Click(sender As Object, e As EventArgs) Handles ToolStripButton23.Click
        frmManager.SearchToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Tools"

    Private Sub ToolStripButton26_Click(sender As Object, e As EventArgs) Handles ToolStripButton26.Click
        frmManager.NotepadToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton27_Click(sender As Object, e As EventArgs) Handles ToolStripButton27.Click
        frmManager.LargeFileEditorToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton28_Click(sender As Object, e As EventArgs) Handles ToolStripButton28.Click
        frmManager.CalendarToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton29_Click(sender As Object, e As EventArgs) Handles ToolStripButton29.Click
        frmManager.WebBrowserToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton30_Click(sender As Object, e As EventArgs) Handles ToolStripButton30.Click
        frmManager.ProcessViewerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton31_Click(sender As Object, e As EventArgs) Handles ToolStripButton31.Click
        frmManager.ServiceViewerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton32_Click(sender As Object, e As EventArgs) Handles ToolStripButton32.Click
        frmManager.DifferenceViewerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton33_Click(sender As Object, e As EventArgs) Handles ToolStripButton33.Click
        frmManager.SitePreviewerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton34_Click(sender As Object, e As EventArgs) Handles ToolStripButton34.Click
        frmManager.CodeMetricsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton35_Click(sender As Object, e As EventArgs) Handles ToolStripButton35.Click
        frmManager.ColorPickerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton36_Click(sender As Object, e As EventArgs) Handles ToolStripButton36.Click
        frmManager.RSSReaderToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton37_Click(sender As Object, e As EventArgs) Handles ToolStripButton37.Click
        frmManager.FileDownloaderToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton38_Click(sender As Object, e As EventArgs) Handles ToolStripButton38.Click
        frmManager.MapperToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton39_Click(sender As Object, e As EventArgs) Handles ToolStripButton39.Click
        frmManager.ImageViewerToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Project"

    Private Sub ToolStripButton40_Click(sender As Object, e As EventArgs) Handles ToolStripButton40.Click
        frmManager.OpenProjectFolderToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton41_Click(sender As Object, e As EventArgs) Handles ToolStripButton41.Click
        frmManager.ProjectInformationToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton42_Click(sender As Object, e As EventArgs) Handles ToolStripButton42.Click
        frmManager.ImportFileToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton43_Click(sender As Object, e As EventArgs) Handles ToolStripButton43.Click
        frmManager.CloseProjectToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "View"

    Private Sub ToolStripButton44_Click(sender As Object, e As EventArgs) Handles ToolStripButton44.Click
        frmManager.SnippetListToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton45_Click(sender As Object, e As EventArgs) Handles ToolStripButton45.Click
        frmManager.SpeedDialToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton46_Click(sender As Object, e As EventArgs) Handles ToolStripButton46.Click
        frmManager.QuickCommandToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton47_Click(sender As Object, e As EventArgs) Handles ToolStripButton47.Click
        frmManager.WindowsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton48_Click(sender As Object, e As EventArgs) Handles ToolStripButton48.Click
        frmManager.PresentationModeToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton49_Click(sender As Object, e As EventArgs) Handles ToolStripButton49.Click
        frmManager.CalculateCodeMetricsForCurrentDocumentToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton50_Click(sender As Object, e As EventArgs) Handles ToolStripButton50.Click
        frmManager.TasksToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton51_Click(sender As Object, e As EventArgs) Handles ToolStripButton51.Click
        frmManager.FoldAllToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton52_Click(sender As Object, e As EventArgs) Handles ToolStripButton52.Click
        frmManager.UnfoldAllToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Print"

    Private Sub ToolStripButton53_Click(sender As Object, e As EventArgs) Handles ToolStripButton53.Click
        frmManager.PrintToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton54_Click(sender As Object, e As EventArgs) Handles ToolStripButton54.Click
        frmManager.PrintPreviewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton55_Click(sender As Object, e As EventArgs) Handles ToolStripButton55.Click
        frmManager.PageSetupToolStripMenuItem.PerformClick()
    End Sub

#End Region

#End Region

#Region "pnlToolbars"

    Private Sub pnlToolbars_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.set_toolbarsvisible = False
    End Sub

    Private Sub pnlToolbars_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshToolbars()
        ToolStripPanel1.BackColor = My.Settings.set_toolbars_backcolor
    End Sub

#End Region

End Class