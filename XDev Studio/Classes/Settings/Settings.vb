Friend Class Settings
    
    Public Shared Sub LoadSettings(Optional ByVal recentlyreset As Boolean = False)
        frmManager.StyleManager1.Theme = My.Settings.set_theme
        frmManager.NotifyIcon1.Visible = My.Settings.set_displaytrayicon

        frmManager.BackupTimer.Enabled = My.Settings.set_autobackup
        frmManager.BackupTimer.Interval = My.Settings.set_autobackupinterval * 1000
        frmManager.EncryptTimer.Enabled = My.Settings.set_autoencrypt
        frmManager.EncryptTimer.Interval = My.Settings.set_autoencryptinterval * 1000
        frmManager.CodeRecoveryTimer.Enabled = My.Settings.set_coderecovery_enabled
        frmManager.CodeRecoveryTimer.Interval = My.Settings.set_coderecovery_interval * 1000
        frmManager.AutoSaveTimer.Enabled = My.Settings.set_autosave
        frmManager.AutoSaveTimer.Interval = My.Settings.set_autosave_interval * 1000
        frmManager.AutomaticBackupToolStripMenuItem.Checked = My.Settings.set_autobackup
        frmManager.MenuStrip1.BackColor = My.Settings.set_menustripcolor
        pnlToolPanel.BackColor = My.Settings.set_toolpanelcolor
        pnlToolPanel.BackColor = My.Settings.set_projectexplorercolor
        pnlToolPanel.Width = My.Settings.set_toolpanelwidth
        pnlToolPanel.Width = My.Settings.set_projectexplorerwidth
        pnlToolPanel.Visible = My.Settings.set_toolpanelvisibleatstartup
        If My.Settings.set_voicepp_commandrecatstartup = True Then
            SpeechEngine.StartDetectingCommands()
        End If
        If My.Settings.set_menustriptextcolorwhite Then
            SetMenuStripTextColorWhite()
        End If
        frmManager.ToolStripMenuItem2.Checked = True
        frmManager.Opacity = 1
        If My.Settings.set_toolbarsvisible Then
            frmManager.ToolbarsToolStripMenuItem.PerformClick()
        End If
        My.Settings.temp_performancemode = My.Settings.set_enableperformancemodeatstartup
        SyntaxHighlighting.GenerateArray()
        frmManager.DockPanel1.DocumentTabStripLocation = My.Settings.set_tabstriplocation
        frmManager.DockPanel1.Refresh()
        If My.Settings.set_displaystudiobgimage Then
            If My.Settings.set_dockpanelbg = "DEFAULT" Then
                frmManager.DockPanel1.BackgroundImage = My.Resources.dockpanel_background
            Else
                Try
                    frmManager.DockPanel1.BackgroundImage = Image.FromFile(My.Settings.set_dockpanelbg)
                Catch ex As Exception
                    Logger.WriteError(ex)
                End Try
            End If
        Else
            frmManager.DockPanel1.BackgroundImage = Nothing
        End If

        If frmManager.AtLeastOneCodeEditor() Then
            For Each item As XDockContent In frmManager.DockPanel1.Documents
                If frmManager.IsCodeEditor(item) Then
                    CType(item, Tab_CodeEditor).LoadSettings()
                End If
            Next
        End If

        'If not recently reset don't re-display welcome tab, tips, etc.
        If recentlyreset = False Then
            frmManager.WindowState = My.Settings.set_defaultwindowstate
            If My.Settings.set_showtipsatstartup Then
                frmManager.TipsToolStripMenuItem.PerformClick()
            End If

            If My.Settings.set_startuptab = "Welcome" Then
                Tabs.AddWelcome()
            ElseIf My.Settings.set_startuptab = "Editor" Then
                Tabs.AddCode()
            ElseIf My.Settings.set_startuptab = "Notepad" Then
                Tabs.AddNotepad()
            ElseIf My.Settings.set_startuptab = "Tasks" Then
                Tabs.AddTasks()
            ElseIf My.Settings.set_startuptab = "Calendar" Then
                Tabs.AddCalendar()
            ElseIf My.Settings.set_startuptab = "Hex Viewer" Then
                Tabs.AddHexViewer()
            ElseIf My.Settings.set_startuptab = "Process Viewer" Then
                Tabs.AddProcessViewer()
            ElseIf My.Settings.set_startuptab = "Service Viewer" Then
                Tabs.AddServiceViewer()
            ElseIf My.Settings.set_startuptab = "Web Browser" Then
                Tabs.AddWebBrowser()
            ElseIf My.Settings.set_startuptab = "Large File Editor" Then
                Tabs.AddLargeFileEditor()
            ElseIf My.Settings.set_startuptab = "Diagrammer" Then
                Tabs.AddDiagrammer()
            ElseIf My.Settings.set_startuptab = "Code Bank" Then
                Tabs.AddCodeBank()
            ElseIf My.Settings.set_startuptab = "WYSIWYG Editor" Then
                Tabs.AddWYSIWYGEditor()
            ElseIf My.Settings.set_startuptab = "RSS Reader" Then
                Tabs.AddRSSReader()
            End If
            If My.Settings.set_applockenabled = True Then
                frmManager.LockStudio()
            End If

            If My.Settings.set_profilestartup <> "" Then
                If IO.File.Exists(XDev.Path.Locator.GetDataPath & "\Profiles\" & My.Settings.set_profilestartup & ".xdup") Then
                    If ProfileManager.GetPassword(My.Settings.set_profilestartup) = "!NONE!" Then
                        ProfileManager.LoadProfile(My.Settings.set_profilestartup)
                        Dim newb As New BN.Toast.ToastForm(2000, "Loaded profile '" & My.Settings.set_profilestartup & "'")
                        newb.Height = "30"
                        newb.TopMost = True
                        newb.Show()
                    Else
                        Dim b As String = InputBox("Please enter the password to login to this profile, otherwise the profile will not be loaded.", "Password", "")
                        If b = ProfileManager.GetPassword(My.Settings.set_profilestartup) Then
                            ProfileManager.LoadProfile(My.Settings.set_profilestartup)
                            Dim newb As New BN.Toast.ToastForm(2000, "Loaded profile '" & My.Settings.set_profilestartup & "'")
                            newb.Height = "30"
                            newb.TopMost = True
                            newb.Show()
                        Else
                            MsgBox("Invalid Password! Profile not loaded.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error")
                        End If
                    End If
                Else
                    My.Settings.set_profilestartup = ""
                End If

            End If

            If My.Settings.set_runscriptatstartup Then
                If IO.File.Exists(My.Settings.set_scripttorunatstartup) Then
                    XDevScriptRunner.RunScript(My.Settings.set_scripttorunatstartup)
                End If
            End If

        End If
    End Sub

    'Private Shared Sub SetThemeDark()
    '    frmManager.StyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark
    '    frmManager.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlText
    '    frmManager.ToolStrip_Standard.BackColor = System.Drawing.SystemColors.ControlText
    '    SetMenuStripTextColorWhite()
    'End Sub

    'Private Shared Sub SetThemeDefault()
    '    frmManager.StyleManager1.Theme = MetroFramework.MetroThemeStyle.Default
    '    frmManager.MenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption
    '    frmManager.ToolStrip_Standard.BackColor = System.Drawing.SystemColors.ActiveCaption
    '    SetMenuStripTextColorBlack()
    'End Sub

    Public Shared Sub SetMenuStripTextColorWhite()
        frmManager.FileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.EditToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.FormatToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.InsertToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.ViewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.LanguageToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.ProjectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.ToolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.RunToolStripMenuItem3.ForeColor = System.Drawing.SystemColors.ControlLight
        frmManager.AboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight
    End Sub

    Public Shared Sub SetMenuStripTextColorBlack()
        frmManager.FileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.EditToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.FormatToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.InsertToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.ViewToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.LanguageToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.ProjectToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.ToolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.RunToolStripMenuItem3.ForeColor = System.Drawing.SystemColors.ControlText
        frmManager.AboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
    End Sub

End Class
