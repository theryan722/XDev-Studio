Imports System.IO
Imports System.Net
Imports MetroFramework
Imports XDev.Editor
Imports ScintillaNET
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class frmMain
    'File filter string
    Dim filefilter As String = "All Files (*.*)|*.*|Plain Text File (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf|Action Script File (*.as)|*.as|Ada file (*.ada;*.a;*.ads;*.adb)|*.ada;*.a;*.ads;*.adb|Assembly Language File (*.asm;*.s;*.S)|*.asm;*.s;*.S|ASP Script (*.asp)|*.asp|Unix Script (*.sh)|*.sh|Batch File (*.bat;*.cmd;*.nt)|*.bat;*.cmd;*.nt|C File (*.c)|*.c|COBOL File (*.cbl)|*.cbl|C++ File (*.cpp;*.cc;*.cxx;*.cp;*.c++;*.hpp;*.hxx)|*.cpp;*.cc;*.cxx;*.cp;*.c++;*.hpp;*.hxx|C# File (*.cs)|*.cs|CSS File (*.css)|*.css|D File (*.d)|*.d|Fortran File (*.f;*.f90;*.f95;*.f03;*.for;*.F;*.F90;*.f2k)|*.f;*.f90;*.f95;*.f03;*.for;*.F;*.F90;*.f2k|HTML File (*.html;*.htm;*.xhtml;*.jhtml;*.shtml;*.shtm;*.hta)|*.html;*.htm;*.xhtml;*.jhtml;*.shtml;*.shtm;*.hta|Java File (*.java;*.jsp;*.jspx)|*.java;*.jsp;*.jspx|JavaScript File (*.js)|*.js|LISP File (*.lsp;*.lisp;*.cl;*.el)|*.lsp;*.lisp;*.cl;*.el|Lua File (*.lua)|*.lua|Markdown File (*.md;*.markdown;*.mdown;*.mkdn;*.mkd;*.mdwn;*.mdtxt;*.mdtext)|*.md;*.markdown;*.mdown;*.mkdn;*.mkd;*.mdwn;*.mdtxt;*.mdtext|NFO File (*.nfo)|*.nfo|Pascal File (*.pas;*.pp;*.pascal;*.inc)|*.pas;*.pp;*.pascal;*.inc|Perl File (*.pl;*.pm;*.plx)|*.pl;*.pm;*.plx|PHP File (*.php;*.php4;*.php3;*.phtml)|*.php;*.php4;*.php3;*.phtml|Postscript File (*.ps)|*.ps|Python File (*.py;*.pyw)|*.py;*.pyw|R File (*.r)|*.r|Ruby File (*.rb;*.rhtml;*.rbw)|*.rb;*.rhtml;*.rbw|SmallTalk File (*.st)|*.st|SQL/PostgreSQL File (*.sql)|*.sql|Visual Basic File (*.vb)|*.vb|Visual Basic Script (*.vbs)|*.vbs|XML File (*.xml;*.rss;*.svg;*.xsml;*.xsl;*.xsd;*.kml;*.wsdl;*.xlf;*.xliff)|*.xml;*.rss;*.svg;*.xsml;*.xsl;*.xsd;*.kml;*.wsdl;*.xlf;*.xliff|YAML File (*.yaml;*.yml)|*.yaml;*.yml|XDev Language File (*.xdlf)|*.xdlf|XDev Script File (*.xds)|*.xds"
    'The location of the file that is being edited
    Dim fileloc As String = ""
    'Whether or not changes have been saved
    Dim issaved As Boolean = True

#Region "Menu Strip"

