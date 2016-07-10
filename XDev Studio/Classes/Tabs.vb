Imports MetroFramework
Imports WeifenLuo.WinFormsUI.Docking

Friend Class Tabs

    Enum UniversalSearchType
        OpenDocuments
        ProjectDocuments
    End Enum

#Region "Tab Items"

#Region "Code Editor"

    Public Shared Sub AddCode()
        Dim newtab As New Tab_CodeEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle("Untitled")
    End Sub

    Public Shared Sub AddCode(ByVal fileloc As String)
        Dim newtab As New Tab_CodeEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        newtab.SetFileLocation(fileloc)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle(System.IO.Path.GetFileName(fileloc))
        newtab.LoadFile(fileloc)
    End Sub

    Public Shared Sub AddCodeWithoutFile(ByVal code As String)
        Dim newtab As New Tab_CodeEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        newtab.LoadExtCode(code, XDev.Editor.Language.EditorLanguage.PlainText)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle("Untitled")
    End Sub

    Public Shared Sub AddCodeWithoutFile(ByVal code As String, ByVal lang As XDev.Editor.Language.EditorLanguage)
        Dim newtab As New Tab_CodeEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        newtab.LoadExtCode(code, lang)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle("Untitled")
    End Sub

    Public Shared Sub AddCodeWithFile(ByVal code As String, ByVal lang As XDev.Editor.Language.EditorLanguage, ByVal fileloc As String)
        Dim newtab As New Tab_CodeEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        newtab.LoadExtCode(code, lang)
        newtab.SetFileLocation(fileloc)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle("Untitled")
    End Sub
    

#End Region

#Region "Large File Editor"

    Public Shared Sub AddLargeFileEditor()
        Dim newtab As New Tab_LargeFileEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle("Untitled")
    End Sub

    Public Shared Sub AddLargeFileEditor_NoFile(ByVal code As String)
        Dim newtab As New Tab_LargeFileEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        newtab.LoadExtCode(code)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle("Untitled")
    End Sub

    Public Shared Sub AddLargeFileEditor(ByVal code As String, ByVal fileloc As String)
        Dim newtab As New Tab_LargeFileEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        newtab.LoadExtCode(code)
        newtab.SetFileLocation(fileloc)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle("Untitled")
    End Sub
    Public Shared Sub AddLargeFileEditor(ByVal fileloc As String)
        Dim newtab As New Tab_LargeFileEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        newtab.SetFileLocation(fileloc)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle(System.IO.Path.GetFileName(fileloc))
        newtab.LoadFile(fileloc)
    End Sub

#End Region

#Region "Notepad"

    Public Shared Sub AddNotepad()
        Dim newtab As New Tab_Notepad
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.UpdateTitle("Untitled")
    End Sub
    Public Shared Sub AddNotepad(ByVal txt As String)
        Dim newtab As New Tab_Notepad
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.TextBox1.Text = txt
        newtab.SetOriginalText(txt)
        newtab.UpdateTitle("Untitled")
    End Sub

    Public Shared Sub AddNotepad(ByVal txt As String, ByVal fileloc As String)
        Dim newtab As New Tab_Notepad
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.TextBox1.Text = txt
        newtab.SetOriginalText(txt)
        newtab.SetFileLocation(fileloc)
        newtab.UpdateTitle(System.IO.Path.GetFileName(fileloc))
    End Sub

#End Region

#Region "File Downloader"

    Public Shared Sub AddFileDownloader()
        Dim newtab As New Tab_FileDownloader
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddFileDownloader(ByVal url As String, ByVal downloadloc As String)
        Dim newtab As New Tab_FileDownloader
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.DownloadFile(url, downloadloc)
    End Sub

#End Region

#Region "Universal Search"
    Public Shared Sub AddUniversalSearch()
        Dim newtab As New Tab_UniversalSearch
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddUniversalSearch(ByVal searchterm As String, ByVal searchtype As UniversalSearchType)
        Dim newtab As New Tab_UniversalSearch
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.txt_search.Text = searchterm
        If searchtype = UniversalSearchType.OpenDocuments Then
            newtab.radio_searchopendocuments.Checked = True
        Else
            newtab.radio_searchdocumentsinproject.Checked = True
        End If
        newtab.btn_search.PerformClick()
        newtab.lb_results.Focus()
    End Sub

