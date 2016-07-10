Imports System.Threading
Imports MetroFramework
Imports System.IO
Imports System.Net
Imports System.Drawing.Text
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports WeifenLuo.WinFormsUI.Docking
Imports BNUpdate
Imports System.Reflection
Imports ScintillaNET
Imports XDev.Editor.Language
Imports System.Drawing.Imaging

Friend Class frmManager

#Region "Variables"

    Dim ptype As ProjType = ProjType.File
    Dim args() As String = Environment.GetCommandLineArgs
    Dim filefilter As String = "All Files (*.*)|*.*|Plain Text File (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf|Action Script File (*.as)|*.as|Ada file (*.ada;*.a;*.ads;*.adb)|*.ada;*.a;*.ads;*.adb|Assembly Language File (*.asm;*.s;*.S)|*.asm;*.s;*.S|ASP Script (*.asp)|*.asp|Unix Script (*.sh)|*.sh|Batch File (*.bat;*.cmd;*.nt)|*.bat;*.cmd;*.nt|C File (*.c)|*.c|COBOL File (*.cbl)|*.cbl|C++ File (*.cpp;*.cc;*.cxx;*.cp;*.c++;*.hpp;*.hxx)|*.cpp;*.cc;*.cxx;*.cp;*.c++;*.hpp;*.hxx|C# File (*.cs)|*.cs|CSS File (*.css)|*.css|D File (*.d)|*.d|Fortran File (*.f;*.f90;*.f95;*.f03;*.for;*.F;*.F90;*.f2k)|*.f;*.f90;*.f95;*.f03;*.for;*.F;*.F90;*.f2k|HTML File (*.html;*.htm;*.xhtml;*.jhtml;*.shtml;*.shtm;*.hta)|*.html;*.htm;*.xhtml;*.jhtml;*.shtml;*.shtm;*.hta|Java File (*.java;*.jsp;*.jspx)|*.java;*.jsp;*.jspx|JavaScript File (*.js)|*.js|LISP File (*.lsp;*.lisp;*.cl;*.el)|*.lsp;*.lisp;*.cl;*.el|Lua File (*.lua)|*.lua|Markdown File (*.md;*.markdown;*.mdown;*.mkdn;*.mkd;*.mdwn;*.mdtxt;*.mdtext)|*.md;*.markdown;*.mdown;*.mkdn;*.mkd;*.mdwn;*.mdtxt;*.mdtext|NFO File (*.nfo)|*.nfo|Pascal File (*.pas;*.pp;*.pascal;*.inc)|*.pas;*.pp;*.pascal;*.inc|Perl File (*.pl;*.pm;*.plx)|*.pl;*.pm;*.plx|PHP File (*.php;*.php4;*.php3;*.phtml)|*.php;*.php4;*.php3;*.phtml|Postscript File (*.ps)|*.ps|Python File (*.py;*.pyw)|*.py;*.pyw|R File (*.r)|*.r|Ruby File (*.rb;*.rhtml;*.rbw)|*.rb;*.rhtml;*.rbw|SmallTalk File (*.st)|*.st|SQL/PostgreSQL File (*.sql)|*.sql|Visual Basic File (*.vb)|*.vb|Visual Basic Script (*.vbs)|*.vbs|XML File (*.xml;*.rss;*.svg;*.xsml;*.xsl;*.xsd;*.kml;*.wsdl;*.xlf;*.xliff)|*.xml;*.rss;*.svg;*.xsml;*.xsl;*.xsd;*.kml;*.wsdl;*.xlf;*.xliff|YAML File (*.yaml;*.yml)|*.yaml;*.yml|XDev Language File (*.xdlf)|*.xdlf|XDev Script File (*.xds)|*.xds"
    Dim tosave As New List(Of String)
    Dim toencrypt As New List(Of String)
    Private winstate As Integer = 0
    Private origsize As New Size(0, 0)
    Private origloc As New Point(0, 0)
    Public livebrowser As New pnlLiveBrowser
    Public closebecauselock As Boolean = False
    'Public TextBox1 As ScintillaNET.Scintilla = CType(DockPanel1.ActiveDocument, Tab_Editor).TextBox1
    '----------empty recycle bin----------------
    Private Declare Function SHEmptyRecycleBin Lib "shell32.dll" Alias "SHEmptyRecycleBinA" (ByVal hWnd As Int32, ByVal pszRootPath As String, ByVal dwFlags As Int32) As Int32
    Private Declare Function SHUpdateRecycleBinIcon Lib "shell32.dll" () As Int32
    Private Const SHERB_NOCONFIRMATION = &H1
    Private Const SHERB_NOPROGRESSUI = &H2
    Private Const SHERB_NOSOUND = &H4
    Private distractionfreemode As Boolean = False
    Private toolbarswerevisible As Boolean = False

#End Region

#Region "Enums"

    Enum ProjType
        File
        Project
    End Enum

#End Region

#Region "Methods"

#Region "Base64"

    Private Function ComputeHash(ByVal textToHash As String) As String
        Dim SHA1 As SHA1CryptoServiceProvider = New SHA1CryptoServiceProvider
        Dim byteValue As Byte() = System.Text.Encoding.UTF8.GetBytes(textToHash)
        Dim byteHash As Byte() = SHA1.ComputeHash(byteValue)
        SHA1.Clear()
        Return Convert.ToBase64String(byteHash)
    End Function
    Private Function To64(ByVal Name As String) As String
        Dim i As Integer
        Dim bb As Byte() = System.Text.Encoding.UTF8.GetBytes(Name)

        i = Name.Length
        Return Convert.ToBase64String(bb)
    End Function

    Private Function ToStr(ByVal Name As String) As String
        Dim i As Integer
        Dim strBytes() As Byte = System.Convert.FromBase64String(Name)
        i = Name.Length
        Return System.Text.Encoding.UTF8.GetString(strBytes)
    End Function

#End Region

#Region "SetCheckedLanguage"

    Public Sub SetCheckedLanguage(ByVal lang As EditorLanguage)
        UncheckAllLanguages()
        Select Case lang
            Case EditorLanguage.Ada
                AdaToolStripMenuItem.Checked = True
            Case EditorLanguage.Assembly
                AssemblyToolStripMenuItem.Checked = True
            Case EditorLanguage.Batch
                BatchToolStripMenuItem.Checked = True
            Case EditorLanguage.Cpp
                CToolStripMenuItem1.Checked = True
            Case EditorLanguage.Csharp
                CToolStripMenuItem.Checked = True
            Case EditorLanguage.Css
                CSSToolStripMenuItem.Checked = True
            Case EditorLanguage.Fortran
                FortranToolStripMenuItem.Checked = True
            Case EditorLanguage.Html
                HTMLToolStripMenuItem.Checked = True
            Case EditorLanguage.Java
                JavaToolStripMenuItem.Checked = True
            Case EditorLanguage.JavaScript
                JavaScriptToolStripMenuItem.Checked = True
            Case EditorLanguage.Lisp
                LispToolStripMenuItem.Checked = True
            Case EditorLanguage.Lua
                LuaToolStripMenuItem.Checked = True
            Case EditorLanguage.Markdown
                MarkdownToolStripMenuItem1.Checked = True
            Case EditorLanguage.Pascal
                PascalToolStripMenuItem.Checked = True
            Case EditorLanguage.Perl
                PerlToolStripMenuItem.Checked = True
            Case EditorLanguage.Php
                PHPToolStripMenuItem.Checked = True
            Case EditorLanguage.Psql
                PostgreSQLToolStripMenuItem.Checked = True
            Case EditorLanguage.Python
                PythonToolStripMenuItem.Checked = True
            Case EditorLanguage.Ruby
                RubyToolStripMenuItem.Checked = True
            Case EditorLanguage.SmallTalk
                SmalltalkToolStripMenuItem.Checked = True
            Case EditorLanguage.Sql
                SQLToolStripMenuItem.Checked = True
            Case EditorLanguage.VB
                VBScriptToolStripMenuItem.Checked = True
            Case EditorLanguage.Xml
                XMLToolStripMenuItem.Checked = True
            Case EditorLanguage.Yaml
                YAMLToolStripMenuItem.Checked = True
            Case EditorLanguage.CustomLanguage
                CustomToolStripMenuItem.Checked = True
            Case EditorLanguage.PlainText
                PlainTextToolStripMenuItem.Checked = True
        End Select
    End Sub

#End Region