#Region "File"

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Title = "Open File"
        newb.Filter = filefilter
        newb.Multiselect = False
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            OpenFile(newb.FileName)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If fileloc = "" Then
            SaveAsToolStripMenuItem.PerformClick()
        Else
            SaveFile()
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Try
            Dim newb As New SaveFileDialog
            newb.Title = "Save Notepad Document"
            newb.OverwritePrompt = True
            newb.Filter = "All Files (*.*)|*.*|Plain Text (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf"
            If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
                SaveFileAs(newb.FileName)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        TextBox1.ShowPrintDialog()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        TextBox1.ShowPrintPreview()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        TextBox1.ShowPageSetupDialog()
    End Sub

    Private Sub OpenFileLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileLocationToolStripMenuItem.Click
        If fileloc <> "" Then
            Try
                System.Diagnostics.Process.Start("explorer.exe", fileloc)
            Catch
            End Try
        End If
    End Sub

    Private Sub LaunchXDevStudioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaunchXDevStudioToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start(XDev.Path.Locator.GetAppPath & "\XDev Studio.exe")
        Catch
        End Try
    End Sub

    Private Sub OpenStudioLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenStudioLocationToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("explorer.exe", XDev.Path.Locator.GetAppPath)
        Catch
        End Try
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        Dim newb As New frmMain
        newb.Show()
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        'If MetroFramework.MetroMessageBox.Show(Me, "Are you sure you want to restart?", "Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        Application.Restart()
        'End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#End Region

#Region "Edit"

#Region "Indent"

    Private Sub IncreaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncreaseToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.Tab)
    End Sub

    Private Sub DecreaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecreaseToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.BackTab)
    End Sub

#End Region
    
#Region "Selection"

#Region "Surround With"

    Private Sub SelectionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem1.Click
        TextBox1.SelectedText = """" & TextBox1.SelectedText & """"
    End Sub

    Private Sub SelectionToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem6.Click
        TextBox1.SelectedText = "'" & TextBox1.SelectedText & "'"
    End Sub

    Private Sub SelectionToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem2.Click
        TextBox1.SelectedText = "(" & TextBox1.SelectedText & ")"
    End Sub

    Private Sub SelectionToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem3.Click
        TextBox1.SelectedText = "[" & TextBox1.SelectedText & "]"
    End Sub

    Private Sub SelectionToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem4.Click
        TextBox1.SelectedText = "{" & TextBox1.SelectedText & "}"
    End Sub

    Private Sub SelectionToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem7.Click
        TextBox1.SelectedText = "<" & TextBox1.SelectedText & ">"
    End Sub

    Private Sub SelectionToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles SelectionToolStripMenuItem5.Click
        TextBox1.SelectedText = "*" & TextBox1.SelectedText & "*"
    End Sub

#End Region

#Region "Extend Selection"

    Private Sub ExtendToBeginningOfLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendToBeginningOfLineToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.HomeExtend)
    End Sub

    Private Sub ExtendDownParagraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendDownParagraphToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.ParaDownExtend)
    End Sub

    Private Sub ExtendUpParagraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendUpParagraphToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.ParaUpExtend)
    End Sub

    Private Sub ExtendToRightByOneCharacterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendToRightByOneCharacterToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.CharRightExtend)
    End Sub

    Private Sub ExtendToLeftByOneCharacterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendToLeftByOneCharacterToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.CharLeftExtend)
    End Sub

    Private Sub ExtendDownOneLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendDownOneLineToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.LineDownExtend)
    End Sub

    Private Sub ExtendUpOneLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendUpOneLineToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.LineUpExtend)
    End Sub

    Private Sub ExtendToStartOfDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendToStartOfDocumentToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.DocumentStartExtend)
    End Sub

    Private Sub ExtendToEndOfDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendToEndOfDocumentToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.DocumentEndExtend)
    End Sub

    Private Sub ExtendToEndOfLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendToEndOfLineToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.LineEndExtend)
    End Sub

