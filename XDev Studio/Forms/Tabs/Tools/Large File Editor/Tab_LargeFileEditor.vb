Imports ScintillaNET

Friend Class Tab_LargeFileEditor

    Private _maxLineNumberCharLength As Integer
    Dim fileloc As String
    Public finddlgshowing As Boolean = False

#Region "TextBox1"

    Private Sub TextBox1_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            frmDragContent.Show()
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
        'Display Line Number
        Dim maxLineNumberCharLength = TextBox1.Lines.Count.ToString().Length
        If maxLineNumberCharLength = Me._maxLineNumberCharLength Then
            Return
        End If
        Const padding As Integer = 2
        TextBox1.Margins(0).Width = TextBox1.TextWidth(Style.LineNumber, New String("9"c, maxLineNumberCharLength + 1)) + padding
        Me._maxLineNumberCharLength = maxLineNumberCharLength
    End Sub

#End Region

#Region "Context Menu Strip"

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        TextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        TextBox1.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        TextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        TextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        TextBox1.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        TextBox1.SelectAll()
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        TextBox1.ClearAll()
    End Sub

#End Region

#Region "Methods"

#Region "Dialogs"
    Public Sub ShowGoto()
        Dim newb As New LFE_Goto(Me, TextBox1.Lines.Count, TextBox1.LineFromPosition(TextBox1.CurrentPosition) + 1)
        Dim p As Point = Cursor.Position
        newb.Location = p
        newb.ShowDialog()
    End Sub

    Public Sub ShowFindReplace()
        If finddlgshowing = False Then
            Dim newb As New LFE_FindReplace(Me, TextBox1.SelectedText)
            finddlgshowing = True
            Dim p As Point = Cursor.Position
            newb.Location = p
            newb.Show()
        End If
    End Sub

#End Region

#Region "Find Replace"

#Region "Replace"

