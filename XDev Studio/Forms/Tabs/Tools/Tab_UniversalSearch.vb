Imports System.IO
Imports ScintillaNET
Imports WeifenLuo.WinFormsUI.Docking

Friend Class Tab_UniversalSearch
    Dim flist As New List(Of SearchObject)
    Dim ulist As New List(Of USearchObject)

#Region "Search"

    Public Sub SearchOpenDocuments(ByVal txt As String)
        Try
            Me.DockHandler.ToolTipText = txt
            If frmManager.AtLeastOneEditor() Then
                For i As Integer = 0 To frmManager.DockPanel1.Documents.Count - 1
                    If frmManager.IsCodeEditor(frmManager.DockPanel1.Documents(i)) Then
                        For Each ln As Line In CType(frmManager.DockPanel1.Documents(i), Tab_CodeEditor).GetCurrentEditor().GetLines()
                            If check_casesensitive.Checked Then
                                If ln.Text.Contains(txt) Then
                                    Dim newb As New USearchObject(ln.Index + 1, CType(frmManager.DockPanel1.Documents(i), Tab_CodeEditor))
                                    ulist.Add(newb)
                                    If ln.Text.Length > 50 Then
                                        lb_results.Items.Add("|" & CType(frmManager.DockPanel1.Documents(i), Tab_CodeEditor).GetFileName(True) & " | Line: " & ln.Index + 1 & " | " & ln.Text.Substring(0, 50) & "...")
                                    Else
                                        lb_results.Items.Add("|" & CType(frmManager.DockPanel1.Documents(i), Tab_CodeEditor).GetFileName(True) & " | Line: " & ln.Index + 1 & " | " & ln.Text)
                                    End If
                                End If
                            Else
                                If ln.Text.ToLower.Contains(txt.ToLower) Then
                                    Dim newb As New USearchObject(ln.Index + 1, CType(frmManager.DockPanel1.Documents(i), Tab_CodeEditor))
                                    ulist.Add(newb)
                                    If ln.Text.Length > 50 Then
                                        lb_results.Items.Add("|" & CType(frmManager.DockPanel1.Documents(i), Tab_CodeEditor).GetFileName(True) & " | Line: " & ln.Index + 1 & " | " & ln.Text.Substring(0, 50) & "...")
                                    Else
                                        lb_results.Items.Add("|" & CType(frmManager.DockPanel1.Documents(i), Tab_CodeEditor).GetFileName(True) & " | Line: " & ln.Index + 1 & " | " & ln.Text)
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next

            End If

        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Public Sub SearchProject(ByVal txt As String)
        If frmManager.GetPType() = frmManager.ProjType.Project Then
            Try

                'For Each item As FileObject In ProjectReader.GetProjectFiles()
                '    Dim ftext As String = File.ReadAllText(item.GetFileLocation)
                '    Dim index As Integer = ftext.IndexOf(txt)
                '    If index >= 0 Then
                '        item.SetSearchIndex(index)
                '        flist.Add(item)
                '        lb_results.Items.Add(item.GetFileName & ": " & index)
                '    End If
                'Next
                Me.DockHandler.ToolTipText = txt
                For Each item As FileObject In ProjectReader.GetProjectFiles()
                    Dim lines() As String = File.ReadAllLines(item.GetFileLocation)
                    For i As Integer = 0 To lines.Length - 1
                        If check_casesensitive.Checked Then
                            If lines(i).Contains(txt) Then
                                Dim newb As New SearchObject(i + 1, item.GetFileLocation, item.GetFileLanguage)
                                flist.Add(newb)
                                If lines(i).Length > 50 Then
                                    lb_results.Items.Add(item.GetFileName & "|Line: " & i + 1 & "|""" & lines(i).Substring(0, 50) & """...")
                                Else
                                    lb_results.Items.Add(item.GetFileName & "|Line: " & i + 1 & "|""" & lines(i) & """")
                                End If
                            End If
                        Else
                            If lines(i).ToLower.Contains(txt.ToLower) Then
                                Dim newb As New SearchObject(i + 1, item.GetFileLocation, item.GetFileLanguage)
                                flist.Add(newb)
                                If lines(i).Length > 50 Then
                                    lb_results.Items.Add(item.GetFileName & "|Line: " & i + 1 & "|""" & lines(i).Substring(0, 50) & """...")
                                Else
                                    lb_results.Items.Add(item.GetFileName & "|Line: " & i + 1 & "|""" & lines(i) & """")
                                End If
                            End If
                        End If
                    Next
                Next
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub
#End Region

    Private Sub GoToSelectedItem()
        Try
            If lb_results.Items.Count > 0 And lb_results.SelectedIndex >= 0 Then
                Dim bb As String = lb_results.SelectedItem
                If bb.StartsWith("|") Then
                    frmManager.SetActiveForm(ulist(lb_results.SelectedIndex).GetDocument())
                    CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().Focus()
                    CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().GotoLine(ulist(lb_results.SelectedIndex).GetSearchLine)
                Else
                    Dim index As DockContent = frmManager.GetSpecificCodeEditorByFileLocation(flist(lb_results.SelectedIndex).GetFileLocation)
                    If index Is Nothing Then
                        Tabs.AddCode(flist(lb_results.SelectedIndex).GetFileLocation)
                        'CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().GoTo.Line(flist(lb_results.SelectedIndex).GetSearchLine)
                        CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().Focus()
                        CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().GotoLine(flist(lb_results.SelectedIndex).GetSearchLine) '-1
                    Else
                        frmManager.SetActiveForm(index)
                        'CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().GoTo.Line(flist(lb_results.SelectedIndex).GetSearchLine)
                        CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().Focus()
                        CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().GotoLine(flist(lb_results.SelectedIndex).GetSearchLine) '-1
                    End If
                End If

            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If txt_search.Text <> "" Then
            lb_results.Items.Clear()
            ulist.Clear()
            flist.Clear()
            If radio_searchdocumentsinproject.Checked Then
                SearchProject(txt_search.Text)
            ElseIf radio_searchopendocuments.Checked Then
                SearchOpenDocuments(txt_search.Text)
            End If
        Else
            btn_reset.PerformClick()
        End If
    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        lb_results.Items.Clear()
        flist.Clear()
        ulist.Clear()
        txt_search.Clear()
    End Sub

    Private Sub txt_search_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_search.KeyDown
        If e.KeyCode = Keys.Enter Then
            btn_search.PerformClick()
        End If
    End Sub

    Private Sub lb_results_KeyDown(sender As Object, e As KeyEventArgs) Handles lb_results.KeyDown
        If lb_results.Items.Count > 0 And lb_results.SelectedIndex >= 0 Then
            If e.KeyCode = Keys.Delete Then
                Dim bb As String = lb_results.SelectedItem
                If bb.StartsWith("|") Then
                    ulist.RemoveAt(lb_results.SelectedIndex)
                    lb_results.Items.RemoveAt(lb_results.SelectedIndex)
                Else
                    flist.RemoveAt(lb_results.SelectedIndex)
                    lb_results.Items.RemoveAt(lb_results.SelectedIndex)
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                GoToSelectedItem()
            End If
        End If
    End Sub

    Private Sub lb_results_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lb_results.MouseDoubleClick
        GoToSelectedItem()
    End Sub

    Private Sub GoToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToToolStripMenuItem.Click
        GoToSelectedItem()
    End Sub

    Private Sub Tab_UniversalSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmManager.GetPType = frmManager.ProjType.Project Then
            radio_searchdocumentsinproject.Checked = True
        Else
            radio_searchdocumentsinproject.Enabled = False
        End If
    End Sub

    Private Sub RemoveFromSearchResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveFromSearchResultsToolStripMenuItem.Click
        If lb_results.Items.Count > 0 And lb_results.SelectedIndex >= 0 Then
            Dim bb As String = lb_results.SelectedItem
            If bb.StartsWith("|") Then
                ulist.RemoveAt(lb_results.SelectedIndex)
                lb_results.Items.RemoveAt(lb_results.SelectedIndex)
            Else
                flist.RemoveAt(lb_results.SelectedIndex)
                lb_results.Items.RemoveAt(lb_results.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub txt_search_Click(sender As Object, e As EventArgs) Handles txt_search.Click
        txt_search.SelectAll()
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        If check_incrementalsearch.Checked Then
            btn_search.PerformClick()
        End If
    End Sub

End Class