#End Region
    Private Sub CompressToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompressToolStripMenuItem.Click

        Dim CompExp As New Regex("\s")
        If CompExp.IsMatch(TextBox1.SelectedText) = True Then
            TextBox1.SelectedText = CompExp.Replace(TextBox1.SelectedText, "")
        End If
    End Sub

    Private Sub ConvertToASCIICodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertToASCIICodeToolStripMenuItem.Click
        Dim v As Integer = 0
        Dim i As Integer
        For i = 1 To 256
            If TextBox1.SelectedText.Chars(0) = Chr(v) Then
                TextBox1.SelectedText = v
                i = 256
            Else
                v = v + 1
            End If
        Next i
        i = 1
        v = 0
    End Sub

    Private Sub SearchSelectionOnWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchSelectionOnWebToolStripMenuItem.Click
        Try
            Dim s As String = TextBox1.SelectedText
            System.Diagnostics.Process.Start("https://www.google.com/search?q=" & s)
        Catch ex As Exception
            MetroMessageBox.Show(Me, "Unable to search the selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DuplicateSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateSelectionToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.SelectionDuplicate)
    End Sub

#End Region

#Region "Lines"

    Private Sub CompressLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompressLineToolStripMenuItem.Click

        Dim CompExp As New Regex("\s")
        Dim curline As Integer = TextBox1.CurrentLine
        If CompExp.IsMatch(TextBox1.GetTextFromLine(TextBox1.CurrentLine)) = True Then
            'TextBox1.GetLines(TextBox1.CurrentLine).Text = CompExp.Replace(TextBox1.GetTextFromLine(curline), "")
            TextBox1.SetTextForLine(curline, CompExp.Replace(TextBox1.GetTextFromLine(curline), ""))
        End If
    End Sub

    Private Sub TransposeLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransposeLineToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.LineTranspose)
    End Sub

    Private Sub NewLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewLineToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.NewLine)
    End Sub

    Private Sub DeleteLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteLineToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.LineDelete)
    End Sub

    Private Sub GotoLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoLineToolStripMenuItem.Click
        TextBox1.ShowGoto()
    End Sub

    Private Sub GotoFirstVisibleLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoFirstVisibleLineToolStripMenuItem.Click
        TextBox1.GotoLine(TextBox1.GetFirstVisibleLine)
    End Sub

    Private Sub GotoFirstLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoFirstLineToolStripMenuItem.Click
        TextBox1.GotoLine(0)
    End Sub

    Private Sub GotoLastLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoLastLineToolStripMenuItem.Click
        TextBox1.GotoLine(TextBox1.GetTotalLines)
    End Sub

    Private Sub MoveSelectedLinesDownToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveSelectedLinesDownToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.MoveSelectedLinesDown)
    End Sub

    Private Sub MoveSelectedLinesUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveSelectedLinesUpToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.MoveSelectedLinesUp)
    End Sub

    Private Sub DuplicateLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateLineToolStripMenuItem.Click
        TextBox1.ExecuteCommand(Command.LineDuplicate)
    End Sub

#End Region

#Region "Other"

#Region "Convert Line Endings"

    Private Sub ToCrLfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToCrLfToolStripMenuItem.Click
        TextBox1.ConvertEols(Eol.CrLf)
    End Sub

    Private Sub ToLfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToLfToolStripMenuItem.Click
        TextBox1.ConvertEols(Eol.Lf)
    End Sub

    Private Sub ToCrToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToCrToolStripMenuItem.Click
        TextBox1.ConvertEols(Eol.Cr)
    End Sub

#End Region

#End Region

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        TextBox1.ExecuteCommand(ScintillaNET.Command.Undo)
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        TextBox1.ExecuteCommand(ScintillaNET.Command.Redo)
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

    Private Sub FindReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindReplaceToolStripMenuItem.Click
        TextBox1.ShowFindReplace()
    End Sub

    Private Sub GotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GotoToolStripMenuItem.Click
        TextBox1.ShowGoto()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        TextBox1.ShowIncrementalSearcher()
    End Sub

    Private Sub ReadOnlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReadOnlyToolStripMenuItem.Click
        If TextBox1.IsReadOnly Then
            TextBox1.IsReadOnly = False
            ReadOnlyToolStripMenuItem.Checked = False
        Else
            TextBox1.IsReadOnly = True
            ReadOnlyToolStripMenuItem.Checked = True
        End If
    End Sub
    
