Imports MetroFramework
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports ScintillaNET
Imports System.Diagnostics
Imports System.Reflection
Imports System.Text
Imports System.Xml
Imports System.CodeDom.Compiler
Imports Microsoft.VisualBasic
Imports System.Threading.Tasks
Imports XDev.Editor

Friend Class Tab_CodeEditor

#Region "Variables"

    Dim fileloc As String
    Private AMacro As MacroObjects.Macro
    Private Recorder As MacroObjects.MacroRecorder
    Private infopanel_pinup As Boolean = False
    Private maxLineNumberCharLength As Integer
    Dim NetAssemblies As New List(Of String)
    Dim net_compileaswinforms As Boolean = False
    Private watchfile As FileSystemWatcher
    Private filealerted As Boolean = False
    Public cureditor As Integer = 1

#End Region
    
#Region "Methods"

#Region "Language Compilation/Running"

#Region "Java"

    Public Sub CompileJavaCode(ByVal run As Boolean)
        If run Then
            SetOutput("Compiling and running " & Path.GetFileName(GetFileLocation) & "...")
        Else
            SetOutput("Compiling " & Path.GetFileName(GetFileLocation) & "...")
        End If
        AddToOutput("=================================")
        Dim b As New List(Of String)
        b = LanguageCompiler.CompileJavaWithOutput(GetFileLocation(), run)
        If b IsNot Nothing Then
            AddToOutput(b(0))
            AddToOutput(b(1))
        End If
        Logger.Write(Logger.TypeOfLog.Code, b(0))
        Logger.Write(Logger.TypeOfLog.Code, b(1))
    End Sub

    Public Sub RunJavaCode()
        SetOutput("Running " & Path.GetFileName(GetFileLocation) & "...")
        LanguageCompiler.RunJavaClass(GetFileLocation())
        'LanguageCompiler.RunJavaClass(Path.GetDirectoryName(GetFileLocation()) + "\Compiled\" + Path.GetFileNameWithoutExtension(GetFileLocation()))
        'System.Diagnostics.Process.Start("Explorer.exe", Path.GetDirectoryName(GetFileLocation()) + "\Compiled\" + Path.GetFileNameWithoutExtension(GetFileLocation()) + ".class")
    End Sub

#End Region

#Region "C++"

    Public Sub CompileCPPCode(ByVal run As Boolean)
        If run Then
            SetOutput("Compiling and running " & Path.GetFileName(GetFileLocation) & "...")
        Else
            SetOutput("Compiling " & Path.GetFileName(GetFileLocation) & "...")
        End If
        AddToOutput("=================================")
        Dim b(2) As String
        b = LanguageCompiler.CompileCPPWithOutput(GetFileLocation(), run)
        AddToOutput(b(0))
        AddToOutput(b(1))
        Logger.Write(Logger.TypeOfLog.Code, b(0))
        Logger.Write(Logger.TypeOfLog.Code, b(1))
    End Sub

    Public Sub RunCPPCode()
        SetOutput("Running " & Path.GetFileName(GetFileLocation) & "...")
        LanguageCompiler.RunCPPEXE(GetFileLocation())
    End Sub
#End Region

#Region "C"
    Public Sub CompileCCode(ByVal run As Boolean)
        If run Then
            SetOutput("Compiling and running " & Path.GetFileName(GetFileLocation) & "...")
        Else
            SetOutput("Compiling " & Path.GetFileName(GetFileLocation) & "...")
        End If
        AddToOutput("=================================")
        Dim b(2) As String
        b = LanguageCompiler.CompileCWithOutput(GetFileLocation(), run)
        AddToOutput(b(0))
        AddToOutput(b(1))
        Logger.Write(Logger.TypeOfLog.Code, b(0))
        Logger.Write(Logger.TypeOfLog.Code, b(1))
    End Sub

    Public Sub RunCCode()
        SetOutput("Running " & Path.GetFileName(GetFileLocation) & "...")
        LanguageCompiler.RunCEXE(GetFileLocation())
    End Sub
#End Region

#Region "Custom"

    Public Sub CompileCustomCode(ByVal run As Boolean)
        If run Then
            SetOutput("Compiling and running " & Path.GetFileName(GetFileLocation) & "...")
        Else
            SetOutput("Compiling " & Path.GetFileName(GetFileLocation) & "...")
        End If
        AddToOutput("=================================")
        Dim b(2) As String
        b = LanguageCompiler.CompileCustomWithOutput(GetFileLocation(), run)
        AddToOutput(b(0))
        AddToOutput(b(1))
        Logger.Write(Logger.TypeOfLog.Code, b(0))
        Logger.Write(Logger.TypeOfLog.Code, b(1))
    End Sub

    Public Sub RunCustomCode()
        SetOutput("Running " & Path.GetFileName(GetFileLocation) & "...")
        LanguageCompiler.RunCustom(GetFileLocation())
    End Sub

#End Region

#Region ".NET"

#Region "Assembly List/Compile Stuff"

    Public Sub SetCompileAsWinForms(ByVal val As Boolean)
        net_compileaswinforms = val
    End Sub

    Public Function GetCompileAsWinforms() As Boolean
        Return net_compileaswinforms
    End Function

    Public Sub AddToNetAssemblies(ByVal loc As String)
        If Not NetAssemblies.Contains(loc) Then
            NetAssemblies.Add(loc)
        End If
    End Sub

    Public Sub RemoveFromNetAssemblies(ByVal loc As String)
        If NetAssemblies.Contains(loc) Then
            NetAssemblies.Remove(loc)
        End If
    End Sub

    Public Function GetNetAssemblies() As List(Of String)
        Return NetAssemblies
    End Function

    Public Sub ClearNetAssemblies()
        NetAssemblies.Clear()
    End Sub

    Public Function GetNetAssembliesCount() As Integer
        Return NetAssemblies.Count
    End Function

#End Region

#Region "C#"

    Public Sub CompileCSharpCode(ByVal run As Boolean)
        Try
            If run Then
                SetOutput("Compiling and running " & Path.GetFileName(GetFileLocation) & "...")
            Else
                SetOutput("Compiling " & Path.GetFileName(GetFileLocation) & "...")
            End If
            AddToOutput("=================================")
            Dim b As String = LanguageCompiler.CompileCSharpCodeWithOutput(GetFileLocation, InputBox("Enter the Entry Point", "Entry Point", Path.GetFileNameWithoutExtension(GetFileLocation)), GetNetAssemblies, net_compileaswinforms, run)
            AddToOutput(b)
            Logger.Write(Logger.TypeOfLog.Code, txt_Output.Text)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try

    End Sub

    Public Sub RunCSharpCode()
        Try
            Logger.Write(Logger.TypeOfLog.Code, "Running " & Path.GetFileName(GetFileLocation))
            SetOutput("Running " & Path.GetFileName(GetFileLocation))
            LanguageCompiler.RunCSharpEXE(GetFileLocation())
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

#End Region

#Region "VB"

    Public Sub CompileVBCode(ByVal run As Boolean)
        If run Then
            SetOutput("Compiling and running " & Path.GetFileName(GetFileLocation) & "...")
        Else
            SetOutput("Compiling " & Path.GetFileName(GetFileLocation) & "...")
        End If
        AddToOutput("=================================")
        Dim b As String = LanguageCompiler.CompileVBNetCodeWithOutput(GetFileLocation, InputBox("Enter the Entry Point", "Entry Point", Path.GetFileNameWithoutExtension(GetFileLocation)), GetNetAssemblies, net_compileaswinforms, run)
        AddToOutput(b)

        Logger.Write(Logger.TypeOfLog.Code, txt_Output.Text)

    End Sub

    Public Sub RunVBCode()
        Try
            Logger.Write(Logger.TypeOfLog.Code, "Running " & Path.GetFileName(GetFileLocation))
            SetOutput("Running " & Path.GetFileName(GetFileLocation))
            LanguageCompiler.RunVBEXE(GetFileLocation())
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