#Region "Normal"

    Public Function ReplaceAll(ByVal otxt As String, ByVal ntxt As String, ByVal sf As Integer) As List(Of Integer)
        Dim lfound As New List(Of Integer)
        TextBox1.TargetStart = 0
        TextBox1.TargetEnd = TextBox1.TextLength
        TextBox1.SearchFlags = sf
        While TextBox1.SearchInTarget(otxt) <> -1
            lfound.Add(TextBox1.TargetStart)
            TextBox1.ReplaceTarget(ntxt)
            TextBox1.TargetStart = TextBox1.TargetEnd
            TextBox1.TargetEnd = TextBox1.TextLength
        End While
        Return lfound
    End Function

    Public Function ReplaceNext(ByVal otxt As String, ByVal ntxt As String, ByVal sf As Integer) As Integer
        'If CheckIfQueryExists(otxt, sf) Then
        '    TextBox1.SearchFlags = sf
        '    TextBox1.TargetStart = Math.Max(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
        '    TextBox1.TargetEnd = TextBox1.TextLength
        '    Dim pos = TextBox1.SearchInTarget(otxt)
        '    If pos >= 0 Then
        '        TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
        '        TextBox1.ReplaceSelection(ntxt)
        '        Return TextBox1.TargetStart
        '    Else
        '        TextBox1.SearchFlags = sf
        '        TextBox1.TargetStart = 0
        '        TextBox1.TargetEnd = TextBox1.TextLength
        '        Dim pos1 = TextBox1.SearchInTarget(otxt)
        '        If pos1 >= 0 Then
        '            TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
        '            TextBox1.ReplaceSelection(ntxt)
        '            Return TextBox1.TargetStart
        '        Else
        '            Return -1
        '        End If
        '    End If
        'Else
        '    Return -1
        'End If
        If CheckIfQueryExists(otxt, sf) Then
            TextBox1.SearchFlags = sf
            TextBox1.TargetStart = Math.Max(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
            TextBox1.TargetEnd = TextBox1.TextLength
            Dim pos = TextBox1.SearchInTarget(otxt)
            If pos >= 0 Then
                TextBox1.ReplaceTarget(ntxt)
                Return TextBox1.TargetStart
            Else
                TextBox1.SearchFlags = sf
                TextBox1.TargetStart = 0
                TextBox1.TargetEnd = TextBox1.TextLength
                Dim pos1 = TextBox1.SearchInTarget(otxt)
                If pos1 >= 0 Then
                    TextBox1.ReplaceTarget(ntxt)
                    Return TextBox1.TargetStart
                Else
                    Return -1
                End If
            End If
        Else
            Return -1
        End If
    End Function

    Public Function ReplacePrevious(ByVal otxt As String, ByVal ntxt As String, ByVal sf As Integer) As Integer
        If CheckIfQueryExists(otxt, sf) Then
            TextBox1.SearchFlags = sf
            TextBox1.TargetStart = Math.Min(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
            TextBox1.TargetEnd = 0
            Dim pos = TextBox1.SearchInTarget(otxt)
            If pos >= 0 Then
                TextBox1.ReplaceTarget(ntxt)
                Return TextBox1.TargetStart
            Else
                TextBox1.SearchFlags = sf
                TextBox1.TargetStart = TextBox1.TextLength
                TextBox1.TargetEnd = 0
                Dim pos1 = TextBox1.SearchInTarget(otxt)
                If pos1 >= 0 Then
                    TextBox1.ReplaceTarget(ntxt)
                    Return TextBox1.TargetStart
                Else
                    Return -1
                End If
            End If
        Else
            Return -1
        End If
    End Function

#End Region

#Region "Regex"

    Public Function ReplaceAllReg(ByVal otxt As String, ByVal ntxt As String) As List(Of Integer)
        Dim lfound As New List(Of Integer)
        TextBox1.TargetStart = 0
        TextBox1.TargetEnd = TextBox1.TextLength
        TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
        While TextBox1.SearchInTarget(otxt) <> -1
            lfound.Add(TextBox1.TargetStart)
            TextBox1.ReplaceTargetRe(ntxt)
            TextBox1.TargetStart = TextBox1.TargetEnd
            TextBox1.TargetEnd = TextBox1.TextLength
        End While
        Return lfound
    End Function

    Public Function ReplacePreviousReg(ByVal otxt As String, ByVal ntxt As String)
        If CheckIfQueryExistsReg(otxt) Then
            TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
            TextBox1.TargetStart = Math.Min(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
            TextBox1.TargetEnd = 0
            Dim pos = TextBox1.SearchInTarget(otxt)
            If pos >= 0 Then
                TextBox1.ReplaceTargetRe(ntxt)
                Return TextBox1.TargetStart
            Else
                TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                TextBox1.TargetStart = TextBox1.TextLength
                TextBox1.TargetEnd = 0
                Dim pos1 = TextBox1.SearchInTarget(otxt)
                If pos1 >= 0 Then
                    TextBox1.ReplaceTargetRe(ntxt)
                    Return TextBox1.TargetStart
                Else
                    Return -1
                End If
            End If
        Else
            Return -1
        End If
    End Function

    Public Function ReplaceNextReg(ByVal otxt As String, ByVal ntxt As String)
        If CheckIfQueryExistsReg(otxt) Then
            TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
            TextBox1.TargetStart = Math.Max(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
            TextBox1.TargetEnd = TextBox1.TextLength
            Dim pos = TextBox1.SearchInTarget(otxt)
            If pos >= 0 Then
                TextBox1.ReplaceTargetRe(ntxt)
                Return TextBox1.TargetStart
            Else
                TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                TextBox1.TargetStart = 0
                TextBox1.TargetEnd = TextBox1.TextLength
                Dim pos1 = TextBox1.SearchInTarget(otxt)
                If pos1 >= 0 Then
                    TextBox1.ReplaceTargetRe(ntxt)
                    Return TextBox1.TargetStart
                Else
                    Return -1
                End If

            End If
        Else
            Return -1
        End If
    End Function


#End Region

#End Region

#Region "Find"

#Region "Normal"

    Public Function FindPrevious(ByVal txt As String, ByVal sf As Integer) As Integer
        If CheckIfQueryExists(txt, sf) Then
            TextBox1.SearchFlags = sf
            TextBox1.TargetStart = Math.Min(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
            TextBox1.TargetEnd = 0
            Dim pos = TextBox1.SearchInTarget(txt)
            If pos >= 0 Then
                TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
                Return TextBox1.TargetStart
            Else
                TextBox1.TargetStart = TextBox1.TextLength
                TextBox1.TargetEnd = 0
                Dim pos1 = TextBox1.SearchInTarget(txt)
                If pos1 >= 0 Then
                    TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
                    Return TextBox1.TargetStart
                Else
                    Return -1
                End If
            End If
            Return pos
        Else
            Return -1
        End If

    End Function

    Public Function FindAll(ByVal txt As String, ByVal sf As Integer) As List(Of Integer)
        Dim lfound As New List(Of Integer)
        TextBox1.TargetStart = 0
        TextBox1.TargetEnd = TextBox1.TextLength
        TextBox1.SearchFlags = sf
        While TextBox1.SearchInTarget(txt) <> -1
            lfound.Add(TextBox1.TargetStart)
            TextBox1.TargetStart = TextBox1.TargetEnd
            TextBox1.TargetEnd = TextBox1.TextLength
        End While
        Return lfound
    End Function
    Public Function FindNext(ByVal txt As String, ByVal sf As Integer) As Integer
        If CheckIfQueryExists(txt, sf) Then
            TextBox1.SearchFlags = sf
            TextBox1.TargetStart = Math.Max(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
            TextBox1.TargetEnd = TextBox1.TextLength

            Dim pos = TextBox1.SearchInTarget(txt)
            If pos >= 0 Then
                TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
                Return TextBox1.TargetStart
            Else
                TextBox1.SearchFlags = sf
                TextBox1.TargetStart = 0
                TextBox1.TargetEnd = TextBox1.TextLength

                Dim pos1 = TextBox1.SearchInTarget(txt)
                If pos1 >= 0 Then
                    TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
                    Return TextBox1.TargetStart
                Else
                    Return -1
                End If
            End If
        Else
            Return -1
        End If
    End Function

#End Region

#Region "Regex"

    Public Function FindPreviousReg(ByVal txt As String) As Integer
        If CheckIfQueryExistsReg(txt) Then
            TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
            TextBox1.TargetStart = Math.Min(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
            TextBox1.TargetEnd = 0

            Dim pos = TextBox1.SearchInTarget(txt)
            If pos >= 0 Then
                TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
                Return TextBox1.TargetStart
            Else
                TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                TextBox1.TargetStart = TextBox1.TextLength
                TextBox1.TargetEnd = 0
                Dim pos1 = TextBox1.SearchInTarget(txt)
                If pos1 >= 0 Then
                    TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
                    Return TextBox1.TargetStart
                Else
                    Return -1
                End If
            End If
        Else
            Return -1
        End If
    End Function

    Public Function FindAllReg(ByVal txt As String) As List(Of Integer)
        Dim lfound As New List(Of Integer)
        TextBox1.TargetStart = 0
        TextBox1.TargetEnd = TextBox1.TextLength
        TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
        While TextBox1.SearchInTarget(txt) <> -1
            lfound.Add(TextBox1.TargetStart)
            TextBox1.TargetStart = TextBox1.TargetEnd
            TextBox1.TargetEnd = TextBox1.TextLength
        End While
        Return lfound
    End Function

    Public Function FindNextReg(ByVal txt As String) As Integer
        If CheckIfQueryExistsReg(txt) Then
            TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
            TextBox1.TargetStart = Math.Max(TextBox1.CurrentPosition, TextBox1.AnchorPosition)
            TextBox1.TargetEnd = TextBox1.TextLength
            Dim pos = TextBox1.SearchInTarget(Text)
            If pos >= 0 Then
                TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
                Return TextBox1.TargetStart
            Else
                TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                TextBox1.TargetStart = 0
                TextBox1.TargetEnd = TextBox1.TextLength
                Dim pos1 = TextBox1.SearchInTarget(Text)
                If pos1 >= 0 Then
                    TextBox1.SetSel(TextBox1.TargetStart, TextBox1.TargetEnd)
                    Return TextBox1.TargetStart
                Else
                    Return -1
                End If
            End If
        Else
            Return -1
        End If
    End Function

#End Region

#End Region

    Private Function CheckIfQueryExists(ByVal txt As String, ByVal sf As Integer) As Boolean
        Dim ret As Boolean = False
        TextBox1.TargetWholeDocument()
        TextBox1.SearchFlags = sf
        If TextBox1.SearchInTarget(txt) <> -1 Then
            ret = True
        End If
        Return ret
    End Function

    Private Function CheckIfQueryExistsReg(ByVal txt As String) As Boolean
        Dim ret As Boolean = False
        TextBox1.TargetWholeDocument()
        TextBox1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
        If TextBox1.SearchInTarget(txt) <> -1 Then
            ret = True
        End If
        Return ret
    End Function

    Public Sub ClearFoundHighlightedWords()
        TextBox1.IndicatorCurrent = 9
        TextBox1.IndicatorClearRange(0, TextBox1.TextLength)
    End Sub

    Public Sub HighlightFoundWords(ByVal txt As String, ByVal tcolor As Color)
        ' Indicators 0-7 could be in use by a lexer
        ' so we'll use indicator 8 to highlight words.
        Const NUM As Integer = 9

        ' Remove all uses of our indicator
        TextBox1.IndicatorCurrent = NUM
        TextBox1.IndicatorClearRange(0, TextBox1.TextLength)

        ' Update indicator appearance
        TextBox1.Indicators(NUM).Style = IndicatorStyle.StraightBox
        TextBox1.Indicators(NUM).Under = True
        TextBox1.Indicators(NUM).ForeColor = tcolor
        TextBox1.Indicators(NUM).OutlineAlpha = 50
        TextBox1.Indicators(NUM).Alpha = 30

        ' Search the document
        TextBox1.TargetStart = 0
        TextBox1.TargetEnd = TextBox1.TextLength
        TextBox1.SearchFlags = SearchFlags.None
        While TextBox1.SearchInTarget(txt) <> -1
            ' Mark the search results with the current indicator
            TextBox1.IndicatorFillRange(TextBox1.TargetStart, TextBox1.TargetEnd - TextBox1.TargetStart)

            ' Search the remainder of the document
            TextBox1.TargetStart = TextBox1.TargetEnd
            TextBox1.TargetEnd = TextBox1.TextLength
        End While
    End Sub

#End Region

    Public Sub GotoLine(ByVal linenum As Integer)
        Try
            If linenum > 0 Then
                If linenum <= TextBox1.Lines.Count Then
                    TextBox1.Lines(linenum - 1).Goto()
                Else
                    TextBox1.Lines(TextBox1.Lines.Count - 1).Goto()
                End If
            Else
                TextBox1.Lines(0).Goto()
            End If
        Catch
        End Try
    End Sub

    Public Sub LoadFile(ByVal floc As String)
        Try
            Dim t As Task = Task.Factory.StartNew(Sub()
                                                      TextBox1.Text = My.Computer.FileSystem.ReadAllText(floc)
                                                      TextBox1.SetSavePoint()
                                                  End Sub)
            SetFileLocation(floc)
        Catch ex As Exception
            Logger.WriteError(ex)
        End Try
    End Sub

    Public Sub LoadExtCode(ByVal txt As String)
        TextBox1.Text = txt
    End Sub

    Public Function GetFileLocation() As String
        Return fileloc
    End Function

    Public Sub SetFileLocation(ByVal loc As String)
        fileloc = loc
        Me.DockHandler.ToolTipText = loc
    End Sub

    Public Sub UpdateTitle(ByVal title As String)
        Me.Text = title
    End Sub

#End Region

#Region "Menu Strip"

#Region "File"

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Title = "Open File"
        newb.Filter = frmManager.GetFileFilter()
        newb.Multiselect = False
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadFile(newb.FileName)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            'My.Computer.FileSystem.WriteAllText(CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetFileLocation, CType(DockPanel1.ActiveDocument, Tab_CodeEditor).GetCurrentEditor().Text, False)
            Dim objWriter As New System.IO.StreamWriter(GetFileLocation, False)
            objWriter.Write(TextBox1.Text)
            objWriter.Close()
            TextBox1.SetSavePoint()
            RecentFilesManager.AddFile(GetFileLocation)
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Try
            Dim newb As New SaveFileDialog
            newb.Title = "Save Document"
            newb.OverwritePrompt = True
            newb.Filter = frmManager.GetFileFilter()
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                SetFileLocation(newb.FileName)
                SaveToolStripMenuItem.PerformClick()
            End If
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

#End Region

#Region "Edit"

    Private Sub UndoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem1.Click
        TextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem1.Click
        TextBox1.Redo()
    End Sub

    Private Sub CutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem1.Click
        TextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem1.Click
        TextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem1.Click
        TextBox1.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem1.Click
        TextBox1.SelectAll()
    End Sub

    Private Sub ClearAllToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem1.Click
        TextBox1.ClearAll()
    End Sub

    Private Sub GotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoToolStripMenuItem.Click
        ShowGoto()
    End Sub

    Private Sub FindReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindReplaceToolStripMenuItem.Click
        ShowFindReplace()
    End Sub

#End Region

#Region "Options"

    Private Sub OvertypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OvertypeToolStripMenuItem.Click
        If TextBox1.Overtype Then
            OvertypeToolStripMenuItem.Checked = False
            TextBox1.Overtype = False
        Else
            OvertypeToolStripMenuItem.Checked = True
            TextBox1.Overtype = True
        End If
    End Sub

    Private Sub HighlightCurrentLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighlightCurrentLineToolStripMenuItem.Click
        If TextBox1.CaretLineVisible Then
            TextBox1.CaretLineVisible = False
            HighlightCurrentLineToolStripMenuItem.Checked = False
        Else
            TextBox1.CaretLineVisible = True
            HighlightCurrentLineToolStripMenuItem.Checked = True
        End If
    End Sub

#End Region

#End Region

#Region "Tab_LargeFileEditor"

    Private Sub Tab_LargeFileEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.Text.EndsWith("*") And e.CloseReason <> CloseReason.MdiFormClosing Then
            If MetroFramework.MetroMessageBox.Show(frmManager, "You have unsaved changes. Are you sure you want to close this document without saving?", "Notepad - Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

End Class