#End Region

#Region "Insert"

#Region "Symbol"

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        TextBox1.InsertText("•")
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        TextBox1.InsertText("«")
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        TextBox1.InsertText("»")
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        TextBox1.InsertText("½")
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        TextBox1.InsertText("¼")
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        TextBox1.InsertText("±")
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        TextBox1.InsertText("÷")
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        TextBox1.InsertText("≥")
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        TextBox1.InsertText("≤")
    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        TextBox1.InsertText("√")
    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        TextBox1.InsertText("©")
    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem23.Click
        TextBox1.InsertText("®")
    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem24.Click
        TextBox1.InsertText("™")
    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem25.Click
        TextBox1.InsertText("▲")
    End Sub

    Private Sub ToolStripMenuItem26_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem26.Click
        TextBox1.InsertText("▼")
    End Sub

    Private Sub ToolStripMenuItem27_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem27.Click
        TextBox1.InsertText("¶")
    End Sub

#End Region

#Region "Lorem Ipsum"

    Private Sub ParagraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParagraphToolStripMenuItem.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\1.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem1.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\2.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem2.Click
       Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\3.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem3.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\4.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem4.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\5.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem5.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\6.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem6.Click
       Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\7.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem7.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\8.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem8.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\9.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

    Private Sub ParagraphsToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ParagraphsToolStripMenuItem9.Click
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(XDev.Path.Locator.GetAppPath + "\Engine\Insert\LoremIpsum\10.txt")
            For Each i As String In lines
                TextBox1.InsertText(vbNewLine)
                TextBox1.InsertText(i)
            Next
        Catch
        End Try
    End Sub

#End Region

    Private Sub TimeDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeDateToolStripMenuItem.Click
        TextBox1.InsertText(DateTime.Now.ToString("hh:mm dd/mm/yyyy"))
    End Sub

    Private Sub ScrapedHTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScrapedHTMLToolStripMenuItem.Click
        Dim b As String = InputBox("Please enter the url of the webpage to download.", "Scrape Web Page", "")
        If b IsNot "" Then
            ThreadPool.QueueUserWorkItem(AddressOf thread_ce_ScrapeHTML, b)
        End If
    End Sub

#End Region

#Region "View"

#Region "Folding"

    Private Sub FoldAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FoldAllToolStripMenuItem.Click
        TextBox1.FoldAll()
    End Sub

    Private Sub UnfoldAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnfoldAllToolStripMenuItem.Click
        TextBox1.UnfoldAll()
    End Sub

    Private Sub FoldLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FoldLineToolStripMenuItem.Click
        TextBox1.FoldLine(TextBox1.CurrentLine)
    End Sub

    Private Sub UnfoldLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnfoldLineToolStripMenuItem.Click
        TextBox1.UnFoldLine(TextBox1.CurrentLine)
    End Sub

#End Region

#Region "Zoom"

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultToolStripMenuItem.Click
        TextBox1.Zoom = 1
        ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + TextBox1.Zoom.ToString
    End Sub

    Private Sub InToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InToolStripMenuItem.Click
        If TextBox1.Zoom > -10 And TextBox1.Zoom < 20 Then
            TextBox1.Zoom += 1
            ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + TextBox1.Zoom.ToString
        End If
    End Sub

    Private Sub OutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutToolStripMenuItem.Click
        If TextBox1.Zoom > -10 And TextBox1.Zoom < 20 Then
            TextBox1.Zoom -= 1
            ZoomLevelToolStripMenuItem.Text = "Zoom Level: " + TextBox1.Zoom.ToString
        End If
    End Sub