#End Region

#End Region

#End Region

#Region "Info Panel"

#Region "FTP"

    Private Function FTPFieldsAreValid() As Boolean
        Dim b As Boolean = True
        If txt_ftpusername.Text = "" Then
            b = False
        ElseIf txt_ftpuserpass.Text = "" Then
            b = False
        ElseIf txt_ftphostname.Text = "" Then
            b = False
        ElseIf txt_ftpfilepath.Text = "" Then
            b = False
        End If
        Return b
    End Function

    Private Sub EnableFTPButtons()
        txt_ftpfilepath.Enabled = True
        txt_ftpusername.Enabled = True
        txt_ftpuserpass.Enabled = True
        btn_ftpupload.Enabled = True
        btn_ftpdownload.Enabled = True
        check_showpassword.Enabled = True
    End Sub

    Private Sub DisableFTPButtons()
        txt_ftpfilepath.Enabled = False
        txt_ftpusername.Enabled = False
        txt_ftpuserpass.Enabled = False
        btn_ftpupload.Enabled = False
        btn_ftpdownload.Enabled = False
        check_showpassword.Enabled = False
    End Sub

#End Region

#End Region

#Region "Macro"

    Public Sub StartRecordingMacro()
        If Not AMacro Is Nothing AndAlso AMacro.Playing Then Exit Sub 'an actual macro pressed me, so i wont do anything! dont want to loop!
        If Recorder.Recording Then
            'do nothing
        Else
            Logger.Write(Logger.TypeOfLog.Studio, "Started recording macro.")
            Recorder.BeginRecording()
            'btnRecord.Text = "Stop"
        End If
    End Sub

    Public Sub StopRecordingMacro()
        If Not AMacro Is Nothing AndAlso AMacro.Playing Then Exit Sub 'an actual macro pressed me, so i wont do anything! dont want to loop!
        If Recorder.Recording Then
            If Not AMacro Is Nothing Then AMacro.Dispose() 'kill any old macro
            AMacro = Recorder.StopRecording 'stop recording and save to AMacro
            Logger.Write(Logger.TypeOfLog.Studio, "Stopped recording macro.")
            'btnRecord.Text = "Record"
        Else
            'do nothing
            'btnRecord.Text = "Stop"
        End If
    End Sub

    Public Sub ToggleRecordingMacro()
        If Not AMacro Is Nothing AndAlso AMacro.Playing Then Exit Sub 'an actual macro pressed me, so i wont do anything! dont want to loop!
        If Recorder.Recording Then
            If Not AMacro Is Nothing Then AMacro.Dispose() 'kill any old macro
            AMacro = Recorder.StopRecording 'stop recording and save to AMacro
            'btnRecord.Text = "Record"
            Logger.Write(Logger.TypeOfLog.Studio, "Stopped recording macro.")
        Else
            Logger.Write(Logger.TypeOfLog.Studio, "Started recording macro.")
            Recorder.BeginRecording()
            'btnRecord.Text = "Stop"
        End If
    End Sub

    Public Sub RunMacro()
        If Not AMacro Is Nothing Then
            If AMacro.Playing Then Exit Sub 'an actual macro pressed me, so i wont do anything! dont want to loop!
            Logger.Write(Logger.TypeOfLog.Studio, "Playing Macro.")
            AMacro.PlayBack(Me) 'playback macro
        End If
    End Sub

    Public Sub RunMacro(ByVal times As Integer)
        If times > 0 Then
            Logger.Write(Logger.TypeOfLog.Studio, "Playing Macro " & times & " times.")
            For t As Integer = 0 To times - 1
                If Not AMacro Is Nothing Then
                    If AMacro.Playing Then Exit Sub 'an actual macro pressed me, so i wont do anything! dont want to loop!
                    AMacro.PlayBack(Me) 'playback macro
                End If
            Next
        End If
    End Sub

#End Region