#Region "Open/Save"

    Public Sub SaveFileAs(ByVal frm As DockContent, ByVal fileloc As String)
        If IsCodeEditor(frm) Then
            Try
                CType(frm, Tab_CodeEditor).SetFileLocation(fileloc)
                Dim objWriter As New System.IO.StreamWriter(CType(frm, Tab_CodeEditor).GetFileLocation, False)
                objWriter.Write(CType(frm, Tab_CodeEditor).GetCurrentEditor().Text)
                objWriter.Close()
                CType(frm, Tab_CodeEditor).GetCurrentEditor().Saved = True
                RecentFilesManager.AddFile(CType(frm, Tab_CodeEditor).GetFileLocation)
                AddFileToHistory(CType(frm, Tab_CodeEditor).GetFileLocation)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        ElseIf IsNotepad(frm) Then
            Try
                CType(frm, Tab_Notepad).SetFileLocation(fileloc)
                Dim objWriter As New System.IO.StreamWriter(CType(frm, Tab_Notepad).GetFileLocation, False)
                objWriter.Write(CType(frm, Tab_Notepad).TextBox1.Text)
                objWriter.Close()
                CType(frm, Tab_Notepad).SetOriginalText(CType(frm, Tab_Notepad).TextBox1.Text)
                CType(frm, Tab_Notepad).SetSaved(True)
                RecentFilesManager.AddFile(CType(frm, Tab_Notepad).GetFileLocation)
                AddFileToHistory(CType(frm, Tab_Notepad).GetFileLocation)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Public Sub SaveFile(ByVal frm As DockContent)
        If IsCodeEditor(frm) Then
            Try
                Dim objWriter As New System.IO.StreamWriter(CType(frm, Tab_CodeEditor).GetFileLocation, False)
                objWriter.Write(CType(frm, Tab_CodeEditor).GetCurrentEditor().Text)
                objWriter.Close()
                CType(frm, Tab_CodeEditor).GetCurrentEditor().Saved = True
                RecentFilesManager.AddFile(CType(frm, Tab_CodeEditor).GetFileLocation)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        ElseIf IsNotepad(frm) Then
            Try
                Dim objWriter As New System.IO.StreamWriter(CType(frm, Tab_Notepad).GetFileLocation, False)
                objWriter.Write(CType(frm, Tab_Notepad).TextBox1.Text)
                objWriter.Close()
                CType(frm, Tab_Notepad).SetOriginalText(CType(frm, Tab_Notepad).TextBox1.Text)
                CType(frm, Tab_Notepad).SetSaved(True)
                RecentFilesManager.AddFile(CType(frm, Tab_Notepad).GetFileLocation)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Public Sub OpenProject(ByVal projloc As String)
        If ptype = ProjType.Project Then
            If MetroMessageBox.Show(Me, "You cannot open another project in the same instance of the application. Would you like to open it in a new instance? Otherwise you must close the current project.", "Open Project", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim aloc As String = XDev.Path.Locator.GetAppPath() + "\XDev Studio.exe"
                System.Diagnostics.Process.Start(aloc, projloc)
            End If
        Else
            LoadProject(Path.GetDirectoryName(projloc))
        End If
    End Sub

    Public Sub OpenFile(ByVal fileloc As String)
        If My.Settings.set_openfileinselectededitor Then
            If IsCodeEditor() = False And IsNotepad(DockPanel1.ActiveDocument) = False Then
                If GetEditorByFileLocation(fileloc) IsNot Nothing Then
                    Dim b As DialogResult = MetroMessageBox.Show(Me, "It appears the document '" & Path.GetFileName(fileloc) & "' is already open in the studio. Select [Yes] to switch to the document, or select [No] to open the document in a new tab.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If b = Windows.Forms.DialogResult.Yes Then
                        GetEditorByFileLocation(fileloc).Activate()
                    ElseIf b = Windows.Forms.DialogResult.No Then
                        Tabs.AddCode(fileloc)
                        RecentFilesManager.AddFile(fileloc)
                        AddFileToHistory(fileloc)
                    End If
                Else
                    Tabs.AddCode(fileloc)
                    RecentFilesManager.AddFile(fileloc)
                    AddFileToHistory(fileloc)
                End If
            Else
                If IsCodeEditor() Then
                    If MetroMessageBox.Show(Me, "Are you sure you want to overwrite the contents of the currently selected tab with the contents of another file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetFileLocation(fileloc)
                        CType(DockPanel1.ActiveDocument, Tab_CodeEditor).LoadExtCode(My.Computer.FileSystem.ReadAllText(fileloc), LanguageEnum.ConvertExtensionToEnum(Path.GetExtension(fileloc)))
                        AddFileToHistory(fileloc)
                    End If
                ElseIf IsNotepad(DockPanel1.ActiveDocument) Then
                    If MetroMessageBox.Show(Me, "Are you sure you want to overwrite the contents of the currently selected tab with the contents of another file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).SetSaved(False)
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).SetFileLocation(fileloc)
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Text = My.Computer.FileSystem.ReadAllText(fileloc)
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).SetOriginalText(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Text)
                        AddFileToHistory(fileloc)
                    End If
                End If
            End If
        Else
            If GetEditorByFileLocation(fileloc) IsNot Nothing Then
                Dim b As DialogResult = MetroMessageBox.Show(Me, "It appears the document '" & Path.GetFileName(fileloc) & "' is already open in the studio. Select [Yes] to switch to the document, or select [No] to open the document in a new tab.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If b = Windows.Forms.DialogResult.Yes Then
                    GetEditorByFileLocation(fileloc).Activate()
                ElseIf b = Windows.Forms.DialogResult.No Then
                    Tabs.AddCode(fileloc)
                    RecentFilesManager.AddFile(fileloc)
                    AddFileToHistory(fileloc)
                End If
            Else
                Tabs.AddCode(fileloc)
                RecentFilesManager.AddFile(fileloc)
                AddFileToHistory(fileloc)
            End If
        End If
    End Sub

    Public Sub OpenFile(ByVal fileloc As String())
        If My.Settings.set_openfileinselectededitor Then
            If IsCodeEditor() = False And IsNotepad(DockPanel1.ActiveDocument) = False Then
                For Each item As String In fileloc
                    If GetEditorByFileLocation(item) IsNot Nothing Then
                        Dim b As DialogResult = MetroMessageBox.Show(Me, "It appears the document '" & Path.GetFileName(item) & "' is already open in the studio. Select [Yes] to switch to the document, or select [No] to open the document in a new tab.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        If b = Windows.Forms.DialogResult.Yes Then
                            GetEditorByFileLocation(item).Activate()
                        ElseIf b = Windows.Forms.DialogResult.No Then
                            Tabs.AddCode(item)
                            RecentFilesManager.AddFile(item)
                        End If
                    Else
                        Tabs.AddCode(item)
                        RecentFilesManager.AddFile(item)
                    End If
                    AddFileToHistory(item)
                Next
            Else
                If IsCodeEditor() Then
                    If MetroMessageBox.Show(Me, "Are you sure you want to overwrite the contents of the currently selected tab with the contents of another file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetFileLocation(fileloc(0))
                        CType(DockPanel1.ActiveDocument, Tab_CodeEditor).LoadExtCode(My.Computer.FileSystem.ReadAllText(fileloc(0)), LanguageEnum.ConvertExtensionToEnum(Path.GetExtension(fileloc(0))))
                        AddFileToHistory(fileloc(0))
                    End If
                ElseIf IsNotepad(DockPanel1.ActiveDocument) Then
                    If MetroMessageBox.Show(Me, "Are you sure you want to overwrite the contents of the currently selected tab with the contents of another file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).SetSaved(False)
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).SetFileLocation(fileloc(0))
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Text = My.Computer.FileSystem.ReadAllText(fileloc(0))
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).SetOriginalText(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Text)
                        AddFileToHistory(fileloc(0))
                    End If
                End If
            End If
        Else
            For Each item As String In fileloc
                If GetEditorByFileLocation(item) IsNot Nothing Then
                    Dim b As DialogResult = MetroMessageBox.Show(Me, "It appears the document '" & Path.GetFileName(item) & "' is already open in the studio. Select [Yes] to switch to the document, or select [No] to open the document in a new tab.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If b = Windows.Forms.DialogResult.Yes Then
                        GetEditorByFileLocation(item).Activate()
                    ElseIf b = Windows.Forms.DialogResult.No Then
                        Tabs.AddCode(item)
                        RecentFilesManager.AddFile(item)
                    End If
                Else
                    Tabs.AddCode(item)
                    RecentFilesManager.AddFile(item)
                End If
                AddFileToHistory(item)
            Next
        End If
    End Sub

#End Region

#Region "Close Tabs"
    Public Sub CloseAllTabs()
        If CheckIfAllSaved() Then
            Try
                For i As Integer = DockPanel1.Documents.Count - 1 To 0 Step -1
                    DockPanel1.Documents(i).DockHandler.Close()
                Next
            Catch
            End Try
        Else
            Dim docs(0 To DockPanel1.Documents.Count - 1) As DockContent
            For i As Integer = 0 To DockPanel1.Documents.Count - 1
                If IsCodeEditor(DockPanel1.Documents(i)) Or IsNotepad(DockPanel1.Documents(i)) Then
                    If CheckIfDocumentHasUnsavedChanges((DockPanel1.Documents(i))) Then
                        docs(i) = DockPanel1.Documents(i)
                    End If
                End If
            Next
            Dim newb As New frmSave(docs)
            Dim dlgRes As DialogResult = newb.ShowDialog()

            If dlgRes = Windows.Forms.DialogResult.Yes Then
                Dim docsToSave() As DockContent = newb.DocsToSave
                For i As Integer = 0 To docsToSave.GetUpperBound(0)
                    Dim doc As DockContent = docsToSave(i)
                    If IsCodeEditor(doc) Then
                        If CheckIfDocumentSaved(doc, False) Then
                            SaveFile(doc)
                        Else
                            Try
                                doc.Activate()
                                Dim nb As New SaveFileDialog
                                nb.Title = "Save Document"
                                nb.OverwritePrompt = True
                                nb.Filter = GetFileFilter()
                                If nb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                    SaveFileAs(doc, nb.FileName)
                                End If
                            Catch
                            End Try
                        End If
                    ElseIf IsNotepad(doc) Then
                        If CheckIfDocumentSaved(doc, False) Then
                            SaveFile(doc)
                        Else
                            Try
                                doc.Activate()
                                Dim nb As New SaveFileDialog
                                nb.Title = "Save Notepad Document"
                                nb.OverwritePrompt = True
                                nb.Filter = "All Files (*.*)|*.*|Plain Text (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf"
                                If nb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                    SaveFileAs(doc, nb.FileName)
                                End If
                            Catch
                            End Try
                        End If
                    End If
                Next

                Try
                    For i As Integer = DockPanel1.Documents.Count - 1 To 0 Step -1
                        DockPanel1.Documents(i).DockHandler.Close()
                    Next
                Catch
                End Try
            ElseIf dlgRes = Windows.Forms.DialogResult.No Then
                Try
                    For i As Integer = DockPanel1.Documents.Count - 1 To 0 Step -1
                        DockPanel1.Documents(i).DockHandler.Close()
                    Next
                Catch
                End Try
            ElseIf dlgRes = Windows.Forms.DialogResult.Cancel Then
                Try
                    For i As Integer = DockPanel1.Documents.Count - 1 To 0 Step -1
                        DockPanel1.Documents(i).DockHandler.Close()
                    Next
                Catch
                End Try
            End If
        End If
    End Sub

    Public Function GetIndexOfDocument(ByVal doc As XDockContent) As Integer
        Dim ind As Integer = 0
        For i As Integer = 0 To DockPanel1.Documents.Count - 1
            If DockPanel1.Documents(i) Is doc Then
                ind = i
                Exit For
            End If
        Next
        Return ind
    End Function

    'Public Sub CloseAllTabsToRightOfCurrent()
    '    Dim ind As Integer = GetIndexOfDocument(DockPanel1.ActiveDocument)
    '    Try
    '        For i As Integer = DockPanel1.Documents.Count - 1 To (ind + 1) Step -1
    '            DockPanel1.Documents(i).DockHandler.Close()
    '        Next
    '    Catch
    '    End Try
    'End Sub

    'Public Sub CloseAllTabsToLeftOfCurrent()
    '    Dim ind As Integer = GetIndexOfDocument(DockPanel1.ActiveDocument)
    '    Try
    '        For i As Integer = (ind - 1) To 0 Step -1
    '            DockPanel1.Documents(i).DockHandler.Close()
    '        Next
    '    Catch
    '    End Try
    'End Sub

    Public Sub CloseAllTabsExceptCurrent()
        Dim ind As Integer = GetIndexOfDocument(DockPanel1.ActiveDocument)
        Try
            For i As Integer = DockPanel1.Documents.Count - 1 To 0 Step -1
                If Not i = ind Then
                    DockPanel1.Documents(i).DockHandler.Close()
                End If
            Next
        Catch
        End Try
    End Sub

#End Region
    
    Public Sub AddFileToHistory(ByVal floc As String)
        If Not My.Settings.set_filehistory.Contains(floc) Then
            My.Settings.set_filehistory.Add(DateTime.Now.ToString & "|" & floc)
        End If
    End Sub

    Public Sub EnterDistractionFreeMode()
        distractionfreemode = True
        DistractionFreeModeToolStripMenuItem.Checked = True
        Me.ContextMenuStrip = contextmenustrip_distractionfreemode
        MetroMessageBox.Show(Me, "To exit distraction free mode right click on the bottom status bar of the studio and select 'Exit Distraction Free Mode'", "Distraction Free Mode", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '-----
        pnl_mainmenustrip.Visible = False
        Me.DisplayHeader = False
        Fullscreen()
        If pnlToolbars.Visible Then
            toolbarswerevisible = True
            pnlToolbars.Close()
        Else
            toolbarswerevisible = False
        End If
    End Sub

    Public Sub ExitDistractionFreeMode()
        distractionfreemode = False
        DistractionFreeModeToolStripMenuItem.Checked = False
        Me.ContextMenuStrip = Nothing
        '-----
        Me.DisplayHeader = True
        pnl_mainmenustrip.Visible = True
        ExitFullscreen()
        If toolbarswerevisible Then
            ToolbarsToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub ProcessArgumentsForCommands()
        For i As Integer = 0 To args.Count - 1
            Select Case args(i)
                Case "-editor"
                    Tabs.AddCode()
                Case "-notepad"
                    Tabs.AddNotepad()
                Case "-calendar"
                    Tabs.AddCalendar()
                Case "-processviewer"
                    Tabs.AddProcessViewer()
                Case "-webbrowser"
                    Tabs.AddWebBrowser()
                Case "-filedownloader"
                    Tabs.AddFileDownloader()
                Case "-differenceviewer"
                    Tabs.AddDifferenceViewer()
                Case "-codemetrics"
                    Tabs.AddCodeMetrics()
                Case "-serviceviewer"
                    Tabs.AddServiceViewer()
                Case "-rssreader"
                    Tabs.AddRSSReader()
                Case "-coderecovery"
                    Tabs.AddCodeRecovery()
                Case "-diagrammer"
                    Tabs.AddDiagrammer()
                Case "-codebank"
                    Tabs.AddCodeBank()
                Case "-mapper"
                    Tabs.AddImageMapper()
                Case "-colorpicker"
                    Dim newb As New frmColorPicker
                    newb.Show()
                Case "-imageviewer"
                    ImageViewerToolStripMenuItem.PerformClick()
                Case "-multiinstance"
                    NewInstanceToolStripMenuItem.PerformClick()
                Case "-tray"
                    NotifyIcon1.Visible = True
                    Me.Hide()
                Case "-help"
                    Tabs.AddNotepad(My.Computer.FileSystem.ReadAllText(XDev.Path.Locator.GetAppPath & "\Engine\Tools\commandhelp.txt"))
                Case "-fullscreen"
                    FullscreenToolStripMenuItem.PerformClick()
                Case "-distractionfree"
                    DistractionFreeModeToolStripMenuItem.PerformClick()
                Case "-topmost"
                    TopmostToolStripMenuItem1.PerformClick()
                Case "-width"
                    If IsNumeric(args(i + 1)) Then
                        Me.Width = args(i + 1)
                    End If
                Case "-height"
                    If IsNumeric(args(i + 1)) Then
                        Me.Height = args(i + 1)
                    End If
                Case "-xpos"
                    If IsNumeric(args(i + 1)) Then
                        Me.Location = New Point(args(i + 1), Me.Location.Y)
                    End If
                Case "-ypos"
                    If IsNumeric(args(i + 1)) Then
                        Me.Location = New Point(Me.Location.X, args(i + 1))
                    End If
            End Select
        Next
    End Sub

    Public Sub Fullscreen()
        FullscreenToolStripMenuItem.Image = My.Resources._32_exitfullscreen
        FullscreenToolStripMenuItem.Text = "Exit Fullscreen"
        origloc = Me.Location
        origsize = Me.Size
        Me.Size = SystemInformation.PrimaryMonitorSize
        Me.Location = New Point(0, 0)
    End Sub

    Public Sub ExitFullscreen()
        FullscreenToolStripMenuItem.Image = My.Resources._32_fullscreen
        FullscreenToolStripMenuItem.Text = "Fullscreen"
        Me.Size = origsize
        Me.Location = origloc
    End Sub

    Public Function AreSameImage(ByVal I1 As Image, ByVal I2 As Image) As Boolean
        Dim MS1 As New MemoryStream
        Dim MS2 As New MemoryStream
        I1.Save(MS1, ImageFormat.Bmp)
        I2.Save(MS2, ImageFormat.Bmp)
        For I As Integer = 0 To CInt(MS1.Length) - 1
            If MS1.ReadByte() <> MS2.ReadByte Then Return False
        Next
        Return True
    End Function

    Public Function CheckIfEditorIsOpenByFileLocation(ByVal fileloc As String) As Boolean
        Dim open As Boolean = False
        For Each item As DockContent In DockPanel1.Documents
            If IsCodeEditor(item) Then
                If CType(item, Tab_CodeEditor).GetFileLocation = fileloc Then
                    open = True
                    Exit For
                End If
            End If
        Next
        Return open
    End Function

    Public Function GetEditorByFileLocation(ByVal fileloc As String) As XDockContent
        Dim b As DockContent = Nothing
        For Each item As DockContent In DockPanel1.Documents
            If IsCodeEditor(item) Then
                If CType(item, Tab_CodeEditor).GetFileLocation = fileloc Then
                    b = item
                    Exit For
                End If
            End If
        Next
        Return b
    End Function

    Public Function AtLeastOneCodeEditor() As Boolean
        Dim codecount As Integer = 0
        If AtLeastOneTab() Then
            For Each item As DockContent In DockPanel1.Documents
                If IsCodeEditor(item) Then
                    codecount += 1
                End If
            Next
        End If
        Return codecount > 0
    End Function

    Public Function AtLeastOneEditor() As Boolean
        Dim codecount As Integer = 0
        If AtLeastOneTab() Then
            For Each item As DockContent In DockPanel1.Documents
                If IsCodeEditor(item) Or IsNotepad(item) Then
                    codecount += 1
                End If
            Next
        End If
        Return codecount > 0
    End Function

    Public Sub SetActiveForm(ByVal doc As WeifenLuo.WinFormsUI.Docking.DockContent)
        doc.Activate()
    End Sub

    Public Sub UpdateMenuItems()
        If GetPType() = ProjType.Project Then
            ProjectToolStripMenuItem.Enabled = True
            'SaveAllToolStripMenuItem.Enabled = True
            ProjectExplorerToolStripMenuItem.Enabled = True
            BackupProjectToolStripMenuItem.Enabled = True
            EncryptProjectToolStripMenuItem.Enabled = True
            DecryptProjectToolStripMenuItem.Enabled = True
            EditorToolStripMenuItem.Visible = True
            FileToolStripMenuItem1.Text = "File"
        Else
            ProjectToolStripMenuItem.Enabled = False
            'SaveAllToolStripMenuItem.Enabled = False
            ProjectExplorerToolStripMenuItem.Enabled = False
            BackupProjectToolStripMenuItem.Enabled = False
            EncryptProjectToolStripMenuItem.Enabled = False
            DecryptProjectToolStripMenuItem.Enabled = False

            If My.Settings.set_requirefilecreation Then
                FileToolStripMenuItem1.Text = "File"
                EditorToolStripMenuItem.Visible = True
            Else
                FileToolStripMenuItem1.Text = "Editor"
                EditorToolStripMenuItem.Visible = False
            End If

        End If
        If My.Settings.set_customlang_enabled = True Then
            CustomToolStripMenuItem.Enabled = True
        Else
            CustomToolStripMenuItem.Enabled = False
        End If

        '---------------------------
        If IsCodeEditor() Then
            SaveToolStripMenuItem.Enabled = True
            SaveAsToolStripMenuItem.Enabled = True
            SaveAllToolStripMenuItem.Enabled = True
            QuickSaveAllToolStripMenuItem.Enabled = True
            EditToolStripMenuItem.Enabled = True
            PrintToolStripMenuItem.Enabled = True
            PrintPreviewToolStripMenuItem.Enabled = True
            PageSetupToolStripMenuItem.Enabled = True
            SearchToolStripMenuItem.Enabled = True
            LinesToolStripMenuItem.Enabled = True
            IndentToolStripMenuItem.Enabled = True
            TextToolStripMenuItem.Enabled = True
            DuplicateSelectionToolStripMenuItem.Enabled = True
            RightByOneCharacterToolStripMenuItem.Enabled = True
            LeftByOneCharacterToolStripMenuItem.Enabled = True
            DownOneLineToolStripMenuItem.Enabled = True
            UpOneLineToolStripMenuItem.Enabled = True
            ToStartOfDocumentToolStripMenuItem.Enabled = True
            ToEndOfDocumentToolStripMenuItem.Enabled = True
            DownOneParagraphToolStripMenuItem.Enabled = True
            UpOneParagraphToolStripMenuItem.Enabled = True
            ToEndOfLineToolStripMenuItem.Enabled = True
            ToBeginningOfLineToolStripMenuItem.Enabled = True
            BookmarksToolStripMenuItem1.Enabled = True
            FormatToolStripMenuItem.Enabled = True
            InsertToolStripMenuItem.Enabled = True
            ExamplesToolStripMenuItem.Enabled = True
            ZoomToolStripMenuItem.Enabled = True
            SnippetListToolStripMenuItem.Enabled = True
            CalculateCodeMetricsForCurrentDocumentToolStripMenuItem.Enabled = True
            LanguageToolStripMenuItem.Enabled = True
            OpenDocumentLocationToolStripMenuItem.Enabled = True
            BackupDocumentToolStripMenuItem.Enabled = True
            EncryptDocumentToolStripMenuItem.Enabled = True
            DecryptDocumentToolStripMenuItem.Enabled = True
            MacroToolStripMenuItem.Enabled = True
            RunToolStripMenuItem3.Enabled = True
            ConvertToASCIICodeToolStripMenuItem.Enabled = True
            HTMLToolStripMenuItem3.Enabled = True
            StartDictationToolStripMenuItem.Enabled = True
            PresentationModeToolStripMenuItem.Enabled = True
            XMLToolStripMenuItem2.Enabled = True
            FormatToolStripMenuItem.Enabled = True
            GotoToolStripMenuItem1.Enabled = True
            CommentToolStripMenuItem.Enabled = True
            UncommentToolStripMenuItem.Enabled = True
            ViewDocumentInLiveBrowserToolStripMenuItem.Enabled = True
            TextToolStripMenuItem1.Enabled = True
            EditorCommandPaletteToolStripMenuItem.Enabled = True
            ReferencesToolStripMenuItem.Enabled = True
            CompileAsToolStripMenuItem.Enabled = True
            HTMLToolStripMenuItem3.Enabled = True
            XMLToolStripMenuItem2.Enabled = True
            MarkdownToolStripMenuItem.Enabled = True
            FixCToolStripMenuItem.Enabled = True
            FixVBToolStripMenuItem.Enabled = True
            ForecolorToolStripMenuItem.Enabled = False
            BackcolorToolStripMenuItem.Enabled = False
            '------------
            ToggleReadOnlyToolStripMenuItem.Checked = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).TextBox1.IsReadOnly
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation = "" Then
                CalculateCodeMetricsForCurrentDocumentToolStripMenuItem.Enabled = False
            Else
                CalculateCodeMetricsForCurrentDocumentToolStripMenuItem.Enabled = True
            End If
        ElseIf IsNotepad() Then
            SaveToolStripMenuItem.Enabled = True
            SaveAsToolStripMenuItem.Enabled = True
            SaveAllToolStripMenuItem.Enabled = True
            QuickSaveAllToolStripMenuItem.Enabled = True
            EditToolStripMenuItem.Enabled = True
            PrintToolStripMenuItem.Enabled = False
            PrintPreviewToolStripMenuItem.Enabled = False
            PageSetupToolStripMenuItem.Enabled = False
            SearchToolStripMenuItem.Enabled = False
            LinesToolStripMenuItem.Enabled = False
            IndentToolStripMenuItem.Enabled = False
            TextToolStripMenuItem.Enabled = False
            DuplicateSelectionToolStripMenuItem.Enabled = False
            RightByOneCharacterToolStripMenuItem.Enabled = False
            LeftByOneCharacterToolStripMenuItem.Enabled = False
            DownOneLineToolStripMenuItem.Enabled = False
            UpOneLineToolStripMenuItem.Enabled = False
            ToStartOfDocumentToolStripMenuItem.Enabled = False
            ToEndOfDocumentToolStripMenuItem.Enabled = False
            DownOneParagraphToolStripMenuItem.Enabled = False
            UpOneParagraphToolStripMenuItem.Enabled = False
            ToEndOfLineToolStripMenuItem.Enabled = False
            ToBeginningOfLineToolStripMenuItem.Enabled = False
            BookmarksToolStripMenuItem1.Enabled = False
            InsertToolStripMenuItem.Enabled = True
            ExamplesToolStripMenuItem.Enabled = False
            ZoomToolStripMenuItem.Enabled = False
            SnippetListToolStripMenuItem.Enabled = False
            CalculateCodeMetricsForCurrentDocumentToolStripMenuItem.Enabled = False
            LanguageToolStripMenuItem.Enabled = False
            OpenDocumentLocationToolStripMenuItem.Enabled = True
            BackupDocumentToolStripMenuItem.Enabled = True
            EncryptDocumentToolStripMenuItem.Enabled = True
            DecryptDocumentToolStripMenuItem.Enabled = True
            MacroToolStripMenuItem.Enabled = False
            RunToolStripMenuItem3.Enabled = False
            ConvertToASCIICodeToolStripMenuItem.Enabled = True
            HTMLToolStripMenuItem3.Enabled = False
            StartDictationToolStripMenuItem.Enabled = True
            PresentationModeToolStripMenuItem.Enabled = False
            XMLToolStripMenuItem2.Enabled = False
            FormatToolStripMenuItem.Enabled = True
            GotoToolStripMenuItem1.Enabled = False
            CommentToolStripMenuItem.Enabled = False
            UncommentToolStripMenuItem.Enabled = False
            ViewDocumentInLiveBrowserToolStripMenuItem.Enabled = False
            TextToolStripMenuItem1.Enabled = True
            EditorCommandPaletteToolStripMenuItem.Enabled = False
            ReferencesToolStripMenuItem.Enabled = False
            CompileAsToolStripMenuItem.Enabled = False
            HTMLToolStripMenuItem3.Enabled = False
            XMLToolStripMenuItem2.Enabled = False
            MarkdownToolStripMenuItem.Enabled = False
            FixCToolStripMenuItem.Enabled = False
            FixVBToolStripMenuItem.Enabled = False
            ForecolorToolStripMenuItem.Enabled = True
            BackcolorToolStripMenuItem.Enabled = True
            '-----------------
            ToggleReadOnlyToolStripMenuItem.Checked = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.ReadOnly
        Else
            SaveToolStripMenuItem.Enabled = False
            SaveAsToolStripMenuItem.Enabled = False
            EditToolStripMenuItem.Enabled = False
            PrintToolStripMenuItem.Enabled = False
            PrintPreviewToolStripMenuItem.Enabled = False
            PageSetupToolStripMenuItem.Enabled = False
            FormatToolStripMenuItem.Enabled = False
            InsertToolStripMenuItem.Enabled = False
            ZoomToolStripMenuItem.Enabled = False
            SnippetListToolStripMenuItem.Enabled = False
            CalculateCodeMetricsForCurrentDocumentToolStripMenuItem.Enabled = False
            LanguageToolStripMenuItem.Enabled = False
            OpenDocumentLocationToolStripMenuItem.Enabled = False
            BackupDocumentToolStripMenuItem.Enabled = False
            EncryptDocumentToolStripMenuItem.Enabled = False
            DecryptDocumentToolStripMenuItem.Enabled = False
            MacroToolStripMenuItem.Enabled = False
            RunToolStripMenuItem3.Enabled = False
            HTMLToolStripMenuItem3.Enabled = False
            StartDictationToolStripMenuItem.Enabled = False
            PresentationModeToolStripMenuItem.Enabled = False
            XMLToolStripMenuItem2.Enabled = False
            ViewDocumentInLiveBrowserToolStripMenuItem.Enabled = False
            TextToolStripMenuItem1.Enabled = False
            EditorCommandPaletteToolStripMenuItem.Enabled = False
            ReferencesToolStripMenuItem.Enabled = False
            CompileAsToolStripMenuItem.Enabled = False
            HTMLToolStripMenuItem3.Enabled = False
            XMLToolStripMenuItem2.Enabled = False
            MarkdownToolStripMenuItem.Enabled = False
            FixCToolStripMenuItem.Enabled = False
            FixVBToolStripMenuItem.Enabled = False
            '------------------
            ToggleReadOnlyToolStripMenuItem.Checked = False
        End If

        If IsLargeFileEditor() Then
            SaveAllToolStripMenuItem.Enabled = False
            QuickSaveAllToolStripMenuItem.Enabled = False
        End If

        If IsCodeEditor() Then
            SetCheckedLanguage(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).TextBox1.Language)
            ZoomLevelToolStripMenuItem.Text = "Zoom Level: " & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCompileAsWinforms Then
                ConsoleApplicationToolStripMenuItem.Checked = False
                WinFormsApplicationToolStripMenuItem.Checked = True
            Else
                ConsoleApplicationToolStripMenuItem.Checked = True
                WinFormsApplicationToolStripMenuItem.Checked = False
            End If
        ElseIf IsNotepad() Then
            SetCheckedLanguage(EditorLanguage.PlainText)
        End If

        If AtLeastOneCodeEditor() Then
            SaveSessionToolStripMenuItem.Enabled = True
        Else
            SaveSessionToolStripMenuItem.Enabled = False
        End If
        If CurrentProfile.Name = "" Then
            OpenProfileFolderToolStripMenuItem.Enabled = False
        Else
            OpenProfileFolderToolStripMenuItem.Enabled = True
        End If
        If My.Settings.set_recentlyclosedfiles.Count > 0 Then
            RecentlyClosedToolStripMenuItem.Enabled = True
        Else
            RecentlyClosedToolStripMenuItem.Enabled = False
        End If
        PerformanceModeToolStripMenuItem.Checked = My.Settings.temp_performancemode
        TopmostToolStripMenuItem1.Checked = Me.TopMost
        ExitDistractionFreeModeToolStripMenuItem.Checked = distractionfreemode
    End Sub

    Public Sub SetNotepadText(ByVal txt As String)
        pnlToolPanel.txt_notepad.Text = txt
    End Sub

    Private Sub EmptyRecycleBin()
        Try
            SHEmptyRecycleBin(Me.Handle.ToInt32, vbNullString, SHERB_NOCONFIRMATION + SHERB_NOSOUND)
            SHUpdateRecycleBinIcon()
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Public Function getUptime() As String
        Dim strResult As String = String.Empty
        strResult += Math.Round(Environment.TickCount / 86400000) & " days, "
        strResult += Math.Round(Environment.TickCount / 3600000 Mod 24) & " hours, "
        strResult += Math.Round(Environment.TickCount / 120000 Mod 60) & " minutes, "
        strResult += Math.Round(Environment.TickCount / 1000 Mod 60) & " seconds."
        Return strResult
    End Function

    Private Function defaultbrowserlocation() As String
        Try
            defaultbrowserlocation = My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\HTTP\shell\open\command", "", "Not Found")
            Dim shplit() As String = Split(defaultbrowserlocation, """")
            Return shplit(1)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            Return Nothing
        End Try
    End Function

    Public Function GetSpecificCodeEditorByFileLocation(ByVal fileloc As String) As DockContent
        Dim b As DockContent = Nothing
        Dim i As Integer = 0
        For Each item As DockContent In DockPanel1.Documents
            If IsCodeEditor(item) Then
                If CType(item, Tab_CodeEditor).GetFileLocation = fileloc Then
                    b = item
                    Exit For
                End If
            End If
        Next
        Return b
    End Function

    Public Sub UpdateVoiceStatus()
        If SpeechEngine.GetCommandRecStatus = True And SpeechEngine.GetDictationRecStatus = True Then
            voicepp_notifyicon_status.Text = "Command Recognition: Enabled | Dictation: Enabled"
            voicepp_notify_menustripitem.Text = "Command Recognition: Enabled | Dictation: Enabled"
        ElseIf SpeechEngine.GetCommandRecStatus = False And SpeechEngine.GetDictationRecStatus = False Then
            voicepp_notifyicon_status.Text = "Command Recognition: Disabled | Dictation: Disabled"
            voicepp_notify_menustripitem.Text = "Command Recognition: Disabled | Dictation: Disabled"
        ElseIf SpeechEngine.GetCommandRecStatus = True And SpeechEngine.GetDictationRecStatus = False Then
            voicepp_notifyicon_status.Text = "Command Recognition: True | Dictation: Disabled"
            voicepp_notify_menustripitem.Text = "Command Recognition: True | Dictation: Disabled"
        ElseIf SpeechEngine.GetCommandRecStatus = False And SpeechEngine.GetDictationRecStatus = True Then
            voicepp_notifyicon_status.Text = "Command Recognition: Disabled | Dictation: Enabled"
            voicepp_notify_menustripitem.Text = "Command Recognition: Disabled | Dictation: Enabled"
        End If
    End Sub

    Public Sub ShowEncryptAlert(ByVal msg As String, ByVal timeout As Integer)
        EncryptNotifyIcon.Visible = True
        EncryptNotifyIcon.ShowBalloonTip(timeout, "Encrypt++", msg, ToolTipIcon.Info)
    End Sub

    Public Sub ShowStudioAlert(ByVal msg As String, ByVal timeout As Integer)
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(timeout, "XDev Studio", msg, ToolTipIcon.Info)
    End Sub

    Public Sub ShowBackupAlert(ByVal msg As String, ByVal timeout As Integer)
        BackupNotifyIcon.Visible = True
        BackupNotifyIcon.ShowBalloonTip(timeout, "Backup++", msg, ToolTipIcon.Info)
    End Sub

    Public Function CheckIfCurrentDocumentHasUnsavedChanges() As Boolean
        Dim changes As Boolean = False
        If AtLeastOneTab() Then
            Try
                If DockPanel1.ActiveDocument.DockHandler.TabText.EndsWith("*") Then
                    changes = True
                End If
            Catch
            End Try
        End If
        Return changes
    End Function

    Public Function CheckIfDocumentHasUnsavedChanges(ByVal frm As WeifenLuo.WinFormsUI.Docking.DockContent)
        Dim changes As Boolean = False
        If IsCodeEditor(frm) Then
            If CType(frm, Tab_CodeEditor).Text.EndsWith("*") Then
                changes = True
            End If
        ElseIf IsNotepad(frm) Then
            If CType(frm, Tab_Notepad).Text.EndsWith("*") Then
                changes = True
            End If
        End If
        Return changes
    End Function

    Public Function CheckIfDocumentSaved(ByVal displayalert As Boolean) As Boolean
        Dim docsaved As Boolean = False
        If IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation = "" Then
                If displayalert Then
                    MetroMessageBox.Show(Me, "Warning: Some features require that the document be saved before using. Please save the document before using this feature.", "Unsaved Document", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                docsaved = False
            Else
                docsaved = True
            End If
        ElseIf IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation = "" Then
                If displayalert Then
                    MetroMessageBox.Show(Me, "Warning: Some features require that the document be saved before using. Please save the document before using this feature.", "Unsaved Document", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                docsaved = False
            Else
                docsaved = True
            End If
        End If
        Return docsaved
    End Function

    Public Function CheckIfDocumentSaved(ByVal frm As WeifenLuo.WinFormsUI.Docking.DockContent, ByVal displayalert As Boolean) As Boolean
        Dim docsaved As Boolean = False
        If IsNotepad(frm) Then
            If CType(frm, Tab_Notepad).GetFileLocation = "" Then
                If displayalert Then
                    MetroMessageBox.Show(Me, "Warning: Some features require that the document be saved before using. Please save the document before using this feature.", "Unsaved Document", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                docsaved = False
            Else
                docsaved = True
            End If
        ElseIf IsCodeEditor(frm) Then
            If CType(frm, Tab_CodeEditor).GetFileLocation = "" Then
                If displayalert Then
                    MetroMessageBox.Show(Me, "Warning: Some features require that the document be saved before using. Please save the document before using this feature.", "Unsaved Document", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                docsaved = False
            Else
                docsaved = True
            End If
        End If
        Return docsaved
    End Function

    Private Function IsURLValid(ByVal website As String)
        Dim valid As Boolean = False
        Try
            Dim url As New System.Uri(website)
            Dim req As System.Net.WebRequest
            req = System.Net.WebRequest.Create(url)
            Dim resp As System.Net.WebResponse
            Try
                resp = req.GetResponse()
                resp.Close()
                req = Nothing
                valid = True
            Catch ex As Exception
                req = Nothing
                valid = False
            End Try
        Catch
        End Try
        Return valid
    End Function

    Public Sub LockStudio()
        Me.Enabled = False
        NotifyIcon1.Visible = False
        Dim newb As New frmLock
        newb.ShowDialog()
    End Sub

    Public Sub UnlockStudio()
        Me.Enabled = True
        NotifyIcon1.Visible = True
    End Sub

    Public Sub SetFocus()
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Focus()
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Focus()
        End If
    End Sub

    Public Function IsFileLocked(ByVal file As String) As Boolean
        Dim stream As FileStream = Nothing
        Try
            stream = System.IO.File.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
        Catch ex As Exception
            Return True
        Finally
            If stream IsNot Nothing Then
                stream.Close()
            End If
        End Try
        Return False
    End Function

    Public Sub CloseProject()
        Dim b As List(Of FileObject) = ProjectReader.GetProjectFiles
        Dim remlist As New List(Of DockContent)
        For Each item As DockContent In DockPanel1.Documents
            If IsCodeEditor(item) Then
                For Each fo As FileObject In b
                    If CType(item, Tab_CodeEditor).GetFileLocation = fo.GetFileLocation Then
                        remlist.Add(item)
                        Exit For
                    End If
                Next
            End If
        Next
        For Each item As DockContent In remlist
            item.Close()
        Next
        My.Settings.temp_projlocation = ""
        ptype = ProjType.File
        pnlProjectExplorer.Close()
        NotifyIcon1.Text = "XDev Studio"
    End Sub

    Public Function CheckIfAllSaved() As Boolean
        Dim allsaved As Boolean = True
        For Each item As DockContent In DockPanel1.Documents
            If item.DockHandler.TabText.EndsWith("*") Then
                allsaved = False
            End If
        Next
        Return allsaved
    End Function

    Public Function GetPType() As ProjType
        Return ptype
    End Function

    Public Sub RemoveCodeEditorWithFileName(ByVal filename As String)
        For Each item As DockContent In DockPanel1.Documents
            If IsCodeEditor(item) Then
                If CType(item, Tab_CodeEditor).GetFileName = filename Then
                    item.DockHandler.Close()
                    Exit For
                End If
            End If
        Next
    End Sub

    Public Sub RemoveTab(ByVal performsavecheck As Boolean)
        If performsavecheck = True Then
            If CheckIfDocumentHasUnsavedChanges(DockPanel1.ActiveDocument) = True Then
                If MetroMessageBox.Show(Me, "You have unsaved changes. Are you sure you want to close this document without saving?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    DockPanel1.ActiveDocumentPane.CloseActiveContent()
                Else
                    'do nothing
                End If
            Else
                DockPanel1.ActiveDocumentPane.CloseActiveContent()
            End If
        Else
            DockPanel1.ActiveDocumentPane.CloseActiveContent()
        End If
    End Sub

    Public Sub LoadProject(ByVal projloc As String)
        If ptype = ProjType.Project Then
            If MetroMessageBox.Show(Me, "You cannot open another project in the same instance of the application. Would you like to open it in a new instance? Otherwise you must close the current project.", "Open Project", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim aloc As String = XDev.Path.Locator.GetAppPath() + "\XDev Studio.exe"
                System.Diagnostics.Process.Start(aloc, projloc + "\xdevproject_details.xdpf")
            End If
        Else
            ptype = ProjType.Project
            My.Settings.temp_projlocation = projloc
            Dim blist As List(Of FileObject) = ProjectReader.GetProjectFiles()
            If My.Settings.set_recentprojects.Contains(projloc) Then
            Else
                My.Settings.set_recentprojects.Add(projloc)
            End If
            pnlProjectExplorer.ShowPanel(DockPanel1, DockState.DockLeft)
            Tabs.AddCode(ProjectReader.GetProjectFiles(0).GetFileLocation)
            NotifyIcon1.Text = "XDev Studio - " & ProjectReader.GetProjectName
            Logger.Write(Logger.TypeOfLog.Studio, "Loading project '" & ProjectReader.GetProjectName & "'")
        End If

    End Sub

    Private Function CheckIfArguments() As Boolean
        If args.Count > 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetFileFilter() As String
        Return filefilter
    End Function

    Public Sub SetProjectType(ByVal typeofproj As ProjType)
        ptype = typeofproj
    End Sub

    Public Sub InitializeStudio()
        Settings.LoadSettings()
        'If My.Settings.set_allowplugins Then
        '    PluginManager.LoadPlugins()
        'Else
        '    Logger.Write(Logger.TypeOfLog.Studio, "Did not attempt to load plugins because 'Allow Plugins' is disabled in the security settings.")
        'End If
        AppManager.LoadApps()
        UpdateMenuItems()
        RecentFilesManager.UpdateRecentFilesMenu()
        LanguageCompiler.InitializeNetLanguages()
    End Sub

    Public Function AtLeastOneTab() As Boolean
        If DockPanel1.DocumentsCount < 1 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function IsCodeEditor() As Boolean
        Dim b As Boolean = False
        Try
            If AtLeastOneTab() Then
                If TypeOf DockPanel1.ActiveDocument Is Tab_CodeEditor Then
                    b = True
                Else
                    b = False
                End If
            Else
                b = False
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
        Return b
    End Function

    Public Function IsLargeFileEditor() As Boolean
        Dim b As Boolean = False
        Try
            If AtLeastOneTab() Then
                If TypeOf DockPanel1.ActiveDocument Is Tab_LargeFileEditor Then
                    b = True
                Else
                    b = False
                End If
            Else
                b = False
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
        Return b
    End Function

    Public Function IsCodeEditor(ByVal doc As WeifenLuo.WinFormsUI.Docking.DockContent)
        If TypeOf doc Is Tab_CodeEditor Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function IsNotepad() As Boolean
        Dim b As Boolean = False
        Try
            If AtLeastOneTab() Then
                If TypeOf DockPanel1.ActiveDocument Is Tab_Notepad Then
                    b = True
                Else
                    b = False
                End If
            Else
                b = False
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
        Return b
    End Function

    Public Function IsNotepad(ByVal doc As WeifenLuo.WinFormsUI.Docking.DockContent)
        If TypeOf doc Is Tab_Notepad Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub UncheckAllLanguages()
        AdaToolStripMenuItem.Checked = False
        AssemblyToolStripMenuItem.Checked = False
        BatchToolStripMenuItem.Checked = False
        CToolStripMenuItem.Checked = False
        CToolStripMenuItem1.Checked = False
        CSSToolStripMenuItem.Checked = False
        FortranToolStripMenuItem.Checked = False
        HTMLToolStripMenuItem.Checked = False
        JavaToolStripMenuItem.Checked = False
        JavaScriptToolStripMenuItem.Checked = False
        LispToolStripMenuItem.Checked = False
        LuaToolStripMenuItem.Checked = False
        MarkdownToolStripMenuItem1.Checked = False
        PascalToolStripMenuItem.Checked = False
        PerlToolStripMenuItem.Checked = False
        PHPToolStripMenuItem.Checked = False
        PostgreSQLToolStripMenuItem.Checked = False
        PythonToolStripMenuItem.Checked = False
        RubyToolStripMenuItem.Checked = False
        SmalltalkToolStripMenuItem.Checked = False
        SQLToolStripMenuItem.Checked = False
        VBScriptToolStripMenuItem.Checked = False
        XMLToolStripMenuItem.Checked = False
        YAMLToolStripMenuItem.Checked = False
        PlainTextToolStripMenuItem.Checked = False
        CustomToolStripMenuItem.Checked = False
    End Sub

#End Region

#Region "Top Panel"

#Region "MENU STRIP"

#Region "File"

    Private Sub FileToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub FileToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            FileToolStripMenuItem.ShowDropDown()
        End If
    End Sub

#Region "New"

    Private Sub NewProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProjectToolStripMenuItem.Click
        If GetPType() = ProjType.File Then
            Dim newb As New frmNewProject
            newb.ShowDialog()
        Else
            If MetroMessageBox.Show(Me, "You cannot open another project in the same instance of the application. Would you like to create it in a new instance of XDev Studio? Otherwise you must close the current project.", "New Project", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                NewInstanceToolStripMenuItem.PerformClick()
            End If
        End If
    End Sub

    Private Sub FileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem1.Click
        If ptype = ProjType.File Then
            If My.Settings.set_requirefilecreation Then
                Dim newb As New dlgNewFile
                newb.ShowDialog()
            Else
                Tabs.AddCode()
            End If
        Else
            Dim newb As New frmNewFile
            newb.ShowDialog()
        End If
    End Sub

    Private Sub EditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditorToolStripMenuItem.Click
        Tabs.AddCode()
    End Sub

#End Region

#Region "Open"

#Region "Recent Files"
    Private Sub rf0_Click(sender As Object, e As EventArgs) Handles rf0.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(0)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf1_Click(sender As Object, e As EventArgs) Handles rf1.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(1)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf2_Click(sender As Object, e As EventArgs) Handles rf2.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(2)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf3_Click(sender As Object, e As EventArgs) Handles rf3.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(3)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf4_Click(sender As Object, e As EventArgs) Handles rf4.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(4)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf5_Click(sender As Object, e As EventArgs) Handles rf5.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(5)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf6_Click(sender As Object, e As EventArgs) Handles rf6.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(6)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf7_Click(sender As Object, e As EventArgs) Handles rf7.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(7)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf8_Click(sender As Object, e As EventArgs) Handles rf8.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(8)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub rf9_Click(sender As Object, e As EventArgs) Handles rf9.Click
        Try
            Dim b As String = My.Settings.set_recentfiles(9)
            OpenFile(b)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        RecentFilesManager.ClearRecentFiles()
    End Sub

#End Region

#Region "Recently Closed"

    Private Sub RecentlyClosedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecentlyClosedToolStripMenuItem.Click
        If My.Settings.set_recentlyclosedfiles.Count > 0 Then
            Try
                Tabs.AddCode(My.Settings.set_recentlyclosedfiles(My.Settings.set_recentlyclosedfiles.Count - 1))
                My.Settings.set_recentlyclosedfiles.RemoveAt(My.Settings.set_recentlyclosedfiles.Count - 1)
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

    Private Sub QuickOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickOpenToolStripMenuItem.Click
        Dim newb As New dlgQuickOpen
        newb.ShowDialog()
    End Sub

    Private Sub OpenProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Title = "Open XDev Studio Project"
        newb.Filter = "XDev Studio Project Files (*.xdpf)|*.xdpf"
        If My.Settings.set_defaultprojlocation = "DEFAULT" Then
            newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath + "\Projects"
        Else
            newb.InitialDirectory = My.Settings.set_defaultprojlocation
        End If
        If CurrentProfile.Name <> "" Then
            newb.InitialDirectory = CurrentProfile.Folder
        End If
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            OpenProject(newb.FileName)
        End If
    End Sub

    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileToolStripMenuItem.Click
        If My.Settings.set_openfileinselectededitor And IsCodeEditor() Then
            Dim newb As New OpenFileDialog
            newb.Title = "Open File"
            newb.Filter = GetFileFilter()
            newb.Multiselect = False
            If CurrentProfile.Name <> "" Then
                newb.InitialDirectory = CurrentProfile.Folder
            End If
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim b(1) As String
                b(0) = newb.FileName
                OpenFile(b)
            End If
        Else
            Dim newb As New OpenFileDialog
            newb.Title = "Open File(s)"
            newb.Filter = GetFileFilter()
            newb.Multiselect = True
            If CurrentProfile.Name <> "" Then
                newb.InitialDirectory = CurrentProfile.Folder
            End If
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                OpenFile(newb.FileNames)
            End If
        End If
    End Sub

#End Region

#Region "Save"

    Private Sub QuickSaveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickSaveAllToolStripMenuItem.Click
        Dim i As Integer = 0
        Try
            For Each item As DockContent In DockPanel1.Documents
                If IsCodeEditor(item) Then
                    If CheckIfDocumentSaved(item, False) Then
                        Dim objWriter As New System.IO.StreamWriter(CType(item, Tab_CodeEditor).GetFileLocation, False)
                        objWriter.Write(CType(item, Tab_CodeEditor).GetCurrentEditor().Text)
                        objWriter.Close()
                        CType(item, Tab_CodeEditor).GetCurrentEditor().Saved = True
                        'RecentFilesManager.AddFile(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
                        If My.Settings.set_backupwhensaving Then
                            BackupManager.BackupFile(CType(item, Tab_CodeEditor).GetFileLocation)
                        End If
                    End If
                ElseIf IsNotepad(item) Then
                    If CheckIfDocumentSaved(item, False) Then
                        Dim objWriter As New System.IO.StreamWriter(CType(item, Tab_Notepad).GetFileLocation, False)
                        objWriter.Write(CType(item, Tab_Notepad).TextBox1.Text)
                        objWriter.Close()
                        CType(item, Tab_Notepad).SetOriginalText(CType(item, Tab_Notepad).TextBox1.Text)
                        CType(item, Tab_Notepad).SetSaved(True)
                        'RecentFilesManager.AddFile(CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation)
                        If My.Settings.set_backupwhensaving Then
                            BackupManager.BackupFile(CType(item, Tab_Notepad).GetFileLocation)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub SaveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAllToolStripMenuItem.Click
        Dim docs(0 To DockPanel1.Documents.Count - 1) As DockContent
        For i As Integer = 0 To DockPanel1.Documents.Count - 1
            If IsCodeEditor(DockPanel1.Documents(i)) Or IsNotepad(DockPanel1.Documents(i)) Then
                If CheckIfDocumentHasUnsavedChanges((DockPanel1.Documents(i))) Then
                    docs(i) = DockPanel1.Documents(i)
                End If
            End If
        Next
        Dim newb As New frmSave(docs)
        Dim dlgRes As DialogResult = newb.ShowDialog()

        If dlgRes = Windows.Forms.DialogResult.Yes Then
            Dim docsToSave() As DockContent = newb.DocsToSave
            For i As Integer = 0 To docsToSave.GetUpperBound(0)
                Dim doc As DockContent = docsToSave(i)
                If IsCodeEditor(doc) Then
                    If CheckIfDocumentSaved(doc, False) Then
                        SaveFile(doc)
                    Else
                        Try
                            doc.Activate()
                            Dim nb As New SaveFileDialog
                            nb.Title = "Save Document"
                            nb.OverwritePrompt = True
                            nb.Filter = GetFileFilter()
                            If CurrentProfile.Name <> "" Then
                                nb.InitialDirectory = CurrentProfile.Folder
                            End If
                            If nb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                SaveFileAs(doc, nb.FileName)
                            End If
                        Catch
                        End Try
                    End If
                ElseIf IsNotepad(doc) Then
                    If CheckIfDocumentSaved(doc, False) Then
                        SaveFile(doc)
                    Else
                        Try
                            doc.Activate()
                            Dim nb As New SaveFileDialog
                            nb.Title = "Save Notepad Document"
                            nb.OverwritePrompt = True
                            nb.Filter = "All Files (*.*)|*.*|Plain Text (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf"
                            If CurrentProfile.Name <> "" Then
                                nb.InitialDirectory = CurrentProfile.Folder
                            End If
                            If nb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                SaveFileAs(doc, nb.FileName)
                            End If
                        Catch
                        End Try
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If IsNotepad() Then
            Try
                Dim newb As New SaveFileDialog
                newb.Title = "Save Notepad Document"
                newb.OverwritePrompt = True
                newb.Filter = "All Files (*.*)|*.*|Plain Text (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf"
                If CurrentProfile.Name <> "" Then
                    newb.InitialDirectory = CurrentProfile.Folder
                End If
                If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    SaveFileAs(DockPanel1.ActiveDocument, newb.FileName)
                End If
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        ElseIf IsCodeEditor() Then
            Try
                Dim newb As New SaveFileDialog
                newb.Title = "Save Document"
                newb.OverwritePrompt = True
                newb.Filter = GetFileFilter()
                If CurrentProfile.Name <> "" Then
                    newb.InitialDirectory = CurrentProfile.Folder
                End If
                If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    SaveFileAs(DockPanel1.ActiveDocument, newb.FileName)
                End If
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        'If ptype = ProjType.File Then
        If IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation = "" Then
                SaveAsToolStripMenuItem.PerformClick()
            Else
                SaveFile(DockPanel1.ActiveDocument)
            End If
        ElseIf IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation = "" Then
                SaveAsToolStripMenuItem.PerformClick()
            Else
                SaveFile(DockPanel1.ActiveDocument)
            End If
        End If
        If My.Settings.set_backupwhensaving Then
            BackupDocumentToolStripMenuItem.PerformClick()
        End If
    End Sub

#End Region

#Region "Session"

    Private Sub OpenSessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSessionToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Filter = "XDev Session File (*.xdsf)|*.xdsf"
        newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath + "\Sessions"
        If CurrentProfile.Name <> "" Then
            newb.InitialDirectory = CurrentProfile.Folder
        End If
        newb.Title = "Open Session"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim glist As New List(Of String)
            glist = SessionManager.ReadSessionFile(newb.FileName)
            For Each item As String In glist
                Tabs.AddCode(item)
            Next
        End If
    End Sub

    Private Sub SaveSessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSessionToolStripMenuItem.Click
        Dim newb As New SaveFileDialog
        newb.Filter = "XDev Session File (*.xdsf)|*.xdsf"
        newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath + "\Sessions"
        If CurrentProfile.Name <> "" Then
            newb.InitialDirectory = CurrentProfile.Folder
        End If
        newb.Title = "Save Session"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim seslist As New List(Of String)
            Dim i As Integer = 0
            For Each item As DockContent In DockPanel1.Documents
                If IsCodeEditor(item) Then
                    If CheckIfDocumentSaved(item, True) Then
                        seslist.Add(CType(item, Tab_CodeEditor).GetFileLocation)
                    End If
                End If
            Next
            If seslist.Count > 0 Then
                SessionManager.SaveSessionFile(newb.FileName, seslist)
                MetroMessageBox.Show(Me, "Saved session!", "Saved Session", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MetroMessageBox.Show(Me, "There were no code editor tabs to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

#End Region

#Region "Document"

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                If MetroMessageBox.Show(Me, "Are you sure you want to delete the document '" & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName & "' ?", "Delete Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Try
                        System.IO.File.Delete(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
                    Catch ex As Exception
                        Logger.WriteError(ex)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                Dim newb As String = InputBox("Enter the new filename", "Rename Document", CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName)
                If Not newb = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName Then
                    Try
                        My.Computer.FileSystem.RenameFile(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation, newb)
                    Catch ex As Exception
                        Logger.WriteError(ex)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub CloneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloneToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                Dim newb As New SaveFileDialog
                newb.Title = "Clone Document"
                newb.OverwritePrompt = True
                newb.Filter = GetFileFilter()
                If CurrentProfile.Name <> "" Then
                    newb.InitialDirectory = CurrentProfile.Folder
                End If
                If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        My.Computer.FileSystem.CopyFile(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation, newb.FileName)
                    Catch ex As Exception
                        Logger.WriteError(ex)
                    End Try
                End If
            End If
        End If
    End Sub

#End Region

    Private Sub OpenProfileFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProfileFolderToolStripMenuItem.Click
        If CurrentProfile.Name <> "" Then
            System.Diagnostics.Process.Start("explorer.exe", CurrentProfile.Folder)
        End If
    End Sub

    Private Sub PerformanceModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerformanceModeToolStripMenuItem.Click
        If My.Settings.temp_performancemode Then
            My.Settings.temp_performancemode = False
            PerformanceModeToolStripMenuItem.Checked = False
        Else
            My.Settings.temp_performancemode = True
            PerformanceModeToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub OpenStudioLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenStudioLocationToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Explorer.exe", XDev.Path.Locator.GetAppPath)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub OpenWorkspaceLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenWorkspaceLocationToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Explorer.exe", XDev.Path.Locator.GetWorkspacePath)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Private Sub OpenDataLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDataLocationToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Explorer.exe", XDev.Path.Locator.GetDataPath)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    'Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
    '    Application.Restart()
    'End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'If CheckIfAllSaved() = False Then
        '    If MetroMessageBox.Show(Me, "Some documents have unsaved changes. Do you really want to exit without saving?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '        'CloseProject()
        '        My.Settings.Save()
        '        Logger.Write(Logger.TypeOfLog.Studio, "Exiting XDev Studio.")
        '        Me.Close()
        '    Else
        '        'do nothing
        '    End If
        'Else
        '    Me.Close()
        'End If
        'Me.Close()
        Me.Close()
    End Sub

    Private Sub NewInstanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewInstanceToolStripMenuItem.Click
        Try
            Dim aloc As String = XDev.Path.Locator.GetAppPath + "\XDev Studio.exe"
            System.Diagnostics.Process.Start(aloc)
            Logger.Write(Logger.TypeOfLog.Studio, "Creating new instance of XDev Studio.")
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            MetroMessageBox.Show(Me, "Could not create a new instance of XDev Studio. Has the application file been renamed?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowPrintDialog()
        End If
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowPrintPreview()
        End If
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowPageSetupDialog()
        End If
    End Sub

#End Region

#Region "Edit"

    Private Sub EditToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub EditToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            EditToolStripMenuItem.ShowDropDown()
        End If
    End Sub

#Region "Copy As"

    Private Sub RTFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RTFToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CopyAsRtf()
        End If
    End Sub

    Private Sub HTMLToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem4.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CopyAsHtml()
        End If
    End Sub

#End Region

    Private Sub ClearAllHighlightsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllHighlightsToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ClearFoundHighlightedWords()
        End If
    End Sub

    Private Sub ToggleReadOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleReadOnlyToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).TextBox1.IsReadOnly Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).TextBox1.IsReadOnly = False
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).TextBox2.IsReadOnly = False
                ToggleReadOnlyToolStripMenuItem.Checked = False
            Else
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).TextBox1.IsReadOnly = True
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).TextBox2.IsReadOnly = True
                ToggleReadOnlyToolStripMenuItem.Checked = True
            End If
        ElseIf IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.ReadOnly Then
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.ReadOnly = False
                ToggleReadOnlyToolStripMenuItem.Checked = False
            Else
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.ReadOnly = True
                ToggleReadOnlyToolStripMenuItem.Checked = True
            End If
        End If
    End Sub

    Private Sub ClearUndoHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearUndoHistoryToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().EmptyUndoBuffer()
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.ClearUndo()
        End If
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowIncrementalSearcher(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.Undo)
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Focus()
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Undo()
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Focus()
        End If
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.Redo)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Redo()
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        If IsCodeEditor() Then
            If My.Settings.set_smartcut Then
                If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "" Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CutWordFromCurrentPosition()
                Else
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Cut()
                End If
            Else
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Cut()
            End If
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Cut()
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        If IsCodeEditor() Then
            If My.Settings.set_smartcopy Then
                If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "" Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CopyWordFromCurrentPosition()
                Else
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Copy()
                End If
            Else
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Copy()
            End If
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Copy()
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        If IsCodeEditor() Then
            If My.Settings.set_smartpaste Then
                If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "" And Not CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetWordFromCurrentPosition = "" Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().PasteWordFromCurrentPosition()
                Else
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Paste()
                End If
            Else
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Paste()
            End If
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Paste()
        End If
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectAll()
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectAll()
        End If
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ClearAll()
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Clear()
        End If
    End Sub

    Private Sub FindReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindReplaceToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowFindReplace()
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.FindForm.Show()
        End If
    End Sub

    Private Sub GotoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GotoToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowGoto()
        End If
    End Sub

#End Region

#Region "Text"

    Private Sub TextToolStripMenuItem1_DropDownOpening(sender As Object, e As EventArgs) Handles TextToolStripMenuItem1.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub TextToolStripMenuItem1_MouseHover(sender As Object, e As EventArgs) Handles TextToolStripMenuItem1.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            TextToolStripMenuItem1.ShowDropDown()
        End If
    End Sub

#Region "Indent"

    Private Sub IncreaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncreaseToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.Tab)
        End If
    End Sub

    Private Sub DecreaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecreaseToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.BackTab)
        End If
    End Sub

#End Region

#Region "Bookmarks"

    Private Sub AddAtCurrentLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAtCurrentLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).AddBookmarkAtCurrentLine()
        End If
    End Sub

    Private Sub AddAtSpecificLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAtSpecificLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).AddBookmarkAtSpecificLine()
        End If
    End Sub

#End Region

#Region "Text"

    Private Sub DeleteTextRightOfCurrentPositionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteTextRightOfCurrentPositionToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.DelLineRight)
        End If
    End Sub

    Private Sub DeleteTextLeftOfCurrentPositionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteTextLeftOfCurrentPositionToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.DelLineLeft)
        End If
    End Sub

    Private Sub DeleteWordLeftOfCurrentPositionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteWordLeftOfCurrentPositionToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.DelWordLeft)
        End If
    End Sub

    Private Sub DeleteWordRightOfCurrentPositionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteWordRightOfCurrentPositionToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.DelWordRight)
        End If
    End Sub

#End Region

#Region "Selection"

#Region "Convert"

    Private Sub Base64ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Base64ToolStripMenuItem.Click
        Try
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = To64(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
            ElseIf IsNotepad() Then
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.ToUpper
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = To64(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText)
            End If
        Catch ex As Exception
            MetroMessageBox.Show(Me, "Invalid String!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub
    
    Private Sub StringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StringToolStripMenuItem.Click
        Try
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = ToStr(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
            ElseIf IsNotepad() Then
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.ToUpper
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = ToStr(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText)
            End If
        Catch ex As Exception
            MetroMessageBox.Show(Me, "Invalid Base64 String!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub UPPERCASEToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UPPERCASEToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.Uppercase)
        ElseIf IsNotepad() Then
            Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.ToUpper
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = s
        End If
    End Sub

    Private Sub LowercaseToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LowercaseToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.Lowercase)
        ElseIf IsNotepad() Then
            Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.ToLower
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = s
        End If
    End Sub

    Private Sub ProperCaseToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProperCaseToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim s As String = StrConv(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText, VbStrConv.ProperCase)
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = s
        ElseIf IsNotepad() Then
            Dim s As String = StrConv(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.ToUpper, VbStrConv.ProperCase)
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = s
        End If
    End Sub

#End Region

#Region "Selected URL"

    Private Sub GetWHOISInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetWHOISInfoToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText <> "" Then
                Dim orig As String = WhoisResolver.Whois(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
                Dim first As String = orig.Remove(orig.IndexOf("NOTICE:"))
                Dim cut_at As String = "information."
                Dim x As Integer = InStr(first, cut_at)
                Dim string_after As String = first.Substring(x + cut_at.Length - 1)
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText += string_after
            End If
        ElseIf IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText <> "" Then
                Dim orig As String = WhoisResolver.Whois(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText)
                Dim first As String = orig.Remove(orig.IndexOf("NOTICE:"))
                Dim cut_at As String = "information."
                Dim x As Integer = InStr(first, cut_at)
                Dim string_after As String = first.Substring(x + cut_at.Length - 1)
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText += string_after
            End If
        End If
    End Sub

    Private Sub GetIPAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GetIPAddressToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText <> "" Then
                Try
                    If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText.Contains("http://") Then
                        Dim iphe As IPHostEntry = Dns.GetHostEntry(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText.Replace("http://", String.Empty))
                        CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText += iphe.AddressList(0).ToString()
                    Else
                        Dim iphe As IPHostEntry = Dns.GetHostEntry(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
                        CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText += iphe.AddressList(0).ToString()
                    End If
                Catch ex As Exception
                    MsgBox(ex)
                End Try
            End If
        ElseIf IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText <> "" Then
                Try
                    If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.Contains("http://") Then
                        Dim iphe As IPHostEntry = Dns.GetHostEntry(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.Replace("http://", String.Empty))
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText += iphe.AddressList(0).ToString()
                    Else
                        Dim iphe As IPHostEntry = Dns.GetHostEntry(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText)
                        CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText += iphe.AddressList(0).ToString()
                    End If
                Catch ex As Exception
                    MsgBox(ex)
                End Try
            End If
        End If
    End Sub

    Private Sub PreviewURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewURLToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText <> "" Then
                Try
                    Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                    'If CheckURL(s) = True Then
                    Dim newb As New frmSitePreviewer
                    newb.PreviewWebsite(s)
                    newb.Show()
                    'Else
                    'MetroMessageBox.Show(Me, "Invalid URL selected.", "Site Previewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                Catch ex As Exception
                    Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                    MetroMessageBox.Show(Me, "Unable to load the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        ElseIf IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText <> "" Then
                Try
                    Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                    'If CheckURL(s) = True Then
                    Dim newb As New frmSitePreviewer
                    newb.PreviewWebsite(s)
                    newb.Show()
                    'Else
                    'MetroMessageBox.Show(Me, "Invalid URL selected.", "Site Previewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If
                Catch ex As Exception
                    Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                    MetroMessageBox.Show(Me, "Unable to load the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub CheckURLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckURLToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText <> "" Then
                If IsURLValid(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText) Then
                    MetroMessageBox.Show(Me, "The URL: " & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & " appears to be valid and working.", "Check URL", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MetroMessageBox.Show(Me, "The URL: " & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & " does NOT appear to be valid and working.", "Check URL", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        ElseIf IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText <> "" Then
                If IsURLValid(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText) Then
                    MetroMessageBox.Show(Me, "The URL: " & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & " appears to be valid and working.", "Check URL", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MetroMessageBox.Show(Me, "The URL: " & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & " does NOT appear to be valid and working.", "Check URL", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

#End Region

#Region "Selected Path"

    Private Sub OpenInExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInExplorerToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText <> "" Then
                Try
                    System.Diagnostics.Process.Start("explorer.exe", CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
                Catch ex As Exception
                    Logger.WriteError(ex)
                End Try
            End If
        ElseIf IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText <> "" Then
                Try
                    System.Diagnostics.Process.Start("explorer.exe", CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText)
                Catch ex As Exception
                    Logger.WriteError(ex)
                End Try
            End If
        End If
    End Sub

#End Region

#Region "Search Website for Selection"

    Private Sub PHPManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPManualToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                Tabs.AddWebBrowser("http://php.net/manual-lookup.php?pattern=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                Tabs.AddWebBrowser("http://php.net/manual-lookup.php?pattern=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub StackOverflowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StackOverflowToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                Tabs.AddWebBrowser("https://stackoverflow.com/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                Tabs.AddWebBrowser("https://stackoverflow.com/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub WikipediaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WikipediaToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                Tabs.AddWebBrowser("https://en.wikipedia.org/wiki/" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                Tabs.AddWebBrowser("https://en.wikipedia.org/wiki/" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub GithubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GithubToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                Tabs.AddWebBrowser("https://github.com/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                Tabs.AddWebBrowser("https://github.com/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub W3schoolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles W3schoolsToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                Tabs.AddWebBrowser("http://www.w3schools.com/?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                Tabs.AddWebBrowser("http://www.w3schools.com/?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub CodegooglecomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodegooglecomToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                Tabs.AddWebBrowser("https://code.google.com/hosting/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                Tabs.AddWebBrowser("https://code.google.com/hosting/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub PastebinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PastebinToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                Tabs.AddWebBrowser("http://pastebin.com/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                Tabs.AddWebBrowser("http://pastebin.com/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

#End Region

#Region "Surround With"

    Private Sub CustomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CustomToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Dim newb As New dlgSurroundWith
            If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = newb.txt_start.Text & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & newb.txt_end.Text
            End If
        ElseIf IsNotepad() Then
            Dim newb As New dlgSurroundWith
            If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = newb.txt_start.Text & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & newb.txt_end.Text
            End If
        End If
    End Sub

    Private Sub SelectionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = """" & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & """"
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = """" & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & """"
        End If
    End Sub

    Private Sub SelectionToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem6.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "'" & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & "'"
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = "'" & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & "'"
        End If
    End Sub

    Private Sub SelectionToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem2.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "(" & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & ")"
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = "(" & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & ")"
        End If
    End Sub

    Private Sub SelectionToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem3.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "[" & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & "]"
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = "[" & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & "]"
        End If
    End Sub

    Private Sub SelectionToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem4.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "{" & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & "}"
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = "{" & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & "}"
        End If
    End Sub

    Private Sub SelectionToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem7.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "<" & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & ">"
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = "<" & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & ">"
        End If
    End Sub

    Private Sub SelectionToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem5.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = "*" & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText & "*"
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = "*" & CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText & "*"
        End If
    End Sub

#End Region

#Region "Speech"

    Private Sub SpeakSelectionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SpeakSelectionToolStripMenuItem1.Click
        If IsCodeEditor() And CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText <> "" Then
            SpeechEngine.SpeakText(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
        End If
    End Sub

    Private Sub CancelSpeakingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelSpeakingToolStripMenuItem.Click
        SpeechEngine.CancelSpeaking()
    End Sub

#End Region

#Region "Extend"

    Private Sub RightByOneCharacterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RightByOneCharacterToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.CharRightExtend)
        End If
    End Sub

    Private Sub LeftByOneCharacterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeftByOneCharacterToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.CharLeftExtend)
        End If
    End Sub

    Private Sub DownOneLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownOneLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.LineDownExtend)
        End If
    End Sub

    Private Sub UpOneLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpOneLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.LineUpExtend)
        End If
    End Sub

    Private Sub ToStartOfDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToStartOfDocumentToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.DocumentStartExtend)
        End If
    End Sub

    Private Sub ToEndOfDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToEndOfDocumentToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.DocumentEndExtend)
        End If
    End Sub

    Private Sub DownOneParagraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownOneParagraphToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.ParaDownExtend)
        End If
    End Sub

    Private Sub UpOneParagraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpOneParagraphToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.ParaUpExtend)
        End If
    End Sub

    Private Sub ToEndOfLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToEndOfLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.LineEndExtend)
        End If
    End Sub

    Private Sub ToBeginningOfLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToBeginningOfLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.HomeExtend)
        End If
    End Sub

#End Region

    Private Sub HTMLEncodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTMLEncodeToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = WebUtility.HtmlEncode(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
        ElseIf IsNotepad() Then
            Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.ToUpper
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = WebUtility.HtmlEncode(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText)
        End If
    End Sub

    Private Sub RemoveSpecialCharactersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveSpecialCharactersToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = EditMethods.RemoveSpecialCharacters(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
        ElseIf IsNotepad() Then
            Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.ToUpper
            CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = EditMethods.RemoveSpecialCharacters(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText)
        End If
    End Sub

    Private Sub CompressToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompressToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim CompExp As New Regex("\s")
            If CompExp.IsMatch(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText) = True Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = CompExp.Replace(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText, "")
            End If
        End If
    End Sub

    Private Sub ConvertToASCIICodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertToASCIICodeToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim v As Integer = 0
            Dim i As Integer
            For i = 1 To 256
                If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText.Chars(0) = Chr(v) Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText = v
                    i = 256
                Else
                    v = v + 1
                End If
            Next i
            i = 1
            v = 0
        ElseIf IsNotepad() Then
            Dim v As Integer = 0
            Dim i As Integer
            For i = 1 To 256
                If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText.Chars(0) = Chr(v) Then
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText = v
                    i = 256
                Else
                    v = v + 1
                End If
            Next i
            i = 1
            v = 0
        End If
    End Sub

    Private Sub SearchSelectionOnWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchSelectionOnWebToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
                'System.Diagnostics.Process.Start("https://www.google.com/search?q=" & s)
                Tabs.AddWebBrowser("https://www.google.com/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
                'System.Diagnostics.Process.Start("https://www.google.com/search?q=" & s)
                Tabs.AddWebBrowser("https://www.google.com/search?q=" & s)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub DuplicateSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateSelectionToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.SelectionDuplicate)
        End If
    End Sub

#End Region

#Region "Lines"

    Private Sub CompressLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompressLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim CompExp As New Regex("\s")
            Dim curline As Integer = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentLine
            If CompExp.IsMatch(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetTextFromLine(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentLine)) = True Then
                'CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetLines(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentLine).Text = CompExp.Replace(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetTextFromLine(curline), "")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SetTextForLine(curline, CompExp.Replace(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetTextFromLine(curline), ""))
            End If
        End If
    End Sub

    Private Sub TransposeLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransposeLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.LineTranspose)
        End If
    End Sub

    Private Sub NewLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.NewLine)
        End If
    End Sub

    Private Sub DeleteLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.LineDelete)
        End If
    End Sub

    Private Sub GotoLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowGoto()
        End If
    End Sub

    Private Sub GotoFirstVisibleLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoFirstLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GotoLine(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetFirstVisibleLine)
        End If
    End Sub

    Private Sub GotoFirstLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoFirstLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GotoLine(0)
        End If
    End Sub

    Private Sub GotoLastLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoLastLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GotoLine(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetTotalLines)
        End If
    End Sub

    Private Sub MoveSelectedLinesDownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveSelectedLinesDownToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.MoveSelectedLinesDown)
        End If
    End Sub

    Private Sub MoveSelectedLinesUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveSelectedLinesUpToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.MoveSelectedLinesUp)
        End If
    End Sub

    Private Sub DuplicateLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExecuteCommand(Command.LineDuplicate)
        End If
    End Sub

#End Region

#Region "Spelling"

#Region "Selection"

    Private Sub SpellingSuggestionsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SpellingSuggestionsToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Dim b As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).AddLineToNotes("=====Spelling Recommendations for '" & b & "'=====")
            For Each item As String In SpellChecker.GetSpellingRecommendations(b)
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).AddLineToNotes(item)
            Next
        ElseIf IsNotepad() Then
            Dim b As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
            Dim out As String = vbNewLine
            out += "=====Spelling Recommendations for '" & b & "'====="
            out += vbNewLine
            For Each item As String In SpellChecker.GetSpellingRecommendations(b)
                out += item
                out += vbNewLine
            Next
            out += "=========="
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(out)
        End If
    End Sub

    Private Sub CheckIfWordIsSpelledCorrectlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckIfWordIsSpelledCorrectlyToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim b As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText
            If SpellChecker.IsWordSpelledCorrectly(b) = True Then
                MetroMessageBox.Show(Me, "The word '" & b & "' is spelled correctly.", "Spelling", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MetroMessageBox.Show(Me, "The word '" & b & "' is spelled incorrectly. Do you want to view spelling recommendations?", "Spelling", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    SpellingSuggestionsToolStripMenuItem1.PerformClick()
                End If
            End If
        ElseIf IsNotepad() Then
            Dim b As String = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText
            If SpellChecker.IsWordSpelledCorrectly(b) = True Then
                MetroMessageBox.Show(Me, "The word '" & b & "' is spelled correctly.", "Spelling", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MetroMessageBox.Show(Me, "The word '" & b & "' is spelled incorrectly. Do you want to view spelling recommendations?", "Spelling", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    SpellingSuggestionsToolStripMenuItem1.PerformClick()
                End If
            End If
        End If
    End Sub

#End Region

#Region "Dictionary"

    Private Sub AddWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddWordToolStripMenuItem.Click
        Dim b As String = InputBox("Enter the word you want to add to the dictionary:", "Add Word", "")
        If b <> "" Then
            SpellChecker.AddCustomWordToDictionary(b)
            MetroMessageBox.Show(Me, "'" & b & "' was added to the dictionary!", "Add Word", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub RemoveWordToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RemoveWordToolStripMenuItem.Click
        Dim b As String = InputBox("Enter the word you want to remove from the dictionary (it must be spelled exactly as it is listed):", "Remove Word", "")
        If b <> "" Then
            SpellChecker.RemoveCustomWordFromDictionary(b)
            MetroMessageBox.Show(Me, "'" & b & "' was removed from the dictionary!", "Remove Word", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

    Private Sub SpellingSuggestionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpellingSuggestionsToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim b As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetWordFromPosition(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentPosition - 1)
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).AddLineToNotes("=====Spelling Recommendations for '" & b & "'=====")
            For Each item As String In SpellChecker.GetSpellingRecommendations(b)
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).AddLineToNotes(item)
            Next
        End If
    End Sub

    Private Sub CheckIfWordIsSpelledCorrectlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CheckIfWordIsSpelledCorrectlyToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Dim b As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GetWordFromPosition(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentPosition - 1)
            If SpellChecker.IsWordSpelledCorrectly(b) = True Then
                MetroMessageBox.Show(Me, "The word '" & b & "' is spelled correctly.", "Spelling", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MetroMessageBox.Show(Me, "The word '" & b & "' is spelled incorrectly. Do you want to view spelling recommendations?", "Spelling", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                    SpellingSuggestionsToolStripMenuItem.PerformClick()
                End If
            End If
        End If
    End Sub

#End Region

#Region "Goto"

    Private Sub MatchingBraceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MatchingBraceToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().BraceMatch(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentPosition) = -1 Then
                If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().BraceMatch(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentPosition - 1) = -1 Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowCallTip(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentPosition, "Could not find matching brace.")
                Else
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GoToMatchingBrace(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentPosition - 1)
                End If
            Else
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().GoToMatchingBrace()
            End If
        End If
    End Sub

#End Region

#Region "Other"

#Region "Convert Line Endings"

    Private Sub ToCrLfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToCrLfToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ConvertEols(Eol.CrLf)
        End If
    End Sub

    Private Sub ToLfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToLfToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ConvertEols(Eol.Lf)
        End If
    End Sub

    Private Sub ToCrToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToCrToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ConvertEols(Eol.Cr)
        End If
    End Sub

#End Region

#End Region

    Private Sub SaveSelectionAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSelectionAsToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText <> "" Then
                Dim newb As New SaveFileDialog
                newb.Title = "Save Selection to File"
                newb.OverwritePrompt = True
                newb.Filter = GetFileFilter()
                If CurrentProfile.Name <> "" Then
                    newb.InitialDirectory = CurrentProfile.Folder
                End If
                If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim objWriter As New System.IO.StreamWriter(newb.FileName, False)
                    objWriter.Write(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().SelectedText)
                    objWriter.Close()
                    If MetroMessageBox.Show(Me, "Saved selection to file '" & newb.FileName & "' Would you like to open it?", "Saved Selection", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                        Tabs.AddCode(newb.FileName)
                    End If
                End If
            End If
        ElseIf IsNotepad() Then
            If CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText <> "" Then
                Dim newb As New SaveFileDialog
                newb.Title = "Save Selection to File"
                newb.OverwritePrompt = True
                newb.Filter = GetFileFilter()
                If CurrentProfile.Name <> "" Then
                    newb.InitialDirectory = CurrentProfile.Folder
                End If
                If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim objWriter As New System.IO.StreamWriter(newb.FileName, False)
                    objWriter.Write(CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.SelectedText)
                    objWriter.Close()
                    If MetroMessageBox.Show(Me, "Saved selection to file '" & newb.FileName & "' Would you like to open it?", "Saved Selection", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                        Tabs.AddCode(newb.FileName)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CommentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommentToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CommentLines()
        End If
    End Sub

    Private Sub UncommentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UncommentToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().UnCommentLines()
        End If
    End Sub

#End Region

#Region "Format"

    Private Sub FormatToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles FormatToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub FormatToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles FormatToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            FormatToolStripMenuItem.ShowDropDown()
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim newb As New FontDialog
            newb.Font = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Font
            newb.AllowScriptChange = False
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Font = newb.Font
            End If
        ElseIf IsNotepad() Then
            Dim newb As New FontDialog
            newb.Font = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Font
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.Font = newb.Font
            End If
        End If
    End Sub

    Private Sub ForecolorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForecolorToolStripMenuItem.Click
        If IsNotepad() Then
            Dim newb As New ColorDialog
            newb.Color = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.ForeColor
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.ForeColor = newb.Color
            End If
        End If
    End Sub

    Private Sub BackcolorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackcolorToolStripMenuItem.Click
        If IsNotepad() Then
            Dim newb As New ColorDialog
            newb.Color = CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.BackColor
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CType(DockPanel1.ActiveDocument, Tab_Notepad).TextBox1.BackColor = newb.Color
            End If
        End If
    End Sub
#End Region

#Region "Insert"

    Private Sub InsertToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles InsertToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub InsertToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles InsertToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            InsertToolStripMenuItem.ShowDropDown()
        End If
    End Sub

#Region "Time/Date"

    Private Sub TimeDateToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TimeDateToolStripMenuItem2.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(DateTime.Now.ToString("hh:mm dd/mm/yyyy"))
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(DateTime.Now.ToString("hh:mm dd/mm/yyyy"))
        End If
    End Sub

    Private Sub UTCTimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UTCTimeToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(DateTime.UtcNow)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(DateTime.UtcNow)
        End If
    End Sub

#End Region

#Region "Computer Information"

#Region "OS"

    Private Sub NameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NameToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Info.OSFullName)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Info.OSFullName)
        End If
    End Sub

    Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Info.OSVersion)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Info.OSVersion)
        End If
    End Sub

    Private Sub PlatformToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlatformToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Info.OSPlatform)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Info.OSPlatform)
        End If
    End Sub

#End Region

#Region "Screen"

    Private Sub WorkingAreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WorkingAreaToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Screen.WorkingArea.ToString)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Screen.WorkingArea.ToString)
        End If
    End Sub

    Private Sub NameToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NameToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Screen.DeviceName)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Screen.DeviceName)
        End If
    End Sub

    Private Sub BoundsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BoundsToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Screen.Bounds.ToString)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Screen.Bounds.ToString)
        End If
    End Sub

#End Region

    Private Sub ComputerNameToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ComputerNameToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Name)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Name)
        End If
    End Sub

    Private Sub TotalPhysicalMemoryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TotalPhysicalMemoryToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Info.TotalPhysicalMemory.ToString)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Info.TotalPhysicalMemory.ToString)
        End If
    End Sub

    Private Sub TotalVirtualMemoryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TotalVirtualMemoryToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.Info.TotalVirtualMemory.ToString)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.Info.TotalVirtualMemory.ToString)
        End If
    End Sub

    Private Sub CPUUsageToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CPUUsageToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(CPUMonitor.GetCPUUsage.ToString & "%")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(CPUMonitor.GetCPUUsage.ToString & "%")
        End If
    End Sub

    Private Sub NetworkAdapterInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NetworkAdapterInformationToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(NetworkInfo.GetNetworkInfo())
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try

        ElseIf IsNotepad() Then
            Try
                CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(NetworkInfo.GetNetworkInfo())
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub DefaultBrowserPathToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DefaultBrowserPathToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(defaultbrowserlocation())
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(defaultbrowserlocation())
        End If
    End Sub

    Private Sub SystemUptimeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SystemUptimeToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(getUptime())
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(getUptime())
        End If
    End Sub

    Private Sub InstalledFontsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InstalledFontsToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Dim fonts As New InstalledFontCollection
            Dim flist As String = ""
            For Each one As FontFamily In fonts.Families
                flist += one.Name & vbNewLine
            Next
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(flist)
        ElseIf IsNotepad() Then
            Dim fonts As New InstalledFontCollection
            Dim flist As String = ""
            For Each one As FontFamily In fonts.Families
                flist += one.Name & vbNewLine
            Next
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(flist)
        End If
    End Sub

#End Region

#Region "Symbol"

    Private Sub SymbolChooserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SymbolChooserToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowInsertSymbol()
        End If
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("•")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("•")
        End If
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("«")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("«")
        End If
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("»")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("»")
        End If
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("½")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("½")
        End If
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("¼")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("¼")
        End If
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("±")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("±")
        End If
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("÷")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("÷")
        End If
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("≥")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("≥")
        End If
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("≤")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("≤")
        End If
    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("√")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("√")
        End If
    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("©")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("©")
        End If
    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem23.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("®")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("®")
        End If
    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem24.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("™")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("™")
        End If
    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem25.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("▲")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("▲")
        End If
    End Sub

    Private Sub ToolStripMenuItem26_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem26.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("▼")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("▼")
        End If
    End Sub

    Private Sub ToolStripMenuItem27_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem27.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText("¶")
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText("¶")
        End If
    End Sub

#End Region

#Region "Examples"

    Dim exampleloc As String = XDev.Path.Locator.GetAppPath() + "\Engine\Examples\"

#Region "HTML"

    Private Sub DocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\document.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub HeadingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeadingsToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\headings.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\paragraphs.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub LinksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinksToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\links.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub ImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImagesToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\images.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub StylesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StylesToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\styles.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub BackgroundColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackgroundColorToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\backgroundcolor.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub BasicTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BasicTableToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\basictable.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub OrderedListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderedListToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\orderedlist.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub UnorderedListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnorderedListToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\unorderedlist.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub StylingdivElementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StylingdivElementsToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\stylingdivelements.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub StylingspanElementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StylingspanElementsToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\stylingspanelements.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub IFrameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IFrameToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\iframe.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub FormWithTextInputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FormWithTextInputToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\formwithtextinput.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub SimpleDropdownListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimpleDropdownListToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\simpledropdownlist.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub HTML5CanvasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTML5CanvasToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\html5canvas.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub HTML5VideoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTML5VideoToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\html5video.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub HTML5GeolocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTML5GeolocationToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\html5geolocation.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub HTML5LocalStorageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTML5LocalStorageToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\html5localstorage.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub HTML5AudioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTML5AudioToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "HTML\html5audio.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

#End Region

#Region "Batch"

    Private Sub DisplayTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisplayTextToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Batch\displaytext.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub UserInputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserInputToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Batch\userinput.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub StartProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartProcessToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Batch\startprocess.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub CallBatchFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CallBatchFileToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Batch\callbatchfile.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub PauseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PauseToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Batch\pause.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub GotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Batch\goto.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

#End Region

#Region "Java"

    Private Sub HelloWorldToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelloWorldToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Java\helloworld.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub UserInputToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UserInputToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Java\userinput.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub StartProcessToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StartProcessToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Java\startprocess.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub ForLoopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForLoopToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Java\forloop.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub WhileLoopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhileLoopToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Java\whileloop.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

#End Region

#Region "C++"

    Private Sub HelloWorldToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelloWorldToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "CPlusPlus\helloworld.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub ForLoopToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ForLoopToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "CPlusPlus\forloop.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub WhileLoopToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles WhileLoopToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "CPlusPlus\whileloop.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub StartProcessToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles StartProcessToolStripMenuItem2.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "CPlusPlus\startprocess.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub UserInputToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles UserInputToolStripMenuItem2.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "CPlusPlus\userinput.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub SwitchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SwitchToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "CPlusPlus\switch.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub PauseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PauseToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "CPlusPlus\pause.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

#End Region

#Region "XML"

    Private Sub SimpleXMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimpleXMLToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "XML\simplexml.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub BreakfastMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BreakfastMenuToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "XML\breakfastmenu.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

#End Region

#Region "Python"

    Private Sub PrintToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Python\print.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub ForLoopToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ForLoopToolStripMenuItem2.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Python\forloop.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub WhileLoopToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles WhileLoopToolStripMenuItem2.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Python\whileloop.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

    Private Sub StartProcessToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles StartProcessToolStripMenuItem3.Click
        If IsCodeEditor() Then
            Try
                Dim i As String = System.IO.File.ReadAllText(exampleloc + "Python\startprocess.txt")
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
            Catch
            End Try
        End If
    End Sub

#End Region

#End Region

#Region "Lorem Ipsum"

    Private Sub ParagraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParagraphToolStripMenuItem.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\1.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\1.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\2.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\2.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem2.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\3.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\3.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem3.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\4.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\4.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem4.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\5.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\5.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem5.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\6.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\6.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem6.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\7.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\7.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem7.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\8.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\8.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem8.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\9.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\9.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub ParagraphsToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem9.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\10.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\10.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

#End Region

#Region "Scrape HTML"

    Private Sub thread_ce_ScrapeHTML(ByVal b As String)
        Dim request As WebRequest = WebRequest.Create(b)
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                Dim html As String = reader.ReadToEnd()
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(html)
                Logger.Write(Logger.TypeOfLog.Code, "Downloaded webpage '" & b & "' and inserted source into editor.")
            End Using
        End Using
    End Sub

    Private Sub thread_np_ScrapeHTML(ByVal b As String)
        Dim request As WebRequest = WebRequest.Create(b)
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                Dim html As String = reader.ReadToEnd()
                CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(html)
                Logger.Write(Logger.TypeOfLog.Code, "Downloaded webpage '" & b & "' and inserted source into editor.")
            End Using
        End Using
    End Sub

    Private Sub ScrapedHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScrapedHTMLToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim b As String = InputBox("Please enter the url of the webpage to download.", "Scrape Web Page", "")
            If b IsNot "" Then
                ThreadPool.QueueUserWorkItem(AddressOf thread_ce_ScrapeHTML, b)
            End If
        ElseIf IsNotepad() Then
            Dim b As String = InputBox("Please enter the url of the webpage to download.", "Scrape Web Page", "")
            If b IsNot "" Then
                ThreadPool.QueueUserWorkItem(AddressOf thread_np_ScrapeHTML, b)
            End If
        End If
    End Sub

#End Region

#Region "Math"

    Private Sub PIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PIToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(Math.PI.ToString)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(Math.PI.ToString)
        End If
    End Sub


    Private Sub EToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(Math.E.ToString)
        ElseIf IsNotepad() Then
            CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(Math.E.ToString)
        End If
    End Sub

    Private Sub EXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim b As String = InputBox("Enter the power to raise E to.", "E^X", "")
            If b <> "" Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(Math.Exp(b).ToString)
            End If
        ElseIf IsNotepad() Then
            Dim b As String = InputBox("Enter the power to raise E to.", "E^X", "")
            If b <> "" Then
                CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(Math.Exp(b).ToString)
            End If
        End If
    End Sub

#End Region

#Region ".NET"

    Private Sub ManifestToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManifestToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\Manifest\dotnet.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(i)
                Next
            Catch
            End Try
        ElseIf IsNotepad() Then
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\Manifest\dotnet.txt")
                For Each i As String In lines
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(vbNewLine)
                    CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(i)
                Next
            Catch
            End Try
        End If
    End Sub

    Private Sub GUIDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GUIDToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowInsertGUID()
        End If
    End Sub

#End Region

    Private Sub CodeTemplateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodeTemplateToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowCodeTemplates()
        End If
    End Sub

    Private Sub DocumentAtCurrentPositonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentAtCurrentPositonToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim newb As New OpenFileDialog
            newb.Title = "Open File"
            newb.Filter = GetFileFilter()
            newb.Multiselect = False
            If CurrentProfile.Name <> "" Then
                newb.InitialDirectory = CurrentProfile.Folder
            End If
            If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().InsertText(My.Computer.FileSystem.ReadAllText(newb.FileName))
            End If
        ElseIf IsNotepad() Then
            Dim newb As New OpenFileDialog
            newb.Title = "Open File"
            newb.Filter = GetFileFilter()
            newb.Multiselect = False
            If CurrentProfile.Name <> "" Then
                newb.InitialDirectory = CurrentProfile.Folder
            End If
            If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
                CType(DockPanel1.ActiveDocument, Tab_Notepad).InsertText(My.Computer.FileSystem.ReadAllText(newb.FileName))
            End If
        End If
    End Sub

#End Region

#Region "View"

    Private Sub ViewToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub ViewToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            ViewToolStripMenuItem.ShowDropDown()
        End If
    End Sub

#Region "Zoom"

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom = 1
            ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom.ToString
        End If
    End Sub

    Private Sub InToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom > -10 And CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom < 20 Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom += 1
                ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom.ToString
            End If
        End If
    End Sub

    Private Sub OutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom > -10 And CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom < 20 Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom -= 1
                ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Zoom.ToString
            End If
        End If
    End Sub

#End Region

#Region "Folding"

    Private Sub UnfoldLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnfoldLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().UnFoldLine(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentLine)
        End If
    End Sub

    Private Sub FoldLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FoldLineToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().FoldLine(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().CurrentLine)
        End If
    End Sub

    Private Sub FoldAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FoldAllToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().FoldAll()
        End If
    End Sub

    Private Sub UnfoldAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnfoldAllToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().FoldAll()
        End If
    End Sub

#End Region

    Private Sub NotificationCenterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotificationCenterToolStripMenuItem.Click
        pnlNotificationCenter.ShowPanel(DockPanel1, DockState.DockBottom)
    End Sub

    Private Sub EditorCommandPaletteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditorCommandPaletteToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowCommandPalette()
        End If
    End Sub

    Private Sub SystemTerminalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemTerminalToolStripMenuItem.Click
        pnlSystemTerminal.ShowPanel(DockPanel1, DockState.DockBottom)
    End Sub

    Private Sub FavoritesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FavoritesToolStripMenuItem.Click
        pnlFavorites.ShowPanel(DockPanel1, DockState.DockRight)
    End Sub

    Private Sub PresentationModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PresentationModeToolStripMenuItem.Click
        If IsCodeEditor() Then
            If MetroMessageBox.Show(Me, "Are you sure you want to enter presentation mode for this editor? Notes from the current editor will be loaded and changes made in presentation mode will not be saved.", "Presentation Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim t As New frmPresent
                t.TextBox1.Text = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text
                t.TextBox1.CustomLanguageEnabled = My.Settings.set_customlang_enabled
                t.TextBox1.SetCustomLanguage(My.Settings.set_customlang_keywords0, My.Settings.set_customlang_keywords1, My.Settings.set_customlang_autocompletelist)
                t.TextBox1.Language = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Language
                t.txt_notes.Text = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetNotes
                t.txt_notes.Font = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).txt_notes.Font
                t.txt_notes.BackColor = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).txt_notes.BackColor
                t.txt_notes.ForeColor = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).txt_notes.ForeColor
                t.UpdateTitle(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName)
                t.Show()
            End If
        End If
    End Sub

    Private Sub BookmarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookmarksToolStripMenuItem.Click
        Tabs.AddBookmarks()
    End Sub

    Private Sub CalculateCodeMetricsForCurrentDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculateCodeMetricsForCurrentDocumentToolStripMenuItem.Click
        If IsCodeEditor() Then
            Tabs.AddCodeMetrics(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
        End If
    End Sub

    Private Sub TipsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipsToolStripMenuItem.Click
        Dim newb As New frmTips
        newb.Show()
    End Sub

    Private Sub TasksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TasksToolStripMenuItem.Click
        Tabs.AddTasks()
    End Sub

    Private Sub WelcomePageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WelcomePageToolStripMenuItem.Click
        Tabs.AddWelcome()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogsToolStripMenuItem.Click
        Tabs.AddLogManager()
    End Sub

    Private Sub SnippetListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SnippetListToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim bb As List(Of String) = My.Settings.set_snippetlist.Cast(Of String)().ToList()
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ShowSnippetList(bb)
        End If
    End Sub

    Private Sub ToolPanelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolPanelToolStripMenuItem.Click
        If pnlToolPanel.Visible = False Then
            pnlToolPanel.ShowPanel(DockPanel1, DockState.DockRight)
        End If
    End Sub

    Private Sub ProjectExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectExplorerToolStripMenuItem.Click
        If ptype = ProjType.Project Then
            If pnlProjectExplorer.Visible = False Then
                pnlProjectExplorer.ShowPanel(DockPanel1, DockState.DockLeft)
            End If
        Else
            MetroMessageBox.Show(Me, "XDev Studio is not in project mode and therefore cannot display the project explorer.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#Region "Language"

    Private Sub LanguageToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles LanguageToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub LanguageToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles LanguageToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            LanguageToolStripMenuItem.ShowDropDown()
        End If
    End Sub

    Private Sub DetectLanguageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetectLanguageToolStripMenuItem.Click
        If IsCodeEditor() Then
            Select Case Ozone.LanguageDetector.Detector.DetectLanguageFromSnippet(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor.Text)
                Case Ozone.LanguageDetector.Language.Language.Ada
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Ada)
                Case Ozone.LanguageDetector.Language.Language.Assembly
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Assembly)
                Case Ozone.LanguageDetector.Language.Language.Batch
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Batch)
                Case Ozone.LanguageDetector.Language.Language.Cpp
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Cpp)
                Case Ozone.LanguageDetector.Language.Language.CSharp
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Csharp)
                Case Ozone.LanguageDetector.Language.Language.Css
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Css)
                Case Ozone.LanguageDetector.Language.Language.Fortran
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Fortran)
                Case Ozone.LanguageDetector.Language.Language.Html
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Html)
                Case Ozone.LanguageDetector.Language.Language.Java
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Java)
                Case Ozone.LanguageDetector.Language.Language.JavaScript
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.JavaScript)
                Case Ozone.LanguageDetector.Language.Language.Lisp
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Lisp)
                Case Ozone.LanguageDetector.Language.Language.Lua
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Lua)
                Case Ozone.LanguageDetector.Language.Language.Pascal
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Pascal)
                Case Ozone.LanguageDetector.Language.Language.Perl
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Perl)
                Case Ozone.LanguageDetector.Language.Language.Php
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Php)
                Case Ozone.LanguageDetector.Language.Language.PlainText
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.PlainText)
                Case Ozone.LanguageDetector.Language.Language.Python
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Python)
                Case Ozone.LanguageDetector.Language.Language.Ruby
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Ruby)
                Case Ozone.LanguageDetector.Language.Language.SmallTalk
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.SmallTalk)
                Case Ozone.LanguageDetector.Language.Language.Sql
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Sql)
                Case Ozone.LanguageDetector.Language.Language.Unknown
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.PlainText)
                Case Ozone.LanguageDetector.Language.Language.Vb
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.VB)
                Case Ozone.LanguageDetector.Language.Language.Xml
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Xml)
            End Select
        End If
    End Sub

    Private Sub AdaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdaToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Ada)
        End If
    End Sub


    Private Sub AssemblyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssemblyToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Assembly)
        End If
    End Sub

    Private Sub BatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Batch)
        End If
    End Sub

    Private Sub CToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Csharp)
        End If
    End Sub

    Private Sub CToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Cpp)
        End If
    End Sub


    Private Sub CSSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSSToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Css)
        End If
    End Sub

    Private Sub FortranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FortranToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Fortran)
        End If
    End Sub

    Private Sub HTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Html)
        End If
    End Sub

    Private Sub JavaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JavaToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Java)
        End If
    End Sub

    Private Sub JavaScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JavaScriptToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.JavaScript)
        End If
    End Sub

    Private Sub LispToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LispToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Lisp)
        End If
    End Sub

    Private Sub LuaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LuaToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Lua)
        End If
    End Sub

    Private Sub MarkdownToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MarkdownToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Markdown)
        End If
    End Sub

    Private Sub PascalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PascalToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Pascal)
        End If
    End Sub

    Private Sub PerlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerlToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Perl)
        End If
    End Sub

    Private Sub PHPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Php)
        End If
    End Sub

    Private Sub PostgreSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostgreSQLToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Psql)
        End If
    End Sub

    Private Sub PythonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PythonToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Python)
        End If
    End Sub

    Private Sub RubyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RubyToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Ruby)
        End If
    End Sub

    Private Sub SmalltalkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SmalltalkToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.SmallTalk)
        End If
    End Sub

    Private Sub SQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Sql)
        End If
    End Sub

    Private Sub VBScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VBScriptToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.VB)
        End If
    End Sub

    Private Sub XMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMLToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Xml)
        End If
    End Sub

    Private Sub YAMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YAMLToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.Yaml)
        End If
    End Sub

    Private Sub PlainTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlainTextToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.PlainText)
        End If
    End Sub

    Private Sub CustomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetLanguage(EditorLanguage.CustomLanguage)
        End If
    End Sub

#End Region

#Region "Project"

    Private Sub ProjectToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ProjectToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub ProjectToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles ProjectToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            ProjectToolStripMenuItem.ShowDropDown()
        End If
    End Sub

    Private Sub ProjectInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectInformationToolStripMenuItem.Click
        If ptype = ProjType.Project Then
            Dim newb As New frmProjectInfo
            newb.Show()
        End If
    End Sub

    Private Sub OpenProjectFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenProjectFolderToolStripMenuItem.Click
        System.Diagnostics.Process.Start("Explorer.exe", My.Settings.temp_projlocation)
    End Sub

    Private Sub ImportFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFileToolStripMenuItem.Click
        If ptype = ProjType.Project Then
            Dim newb As New OpenFileDialog
            newb.Title = "Import File"
            newb.Filter = GetFileFilter()
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim ofile As String = Path.GetFileName(newb.FileName)
                Dim nfile As String = My.Settings.temp_projlocation + "\Files\" + ofile
                System.IO.File.Copy(newb.FileName, My.Settings.temp_projlocation + "\Files\" + ofile)
                'Tabs.AddCode(My.Computer.FileSystem.ReadAllText(newb.FileName), LanguageEnum.ConvertExtensionToLanguage(Path.GetExtension(newb.FileName)), Path.GetFileName(newb.FileName), newb.FileName)
                'ProjectWriter.AddFile(Path.GetFileName(newb.FileName), LanguageEnum.ConvertExtensionToLanguage(Path.GetExtension(newb.FileName)), newb.FileName)
                ProjectWriter.AddFile(Path.GetFileName(nfile), LanguageEnum.ConvertExtensionToEnum(Path.GetExtension(nfile)))
                Tabs.AddCode(nfile)
                Logger.Write(Logger.TypeOfLog.Studio, "Importing file " & Path.GetFileName(newb.FileName) & " into project '" & ProjectReader.GetProjectName & "'")
            End If
        End If
    End Sub

    Private Sub CloseProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseProjectToolStripMenuItem.Click
        If ptype = ProjType.Project Then
            If MetroMessageBox.Show(Me, "Are you sure you want to close the current project? This will disable project mode and close any open project documents. If you have not saved these documents or your project, please do so before continuing.", "Close Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim pname As String = ProjectReader.GetProjectName
                CloseProject()
                MetroMessageBox.Show(Me, "Closed Project '" & pname & "'!")
                Logger.Write(Logger.TypeOfLog.Studio, "Closing project '" & pname & "'")
            End If
        End If
    End Sub

#End Region

#Region "Tools"

    Private Sub ToolsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub ToolsToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            ToolsToolStripMenuItem.ShowDropDown()
        End If
    End Sub

#Region "Encrypt++"

    Private Sub EncryptProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptProjectToolStripMenuItem.Click
        If GetPType() = ProjType.Project Then
            EncryptManager.EncryptProject(My.Settings.temp_projlocation)
            ShowEncryptAlert("Encrypted project '" & ProjectReader.GetProjectName & "'", 2000)
        End If
    End Sub

    Private Sub DecryptProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptProjectToolStripMenuItem.Click
        If GetPType() = ProjType.Project Then
            EncryptManager.DecryptProject(My.Settings.temp_projlocation)
            ShowEncryptAlert("Decrypted project '" & ProjectReader.GetProjectName & "'", 2000)
        End If
    End Sub

    Private Sub EncryptDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncryptDocumentToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsNotepad() Then
                EncryptManager.EncryptDocument(CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation)
                ShowEncryptAlert("Encrypted document " & CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileName(), 2000)
            ElseIf IsCodeEditor() Then
                EncryptManager.EncryptDocument(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
                ShowEncryptAlert("Encrypted document " & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName(), 2000)
            End If
        End If
    End Sub

    Private Sub DecryptDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecryptDocumentToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsNotepad() Then
                EncryptManager.DecryptDocument(CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation)
                ShowEncryptAlert("Decrypted document " & CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileName(), 2000)
            ElseIf IsCodeEditor() Then
                EncryptManager.DecryptDocument(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
                ShowEncryptAlert("Decrypted document " & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName(), 2000)
            End If
        End If
    End Sub

    Private Sub BrowseForFileToEncryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowseForFileToEncryptToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Title = "Select file(s) to encrypt"
        newb.Multiselect = True
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each s As String In newb.FileNames
                EncryptManager.EncryptDocument(s)
            Next
            ShowEncryptAlert("Encrypted selected files.", 2000)
        End If
    End Sub

    Private Sub BrowseForFileToDecryptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowseForFileToDecryptToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Title = "Select file(s) to decrypt"
        newb.Multiselect = True
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each s As String In newb.FileNames
                EncryptManager.DecryptDocument(s)
            Next
            ShowEncryptAlert("Decrypted selected files.", 2000)
        End If
    End Sub

#End Region

#Region "External"

#Region "Browser"

    Private Sub ClearAddonSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAddonSettingsToolStripMenuItem.Click
        If MetroMessageBox.Show(Me, "Are you sure you want to clear addon settings?", "Clear Addon Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 4351", AppWinStyle.Hide)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub ClearCookiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearCookiesToolStripMenuItem.Click
        If MetroMessageBox.Show(Me, "Are you sure you want to clear the cookies?", "Clear Cookies", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 2", AppWinStyle.Hide)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub ClearFormDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearFormDataToolStripMenuItem.Click
        If MetroMessageBox.Show(Me, "Are you sure you want to clear form data?", "Clear Form Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 16", AppWinStyle.Hide)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub ClearHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearHistoryToolStripMenuItem.Click
        If MetroMessageBox.Show(Me, "Are you sure you want to clear the history?", "Clear History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 1", AppWinStyle.Hide)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub ClearSavedPasswordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearSavedPasswordsToolStripMenuItem.Click
        If MetroMessageBox.Show(Me, "Are you sure you want to clear saved passwords?", "Clear Saved Passwords", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 32", AppWinStyle.Hide)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub ClearAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem1.Click
        If MetroMessageBox.Show(Me, "Are you sure you want to clear all data?", "Clear All Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 255", AppWinStyle.Hide)
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

#End Region

#Region "Launch Process"

    'Dim a As String = InputBox("Enter the process/file you want to start.", "Process", "")
    'If a IsNot "" Then
    '    Dim b As String = InputBox("Enter any parameters (if any) you wish to launch with.", "Parameters", "")
    '    Try
    '        Dim process = New Process()
    '        process.StartInfo.FileName = a
    '        process.StartInfo.Arguments = b
    '        process.StartInfo.UseShellExecute = False
    '        process.StartInfo.RedirectStandardOutput = True
    '        process.StartInfo.RedirectStandardError = True
    '        'Process.StartInfo.RedirectStandardInput = True
    '        process.Start()
    '        Dim outputReader As StreamReader = process.StandardOutput
    '        Dim errorReader As StreamReader = process.StandardError
    '        Tabs.AddNotepad("-----------OUTPUT FOR " & a & "-----------" & vbNewLine & outputReader.ReadToEnd() & vbNewLine & "-----------ERRORS-----------" & vbNewLine & errorReader.ReadToEnd())
    '        process.WaitForExit()
    '    Catch ex As Exception
    '        Logger.WriteError(Logger.TypeOfLog.Studio, ex)
    '    End Try
    'End If

    Private Sub WithParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithParametersToolStripMenuItem.Click
        Dim a As String = InputBox("Enter the process/file you want to start.", "Process", "")
        If a IsNot "" Then
            Dim b As String = InputBox("Enter any parameters you wish to launch with.", "Parameters", "")
            Try
                Dim process = New Process()
                process.StartInfo.FileName = a
                process.StartInfo.Arguments = b
                process.StartInfo.UseShellExecute = False
                'process.StartInfo.RedirectStandardOutput = True
                'process.StartInfo.RedirectStandardError = True
                'Process.StartInfo.RedirectStandardInput = True
                process.Start()
                'Dim outputReader As StreamReader = process.StandardOutput
                'Dim errorReader As StreamReader = process.StandardError
                'Tabs.AddNotepad("-----------OUTPUT FOR " & a & "-----------" & vbNewLine & outputReader.ReadToEnd() & vbNewLine & "-----------ERRORS-----------" & vbNewLine & errorReader.ReadToEnd())
                process.WaitForExit()
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub WithoutParametersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WithoutParametersToolStripMenuItem.Click
        Dim a As String = InputBox("Enter the process/file you want to start.", "Process", "")
        If a IsNot "" Then
            Try
                Dim process = New Process()
                process.StartInfo.FileName = a
                process.StartInfo.Arguments = ""
                process.StartInfo.UseShellExecute = False
                'process.StartInfo.RedirectStandardOutput = True
                'process.StartInfo.RedirectStandardError = True
                'Process.StartInfo.RedirectStandardInput = True
                process.Start()
                'Dim outputReader As StreamReader = process.StandardOutput
                'Dim errorReader As StreamReader = process.StandardError
                'Tabs.AddNotepad("-----------OUTPUT FOR " & a & "-----------" & vbNewLine & outputReader.ReadToEnd() & vbNewLine & "-----------ERRORS-----------" & vbNewLine & errorReader.ReadToEnd())
                process.WaitForExit()
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

#End Region

    Private Sub PerformanceMonitorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerformanceMonitorToolStripMenuItem.Click
        System.Diagnostics.Process.Start("perfmon.exe")
    End Sub

    Private Sub SystemConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemConfigurationToolStripMenuItem.Click
        System.Diagnostics.Process.Start("msconfig.exe")
    End Sub

    Private Sub SystemInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemInformationToolStripMenuItem.Click
        System.Diagnostics.Process.Start("msinfo32.exe")
    End Sub

    Private Sub ColorManagementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorManagementToolStripMenuItem.Click
        System.Diagnostics.Process.Start("colorcpl.exe")
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculatorToolStripMenuItem.Click
        System.Diagnostics.Process.Start("calc.exe")
    End Sub

    Private Sub RegistryEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistryEditorToolStripMenuItem.Click
        System.Diagnostics.Process.Start("regedit.exe")
    End Sub
    Private Sub CommandPromptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommandPromptToolStripMenuItem.Click
        System.Diagnostics.Process.Start("cmd")
    End Sub

    Private Sub OnScreenKeyboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnScreenKeyboardToolStripMenuItem.Click
        System.Diagnostics.Process.Start("osk.exe")
    End Sub

#End Region

#Region "Backup++"

    Private Sub OpenBackupsLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenBackupsLocationToolStripMenuItem.Click
        If My.Settings.set_backupsloc = "DEFAULT" Then
            System.Diagnostics.Process.Start("Explorer.exe", XDev.Path.Locator.GetWorkspacePath + "\Backups")
        Else
            System.Diagnostics.Process.Start("Explorer.exe", My.Settings.set_backupsloc)
        End If
    End Sub

    Private Sub AutomaticBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutomaticBackupToolStripMenuItem.Click
        If AutomaticBackupToolStripMenuItem.Checked = False Then
            AutomaticBackupToolStripMenuItem.Checked = True
            My.Settings.set_autobackup = True
            BackupTimer.Enabled = True
        Else
            AutomaticBackupToolStripMenuItem.Checked = False
            My.Settings.set_autobackup = False
            BackupTimer.Enabled = False
        End If
    End Sub

    Private Sub BackupProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupProjectToolStripMenuItem.Click
        If GetPType() = ProjType.Project Then
            BackupManager.BackupProject(My.Settings.temp_projlocation)
            ShowBackupAlert("Created a backup of project '" & ProjectReader.GetProjectName & "'", 2000)
        End If
    End Sub

    Private Sub BackupDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupDocumentToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsNotepad() Then
                BackupManager.BackupFile(CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation)
                ShowBackupAlert("Created a backup of document " & CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileName(), 2000)
            ElseIf IsCodeEditor() Then
                BackupManager.BackupFile(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
                ShowBackupAlert("Created a backup of document " & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName(), 2000)
            End If
        End If
    End Sub

    Private Sub RestoreDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreDocumentToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsNotepad() Then
                If MetroMessageBox.Show(Me, "Are you sure you want to restore this document with one from a backup? This will replace the current file.", "Backup++", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    BackupManager.RestoreFile(CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation)
                End If
            ElseIf IsCodeEditor() Then
                If MetroMessageBox.Show(Me, "Are you sure you want to restore this document with one from a backup? This will replace the current file.", "Backup++", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    BackupManager.RestoreFile(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
                End If
            End If
        End If
    End Sub

    Private Sub RestoreProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreProjectToolStripMenuItem.Click
        If GetPType() = ProjType.Project Then
            If MetroMessageBox.Show(Me, "Are you sure you want to restore this project with one from a backup? This will replace the current project.", "Backup++", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                BackupManager.RestoreProject(My.Settings.temp_projlocation)
            End If
        End If
    End Sub

#End Region

#Region "Voice++"

    Private Sub StartCommandRecognitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartCommandRecognitionToolStripMenuItem.Click
        SpeechEngine.StartDetectingCommands()
    End Sub

    Private Sub StopCommandRecognitionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopCommandRecognitionToolStripMenuItem.Click
        SpeechEngine.StopDetectingCommands()
    End Sub

    Private Sub StartDictationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartDictationToolStripMenuItem.Click
        SpeechEngine.StartDictation()
    End Sub

    Private Sub StopDictationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopDictationToolStripMenuItem.Click
        SpeechEngine.StopDictation()
    End Sub

#End Region

#Region "Macro"

    Private Sub StartRecordingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartRecordingToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).StartRecordingMacro()
        End If
    End Sub

    Private Sub StopRecordingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopRecordingToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).StopRecordingMacro()
        End If
    End Sub

    Private Sub RunMacroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunMacroToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro()
        End If
    End Sub

#Region "Multiple Times"

    Private Sub XTimesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XTimesToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim b As String = InputBox("Enter the amount of times you want to run the macro.", "Run Macro X Times", "")
            If b <> "" Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(b)
            End If
        End If

    End Sub

    Private Sub TimesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(2)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem1.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(3)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem2.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(4)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem3.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(5)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem4.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(6)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem5.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(7)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem6.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(8)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem7.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(9)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem8.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(10)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem9.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(15)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem10.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(20)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem11.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(25)
        End If
    End Sub

    Private Sub TimesToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles TimesToolStripMenuItem12.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunMacro(30)
        End If
    End Sub

#End Region

#End Region

#Region "Imaging/Graphics"

    Private Sub MapperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MapperToolStripMenuItem.Click
        Tabs.AddImageMapper()
    End Sub

    Private Sub ColorPickerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorPickerToolStripMenuItem.Click
        Dim newb As New frmColorPicker
        newb.Show()
    End Sub

    Private Sub ImageViewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImageViewerToolStripMenuItem.Click
        pnlImageViewer.ShowPanel(DockPanel1, DockState.DockRight)
    End Sub

#End Region

#Region "Functions"

#Region "Math"

    Private Sub SinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SinToolStripMenuItem.Click
        Dim b As String = InputBox("Enter an angle.", "Sin", "")
        If b <> "" Then
            Try
                Dim result As Double = Math.Sin(b)
                If MetroMessageBox.Show(Me, "Result: [" & result.ToString & "] Copy to clipboard?", "Functions:Math:Sin", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    My.Computer.Clipboard.SetText(result.ToString)
                End If
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub CosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CosToolStripMenuItem.Click
        Dim b As String = InputBox("Enter an angle.", "Cos", "")
        If b <> "" Then
            Try
                Dim result As Double = Math.Cos(b)
                If MetroMessageBox.Show(Me, "Result: [" & result.ToString & "] Copy to clipboard?", "Functions:Math:Cos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    My.Computer.Clipboard.SetText(result.ToString)
                End If
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub TanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TanToolStripMenuItem.Click
        Dim b As String = InputBox("Enter an angle.", "Tan", "")
        If b <> "" Then
            Try
                Dim result As Double = Math.Tan(b)
                If MetroMessageBox.Show(Me, "Result: [" & result.ToString & "] Copy to clipboard?", "Functions:Math:Tan", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    My.Computer.Clipboard.SetText(result.ToString)
                End If
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Private Sub SqrtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SqrtToolStripMenuItem.Click
        Dim b As String = InputBox("Enter a number.", "SQRT", "")
        If b <> "" Then
            Try
                Dim result As Double = Math.Sqrt(b)
                If MetroMessageBox.Show(Me, "Result: [" & result.ToString & "] Copy to clipboard?", "Functions:Math:SQRT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                    My.Computer.Clipboard.SetText(result.ToString)
                End If
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

#End Region

#End Region

#Region "Languages"

#Region "VB/C#"

#Region "References"

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.FileName = "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Windows.Forms.dll"
            OpenFileDialog.Filter = "Dynamic Link Libraries (*.dll)|*.dll"
            If OpenFileDialog.ShowDialog = DialogResult.OK Then
                Dim asm As Assembly = Assembly.LoadFile(OpenFileDialog.FileName)
                If Not CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetNetAssemblies.IndexOf(LCase(asm.Location)) = -1 Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).AddToNetAssemblies(LCase(asm.Location))
                Else
                    MetroMessageBox.Show(Me, "This document already contains this reference!", "Duplicate Reference", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If IsCodeEditor() Then
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.Filter = "Dynamic Link Libraries (*.dll)|*.dll"
            If OpenFileDialog.ShowDialog = DialogResult.OK Then
                Dim asm As Assembly = Assembly.LoadFile(OpenFileDialog.FileName)
                If Not CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetNetAssemblies.IndexOf(LCase(asm.Location)) = -1 Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RemoveFromNetAssemblies(LCase(asm.Location))
                Else
                    MetroMessageBox.Show(Me, "This document does not contain this reference.", "Invalid Reference", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub ViewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem1.Click
        If IsCodeEditor() Then
            Dim msg As String = ""
            Dim b As List(Of String) = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetNetAssemblies
            For I = 0 To b.Count - 1
                msg = msg & b(I) & vbCrLf & "======================" & vbCrLf
            Next
            MetroMessageBox.Show(Me, msg, "Referenced Assemblies", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#Region "Compile As"

    Private Sub ConsoleApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsoleApplicationToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetCompileAsWinForms(False)
            ConsoleApplicationToolStripMenuItem.Checked = True
            WinFormsApplicationToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub WinFormsApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WinFormsApplicationToolStripMenuItem.Click
        If IsCodeEditor() Then

            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).SetCompileAsWinForms(True)
            ConsoleApplicationToolStripMenuItem.Checked = False
            WinFormsApplicationToolStripMenuItem.Checked = True
        End If
    End Sub

#End Region

    Private Sub FixVBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixVBToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text = LanguageFormatter.FixVB2(LanguageFormatter.FixVB(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text))
        End If
    End Sub

    Private Sub FixCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixCToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text = LanguageFormatter.FixCS(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text)
        End If
    End Sub

    Private Sub NetConverterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NetConverterToolStripMenuItem.Click
        Tabs.AddNetConverter()
    End Sub

#End Region

#Region "HTML"

    Private Sub ProtectHTMLCodeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProtectHTMLCodeToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text = HTMLProtector.ProtectHTML(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text)
        End If
    End Sub

    Private Sub UnprotectHTMLCodeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UnprotectHTMLCodeToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text = HTMLProtector.UnprotectHTML(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text)
        End If
    End Sub

#End Region

#Region "XML"

#Region "Refactor"

#Region "Beautify"

    Private Sub SelectionToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem9.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).BeautifyXML(True)
        End If
    End Sub

    Private Sub EntireDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntireDocumentToolStripMenuItem.Click
        If IsCodeEditor() Then
            CType(DockPanel1.ActiveDocument, Tab_CodeEditor).BeautifyXML(False)
        End If
    End Sub

#End Region

#End Region

#End Region

#Region "Markdown"

    Private Sub ConvertToHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertToHTMLToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text <> "" Then
                Dim bb As String = Ozone.Markdown.Parser.ParseMarkdown(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text)
                My.Computer.Clipboard.SetText(bb)
                If MetroMessageBox.Show(Me, "Markdown exported to HTML and copied to clipboard! Do you want to load it in a new tab?", "Markdown", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Tabs.AddCodeWithoutFile(bb)
                End If
            End If
        End If
    End Sub

    Private Sub PreviewInBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewInBrowserToolStripMenuItem.Click
        If IsCodeEditor() Then
            If CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text <> "" Then
                Tabs.AddTestBrowser("Preview Markdown", "", Ozone.Markdown.Parser.ParseMarkdown(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text))
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Other"

#Region "Clear Data"

    Private Sub EmptyRecycleBinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmptyRecycleBinToolStripMenuItem.Click
        If MetroMessageBox.Show(Me, "Are you sure you want to empty the recycle bin?", "Empty Recycle Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            EmptyRecycleBin()
        End If
    End Sub

    Private Sub ClearTempFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearTempFileToolStripMenuItem.Click
        If MetroMessageBox.Show(Me, "Are you sure you want to clear the temp file?", "Clear Temp File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 8 ", AppWinStyle.Hide)
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

#End Region

#Region "More"

    Private Sub FileHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileHistoryToolStripMenuItem.Click
        Tabs.AddFileHistory()
    End Sub

    Private Sub TaskSchedulerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaskSchedulerToolStripMenuItem.Click
        Tabs.AddTaskScheduler()
    End Sub

    Private Sub HexViewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HexViewerToolStripMenuItem.Click
        Tabs.AddHexViewer()
    End Sub

    Private Sub WYSIWYGEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WYSIWYGEditorToolStripMenuItem.Click
        Tabs.AddWYSIWYGEditor()
    End Sub

    Private Sub CodeBankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodeBankToolStripMenuItem.Click
        Tabs.AddCodeBank()
    End Sub

    Private Sub DiagrammerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiagrammerToolStripMenuItem.Click
        Tabs.AddDiagrammer()
    End Sub

    Private Sub CodeRecoveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodeRecoveryToolStripMenuItem.Click
        Tabs.AddCodeRecovery()
    End Sub

    Private Sub SitePreviewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SitePreviewerToolStripMenuItem.Click
        Dim newb As New frmSitePreviewer
        newb.Show()
    End Sub

    Private Sub RSSReaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RSSReaderToolStripMenuItem.Click
        Tabs.AddRSSReader()
    End Sub

    Private Sub ServiceViewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceViewerToolStripMenuItem.Click
        Tabs.AddServiceViewer()
    End Sub

#End Region

#Region "Document"

    Private Sub OpenDocumentLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDocumentLocationToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                Try
                    System.Diagnostics.Process.Start("Explorer.exe", Path.GetDirectoryName(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation()))
                Catch ex As Exception
                    Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                End Try
            ElseIf IsNotepad() Then
                Try
                    System.Diagnostics.Process.Start("Explorer.exe", Path.GetDirectoryName(CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation()))
                Catch ex As Exception
                    Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                End Try
            End If
        End If
    End Sub

    Private Sub ViewDocumentInLiveBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDocumentInLiveBrowserToolStripMenuItem.Click
        If livebrowser Is Nothing Then
            livebrowser = New pnlLiveBrowser
        End If
        If IsCodeEditor() Then
            If livebrowser.Visible Then
                livebrowser.SetEditor(DockPanel1.ActiveDocument)
            Else
                livebrowser.Show(DockPanel1, DockState.DockBottom)
                livebrowser.SetEditor(DockPanel1.ActiveDocument)
            End If
        End If
    End Sub

    Private Sub ReloadDocumentFromFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadDocumentFromFileToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                If MetroMessageBox.Show(Me, "Are you sure you want to reload the document from its source? You will lose any unsaved changes.", "Reload Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).LoadFile(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
                End If
            End If
        End If
    End Sub

#End Region

#Region "XDev Script"

    Private Sub OpenAndRunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenAndRunToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Title = "Open XDev Script to run"
        newb.Filter = "XDev Script File (*.xds)|*.xds|All Files (*.*)|*.*"
        newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath & "\Scripts"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            XDevScriptRunner.RunScript(newb.FileName)
        End If
    End Sub

    Private Sub RunFromCurrentEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunFromCurrentEditorToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                XDevScriptRunner.RunScript(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
            End If
        End If
    End Sub

#End Region

    Private Sub LockStudioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LockStudioToolStripMenuItem.Click
        LockStudio()
    End Sub

    Private Sub DifferenceViewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DifferenceViewerToolStripMenuItem.Click
        Tabs.AddDifferenceViewer()
    End Sub

    Private Sub LargeFileEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LargeFileEditorToolStripMenuItem.Click
        Tabs.AddLargeFileEditor()
    End Sub

    Private Sub UniversalSearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UniversalSearchToolStripMenuItem.Click
        Tabs.AddUniversalSearch()
    End Sub

    Private Sub CodeMetricsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodeMetricsToolStripMenuItem.Click
        Tabs.AddCodeMetrics()
    End Sub

    Private Sub FileDownloaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileDownloaderToolStripMenuItem.Click
        Tabs.AddFileDownloader()
    End Sub

    Private Sub WebBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebBrowserToolStripMenuItem.Click
        Tabs.AddWebBrowser()
    End Sub

    Private Sub NotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotepadToolStripMenuItem.Click
        Tabs.AddNotepad()
    End Sub

    Private Sub CalendarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalendarToolStripMenuItem.Click
        Tabs.AddCalendar()
    End Sub

    'Private Sub ExportToHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToHTMLToolStripMenuItem.Click
    '    If IsCodeEditor() Then
    '        Dim b As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().ExportHtml
    '        My.Computer.Clipboard.SetText(b)
    '        If MetroMessageBox.Show(Me, "Code exported to HTML and copied to the clipboard! Open in new editor?", "Export to HTML", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
    '            Tabs.AddCode(b, "html")
    '        End If
    '    End If
    'End Sub

    Private Sub ProcessViewerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcessViewerToolStripMenuItem.Click
        Tabs.AddProcessViewer()
    End Sub

#End Region

#Region "Apps"

    Private Sub AppsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles AppsToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub AppsToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles AppsToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            AppsToolStripMenuItem.ShowDropDown()
        End If
    End Sub

    Private Sub ManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem.Click
        Tabs.AddAppManager()
    End Sub

#End Region

#Region "Run"

    Private Sub RunToolStripMenuItem3_DropDownOpening(sender As Object, e As EventArgs) Handles RunToolStripMenuItem3.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub RunToolStripMenuItem3_MouseHover(sender As Object, e As EventArgs) Handles RunToolStripMenuItem3.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            RunToolStripMenuItem3.ShowDropDown()
        End If
    End Sub

#Region "File"

    Private Sub NormalToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NormalToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunFile()
            End If
        End If
    End Sub

    Private Sub RedirectOutputToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RedirectOutputToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunFile(True, "")
            End If
        End If
    End Sub

#End Region

#Region "HTML"

    Private Sub TestFileInBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestFileInBrowserToolStripMenuItem.Click
        Try
            If CheckIfDocumentSaved(True) Then
                If IsCodeEditor() Then
                    Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation
                    Tabs.AddTestBrowser("Browser - " & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName, s, "")
                End If
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub TestCodeInBrowserToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TestCodeInBrowserToolStripMenuItem.Click
        Try
            If IsCodeEditor() Then
                Dim s As String = CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text
                Tabs.AddTestBrowser("Browser - " & CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileName, "", s)
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

#End Region

#Region "Java"

    Private Sub CompileToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CompileToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileJavaCode(False)
            End If
        End If
    End Sub

    Private Sub RunToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RunToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunJavaCode()
            End If
        End If
    End Sub

    Private Sub CompileRunToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CompileRunToolStripMenuItem1.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileJavaCode(True)
            End If
        End If
    End Sub

#End Region

#Region "C"

    Private Sub CompileToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles CompileToolStripMenuItem1.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileCCode(False)
            End If
        End If
    End Sub

    Private Sub RunToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles RunToolStripMenuItem1.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunCCode()
            End If
        End If
    End Sub

    Private Sub CompileRunToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CompileRunToolStripMenuItem2.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileCCode(True)
            End If
        End If
    End Sub

#End Region

#Region "C++"

    Private Sub CompileToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CompileToolStripMenuItem2.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileCPPCode(False)
            End If
        End If
    End Sub

    Private Sub RunToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem2.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunCPPCode()
            End If
        End If
    End Sub

    Private Sub CompileRunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompileRunToolStripMenuItem.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileCPPCode(True)
            End If
        End If
    End Sub

#End Region

#Region "VB"

    Private Sub CompileToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles CompileToolStripMenuItem4.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileVBCode(False)
            End If
        End If
    End Sub

    Private Sub RunToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem5.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunVBCode()
            End If
        End If
    End Sub

    Private Sub CompileRunToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CompileRunToolStripMenuItem3.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileVBCode(True)
            End If
        End If
    End Sub

#End Region

#Region "C#"

    Private Sub CompileToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles CompileToolStripMenuItem5.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileCSharpCode(False)
            End If
        End If
    End Sub

    Private Sub RunToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem6.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunCSharpCode()
            End If
        End If
    End Sub

    Private Sub CompileRunToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles CompileRunToolStripMenuItem4.Click
        If CheckIfDocumentSaved(True) Then
            If IsCodeEditor() Then
                CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileCSharpCode(True)
            End If
        End If
    End Sub

#End Region

#Region "Custom Compiler"

    Private Sub CompileToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CompileToolStripMenuItem3.Click
        If My.Settings.set_customcompilerenabled Then
            If CheckIfDocumentSaved(True) Then
                If IsCodeEditor() Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileCustomCode(False)
                End If
            End If
        End If
    End Sub

    Private Sub RunToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem4.Click
        If My.Settings.set_customcompilerenabled Then
            If CheckIfDocumentSaved(True) Then
                If IsCodeEditor() Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).RunCustomCode()
                End If
            End If
        End If
    End Sub

    Private Sub CompileRunToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles CompileRunToolStripMenuItem5.Click
        If My.Settings.set_customcompilerenabled Then
            If CheckIfDocumentSaved(True) Then
                If IsCodeEditor() Then
                    CType(DockPanel1.ActiveDocument, Tab_CodeEditor).CompileCustomCode(True)
                End If
            End If
        End If
    End Sub

#End Region

#End Region

#Region "Window"

    Private Sub WindowToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles WindowToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub WindowToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles WindowToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            WindowToolStripMenuItem.ShowDropDown()
        End If
    End Sub

#Region "Tabs"

    Private Sub CloseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        CloseAllTabs()
    End Sub

    Private Sub CloseAllExceptCurrentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllExceptCurrentToolStripMenuItem.Click
        CloseAllTabsExceptCurrent()
    End Sub

    Private Sub CloseCurrentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseCurrentToolStripMenuItem.Click
        If AtLeastOneTab() Then
            DockPanel1.ActiveDocument.DockHandler.Close()
        End If
    End Sub

    'Private Sub CloseAllToRightOfCurrentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllToRightOfCurrentToolStripMenuItem.Click
    '    CloseAllTabsToRightOfCurrent()
    'End Sub

    'Private Sub CloseAllToLeftOfCurrentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllToLeftOfCurrentToolStripMenuItem.Click
    '    CloseAllTabsToLeftOfCurrent()
    'End Sub

#End Region

#Region "Opacity"

    Private Sub ClearOpacityChecks()
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = False
        ToolStripMenuItem6.Checked = False
        ToolStripMenuItem7.Checked = False
        ToolStripMenuItem8.Checked = False
        ToolStripMenuItem9.Checked = False
        ToolStripMenuItem10.Checked = False
        ToolStripMenuItem11.Checked = False
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        ClearOpacityChecks()
        ToolStripMenuItem2.Checked = True
        Me.Opacity = 1
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        ClearOpacityChecks()
        ToolStripMenuItem3.Checked = True
        Me.Opacity = 0.9
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        ClearOpacityChecks()
        ToolStripMenuItem4.Checked = True
        Me.Opacity = 0.8
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        ClearOpacityChecks()
        ToolStripMenuItem5.Checked = True
        Me.Opacity = 0.7
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        ClearOpacityChecks()
        ToolStripMenuItem6.Checked = True
        Me.Opacity = 0.6
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        ClearOpacityChecks()
        ToolStripMenuItem7.Checked = True
        Me.Opacity = 0.5
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        ClearOpacityChecks()
        ToolStripMenuItem8.Checked = True
        Me.Opacity = 0.4
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        ClearOpacityChecks()
        ToolStripMenuItem9.Checked = True
        Me.Opacity = 0.3
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        ClearOpacityChecks()
        ToolStripMenuItem10.Checked = True
        Me.Opacity = 0.2
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        ClearOpacityChecks()
        ToolStripMenuItem11.Checked = True
        Me.Opacity = 0.1
    End Sub

#End Region

    Private Sub QuickCommandToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuickCommandToolStripMenuItem.Click
        frmQuickCommand.Show()
    End Sub

    Private Sub SpeedDialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeedDialToolStripMenuItem.Click
        Dim newb As New frmSpeedDial
        newb.ShowDialog()
    End Sub

    Private Sub WindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WindowsToolStripMenuItem.Click
        Dim newb As New frmWindows
        newb.Show()
    End Sub

    Private Sub ToolbarsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolbarsToolStripMenuItem.Click
        pnlToolbars.Show(DockPanel1, DockState.DockTop, New Rectangle(pnlToolbars.Location, New Size(800, 90)))
        My.Settings.set_toolbarsvisible = True
    End Sub

    Private Sub FullscreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullscreenToolStripMenuItem.Click
        If AreSameImage(FullscreenToolStripMenuItem.Image, My.Resources._32_fullscreen) Then
            Fullscreen()
        Else
            ExitFullscreen()
        End If
    End Sub

    Private Sub TopmostToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TopmostToolStripMenuItem1.Click
        If Me.TopMost = False Then
            Me.TopMost = True
            TopmostToolStripMenuItem1.Checked = True
        Else
            Me.TopMost = False
            TopmostToolStripMenuItem1.Checked = False
        End If
    End Sub

    Private Sub DistractionFreeModeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DistractionFreeModeToolStripMenuItem.Click
        If distractionfreemode Then
            ExitDistractionFreeMode()
        Else
            EnterDistractionFreeMode()
        End If
    End Sub

#End Region

#Region "About"

    Private Sub AboutToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.DropDownOpening
        UpdateMenuItems()
    End Sub

    Private Sub AboutToolStripMenuItem_MouseHover(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.MouseHover
        If My.Settings.set_menustrip_mousehover Then
            AboutToolStripMenuItem.ShowDropDown()
        End If
    End Sub

    Private Sub TerminalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerminalToolStripMenuItem.Click
        Tabs.AddStudioTerminal()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        Tabs.AddOptions()
    End Sub

    Private Sub LocalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocalToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start(XDev.Path.Locator.GetAppPath + "\Documentation.chm")
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub WebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebToolStripMenuItem.Click
        Tabs.AddWebDocumentation()
    End Sub

    Private Sub ReportABugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportABugToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("https://github.com/theryan722/XDev-Studio/issues")
        Catch
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        Dim newb As New frmAbout
        newb.ShowDialog()
    End Sub

    Private Sub GithubToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GithubToolStripMenuItem1.Click
        System.Diagnostics.Process.Start("https://github.com/theryan722/XDev-Studio")
    End Sub

#End Region

#End Region

#Region "txt_search"

    Private Sub txt_search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_search.KeyDown
        If e.KeyCode = Keys.Enter And txt_search.Text <> "" And txt_search.Text <> " " And AtLeastOneCodeEditor() Then
            Tabs.AddUniversalSearch(txt_search.Text, Tabs.UniversalSearchType.OpenDocuments)
            txt_search.Clear()
        End If
    End Sub


#End Region

    Private Sub btn_profile_Click(sender As Object, e As EventArgs) Handles btn_profile.Click
        If CurrentProfile.Name <> "" Then
            frmProfileInfo.Show()
        Else
            frmProfileSelect.Show()
        End If
    End Sub

#End Region

#Region "DockPanel"

    Private Sub DockPanel1_ActiveDocumentChanged(sender As Object, e As EventArgs) Handles DockPanel1.ActiveDocumentChanged
        UpdateMenuItems()
    End Sub

    Private Sub DockPanel1_ContentRemoved(sender As Object, e As DockContentEventArgs) Handles DockPanel1.ContentRemoved
        If AtLeastOneTab() = False Then
            If My.Settings.set_actionifnotabs = 0 Then
                'do nothing
            ElseIf My.Settings.set_actionifnotabs = 1 Then
                Tabs.AddCode()
            ElseIf My.Settings.set_actionifnotabs = 2 Then
                ExitToolStripMenuItem.PerformClick()
            End If
        End If
    End Sub

#End Region

#Region "Tray Icons"

#Region "Encrypt++"

    Private Sub EncryptNotifyIcon_BalloonTipClicked(sender As Object, e As EventArgs) Handles EncryptNotifyIcon.BalloonTipClicked
        If CheckIfDocumentSaved(True) Then
            If IsNotepad() Then
                System.Diagnostics.Process.Start("Explorer.exe", CType(DockPanel1.ActiveDocument, Tab_Notepad).GetFileLocation)
            ElseIf IsCodeEditor() Then
                System.Diagnostics.Process.Start("Explorer.exe", CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation)
            End If
        End If
        EncryptNotifyIcon.Visible = False
    End Sub

    Private Sub EncryptNotifyIcon_BalloonTipClosed(sender As Object, e As EventArgs) Handles EncryptNotifyIcon.BalloonTipClosed
        EncryptNotifyIcon.Visible = False
    End Sub

#End Region

#Region "Backup++"

    Private Sub BackupNotifyIcon_BalloonTipClicked(sender As Object, e As EventArgs) Handles BackupNotifyIcon.BalloonTipClicked
        OpenBackupsLocationToolStripMenuItem.PerformClick()
        BackupNotifyIcon.Visible = False
    End Sub

    Private Sub BackupNotifyIcon_BalloonTipClosed(sender As Object, e As EventArgs) Handles BackupNotifyIcon.BalloonTipClosed
        BackupNotifyIcon.Visible = False
    End Sub

#End Region

#Region "XDev Studio Tray Icon"

#Region "Backup++"
    Private Sub BackupProjectToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BackupProjectToolStripMenuItem1.Click
        BackupProjectToolStripMenuItem.PerformClick()
    End Sub

    Private Sub BackupDocumentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BackupDocumentToolStripMenuItem1.Click
        BackupDocumentToolStripMenuItem.PerformClick()
    End Sub

    Private Sub OpenBackupsLocationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenBackupsLocationToolStripMenuItem1.Click
        OpenBackupsLocationToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Voice++"

    Private Sub StartCommandRecognitionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StartCommandRecognitionToolStripMenuItem1.Click
        StartCommandRecognitionToolStripMenuItem.PerformClick()
    End Sub

    Private Sub StopCommandRecognitionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StopCommandRecognitionToolStripMenuItem1.Click
        StopCommandRecognitionToolStripMenuItem.PerformClick()
    End Sub

    Private Sub StartDictationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StartDictationToolStripMenuItem1.Click
        StartDictationToolStripMenuItem.PerformClick()
    End Sub

    Private Sub StopDictationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles StopDictationToolStripMenuItem1.Click
        StopDictationToolStripMenuItem.PerformClick()
    End Sub

#End Region

    Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick
        NotifyIcon1.ContextMenuStrip.Show(New Point(MousePosition.X, MousePosition.Y))
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ShowToolStripMenuItem.PerformClick()
    End Sub

    Private Sub AddTaskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddTaskToolStripMenuItem.Click
        Dim toadd As String = InputBox("Please enter a new task.", "New Task", "")
        If toadd = "" Then
            'do nothing
        Else
            My.Settings.set_tasklisttodo.Add(toadd)
            MsgBox("Task Added!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "New Task")
        End If
    End Sub

    Private Sub ViewTasksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTasksToolStripMenuItem.Click
        Tabs.AddTasks()
        ShowToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        ExitToolStripMenuItem.PerformClick()
    End Sub

    Private Sub TopmostToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopmostToolStripMenuItem.Click
        TopmostToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()
        Me.Focus()
        If Me.WindowState = FormWindowState.Minimized Then
            If winstate = 1 Then
                Me.WindowState = FormWindowState.Maximized
            ElseIf winstate = 0 Then
                Me.WindowState = FormWindowState.Normal
            Else
                Me.WindowState = FormWindowState.Normal
            End If
        End If
    End Sub

    Private Sub NewInstanceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NewInstanceToolStripMenuItem1.Click
        NewInstanceToolStripMenuItem.PerformClick()
    End Sub

#End Region

#End Region

#Region "Timers"

#Region "Code Recovery"

    Private Sub CodeRecoveryTimer_Tick(sender As Object, e As EventArgs) Handles CodeRecoveryTimer.Tick
        If Not My.Settings.temp_performancemode Then
            CodeRecovery.SaveSnapshotsForAllOpenDocuments()
        End If
    End Sub

#End Region

#Region "Backup"

    Private Sub BackupTimer_Tick(sender As Object, e As EventArgs) Handles BackupTimer.Tick
        If Not My.Settings.temp_performancemode Then
            If GetPType() = ProjType.Project Then
                BackupManager.BackupProject(My.Settings.temp_projlocation)
                ShowBackupAlert("Performed an automatic backup of project '" & ProjectReader.GetProjectName & "' Any files not part of this project were not backed up.", 2000)
            Else
                If tosave IsNot Nothing Then
                    tosave.Clear()
                End If
                For Each item As DockContent In DockPanel1.Documents
                    If IsCodeEditor(item) Then
                        If CType(item, Tab_CodeEditor).GetFileLocation() <> "" Then
                            tosave.Add(CType(item, Tab_CodeEditor).GetFileLocation())
                        End If
                    ElseIf IsNotepad(item) Then
                        If CType(item, Tab_Notepad).GetFileLocation() <> "" Then
                            tosave.Add(CType(item, Tab_Notepad).GetFileLocation())
                        End If
                    End If
                Next

                'DockPanel1.ActiveDocument.Focus()
                '----------------------
                If tosave.Count = 0 Then
                    For Each item As String In tosave
                        BackupManager.BackupFile(item)
                    Next
                    ShowBackupAlert("Performed an automatic backup of all open documents.", 2000)
                End If
            End If
        End If
    End Sub

#End Region

#Region "Encrypt"

    Private Sub EncryptTimer_Tick(sender As Object, e As EventArgs) Handles EncryptTimer.Tick
        If Not My.Settings.temp_performancemode Then
            If GetPType() = ProjType.Project Then
                EncryptManager.EncryptProject(My.Settings.temp_projlocation)
                ShowEncryptAlert("Performed an automatic encryption of project '" & ProjectReader.GetProjectName & "' Any files not a part of this project were not encrypted.", 2000)
            Else
                If toencrypt IsNot Nothing Then
                    toencrypt.Clear()
                End If
                For Each item As DockContent In DockPanel1.Documents
                    If IsCodeEditor(item) Then
                        If CType(item, Tab_CodeEditor).GetFileLocation() <> "" Then
                            toencrypt.Add(CType(item, Tab_CodeEditor).GetFileLocation())
                        End If
                    ElseIf IsNotepad(item) Then
                        If CType(item, Tab_Notepad).GetFileLocation() <> "" Then
                            toencrypt.Add(CType(item, Tab_Notepad).GetFileLocation())
                        End If
                    End If
                Next

                'DockPanel1.ActiveDocument.Focus()
                '----------------------
                If toencrypt.Count = 0 Then
                    For Each item As String In toencrypt
                        EncryptManager.EncryptDocument(item)
                    Next
                    ShowEncryptAlert("Performed an automatic encryption of all open documents.", 2000)
                End If
            End If
        End If
    End Sub

#End Region

#Region "Autosave"

    Private Sub AutoSaveTimer_Tick(sender As Object, e As EventArgs) Handles AutoSaveTimer.Tick
        If Not My.Settings.temp_performancemode Then
            If AtLeastOneTab() Then
                For Each item As XDockContent In DockPanel1.Documents
                    If IsCodeEditor(item) Then
                        If CType(item, Tab_CodeEditor).GetFileLocation <> "" Then
                            SaveFile(item)
                        End If
                    ElseIf IsNotepad(item) Then
                        If CType(item, Tab_Notepad).GetFileLocation <> "" Then
                            SaveFile(item)
                        End If
                    End If
                Next
            End If
        End If
    End Sub

#End Region

#End Region

#Region "frmManager"

    Private Sub frmManager_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            frmDragContent.Show()
        End If
    End Sub

    Private Sub frmManager_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Maximized Then
            winstate = 1
        ElseIf Me.WindowState = FormWindowState.Normal Then
            winstate = 0
        End If
    End Sub

    Private Sub frmManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If MetroMessageBox.Show(Me, "Do you want to save all XDev Studio settings? This only affects minor settings that are updated throughout runtime such as recent projects.", "Save Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '    My.Settings.Save()
        'End If
        My.Settings.Save()
        If closebecauselock Then
            If CheckIfAllSaved() = False Then
                Dim docs(0 To DockPanel1.Documents.Count - 1) As DockContent
                For i As Integer = 0 To DockPanel1.Documents.Count - 1
                    If IsCodeEditor(DockPanel1.Documents(i)) Or IsNotepad(DockPanel1.Documents(i)) Then
                        If CheckIfDocumentHasUnsavedChanges((DockPanel1.Documents(i))) Then
                            docs(i) = DockPanel1.Documents(i)
                        End If
                    End If
                Next
                Dim newb As New frmSave(docs)
                Dim dlgRes As DialogResult = newb.ShowDialog()

                If dlgRes = Windows.Forms.DialogResult.Yes Then
                    Dim docsToSave() As DockContent = newb.DocsToSave
                    For i As Integer = 0 To docsToSave.GetUpperBound(0)
                        Dim doc As DockContent = docsToSave(i)
                        If IsCodeEditor(doc) Then
                            If CheckIfDocumentSaved(doc, False) Then
                                SaveFile(doc)
                            Else
                                Try
                                    doc.Activate()
                                    Dim nb As New SaveFileDialog
                                    If CType(doc, Tab_CodeEditor).GetFileName() = "" Then
                                        nb.Title = "Save Document 'Untitled'"
                                    Else
                                        nb.Title = "Save Document '" & CType(doc, Tab_CodeEditor).GetFileName() & "'"
                                    End If
                                    nb.OverwritePrompt = True
                                    nb.Filter = GetFileFilter()
                                    If nb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                        SaveFileAs(doc, nb.FileName)
                                    End If
                                Catch
                                End Try
                            End If
                        ElseIf IsNotepad(doc) Then
                            If CheckIfDocumentSaved(doc, False) Then
                                SaveFile(doc)
                            Else
                                Try
                                    doc.Activate()
                                    Dim nb As New SaveFileDialog
                                    nb.Title = "Save Notepad Document"
                                    nb.OverwritePrompt = True
                                    nb.Filter = "All Files (*.*)|*.*|Plain Text (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf"
                                    If nb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                        SaveFileAs(doc, nb.FileName)
                                    End If
                                Catch
                                End Try
                            End If
                        End If
                    Next

                    e.Cancel = False
                    My.Settings.temp_projlocation = ""
                    ptype = ProjType.File
                    NotifyIcon1.Text = "XDev Studio"
                    My.Settings.Save()
                ElseIf dlgRes = Windows.Forms.DialogResult.No Then
                    e.Cancel = False
                    My.Settings.temp_projlocation = ""
                    ptype = ProjType.File
                    NotifyIcon1.Text = "XDev Studio"
                    My.Settings.Save()
                ElseIf dlgRes = Windows.Forms.DialogResult.Cancel Then
                    e.Cancel = False
                    My.Settings.temp_projlocation = ""
                    ptype = ProjType.File
                    NotifyIcon1.Text = "XDev Studio"
                    My.Settings.Save()
                End If
            End If
        Else
            If CheckIfAllSaved() = False Then
                Dim docs(0 To DockPanel1.Documents.Count - 1) As DockContent
                For i As Integer = 0 To DockPanel1.Documents.Count - 1
                    If IsCodeEditor(DockPanel1.Documents(i)) Or IsNotepad(DockPanel1.Documents(i)) Then
                        If CheckIfDocumentHasUnsavedChanges((DockPanel1.Documents(i))) Then
                            docs(i) = DockPanel1.Documents(i)
                        End If
                    End If
                Next
                Dim newb As New frmSave(docs)
                Dim dlgRes As DialogResult = newb.ShowDialog()

                If dlgRes = Windows.Forms.DialogResult.Yes Then
                    Dim docsToSave() As DockContent = newb.DocsToSave
                    For i As Integer = 0 To docsToSave.GetUpperBound(0)
                        Dim doc As DockContent = docsToSave(i)
                        If IsCodeEditor(doc) Then
                            If CheckIfDocumentSaved(doc, False) Then
                                SaveFile(doc)
                            Else
                                Try
                                    doc.Activate()
                                    Dim nb As New SaveFileDialog
                                    If CType(doc, Tab_CodeEditor).GetFileName() = "" Then
                                        nb.Title = "Save Document 'Untitled'"
                                    Else
                                        nb.Title = "Save Document '" & CType(doc, Tab_CodeEditor).GetFileName() & "'"
                                    End If
                                    nb.OverwritePrompt = True
                                    nb.Filter = GetFileFilter()
                                    If nb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                        SaveFileAs(doc, nb.FileName)
                                    End If
                                Catch
                                End Try
                            End If
                        ElseIf IsNotepad(doc) Then
                            If CheckIfDocumentSaved(doc, False) Then
                                SaveFile(doc)
                            Else
                                Try
                                    doc.Activate()
                                    Dim nb As New SaveFileDialog
                                    nb.Title = "Save Notepad Document"
                                    nb.OverwritePrompt = True
                                    nb.Filter = "All Files (*.*)|*.*|Plain Text (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf"
                                    If nb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                        SaveFileAs(doc, nb.FileName)
                                    End If
                                Catch
                                End Try
                            End If
                        End If
                    Next

                    e.Cancel = False
                    My.Settings.temp_projlocation = ""
                    ptype = ProjType.File
                    NotifyIcon1.Text = "XDev Studio"
                    My.Settings.Save()
                ElseIf dlgRes = Windows.Forms.DialogResult.No Then
                    e.Cancel = False
                    My.Settings.temp_projlocation = ""
                    ptype = ProjType.File
                    NotifyIcon1.Text = "XDev Studio"
                    My.Settings.Save()
                ElseIf dlgRes = Windows.Forms.DialogResult.Cancel Then
                    e.Cancel = True
                End If
            Else
                If My.Settings.set_confirmexit Then
                    If MetroMessageBox.Show(Me, "Are you sure you want to exit XDev Studio?", "Exit Studio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        My.Settings.temp_projlocation = ""
                        ptype = ProjType.File
                        NotifyIcon1.Text = "XDev Studio"
                        My.Settings.Save()
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                Else
                    My.Settings.temp_projlocation = ""
                    ptype = ProjType.File
                    NotifyIcon1.Text = "XDev Studio"
                    My.Settings.Save()
                    e.Cancel = False
                End If

            End If
        End If

        My.Settings.set_openedfiles.Clear()
        If My.Settings.set_rememberopenedfiles Then
            For Each item As DockContent In DockPanel1.Documents
                If IsCodeEditor(item) Then
                    If CType(item, Tab_CodeEditor).GetFileLocation <> "" Then
                        My.Settings.set_openedfiles.Add(CType(item, Tab_CodeEditor).GetFileLocation)
                    End If
                End If
            Next
        End If

        'My.Settings.temp_projlocation = ""
    End Sub

    Private Sub frmManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledExceptionHandler
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.SuspendLayout()
        DataManager.CheckAllData()
        Me.StyleManager = StyleManager1
        InitializeStudio()
        If CheckIfArguments() Then
            Try
                For Each item As String In args
                    If Path.GetExtension(item) <> ".exe" Then
                        If IO.Path.GetExtension(item) = ".xdpf" Then
                            OpenProject(item)
                        Else
                            OpenFile(item)
                        End If
                    End If
                Next
                ProcessArgumentsForCommands()
            Catch ex As Exception
                Logger.WriteError(ex)
            End Try
        End If
        If My.Settings.set_rememberopenedfiles Then
            If My.Settings.set_openedfiles.Count > 0 Then
                For Each item As String In My.Settings.set_openedfiles
                    Try
                        Tabs.AddCode(item)
                    Catch ex As Exception
                        Logger.WriteError(ex)
                    End Try
                Next
                My.Settings.set_openedfiles.Clear()
            End If
        End If
        If My.Settings.set_firstlaunch Then
            My.Settings.set_firstlaunch = False
        End If
        Me.ResumeLayout()
    End Sub

    Private Sub ExitDistractionFreeModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitDistractionFreeModeToolStripMenuItem.Click
        DistractionFreeModeToolStripMenuItem.PerformClick()
    End Sub

#End Region

#Region "Error/Exception Handling"

    'Public Sub UnhandledExceptionHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
    '    Logger.Write("ERROR: " & e.ExceptionObject.ToString)
    '    Logger.WriteError(e.ExceptionObject)
    '    MsgBox("An error has occurred in the studio. More details can be found in the log.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Error")
    'End Sub

#End Region

End Class