#End Region

    Private Sub TopmostToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TopmostToolStripMenuItem.Click
        If Me.TopMost Then
            Me.TopMost = False
            TopmostToolStripMenuItem.Checked = False
        Else
            Me.TopMost = True
            TopmostToolStripMenuItem.Checked = True
        End If
    End Sub

#End Region

#Region "Language"
    
    Private Sub AdaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdaToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Ada
    End Sub
    
    Private Sub AssemblyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssemblyToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Assembly
    End Sub

    Private Sub BatchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BatchToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Batch
    End Sub

    Private Sub CToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Csharp
    End Sub

    Private Sub CToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CToolStripMenuItem1.Click
        TextBox1.Language = Language.EditorLanguage.Cpp
    End Sub
    
    Private Sub CSSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSSToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Css
    End Sub

    Private Sub FortranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FortranToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Fortran
    End Sub

    Private Sub HTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Html
    End Sub

    Private Sub JavaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JavaToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Java
    End Sub

    Private Sub JavaScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JavaScriptToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.JavaScript
    End Sub

    Private Sub LispToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LispToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Lisp
    End Sub

    Private Sub LuaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LuaToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Lua
    End Sub

    Private Sub PascalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PascalToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Pascal
    End Sub

    Private Sub PerlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerlToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Perl
    End Sub

    Private Sub PHPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Php
    End Sub

    Private Sub PostgreSQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PostgreSQLToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Psql
    End Sub

    Private Sub PythonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PythonToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Python
    End Sub

    Private Sub RubyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RubyToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Ruby
    End Sub

    Private Sub SmalltalkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SmalltalkToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.SmallTalk
    End Sub

    Private Sub SQLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Sql
    End Sub

    Private Sub VBScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VBScriptToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.VB
    End Sub

    Private Sub XMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMLToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Xml
    End Sub

    Private Sub YAMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YAMLToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.Yaml
    End Sub

    Private Sub PlainTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlainTextToolStripMenuItem.Click
        TextBox1.Language = Language.EditorLanguage.PlainText
    End Sub

#End Region

#Region "Options"

#Region "Wrap Mode"

    Private Sub UncheckWrapMode()
        NoneToolStripMenuItem.Checked = False
        WordToolStripMenuItem.Checked = False
        CharToolStripMenuItem.Checked = False
        WhitespaceToolStripMenuItem.Checked = False
    End Sub

    Private Sub WhitespaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhitespaceToolStripMenuItem.Click
        UncheckWrapMode()
        TextBox1.WrapMode = WrapMode.Whitespace
        WhitespaceToolStripMenuItem.Checked = True
    End Sub

    Private Sub CharToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CharToolStripMenuItem.Click
        UncheckWrapMode()
        TextBox1.WrapMode = WrapMode.Char
        CharToolStripMenuItem.Checked = True
    End Sub

    Private Sub WordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordToolStripMenuItem.Click
        UncheckWrapMode()
        TextBox1.WrapMode = WrapMode.Word
        WordToolStripMenuItem.Checked = True
    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoneToolStripMenuItem.Click
        UncheckWrapMode()
        TextBox1.WrapMode = WrapMode.None
        WordToolStripMenuItem.Checked = True
    End Sub

