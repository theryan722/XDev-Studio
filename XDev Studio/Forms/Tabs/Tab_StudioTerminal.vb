Imports System.IO

Friend Class Tab_StudioTerminal
    Dim TypedText As String = ""

#Region "MenuStrip"

    Private Sub OpenOutputInNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenOutputInNotepadToolStripMenuItem.Click
        Tabs.AddNotepad(TextBox1.Text)
    End Sub

    Private Sub ScrollbarsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScrollbarsToolStripMenuItem.Click
        If TextBox1.ScrollBars = ScrollBars.Vertical Then
            TextBox1.ScrollBars = ScrollBars.None
            ScrollbarsToolStripMenuItem.Checked = False
        Else
            TextBox1.ScrollBars = ScrollBars.Vertical
            ScrollbarsToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim newb As New FontDialog
        newb.Font = TextBox1.Font
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Font = newb.Font
            UpdateSettings()
        End If
    End Sub

    Private Sub BackColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackColorToolStripMenuItem.Click
        Dim newb As New ColorDialog
        newb.Color = TextBox1.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.BackColor = newb.Color
            UpdateSettings()
        End If
    End Sub

    Private Sub ForeColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForeColorToolStripMenuItem.Click
        Dim newb As New ColorDialog
        newb.Color = TextBox1.ForeColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.ForeColor = newb.Color
            UpdateSettings()
        End If
    End Sub

    Private Sub ResetLookToDefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetLookToDefaultToolStripMenuItem.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to reset the look of the terminal to its default values?", "Reset Look", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            TextBox1.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
            TextBox1.BackColor = System.Drawing.SystemColors.InfoText
            TextBox1.ForeColor = System.Drawing.SystemColors.Window
            UpdateSettings()
        End If
    End Sub

#End Region

#Region "Methods"

#Region "Settings"

    Private Sub UpdateSettings()
        My.Settings.set_terminal_font = TextBox1.Font
        My.Settings.set_terminal_backcolor = TextBox1.BackColor
        My.Settings.set_terminal_forecolor = TextBox1.ForeColor
        My.Settings.Save()
    End Sub

    Private Sub LoadSettings()
        TextBox1.Font = My.Settings.set_terminal_font
        TextBox1.BackColor = My.Settings.set_terminal_backcolor
        TextBox1.ForeColor = My.Settings.set_terminal_forecolor
    End Sub