#Region "File Monitoring"

    Public Sub StartMonitoringFile()
        filealerted = False
        watchfile = New System.IO.FileSystemWatcher()
        watchfile.Path = Path.GetDirectoryName(GetFileLocation())
        watchfile.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.Attributes Or NotifyFilters.FileName Or NotifyFilters.DirectoryName)
        watchfile.Filter = Path.GetFileName(GetFileLocation)
        AddHandler watchfile.Changed, AddressOf filechange
        AddHandler watchfile.Deleted, AddressOf filechange
        AddHandler watchfile.Renamed, AddressOf filerename
        watchfile.EnableRaisingEvents = True
    End Sub

    Public Sub StopMonitoringFile()
        watchfile.EnableRaisingEvents = False
    End Sub

    Public Sub filerename(ByVal source As Object, ByVal e As System.IO.RenamedEventArgs)
        If filealerted = False And Not My.Settings.temp_performancemode Then
            filealerted = True
            If MsgBox("The file '" & e.OldName & "' has been renamed to '" & e.Name & "'. Do you want to update this information in the editor? If no the editor will no longer save to that file.", MessageBoxButtons.YesNo + MessageBoxIcon.Exclamation, "File Renamed") = Windows.Forms.DialogResult.Yes Then
                StopMonitoringFile()
                SetFileLocation(e.FullPath)
                UpdateTitle(e.Name)
                StartMonitoringFile()
            Else
                StopMonitoringFile()
                If My.Settings.set_keepfileloc = False Then
                    UpdateTitle("Untitled")
                    SetFileLocation("")
                End If
            End If
        End If
    End Sub

    Private Sub filechange(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
        If e.ChangeType = IO.WatcherChangeTypes.Deleted And filealerted = False And Not My.Settings.temp_performancemode Then
            filealerted = True
            StopMonitoringFile()
            If MsgBox("The file '" & e.Name & "' has been deleted. Do you want to keep this editor open?", MessageBoxButtons.YesNo + MessageBoxIcon.Exclamation, "File Deleted") = Windows.Forms.DialogResult.Yes Then
                If My.Settings.set_keepfileloc = False Then
                    UpdateTitle("Untitled")
                    SetFileLocation("")
                End If
            Else
                TextBox1.Saved = True
                Me.Close()
            End If
            'ElseIf e.ChangeType = IO.WatcherChangeTypes.Changed And filealerted = False And Not My.Settings.temp_performancemode Then
            '    If MsgBox("The file '" & e.Name & "' has been modified. Do you want to update this editor to match the file? Any changes in the editor will be lost.", MessageBoxButtons.YesNo + MessageBoxIcon.Exclamation, "File Modified") = Windows.Forms.DialogResult.Yes Then
            '        LoadFile(GetFileLocation)
            '    End If
        End If
    End Sub

#End Region

    Public Sub AddToClipboardHistory(ByVal txt As String)
        TextBox1.AddTextToClipboardHistory(txt)
        TextBox2.AddTextToClipboardHistory(txt)
    End Sub

    Public Sub ClearClipboardHistory()
        TextBox1.ClearClipboardHistory()
        TextBox2.ClearClipboardHistory()
    End Sub

    Public Sub AddFileToRecentlyClosed()
        If GetFileLocation() <> "" And Not My.Settings.set_recentlyclosedfiles.Contains(GetFileLocation()) Then
            My.Settings.set_recentlyclosedfiles.Add(GetFileLocation())
        End If
    End Sub

    Public Sub EnableSplitView()
        SplitContainer_Editors.Panel2Collapsed = False
        EnabledToolStripMenuItem.Checked = True
        HorizontalToolStripMenuItem.Enabled = True
        VerticalToolStripMenuItem.Enabled = True
    End Sub

    Public Sub SetSplitViewOrientationHorizontal()
        SplitContainer_Editors.Orientation = Orientation.Horizontal
        HorizontalToolStripMenuItem.Checked = True
        VerticalToolStripMenuItem.Checked = False
    End Sub

    Public Sub SetSplitViewOrientationVertical()
        SplitContainer_Editors.Orientation = Orientation.Vertical
        HorizontalToolStripMenuItem.Checked = False
        VerticalToolStripMenuItem.Checked = True
    End Sub

    Public Sub DisableSplitView()
        SplitContainer_Editors.Panel2Collapsed = True
        EnabledToolStripMenuItem.Checked = False
        HorizontalToolStripMenuItem.Enabled = False
        VerticalToolStripMenuItem.Enabled = False
    End Sub

    Public Function GetCurrentEditor() As XEditor
        If cureditor = 1 Then
            Return TextBox1
        Else
            Return TextBox2
        End If
    End Function

    Public Sub SetLanguage(ByVal lang As Language.EditorLanguage)
        TextBox1.Language = lang
        TextBox2.Language = lang
        txt_documentmap.Language = lang
    End Sub

    Enum InfoPanelTab
        Info
        Output
        Errors
        Tasks
        Notes
        FTP
    End Enum
    Public Function IsDocumentMapVisible() As Boolean
        If SplitContainer1.Panel2Collapsed Then
            Return False
        Else
            Return True
        End If
    End Function


    Public Sub ShowDocumentMap()
        SplitContainer1.Panel2Collapsed = False
        DocumentMapToolStripMenuItem.Checked = True
        txt_documentmap.Language = TextBox1.Language
    End Sub

    Public Sub HideDocumentMap()
        SplitContainer1.Panel2Collapsed = True
        DocumentMapToolStripMenuItem.Checked = False
    End Sub

    Public Sub BeautifyXML(ByVal selectiononly As Boolean)
        If selectiononly = True Then
            Try
                Dim doc As New XmlDocument
                doc.LoadXml(GetCurrentEditor().SelectedText)
                Dim sb As New StringBuilder()
                Dim settings As New XmlWriterSettings()
                settings.Indent = True
                settings.IndentChars = "  "
                settings.NewLineChars = vbCr & vbLf
                settings.NewLineHandling = NewLineHandling.Replace
                Dim writer As XmlWriter = XmlWriter.Create(sb, settings)
                doc.Save(writer)
                writer.Close()
                GetCurrentEditor().SelectedText = sb.ToString
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        Else
            Try
                Dim doc As New XmlDocument
                doc.LoadXml(GetCurrentEditor().Text)
                Dim sb As New StringBuilder()
                Dim settings As New XmlWriterSettings()
                settings.Indent = True
                settings.IndentChars = "  "
                settings.NewLineChars = vbCr & vbLf
                settings.NewLineHandling = NewLineHandling.Replace
                Dim writer As XmlWriter = XmlWriter.Create(sb, settings)
                doc.Save(writer)
                writer.Close()
                GetCurrentEditor().Text = sb.ToString
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If

    End Sub

    Private Sub InitializeCodeEditor()
        LoadSettings()
        txt_documentmap.Language = TextBox1.Language
        TextBox2.Document = TextBox1.Document
        TextBox1.UpdateSyntaxHighlighting()
        TextBox2.UpdateSyntaxHighlighting()
    End Sub

    Public Sub ToggleInfoPanel()
        If Panel_Bottom.Height > 16 Then
            HideInfoPanel()
        Else
            ShowInfoPanel(True)
        End If
    End Sub

    Public Function GetNotes() As String
        Return txt_notes.Text
    End Function

    Public Sub SetNotes(ByVal txt As String)
        txt_notes.Text = txt
        SetSelectedInfoPanelTab(InfoPanelTab.Notes)
    End Sub

    Public Sub AddLineToNotes(ByVal txt As String)
        txt_notes.Text += vbNewLine
        txt_notes.Text += txt
        SetSelectedInfoPanelTab(InfoPanelTab.Notes)
    End Sub

    Public Sub AddToNotes(ByVal txt As String)
        txt_notes.Text += txt
        SetSelectedInfoPanelTab(InfoPanelTab.Notes)
    End Sub

    Public Sub SetSelectedInfoPanelTab(ByVal tab As InfoPanelTab)
        ShowInfoPanel(True)
        Select Case tab
            Case InfoPanelTab.Info
                TabControl_InfoPanel.SelectedTab = Tab_Info
            Case InfoPanelTab.Output
                TabControl_InfoPanel.SelectedTab = Tab_Output
            Case InfoPanelTab.Errors
                TabControl_InfoPanel.SelectedTab = Tab_Errors
            Case InfoPanelTab.Tasks
                TabControl_InfoPanel.SelectedTab = Tab_Tasks
            Case InfoPanelTab.Notes
                TabControl_InfoPanel.SelectedTab = Tab_Notes
            Case InfoPanelTab.FTP
                TabControl_InfoPanel.SelectedTab = Tab_FTP
        End Select
    End Sub

    Public Sub AddBookmarkAtCurrentLine()
        If GetFileLocation() <> "" Then
            My.Settings.set_codebookmarks.Add(GetCurrentEditor().CurrentLine + 1 & "|" & GetFileLocation() & "|" & GetCurrentEditor().GetTextFromLine(GetCurrentEditor().CurrentLine))
            My.Settings.Save()
            MetroMessageBox.Show(frmManager, "Created bookmark at line '" & GetCurrentEditor().CurrentLine + 1 & "'", "New Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub AddBookmarkAtSpecificLine()
        If GetFileLocation() <> "" Then
            Dim newb As String = InputBox("Enter line number to bookmark.", "New Bookmark", "")
            If newb <> "" Then
                My.Settings.set_codebookmarks.Add(newb & "|" & GetFileLocation() & "|" & GetCurrentEditor().GetTextFromLine(newb - 1))
                My.Settings.Save()
                MetroMessageBox.Show(frmManager, "Created bookmark at line '" & newb & "'", "New Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Public Sub LoadSettings()
        '-----------------------
        TextBox1.SetSyntaxHighlightingArray(SyntaxHighlighting.GetHighlightArray)
        TextBox2.SetSyntaxHighlightingArray(SyntaxHighlighting.GetHighlightArray)
        txt_documentmap.SetSyntaxHighlightingArray(SyntaxHighlighting.GetHighlightArray)
        Dim ttlist As New List(Of String)
        ttlist.Clear()
        For Each item As String In My.Settings.set_tabtriggers
            ttlist.Add(item)
        Next
        Dim ctlist As New List(Of String)
        ctlist.Clear()
        For Each item As String In My.Settings.set_codetemplates
            ctlist.Add(item)
        Next

        Dim chlist As New List(Of String)
        chlist.Clear()
        For Each item As String In My.Settings.set_clipboardhistory
            chlist.Add(item)
        Next
        '-----------------------
        'UpdateTitle(filename)
        'TextBox1
        TextBox1.CustomLanguageEnabled = My.Settings.set_customlang_enabled
        TextBox1.SetCustomLanguage(My.Settings.set_customlang_keywords0, My.Settings.set_customlang_keywords1, My.Settings.set_customlang_autocompletelist)

        TextBox1.Font = My.Settings.set_defaultfont

        TextBox1.RightToLeft = My.Settings.set_righttoleft

        TextBox1.EolMode = My.Settings.set_endofline

        TextBox1.ViewEol = My.Settings.set_eolvisible

        TextBox1.CaretStyle = My.Settings.set_caret

        TextBox1.AllowDrop = My.Settings.set_allowdragdrop

        TextBox1.OverType = My.Settings.set_Overtype

        If My.Settings.set_cursor = 0 Then
            TextBox1.Cursor = Cursors.IBeam
        ElseIf My.Settings.set_cursor = 1 Then
            TextBox1.Cursor = Cursors.Arrow
        End If

        TextBox1.HighlightCurrentLine = My.Settings.set_highlightselectedline

        TextBox1.MatchBraces = My.Settings.set_highlightmatchingbraceswhenselected

        TextBox1.IndentationGuides = My.Settings.set_showindentationguides

        TextBox1.SmartIndentation = My.Settings.set_usesmartindentation

        TextBox1.SmartCompletion = My.Settings.set_usesmartcompletion

        TextBox1.AutoComplete = My.Settings.set_autocomplete_enabled

        TextBox1.HighlightMatchingSelection = My.Settings.set_highlightmatchingselection

        TextBox1.MultiPaste = My.Settings.set_multipaste

        TextBox1.MultipleSelection = My.Settings.set_multiselection

        TextBox1.WrapMode = My.Settings.set_wrapmode

        TextBox1.HighlightMatchingWords = My.Settings.set_highlightmatchingwords

        TextBox1.MultiSelectionTyping = My.Settings.set_multiselectiontyping

        TextBox1.TabTriggers = ttlist

        TextBox1.TabTriggersEnabled = My.Settings.set_tabtriggers_enabled

        TextBox1.TabTriggersReplacePhrase = My.Settings.set_tabtriggers_replacephrase

        TextBox1.CodeTemplates = ctlist

        TextBox1.HighlightCurrentBlock = My.Settings.set_highlightcurrentblock

        TextBox1.RecordClipboardHistory = My.Settings.set_recordclipboardhistory

        If My.Settings.set_rememberclipboardhistory Then
            TextBox1.ClipboardHistory = chlist
        End If

        TextBox1.HomeEndKeysNavigateWrappedLines = My.Settings.set_homekeywrappedlines
        '------------------------------
        TextBox2.CustomLanguageEnabled = My.Settings.set_customlang_enabled
        TextBox2.SetCustomLanguage(My.Settings.set_customlang_keywords0, My.Settings.set_customlang_keywords1, My.Settings.set_customlang_autocompletelist)

        TextBox2.Font = My.Settings.set_defaultfont

        TextBox2.RightToLeft = My.Settings.set_righttoleft

        TextBox2.EolMode = My.Settings.set_endofline

        TextBox2.ViewEol = My.Settings.set_eolvisible

        TextBox2.CaretStyle = My.Settings.set_caret

        TextBox2.AllowDrop = My.Settings.set_allowdragdrop

        TextBox2.OverType = My.Settings.set_Overtype

        If My.Settings.set_cursor = 0 Then
            TextBox2.Cursor = Cursors.IBeam
        ElseIf My.Settings.set_cursor = 1 Then
            TextBox2.Cursor = Cursors.Arrow
        End If

        TextBox2.HighlightCurrentLine = My.Settings.set_highlightselectedline

        TextBox2.MatchBraces = My.Settings.set_highlightmatchingbraceswhenselected

        TextBox2.IndentationGuides = My.Settings.set_showindentationguides

        TextBox2.SmartIndentation = My.Settings.set_usesmartindentation

        TextBox2.SmartCompletion = My.Settings.set_usesmartcompletion

        TextBox2.AutoComplete = My.Settings.set_autocomplete_enabled

        TextBox2.HighlightMatchingSelection = My.Settings.set_highlightmatchingselection

        TextBox2.MultiPaste = My.Settings.set_multipaste

        TextBox2.MultipleSelection = My.Settings.set_multiselection

        TextBox2.WrapMode = My.Settings.set_wrapmode

        TextBox2.HighlightMatchingWords = My.Settings.set_highlightmatchingwords

        TextBox2.MultiSelectionTyping = My.Settings.set_multiselectiontyping

        TextBox2.TabTriggers = ttlist

        TextBox2.TabTriggersEnabled = My.Settings.set_tabtriggers_enabled

        TextBox2.TabTriggersReplacePhrase = My.Settings.set_tabtriggers_replacephrase

        TextBox2.CodeTemplates = ctlist

        TextBox2.HighlightCurrentBlock = My.Settings.set_highlightcurrentblock

        TextBox2.RecordClipboardHistory = My.Settings.set_recordclipboardhistory

        If My.Settings.set_rememberclipboardhistory Then
            TextBox2.ClipboardHistory = chlist
        End If

        TextBox2.HomeEndKeysNavigateWrappedLines = My.Settings.set_homekeywrappedlines
        '-----------------------------------
        LoadQuickSettings()

        txt_ftpusername.Text = My.Settings.set_ftpusername
        txt_ftpuserpass.Text = My.Settings.set_ftpuserpass
        txt_ftphostname.Text = My.Settings.set_ftphostname
        txt_ftpfilepath.Text = "/DIRECTORY/" & System.IO.Path.GetFileName(GetFileLocation)
        For Each item As String In My.Settings.set_ftppathhistory
            txt_ftpfilepath.Items.Add(item)
        Next


        If My.Settings.set_showinfopanelbydefault = True Then
            ShowInfoPanel(True)
        Else
            HideInfoPanel()
        End If
        If My.Settings.set_editordocumentmap And Not My.Settings.temp_performancemode Then
            ShowDocumentMap()
            If txt_documentmap.Zoom = -10 Then
                NormalToolStripMenuItem.Checked = True
            ElseIf txt_documentmap.Zoom = -7 Then
                LargeToolStripMenuItem.Checked = True
            ElseIf txt_documentmap.Zoom = -4 Then
                ExtraLargeToolStripMenuItem.PerformClick()
            End If
        Else
            HideDocumentMap()
        End If
        '--------Macros
        Recorder = New MacroObjects.MacroRecorder(Me)
    End Sub

    Public Sub UpdateInfoTab()
        txt_info.Text = "Word Count: " & CountWords(GetCurrentEditor().Text) & vbNewLine & "Character Count: " & GetCurrentEditor().GetTextLength & vbNewLine & "Words in Selection: " & CountWords(GetCurrentEditor().SelectedText) & vbNewLine & "Selection Length: " & GetCurrentEditor().SelectedText.Length & vbNewLine & "Total Lines: " & GetCurrentEditor().GetTotalLines & vbNewLine & "Position: " & GetCurrentEditor().CurrentPosition & vbNewLine & "Column: " & GetCurrentEditor().GetColumn(GetCurrentEditor().CurrentPosition) & vbNewLine & "Language: " & LanguageEnum.ConvertEnumToReadable(GetCurrentEditor().Language) & vbNewLine & "ReadOnly: " & GetCurrentEditor().IsReadOnly & vbNewLine & "Macro Recording:" & Recorder.Recording
    End Sub

    Public Function CountWords(ByVal value As String) As Integer
        ' Count matches.
        Dim collection As MatchCollection = Regex.Matches(value, "\S+")
        Return collection.Count
    End Function

    Public Sub SetCustomSyntaxHighlighting(ByVal keywords0 As String, ByVal keywords1 As String, ByVal autocompletelist As String)
        TextBox1.SetCustomLanguage(keywords0, keywords1, autocompletelist)
        TextBox1.CustomLanguageEnabled = True
        TextBox2.SetCustomLanguage(keywords0, keywords1, autocompletelist)
        TextBox2.CustomLanguageEnabled = True
    End Sub

    Private Sub RefreshTasks()
        ListBox_Tasks.Items.Clear()
        For Each item As String In My.Settings.set_tasklisttodo
            ListBox_Tasks.Items.Add(item)
        Next
    End Sub

    Public Sub RunFile()
        Try
            System.Diagnostics.Process.Start(GetFileLocation())
        Catch
        End Try
    End Sub

    Public Sub RunFile(ByVal CreateNoWindow As Boolean, ByVal args As String)
        Try
            txt_Errors.Clear()
            txt_Output.Clear()
            Dim process = New Process()
            process.StartInfo.FileName = GetFileLocation()
            process.StartInfo.Arguments = args
            process.StartInfo.UseShellExecute = False
            process.StartInfo.CreateNoWindow = CreateNoWindow
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            'Process.StartInfo.RedirectStandardInput = True
            process.Start()
            Dim outputReader As StreamReader = process.StandardOutput
            Dim errorReader As StreamReader = process.StandardError
            txt_Output.Text = outputReader.ReadToEnd()
            txt_Errors.Text = errorReader.ReadToEnd()
            process.WaitForExit()
        Catch

        End Try
    End Sub

    Public Sub HideInfoPanel()
        Panel_Bottom.Height = 16
        Btn_HideShowOutput.BackgroundImage = My.Resources._16_up
        infopanel_pinup = False
    End Sub

    Public Sub ShowInfoPanel(ByVal pinup As Boolean)
        Panel_Bottom.Height = My.Settings.set_infopanelsize
        Btn_HideShowOutput.BackgroundImage = My.Resources._16_down
        infopanel_pinup = pinup
    End Sub

    Public Sub AddToOutput(ByVal txt)
        txt_Output.Text += vbNewLine
        txt_Output.Text += txt
        SetSelectedInfoPanelTab(InfoPanelTab.Output)
    End Sub

    Public Sub SetOutput(ByVal txt)
        txt_Output.Text = txt
        SetSelectedInfoPanelTab(InfoPanelTab.Output)
    End Sub

    Public Sub AddToErrors(ByVal txt)
        txt_Errors.Text += vbNewLine
        txt_Errors.Text += txt
        SetSelectedInfoPanelTab(InfoPanelTab.Errors)
    End Sub

    Public Sub SetErrors(ByVal txt)
        txt_Errors.Text = txt
        SetSelectedInfoPanelTab(InfoPanelTab.Errors)
    End Sub

    Public Sub UpdateTitle(ByVal title As String)
        Me.Text = title
    End Sub

    Public Function GetTitle() As String
        Return Me.Parent.Text
    End Function

    Public Function GetSaved() As Boolean
        Return TextBox1.Saved
    End Function

    Public Function GetFileName() As String
        If GetFileLocation() = "" Then
            Return ""
        Else
            Return System.IO.Path.GetFileName(GetFileLocation)
        End If
    End Function

    Public Function GetFileName(ByVal ifblankreturnuntitled As Boolean) As String
        If GetFileLocation() = "" Then
            Return "Untitled"
        Else
            Return System.IO.Path.GetFileName(GetFileLocation)
        End If
    End Function

    Public Function GetFileLocation() As String
        Return fileloc
    End Function

    Public Sub SetFileLocation(ByVal loc As String)
        fileloc = loc
        Me.DockHandler.ToolTipText = loc
        If loc <> "" And Not My.Settings.temp_performancemode Then
            StartMonitoringFile()
        End If
    End Sub

    Public Sub LoadExtCode(ByVal txt As String, ByVal lang As XDev.Editor.Language.EditorLanguage)
        TextBox1.Text = txt

        'TextBox1.ConfigurationManager.Language = lang
        'TextBox1.ConfigurationManager.Configure()
        SetLanguage(lang)
        'UpdateTitle("Untitled")
    End Sub

    Public Sub LoadFile(ByVal floc As String)
        If System.IO.File.Exists(floc) Then
            Try
                Dim t As Task = Task.Factory.StartNew(Sub()
                                                          TextBox1.Text = My.Computer.FileSystem.ReadAllText(floc)
                                                          TextBox1.Saved = True
                                                          Try
                                                              SetLanguage(LanguageEnum.ConvertExtensionToEnum(Path.GetExtension(floc)))
                                                          Catch
                                                          End Try
                                                          SetFileLocation(floc)
                                                      End Sub)
            Catch ex As Exception
                Logger.WriteError(ex)
            End Try
        Else
            MetroMessageBox.Show(frmManager, "Error: The file does not exist or could not be found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

#Region "Textbox1"

    Private Sub TextBox1_ClipboardHistoryCleared() Handles TextBox1.ClipboardHistoryCleared
        GlobalClipboardHistoryUpdater.ClearForAllEditors()
    End Sub

    Private Sub TextBox1_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            frmDragContent.Show()
        End If
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        If txt_documentmap.Visible And Not My.Settings.temp_performancemode Then
            txt_documentmap.UpdateDocumentMap(TextBox1.CurrentPosition, TextBox1.Text)
        End If
    End Sub

    Private Sub TextBox1_SavePointReached(sender As Object, e As EventArgs) Handles TextBox1.SavePointReached
        If GetFileLocation() = "" Then
            UpdateTitle("Untitled")
        Else
            UpdateTitle(System.IO.Path.GetFileName(GetFileLocation))
        End If
    End Sub

    Private Sub TextBox1_SavePointLeft(sender As Object, e As EventArgs) Handles TextBox1.SavePointLeft
        If GetFileLocation() = "" Then
            UpdateTitle("Untitled*")
        Else
            UpdateTitle(System.IO.Path.GetFileName(GetFileLocation) & "*")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If txt_documentmap.Visible And Not My.Settings.temp_performancemode Then
            txt_documentmap.UpdateDocumentMap(TextBox1.CurrentPosition, TextBox1.Text)
        End If
        If frmManager.livebrowser IsNot Nothing Then
            If frmManager.livebrowser.Visible Then
                If CType(frmManager.livebrowser.GetEditor, Tab_CodeEditor) Is Me Then
                    frmManager.livebrowser.UpdateHTML()
                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_UpdateUI(sender As Object, e As UpdateUIEventArgs) Handles TextBox1.UpdateUI
        UpdateInfoTab()
        'If TextBox1.SelectedText <> "" Then
        '    TextBox1.ShowCallTip(TextBox1.CurrentPosition, "Length: " & TextBox1.SelectedText.Length & "|Words: " & CountWords(TextBox1.SelectedText))
        'End If
    End Sub

    Private Sub TextBox1_MouseEnter(sender As Object, e As EventArgs) Handles TextBox1.MouseEnter
        If My.Settings.set_hoveroverinfopaneltoopen And infopanel_pinup = False Then
            HideInfoPanel()
        End If
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        cureditor = 1
    End Sub

    Private Sub TextBox1_TextAddedToClipboardHistory(AddedText As String) Handles TextBox1.TextAddedToClipboardHistory
        GlobalClipboardHistoryUpdater.AddToAllEditors(AddedText)
    End Sub

#End Region

#Region "Textbox2"

    Private Sub TextBox2_ClipboardHistoryCleared() Handles TextBox2.ClipboardHistoryCleared
        GlobalClipboardHistoryUpdater.ClearForAllEditors()
    End Sub

    Private Sub TextBox2_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            frmDragContent.Show()
        End If
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        If txt_documentmap.Visible And Not My.Settings.temp_performancemode Then
            txt_documentmap.UpdateDocumentMap(TextBox2.CurrentPosition, TextBox2.Text)
        End If
    End Sub

    Private Sub TextBox2_SavePointReached(sender As Object, e As EventArgs) Handles TextBox2.SavePointReached
        If GetFileLocation() = "" Then
            UpdateTitle("Untitled")
        Else
            UpdateTitle(System.IO.Path.GetFileName(GetFileLocation))
        End If
    End Sub

    Private Sub TextBox2_SavePointLeft(sender As Object, e As EventArgs) Handles TextBox2.SavePointLeft
        If GetFileLocation() = "" Then
            UpdateTitle("Untitled*")
        Else
            UpdateTitle(System.IO.Path.GetFileName(GetFileLocation) & "*")
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If txt_documentmap.Visible And Not My.Settings.temp_performancemode Then
            txt_documentmap.UpdateDocumentMap(TextBox2.CurrentPosition, TextBox2.Text)
        End If
    End Sub

    Private Sub TextBox2_UpdateUI(sender As Object, e As UpdateUIEventArgs) Handles TextBox2.UpdateUI
        UpdateInfoTab()
        'If TextBox2.SelectedText <> "" Then
        '    TextBox2.ShowCallTip(TextBox2.CurrentPosition, "Length: " & TextBox2.SelectedText.Length & "|Words: " & CountWords(TextBox2.SelectedText))
        'End If
    End Sub

    Private Sub TextBox2_MouseEnter(sender As Object, e As EventArgs) Handles TextBox2.MouseEnter
        If My.Settings.set_hoveroverinfopaneltoopen And infopanel_pinup = False Then
            HideInfoPanel()
        End If
    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        cureditor = 2
    End Sub

    Private Sub TextBox2_TextAddedToClipboardHistory(AddedText As String) Handles TextBox2.TextAddedToClipboardHistory
        GlobalClipboardHistoryUpdater.AddToAllEditors(AddedText)
    End Sub

#End Region

#Region "Document Map"

#Region "Context Menu Strip"

#Region "Zoom"

    Private Sub NormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalToolStripMenuItem.Click
        txt_documentmap.Zoom = -10
        NormalToolStripMenuItem.Checked = True
        LargeToolStripMenuItem.Checked = False
        ExtraLargeToolStripMenuItem.Checked = False
    End Sub

    Private Sub LargeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LargeToolStripMenuItem.Click
        txt_documentmap.Zoom = -7
        NormalToolStripMenuItem.Checked = False
        LargeToolStripMenuItem.Checked = True
        ExtraLargeToolStripMenuItem.Checked = False
    End Sub

    Private Sub ExtraLargeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtraLargeToolStripMenuItem.Click
        txt_documentmap.Zoom = -4
        NormalToolStripMenuItem.Checked = False
        LargeToolStripMenuItem.Checked = False
        ExtraLargeToolStripMenuItem.Checked = True
    End Sub

#End Region

    Private Sub CollapseDocumentMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CollapseDocumentMapToolStripMenuItem.Click
        HideDocumentMap()
    End Sub

    Private Sub RefreshToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem2.Click
        txt_documentmap.IsReadOnly = False
        txt_documentmap.Text = TextBox1.Text
        txt_documentmap.Language = TextBox1.Language
        txt_documentmap.IsReadOnly = True
    End Sub

#End Region

    Private Sub txt_documentmap_Click(sender As Object, e As EventArgs) Handles txt_documentmap.Click
        GetCurrentEditor().GotoLine(txt_documentmap.CurrentLine)
        txt_documentmap.UpdateDocumentMap(GetCurrentEditor().CurrentPosition, GetCurrentEditor().Text)
        GetCurrentEditor().Focus()
    End Sub

#End Region

#Region "Context Menustrip"

#Region "Quick Paste"
    Private Sub Set1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set1ToolStripMenuItem.Click
        My.Settings.set_quickpaste(0) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set2ToolStripMenuItem.Click
        My.Settings.set_quickpaste(1) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set3ToolStripMenuItem.Click
        My.Settings.set_quickpaste(2) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set4ToolStripMenuItem.Click
        My.Settings.set_quickpaste(3) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set5ToolStripMenuItem.Click
        My.Settings.set_quickpaste(4) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set6ToolStripMenuItem.Click
        My.Settings.set_quickpaste(5) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set7ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set7ToolStripMenuItem.Click
        My.Settings.set_quickpaste(6) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set8ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set8ToolStripMenuItem.Click
        My.Settings.set_quickpaste(7) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set9ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set9ToolStripMenuItem.Click
        My.Settings.set_quickpaste(8) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set10ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set10ToolStripMenuItem.Click
        My.Settings.set_quickpaste(9) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set11ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set11ToolStripMenuItem.Click
        My.Settings.set_quickpaste(10) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set12ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set12ToolStripMenuItem.Click
        My.Settings.set_quickpaste(11) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set13ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set13ToolStripMenuItem.Click
        My.Settings.set_quickpaste(12) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set14ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set14ToolStripMenuItem.Click
        My.Settings.set_quickpaste(13) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set15ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set15ToolStripMenuItem.Click
        My.Settings.set_quickpaste(14) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set16ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set16ToolStripMenuItem.Click
        My.Settings.set_quickpaste(15) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set17ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set17ToolStripMenuItem.Click
        My.Settings.set_quickpaste(16) = GetCurrentEditor().SelectedText
    End Sub

    Private Sub Set18ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Set18ToolStripMenuItem.Click
        My.Settings.set_quickpaste(17) = GetCurrentEditor().SelectedText
    End Sub
#End Region

#Region "Universal Search"

    Private Sub SearchOpenDocumentsForSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchOpenDocumentsForSelectionToolStripMenuItem.Click
        Tabs.AddUniversalSearch(GetCurrentEditor().SelectedText, Tabs.UniversalSearchType.OpenDocuments)
    End Sub

    Private Sub SearchProjectForSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchProjectForSelectionToolStripMenuItem.Click
        If frmManager.GetPType = frmManager.ProjType.Project Then
            Tabs.AddUniversalSearch(GetCurrentEditor().SelectedText, Tabs.UniversalSearchType.ProjectDocuments)
        Else
            MetroMessageBox.Show(frmManager, "Error: No project is currently open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

#Region "Snippet List"

    Private Sub AddSelectionToSnippetListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddSelectionToSnippetListToolStripMenuItem.Click
        My.Settings.set_snippetlist.Add(GetCurrentEditor().SelectedText)
        MetroMessageBox.Show(frmManager, "The selection was added to the Snippet List!", "Snippet List", MessageBoxButtons.OK, MessageBoxIcon.Information)
        My.Settings.Save()
    End Sub

    Private Sub ViewSnippetListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSnippetListToolStripMenuItem.Click
        Dim bb As List(Of String) = My.Settings.set_snippetlist.Cast(Of String)().ToList()
        GetCurrentEditor().ShowSnippetList(bb)
    End Sub

#End Region

#Region "URL"

    Private Sub SearchSelectionOnWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchSelectionOnWebToolStripMenuItem.Click
        Try
            Dim s As String = GetCurrentEditor().SelectedText
            'System.Diagnostics.Process.Start("https://www.google.com/search?q=" & s)
            Tabs.AddWebBrowser("https://www.google.com/search?q=" & s)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            MetroMessageBox.Show(frmManager, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PreviewSelectedURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewSelectedURLToolStripMenuItem.Click
        frmManager.PreviewURLToolStripMenuItem.PerformClick()
    End Sub

    Private Sub CheckURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckURLToolStripMenuItem.Click
        frmManager.CheckURLToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Spelling"

    Private Sub SpellingSuggestionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpellingSuggestionsToolStripMenuItem.Click
        frmManager.SpellingSuggestionsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub CheckIfWordIsSpelledCorrectlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckIfWordIsSpelledCorrectlyToolStripMenuItem.Click
        frmManager.CheckIfWordIsSpelledCorrectlyToolStripMenuItem1.PerformClick()
    End Sub

#End Region

#Region "Add Bookmark"

    Private Sub AtSpecificLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtSpecificLineToolStripMenuItem.Click
        AddBookmarkAtSpecificLine()
    End Sub

    Private Sub AtCurrentLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtCurrentLineToolStripMenuItem.Click
        AddBookmarkAtCurrentLine()
    End Sub

#End Region

#Region "Split View"

    Private Sub EnabledToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnabledToolStripMenuItem.Click
        If SplitContainer_Editors.Panel2Collapsed Then
            EnableSplitView()
        Else
            DisableSplitView()
        End If
    End Sub

    Private Sub HorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HorizontalToolStripMenuItem.Click
        SetSplitViewOrientationHorizontal()
    End Sub

    Private Sub VerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerticalToolStripMenuItem.Click
        SetSplitViewOrientationVertical()
    End Sub

#End Region

    Private Sub DocumentMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentMapToolStripMenuItem.Click
        If IsDocumentMapVisible() Then
            HideDocumentMap()
        Else
            ShowDocumentMap()
        End If
    End Sub

    Private Sub UndoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem1.Click
        GetCurrentEditor().ExecuteCommand(Command.Undo)
    End Sub

    Private Sub RedoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem1.Click
        GetCurrentEditor().ExecuteCommand(Command.Redo)
    End Sub

    Private Sub CutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem1.Click
        GetCurrentEditor().Cut()
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem1.Click
        GetCurrentEditor().Copy()
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem1.Click
        GetCurrentEditor().Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        GetCurrentEditor().SelectAll()
    End Sub

    Private Sub ClearAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem1.Click
        GetCurrentEditor().ClearAll()
    End Sub

    Private Sub GotoLineToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GotoLineToolStripMenuItem1.Click
        GetCurrentEditor().ShowGoto()
    End Sub

    Private Sub FindReplaceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FindReplaceToolStripMenuItem1.Click
        GetCurrentEditor().ShowFindReplace()
    End Sub

#End Region

#Region "Tab_CodeEditor"

    Private Sub Tab_CodeEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.Text.EndsWith("*") And e.CloseReason <> CloseReason.MdiFormClosing Then
            If MetroMessageBox.Show(frmManager, "You have unsaved changes. Are you sure you want to close this document without saving?", "Editor '" & GetFileName() & "' - Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
        If e.Cancel = False Then
            AddFileToRecentlyClosed()
        End If
    End Sub

    Private Sub Tab_Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()
        InitializeCodeEditor()
        Me.ResumeLayout()
    End Sub

#End Region

#Region "Info Panel"

#Region "Output"

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        txt_Output.Copy()
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        txt_Output.SelectAll()
        txt_Output.Copy()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        txt_Output.Clear()
    End Sub

#End Region

#Region "Errors"

    Private Sub CopyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem2.Click
        txt_Errors.Copy()
    End Sub

    Private Sub CopyAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem1.Click
        txt_Errors.SelectAll()
        txt_Errors.Copy()
    End Sub

    Private Sub ClearToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem1.Click
        txt_Errors.Clear()
    End Sub

#End Region

#Region "Tasks"

    Private Sub ListBox_Tasks_KeyDown(sender As Object, e As KeyEventArgs) Handles ListBox_Tasks.KeyDown
        If ListBox_Tasks.Items.Count > 0 And ListBox_Tasks.SelectedIndex >= 0 Then
            If e.KeyCode = Keys.Delete Then
                My.Settings.set_tasklisttodo.Remove(ListBox_Tasks.SelectedItem)
                RefreshTasks()
            End If
        End If
    End Sub

    Private Sub MarkTaskAsCompleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkTaskAsCompleteToolStripMenuItem.Click
        Try
            My.Settings.set_tasklisttodo.Remove(ListBox_Tasks.SelectedItem)
            My.Settings.set_tasklistcomplete.Add(ListBox_Tasks.SelectedItem)
            RefreshTasks()
        Catch
        End Try
    End Sub

    Private Sub CopyTaskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyTaskToolStripMenuItem.Click
        Try
            My.Computer.Clipboard.SetText(ListBox_Tasks.SelectedItem)
            MetroFramework.MetroMessageBox.Show(frmManager, "Task Copied to Clipboard!", "Copy Task", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch
        End Try
    End Sub

    Private Sub AddTaskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTaskToolStripMenuItem.Click
        Dim toadd As String = InputBox("Please enter a new task.", "New Task", "")
        If toadd = "" Then
            'do nothing
        Else
            My.Settings.set_tasklisttodo.Add(toadd)
            RefreshTasks()
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshTasks()
    End Sub

    Private Sub RemoveTaskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveTaskToolStripMenuItem.Click
        If ListBox_Tasks.Items.Count > 0 And ListBox_Tasks.SelectedIndex >= 0 Then
            My.Settings.set_tasklisttodo.Remove(ListBox_Tasks.SelectedItem)
            RefreshTasks()
        End If
    End Sub

#End Region

#Region "Quick Settings"

    Private Sub LoadQuickSettings()
        check_qs_displayeol.Checked = My.Settings.set_eolvisible
        check_qs_highlightcurrentline.Checked = My.Settings.set_highlightselectedline
        check_qs_highlightmatchingbraces.Checked = My.Settings.set_highlightmatchingbraceswhenselected
        check_qs_highlightmatchingselection.Checked = My.Settings.set_highlightmatchingselection
        check_qs_intellisense.Checked = My.Settings.set_autocomplete_enabled
        check_qs_smartcompletion.Checked = My.Settings.set_usesmartcompletion
        check_qs_smartindentation.Checked = My.Settings.set_usesmartindentation
        check_qs_indentationguides.Checked = My.Settings.set_showindentationguides
    End Sub

    Private Sub check_qs_displayeol_CheckedChanged(sender As Object, e As EventArgs) Handles check_qs_displayeol.CheckedChanged
        GetCurrentEditor().ViewEol = check_qs_displayeol.Checked
        TextBox2.ViewEol = check_qs_displayeol.Checked
    End Sub

    Private Sub check_qs_highlightcurrentline_CheckedChanged(sender As Object, e As EventArgs) Handles check_qs_highlightcurrentline.CheckedChanged
        GetCurrentEditor().HighlightCurrentLine = check_qs_highlightcurrentline.Checked
        TextBox2.HighlightCurrentLine = check_qs_highlightcurrentline.Checked
    End Sub

    Private Sub check_qs_highlightmatchingbraces_CheckedChanged(sender As Object, e As EventArgs) Handles check_qs_highlightmatchingbraces.CheckedChanged
        GetCurrentEditor().MatchBraces = check_qs_highlightmatchingbraces.Checked
        TextBox2.MatchBraces = check_qs_highlightmatchingbraces.Checked
    End Sub

    Private Sub check_qs_highlightmatchingselection_CheckedChanged(sender As Object, e As EventArgs) Handles check_qs_highlightmatchingselection.CheckedChanged
        GetCurrentEditor().HighlightMatchingSelection = check_qs_highlightmatchingselection.Checked
        TextBox2.HighlightMatchingSelection = check_qs_highlightmatchingselection.Checked
    End Sub

    Private Sub check_qs_intellisense_CheckedChanged(sender As Object, e As EventArgs) Handles check_qs_intellisense.CheckedChanged
        GetCurrentEditor().AutoComplete = check_qs_intellisense.Checked
        TextBox2.AutoComplete = check_qs_intellisense.Checked
    End Sub

    Private Sub check_qs_smartcompletion_CheckedChanged(sender As Object, e As EventArgs) Handles check_qs_smartcompletion.CheckedChanged
        GetCurrentEditor().SmartCompletion = check_qs_smartcompletion.Checked
        TextBox2.SmartCompletion = check_qs_smartcompletion.Checked
    End Sub

    Private Sub check_qs_smartindentation_CheckedChanged(sender As Object, e As EventArgs) Handles check_qs_smartindentation.CheckedChanged
        GetCurrentEditor().SmartIndentation = check_qs_smartindentation.Checked
        TextBox2.SmartIndentation = check_qs_smartindentation.Checked
    End Sub

    Private Sub check_qs_indentationguides_CheckedChanged(sender As Object, e As EventArgs) Handles check_qs_indentationguides.CheckedChanged
        GetCurrentEditor().IndentationGuides = check_qs_indentationguides.Checked
        TextBox2.IndentationGuides = check_qs_indentationguides.Checked
    End Sub

#End Region

#Region "Info"

    Private Sub CopyToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem3.Click
        txt_info.Copy()
    End Sub

    Private Sub CopyAllToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem2.Click
        txt_info.SelectAll()
        txt_info.Copy()
    End Sub

    Private Sub RefreshToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem1.Click
        UpdateInfoTab()
    End Sub

#End Region

#Region "Notes"

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        txt_notes.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem4.Click
        txt_notes.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txt_notes.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        txt_notes.SelectAll()
    End Sub

    Private Sub ClearToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem2.Click
        txt_notes.Clear()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim newb As New FontDialog
        newb.Font = txt_notes.Font
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_notes.Font = newb.Font
        End If
    End Sub

    Private Sub BackcolorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackcolorToolStripMenuItem.Click
        Dim newb As New ColorDialog
        newb.Color = txt_notes.BackColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_notes.BackColor = newb.Color
        End If
    End Sub

    Private Sub ForecolorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForecolorToolStripMenuItem.Click
        Dim newb As New ColorDialog
        newb.Color = txt_notes.ForeColor
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_notes.ForeColor = newb.Color
        End If
    End Sub

    Private Sub OpenInNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInNotepadToolStripMenuItem.Click
        Tabs.AddNotepad(txt_notes.Text)
    End Sub

#End Region

#Region "FTP"

    Private Sub T_UploadFTP()
        Dim myFtp As New BN.FTP.FTPclient(txt_ftphostname.Text, txt_ftpusername.Text, txt_ftpuserpass.Text)
        myFtp.Upload(GetFileLocation(), txt_ftpfilepath.Text)
        If My.Settings.set_ftppathhistory.Contains(txt_ftpfilepath.Text) = False Then
            My.Settings.set_ftppathhistory.Add(txt_ftpfilepath.Text)
        End If
        frmManager.ShowStudioAlert("Uploaded document '" & GetFileName() & "' to FTP.", 2000)
    End Sub

    Private Sub btn_ftpupload_Click(sender As Object, e As EventArgs) Handles btn_ftpupload.Click
        If FTPFieldsAreValid() Then
            Try
                ThreadPool.QueueUserWorkItem(AddressOf T_UploadFTP)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(frmManager, "Unable to upload the file. Please check if the location is correct or if the user details are correct.", "FTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MetroMessageBox.Show(frmManager, "Please make sure the FTP details are filled out properly.", "FTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub check_showpassword_CheckedChanged(sender As Object, e As EventArgs) Handles check_showpassword.CheckedChanged
        If check_showpassword.Checked = True Then
            txt_ftpuserpass.PasswordChar = ""
        Else
            txt_ftpuserpass.PasswordChar = "•"
        End If
    End Sub

    Private Sub T_DownloadFTP()
        Dim myFtp As New BN.FTP.FTPclient(txt_ftphostname.Text, txt_ftpusername.Text, txt_ftpuserpass.Text)
        myFtp.Download(txt_ftpfilepath.Text, GetFileLocation(), True)
        GetCurrentEditor().Text = My.Computer.FileSystem.ReadAllText(GetFileLocation())
        If My.Settings.set_ftppathhistory.Contains(txt_ftpfilepath.Text) = False Then
            My.Settings.set_ftppathhistory.Add(txt_ftpfilepath.Text)
        End If
        frmManager.ShowStudioAlert("Downloaded document '" & Path.GetFileName(txt_ftpfilepath.Text) & "' from FTP.", 2000)
    End Sub

    Private Sub btn_ftpdownload_Click(sender As Object, e As EventArgs) Handles btn_ftpdownload.Click
        If FTPFieldsAreValid() Then
            Try
                ThreadPool.QueueUserWorkItem(AddressOf T_DownloadFTP)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(frmManager, "Unable to download the file. Please check if the location is correct or if the user details are correct.", "FTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            MetroMessageBox.Show(frmManager, "Please make sure the FTP details are filled out properly.", "FTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

    Private Sub Label5_MouseHover(sender As Object, e As EventArgs) Handles Label5.MouseHover
        If Panel_Bottom.Height <= 16 And infopanel_pinup = False Then
            ShowInfoPanel(False)
        End If
    End Sub

    Private Sub Panel_BottomTitleBar_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Panel_BottomTitleBar.MouseDoubleClick
        ToggleInfoPanel()
    End Sub

    Private Sub Panel_BottomTitleBar_MouseHover(sender As Object, e As EventArgs) Handles Panel_BottomTitleBar.MouseHover
        If Panel_Bottom.Height <= 16 And infopanel_pinup = False Then
            ShowInfoPanel(False)
        End If
    End Sub

    Private Sub Btn_HideShowOutput_MouseClick(sender As Object, e As MouseEventArgs) Handles Btn_HideShowOutput.MouseClick
        ToggleInfoPanel()
    End Sub


#End Region

#Region "Keyboard Shortcut Buttons"

    Private Sub UploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadToolStripMenuItem.Click
        btn_ftpupload.PerformClick()
    End Sub

    Private Sub DownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem.Click
        btn_ftpdownload.PerformClick()
    End Sub

    Private Sub LoadSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSettingsToolStripMenuItem.Click
        LoadSettings()
    End Sub

    Private Sub FirstVisibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirstVisibleToolStripMenuItem.Click
        GetCurrentEditor().GotoLine(GetCurrentEditor().GetFirstVisibleLine)
    End Sub

    Private Sub FirstToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirstToolStripMenuItem.Click
        GetCurrentEditor().GotoLineNotArray(1)
    End Sub

    Private Sub LastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LastToolStripMenuItem.Click
        GetCurrentEditor().GotoLine(GetCurrentEditor().GetTotalLines())
    End Sub

    Private Sub DeleteLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteLineToolStripMenuItem.Click
        GetCurrentEditor().ExecuteCommand(Command.LineDelete)
    End Sub

#Region "QuickPaste"

    Private Sub QP1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP1ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(0))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP2ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(1))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP3ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(2))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP4ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(3))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP5ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(4))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP6ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(5))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP7ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP7ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(6))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP8ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP8ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(7))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP9ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP9ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(8))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP10ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP10ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(9))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP11ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP11ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(10))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP12ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP12ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(11))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP13ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP13ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(12))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP14ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP14ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(13))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP15ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP15ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(14))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP16ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP16ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(15))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP17ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP17ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(16))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

    Private Sub QP18ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QP18ToolStripMenuItem.Click
        Try
            Dim b As Integer = GetCurrentEditor().CurrentPosition
            GetCurrentEditor().InsertText(My.Settings.set_quickpaste(17))
            GetCurrentEditor().CurrentPosition = b
        Catch
        End Try
    End Sub

#End Region

#End Region

End Class