#End Region

    Private Sub HighlightCurrentLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighlightCurrentLineToolStripMenuItem.Click
        If TextBox1.HighlightCurrentLine Then
            TextBox1.HighlightCurrentLine = False
            HighlightCurrentLineToolStripMenuItem.Checked = False
        Else
            TextBox1.HighlightCurrentLine = True
            HighlightCurrentLineToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub ViewEOLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewEOLToolStripMenuItem.Click
        If TextBox1.ViewEol Then
            TextBox1.ViewEol = False
            ViewEOLToolStripMenuItem.Checked = False
        Else
            TextBox1.ViewEol = True
            ViewEOLToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub HighlightMatchingSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighlightMatchingSelectionToolStripMenuItem.Click
        If TextBox1.HighlightMatchingSelection Then
            TextBox1.HighlightMatchingSelection = False
            HighlightMatchingSelectionToolStripMenuItem.Checked = False
        Else
            TextBox1.HighlightMatchingSelection = True
            HighlightMatchingSelectionToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub SmartIndentationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SmartIndentationToolStripMenuItem.Click
        If TextBox1.SmartIndentation Then
            TextBox1.SmartIndentation = False
            SmartIndentationToolStripMenuItem.Checked = False
        Else
            TextBox1.SmartIndentation = True
            SmartIndentationToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub SmartCompletionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SmartCompletionToolStripMenuItem.Click
        If TextBox1.SmartCompletion Then
            TextBox1.SmartCompletion = False
            SmartCompletionToolStripMenuItem.Checked = False
        Else
            TextBox1.SmartCompletion = True
            SmartCompletionToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub IntelliSenseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IntelliSenseToolStripMenuItem.Click
        If TextBox1.AutoComplete Then
            TextBox1.AutoComplete = False
            IntelliSenseToolStripMenuItem.Checked = False
        Else
            TextBox1.AutoComplete = True
            IntelliSenseToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub IndentationGuidesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndentationGuidesToolStripMenuItem.Click
        If TextBox1.IndentationGuides Then
            TextBox1.IndentationGuides = False
            IndentationGuidesToolStripMenuItem.Checked = False
        Else
            TextBox1.IndentationGuides = True
            IndentationGuidesToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub OvertypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OvertypeToolStripMenuItem.Click
        If TextBox1.OverType Then
            TextBox1.OverType = False
            OvertypeToolStripMenuItem.Checked = False
        Else
            TextBox1.OverType = True
            OvertypeToolStripMenuItem.Checked = True
        End If
    End Sub

#End Region

#Region "About"

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        Dim newb As New frmAbout
        newb.ShowDialog()
    End Sub

    Private Sub BioNetWorksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BioNetWorksToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.bionetworkscorp.net/")
    End Sub

#End Region

#End Region

