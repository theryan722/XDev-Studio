Imports System.Speech
Imports System.Speech.Recognition
Imports System.Speech.Recognition.SrgsGrammar
Imports ScintillaNET

Friend Class SpeechEngine
    Private Shared WithEvents commandreco As New SpeechRecognitionEngine
    Private Shared WithEvents dictationreco As New SpeechRecognitionEngine
    Private Shared synth As New Synthesis.SpeechSynthesizer
    Private Shared commandrecenabled As Boolean = False
    Private Shared dictationrecenabled As Boolean = False

    'Get whether the speechengine is listening for commands or not
    Public Shared Function GetCommandRecStatus() As Boolean
        Return commandrecenabled
    End Function

    'Get whether the speechengine is listening for dictation
    Public Shared Function GetDictationRecStatus() As Boolean
        Return dictationrecenabled
    End Function

#Region "Command Recognition"

    'Start listening for commands
    Public Shared Sub StartDetectingCommands()
        Try
            commandrecenabled = True
            frmManager.UpdateVoiceStatus()
            Dim grammar As New GrammarBuilder()
            grammar.Append(New Choices(System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\VoiceRecognition\commands.xdvrf")))
            commandreco.LoadGrammarAsync(New Recognition.Grammar(grammar))
            commandreco.SetInputToDefaultAudioDevice()
            commandreco.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    'Stop listening for commands
    Public Shared Sub StopDetectingCommands()
        commandrecenabled = False
        frmManager.UpdateVoiceStatus()
        commandreco.RecognizeAsyncCancel()
        commandreco.RecognizeAsyncStop()
    End Sub

    Private Shared Sub commandreco_SpeechDetected(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechDetectedEventArgs) Handles commandreco.SpeechDetected
        'Label1.Text = "Speech Detected"
        'MsgBox("speech detected")
    End Sub

    'Handle the command
    Private Shared Sub commandreco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles commandreco.SpeechRecognized
        Select Case e.Result.Text
            Case "xdev minimize studio"
                frmManager.WindowState = FormWindowState.Minimized
            Case "xdev maximize studio"
                frmManager.WindowState = FormWindowState.Maximized
            Case "xdev window state normal"
                frmManager.WindowState = FormWindowState.Normal
            Case "xdev show studio"
                frmManager.Show()
            Case "xdev hide studio"
                frmManager.Hide()
            Case "xdev exit studio"
                frmManager.ExitToolStripMenuItem.PerformClick()
            Case "xdev stop speech"
                StopDetectingCommands()
            Case "xdev insert scraped html"
                frmManager.ScrapedHTMLToolStripMenuItem.PerformClick()
            Case "xdev view tool panel"
                frmManager.ToolPanelToolStripMenuItem.PerformClick()
            Case "xdev view project explorer"
                frmManager.ProjectExplorerToolStripMenuItem.PerformClick()
            Case "xdev view welcome page"
                frmManager.WelcomePageToolStripMenuItem.PerformClick()
            Case "xdev view tips"
                frmManager.TipsToolStripMenuItem.PerformClick()
            Case "xdev view tasks"
                frmManager.TasksToolStripMenuItem.PerformClick()
            Case "xdev view logs"
                frmManager.LogsToolStripMenuItem.PerformClick()
            Case "xdev open document location"
                frmManager.OpenDocumentLocationToolStripMenuItem.PerformClick()
            Case "xdev open calendar"
                frmManager.CalendarToolStripMenuItem.PerformClick()
            Case "xdev open notepad"
                frmManager.NotepadToolStripMenuItem.PerformClick()
            Case "xdev open process viewer"
                frmManager.ProcessViewerToolStripMenuItem.PerformClick()
            Case "xdev open web browser"
                frmManager.WebBrowserToolStripMenuItem.PerformClick()
            Case "xdev open file downloader"
                frmManager.FileDownloaderToolStripMenuItem.PerformClick()
            Case "xdev open site previewer"
                frmManager.SitePreviewerToolStripMenuItem.PerformClick()
            Case "xdev open options"
                frmManager.OptionsToolStripMenuItem.PerformClick()
            Case "xdev open about"
                frmManager.AboutToolStripMenuItem1.PerformClick()
            Case "xdev open documentation"
                frmManager.LocalToolStripMenuItem.PerformClick()
            Case "xdev open command prompt"
                frmManager.CommandPromptToolStripMenuItem.PerformClick()
            Case "xdev open registry editor"
                frmManager.RegistryEditorToolStripMenuItem.PerformClick()
                'Case "xdev export to html"
                '    frmManager.ExportToHTMLToolStripMenuItem.PerformClick()
            Case "xdev backup project"
                frmManager.BackupProjectToolStripMenuItem.PerformClick()
            Case "xdev backup document"
                frmManager.BackupDocumentToolStripMenuItem.PerformClick()
            Case "xdev encrypt project"
                frmManager.EncryptProjectToolStripMenuItem.PerformClick()
            Case "xdev encrypt document"
                frmManager.EncryptDocumentToolStripMenuItem.PerformClick()
            Case "xdev new file"
                frmManager.FileToolStripMenuItem1.PerformClick()
            Case "xdev new project"
                frmManager.NewProjectToolStripMenuItem.PerformClick()
            Case "xdev open project"
                frmManager.OpenProjectToolStripMenuItem.PerformClick()
            Case "xdev open file"
                frmManager.OpenFileToolStripMenuItem.PerformClick()
            Case "xdev save"
                frmManager.SaveToolStripMenuItem.PerformClick()
            Case "xdev save as"
                frmManager.SaveAsToolStripMenuItem.PerformClick()
            Case "xdev save all"
                frmManager.SaveAllToolStripMenuItem.PerformClick()
            Case "xdev print"
                frmManager.PrintToolStripMenuItem.PerformClick()
            Case "xdev print preview"
                frmManager.PrintPreviewToolStripMenuItem.PerformClick()
            Case "xdev page setup"
                frmManager.PageSetupToolStripMenuItem.PerformClick()
            Case "xdev new instance"
                frmManager.NewInstanceToolStripMenuItem.PerformClick()
            Case "xdev close project"
                frmManager.CloseProjectToolStripMenuItem.PerformClick()
            Case "xdev import file"
                frmManager.ImportFileToolStripMenuItem.PerformClick()
            Case "xdev open project folder"
                frmManager.OpenProjectFolderToolStripMenuItem.PerformClick()
            Case "xdev set language ada"
                frmManager.AdaToolStripMenuItem.PerformClick()
            Case "xdev set language assembly"
                frmManager.AssemblyToolStripMenuItem.PerformClick()
            Case "xdev set language batch"
                frmManager.BatchToolStripMenuItem.PerformClick()
            Case "xdev set language csharp"
                frmManager.CToolStripMenuItem.PerformClick()
            Case "xdev set language see plus plus"
                frmManager.CToolStripMenuItem1.PerformClick()
            Case "xdev set language css"
                frmManager.CSSToolStripMenuItem.PerformClick()
            Case "xdev set language fortran"
                frmManager.FortranToolStripMenuItem.PerformClick()
            Case "xdev set language html"
                frmManager.HTMLToolStripMenuItem.PerformClick()
            Case "xdev set language java"
                frmManager.JavaToolStripMenuItem.PerformClick()
            Case "xdev set language javascript"
                frmManager.JavaScriptToolStripMenuItem.PerformClick()
            Case "xdev set language lisp"
                frmManager.LispToolStripMenuItem.PerformClick()
            Case "xdev set language lua"
                frmManager.LuaToolStripMenuItem.PerformClick()
            Case "xdev set language pascal"
                frmManager.PascalToolStripMenuItem.PerformClick()
            Case "xdev set language perl"
                frmManager.PerlToolStripMenuItem.PerformClick()
            Case "xdev set language php"
                frmManager.PHPToolStripMenuItem.PerformClick()
            Case "xdev set language postgresql"
                frmManager.PostgreSQLToolStripMenuItem.PerformClick()
            Case "xdev set language python"
                frmManager.PythonToolStripMenuItem.PerformClick()
            Case "xdev set language ruby"
                frmManager.RubyToolStripMenuItem.PerformClick()
            Case "xdev set language smalltalk"
                frmManager.SmalltalkToolStripMenuItem.PerformClick()
            Case "xdev set language sql"
                frmManager.SQLToolStripMenuItem.PerformClick()
            Case "xdev set language vbscript"
                frmManager.VBScriptToolStripMenuItem.PerformClick()
            Case "xdev set language xml"
                frmManager.XMLToolStripMenuItem.PerformClick()
            Case "xdev set language yaml"
                frmManager.YAMLToolStripMenuItem.PerformClick()
            Case "xdev compile java"
                frmManager.CompileToolStripMenuItem.PerformClick()
            Case "xdev run java"
                frmManager.RunToolStripMenuItem.PerformClick()
            Case "xdev compile c"
                frmManager.CompileToolStripMenuItem1.PerformClick()
            Case "xdev run c"
                frmManager.RunToolStripMenuItem1.PerformClick()
            Case "xdev compile see plus plus"
                frmManager.CompileToolStripMenuItem2.PerformClick()
            Case "xdev run see plus plus"
                frmManager.RunToolStripMenuItem2.PerformClick()
            Case Else
                synth.Speak("Unrecognized Command.")
        End Select
    End Sub

#Region "Actions"

    'Private Sub SetColor(ByVal color As System.Drawing.Color)
    '    commandreco.RecognizeAsyncCancel()
    '    commandreco.RecognizeAsyncStop()
    '    synth.Speak("setting the back color to " & color.ToString)
    '    commandreco.RecognizeAsync(RecognizeMode.Multiple)
    'End Sub

#End Region

#End Region

#Region "Dictation"

    'Start dictating to the editor
    Public Shared Sub StartDictation()
        Try
            dictationrecenabled = True
            frmManager.UpdateVoiceStatus()
            Dim gram As New System.Speech.Recognition.DictationGrammar()
            dictationreco.LoadGrammarAsync(gram)
            dictationreco.SetInputToDefaultAudioDevice()
            dictationreco.RecognizeAsync(RecognizeMode.Multiple)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Shared Sub dictationreco_SpeechDetected(ByVal sender As Object, ByVal e As System.Speech.Recognition.SpeechDetectedEventArgs) Handles dictationreco.SpeechDetected
        'Label1.Text = "Speech Detected"
        'MsgBox("speech detected")
    End Sub

    'Handle some commands for editing
    Private Shared Sub dictationreco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles dictationreco.SpeechRecognized
        If frmManager.IsCodeEditor() Then
            Select Case e.Result.Text
                Case "xdev stop speech"
                    StopDictation()
                Case "undo"
                    frmManager.UndoToolStripMenuItem.PerformClick()
                Case "redo"
                    frmManager.RedoToolStripMenuItem.PerformClick()
                Case "paste"
                    frmManager.PasteToolStripMenuItem.PerformClick()
                Case "copy"
                    frmManager.CopyToolStripMenuItem.PerformClick()
                Case "cut"
                    frmManager.CutToolStripMenuItem.PerformClick()
                Case "select all"
                    frmManager.SelectAllToolStripMenuItem.PerformClick()
                Case "clear all"
                    frmManager.ClearAllToolStripMenuItem.PerformClick()
                Case "space"
                    CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().InsertText(" ")
                Case "delete line"
                    CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).DeleteLineToolStripMenuItem.PerformClick()
                Case "line up"
                    CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.LineUp)
                Case "line down"
                    CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.LineDown)
                Case Else
                    CType(frmManager.DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(e.Result.Text)
            End Select
        Else
            synth.Speak("Dictation only available for code editor.")
        End If

    End Sub

    'Stop dictating
    Public Shared Sub StopDictation()
        dictationrecenabled = False
        frmManager.UpdateVoiceStatus()
        dictationreco.RecognizeAsyncCancel()
        dictationreco.RecognizeAsyncStop()
    End Sub

#End Region

#Region "Speech"

    Public Shared Sub SpeakText(ByVal txt As String)
        synth.SpeakAsync(txt)
    End Sub

    Public Shared Sub CancelSpeaking()
        synth.SpeakAsyncCancelAll()
    End Sub
    
#End Region

End Class