#End Region

    Private Sub ProcessCommand(CommandText As String)
        Dim sText As String = ""
        Try
            Select Case UCase(CommandText)
                Case "CLEAR"
                    sText = ""
                    TextBox1.Clear()
                Case "GET APP INFO"
                    sText = "----------XDev Studio Information-----------" & vbNewLine & "Product Version: " & My.Application.Info.Version.ToString & vbNewLine & "Culture: " & Application.CurrentCulture.ToString & vbNewLine & "Directory: " & My.Application.Info.DirectoryPath & vbNewLine & "Working Set: " & My.Application.Info.WorkingSet
                Case "HELP"
                    sText = "----------Help-----------" & vbNewLine & "Please see documentation for a full list of commands." & vbNewLine & "Type a command and press the enter key to run the command." & vbNewLine & "-------------------------" & vbNewLine & "Basic Commands: HELP, CLEAR,GET APP INFO" & vbNewLine & "-------------------------" & vbNewLine & "Warning: Some commands may alter the state of the application, or cause the loss of data." & vbNewLine & "Please use caution when using certain commands as some offer access and privileges not available from the GUI." & vbNewLine & "-------End Of Help--------" & vbNewLine
                Case "GET STACKTRACE"
                    sText = My.Application.Info.StackTrace
                Case "GET LOADED ASSEMBLIES"
                    For Each item As System.Reflection.Assembly In My.Application.Info.LoadedAssemblies
                        sText += item.FullName & vbNewLine & "--------------------" & vbNewLine
                    Next
                Case "APP EXIT"
                    Application.Exit()
                    sText = "Exiting Application"
                Case "APP EXIT THREAD"
                    Application.ExitThread()
                    sText = "Exiting Thread"
                Case "APP RESTART"
                    Application.Restart()
                    sText = "Restarting Application"
                Case "GET DEVELOPER"
                    sText = "BioNetWorks Corp."
                Case "GET DEVELOPER WEBSITE"
                    sText = "http://www.bionetworkscorp.net/"
                Case "GET COPYRIGHT"
                    sText = "Copyright © 2010-2015 BioNetWorks Corp. All Rights Reserved."
                Case "APP NEW INSTANCE"
                    frmManager.NewInstanceToolStripMenuItem.PerformClick()
                    sText = "Creating new Studio instance..."
                Case "APP SETTINGS SAVE"
                    My.Settings.Save()
                    sText = "Saved Application Settings"
                Case "APP SETTINGS RELOAD"
                    My.Settings.Reload()
                    sText = "Reloaded Application Settings"
                Case "APP SETTINGS RESET"
                    My.Settings.Reset()
                    sText = "Reset Settings to Default Values"
                Case "APP SETTINGS UPGRADE"
                    My.Settings.Upgrade()
                    sText = "Upgraded Settings"
                Case "GET PSS VERSION"
                    sText = "PSS Version: " & My.Resources.PSSVersion
                Case "GET TEMP DATA"
                    sText = "----------Temp Data----------" & vbNewLine & "ProjLoc: " & My.Settings.temp_projlocation & vbNewLine & "Performance Mode: " & My.Settings.temp_performancemode & vbNewLine & "----------End Temp Data----------"
                Case "RECREATE ALL"
                    DataManager.RecreateAll()
                    sText = "DataManager: Recreated all files and folders."
                Case "RECREATE FOLDERS"
                    DataManager.RecreateAllFolders()
                    sText = "DataManager: Recreated all folders."
                Case "RECREATE FILES"
                    DataManager.RecreateAllFiles()
                    sText = "DataManager: Recreated all files."
                Case "GET DATA PATH"
                    sText = XDev.Path.Locator.GetDataPath
                Case "GET WORKSPACE PATH"
                    sText = XDev.Path.Locator.GetWorkspacePath
                Case "GET STUDIO PATH"
                    sText = XDev.Path.Locator.GetAppPath
                Case "GET ENVIRONMENT INFO"
                    Try
                        Dim oProcess As New Process()
                        Dim oStartInfo As New ProcessStartInfo(XDev.Path.Locator.GetAppPath & "\Engine\Terminal\getenvironment.bat")
                        oStartInfo.UseShellExecute = False
                        oStartInfo.RedirectStandardOutput = True
                        oProcess.StartInfo = oStartInfo
                        oProcess.Start()

                        Dim sOutput As String
                        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
                            sOutput = oStreamReader.ReadToEnd()
                        End Using
                        sText = "----------Environment Info----------" & vbNewLine & sOutput & vbNewLine & "----------End Environment Info----------"
                    Catch ex As Exception
                        Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                        sText = "There was an error attempting to perform the command or action."
                    End Try
                Case "RESET FIRSTLAUNCH"
                    sText = "First launch value set to true."
                    My.Settings.set_firstlaunch = True
                Case "GET LOCAL ENVIRONMENT INFO"
                    Try
                        Dim oProcess As New Process()
                        Dim oStartInfo As New ProcessStartInfo("cmd.exe", "set")
                        oStartInfo.UseShellExecute = False
                        oStartInfo.RedirectStandardOutput = True
                        oProcess.StartInfo = oStartInfo
                        oProcess.Start()

                        Dim sOutput As String
                        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
                            sOutput = oStreamReader.ReadToEnd()
                        End Using
                        sText = "----------Local Environment Info----------" & vbNewLine & sOutput & vbNewLine & "----------End Local Environment Info----------"
                    Catch ex As Exception
                        Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                        sText = "There was an error attempting to perform the command or action."
                    End Try
                    'Case "LOAD PLUGINS"
                    '    sText = "Loading Plugins"
                    '    PluginManager.LoadPlugins()
                Case "LOGOUT CURRENT PROFILE"
                    ProfileManager.LogoutCurrentProfile()
                    sText = "Profile Manager: Cleared current profile"
                Case Else
                    sText = "Unrecognized command. Enter HELP for help."
            End Select
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            sText = "There was an error attempting to perform the command or action."
        End Try
        TextBox1.Text = TextBox1.Text & vbNewLine & vbNewLine & sText & vbNewLine & vbNewLine & "Studio:>"
        TextBox1.SelectionStart = Len(TextBox1.Text)
    End Sub

#End Region

#Region "TextBox1"

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        TextBox1.SelectionStart = Len(TextBox1.Text)
    End Sub

    'Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
    '    Try
    '        If e.KeyCode = Keys.Enter Then
    '            ProcessCommand(TypedText)
    '            TypedText = ""
    '        ElseIf e.KeyCode = Keys.Back Then
    '            If TypedText.Length > 0 Then
    '                TypedText = TypedText.Substring(0, TypedText.Length - 1)
    '            End If
    '        Else
    '            TypedText += Char.ConvertFromUtf32(e.KeyValue)
    '        End If
    '        TextBox1.SelectionStart = Len(TextBox1.Text)
    '    Catch ex As Exception
    '        Logger.WriteError(Logger.TypeOfLog.Studio, ex)
    '    End Try
    'End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                ProcessCommand(TypedText)
                TypedText = ""
            ElseIf e.KeyChar = ChrW(Keys.Back) Then
                If TypedText.Length > 0 Then
                    TypedText = TypedText.Substring(0, TypedText.Length - 1)
                Else
                    e.Handled = True
                End If
            Else
                TypedText += e.KeyChar
            End If
            TextBox1.SelectionStart = Len(TextBox1.Text)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

#End Region

    Private Sub Tab_Terminal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub

End Class