#Region "Methods"

    'Unchecks all language menu items
    Private Sub UncheckLanguage()
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
    End Sub

    'Get the page source of a web page (HTML scraper). Helper method that runs in the threadpool
    Private Sub thread_ce_ScrapeHTML(ByVal b As String)
        Dim request As WebRequest = WebRequest.Create(b)
        Using response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                Dim html As String = reader.ReadToEnd()
                TextBox1.InsertText(html)
            End Using
        End Using
    End Sub

    'Loads a file into the editor
    Public Sub LoadFile(ByVal floc As String, ByVal lang As Language.EditorLanguage)
        If System.IO.File.Exists(floc) Then
            Try
                Dim t As Task = Task.Factory.StartNew(Sub()
                                                          TextBox1.Text = My.Computer.FileSystem.ReadAllText(floc)
                                                          TextBox1.Saved = True
                                                          TextBox1.Language = lang
                                                          fileloc = floc
                                                      End Sub)
            Catch ex As Exception
            End Try
        Else
            MetroMessageBox.Show(Me, "Error: The file does not exist or could not be found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub OpenFile(ByVal filelocation As String)
        fileloc = filelocation
        LoadFile(fileloc, LanguageEnum.ConvertExtensionToEnum(System.IO.Path.GetExtension(fileloc)))
    End Sub

    'Initializes the editor, sets properties/values
    Private Sub InitializeEditor()
        TextBox1.SetSyntaxHighlightingArray(SyntaxHighlighting.GetHighlightArray)

        TextBox1.CustomLanguageEnabled = False


        TextBox1.EolMode = ScintillaNET.Eol.CrLf

        TextBox1.ViewEol = False

        TextBox1.CaretStyle = ScintillaNET.CaretStyle.Line

        TextBox1.AllowDrop = False

        TextBox1.OverType = False

        TextBox1.HighlightCurrentLine = False

        TextBox1.MatchBraces = True

        TextBox1.IndentationGuides = True

        TextBox1.SmartIndentation = True

        TextBox1.SmartCompletion = True

        TextBox1.AutoComplete = True

        TextBox1.HighlightMatchingSelection = True

        TextBox1.MultiPaste = True

        TextBox1.MultipleSelection = True

        TextBox1.WrapMode = ScintillaNET.WrapMode.None
    End Sub

    'Saves the current file
    Public Sub SaveFile()
        Try
            Dim objWriter As New System.IO.StreamWriter(fileloc, False)
            objWriter.Write(TextBox1.Text)
            objWriter.Close()
            TextBox1.Saved = True
        Catch ex As Exception
        End Try
    End Sub

    'Saves the file to a specified location
    Public Sub SaveFileAs(ByVal filelocation As String)
        Try
            fileloc = filelocation
            Dim objWriter As New System.IO.StreamWriter(fileloc, False)
            objWriter.Write(TextBox1.Text)
            objWriter.Close()
            TextBox1.Saved = True
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "TextBox1"

    Private Sub TextBox1_LanguageChanged() Handles TextBox1.LanguageChanged
        UncheckLanguage()
        Select Case TextBox1.Language
            Case Language.EditorLanguage.Ada
                AdaToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Assembly
                AssemblyToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Batch
                BatchToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Csharp
                CToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Cpp
                CToolStripMenuItem1.Checked = True
            Case Language.EditorLanguage.Css
                CSSToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Fortran
                FortranToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Html
                HTMLToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Java
                JavaToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.JavaScript
                JavaScriptToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Lisp
                LispToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Lua
                LuaToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Pascal
                PascalToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Perl
                PerlToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Php
                PHPToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.PlainText
                PlainTextToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Psql
                PostgreSQLToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Python
                PythonToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Ruby
                RubyToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.SmallTalk
                SmalltalkToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Sql
                SQLToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.VB
                VBScriptToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Xml
                XMLToolStripMenuItem.Checked = True
            Case Language.EditorLanguage.Yaml
                YAMLToolStripMenuItem.Checked = True
            Case Else
                PlainTextToolStripMenuItem.Checked = True
        End Select
    End Sub

    Private Sub TextBox1_SavePointLeft(sender As Object, e As EventArgs) Handles TextBox1.SavePointLeft
        If fileloc = "" Then
            Me.Text = "Untitled* - Quick Editor"
            Me.Refresh()
        Else
            Me.Text = System.IO.Path.GetFileName(fileloc) & "* - Quick Editor"
            Me.Refresh()
        End If
        issaved = False
    End Sub

    Private Sub TextBox1_SavePointReached(sender As Object, e As EventArgs) Handles TextBox1.SavePointReached
        If fileloc = "" Then
            Me.Text = "Untitled - Quick Editor"
            Me.Refresh()
        Else
            Me.Text = System.IO.Path.GetFileName(fileloc) & " - Quick Editor"
            Me.Refresh()
        End If
        issaved = True
    End Sub

#End Region

#Region "frmMain"

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If issaved = False Then
            If MetroMessageBox.Show(Me, "You have unsaved changes, are you sure you want to exit without saving?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeEditor()
    End Sub

#End Region

#Region "Context Menu Strip"

    Private Sub UndoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem1.Click
        TextBox1.ExecuteCommand(ScintillaNET.Command.Undo)
    End Sub

    Private Sub RedoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem1.Click
        TextBox1.ExecuteCommand(ScintillaNET.Command.Redo)
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

    Private Sub FindReplaceToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FindReplaceToolStripMenuItem1.Click
        TextBox1.ShowFindReplace()
    End Sub

    Private Sub GotoLineToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GotoLineToolStripMenuItem1.Click
        TextBox1.ShowGoto()
    End Sub

    Private Sub SearchToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem1.Click
        TextBox1.ShowIncrementalSearcher()
    End Sub

#End Region

End Class