#End Region

#Region "RSS Reader"

    Public Shared Sub AddRSSReader()
        Dim newtab As New Tab_RSSReader
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddRSSReader(ByVal feedurl As String)
        Dim newtab As New Tab_RSSReader
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.tbChannel.Text = feedurl
        newtab.btn_load.PerformClick()
    End Sub

#End Region

#Region "Code Metrics"

    Public Shared Sub AddCodeMetrics()
        Dim newtab As New Tab_CodeMetrics
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub
    Public Shared Sub AddCodeMetrics(ByVal fileloc As String)
        Dim newtab As New Tab_CodeMetrics
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.CalculateCodeMetrics(fileloc)
    End Sub

#End Region

#Region "Web Browser"

    Public Shared Sub AddWebBrowser()
        Dim newtab As New Tab_WebBrowser
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddWebBrowser(ByVal url As String)
        Dim newtab As New Tab_WebBrowser
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        newtab.LoadURL(url)
    End Sub

#End Region

#Region "TestBrowser"

    Public Shared Sub AddTestBrowser()
        Dim newtab As New Tab_TestBrowser
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddTestBrowser(Optional title As String = "Test Browser", Optional url As String = "", Optional doctext As String = "")
        If url = "" Then
            Dim newtab As New Tab_TestBrowser
            newtab.Show(frmManager.DockPanel1, DockState.Document)
            frmManager.SetActiveForm(newtab)
            newtab.DisplayHtml(doctext)
            newtab.Text = title
        ElseIf doctext = "" Then
            Dim newtab As New Tab_TestBrowser
            newtab.Show(frmManager.DockPanel1, DockState.Document)
            frmManager.SetActiveForm(newtab)
            newtab.WebBrowser1.Navigate(url)
            newtab.Text = title
        End If
    End Sub

#End Region

#Region "Difference Viewer"

    Public Shared Sub AddDifferenceViewer()
        Dim newtab As New Tab_DifferenceViewer
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddDifferenceViewer(ByVal f1 As String, ByVal f2 As String, ByVal compare As Boolean)
        Dim newtab As New Tab_DifferenceViewer
        newtab.txt_file1.Text = f1
        newtab.txt_file2.Text = f2
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
        If compare Then
            newtab.btn_compare.PerformClick()
        End If
    End Sub

#End Region

    Public Shared Sub AddNetConverter()
        Dim newtab As New Tab_NetConverter
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddFileHistory()
        Dim newtab As New Tab_FileHistory
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddTaskScheduler()
        Dim newtab As New Tab_TaskScheduler
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddHexViewer()
        Dim newtab As New Tab_HexViewer
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddWYSIWYGEditor()
        Dim newtab As New Tab_WYSIWYGEditor
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddCodeBank()
        Dim newtab As New Tab_CodeBank
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddCodeRecovery()
        Dim newtab As New Tab_CodeRecovery
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddDiagrammer()
        Dim newtab As New Tab_Diagrammer
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddStudioTerminal()
        Dim newtab As New Tab_StudioTerminal
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddAppManager()
        Dim newtab As New Tab_AppManager
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddServiceViewer()
        Dim newtab As New Tab_ServiceViewer
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddWebDocumentation()
        Dim newtab As New Tab_WebDocumentation
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddImageMapper()
        Dim newtab As New Tab_ImageMapper
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddBookmarks()
        Dim newtab As New Tab_Bookmarks
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddWelcome()
        Dim newtab As New Tab_Welcome
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddLogManager()
        Dim newtab As New Tab_LogManager
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddTasks()
        Dim newtab As New Tab_TaskViewer
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddOptions()
        Dim newtab As New Tab_Options
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddCalendar()
        Dim newtab As New Tab_Calendar
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub


    Public Shared Sub AddProcessViewer()
        Dim newtab As New Tab_ProcessViewer
        newtab.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(newtab)
    End Sub

    Public Shared Sub AddCustom(ByVal custform As WeifenLuo.WinFormsUI.Docking.DockContent)
        custform.Show(frmManager.DockPanel1, DockState.Document)
        frmManager.SetActiveForm(custform)
    End Sub

#End Region

End Class
