Imports ScintillaNET
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions
Imports XDev.Editor.Language

Public Class XEditor
    'Indicator 8 = Matching selected words when clicked on
    'Indicator 9 = Found Highlighted Words
    'Indicator 10 = DocumentMap Highlight
    'Indicator 11 = Present Highlight
    'Marker 1 = Changed Line **removed for now
    
#Region "Variables"

    Private _curlang As EditorLanguage = EditorLanguage.PlainText 'The current language of the editor
    Private _fontname As String = "Consolas" 'The current font name of the editor
    Private _fontsize As Integer = 10 'Set in the editor that the dialog is no longer being displayed
    Private _fonto As Font 'Font object that wraps font size and name
    Private _autoclist As String = "" 'The auto complete list
    Private _maxLineNumberCharLength As Integer 'Character length used to determine width of line number margin
    Private _lastCaretPos As Integer = 0 'The last position of the caret
    Private _bracematch As Boolean = True 'Whether or not to match braces
    Public finddlgshowing As Boolean = False 'Whether the find replace dialog is showing
    Public gotodlgshowing As Boolean = False 'Whether the goto line dialog is showing
    Private _pagesetup As PrintDocument = New PrintDocument() 'The page setup object
    Private _psissetup As Boolean = False '_pagesetup is setup
    Private _smartcompletion_pressedkey As System.Windows.Forms.Keys 'Stores the key pressed (delete, back, none) to be used for smart completion
    Private _custlang_keyword0 As String = "" 'Keyword 0 list for a custom language
    Private _custlang_keyword1 As String = "" 'Keyword 1 list for a custom language
    Private _custlang_autoclist As String = "" 'Autocomplete list for a custom language
    Private mousedwellposition As Integer = 0 'Position of mouse when mouse is dwelling
    Private SyntaxHighlightingArray(87) As Color 'Array of colors for syntax highlighting
    Public searchselect_start As Integer = -1 'Selection start anchor
    Public searchselect_end As Integer = -1 'Selection end anchor
    Private tabtriggerslist As List(Of String) 'List of tab triggers
    Public codetemplatelist As List(Of String) 'List of code templates
    Public codetemplatesdlgshowing As Boolean = False 'Whether the code templates dialog is showing
    Public clipboardhistorydlgshowing As Boolean = False 'Whether the clipboard history dialog is showing
    Private blockhighlight As Boolean = False 'Highlighting of folding blocks
    Public insertsymboldlgshowing As Boolean = False 'Whether the insert symbol dialog is showing
    Public listclipboardhistory As List(Of String) 'Clipboard history
    Public justpasted As Boolean = False 'Whether something was pasted into the editor and not yet added to the clipboard history
    Private hekeysnavwrapline As Boolean = False 'Whether the home and end keys navigate wrapped lines
    Public cmdpalettedlgshowing As Boolean = False 'Whether the command palette dialog is showing
    Public insertguiddlgshowing As Boolean = False 'Whether the insert GUID dialog is showing

#End Region

#Region "Enum"

    'The mode the editor is in - default is editor.
    Enum Mode
        Editor
        DocumentMap
    End Enum

#End Region

#Region "Syntax Colors"

    'Default use of color is to use as forecolor for text, unless otherwise specified
    Private COLOR_DEFAULT As Color = Color.Black
    Private COLOR_COMMENT As Color = Color.FromArgb(0, 128, 0) 'Green
    Private COLOR_COMMENTBLOCK As Color = Color.FromArgb(0, 128, 0) 'Green
    Private COLOR_COMMENTLINE As Color = Color.FromArgb(0, 128, 0) 'Green
    Private COLOR_COMMENTLINEDOC As Color = Color.FromArgb(128, 128, 128) 'Grey
    Private COLOR_NUMBER As Color = Color.Goldenrod
    Private COLOR_WORD As Color = Color.Blue
    Private COLOR_WORD2 As Color = Color.Blue
    Private COLOR_WORD3 As Color = Color.Blue
    Private COLOR_STRING As Color = Color.FromArgb(163, 21, 21) 'Red
    Private COLOR_CHARACTER As Color = Color.FromArgb(163, 21, 21) 'Red
    Private COLOR_VERBATIM As Color = Color.FromArgb(163, 21, 21) 'Red
    Private COLOR_STRINGEOL As Color = Color.Pink 'Use as BackColor
    Private COLOR_CHARACTEREOL As Color = Color.Pink 'Use as BackColor
    Private COLOR_OPERATOR As Color = Color.Purple
    Private COLOR_PREPROCESSOR As Color = Color.Maroon
    Private COLOR_DELIMITER As Color = Color.LightCoral
    Private COLOR_LABEL As Color = Color.Brown
    Private COLOR_ILLEGAL As Color = Color.Red
    Private COLOR_IDENTIFIER As Color = Color.Black
    Private COLOR_CPUINSTRUCTION As Color = Color.DarkBlue
    Private COLOR_MATHINSTRUCTION As Color = Color.Blue
    Private COLOR_EXTINSTRUCTION As Color = Color.LightBlue
    Private COLOR_REGISTER As Color = Color.Purple
    Private COLOR_DIRECTIVE As Color = Color.Blue
    Private COLOR_DIRECTIVEOPERAND As Color = Color.DarkBlue
    Private COLOR_HIDE As Color = Color.HotPink
    Private COLOR_TRIPLE As Color = Color.FromArgb(&H7F, &H0, &H0)
    Private COLOR_TRIPLEDOUBLE As Color = Color.FromArgb(&H7F, &H0, &H0)
    Private COLOR_CLASSNAME As Color = Color.FromArgb(&H0, &H0, &HFF)
    Private COLOR_DEFNAME As Color = Color.FromArgb(&H0, &H7F, &H7F)
    Private COLOR_DECORATOR As Color = Color.FromArgb(&H80, &H50, &H0)
    Private COLOR_UUID As Color = Color.FromArgb(163, 21, 21) 'Red
    Private COLOR_REGEX As Color = Color.Black
    Private COLOR_COMMENTDOCKEYWORD As Color = Color.DarkCyan
    Private COLOR_COMMENTDOCKEYWORDERROR As Color = Color.DarkCyan
    Private COLOR_TAG As Color = Color.Blue
    Private COLOR_TAGUNKNOWN As Color = Color.Black
    Private COLOR_PSEUDOCLASS As Color = Color.Orange
    Private COLOR_UNKNOWNPSEUDOCLASS As Color = Color.LightCoral
    Private COLOR_UNKNOWNIDENTIFIER As Color = Color.Black
    Private COLOR_VALUE As Color = Color.Orange
    Private COLOR_ID As Color = Color.RoyalBlue
    Private COLOR_IMPORTANT As Color = Color.Red
    Private COLOR_ATTRIBUTE As Color = Color.Red
    Private COLOR_ATTRIBUTEUNKNOWN As Color = Color.Black
    Private COLOR_ENTITY As Color = Color.Black
    Private COLOR_CONTINUATION As Color = Color.FromArgb(0, 128, 0) 'Green
    Private COLOR_DOUBLESTRING As Color = Color.Purple
    Private COLOR_OTHER As Color = Color.Black
    Private COLOR_XMLSTART As Color = Color.Blue
    Private COLOR_XMLEND As Color = Color.Blue
    Private COLOR_SCRIPT As Color = Color.Plum
    Private COLOR_ASP As Color = Color.Plum
    Private COLOR_ASPAT As Color = Color.Plum
    Private COLOR_QUESTION As Color = Color.DarkGray
    Private COLOR_CDATA As Color = Color.Orange
    Private COLOR_XCCOMMENT As Color = Color.FromArgb(0, 128, 0) 'Green
    Private COLOR_SPECIAL As Color = Color.RoyalBlue
    Private COLOR_SYMBOL As Color = Color.Navy
    Private COLOR_INSTRUCTIONWORD As Color = Color.Blue
    Private COLOR_SCALAR As Color = Color.Orange
    Private COLOR_ARRAY As Color = Color.Purple
    Private COLOR_HASH As Color = Color.MediumPurple
    Private COLOR_SYMBOLTABLE As Color = Color.Red
    Private COLOR_DATASECTION As Color = Color.Maroon
    Private COLOR_POD As Color = Color.Black
    Private COLOR_LONGQUOTE As Color = Color.Orange
    Private COLOR_BACKTICKS As Color = Color.Yellow
    Private COLOR_PUNCTUATION As Color = Color.Brown
    Private COLOR_VARIABLE As Color = Color.Navy
    Private COLOR_GLOBAL As Color = Color.DarkBlue
    Private COLOR_MODULENAME As Color = Color.Brown
    Private COLOR_INSTANCEVAR As Color = Color.Black
    Private COLOR_STDIN As Color = Color.LightBlue
    Private COLOR_STDOUT As Color = Color.Blue
    Private COLOR_STDERR As Color = Color.Red
    Private COLOR_UPPERBOUND As Color = Color.LightCoral
    Private COLOR_WORDDEMOTED As Color = Color.DarkGoldenrod
    Private COLOR_CLASSVAR As Color = Color.DarkCyan
    Private COLOR_SPECSEL As Color = Color.Pink
    Private COLOR_ASSIGN As Color = Color.Red
    Private COLOR_KWSEND As Color = Color.RoyalBlue
    Private COLOR_RETURN As Color = Color.Blue
    Private COLOR_NIL As Color = Color.Purple
    Private COLOR_BINARY As Color = Color.Navy
    Private COLOR_SUPER As Color = Color.LightBlue
    Private COLOR_SELF As Color = Color.MediumSlateBlue

#End Region

#Region "Properties"

    ''' <summary>
    ''' Whether the control can accept data that the user drags onto it
    ''' </summary>
    Shadows Property AllowDrop As Boolean
        Get
            Return Scintilla1.AllowDrop
        End Get
        Set(value As Boolean)
            Scintilla1.AllowDrop = value
        End Set
    End Property

    ''' <summary>
    ''' Whether smart paste is enabled
    ''' </summary>
    Property SmartPaste As Boolean = True

    ''' <summary>
    ''' Whether performance mode is enabled
    ''' </summary>
    Property PerformanceMode As Boolean = False

    ''' <summary>
    ''' Whether smart copy is enabled
    ''' </summary>
    Property SmartCopy As Boolean = True

    ''' <summary>
    ''' Whether the custom language is enabled
    ''' </summary>
    Property CustomLanguageEnabled As Boolean = False

    ''' <summary>
    ''' Whether to highlight matches of the selection
    ''' </summary>
    Property HighlightMatchingSelection As Boolean

    ''' <summary>
    ''' Whether to highlight matches of the current word
    ''' </summary>
    Property HighlightMatchingWords As Boolean

    ''' <summary>
    ''' Whether to record the clipboard history
    ''' </summary>
    Property RecordClipboardHistory As Boolean = True

    ''' <summary>
    ''' Whether the home and end keys navigate wrapped lines
    ''' </summary>
    Property HomeEndKeysNavigateWrappedLines As Boolean
        Get
            Return hekeysnavwrapline
        End Get
        Set(value As Boolean)
            hekeysnavwrapline = value
            If value Then
                Scintilla1.AssignCmdKey(Keys.Home, Command.HomeWrap)
                Scintilla1.AssignCmdKey(Keys.End, Command.LineEndWrap)
            Else
                Scintilla1.AssignCmdKey(Keys.Home, Command.Default)
                Scintilla1.AssignCmdKey(Keys.End, Command.Default)
            End If
        End Set
    End Property

    ''' <summary>
    ''' The clipboard history
    ''' </summary>
    Property ClipboardHistory As List(Of String)
        Get
            Return listclipboardhistory
        End Get
        Set(value As List(Of String))
            listclipboardhistory = value
        End Set
    End Property

    ''' <summary>
    ''' Whether the current folding block is highlighted
    ''' </summary>
    Property HighlightCurrentBlock As Boolean
        Get
            Return blockhighlight
        End Get
        Set(value As Boolean)
            blockhighlight = value
            Scintilla1.MarkerEnableHighlight(value)
        End Set
    End Property

    ''' <summary>
    ''' The list of code templates
    ''' </summary>
    Property CodeTemplates As List(Of String)
        Get
            Return codetemplatelist
        End Get
        Set(value As List(Of String))
            codetemplatelist = value
        End Set
    End Property

    ''' <summary>
    ''' The list of tab triggers
    ''' </summary>
    Property TabTriggers As List(Of String)
        Get
            Return tabtriggerslist
        End Get
        Set(value As List(Of String))
            tabtriggerslist = value
        End Set
    End Property

    ''' <summary>
    ''' Whether tab triggers are enabled
    ''' </summary>
    Property TabTriggersEnabled As Boolean = False

    ''' <summary>
    ''' Whether a tab trigger will replace the line or be inserted in its place
    ''' </summary>
    Property TabTriggersReplacePhrase As Boolean = True

    ''' <summary>
    ''' The current caret position
    ''' </summary>
    Property CurrentPosition As Integer
        Get
            Return Scintilla1.CurrentPosition
        End Get
        Set(value As Integer)
            Scintilla1.CurrentPosition = value
        End Set
    End Property

    ''' <summary>
    ''' Whether the current line is highlighted
    ''' </summary>
    Property HighlightCurrentLine As Boolean
        Get
            Return Scintilla1.CaretLineVisible
        End Get
        Set(value As Boolean)
            Scintilla1.CaretLineVisible = value
        End Set
    End Property

    Property MultiSelectionTyping As Boolean
        Get
            Return Scintilla1.AdditionalSelectionTyping
        End Get
        Set(value As Boolean)
            Scintilla1.AdditionalSelectionTyping = value
        End Set
    End Property

    Property CaretStyle As ScintillaNET.CaretStyle
        Get
            Return Scintilla1.CaretStyle
        End Get
        Set(value As ScintillaNET.CaretStyle)
            Scintilla1.CaretStyle = value
        End Set
    End Property

    Property SelectedText As String
        Get
            Return Scintilla1.SelectedText
        End Get
        Set(value As String)
            Scintilla1.ReplaceSelection(value)
        End Set
    End Property

    Property Document As ScintillaNET.Document
        Get
            Return Scintilla1.Document
        End Get
        Set(value As ScintillaNET.Document)
            Scintilla1.Document = value
        End Set
    End Property

    Property Saved As Boolean
        Get
            Return Scintilla1.Modified
        End Get
        Set(value As Boolean)
            If value = True Then
                Scintilla1.SetSavePoint()
            End If
        End Set
    End Property

    Property SmartIndentation As Boolean

    Property MatchBraces() As Boolean
        Get
            Return _bracematch
        End Get
        Set(value As Boolean)
            _bracematch = value
        End Set
    End Property

    Property EditorMode() As Mode = Mode.Editor

    Public Property SmartCompletion As Boolean = False

    Public Property AutoComplete() As Boolean

    Property Language() As Language.EditorLanguage
        Get
            Return _curlang
        End Get
        Set(value As Language.EditorLanguage)
            SetLanguage(value)
            RaiseEvent LanguageChanged()
        End Set
    End Property

    Shadows Property Font As Font
        Get
            If _fonto Is Nothing Then
                _fonto = New Font(_fontname, _fontsize)
                Return _fonto
            Else
                Return _fonto
            End If
        End Get
        Set(value As Font)
            _fonto = value
            _fontsize = value.Size
            _fontname = value.Name
            UpdateSyntaxHighlighting()
        End Set
    End Property

    Shadows Property Text() As String
        Get
            Return Scintilla1.Text
        End Get
        Set(value As String)
            Scintilla1.Text = value
        End Set
    End Property

    Shadows Property RightToLeft() As Boolean
        Get
            If Scintilla1.RightToLeft = Windows.Forms.RightToLeft.Yes Then
                Return True
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            If value = True Then
                Scintilla1.RightToLeft = Windows.Forms.RightToLeft.Yes
            Else
                Scintilla1.RightToLeft = Windows.Forms.RightToLeft.No
            End If
        End Set
    End Property

    Property EditorAllowDrop() As Boolean
        Get
            Return Scintilla1.AllowDrop
        End Get
        Set(value As Boolean)
            Scintilla1.AllowDrop = value
        End Set
    End Property

    Property MultiPaste() As ScintillaNET.MultiPaste
        Get
            Return Scintilla1.MultiPaste
        End Get
        Set(value As ScintillaNET.MultiPaste)
            Scintilla1.MultiPaste = value
        End Set
    End Property

    Property MultipleSelection() As Boolean
        Get
            Return Scintilla1.MultipleSelection
        End Get
        Set(value As Boolean)
            Scintilla1.MultipleSelection = value
        End Set
    End Property

    Property IsReadOnly() As Boolean
        Get
            Return Scintilla1.ReadOnly
        End Get
        Set(value As Boolean)
            Scintilla1.ReadOnly = value
        End Set
    End Property

    Property OverType() As Boolean
        Get
            Return Scintilla1.Overtype
        End Get
        Set(value As Boolean)
            Scintilla1.Overtype = value
        End Set
    End Property

    Property UseTabs() As Boolean
        Get
            Return Scintilla1.UseTabs
        End Get
        Set(value As Boolean)
            Scintilla1.UseTabs = value
        End Set
    End Property

    Shadows Property UseWaitCursor() As Boolean
        Get
            Return Scintilla1.UseWaitCursor
        End Get
        Set(value As Boolean)
            Scintilla1.UseWaitCursor = value
        End Set
    End Property

    Property ViewWhitespace() As ScintillaNET.WhitespaceMode
        Get
            Return Scintilla1.ViewWhitespace
        End Get
        Set(value As ScintillaNET.WhitespaceMode)
            Scintilla1.ViewWhitespace = value
        End Set
    End Property

    Property ViewEol() As Boolean
        Get
            Return Scintilla1.ViewEol
        End Get
        Set(value As Boolean)
            Scintilla1.ViewEol = value
        End Set
    End Property

    Property WrapMode() As ScintillaNET.WrapMode
        Get
            Return Scintilla1.WrapMode
        End Get
        Set(value As ScintillaNET.WrapMode)
            Scintilla1.WrapMode = value
        End Set
    End Property

    Property WrapIndentMode() As ScintillaNET.WrapIndentMode
        Get
            Return Scintilla1.WrapIndentMode
        End Get
        Set(value As ScintillaNET.WrapIndentMode)
            Scintilla1.WrapIndentMode = value
        End Set
    End Property

    Property Zoom() As Integer
        Get
            Return Scintilla1.Zoom
        End Get
        Set(value As Integer)
            Scintilla1.Zoom = value
        End Set
    End Property

    Property Technology() As ScintillaNET.Technology
        Get
            Return Scintilla1.Technology
        End Get
        Set(value As ScintillaNET.Technology)
            Scintilla1.Technology = value
        End Set
    End Property

    Property TabWidth() As Integer
        Get
            Return Scintilla1.TabWidth
        End Get
        Set(value As Integer)
            Scintilla1.TabWidth = value
        End Set
    End Property

    Property PasteConvertEndings() As Boolean
        Get
            Return Scintilla1.PasteConvertEndings
        End Get
        Set(value As Boolean)
            Scintilla1.PasteConvertEndings = value
        End Set
    End Property

    Property MouseDwellTime() As Integer
        Get
            Return Scintilla1.MouseDwellTime
        End Get
        Set(value As Integer)
            Scintilla1.MouseDwellTime = value
        End Set
    End Property

    Property MouseSelectionRectangularSwitch() As Boolean
        Get
            Return Scintilla1.MouseSelectionRectangularSwitch
        End Get
        Set(value As Boolean)
            Scintilla1.MouseSelectionRectangularSwitch = value
        End Set
    End Property

    Property Lexer() As ScintillaNET.Lexer
        Get
            Return Scintilla1.Lexer
        End Get
        Set(value As ScintillaNET.Lexer)
            Scintilla1.Lexer = value
        End Set
    End Property

    Property IndentWidth() As Integer
        Get
            Return Scintilla1.IndentWidth
        End Get
        Set(value As Integer)
            Scintilla1.IndentWidth = value
        End Set
    End Property

    Property FontQuality() As ScintillaNET.FontQuality
        Get
            Return Scintilla1.FontQuality
        End Get
        Set(value As ScintillaNET.FontQuality)
            Scintilla1.FontQuality = value
        End Set
    End Property

    Property HScrollBar() As Boolean
        Get
            Return Scintilla1.HScrollBar
        End Get
        Set(value As Boolean)
            Scintilla1.HScrollBar = value
        End Set
    End Property

    Property VScrollBar() As Boolean
        Get
            Return Scintilla1.VScrollBar
        End Get
        Set(value As Boolean)
            Scintilla1.VScrollBar = value
        End Set
    End Property

    Property IndentationGuides() As ScintillaNET.IndentView
        Get
            Return Scintilla1.IndentationGuides
        End Get
        Set(value As ScintillaNET.IndentView)
            Scintilla1.IndentationGuides = value
        End Set
    End Property

    Property EndAtLastLine() As Boolean
        Get
            Return Scintilla1.EndAtLastLine
        End Get
        Set(value As Boolean)
            Scintilla1.EndAtLastLine = value
        End Set
    End Property

    Shadows Property ContextMenuStrip() As System.Windows.Forms.ContextMenuStrip
        Get
            Return Scintilla1.ContextMenuStrip
        End Get
        Set(value As System.Windows.Forms.ContextMenuStrip)
            Scintilla1.ContextMenuStrip = value
        End Set
    End Property

    Property EolMode() As ScintillaNET.Eol
        Get
            Return Scintilla1.EolMode
        End Get
        Set(value As ScintillaNET.Eol)
            Scintilla1.EolMode = value
        End Set
    End Property

#End Region

#Region "Private Methods"

#Region "Snippet List"

    Private Sub listbox_snippetlist_KeyDown(sender As Object, e As KeyEventArgs) Handles listbox_snippetlist.KeyDown
        If e.KeyCode = Keys.Enter Then
            If listbox_snippetlist.SelectedIndex <> -1 Then
                Scintilla1.InsertText(Scintilla1.CurrentPosition, listbox_snippetlist.SelectedItem)
                HideSnippetListIfVisible()
            End If
        End If
    End Sub

    Private Sub listbox_snippetlist_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles listbox_snippetlist.MouseDoubleClick
        If listbox_snippetlist.SelectedIndex <> -1 Then
            Scintilla1.InsertText(Scintilla1.CurrentPosition, listbox_snippetlist.SelectedItem)
            HideSnippetListIfVisible()
        End If
    End Sub

    Private Sub HideSnippetListIfVisible()
        If pnl_snippetlist.Visible Then
            pnl_snippetlist.Hide()
        End If
    End Sub

    Private Sub btn_closesnippetlist_Click(sender As Object, e As EventArgs) Handles btn_closesnippetlist.Click
        pnl_snippetlist.Hide()
    End Sub

#End Region

#Region "SmartCompletion"

    Public Sub RunSmartCompletion()
        Dim curpos As Integer = Scintilla1.CurrentPosition
        Dim curline As Integer = Scintilla1.CurrentLine
        Dim s As EditorLanguage = Language
        Select Case s
            Case EditorLanguage.Ada
                If Scintilla1.GetWordFromPosition(curpos - 1) = "loop" Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end loop;")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Scintilla1.GetWordFromPosition(curpos - 1) = "begin" Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end;")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("if") And Scintilla1.GetWordFromPosition(curpos - 1) = "then" Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end if;")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("case") And Scintilla1.Lines(Scintilla1.CurrentLine).Text.EndsWith("is") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end case;")
                    Scintilla1.Lines(curline + 1).Goto()
                    Scintilla1.CurrentPosition = curpos
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then

                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then

                    Scintilla1.InsertText(curpos, "'")
                End If
            Case EditorLanguage.Assembly
                'None
            Case EditorLanguage.Batch
                'None
            Case EditorLanguage.Csharp
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "*" And Chr(Scintilla1.GetCharAt(curpos - 2)) = "/" Then
                    Scintilla1.InsertText(curpos, "*/")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                End If
            Case EditorLanguage.Cpp
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "*" And Chr(Scintilla1.GetCharAt(curpos - 2)) = "/" Then
                    Scintilla1.InsertText(curpos, "*/")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                End If

            Case EditorLanguage.Css
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                End If
            Case EditorLanguage.Fortran
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("IF") And Scintilla1.Lines(Scintilla1.CurrentLine).Text.EndsWith("THEN") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "END IF")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("PROGRAM") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "END")
                    Scintilla1.Lines(curline + 1).Goto()
                End If
            Case EditorLanguage.Html
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("<") And Chr(Scintilla1.GetCharAt(curpos - 1)) = ">" Then
                    Dim b As String = Scintilla1.Lines(Scintilla1.CurrentLine).Text.Split(">")(0)
                    If b.Contains(" ") = False And b.Contains("/") = False Then
                        'Scintilla1.Lines(Scintilla1.CurrentLine).Text.Remove(curpos)
                        Scintilla1.InsertText(curpos, "</" & Scintilla1.GetWordFromPosition(curpos - 1)) '  & ">"
                        Scintilla1.CurrentPosition = curpos
                    End If
                End If
            Case EditorLanguage.Java
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "*" And Chr(Scintilla1.GetCharAt(curpos - 2)) = "/" Then
                    Scintilla1.InsertText(curpos, "*/")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                End If
            Case EditorLanguage.JavaScript
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "*" And Chr(Scintilla1.GetCharAt(curpos - 2)) = "/" Then
                    Scintilla1.InsertText(curpos, "*/")
                End If
            Case EditorLanguage.Lisp
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "*" Then
                    Scintilla1.InsertText(curpos, "*")
                End If
            Case EditorLanguage.Lua
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("function") And Scintilla1.Lines(Scintilla1.CurrentLine).Text.EndsWith(")") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("for") And Scintilla1.Lines(Scintilla1.CurrentLine).Text.EndsWith("do") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                End If
            Case EditorLanguage.Pascal
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(*" Then
                    Scintilla1.InsertText(curpos, "*)")
                ElseIf Scintilla1.GetWordFromPosition(curpos - 1) = "BEGIN" Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end;")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                End If
            Case EditorLanguage.Perl
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                End If
            Case EditorLanguage.Php
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("<?php") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "?>")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                End If
            Case EditorLanguage.Psql
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                End If
            Case EditorLanguage.Python
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "{" Then
                    Scintilla1.InsertText(curpos, "}")
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("<?php") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "?>")
                    Scintilla1.Lines(curline + 1).Goto()
                End If
            Case EditorLanguage.Ruby
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("if") And Scintilla1.Lines(Scintilla1.CurrentLine).Text.EndsWith("then") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end")
                    Scintilla1.Lines(curline + 1).Goto()
                ElseIf Scintilla1.GetWordFromPosition(curpos - 1) = "begin" Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end")
                    Scintilla1.Lines(curline + 1).Goto()
                End If
            Case EditorLanguage.SmallTalk
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "|" Then
                    Scintilla1.InsertText(curpos, "|")
                End If
            Case EditorLanguage.Sql
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                End If
            Case EditorLanguage.VB
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("if") And Scintilla1.Lines(Scintilla1.CurrentLine).Text.EndsWith("then") Then
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.ExecuteCmd(Command.NewLine)
                    Scintilla1.InsertText(curpos, "end if")
                    Scintilla1.Lines(curline + 1).Goto()
                End If
            Case EditorLanguage.Xml
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Scintilla1.Lines(Scintilla1.CurrentLine).Text.StartsWith("<") And Chr(Scintilla1.GetCharAt(curpos - 1)) = ">" Then
                    Dim b As String = Scintilla1.Lines(Scintilla1.CurrentLine).Text.Split(">")(0)
                    If b.Contains(" ") = False And b.Contains("/") = False Then
                        'Scintilla1.Lines(Scintilla1.CurrentLine).Text.Remove(curpos)
                        Scintilla1.InsertText(curpos, "</" & Scintilla1.GetWordFromPosition(curpos - 1) & ">")
                        Scintilla1.CurrentPosition = curpos
                    End If
                End If
            Case EditorLanguage.Yaml
                If Chr(Scintilla1.GetCharAt(curpos - 1)) = """" Then
                    Scintilla1.InsertText(curpos, """")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "'" Then
                    Scintilla1.InsertText(curpos, "'")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "*" And Chr(Scintilla1.GetCharAt(curpos - 2)) = "/" Then
                    Scintilla1.InsertText(curpos, "*/")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "(" Then
                    Scintilla1.InsertText(curpos, ")")
                ElseIf Chr(Scintilla1.GetCharAt(curpos - 1)) = "[" Then
                    Scintilla1.InsertText(curpos, "]")
                End If
        End Select
    End Sub

#End Region

#Region "Incremental Searcher"

    Private Sub HideIncrementalSearcherIfVisible()
        If pnl_incrementalsearcher.Visible Then
            pnl_incrementalsearcher.Hide()
        End If
    End Sub

    Private Sub txt_incrementalsearcher_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_incrementalsearcher.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_incrementalsearcher.BackColor = System.Drawing.SystemColors.Window
            If FindNext(txt_incrementalsearcher.Text, SearchFlags.None, False) = -1 Then
                txt_incrementalsearcher.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub btn_incrementalsearcher_up_Click(sender As Object, e As EventArgs) Handles btn_incrementalsearcher_up.Click
        txt_incrementalsearcher.BackColor = System.Drawing.SystemColors.Window
        If FindPrevious(txt_incrementalsearcher.Text, SearchFlags.None, False) = -1 Then
            txt_incrementalsearcher.BackColor = Color.Red
        End If
    End Sub

    Private Sub btn_incrementalsearcher_down_Click(sender As Object, e As EventArgs) Handles btn_incrementalsearcher_down.Click
        txt_incrementalsearcher.BackColor = System.Drawing.SystemColors.Window
        If FindNext(txt_incrementalsearcher.Text, SearchFlags.None, False) = -1 Then
            txt_incrementalsearcher.BackColor = Color.Red
        End If
    End Sub

    Private Sub btn_incrementalsearcher_close_Click(sender As Object, e As EventArgs) Handles btn_incrementalsearcher_close.Click
        pnl_incrementalsearcher.Hide()
        txt_incrementalsearcher.Text = ""
    End Sub

#End Region

#Region "Document Map"

    Private Function GetMinLinePosForDocumentMap(ByVal curline As Integer)
        If curline < 5 Then
            Return 0
        Else
            Return Scintilla1.Lines(curline - 5).Position
        End If
    End Function

    Private Function GetMaxLinePosForDocumentMap(ByVal curline As Integer)
        If (curline + 5) > (Scintilla1.Lines.Count) Then
            Return Scintilla1.Lines(Scintilla1.Lines.Count - 1).EndPosition
        Else
            Return Scintilla1.Lines(curline + 5).Position
        End If
    End Function

    Private Function CalculateHighlightLengthForDocumentMap(ByVal curline As Integer) As Integer
        Return GetMaxLinePosForDocumentMap(curline) - GetMinLinePosForDocumentMap(curline)
    End Function

#End Region

    Private Sub InitializeLists()
        ClipboardHistory = New List(Of String)
    End Sub

    Private Sub AddSelectedTextToClipboardHistory()
        If RecordClipboardHistory AndAlso Scintilla1.SelectedText <> "" Then
            AddTextToClipboardHistory(Scintilla1.SelectedText)
        End If
    End Sub

    Private Sub ManageKeyboardShortcuts()
        Scintilla1.AssignCmdKey(Keys.Control Or Keys.H, Command.Null) 'Code Templates
        Scintilla1.AssignCmdKey(Keys.Control Or Keys.K, Command.Null) 'Symbols
        Scintilla1.AssignCmdKey(Keys.Control Or Keys.Q, Command.Null) 'Used in studio as quick open
        Scintilla1.AssignCmdKey(Keys.Control Or Keys.W, Command.Null) 'Clipboard history
    End Sub

    Private Sub ClearMatchingWordHighlights()
        Scintilla1.IndicatorCurrent = 8
        Scintilla1.IndicatorClearRange(0, Scintilla1.TextLength)
    End Sub

    Private Sub HighlightAllMatchingWords(ByVal txt As String)
        Try
            If FindAll(txt, SearchFlags.None, False).Count > 1 Then
                ' Indicators 0-7 could be in use by a lexer
                ' so we'll use indicator 8 to highlight words.
                Const NUM As Integer = 8
                ' Remove all uses of our indicator
                Scintilla1.IndicatorCurrent = NUM
                Scintilla1.IndicatorClearRange(0, Scintilla1.TextLength)

                ' Update indicator appearance
                Scintilla1.Indicators(NUM).Style = IndicatorStyle.StraightBox
                Scintilla1.Indicators(NUM).Under = True
                Scintilla1.Indicators(NUM).ForeColor = Color.Green
                Scintilla1.Indicators(NUM).OutlineAlpha = 50
                Scintilla1.Indicators(NUM).Alpha = 30

                ' Search the document
                Scintilla1.TargetStart = 0
                Scintilla1.TargetEnd = Scintilla1.TextLength
                Scintilla1.SearchFlags = SearchFlags.None
                While Scintilla1.SearchInTarget(txt) <> -1
                    ' Mark the search results with the current indicator
                    Scintilla1.IndicatorFillRange(Scintilla1.TargetStart, Scintilla1.TargetEnd - Scintilla1.TargetStart)

                    ' Search the remainder of the document
                    Scintilla1.TargetStart = Scintilla1.TargetEnd
                    Scintilla1.TargetEnd = Scintilla1.TextLength
                End While
            End If
        Catch
        End Try
    End Sub
    Private Sub SetCodeFolding()
        If EditorMode = Mode.Editor Then
            Scintilla1.SetProperty("fold", "1")
            Scintilla1.SetProperty("fold.compact", "0")
            Scintilla1.SetProperty("fold.html", "1") 'XML etc.

            ' Configure a margin to display folding symbols
            Scintilla1.Margins(2).Type = MarginType.Symbol
            Scintilla1.Margins(2).Mask = Marker.MaskFolders
            Scintilla1.Margins(2).Sensitive = True
            Scintilla1.Margins(2).Width = 20

            ' Set colors for all folding markers
            For i As Integer = 25 To 31
                Scintilla1.Markers(i).SetForeColor(SystemColors.ControlLightLight)
                Scintilla1.Markers(i).SetBackColor(SystemColors.ControlDark)
            Next

            ' Configure folding markers with respective symbols
            Scintilla1.Markers(Marker.Folder).Symbol = MarkerSymbol.BoxPlus
            Scintilla1.Markers(Marker.FolderOpen).Symbol = MarkerSymbol.BoxMinus
            Scintilla1.Markers(Marker.FolderEnd).Symbol = MarkerSymbol.BoxPlusConnected
            Scintilla1.Markers(Marker.FolderMidTail).Symbol = MarkerSymbol.TCorner
            Scintilla1.Markers(Marker.FolderOpenMid).Symbol = MarkerSymbol.BoxMinusConnected
            Scintilla1.Markers(Marker.FolderSub).Symbol = MarkerSymbol.VLine
            Scintilla1.Markers(Marker.FolderTail).Symbol = MarkerSymbol.LCorner

            ' Enable automatic folding
            Scintilla1.AutomaticFold = (AutomaticFold.Show Or AutomaticFold.Click Or AutomaticFold.Change)
        End If
    End Sub

#End Region

#Region "Public Methods"

#Region "Printing"

    Public Sub ShowPageSetupDialog()
        If _psissetup Then
            Dim newb As New PageSetupDialog
            Dim printer As New PrintDoc()
            printer.PrinterFont = Font
            printer.TextToPrint = Scintilla1.Text
            printer.DefaultPageSettings = _pagesetup.DefaultPageSettings
            newb.PageSettings = _pagesetup.DefaultPageSettings
            newb.Document = printer
            If newb.ShowDialog = DialogResult.OK Then
                _pagesetup.DefaultPageSettings = newb.PageSettings
            End If
        Else
            Dim newb As New PageSetupDialog
            Dim printer As New PrintDoc()
            printer.PrinterFont = Font
            printer.TextToPrint = Scintilla1.Text
            _pagesetup.DefaultPageSettings = printer.DefaultPageSettings
            newb.PageSettings = _pagesetup.DefaultPageSettings
            newb.Document = printer
            If newb.ShowDialog = DialogResult.OK Then
                _pagesetup.DefaultPageSettings = newb.PageSettings
            End If
            _psissetup = True
        End If
    End Sub

    Public Sub ShowPrintPreview()
        If _psissetup Then
            Dim newb As New PrintPreviewDialog
            Dim printer As New PrintDoc()
            printer.PrinterFont = Font
            printer.TextToPrint = Scintilla1.Text
            printer.DefaultPageSettings = _pagesetup.DefaultPageSettings
            newb.Document = printer
            newb.ShowDialog()
        Else
            Dim newb As New PrintPreviewDialog
            Dim printer As New PrintDoc()
            printer.PrinterFont = Font
            printer.TextToPrint = Scintilla1.Text
            _pagesetup.DefaultPageSettings = printer.DefaultPageSettings
            newb.Document = printer
            newb.ShowDialog()
            _psissetup = True
        End If
    End Sub

    Public Sub ShowPrintDialog()
        If _psissetup Then
            Dim newb As New PrintDialog
            Dim printer As New PrintDoc()
            printer.PrinterFont = Font
            printer.TextToPrint = Scintilla1.Text
            newb.PrinterSettings = printer.PrinterSettings
            newb.AllowSomePages = True
            printer.DefaultPageSettings = _pagesetup.DefaultPageSettings
            newb.Document = printer
            If newb.ShowDialog() = DialogResult.OK Then
                printer.PrinterSettings = newb.PrinterSettings
                printer.Print()
            End If
        Else
            Dim newb As New PrintDialog
            Dim printer As New PrintDoc()
            printer.PrinterFont = Font
            printer.TextToPrint = Scintilla1.Text
            newb.Document = printer
            newb.PrinterSettings = printer.PrinterSettings
            newb.AllowSomePages = True
            _pagesetup.DefaultPageSettings = printer.DefaultPageSettings
            If newb.ShowDialog() = DialogResult.OK Then
                printer.PrinterSettings = newb.PrinterSettings
                printer.Print()
            End If
            _psissetup = True
        End If
    End Sub

    Public Sub PrintDocument()
        If _psissetup Then
            Dim printer As New PrintDoc()
            printer.DefaultPageSettings = _pagesetup.DefaultPageSettings
            printer.PrinterFont = Font
            printer.TextToPrint = Scintilla1.Text
            printer.Print()
        Else
            Dim printer As New PrintDoc()
            _pagesetup.DefaultPageSettings = printer.DefaultPageSettings
            printer.PrinterFont = Font
            printer.TextToPrint = Scintilla1.Text
            printer.Print()
            _psissetup = True
        End If
    End Sub

#End Region

#Region "Language"

    Public Sub SetLanguage(ByVal lang As EditorLanguage)
        _curlang = lang
        UpdateSyntaxHighlighting()
    End Sub

    Public Sub UpdateSyntaxHighlighting()
        UpdateBraceStyling()
        Select Case _curlang
            Case EditorLanguage.Ada
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                ' Configure the lexer styles
                Scintilla1.Styles(Style.Ada.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Ada.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Ada.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Ada.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Ada.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Ada.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Ada.Delimiter).ForeColor = COLOR_DELIMITER
                Scintilla1.Styles(Style.Ada.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Ada.Label).ForeColor = COLOR_LABEL
                Scintilla1.Styles(Style.Ada.Illegal).ForeColor = COLOR_ILLEGAL
                Scintilla1.Styles(Style.Ada.CharacterEol).BackColor = COLOR_CHARACTEREOL
                Scintilla1.Styles(Style.Ada.Identifier).ForeColor = COLOR_IDENTIFIER
                'LEXER:
                Scintilla1.Lexer = Lexer.Ada
                'Keywords
                Scintilla1.SetKeywords(0, "abort abstract accept access aliased all and array at begin body case declare delay delta digits do else elsif end entry exception exit for function generic goto if in is limited loop new not null of others out or package pragma private procedure protected raise range record renames requeue return reverse select separate subtype tagged task terminate then type until use when while with")
                Scintilla1.SetKeywords(1, "character string integer float constant")
                'AutoComplete
                _autoclist = AUTOCLIST_ADA
                SetCodeFolding()
            Case EditorLanguage.Assembly
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                ' Configure the lexer styles
                Scintilla1.Styles(Style.Asm.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Asm.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Asm.CommentBlock).ForeColor = COLOR_COMMENTBLOCK
                Scintilla1.Styles(Style.Asm.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Asm.MathInstruction).ForeColor = COLOR_MATHINSTRUCTION
                Scintilla1.Styles(Style.Asm.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Asm.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Asm.CpuInstruction).ForeColor = COLOR_CPUINSTRUCTION
                Scintilla1.Styles(Style.Asm.Register).BackColor = COLOR_REGISTER
                Scintilla1.Styles(Style.Asm.Operator).BackColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Asm.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Asm.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Asm.Directive).ForeColor = COLOR_DIRECTIVE
                Scintilla1.Styles(Style.Asm.DirectiveOperand).BackColor = COLOR_DIRECTIVEOPERAND
                Scintilla1.Styles(Style.Asm.ExtInstruction).ForeColor = COLOR_EXTINSTRUCTION
                'LEXER:
                Scintilla1.Lexer = Lexer.Asm
                'Keywords
                Scintilla1.SetKeywords(0, "aaa aad aam aas adc add and call cbw clc cld cli cmc cmp cmps cmpsb cmpsw cwd daa das dec div esc hlt idiv imul in inc int into iret ja jae jb jbe jc jcxz je jg jge jl jle jmp jna jnae jnb jnbe jnc jne jng jnge jnl jnle jno jnp jns jnz jo jp jpe jpo js jz lahf lds lea les lods lodsb lodsw loop loope loopew loopne loopnew loopnz loopnzw loopw loopz loopzw mov movs movsb movsw mul neg nop not or out pop popf push pushf rcl rcr ret retf retn rol ror sahf sal sar sbb scas scasb scasw shl shr stc std sti stos stosb stosw sub test wait xchg xlat xlatb xor bound enter ins insb insw leave outs outsb outsw popa pusha pushw arpl lar lsl sgdt sidt sldt smsw str verr verw clts lgdt lidt lldt lmsw ltr bsf bsr bt btc btr bts cdq cmpsd cwde insd iretd iretdf iretf jecxz lfs lgs lodsd loopd looped loopned loopnzd loopzd lss movsd movsx movzx outsd popad popfd pushad pushd pushfd scasd seta setae setb setbe setc sete setg setge setl setle setna setnae setnb setnbe setnc setne setng setnge setnl setnle setno setnp setns setnz seto setp setpe setpo sets setz shld shrd stosd bswap cmpxchg invd invlpg wbinvd xadd lock rep repe repne repnz repz cflush cpuid emms femms cmovo cmovno cmovb cmovc cmovnae cmovae cmovnb cmovnc cmove cmovz cmovne cmovnz cmovbe cmovna cmova cmovnbe cmovs cmovns cmovp cmovpe cmovnp cmovpo cmovl cmovnge cmovge cmovnl cmovle cmovng cmovg cmovnle cmpxchg486 cmpxchg8b loadall loadall286 ibts icebp int1 int3 int01 int03 iretw popaw popfw pushaw pushfw rdmsr rdpmc rdshr rdtsc rsdc rsldt rsm rsts salc smi smint smintold svdc svldt svts syscall sysenter sysexit sysret ud0 ud1 ud2 umov xbts wrmsr wrshr f2xm1 fabs fadd faddp fbld fbstp fchs fclex fcom fcomp fcompp fdecstp fdisi fdiv fdivp fdivr fdivrp feni ffree fiadd ficom ficomp fidiv fidivr fild fimul fincstp finit fist fistp fisub fisubr fld fld1 fldcw fldenv fldenvw fldl2e fldl2t fldlg2 fldln2 fldpi fldz fmul fmulp fnclex fndisi fneni fninit fnop fnsave fnsavew fnstcw fnstenv fnstenvw fnstsw fpatan fprem fptan frndint frstor frstorw fsave fsavew fscale fsqrt fst fstcw fstenv fstenvw fstp fstsw fsub fsubp fsubr fsubrp ftst fwait fxam fxch fxtract fyl2x fyl2xp1 fsetpm fcos fldenvd fnsaved fnstenvd fprem1 frstord fsaved fsin fsincos fstenvd fucom fucomp fucompp fcomi fcomip ffreep fcmovb fcmove fcmovbe fcmovu fcmovnb fcmovne fcmovnbe fcmovnu")
                Scintilla1.SetKeywords(1, "ah al ax bh bl bp bx ch cl cr0 cr2 cr3 cr4 cs cx dh di dl dr0 dr1 dr2 dr3 dr6 dr7 ds dx eax ebp ebx ecx edi edx es esi esp fs gs si sp ss st tr3 tr4 tr5 tr6 tr7 st0 st1 st2 st3 st4 st5 st6 st7 mm0 mm1 mm2 mm3 mm4 mm5 mm6 mm7 xmm0 xmm1 xmm2 xmm3 xmm4 xmm5 xmm6 xmm7 .186 .286 .286c .286p .287 .386 .386c .386p .387 .486 .486p .8086 .8087 .alpha .break .code .const .continue .cref .data .data? .dosseg .else .elseif .endif .endw .err .err1 .err2 .errb .errdef .errdif .errdifi .erre .erridn .erridni .errnb .errndef .errnz .exit .fardata .fardata? .if .lall .lfcond .list .listall .listif .listmacro .listmacroall .model .no87 .nocref .nolist .nolistif .nolistmacro .radix .repeat .sall .seq .sfcond .stack .startup .tfcond .type .until .untilcxz .while .xall .xcref .xlist alias align assume catstr comm comment db dd df dosseg dq dt dup dw echo else elseif elseif1 elseif2 elseifb elseifdef elseifdif elseifdifi elseife elseifidn elseifidni elseifnb elseifndef end endif endm endp ends eq equ even exitm extern externdef extrn for forc ge goto group gt high highword if if1 if2 ifb ifdef ifdif ifdifi ife ifidn ifidni ifnb ifndef include includelib instr invoke irp irpc label le length lengthof local low lowword lroffset lt macro mask mod .msfloat name ne offset opattr option org %out page popcontext proc proto ptr public purge pushcontext record repeat rept seg segment short size sizeof sizestr struc struct substr subtitle subttl textequ this title type typedef union while width db dw dd dq dt resb resw resd resq rest incbin equ times %define %idefine %xdefine %xidefine %undef %assign %iassign %strlen %substr %macro %imacro %endmacro %rotate .nolist %if %elif %else %endif %ifdef %ifndef %elifdef %elifndef %ifmacro %ifnmacro %elifmacro %elifnmacro %ifctk %ifnctk %elifctk %elifnctk %ifidn %ifnidn %elifidn %elifnidn %ifidni %ifnidni %elifidni %elifnidni %ifid %ifnid %elifid %elifnid %ifstr %ifnstr %elifstr %elifnstr %ifnum %ifnnum %elifnum %elifnnum %error %rep %endrep %exitrep %include %push %pop %repl struct endstruc istruc at iend align alignb %arg %stacksize %local %line bits use16 use32 section absolute extern global common cpu org section group import export addpd addps addsd addss andpd andps andnpd andnps cmpeqpd cmpltpd cmplepd cmpunordpd cmpnepd cmpnltpd cmpnlepd cmpordpd cmpeqps cmpltps cmpleps cmpunordps cmpneps cmpnltps cmpnleps cmpordps cmpeqsd cmpltsd cmplesd cmpunordsd cmpnesd cmpnltsd cmpnlesd cmpordsd cmpeqss cmpltss cmpless cmpunordss cmpness cmpnltss cmpnless cmpordss comisd comiss cvtdq2pd cvtdq2ps cvtpd2dq cvtpd2pi cvtpd2ps cvtpi2pd cvtpi2ps cvtps2dq cvtps2pd cvtps2pi cvtss2sd cvtss2si cvtsd2si cvtsd2ss cvtsi2sd cvtsi2ss cvttpd2dq cvttpd2pi cvttps2dq cvttps2pi cvttsd2si cvttss2si divpd divps divsd divss fxrstor fxsave ldmxscr lfence mfence maskmovdqu maskmovdq maxpd maxps paxsd maxss minpd minps minsd minss movapd movaps movdq2q movdqa movdqu movhlps movhpd movhps movd movq movlhps movlpd movlps movmskpd movmskps movntdq movnti movntpd movntps movntq movq2dq movsd movss movupd movups mulpd mulps mulsd mulss orpd orps packssdw packsswb packuswb paddb paddsb paddw paddsw paddd paddsiw paddq paddusb paddusw pand pandn pause paveb pavgb pavgw pavgusb pdistib pextrw pcmpeqb pcmpeqw pcmpeqd pcmpgtb pcmpgtw pcmpgtd pf2id pf2iw pfacc pfadd pfcmpeq pfcmpge pfcmpgt pfmax pfmin pfmul pmachriw pmaddwd pmagw pmaxsw pmaxub pminsw pminub pmovmskb pmulhrwc pmulhriw pmulhrwa pmulhuw pmulhw pmullw pmuludq pmvzb pmvnzb pmvlzb pmvgezb pfnacc pfpnacc por prefetch prefetchw prefetchnta prefetcht0 prefetcht1 prefetcht2 pfrcp pfrcpit1 pfrcpit2 pfrsqit1 pfrsqrt pfsub pfsubr pi2fd pf2iw pinsrw psadbw pshufd pshufhw pshuflw pshufw psllw pslld psllq pslldq psraw psrad psrlw psrld psrlq psrldq psubb psubw psubd psubq psubsb psubsw psubusb psubusw psubsiw pswapd punpckhbw punpckhwd punpckhdq punpckhqdq punpcklbw punpcklwd punpckldq punpcklqdq pxor rcpps rcpss rsqrtps rsqrtss sfence shufpd shufps sqrtpd sqrtps sqrtsd sqrtss stmxcsr subpd subps subsd subss ucomisd ucomiss unpckhpd unpckhps unpcklpd unpcklps xorpd xorps $ ? @b @f addr basic byte c carry? dword far far16 fortran fword near near16 overflow? parity? pascal qword real4 real8 real10 sbyte sdword sign? stdcall sword syscall tbyte vararg word zero? flat near32 far32 abs all assumes at casemap common compact cpu dotname emulator epilogue error export expr16 expr32 farstack flat forceframe huge language large listing ljmp loadds m510 medium memory nearstack nodotname noemulator nokeyword noljmp nom510 none nonunique nooldmacros nooldstructs noreadonly noscoped nosignextend nothing notpublic oldmacros oldstructs os_dos para private prologue radix readonly req scoped setif2 smallstack tiny use16 use32 uses a16 a32 o16 o32 byte word dword nosplit $ $$ seq wrt flat large small .text .data .bss near far %0 %1 %2 %3 %4 %5 %6 %7 %8 %9")
                'AutoComplete
                _autoclist = AUTOCLIST_ASSEMBLY
                SetCodeFolding()
            Case EditorLanguage.Batch
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                ' Configure the lexer styles
                Scintilla1.Styles(Style.Batch.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Batch.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Batch.Label).ForeColor = COLOR_LABEL
                Scintilla1.Styles(Style.Batch.Hide).ForeColor = COLOR_HIDE
                Scintilla1.Styles(Style.Batch.Command).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Batch.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Batch.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Batch.Operator).ForeColor = COLOR_OPERATOR
                'LEXER:
                Scintilla1.Lexer = Lexer.Batch
                'Keywords
                Scintilla1.SetKeywords(0, "rem set if else exist errorlevel for in do break call copy chcp cd chdir choice cls country ctty date del erase dir echo exit goto loadfix loadhigh mkdir md move path pause prompt rename ren rmdir rd shift time type ver verify vol com con lpt nul defined not errorlevel cmdextversion")
                Scintilla1.SetKeywords(1, "% @ : == equ neq lss leq gtr geq")
                'AutoComplete
                _autoclist = AUTOCLIST_BATCH
                SetCodeFolding()
            Case EditorLanguage.Cpp
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Cpp.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Cpp.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Cpp.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Cpp.CommentLineDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Cpp.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Cpp.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Cpp.Word2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Cpp.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Cpp.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Cpp.Verbatim).ForeColor = COLOR_VERBATIM
                Scintilla1.Styles(Style.Cpp.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Cpp.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Cpp.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Cpp.Uuid).ForeColor = COLOR_UUID
                Scintilla1.Styles(Style.Cpp.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Cpp.Regex).ForeColor = COLOR_REGEX
                Scintilla1.Styles(Style.Cpp.CommentDocKeyword).ForeColor = COLOR_COMMENTDOCKEYWORD
                Scintilla1.Styles(Style.Cpp.CommentDocKeywordError).ForeColor = COLOR_COMMENTDOCKEYWORDERROR
                'LEXER:
                Scintilla1.Lexer = Lexer.Cpp
                'Keywords
                Scintilla1.SetKeywords(0, "alignof and and_eq bitand bitor break case catch compl const_cast continue default delete do dynamic_cast else false for goto if namespace new not not_eq nullptr operator or or_eq reinterpret_cast return sizeof static_assert static_cast switch this throw true try typedef typeid using while xor xor_eq NULL")
                Scintilla1.SetKeywords(1, "alignas asm auto bool char char16_t char32_t class const constexpr decltype double enum explicit export extern final float friend inline int long mutable noexcept override private protected public register short signed static struct template thread_local typename union unsigned virtual void volatile wchar_t")
                'AutoComplete
                _autoclist = AUTOCLIST_CPP
                SetCodeFolding()
            Case EditorLanguage.Csharp
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Cpp.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Cpp.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Cpp.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Cpp.CommentLineDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Cpp.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Cpp.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Cpp.Word2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Cpp.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Cpp.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Cpp.Verbatim).ForeColor = COLOR_VERBATIM
                Scintilla1.Styles(Style.Cpp.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Cpp.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Cpp.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Cpp.Uuid).ForeColor = COLOR_UUID
                Scintilla1.Styles(Style.Cpp.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Cpp.Regex).ForeColor = COLOR_REGEX
                Scintilla1.Styles(Style.Cpp.CommentDocKeyword).ForeColor = COLOR_COMMENTDOCKEYWORD
                Scintilla1.Styles(Style.Cpp.CommentDocKeywordError).ForeColor = COLOR_COMMENTDOCKEYWORDERROR
                'LEXER:
                Scintilla1.Lexer = Lexer.Cpp
                'Keywords
                Scintilla1.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while")
                Scintilla1.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void")
                'AutoComplete
                _autoclist = AUTOCLIST_CSHARP
                SetCodeFolding()
            Case EditorLanguage.Css
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Css.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Css.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Css.Tag).ForeColor = COLOR_TAG
                Scintilla1.Styles(Style.Css.Class).ForeColor = COLOR_CLASSNAME
                Scintilla1.Styles(Style.Css.PseudoClass).ForeColor = COLOR_PSEUDOCLASS
                Scintilla1.Styles(Style.Css.UnknownPseudoClass).ForeColor = COLOR_UNKNOWNPSEUDOCLASS
                Scintilla1.Styles(Style.Css.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Css.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Css.UnknownIdentifier).ForeColor = COLOR_UNKNOWNIDENTIFIER
                Scintilla1.Styles(Style.Css.Value).ForeColor = COLOR_VALUE
                Scintilla1.Styles(Style.Css.Id).BackColor = COLOR_ID
                Scintilla1.Styles(Style.Css.DoubleString).ForeColor = COLOR_DOUBLESTRING
                Scintilla1.Styles(Style.Css.SingleString).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Css.Directive).ForeColor = COLOR_DIRECTIVE
                Scintilla1.Styles(Style.Css.Identifier2).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Css.Identifier3).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Css.Attribute).ForeColor = COLOR_ATTRIBUTE
                Scintilla1.Styles(Style.Css.PseudoElement).ForeColor = Color.Red
                Scintilla1.Styles(Style.Css.Media).ForeColor = Color.Red
                Scintilla1.Styles(Style.Css.Variable).ForeColor = Color.Red
                'LEXER:
                Scintilla1.Lexer = Lexer.Css
                'Keywords
                Scintilla1.SetKeywords(0, "-khtml-border-radius -khtml-opacity -khtml-background-clip -khtml-background-origin -khtml-background-size -khtml-border-top-left-radius -khtml-border-top-right-radius -khtml-border-bottom-right-radius -khtml-border-bottom-left-radius -moz-animation -moz-animation-delay -moz-animation-direction -moz-animation-duration -moz-animation-fill-mode -moz-animation-iteration-count -moz-animation-name -moz-animation-play-state -moz-animation-timing-function -moz-appearance -moz-background-clip -moz-background-inline-policy -moz-background-origin -moz-background-size -moz-binding -moz-border-bottom-colors -moz-border-end -moz-border-end-color -moz-border-end-style -moz-border-end-width -moz-border-image -moz-border-left-colors -moz-border-radius -moz-border-radius-bottomleft -moz-border-radius-bottomright -moz-border-radius-topleft -moz-border-radius-topright -moz-border-right-colors -moz-border-start -moz-border-start-color -moz-border-start-style -moz-border-start-width -moz-border-top-colors -moz-box-align -moz-box-direction -moz-box-flex -moz-box-flex-group -moz-box-flexgroup -moz-box-ordinal-group -moz-box-orient -moz-box-pack -moz-box-shadow -moz-box-sizing -moz-column-count -moz-column-gap -moz-column-rule -moz-column-rule-color -moz-column-rule-style -moz-column-rule-width -moz-column-width -moz-float-edge -moz-force-broken-image-icon -moz-image-region -moz-linear-gradient -moz-margin-end -moz-margin-start -moz-opacity -moz-outline -moz-outline-color -moz-outline-offset -moz-outline-radius -moz-outline-radius-bottomleft -moz-outline-radius-bottomright -moz-outline-radius-topleft -moz-outline-radius-topright -moz-outline-style -moz-outline-width -moz-padding-end -moz-padding-start -moz-radial-gradient -moz-stack-sizing -moz-text-decoration-color -moz-text-decoration-line -moz-text-decoration-style -moz-transform -moz-transform-origin -moz-transition -moz-transition-delay -moz-transition-duration -moz-transition-property -moz-transition-timing-function -moz-user-focus -moz-user-input -moz-user-modify -moz-user-select -moz-window-shadow -ms-filter -ms-transform  -ms-transform-origin -o-transform -webkit-animation -webkit-animation-delay -webkit-animation-direction -webkit-animation-duration -webkit-animation-fill-mode -webkit-animation-iteration-count -webkit-animation-name -webkit-animation-play-state -webkit-animation-timing-function -webkit-appearance -webkit-backface-visibility -webkit-background-clip -webkit-background-composite -webkit-background-origin -webkit-background-size -webkit-border-bottom-left-radius -webkit-border-bottom-right-radius -webkit-border-horizontal-spacing -webkit-border-image -webkit-border-radius -webkit-border-top-left-radius -webkit-border-top-right-radius -webkit-border-vertical-spacing -webkit-box-align -webkit-box-direction -webkit-box-flex -webkit-box-flex-group -webkit-box-lines -webkit-box-ordinal-group -webkit-box-orient -webkit-box-pack -webkit-box-reflect -webkit-box-shadow -webkit-box-sizing -webkit-column-break-after -webkit-column-break-before -webkit-column-break-inside -webkit-column-count -webkit-column-gap -webkit-column-rule -webkit-column-rule-color -webkit-column-rule-style -webkit-column-rule-width -webkit-column-width -webkit-columns -webkit-dashboard-region -webkit-font-smoothing -webkit-gradient -webkit-line-break -webkit-linear-gradient -webkit-margin-bottom-collapse -webkit-margin-collapse -webkit-margin-start -webkit-margin-top-collapse -webkit-marquee -webkit-marquee-direction -webkit-marquee-increment -webkit-marquee-repetition -webkit-marquee-speed -webkit-marquee-style -webkit-mask -webkit-mask-attachment -webkit-mask-box-image -webkit-mask-clip -webkit-mask-composite -webkit-mask-image -webkit-mask-origin -webkit-mask-position -webkit-mask-position-x -webkit-mask-position-y -webkit-mask-repeat -webkit-mask-size -webkit-nbsp-mode -webkit-padding-start -webkit-perspective -webkit-perspective-origin -webkit-radial-gradient -webkit-rtl-ordering -webkit-tap-highlight-color -webkit-text-fill-color -webkit-text-security -webkit-text-size-adjust -webkit-text-stroke -webkit-text-stroke-color -webkit-text-stroke-width -webkit-touch-callout -webkit-transform -webkit-transform -webkit-transform-origin -webkit-transform-origin-x -webkit-transform-origin-y -webkit-transform-origin-z -webkit-transform-style -webkit-transition -webkit-transition-delay -webkit-transition-duration -webkit-transition-property -webkit-transition-timing-function -webkit-user-drag -webkit-user-modify -webkit-user-select alignment-adjust alignment-baseline animation animation-delay animation-direction animation-duration animation-iteration-count animation-name animation-play-state animation-timing-function appearance azimuth backface-visibility background background-attachment background-break background-clip background-color background-image background-origin background-position background-repeat background-size baseline-shift binding bleed bookmark-label bookmark-level bookmark-state bookmark-target border border border-bottom border-bottom-color border-bottom-left-radius border-bottom-right-radius border-bottom-style border-bottom-width border-collapse border-color border-image border-image-outset border-image-repeat border-image-slice border-image-source border-image-width border-left border-left-color border-left-style border-left-width border-radius border-right border-right-color border-right-style border-right-width border-spacing border-style border-top border-top-color border-top-left-radius border-top-right-radius border-top-style border-top-width border-width bottom box-align box-decoration-break box-direction box-flex box-flex-group box-lines box-ordinal-group box-orient box-pack box-shadow box-sizing break-after break-before break-inside caption-side clear clip color color-profile column-count column-fill column-gap column-rule column-rule-color column-rule-style column-rule-width column-span column-width columns content counter-increment counter-reset crop cue cue-after cue-before cursor direction display dominant-baseline drop-initial-after-adjust drop-initial-after-align drop-initial-before-adjust drop-initial-before-align drop-initial-size drop-initial-value elevation empty-cells filter fit fit-position float float-offset font font-effect font-emphasize font-family font-size font-size-adjust font-stretch font-style font-variant font-weight grid-columns grid-rows hanging-punctuation height hyphenate-after hyphenate-before hyphenate-character hyphenate-lines hyphenate-resource hyphens icon image-orientation image-rendering image-resolution inline-box-align left letter-spacing line-height line-stacking line-stacking-ruby line-stacking-shift line-stacking-strategy list-style list-style-image list-style-position list-style-type margin margin-bottom margin-left margin-right margin-top mark mark-after mark-before marker-offset marks marquee-direction marquee-play-count marquee-speed marquee-style max-height max-width min-height min-width move-to nav-down nav-index nav-left nav-right nav-up opacity orphans outline outline-color outline-offset outline-style outline-width overflow overflow-style overflow-x overflow-y padding padding-bottom padding-left padding-right padding-top page page-break-after page-break-before page-break-inside page-policy pause pause-after pause-before perspective perspective-origin phonemes pitch pitch-range play-during position presentation-level punctuation-trim quotes rendering-intent resize rest rest-after rest-before richness right rotation rotation-point ruby-align ruby-overhang ruby-position ruby-span size speak speak-header speak-numeral speak-punctuation speech-rate stress string-set table-layout target target-name target-new target-position text-align text-align-last text-decoration text-emphasis text-height text-indent text-justify text-outline text-overflow  text-shadow text-transform text-wrap top transform transform-origin transform-style transition transition-delay transition-duration transition-property transition-timing-function unicode-bidi vertical-align visibility voice-balance voice-duration voice-family voice-pitch voice-pitch-range voice-rate voice-stress voice-volume volume white-space white-space-collapse widows width word-break word-spacing word-wrap z-index")
                Scintilla1.SetKeywords(1, "active after before check checked disabled empty enabled first first-child first-letter first-line first-of-type focus hover indeterminate invalid lang last-child last-of-type left link not nth-child nth-last-child nth-of-type nth-last-of-type only-child only-of-type optional read-only read-write required right root selection target valid visited")
                'AutoComplete
                _autoclist = AUTOCLIST_CSS
                SetCodeFolding()
            Case EditorLanguage.CustomLanguage
                If CustomLanguageEnabled Then
                    Scintilla1.Styles(Style.[Default]).Font = _fontname
                    Scintilla1.Styles(Style.[Default]).Size = _fontsize
                    'Configure lexer styles
                    Scintilla1.Styles(Style.Cpp.[Default]).ForeColor = COLOR_DEFAULT
                    Scintilla1.Styles(Style.Cpp.Comment).ForeColor = COLOR_COMMENT
                    Scintilla1.Styles(Style.Cpp.CommentLine).ForeColor = COLOR_COMMENTLINE
                    Scintilla1.Styles(Style.Cpp.CommentLineDoc).ForeColor = COLOR_COMMENTLINEDOC
                    Scintilla1.Styles(Style.Cpp.Number).ForeColor = COLOR_NUMBER
                    Scintilla1.Styles(Style.Cpp.Word).ForeColor = COLOR_WORD
                    Scintilla1.Styles(Style.Cpp.Word2).ForeColor = COLOR_WORD2
                    Scintilla1.Styles(Style.Cpp.[String]).ForeColor = COLOR_STRING
                    Scintilla1.Styles(Style.Cpp.Character).ForeColor = COLOR_CHARACTER
                    Scintilla1.Styles(Style.Cpp.Verbatim).ForeColor = COLOR_VERBATIM
                    Scintilla1.Styles(Style.Cpp.StringEol).BackColor = COLOR_STRINGEOL
                    Scintilla1.Styles(Style.Cpp.[Operator]).ForeColor = COLOR_OPERATOR
                    Scintilla1.Styles(Style.Cpp.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                    Scintilla1.Styles(Style.Cpp.Uuid).ForeColor = COLOR_UUID
                    Scintilla1.Styles(Style.Cpp.Identifier).ForeColor = COLOR_IDENTIFIER
                    Scintilla1.Styles(Style.Cpp.Regex).ForeColor = COLOR_REGEX
                    Scintilla1.Styles(Style.Cpp.CommentDocKeyword).ForeColor = COLOR_COMMENTDOCKEYWORD
                    Scintilla1.Styles(Style.Cpp.CommentDocKeywordError).ForeColor = COLOR_COMMENTDOCKEYWORDERROR
                    'LEXER:
                    Scintilla1.Lexer = Lexer.Cpp
                    'Keywords
                    Scintilla1.SetKeywords(0, _custlang_keyword0)
                    Scintilla1.SetKeywords(1, _custlang_keyword1)
                    'AutoComplete
                    _autoclist = _custlang_autoclist
                    SetCodeFolding()
                Else
                    Scintilla1.Styles(Style.[Default]).Font = _fontname
                    Scintilla1.Styles(Style.[Default]).Size = _fontsize
                    Scintilla1.Lexer = Lexer.Null
                    'AutoComplete
                    _autoclist = ""
                End If
            Case EditorLanguage.Fortran
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Fortran.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Fortran.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Fortran.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Fortran.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Fortran.Word2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Fortran.Word3).ForeColor = COLOR_WORD3
                Scintilla1.Styles(Style.Fortran.[String1]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Fortran.[String2]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Fortran.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Fortran.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Fortran.[Operator2]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Fortran.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Fortran.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Fortran.Label).ForeColor = COLOR_LABEL
                Scintilla1.Styles(Style.Fortran.Continuation).ForeColor = COLOR_CONTINUATION
                'LEXER:
                Scintilla1.Lexer = Lexer.Fortran
                'Keywords
                Scintilla1.SetKeywords(0, "access action advance allocatable allocate apostrophe assign assignment associate asynchronous backspace bind blank blockdata call case character class close common complex contains continue cycle data deallocate decimal delim default dimension direct do dowhile double doubleprecision else elseif elsewhere encoding end endassociate endblockdata enddo endfile endforall endfunction endif endinterface endmodule endprogram endselect endsubroutine endtype endwhere entry eor equivalence err errmsg exist exit external file flush fmt forall form format formatted function go goto id if implicit in include inout integer inquire intent interface intrinsic iomsg iolength iostat kind len logical module name named namelist nextrec nml none nullify number only open opened operator optional out pad parameter pass pause pending pointer pos position precision print private program protected public quote read readwrite real rec recl recursive result return rewind save select selectcase selecttype sequential sign size stat status stop stream subroutine target then to type unformatted unit use value volatile wait where while write abs achar acos acosd adjustl adjustr aimag aimax0 aimin0 aint ajmax0 ajmin0 akmax0 akmin0 all allocated alog alog10 amax0 amax1 amin0 amin1 amod anint any asin asind associated atan atan2 atan2d atand bitest bitl bitlr bitrl bjtest bit_size bktest break btest cabs ccos cdabs cdcos cdexp cdlog cdsin cdsqrt ceiling cexp char clog cmplx conjg cos cosd cosh count cpu_time cshift csin csqrt dabs dacos dacosd dasin dasind datan datan2 datan2d datand date date_and_time dble dcmplx dconjg dcos dcosd dcosh dcotan ddim dexp dfloat dflotk dfloti dflotj digits dim dimag dint dlog dlog10 dmax1 dmin1 dmod dnint dot_product dprod dreal dsign dsin dsind dsinh dsqrt dtan dtand dtanh eoshift epsilon errsns exp exponent float floati floatj floatk floor fraction free huge iabs iachar iand ibclr ibits ibset ichar idate idim idint idnint ieor ifix iiabs iiand iibclr iibits iibset iidim iidint iidnnt iieor iifix iint iior iiqint iiqnnt iishft iishftc iisign ilen imax0 imax1 imin0 imin1 imod index inint inot int int1 int2 int4 int8 iqint iqnint ior ishft ishftc isign isnan izext jiand jibclr jibits jibset jidim jidint jidnnt jieor jifix jint jior jiqint jiqnnt jishft jishftc jisign jmax0 jmax1 jmin0 jmin1 jmod jnint jnot jzext kiabs kiand kibclr kibits kibset kidim kidint kidnnt kieor kifix kind kint kior kishft kishftc kisign kmax0 kmax1 kmin0 kmin1 kmod knint knot kzext lbound leadz len len_trim lenlge lge lgt lle llt log log10 logical lshift malloc matmul max max0 max1 maxexponent maxloc maxval merge min min0 min1 minexponent minloc minval mod modulo mvbits nearest nint not nworkers number_of_processors pack popcnt poppar precision present product radix random random_number random_seed range real repeat reshape rrspacing rshift scale scan secnds selected_int_kind selected_real_kind set_exponent shape sign sin sind sinh size sizeof sngl snglq spacing spread sqrt sum system_clock tan tand tanh tiny transfer transpose trim ubound unpack verify")
                Scintilla1.SetKeywords(1, "cdabs cdcos cdexp cdlog cdsin cdsqrt cotan cotand dcmplx dconjg dcotan dcotand decode dimag dll_export dll_import doublecomplex dreal dvchk encode find flen flush getarg getcharqq getcl getdat getenv gettim hfix ibchng identifier imag int1 int2 int4 intc intrup invalop iostat_msg isha ishc ishl jfix lacfar locking locnear map nargs nbreak ndperr ndpexc offset ovefl peekcharqq precfill prompt qabs qacos qacosd qasin qasind qatan qatand qatan2 qcmplx qconjg qcos qcosd qcosh qdim qexp qext qextd qfloat qimag qlog qlog10 qmax1 qmin1 qmod qreal qsign qsin qsind qsinh qsqrt qtan qtand qtanh ran rand randu rewrite segment setdat settim system timer undfl unlock union val virtual volatile zabs zcos zexp zlog zsin zsqrt")
                'AutoComplete
                _autoclist = AUTOCLIST_FORTRAN
                SetCodeFolding()
            Case EditorLanguage.Html
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Html.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Html.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Html.Tag).ForeColor = COLOR_TAG
                Scintilla1.Styles(Style.Html.TagUnknown).ForeColor = COLOR_TAGUNKNOWN
                Scintilla1.Styles(Style.Html.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Html.Attribute).ForeColor = COLOR_ATTRIBUTE
                Scintilla1.Styles(Style.Html.AttributeUnknown).ForeColor = COLOR_ATTRIBUTEUNKNOWN
                Scintilla1.Styles(Style.Html.DoubleString).ForeColor = COLOR_DOUBLESTRING
                Scintilla1.Styles(Style.Html.SingleString).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Html.Other).ForeColor = COLOR_OTHER
                Scintilla1.Styles(Style.Html.Entity).BackColor = COLOR_ENTITY
                Scintilla1.Styles(Style.Html.TagEnd).ForeColor = COLOR_TAG
                Scintilla1.Styles(Style.Html.Value).ForeColor = COLOR_VALUE
                Scintilla1.Styles(Style.Html.XmlStart).ForeColor = COLOR_XMLSTART
                Scintilla1.Styles(Style.Html.XmlEnd).ForeColor = COLOR_XMLEND
                Scintilla1.Styles(Style.Html.Script).ForeColor = COLOR_SCRIPT
                Scintilla1.Styles(Style.Html.Asp).ForeColor = COLOR_ASP
                Scintilla1.Styles(Style.Html.AspAt).ForeColor = COLOR_ASPAT
                Scintilla1.Styles(Style.Html.CData).ForeColor = COLOR_CDATA
                Scintilla1.Styles(Style.Html.Question).ForeColor = COLOR_QUESTION
                Scintilla1.Styles(Style.Html.XcComment).ForeColor = COLOR_XCCOMMENT
                'LEXER:
                Scintilla1.Lexer = Lexer.Html
                'Keywords
                Scintilla1.SetKeywords(0, "!doctype a abbr accept accept-charset accesskey acronym action address align alink alt applet archive area article aside audio axis b background base basefont bdo bgcolor big blockquote body border br button canvas caption cellpadding cellspacing center char charoff charset checkbox checked cite class classid clear code codebase codetype col colgroup color cols colspan command  compact content contenteditable contextmenu coords data datafld dataformatas datalist datapagesize datasrc datetime dd declare defer del details dfn dir disabled div dl draggable dropzone dt em embed enctype event face fieldset figcaption figure file font footer for form frame frameborder frameset h1 h2 h3 h4 h5 h6 head header  height hgroup hidden hr href hreflang hspace html http-equiv i id iframe image img input ins isindex ismap kbd keygen label lang language leftmargin legend li link  longdesc map marginheight marginwidth mark marquee maxlength media menu meta meter method multiple name nav noframes nohref noresize noscript noshade nowrap object ol onabort onafterprint onbeforeonload onbeforeprint onblur oncanplay oncanplaythrough onchange onclick oncontextmenu ondblclick ondrag ondragend ondragenter ondragleave ondragover ondragstart ondrop ondurationchange ondurationchange onemptied onended onerror onfocus onformchange onforminput onhaschange oninput oninvalid onkeydown onkeypress onkeyup onload onloadeddata onloadedmetadata onloadstart onmessage onmousedown onmousemove onmouseout onmouseover onmouseup onmousewheel onoffline ononline onpagehide onpageshow onpause onplay onplaying onpopstate onprogress onratechange onreadystatechange onredo onreset onresize onscroll onseeked onseeking onselect onselect onstalled onstorage onsubmit onsubmit onsuspend ontimeupdate onundo onunload onunload onvolumechange onwaiting optgroup option output p param password placeholder pre profile progress prompt public q radio readonly rel reset rev rows rowspan rp rt ruby rules s samp scheme scope script  section select selected shape size small source span spellcheck src standby start strike strong style sub submit summary sup tabindex table target tbody td text textarea tfoot th thead time title topmargin tr tt type u ul usemap valign value valuetype var version video vlink vspace wbr width xml xmlns")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_HTML
                SetCodeFolding()
            Case EditorLanguage.Java
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Cpp.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Cpp.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Cpp.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Cpp.CommentLineDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Cpp.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Cpp.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Cpp.Word2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Cpp.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Cpp.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Cpp.Verbatim).ForeColor = COLOR_VERBATIM
                Scintilla1.Styles(Style.Cpp.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Cpp.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Cpp.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Cpp.Uuid).ForeColor = COLOR_UUID
                Scintilla1.Styles(Style.Cpp.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Cpp.Regex).ForeColor = COLOR_REGEX
                Scintilla1.Styles(Style.Cpp.CommentDocKeyword).ForeColor = COLOR_COMMENTDOCKEYWORD
                Scintilla1.Styles(Style.Cpp.CommentDocKeywordError).ForeColor = COLOR_COMMENTDOCKEYWORDERROR
                'LEXER:
                Scintilla1.Lexer = Lexer.Cpp
                'Keywords
                Scintilla1.SetKeywords(0, "instanceof assert if else switch case default break goto return for while do continue new throw throws try catch finally this super extends implements import true false null")
                Scintilla1.SetKeywords(1, "package transient strictfp void char short int long double float const static volatile byte boolean class interface native private protected public final abstract synchronized enum")
                'AutoComplete
                _autoclist = AUTOCLIST_JAVA
                SetCodeFolding()
            Case EditorLanguage.JavaScript
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Cpp.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Cpp.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Cpp.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Cpp.CommentLineDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Cpp.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Cpp.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Cpp.Word2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Cpp.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Cpp.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Cpp.Verbatim).ForeColor = COLOR_VERBATIM
                Scintilla1.Styles(Style.Cpp.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Cpp.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Cpp.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Cpp.Uuid).ForeColor = COLOR_UUID
                Scintilla1.Styles(Style.Cpp.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Cpp.Regex).ForeColor = COLOR_REGEX
                Scintilla1.Styles(Style.Cpp.CommentDocKeyword).ForeColor = COLOR_COMMENTDOCKEYWORD
                Scintilla1.Styles(Style.Cpp.CommentDocKeywordError).ForeColor = COLOR_COMMENTDOCKEYWORDERROR
                'LEXER:
                Scintilla1.Lexer = Lexer.Cpp
                'Keywords
                Scintilla1.SetKeywords(0, "abstract boolean break byte case catch char class const continue debugger default delete do double else enum export extends final finally float for function goto if implements import in instanceof int interface long native new package private protected public return short static super switch synchronized this throw throws transient try typeof var void volatile while with true false prototype")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_JAVASCRIPT
                SetCodeFolding()
            Case EditorLanguage.Lisp
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Lisp.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Lisp.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Lisp.KeywordKw).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Lisp.Keyword).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Lisp.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Lisp.Symbol).ForeColor = COLOR_SYMBOL
                Scintilla1.Styles(Style.Lisp.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Lisp.Special).ForeColor = COLOR_SPECIAL
                Scintilla1.Styles(Style.Lisp.MultiComment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Lisp.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Lisp.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Lisp.Identifier).ForeColor = COLOR_IDENTIFIER
                'LEXER:
                Scintilla1.Lexer = Lexer.Lisp
                'Keywords
                Scintilla1.SetKeywords(0, "not defun + - * / = &lt; &gt; &lt;= &gt;= princ eval apply funcall quote identity function complement backquote lambda set setq setf defun defmacro gensym make symbol intern symbol name symbol value symbol plist get getf putprop remprop hash make array aref car cdr caar cadr cdar cddr caaar caadr cadar caddr cdaar cdadr cddar cdddr caaaar caaadr caadar caaddr cadaar cadadr caddar cadddr cdaaar cdaadr cdadar cdaddr cddaar cddadr cdddar cddddr cons list append reverse last nth nthcdr member assoc subst sublis nsubst  nsublis remove length list length mapc mapcar mapl maplist mapcan mapcon rplaca rplacd nconc delete atom symbolp numberp boundp null listp consp minusp zerop plusp evenp oddp eq eql equal cond case and or let l if prog prog1 prog2 progn go return do dolist dotimes catch throw error cerror break continue errset baktrace evalhook truncate float rem min max abs sin cos tan expt exp sqrt random logand logior logxor lognot bignums logeqv lognand lognor logorc2 logtest logbitp logcount integer length nil")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_LISP
                SetCodeFolding()
            Case EditorLanguage.Lua
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Lua.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Lua.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Lua.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Lua.CommentDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Lua.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Lua.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Lua.Word2).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Lua.Word3).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Lua.Word4).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Lua.Word5).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Lua.Word6).ForeColor = COLOR_WORD3
                Scintilla1.Styles(Style.Lua.Word7).ForeColor = COLOR_WORD3
                Scintilla1.Styles(Style.Lua.Word8).ForeColor = COLOR_WORD3
                Scintilla1.Styles(Style.Lua.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Lua.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Lua.LiteralString).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Lua.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Lua.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Lua.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Lua.Label).ForeColor = COLOR_LABEL
                Scintilla1.Styles(Style.Lua.Identifier).ForeColor = COLOR_IDENTIFIER
                'LEXER:
                Scintilla1.Lexer = Lexer.Lua
                'Keywords
                Scintilla1.SetKeywords(0, "and break do else elseif end false for function goto if in local nil not or repeat return then true until while _ENV _G _VERSION assert collectgarbage dofile error getfenv getmetatable ipairs load loadfile loadstring module next pairs pcall print rawequal rawget rawlen rawset require select setfenv setmetatable tonumber tostring type unpack xpcall string table math bit32 coroutine io os debug package __index __newindex __call __add __sub __mul __div __mod __pow __unm __concat __len __eq __lt __le __gc __mode")
                Scintilla1.SetKeywords(1, "byte char dump find format gmatch gsub len lower match rep reverse sub upper abs acos asin atan atan2 ceil cos cosh deg exp floor fmod frexp ldexp log log10 max min modf pow rad random randomseed sin sinh sqrt tan tanh arshift band bnot bor btest bxor extract lrotate lshift replace rrotate rshift shift string.byte string.char string.dump string.find string.format string.gmatch string.gsub string.len string.lower string.match string.rep string.reverse string.sub string.upper table.concat table.insert table.maxn table.pack table.remove table.sort table.unpack math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.cosh math.deg math.exp math.floor math.fmod math.frexp math.huge math.ldexp math.log math.log10 math.max math.min math.modf math.pi math.pow math.rad math.random math.randomseed math.sin math.sinh math.sqrt math.tan math.tanh bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.lrotate bit32.lshift bit32.replace bit32.rrotate bit32.rshift close flush lines read seek setvbuf write clock date difftime execute exit getenv remove rename setlocale time tmpname coroutine.create coroutine.resume coroutine.running coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.popen io.read io.tmpfile io.type io.write io.stderr io.stdin io.stdout os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname debug.debug debug.getfenv debug.gethook debug.getinfo debug.getlocal debug.getmetatable debug.getregistry debug.getupvalue debug.getuservalue debug.setfenv debug.sethook debug.setlocal debug.setmetatable debug.setupvalue debug.setuservalue debug.traceback debug.upvalueid debug.upvaluejoin package.cpath package.loaded package.loaders package.loadlib package.path package.preload package.seeall")
                'AutoComplete
                _autoclist = AUTOCLIST_LUA
                SetCodeFolding()
            Case EditorLanguage.Markdown 'Settings not properly setup
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Markdown.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Markdown.Header1).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Markdown.Header2).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Markdown.Header3).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Markdown.Header4).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Markdown.Header5).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Markdown.Header6).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Markdown.Em1).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Markdown.Em2).ForeColor = COLOR_CHARACTEREOL
                Scintilla1.Styles(Style.Markdown.BlockQuote).ForeColor = COLOR_COMMENTBLOCK
                Scintilla1.Styles(Style.Markdown.Code).ForeColor = COLOR_QUESTION
                Scintilla1.Styles(Style.Markdown.Code2).ForeColor = COLOR_QUESTION
                Scintilla1.Styles(Style.Markdown.CodeBk).ForeColor = COLOR_QUESTION
                Scintilla1.Styles(Style.Markdown.Link).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Markdown.OListItem).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Markdown.Strong1).ForeColor = COLOR_STDIN
                Scintilla1.Styles(Style.Markdown.Strong2).ForeColor = COLOR_STDIN
                Scintilla1.Styles(Style.Markdown.UListItem).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Markdown.Strikeout).ForeColor = COLOR_ILLEGAL
                Scintilla1.Styles(Style.Markdown.PreChar).ForeColor = COLOR_CDATA
                Scintilla1.Styles(Style.Markdown.HRule).ForeColor = COLOR_COMMENT
                'LEXER:
                Scintilla1.Lexer = Lexer.Markdown
                'AutoComplete
                _autoclist = AUTOCLIST_MARKDOWN
                SetCodeFolding()
            Case EditorLanguage.Pascal
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Pascal.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Pascal.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Pascal.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Pascal.Comment2).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Pascal.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Pascal.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Pascal.Preprocessor2).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Pascal.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Pascal.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Pascal.HexNumber).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Pascal.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Pascal.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Pascal.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Pascal.Asm).ForeColor = COLOR_EXTINSTRUCTION
                Scintilla1.Styles(Style.Pascal.Identifier).ForeColor = COLOR_IDENTIFIER
                'LEXER:
                Scintilla1.Lexer = Lexer.Pascal
                'Keywords
                Scintilla1.SetKeywords(0, "and array asm begin case cdecl class const constructor default destructor div do downto else end end. except exit exports external far file finalization finally for function goto if implementation in index inherited initialization inline interface label library message mod near nil not object of on or out overload override packed pascal private procedure program property protected public published raise read record register repeat resourcestring safecall set shl shr stdcall stored string then threadvar to try type unit until uses var virtual while with write xor")
                Scintilla1.SetKeywords(1, "integer real char boolean string")
                'AutoComplete
                _autoclist = AUTOCLIST_PASCAL
                SetCodeFolding()
            Case EditorLanguage.Perl
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Perl.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Perl.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Perl.Error).ForeColor = COLOR_ILLEGAL
                Scintilla1.Styles(Style.Perl.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Perl.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Perl.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Perl.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Perl.Punctuation).ForeColor = COLOR_PUNCTUATION
                Scintilla1.Styles(Style.Perl.Array).ForeColor = COLOR_ARRAY
                Scintilla1.Styles(Style.Perl.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Perl.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Perl.Scalar).ForeColor = COLOR_SCALAR
                Scintilla1.Styles(Style.Perl.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Perl.Regex).ForeColor = COLOR_REGEX
                Scintilla1.Styles(Style.Perl.Hash).ForeColor = COLOR_HASH
                Scintilla1.Styles(Style.Perl.SymbolTable).ForeColor = COLOR_SYMBOLTABLE
                Scintilla1.Styles(Style.Perl.SymbolTable).ForeColor = Color.Black
                Scintilla1.Styles(Style.Perl.Regex).ForeColor = COLOR_REGEX
                Scintilla1.Styles(Style.Perl.BackTicks).ForeColor = COLOR_BACKTICKS
                Scintilla1.Styles(Style.Perl.DataSection).ForeColor = COLOR_DATASECTION
                Scintilla1.Styles(Style.Perl.Pod).ForeColor = COLOR_POD
                Scintilla1.Styles(Style.Perl.StringQ).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Perl.StringQq).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Perl.StringQx).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Perl.StringQr).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Perl.StringQw).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Perl.HereQ).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Perl.HereQq).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Perl.HereQx).ForeColor = COLOR_WORD
                'LEXER:
                Scintilla1.Lexer = Lexer.Perl
                'Keywords
                Scintilla1.SetKeywords(0, "NULL __FILE__ __LINE__ __PACKAGE__ __DATA__ __END__ AUTOLOAD BEGIN CORE DESTROY END EQ GE GT INIT LE LT NE CHECK abs accept alarm and atan2 bind binmode bless caller chdir chmod chomp chop chown chr chroot close closedir cmp connect continue cos crypt dbmclose dbmopen defined delete die do dump each else elsif endgrent endhostent endnetent endprotoent endpwent endservent eof eq eval exec exists exit exp fcntl fileno flock for foreach fork format formline ge getc getgrent getgrgid getgrnam gethostbyaddr gethostbyname gethostent getlogin getnetbyaddr getnetbyname getnetent getpeername getpgrp getppid getpriority getprotobyname getprotobynumber getprotoent getpwent getpwnam getpwuid getservbyname getservbyport getservent getsockname getsockopt glob gmtime goto grep gt hex if index int ioctl join keys kill last lc lcfirst le length link listen local localtime lock log lstat lt m map mkdir msgctl msgget msgrcv msgsnd my ne next no not oct open opendir or ord our pack package pipe pop pos print printf prototype push q qq qr quotemeta qu qw qx rand read readdir readline readlink readpipe recv redo ref rename require reset return reverse rewinddir rindex rmdir s scalar seek seekdir select semctl semget semop send setgrent sethostent setnetent setpgrp setpriority setprotoent setpwent setservent setsockopt shift shmctl shmget shmread shmwrite shutdown sin sleep socket socketpair sort splice split sprintf sqrt srand stat study sub substr symlink syscall sysopen sysread sysseek system syswrite tell telldir tie tied time times tr truncate uc ucfirst umask undef unless unlink unpack unshift untie until use utime values vec wait waitpid wantarray warn while write x xor y")
                Scintilla1.SetKeywords(1, "float g long s str")
                'AutoComplete
                _autoclist = AUTOCLIST_PERL
                SetCodeFolding()
            Case EditorLanguage.Php
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.PhpScript.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.PhpScript.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.PhpScript.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.PhpScript.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.PhpScript.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.PhpScript.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.PhpScript.Variable).ForeColor = COLOR_VARIABLE
                Scintilla1.Styles(Style.PhpScript.ComplexVariable).ForeColor = COLOR_VARIABLE
                Scintilla1.Styles(Style.PhpScript.HString).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.PhpScript.HStringVariable).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.PhpScript.SimpleString).ForeColor = COLOR_STRING
                'LEXER:
                Scintilla1.Lexer = Lexer.PhpScript
                'Keywords
                Scintilla1.SetKeywords(0, "filesize filemtime ksort sort count shell_exec disk_free_space disk_total_space file_exists strip_tags htmlentities stripslashes mysql_real_escape_string session_start error_reporting define str_replace pathinfo date time version_compare sha1 sha1_file md5 md5_file ignore_user_abort and or xor __dir__ __method__ __namespace__ __file__ __line__ array as break case cfunction class const continue declare default die do echo else elseif empty enddeclare endfor endforeach endif endswitch endwhile eval exit extends for foreach function global if include include_once isset list new old_function print require require_once return static switch unset use var while __function__ __class__ php_version php_os default_include_path pear_install_dir pear_extension_dir php_extension_dir php_bindir php_libdir php_datadir php_sysconfdir php_localstatedir php_config_file_path php_output_handler_start php_output_handler_cont php_output_handler_end e_error e_warning e_parse e_notice e_core_error e_core_warning e_compile_error e_compile_warning e_user_error e_user_warning e_user_notice e_all true false bool boolean int integer float double real string array object resource null class extends parent stdclass directory __sleep __wakeup interface implements abstract public protected private printf print_r php_major_version php_minor_version php_release_version php_version_id php_extra_version php_zts php_debug php_maxpathlen php_sapi php_eol php_int_max php_int_size php_prefix php_mandir php_config_file_scan_dir php_shlib_suffix php_windows_version_major php_windows_version_minor php_windows_version_build php_windows_version_platform php_windows_version_sp_major php_windows_version_sp_minor php_windows_version_suitemask php_windows_version_producttype php_windows_nt_domain_controller php_windows_nt_server php_windows_nt_workstation e_deprecated e_user_deprecated e_strict __compiler_halt_offset__ extr_overwrite extr_skip extr_prefix_same extr_prefix_all extr_prefix_invalid extr_prefix_if_exists extr_if_exists sort_asc sort_desc sort_regular sort_numeric sort_string case_lower case_upper count_normal count_recursive assert_active assert_callback assert_bail assert_warning assert_quiet_eval connection_aborted connection_normal connection_timeout ini_user ini_perdir ini_system ini_all m_e m_log2e m_log10e m_ln2 m_ln10 m_pi m_pi_2 m_pi_4 m_1_pi m_2_pi m_2_sqrtpi m_sqrt2 m_sqrt1_2 crypt_salt_length crypt_std_des crypt_ext_des crypt_md5 crypt_blowfish directory_separator seek_set seek_cur seek_end lock_sh lock_ex lock_un lock_nb html_specialchars html_entities ent_compat ent_quotes ent_noquotes info_general info_credits info_configuration info_modules info_environment info_variables info_license info_all credits_group credits_general credits_sapi credits_modules credits_docs credits_fullpage credits_qa credits_all str_pad_left str_pad_right str_pad_both pathinfo_dirname pathinfo_basename pathinfo_extension path_separator char_max lc_ctype lc_numeric lc_time lc_collate lc_monetary lc_all lc_messages abday_1 abday_2 abday_3 abday_4 abday_5 abday_6 abday_7 day_1 day_2 day_3 day_4 day_5 day_6 day_7 abmon_1 abmon_2 abmon_3 abmon_4 abmon_5 abmon_6 abmon_7 abmon_8 abmon_9 abmon_10 abmon_11 abmon_12 mon_1 mon_2 mon_3 mon_4 mon_5 mon_6 mon_7 mon_8 mon_9 mon_10 mon_11 mon_12 am_str pm_str d_t_fmt d_fmt t_fmt t_fmt_ampm era era_year era_d_t_fmt era_d_fmt era_t_fmt alt_digits int_curr_symbol currency_symbol crncystr mon_decimal_point mon_thousands_sep mon_grouping positive_sign negative_sign int_frac_digits frac_digits p_cs_precedes p_sep_by_space n_cs_precedes n_sep_by_space p_sign_posn n_sign_posn decimal_point radixchar thousands_sep thousep grouping yesexpr noexpr yesstr nostr codeset log_emerg log_alert log_crit log_err log_warning log_notice log_info log_debug log_kern log_user log_mail log_daemon log_auth log_syslog log_lpr log_news log_uucp log_cron log_authpriv log_local0 log_local1 log_local2 log_local3 log_local4 log_local5 log_local6 log_local7 log_pid log_cons log_odelay log_ndelay log_nowait log_perror msql_connect msql_close msql msql_create_db msql_createdb msql_drop_db msql_drop_db msql_select_db msql_select_db msql_pconnect msql msql_create_db msql_createdb msql_drop_db msql_drop_db msql_select_db msql_select_db msql_db_query msql_list_dbs msql_list_fields msql_list_tables msql_query msql msql_affected_rows msql_data_seek msql_dbname msql_fetch_array msql_fetch_field msql_fetch_object msql_fetch_row msql_field_seek msql_field_table msql_field_flags msql_field_len msql_field_name msql_field_type msql_num_fields msql_num_rows msql_numfields msql_numrows msql_result mssql_connect mssql_query mssql_select_db mssql_close mssql_pconnect mssql_query mssql_select_db mssql_query mssql_data_seek mssql_fetch_array mssql_fetch_field mssql_fetch_object mssql_fetch_row mssql_field_length mssql_field_name mssql_field_seek mssql_field_type mssql_num_fields mssql_num_rows mssql_result mssql_free_result mysql_connect mysql_affected_rows mysql_change_user mysql_create_db mysql_data_seek mysql_db_name mysql_db_query mysql_drop_db mysql_errno mysql_error mysql_insert_id mysql_list_dbs mysql_list_fields mysql_list_tables mysql_query mysql_result mysql_select_db mysql_tablename mysql_get_host_info mysql_get_proto_info mysql_get_server_info mysql_close mysql_pconnect mysql_affected_rows mysql_change_user mysql_create_db mysql_data_seek mysql_db_name mysql_db_query mysql_drop_db mysql_errno mysql_error mysql_insert_id mysql_list_dbs mysql_list_fields mysql_list_tables mysql_query mysql_result mysql_select_db mysql_tablename mysql_get_host_info mysql_get_proto_info mysql_get_server_info mysql_db_query mysql_list_dbs mysql_list_fields mysql_list_processes mysql_list_tables mysql_query mysql_unbuffered_query mysql_data_seek mysql_db_name mysql_fetch_array mysql_fetch_assoc mysql_fetch_field mysql_fetch_lengths mysql_fetch_object mysql_fetch_row mysql_fetch_row mysql_field_flags mysql_field_name mysql_field_len mysql_field_seek mysql_field_table mysql_field_type mysql_num_fields mysql_num_rows mysql_result mysql_tablename mysql_free_result ocilogon ociplogon ocinlogon ocicommit ociserverversion ocinewcursor ociparse ocierror ocilogoff ocinewdescriptor ocirollback ocinewdescriptor ocirowcount ocidefinebyname ocibindbyname ociexecute ocinumcols ociresult ocifetch ocifetchinto ocifetchstatement ocicolumnisnull ocicolumnname ocicolumnsize ocicolumntype ocistatementtype ocierror ocifreestatement odbc_connect odbc_autocommit odbc_commit odbc_error odbc_errormsg odbc_exec odbc_tables odbc_tableprivileges odbc_do odbc_prepare odbc_columns odbc_columnprivileges odbc_procedurecolumns odbc_specialcolumns odbc_rollback odbc_setoption odbc_gettypeinfo odbc_primarykeys odbc_foreignkeys odbc_procedures odbc_statistics odbc_close odbc_pconnect odbc_autocommit odbc_commit odbc_error odbc_errormsg odbc_exec odbc_tables odbc_tableprivileges odbc_do odbc_prepare odbc_columns odbc_columnprivileges odbc_procedurecolumns odbc_specialcolumns odbc_rollback odbc_setoption odbc_gettypeinfo odbc_primarykeys odbc_foreignkeys odbc_procedures odbc_statistics odbc_prepare odbc_binmode odbc_cursor odbc_execute odbc_fetch_into odbc_fetch_row odbc_field_name odbc_field_num odbc_field_type odbc_field_len odbc_field_precision odbc_field_scale odbc_longreadlen odbc_num_fields odbc_num_rows odbc_result odbc_result_all odbc_setoption odbc_free_result openssl_get_privatekey openssl_get_publickey openssl_sign openssl_seal openssl_open openssl_verify openssl_free_key xml_parser_create xml_parser_create_ns xml_set_object xml_set_element_handler xml_set_character_data_handler xml_set_processing_instruction_handler xml_set_default_handler xml_set_unparsed_entity_decl_handler xml_set_notation_decl_handler xml_set_external_entity_ref_handler xml_parse xml_get_error_code xml_error_string xml_get_current_line_number xml_get_current_column_number xml_get_current_byte_index xml_parse_into_struct xml_parser_set_option xml_parser_get_option xml_parser_free gzopen gzeof gzgetc gzgets gzgetss gzpassthru gzputs gzread gzrewind gzseek gztell gzwrite gzclose bzopen bzerrno bzerror bzerrstr bzflush bzread bzwrite bzclose com_load com_invoke com_propget com_get com_propput com_set com_propput imagecreate imagecreatefromgd imagecreatefromgd2 imagecreatefromgd2part imagecreatefromgif imagecreatefromjpeg imagecreatefrompng imagecreatefromwbmp imagecreatefromstring imagecreatefromxbm imagecreatefromxpm imagecreatetruecolor imagerotate imagearc imagechar imagecharup imagecolorallocate imagecolorat imagecolorclosest imagecolorexact imagecolorresolve imagegammacorrect imagegammacorrect imagecolorset imagecolorsforindex imagecolorstotal imagecolortransparent imagecopy imagecopyresized imagedashedline imagefill imagefilledpolygon imagefilledrectangle imagefilltoborder imagegif imagepng imagejpeg imagewbmp imageinterlace imageline imagepolygon imagepstext imagerectangle imagerotate imagesetpixel imagestring imagestringup imagesx imagesy imagettftext imagefilledarc imageellipse imagefilledellipse imagecolorclosestalpha imagecolorexactalpha imagecolorresolvealpha imagecopymerge imagecopymergegray imagecopyresampled imagetruecolortopalette imagesetbrush imagesettile imagesetthickness image2wbmp imagealphablending imageantialias imagecolorallocatealpha imagecolorclosesthwb imagecolordeallocate imagecolormatch imagefilter imagefttext imagegd imagegd2 imageistruecolor imagelayereffect imagepalettecopy imagesavealpha imagesetstyle imagexbm imagedestroy imageloadfont imagechar imagecharup imagefontheight imagepsloadfont imagepstext imagepsslantfont imagepsextendfont imagepsencodefont imagepsbbox imagepsfreefont curl_copy_handle curl_init curl_copy_handle curl_errno curl_error curl_exec curl_getinfo curl_setopt curl_close dba_open dba_delete dba_exists dba_fetch dba_firstkey dba_insert dba_nextkey dba_optimize dba_replace dba_sync dba_close dba_popen dba_delete dba_exists dba_fetch dba_firstkey dba_insert dba_nextkey dba_optimize dba_replace dba_sync strstr strtoupper strtolower strpos explode implode closedir getdir floatval rtrim fwrite extension_loaded final catch clone goto instanceof namespace throw try trigger_error ftp_connect ftp_ssl_connect ftp_close ftp_login ftp_pwd ftp_cdup ftp_chdir ftp_mkdir ftp_rmdir ftp_nlist ftp_rawlist ftp_systype ftp_pasv ftp_get ftp_fget ftp_put ftp_fput ftp_size ftp_mdtm ftp_rename ftp_delete ftp_site ftp_alloc ftp_chmod ftp_exec ftp_get_option ftp_nb_continue ftp_nb_fget ftp_nb_fput ftp_nb_get ftp_nb_put ftp_raw ftp_set_option imap_open imap_close imap_append imap_body imap_check imap_createmailbox imap_delete imap_deletemailbox imap_expunge imap_fetchbody imap_fetchstructure imap_headerinfo imap_header imap_headers imap_listmailbox imap_getmailboxes imap_get_quota imap_status imap_listsubscribed imap_set_quota imap_set_quota imap_getsubscribed imap_mail_copy imap_mail_move imap_num_msg imap_num_recent imap_ping imap_renamemailbox imap_reopen imap_subscribe imap_undelete imap_unsubscribe imap_scanmailbox imap_mailboxmsginfo imap_fetchheader imap_uid imap_msgno imap_search imap_fetch_overview array_change_key_case array_chunk array_combine array_count_values array_diff array_diff_assoc array_diff_key array_diff_uassoc array_diff_ukey array_fill array_fill_keys array_filter array_flip array_intersect array_intersect_assoc array_intersect_key array_intersect_uassoc array_intersect_ukey array_key_exists array_keys array_map array_merge array_merge_recursive array_multisort array_pad array_pop array_product array_push array_rand array_reduce array_replace array_replace_recursive array_reverse array_search array_shift array_slice array_splice array_sum array_udiff array_udiff_assoc array_udiff_uassoc array_uintersect array_uintersect_assoc array_uintersect_uassoc array_unique array_unshift array_values array_walk array_walk_recursive arrayaccess arrayiterator arrayobject fclose flock floor flush fmod fnmatch fopen fpassthru fprintf fputcsv fputs fread fscanf fseek fsockopen fstat ftell __construct __destruct")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_PHP
                SetCodeFolding()
            Case EditorLanguage.PlainText
                Scintilla1.StyleClearAll()
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                Scintilla1.Lexer = Lexer.Null
                'AutoComplete
                _autoclist = ""
            Case EditorLanguage.Psql
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Sql.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Sql.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Sql.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Sql.CommentDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Sql.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Sql.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Sql.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Sql.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Sql.SqlPlus).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Sql.SqlPlusPrompt).ForeColor = COLOR_WORD3
                Scintilla1.Styles(Style.Sql.Operator).BackColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Sql.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Sql.SqlPlusComment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Sql.CommentLineDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Sql.Word2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Sql.CommentDocKeyword).ForeColor = COLOR_COMMENTDOCKEYWORD
                Scintilla1.Styles(Style.Sql.QuotedIdentifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Sql.QOperator).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Sql.User1).ForeColor = Color.Purple
                Scintilla1.Styles(Style.Sql.User2).ForeColor = Color.Purple
                Scintilla1.Styles(Style.Sql.User3).ForeColor = Color.Purple
                Scintilla1.Styles(Style.Sql.User4).ForeColor = Color.Purple
                'LEXER:
                Scintilla1.Lexer = Lexer.Sql
                'Keywords
                Scintilla1.SetKeywords(0, "abs absolute access acos add add_months adddate admin after aggregate all allocate alter and any app_name are array as asc ascii asin assertion at atan atn2 audit authid authorization autonomous_transaction avg before begin benchmark between bfilename bigint bin binary binary_checksum binary_integer bit bit_count bit_and bit_or blob body boolean both breadth bulk by call cascade cascaded case cast catalog ceil ceiling char char_base character charindex chartorowid check checksum checksum_agg chr class clob close cluster coalesce col_length col_name collate collation collect column comment commit completion compress concat concat_ws connect connection constant constraint constraints constructorcreate contains containsable continue conv convert corr corresponding cos cot count count_big covar_pop covar_samp create cross cube cume_dist current current_date current_path current_role current_time current_timestamp current_user currval cursor cycle data datalength databasepropertyex date date_add date_format date_sub dateadd datediff datename datepart datetime day db_id db_name deallocate dec declare decimal decode default deferrable deferred degrees delete dense_rank depth deref desc describe descriptor destroy destructor deterministic diagnostics dictionary disconnect difference distinct do domain double drop dump dynamic each else elsif empth encode encrypt end end-exec equals escape every except exception exclusive exec execute exists exit exp export_set extends external extract false fetch first first_value file float floor file_id file_name filegroup_id filegroup_name filegroupproperty fileproperty for forall foreign format formatmessage found freetexttable from from_days fulltextcatalog fulltextservice function general get get_lock getdate getansinull getutcdate global go goto grant greatest group grouping having heap hex hextoraw host host_id host_name hour ident_incr ident_seed ident_current identified identity if ifnull ignore immediate in increment index index_col indexproperty indicator initcap initial initialize initially inner inout input insert instr instrb int integer interface intersect interval into is is_member is_srvrolemember is_null is_numeric isdate isnull isolation iterate java join key lag language large last last_day last_value lateral lcase lead leading least left len length lengthb less level like limit limited ln lpad local localtime localtimestamp locator lock log log10 long loop lower ltrim make_ref map match max maxextents mid min minus minute mlslabel mod mode modifies modify module month months_between names national natural naturaln nchar nclob new new_time newid next next_day nextval no noaudit nocompress nocopy none not nowait null nullif number number_base numeric nvl nvl2 object object_id object_name object_property ocirowid oct of off offline old on online only opaque open operator operation option or ord order ordinalityorganization others out outer output package pad parameter parameters partial partition path pctfree percent_rank pi pls_integer positive positiven postfix pow power pragma precision prefix preorder prepare preserve primary prior private privileges procedure public radians raise rand range rank ratio_to_export raw rawtohex read reads real record recursive ref references referencing reftohex relative release release_lock rename repeat replace resource restrict result return returns reverse revoke right rollback rollup round routine row row_number rowid rowidtochar rowlabel rownum rows rowtype rpad rtrim savepoint schema scroll scope search second section seddev_samp select separate sequence session session_user set sets share sign sin sinh size smallint some soundex space specific specifictype sql sqlcode sqlerrm sqlexception sqlstate sqlwarning sqrt start state statement static std stddev stdev_pop strcmp structure subdate substr substrb substring substring_index subtype successful sum synonym sys_context sys_guid sysdate system_user table tan tanh temporary terminate than then time timestamp timezone_abbr timezone_minute timezone_hour timezone_region tinyint to to_char to_date to_days to_number to_single_byte trailing transaction translate translation treat trigger trim true trunc truncate type ucase uid under union unique unknown unnest update upper usage use user userenv using validate value values var_pop var_samp varbinary varchar varchar2 variable variance varying view vsize when whenever where with without while with work write year zone")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_PSQL
                SetCodeFolding()
            Case EditorLanguage.Python
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                '----
                Scintilla1.Styles(Style.Python.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Python.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Python.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Python.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Python.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Python.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Python.Triple).ForeColor = COLOR_TRIPLE
                Scintilla1.Styles(Style.Python.TripleDouble).ForeColor = COLOR_TRIPLEDOUBLE
                Scintilla1.Styles(Style.Python.ClassName).ForeColor = COLOR_CLASSNAME
                Scintilla1.Styles(Style.Python.DefName).ForeColor = COLOR_DEFNAME
                Scintilla1.Styles(Style.Python.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Python.Operator).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Python.CommentBlock).ForeColor = COLOR_COMMENTBLOCK
                Scintilla1.Styles(Style.Python.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Python.Word2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Python.Decorator).ForeColor = COLOR_DECORATOR
                'LEXER:
                Scintilla1.Lexer = Lexer.Python
                'Keywords
                Scintilla1.SetKeywords(0, "and as assert break class continue def del elif else except exec False finally for from global if import in is lambda None not or pass print raise return triple True try while with yield")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_PYTHON
                SetCodeFolding()
            Case EditorLanguage.Ruby
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Ruby.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Ruby.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Ruby.Error).ForeColor = COLOR_ILLEGAL
                Scintilla1.Styles(Style.Ruby.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Ruby.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Ruby.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Ruby.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Ruby.ClassName).ForeColor = COLOR_CLASSNAME
                Scintilla1.Styles(Style.Ruby.DefName).ForeColor = COLOR_DEFNAME
                Scintilla1.Styles(Style.Ruby.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Ruby.Symbol).ForeColor = COLOR_SYMBOL
                Scintilla1.Styles(Style.Ruby.Global).ForeColor = COLOR_GLOBAL
                Scintilla1.Styles(Style.Ruby.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Ruby.Regex).ForeColor = COLOR_REGEX
                Scintilla1.Styles(Style.Ruby.ModuleName).ForeColor = COLOR_MODULENAME
                Scintilla1.Styles(Style.Ruby.InstanceVar).ForeColor = COLOR_INSTANCEVAR
                Scintilla1.Styles(Style.Ruby.ClassVar).ForeColor = COLOR_CLASSVAR
                Scintilla1.Styles(Style.Ruby.Regex).ForeColor = COLOR_REGEX
                Scintilla1.Styles(Style.Ruby.WordDemoted).ForeColor = COLOR_WORDDEMOTED
                Scintilla1.Styles(Style.Ruby.BackTicks).ForeColor = COLOR_BACKTICKS
                Scintilla1.Styles(Style.Ruby.DataSection).ForeColor = COLOR_DATASECTION
                Scintilla1.Styles(Style.Ruby.Pod).ForeColor = COLOR_POD
                Scintilla1.Styles(Style.Ruby.StringQ).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Ruby.StringQq).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Ruby.StringQx).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Ruby.StringQr).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Ruby.StringQw).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Ruby.HereQ).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Ruby.HereQq).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Ruby.HereQx).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Ruby.StdIn).ForeColor = COLOR_STDIN
                Scintilla1.Styles(Style.Ruby.StdOut).ForeColor = COLOR_STDOUT
                Scintilla1.Styles(Style.Ruby.StdErr).ForeColor = COLOR_STDERR
                'LEXER:
                Scintilla1.Lexer = Lexer.Ruby
                'Keywords
                Scintilla1.SetKeywords(0, "ARGF ARGV BEGIN END ENV FALSE DATA NIL RUBY_PATCHLEVEL RUBY_PLATFORM RUBY_RELEASE_DATE RUBY_VERSION PLATFORM RELEASE_DATE STDERR STDIN STDOUT TOPLEVEL_BINDING TRUE __ENCODING__ __END__ __FILE__ __LINE__ alias and begin break case class def defined? do else elsif end ensure false for if in module next nil not or redo rescue retry return self super then true undef unless until when while yield")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_RUBY
                SetCodeFolding()
            Case EditorLanguage.SmallTalk
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Smalltalk.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Smalltalk.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Smalltalk.SpecSel).ForeColor = COLOR_SPECSEL
                Scintilla1.Styles(Style.Smalltalk.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Smalltalk.Assign).ForeColor = COLOR_ASSIGN
                Scintilla1.Styles(Style.Smalltalk.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Smalltalk.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Smalltalk.KwSend).ForeColor = COLOR_KWSEND
                Scintilla1.Styles(Style.Smalltalk.Special).ForeColor = COLOR_SPECIAL
                Scintilla1.Styles(Style.Smalltalk.[Return]).ForeColor = COLOR_RETURN
                Scintilla1.Styles(Style.Smalltalk.Symbol).ForeColor = COLOR_SYMBOL
                Scintilla1.Styles(Style.Smalltalk.Global).ForeColor = COLOR_GLOBAL
                Scintilla1.Styles(Style.Smalltalk.Bool).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Smalltalk.Self).ForeColor = COLOR_SELF
                Scintilla1.Styles(Style.Smalltalk.Super).ForeColor = COLOR_SUPER
                Scintilla1.Styles(Style.Smalltalk.Nil).ForeColor = COLOR_NIL
                Scintilla1.Styles(Style.Smalltalk.Binary).ForeColor = COLOR_BINARY
                'LEXER:
                Scintilla1.Lexer = Lexer.Smalltalk
                'Keywords
                Scintilla1.SetKeywords(0, "ifTrue: ifFalse: whileTrue: whileFalse: ifNil: ifNotNil: whileTrue whileFalse repeat isNil notNil self super true false nil")
                Scintilla1.SetKeywords(1, "for close and array do doThat doThis each size self")
                'AutoComplete
                _autoclist = AUTOCLIST_SMALLTALK
                SetCodeFolding()
            Case EditorLanguage.Sql
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Sql.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Sql.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Sql.CommentLine).ForeColor = COLOR_COMMENTLINE
                Scintilla1.Styles(Style.Sql.CommentDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Sql.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Sql.Word).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Sql.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Sql.Character).ForeColor = COLOR_CHARACTER
                Scintilla1.Styles(Style.Sql.SqlPlus).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Sql.SqlPlusPrompt).ForeColor = COLOR_WORD3
                Scintilla1.Styles(Style.Sql.Operator).BackColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Sql.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Sql.SqlPlusComment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Sql.CommentLineDoc).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Sql.Word2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Sql.CommentDocKeyword).ForeColor = COLOR_COMMENTDOCKEYWORD
                Scintilla1.Styles(Style.Sql.QuotedIdentifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Sql.QOperator).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Sql.User1).ForeColor = Color.Purple
                Scintilla1.Styles(Style.Sql.User2).ForeColor = Color.Purple
                Scintilla1.Styles(Style.Sql.User3).ForeColor = Color.Purple
                Scintilla1.Styles(Style.Sql.User4).ForeColor = Color.Purple
                'LEXER:
                Scintilla1.Lexer = Lexer.Sql
                'Keywords
                Scintilla1.SetKeywords(0, "abs absolute access acos add add_months adddate admin after aggregate all allocate alter and any app_name are array as asc ascii asin assertion at atan atn2 audit authid authorization autonomous_transaction avg before begin benchmark between bfilename bigint bin binary binary_checksum binary_integer bit bit_count bit_and bit_or blob body boolean both breadth bulk by call cascade cascaded case cast catalog ceil ceiling char char_base character charindex chartorowid check checksum checksum_agg chr class clob close cluster coalesce col_length col_name collate collation collect column comment commit completion compress concat concat_ws connect connection constant constraint constraints constructorcreate contains containsable continue conv convert corr corresponding cos cot count count_big covar_pop covar_samp create cross cube cume_dist current current_date current_path current_role current_time current_timestamp current_user currval cursor cycle data datalength databasepropertyex date date_add date_format date_sub dateadd datediff datename datepart datetime day db_id db_name deallocate dec declare decimal decode default deferrable deferred degrees delete dense_rank depth deref desc describe descriptor destroy destructor deterministic diagnostics dictionary disconnect difference distinct do domain double drop dump dynamic each else elsif empth encode encrypt end end-exec equals escape every except exception exclusive exec execute exists exit exp export_set extends external extract false fetch first first_value file float floor file_id file_name filegroup_id filegroup_name filegroupproperty fileproperty for forall foreign format formatmessage found freetexttable from from_days fulltextcatalog fulltextservice function general get get_lock getdate getansinull getutcdate global go goto grant greatest group grouping having heap hex hextoraw host host_id host_name hour ident_incr ident_seed ident_current identified identity if ifnull ignore immediate in increment index index_col indexproperty indicator initcap initial initialize initially inner inout input insert instr instrb int integer interface intersect interval into is is_member is_srvrolemember is_null is_numeric isdate isnull isolation iterate java join key lag language large last last_day last_value lateral lcase lead leading least left len length lengthb less level like limit limited ln lpad local localtime localtimestamp locator lock log log10 long loop lower ltrim make_ref map match max maxextents mid min minus minute mlslabel mod mode modifies modify module month months_between names national natural naturaln nchar nclob new new_time newid next next_day nextval no noaudit nocompress nocopy none not nowait null nullif number number_base numeric nvl nvl2 object object_id object_name object_property ocirowid oct of off offline old on online only opaque open operator operation option or ord order ordinalityorganization others out outer output package pad parameter parameters partial partition path pctfree percent_rank pi pls_integer positive positiven postfix pow power pragma precision prefix preorder prepare preserve primary prior private privileges procedure public radians raise rand range rank ratio_to_export raw rawtohex read reads real record recursive ref references referencing reftohex relative release release_lock rename repeat replace resource restrict result return returns reverse revoke right rollback rollup round routine row row_number rowid rowidtochar rowlabel rownum rows rowtype rpad rtrim savepoint schema scroll scope search second section seddev_samp select separate sequence session session_user set sets share sign sin sinh size smallint some soundex space specific specifictype sql sqlcode sqlerrm sqlexception sqlstate sqlwarning sqrt start state statement static std stddev stdev_pop strcmp structure subdate substr substrb substring substring_index subtype successful sum synonym sys_context sys_guid sysdate system_user table tan tanh temporary terminate than then time timestamp timezone_abbr timezone_minute timezone_hour timezone_region tinyint to to_char to_date to_days to_number to_single_byte trailing transaction translate translation treat trigger trim true trunc truncate type ucase uid under union unique unknown unnest update upper usage use user userenv using validate value values var_pop var_samp varbinary varchar varchar2 variable variance varying view vsize when whenever where with without while with work write year zone")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_SQL
                SetCodeFolding()
            Case EditorLanguage.VB
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Vb.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Vb.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Vb.Keyword).ForeColor = COLOR_WORD
                Scintilla1.Styles(Style.Vb.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Vb.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Vb.Keyword2).ForeColor = COLOR_WORD2
                Scintilla1.Styles(Style.Vb.Keyword3).ForeColor = COLOR_WORD3
                Scintilla1.Styles(Style.Vb.Keyword4).ForeColor = COLOR_WORD3
                Scintilla1.Styles(Style.Vb.Constant).ForeColor = Color.Navy
                Scintilla1.Styles(Style.Vb.[String]).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Vb.Asm).ForeColor = COLOR_ASP
                Scintilla1.Styles(Style.Vb.Label).ForeColor = COLOR_LABEL
                Scintilla1.Styles(Style.Vb.StringEol).BackColor = COLOR_STRINGEOL
                Scintilla1.Styles(Style.Vb.[Operator]).ForeColor = COLOR_OPERATOR
                Scintilla1.Styles(Style.Vb.Preprocessor).ForeColor = COLOR_PREPROCESSOR
                Scintilla1.Styles(Style.Vb.Error).ForeColor = COLOR_ILLEGAL
                Scintilla1.Styles(Style.Vb.Identifier).ForeColor = COLOR_IDENTIFIER
                Scintilla1.Styles(Style.Vb.CommentBlock).ForeColor = COLOR_COMMENTBLOCK
                Scintilla1.Styles(Style.Vb.DocLine).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Vb.DocBlock).ForeColor = COLOR_COMMENTLINEDOC
                Scintilla1.Styles(Style.Vb.DocKeyword).ForeColor = COLOR_COMMENTDOCKEYWORD
                Scintilla1.Styles(Style.Vb.BinNumber).ForeColor = Color.Black
                Scintilla1.Styles(Style.Vb.HexNumber).ForeColor = COLOR_UUID
                'LEXER:
                Scintilla1.Lexer = Lexer.Vb
                'Keywords
                Scintilla1.SetKeywords(0, "addhandler addressof andalso alias and ansi as assembly attribute auto begin boolean byref byte byval call case catch cbool cbyte cchar cdate cdec cdbl char cint class clng cobj compare const continue cshort csng cstr ctype currency date decimal declare default delegate dim do double each else elseif end enum erase error event exit explicit false finally for friend function get gettype global gosub goto handles if implement implements imports in inherits integer interface is let lib like load long loop lset me mid mod module mustinherit mustoverride mybase myclass namespace new next not nothing notinheritable notoverridable object on option optional or orelse overloads overridable overrides paramarray preserve private property protected public raiseevent readonly redim rem removehandler rset resume return select set shadows shared short single static step stop string structure sub synclock then throw to true try type typeof unload unicode until variant wend when while with withevents writeonly xor")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_VB
                SetCodeFolding()
            Case EditorLanguage.Xml
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Xml.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Xml.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Xml.Tag).ForeColor = COLOR_TAG
                Scintilla1.Styles(Style.Xml.TagUnknown).ForeColor = COLOR_TAGUNKNOWN
                Scintilla1.Styles(Style.Xml.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Xml.Attribute).ForeColor = COLOR_ATTRIBUTE
                Scintilla1.Styles(Style.Xml.AttributeUnknown).ForeColor = COLOR_ATTRIBUTEUNKNOWN
                Scintilla1.Styles(Style.Xml.DoubleString).ForeColor = COLOR_DOUBLESTRING
                Scintilla1.Styles(Style.Xml.SingleString).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Xml.Other).ForeColor = COLOR_OTHER
                Scintilla1.Styles(Style.Xml.Entity).BackColor = COLOR_ENTITY
                Scintilla1.Styles(Style.Xml.TagEnd).ForeColor = COLOR_TAG
                Scintilla1.Styles(Style.Xml.Value).ForeColor = COLOR_VALUE
                Scintilla1.Styles(Style.Xml.XmlStart).ForeColor = COLOR_XMLSTART
                Scintilla1.Styles(Style.Xml.XmlEnd).ForeColor = COLOR_XMLEND
                Scintilla1.Styles(Style.Xml.Script).ForeColor = COLOR_SCRIPT
                Scintilla1.Styles(Style.Xml.Asp).ForeColor = COLOR_ASP
                Scintilla1.Styles(Style.Xml.AspAt).ForeColor = COLOR_ASPAT
                Scintilla1.Styles(Style.Xml.CData).ForeColor = COLOR_CDATA
                Scintilla1.Styles(Style.Xml.Question).ForeColor = COLOR_QUESTION
                Scintilla1.Styles(Style.Xml.XcComment).ForeColor = COLOR_XCCOMMENT
                'LEXER:
                Scintilla1.Lexer = Lexer.Xml
                'Keywords
                'Scintilla1.SetKeywords(0, "")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_XML
                SetCodeFolding()
            Case EditorLanguage.Yaml
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                'Configure lexer styles
                Scintilla1.Styles(Style.Xml.[Default]).ForeColor = COLOR_DEFAULT
                Scintilla1.Styles(Style.Xml.Comment).ForeColor = COLOR_COMMENT
                Scintilla1.Styles(Style.Xml.Tag).ForeColor = COLOR_TAG
                Scintilla1.Styles(Style.Xml.TagUnknown).ForeColor = COLOR_TAGUNKNOWN
                Scintilla1.Styles(Style.Xml.Number).ForeColor = COLOR_NUMBER
                Scintilla1.Styles(Style.Xml.Attribute).ForeColor = COLOR_ATTRIBUTE
                Scintilla1.Styles(Style.Xml.AttributeUnknown).ForeColor = COLOR_ATTRIBUTEUNKNOWN
                Scintilla1.Styles(Style.Xml.DoubleString).ForeColor = COLOR_DOUBLESTRING
                Scintilla1.Styles(Style.Xml.SingleString).ForeColor = COLOR_STRING
                Scintilla1.Styles(Style.Xml.Other).ForeColor = COLOR_OTHER
                Scintilla1.Styles(Style.Xml.Entity).BackColor = COLOR_ENTITY
                Scintilla1.Styles(Style.Xml.TagEnd).ForeColor = COLOR_TAG
                Scintilla1.Styles(Style.Xml.Value).ForeColor = COLOR_VALUE
                Scintilla1.Styles(Style.Xml.XmlStart).ForeColor = COLOR_XMLSTART
                Scintilla1.Styles(Style.Xml.XmlEnd).ForeColor = COLOR_XMLEND
                Scintilla1.Styles(Style.Xml.Script).ForeColor = COLOR_SCRIPT
                Scintilla1.Styles(Style.Xml.Asp).ForeColor = COLOR_ASP
                Scintilla1.Styles(Style.Xml.AspAt).ForeColor = COLOR_ASPAT
                Scintilla1.Styles(Style.Xml.CData).ForeColor = COLOR_CDATA
                Scintilla1.Styles(Style.Xml.Question).ForeColor = COLOR_QUESTION
                Scintilla1.Styles(Style.Xml.XcComment).ForeColor = COLOR_XCCOMMENT
                'LEXER:
                Scintilla1.Lexer = Lexer.Xml
                'Keywords
                'Scintilla1.SetKeywords(0, "")
                'Scintilla1.SetKeywords(1, "")
                'AutoComplete
                _autoclist = AUTOCLIST_YAML
                SetCodeFolding()
            Case Else
                Scintilla1.StyleClearAll()
                Scintilla1.Styles(Style.[Default]).Font = _fontname
                Scintilla1.Styles(Style.[Default]).Size = _fontsize
                Scintilla1.Lexer = Lexer.Null
                'AutoComplete
                _autoclist = ""
        End Select
    End Sub

#End Region

#Region "Zoom"

    Public Sub ZoomDefault()
        Scintilla1.Zoom = 1
    End Sub

    Public Sub ZoomIn()
        If Scintilla1.Zoom < 20 Then
            Scintilla1.Zoom += 1
        End If
    End Sub

    Public Sub ZoomOut()
        If Scintilla1.Zoom > -10 Then
            Scintilla1.Zoom -= 1
        End If
    End Sub

#End Region

#Region "Find Replace"

#Region "Replace"

#Region "Normal"

    Public Function ReplaceAll(ByVal otxt As String, ByVal ntxt As String, ByVal sf As Integer, Optional ByVal searchselection As Boolean = False) As List(Of Integer)
        If searchselection Then
            Dim lfound As New List(Of Integer)
            Scintilla1.SearchFlags = sf
            Scintilla1.TargetFromSelection()
            While Scintilla1.SearchInTarget(otxt) <> -1
                lfound.Add(Scintilla1.TargetStart)
                Scintilla1.ReplaceTarget(ntxt)
                Scintilla1.TargetStart = Scintilla1.TargetEnd
                Scintilla1.TargetEnd = Scintilla1.SelectionEnd
            End While
            Return lfound
        Else
            Dim lfound As New List(Of Integer)
            Scintilla1.TargetStart = 0
            Scintilla1.TargetEnd = Scintilla1.TextLength
            Scintilla1.SearchFlags = sf
            While Scintilla1.SearchInTarget(otxt) <> -1
                lfound.Add(Scintilla1.TargetStart)
                Scintilla1.ReplaceTarget(ntxt)
                Scintilla1.TargetStart = Scintilla1.TargetEnd
                Scintilla1.TargetEnd = Scintilla1.TextLength
            End While
            Return lfound
        End If

    End Function

    Public Function ReplaceNext(ByVal otxt As String, ByVal ntxt As String, ByVal sf As Integer, Optional ByVal searchselection As Boolean = False) As Integer
        If CheckIfQueryExists(otxt, sf) Then
            If searchselection Then
                Scintilla1.SearchFlags = sf
                Scintilla1.TargetStart = Math.Max(Scintilla1.CurrentPosition, searchselect_start)
                Scintilla1.TargetEnd = searchselect_end
                Dim pos = Scintilla1.SearchInTarget(otxt)
                If pos >= 0 Then
                    Scintilla1.ReplaceTarget(ntxt)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = sf
                    Scintilla1.TargetStart = searchselect_start
                    Scintilla1.TargetEnd = searchselect_end
                    Dim pos1 = Scintilla1.SearchInTarget(otxt)
                    If pos1 >= 0 Then
                        Scintilla1.ReplaceTarget(ntxt)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            Else
                Scintilla1.SearchFlags = sf
                Scintilla1.TargetStart = Math.Max(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = Scintilla1.TextLength
                Dim pos = Scintilla1.SearchInTarget(otxt)
                If pos >= 0 Then
                    Scintilla1.ReplaceTarget(ntxt)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = sf
                    Scintilla1.TargetStart = 0
                    Scintilla1.TargetEnd = Scintilla1.TextLength
                    Dim pos1 = Scintilla1.SearchInTarget(otxt)
                    If pos1 >= 0 Then
                        Scintilla1.ReplaceTarget(ntxt)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            End If
        Else
            Return -1
        End If
    End Function

    Public Function ReplacePrevious(ByVal otxt As String, ByVal ntxt As String, ByVal sf As Integer, Optional ByVal searchselection As Boolean = False) As Integer
        If CheckIfQueryExists(otxt, sf) Then
            If searchselection Then
                Scintilla1.SearchFlags = sf
                Scintilla1.TargetStart = Math.Min(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = searchselect_start

                Dim pos = Scintilla1.SearchInTarget(otxt)
                If pos >= 0 Then
                    Scintilla1.ReplaceTarget(ntxt)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.TargetStart = searchselect_end
                    Scintilla1.TargetEnd = searchselect_start
                    Scintilla1.SearchFlags = sf
                    Dim pos1 = Scintilla1.SearchInTarget(otxt)
                    If pos1 >= 0 Then
                        Scintilla1.ReplaceTarget(ntxt)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If

                Return pos
            Else
                Scintilla1.SearchFlags = sf
                Scintilla1.TargetStart = Math.Min(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = 0
                Dim pos = Scintilla1.SearchInTarget(otxt)
                If pos >= 0 Then
                    Scintilla1.ReplaceTarget(ntxt)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = sf
                    Scintilla1.TargetStart = Scintilla1.TextLength
                    Scintilla1.TargetEnd = 0
                    Dim pos1 = Scintilla1.SearchInTarget(otxt)
                    If pos1 >= 0 Then
                        Scintilla1.ReplaceTarget(ntxt)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            End If
        Else
            Return -1
        End If
    End Function

#End Region

#Region "Regex"

    Public Function ReplaceAllReg(ByVal otxt As String, ByVal ntxt As String, Optional ByVal searchselection As Boolean = False) As List(Of Integer)
        If searchselection Then
            Dim lfound As New List(Of Integer)
            Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
            Scintilla1.TargetFromSelection()
            While Scintilla1.SearchInTarget(otxt) <> -1
                lfound.Add(Scintilla1.TargetStart)
                Scintilla1.ReplaceTargetRe(ntxt)
                Scintilla1.TargetStart = Scintilla1.TargetEnd
                Scintilla1.TargetEnd = Scintilla1.SelectionEnd
            End While
            Return lfound
        Else
            Dim lfound As New List(Of Integer)
            Scintilla1.TargetStart = 0
            Scintilla1.TargetEnd = Scintilla1.TextLength
            Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
            While Scintilla1.SearchInTarget(otxt) <> -1
                lfound.Add(Scintilla1.TargetStart)
                Scintilla1.ReplaceTargetRe(ntxt)
                Scintilla1.TargetStart = Scintilla1.TargetEnd
                Scintilla1.TargetEnd = Scintilla1.TextLength
            End While
            Return lfound
        End If

    End Function

    Public Function ReplacePreviousReg(ByVal otxt As String, ByVal ntxt As String, Optional ByVal searchselection As Boolean = False)
        If CheckIfQueryExistsReg(otxt) Then
            If searchselection Then
                Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                Scintilla1.TargetStart = Math.Min(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = searchselect_start

                Dim pos = Scintilla1.SearchInTarget(otxt)
                If pos >= 0 Then
                    Scintilla1.ReplaceTargetRe(ntxt)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.TargetStart = searchselect_end
                    Scintilla1.TargetEnd = searchselect_start
                    Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                    Dim pos1 = Scintilla1.SearchInTarget(otxt)
                    If pos1 >= 0 Then
                        Scintilla1.ReplaceTargetRe(ntxt)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If

                Return pos
            Else
                Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                Scintilla1.TargetStart = Math.Min(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = 0
                Dim pos = Scintilla1.SearchInTarget(otxt)
                If pos >= 0 Then
                    Scintilla1.ReplaceTargetRe(ntxt)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                    Scintilla1.TargetStart = Scintilla1.TextLength
                    Scintilla1.TargetEnd = 0
                    Dim pos1 = Scintilla1.SearchInTarget(otxt)
                    If pos1 >= 0 Then
                        Scintilla1.ReplaceTargetRe(ntxt)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            End If
        Else
            Return -1
        End If
    End Function

    Public Function ReplaceNextReg(ByVal otxt As String, ByVal ntxt As String, Optional ByVal searchselection As Boolean = False)
        If CheckIfQueryExistsReg(otxt) Then
            If searchselection Then
                Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                Scintilla1.TargetStart = Math.Max(Scintilla1.CurrentPosition, searchselect_start)
                Scintilla1.TargetEnd = searchselect_end
                Dim pos = Scintilla1.SearchInTarget(otxt)
                If pos >= 0 Then
                    Scintilla1.ReplaceTargetRe(ntxt)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                    Scintilla1.TargetStart = searchselect_start
                    Scintilla1.TargetEnd = searchselect_end
                    Dim pos1 = Scintilla1.SearchInTarget(otxt)
                    If pos1 >= 0 Then
                        Scintilla1.ReplaceTargetRe(ntxt)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            Else
                Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                Scintilla1.TargetStart = Math.Max(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = Scintilla1.TextLength
                Dim pos = Scintilla1.SearchInTarget(otxt)
                If pos >= 0 Then
                    Scintilla1.ReplaceTargetRe(ntxt)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                    Scintilla1.TargetStart = 0
                    Scintilla1.TargetEnd = Scintilla1.TextLength
                    Dim pos1 = Scintilla1.SearchInTarget(otxt)
                    If pos1 >= 0 Then
                        Scintilla1.ReplaceTargetRe(ntxt)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If

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

    Public Function FindPrevious(ByVal txt As String, ByVal sf As Integer, Optional ByVal searchselection As Boolean = False) As Integer
        If CheckIfQueryExists(txt, sf) Then
            If searchselection Then
                Scintilla1.SearchFlags = sf
                Scintilla1.TargetStart = Math.Min(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = searchselect_start

                Dim pos = Scintilla1.SearchInTarget(txt)
                If pos >= 0 Then
                    Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                Else
                    Scintilla1.TargetStart = searchselect_end
                    Scintilla1.TargetEnd = searchselect_start
                    Scintilla1.SearchFlags = sf
                    Dim pos1 = Scintilla1.SearchInTarget(txt)
                    If pos1 >= 0 Then
                        Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                        Return pos1
                    Else
                        Return -1
                    End If
                End If

                Return pos
            Else
                Scintilla1.SearchFlags = sf
                Scintilla1.TargetStart = Math.Min(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = 0
                Dim pos = Scintilla1.SearchInTarget(txt)
                If pos >= 0 Then
                    Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.TargetStart = Scintilla1.TextLength
                    Scintilla1.TargetEnd = 0
                    Dim pos1 = Scintilla1.SearchInTarget(txt)
                    If pos1 >= 0 Then
                        Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
                Return pos
            End If
        Else
            Return -1
        End If
    End Function

    Public Function FindAll(ByVal txt As String, ByVal sf As Integer, Optional ByVal searchselection As Boolean = False) As List(Of Integer)
        If searchselection Then
            Dim lfound As New List(Of Integer)
            Scintilla1.SearchFlags = sf
            Scintilla1.TargetFromSelection()
            While Scintilla1.SearchInTarget(txt) <> -1
                lfound.Add(Scintilla1.TargetStart)
                Scintilla1.TargetStart = Scintilla1.TargetEnd
                Scintilla1.TargetEnd = Scintilla1.SelectionEnd
            End While
            Return lfound
        Else
            Dim lfound As New List(Of Integer)
            Scintilla1.TargetStart = 0
            Scintilla1.TargetEnd = Scintilla1.TextLength
            Scintilla1.SearchFlags = sf
            While Scintilla1.SearchInTarget(txt) <> -1
                lfound.Add(Scintilla1.TargetStart)
                Scintilla1.TargetStart = Scintilla1.TargetEnd
                Scintilla1.TargetEnd = Scintilla1.TextLength
            End While
            Return lfound
        End If

    End Function

    Public Function FindNext(ByVal txt As String, ByVal sf As Integer, Optional ByVal searchselection As Boolean = False) As Integer
        If CheckIfQueryExists(txt, sf) Then
            If searchselection Then
                Scintilla1.SearchFlags = sf
                Scintilla1.TargetStart = Math.Max(Scintilla1.CurrentPosition, searchselect_start)
                Scintilla1.TargetEnd = searchselect_end
                Dim pos = Scintilla1.SearchInTarget(txt)
                If pos >= 0 Then
                    Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = sf
                    Scintilla1.TargetStart = searchselect_start
                    Scintilla1.TargetEnd = searchselect_end
                    Dim pos1 = Scintilla1.SearchInTarget(txt)
                    If pos1 >= 0 Then
                        Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            Else
                Scintilla1.SearchFlags = sf
                Scintilla1.TargetStart = Math.Max(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = Scintilla1.TextLength
                Dim pos = Scintilla1.SearchInTarget(txt)
                If pos >= 0 Then
                    Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = sf
                    Scintilla1.TargetStart = 0
                    Scintilla1.TargetEnd = Scintilla1.TextLength

                    Dim pos1 = Scintilla1.SearchInTarget(txt)
                    If pos1 >= 0 Then
                        Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            End If
        Else
            Return -1
        End If
    End Function

#End Region

#Region "Regex"

    Public Function FindPreviousReg(ByVal txt As String, Optional ByVal searchselection As Boolean = False) As Integer
        If CheckIfQueryExistsReg(txt) Then
            If searchselection Then
                Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                Scintilla1.TargetStart = Math.Min(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = searchselect_start

                Dim pos = Scintilla1.SearchInTarget(txt)
                If pos >= 0 Then
                    Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                Else
                    Scintilla1.TargetStart = searchselect_end
                    Scintilla1.TargetEnd = searchselect_start
                    Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                    Dim pos1 = Scintilla1.SearchInTarget(txt)
                    If pos1 >= 0 Then
                        Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                        Return pos1
                    Else
                        Return -1
                    End If
                End If

                Return pos
            Else
                Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                Scintilla1.TargetStart = Math.Min(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = 0

                Dim pos = Scintilla1.SearchInTarget(txt)
                If pos >= 0 Then
                    Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                    Scintilla1.TargetStart = Scintilla1.TextLength
                    Scintilla1.TargetEnd = 0
                    Dim pos1 = Scintilla1.SearchInTarget(txt)
                    If pos1 >= 0 Then
                        Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            End If
        Else
            Return -1
        End If
    End Function

    Public Function FindAllReg(ByVal txt As String, Optional ByVal searchselection As Boolean = False) As List(Of Integer)
        If searchselection Then
            Dim lfound As New List(Of Integer)
            Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
            Scintilla1.TargetFromSelection()
            While Scintilla1.SearchInTarget(txt) <> -1
                lfound.Add(Scintilla1.TargetStart)
                Scintilla1.TargetStart = Scintilla1.TargetEnd
                Scintilla1.TargetEnd = Scintilla1.SelectionEnd
            End While
            Return lfound
        Else
            Dim lfound As New List(Of Integer)
            Scintilla1.TargetStart = 0
            Scintilla1.TargetEnd = Scintilla1.TextLength
            Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
            While Scintilla1.SearchInTarget(txt) <> -1
                lfound.Add(Scintilla1.TargetStart)
                Scintilla1.TargetStart = Scintilla1.TargetEnd
                Scintilla1.TargetEnd = Scintilla1.TextLength
            End While
            Return lfound
        End If
    End Function

    Public Function FindNextReg(ByVal txt As String, Optional ByVal searchselection As Boolean = False) As Integer
        If CheckIfQueryExistsReg(txt) Then
            If searchselection Then
                Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                Scintilla1.TargetStart = Math.Max(Scintilla1.CurrentPosition, searchselect_start)
                Scintilla1.TargetEnd = searchselect_end
                Dim pos = Scintilla1.SearchInTarget(txt)
                If pos >= 0 Then
                    Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                    Scintilla1.TargetStart = searchselect_start
                    Scintilla1.TargetEnd = searchselect_end
                    Dim pos1 = Scintilla1.SearchInTarget(txt)
                    If pos1 >= 0 Then
                        Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
                End If
            Else
                Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                Scintilla1.TargetStart = Math.Max(Scintilla1.CurrentPosition, Scintilla1.AnchorPosition)
                Scintilla1.TargetEnd = Scintilla1.TextLength
                Dim pos = Scintilla1.SearchInTarget(Text)
                If pos >= 0 Then
                    Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                    Return Scintilla1.TargetStart
                Else
                    Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
                    Scintilla1.TargetStart = 0
                    Scintilla1.TargetEnd = Scintilla1.TextLength
                    Dim pos1 = Scintilla1.SearchInTarget(Text)
                    If pos1 >= 0 Then
                        Scintilla1.SetSel(Scintilla1.TargetStart, Scintilla1.TargetEnd)
                        Return Scintilla1.TargetStart
                    Else
                        Return -1
                    End If
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
        Scintilla1.TargetWholeDocument()
        Scintilla1.SearchFlags = sf
        If Scintilla1.SearchInTarget(txt) <> -1 Then
            ret = True
        End If
        Return ret
    End Function

    Private Function CheckIfQueryExistsReg(ByVal txt As String) As Boolean
        Dim ret As Boolean = False
        Scintilla1.TargetWholeDocument()
        Scintilla1.SearchFlags = SearchFlags.Regex Or SearchFlags.Posix
        If Scintilla1.SearchInTarget(txt) <> -1 Then
            ret = True
        End If
        Return ret
    End Function

    Public Sub ClearFoundHighlightedWords()
        Scintilla1.IndicatorCurrent = 9
        Scintilla1.IndicatorClearRange(0, Scintilla1.TextLength)
    End Sub

    Public Sub HighlightFoundWords(ByVal txt As String, ByVal tcolor As Color)
        ' Indicators 0-7 could be in use by a lexer
        ' so we'll use indicator 8 to highlight words.
        Const NUM As Integer = 9

        ' Remove all uses of our indicator
        Scintilla1.IndicatorCurrent = NUM
        Scintilla1.IndicatorClearRange(0, Scintilla1.TextLength)

        ' Update indicator appearance
        Scintilla1.Indicators(NUM).Style = IndicatorStyle.StraightBox
        Scintilla1.Indicators(NUM).Under = True
        Scintilla1.Indicators(NUM).ForeColor = tcolor
        Scintilla1.Indicators(NUM).OutlineAlpha = 50
        Scintilla1.Indicators(NUM).Alpha = 30

        ' Search the document
        Scintilla1.TargetStart = 0
        Scintilla1.TargetEnd = Scintilla1.TextLength
        Scintilla1.SearchFlags = SearchFlags.None
        While Scintilla1.SearchInTarget(txt) <> -1
            ' Mark the search results with the current indicator
            Scintilla1.IndicatorFillRange(Scintilla1.TargetStart, Scintilla1.TargetEnd - Scintilla1.TargetStart)

            ' Search the remainder of the document
            Scintilla1.TargetStart = Scintilla1.TargetEnd
            Scintilla1.TargetEnd = Scintilla1.TextLength
        End While
    End Sub

#End Region

#Region "Dialogs"

    Public Sub ShowGoto()
        If gotodlgshowing = False Then
            Dim newb As New dlgGoto(Me, Scintilla1.Lines.Count, Scintilla1.LineFromPosition(Scintilla1.CurrentPosition) + 1)
            gotodlgshowing = True
            Dim p As Point = Cursor.Position
            newb.Location = p
            newb.ShowDialog()
        End If
    End Sub

    Public Sub ShowFindReplace()
        If finddlgshowing = False Then
            Dim newb As New dlgFindReplace(Me, Scintilla1.SelectedText)
            finddlgshowing = True
            Dim p As Point = Cursor.Position
            newb.Location = p
            newb.Show()
        End If
    End Sub

    Public Sub ShowCodeTemplates()
        If codetemplatesdlgshowing = False Then
            Dim newb As New dlgCodeTemplates(Me)
            codetemplatesdlgshowing = True
            Dim p As Point = Cursor.Position
            newb.Location = p
            newb.ShowDialog()
        End If
    End Sub

    Public Sub ShowInsertSymbol()
        If insertsymboldlgshowing = False Then
            Dim newb As New dlgInsertSymbol(Me)
            insertsymboldlgshowing = True
            Dim p As Point = Cursor.Position
            newb.Location = p
            newb.ShowDialog()
        End If
    End Sub

    Public Sub ShowInsertGUID()
        If insertguiddlgshowing = False Then
            Dim newb As New dlgInsertGUID(Me)
            insertguiddlgshowing = True
            Dim p As Point = Cursor.Position
            newb.Location = p
            newb.ShowDialog()
        End If
    End Sub

    Public Sub ShowClipboardHistory()
        If clipboardhistorydlgshowing = False Then
            Dim newb As New dlgClipboardHistory(Me)
            clipboardhistorydlgshowing = True
            Dim p As Point = Cursor.Position
            newb.Location = p
            newb.ShowDialog()
        End If
    End Sub

    Public Sub ShowCommandPalette()
        If insertsymboldlgshowing = False Then
            Dim newb As New dlgCommandPalette(Me)
            cmdpalettedlgshowing = True
            Dim p As Point = Cursor.Position
            newb.Location = p
            newb.ShowDialog()
        End If
    End Sub

#End Region

#Region "Folding"

    Public Function LineIsFoldPoint(ByVal linenum As Boolean)
        Return ((Scintilla1.Lines(linenum).FoldLevelFlags And FoldLevelFlags.Header) > 0)
    End Function

    Public Sub FoldAll()
        Scintilla1.FoldAll(FoldAction.Contract)
    End Sub

    Public Sub UnfoldAll()
        Scintilla1.FoldAll(FoldAction.Expand)
    End Sub

    Public Sub FoldLine(ByVal linenum As Integer)
        Scintilla1.Lines(linenum).FoldLine(FoldAction.Contract)
    End Sub

    Public Sub UnFoldLine(ByVal linenum As Integer)
        Scintilla1.Lines(linenum).FoldLine(FoldAction.Expand)
    End Sub

#End Region

#Region "Snippet List"

    Public Sub ShowSnippetList(ByVal lb As List(Of String))
        pnl_snippetlist.Show()
        pnl_snippetlist.Location = New Point(Scintilla1.PointXFromPosition(Scintilla1.CurrentPosition), Scintilla1.PointYFromPosition(Scintilla1.CurrentPosition) + 20)
        listbox_snippetlist.Items.Clear()
        lb.Sort()
        For Each item As String In lb
            listbox_snippetlist.Items.Add(item)
        Next
        listbox_snippetlist.Focus()
    End Sub

#End Region

#Region "Incremental Searcher"

    Public Sub ShowIncrementalSearcher()
        pnl_incrementalsearcher.Show()
        txt_incrementalsearcher.Focus()
    End Sub

    Public Sub ShowIncrementalSearcher(ByVal txt As String)
        pnl_incrementalsearcher.Show()
        txt_incrementalsearcher.Focus()
        txt_incrementalsearcher.Text = txt
    End Sub

    Public Sub HideIncrementalSearcher()
        pnl_incrementalsearcher.Hide()
    End Sub

#End Region

#Region "Document Map"

    Public Sub SetDocumentMapText(ByVal txt As String)
        If EditorMode = Mode.DocumentMap Then
            IsReadOnly = False
            Scintilla1.Text = txt
            IsReadOnly = True
        End If
    End Sub

    Public Sub UpdateDocumentMap(ByVal curpos As Integer, ByVal txt As String)
        If EditorMode = Mode.DocumentMap Then
            SetDocumentMapText(txt)
            Scintilla1.Lines(Scintilla1.LineFromPosition(curpos)).Goto()
            HighlightAreaForDocumentMap(curpos)
        End If
    End Sub

    Public Sub HighlightAreaForDocumentMap(ByVal curline As Integer)
        If EditorMode = Mode.DocumentMap Then
            Try
                Const NUM As Integer = 10
                Scintilla1.IndicatorCurrent = NUM
                Scintilla1.IndicatorClearRange(0, Scintilla1.TextLength)
                Scintilla1.Indicators(NUM).Style = IndicatorStyle.FullBox
                Scintilla1.Indicators(NUM).Under = False
                Scintilla1.Indicators(NUM).ForeColor = Color.Green
                Scintilla1.Indicators(NUM).OutlineAlpha = 50
                Scintilla1.Indicators(NUM).Alpha = 30
                Dim tstart As Integer = Scintilla1.Lines(Scintilla1.CurrentLine - 7).Position
                Dim tend As Integer = Scintilla1.Lines(Scintilla1.CurrentLine + 7).EndPosition
                Scintilla1.IndicatorFillRange(tstart, tend - tstart)

            Catch
            End Try
        End If
    End Sub

#End Region

#Region "Present"

    Public Sub ClearPresentHighlightedWords()
        Scintilla1.IndicatorCurrent = 11
        Scintilla1.IndicatorClearRange(0, Scintilla1.TextLength)
    End Sub

    Public Sub HighlightPresentWords(ByVal tcolor As Color)
        ' Indicators 0-7 could be in use by a lexer
        Const NUM As Integer = 11
        ' Remove all uses of our indicator
        Scintilla1.IndicatorCurrent = NUM
        'Scintilla1.IndicatorClearRange(0, Scintilla1.TextLength)
        ' Update indicator appearance
        Scintilla1.Indicators(NUM).Style = IndicatorStyle.StraightBox
        Scintilla1.Indicators(NUM).Under = True
        Scintilla1.Indicators(NUM).ForeColor = tcolor
        Scintilla1.Indicators(NUM).OutlineAlpha = 50
        Scintilla1.Indicators(NUM).Alpha = 30
        Scintilla1.TargetFromSelection()
        Scintilla1.IndicatorFillRange(Scintilla1.TargetStart, Scintilla1.TargetEnd - Scintilla1.TargetStart)
    End Sub

#End Region

#Region "Commands"

    Public Sub Cut()
        Scintilla1.Cut()
        AddSelectedTextToClipboardHistory()
    End Sub

    Public Sub Copy()
        Scintilla1.Copy()
        AddSelectedTextToClipboardHistory()
    End Sub

    Public Sub Paste()
        justpasted = True
        Scintilla1.Paste()
    End Sub

    Public Sub SelectAll()
        Scintilla1.SelectAll()
    End Sub

    Public Sub ClearAll()
        Scintilla1.ClearAll()
    End Sub

    Public Sub ExecuteCommand(ByVal cmd As Command)
        Scintilla1.ExecuteCmd(cmd)
    End Sub

#End Region

#Region "Call Tips"

    Public Sub ShowCallTip(ByVal pos As Integer, ByVal txt As String)
        Scintilla1.CallTipShow(pos, txt)
    End Sub

#End Region

#Region "Commenting"

    Public Sub CommentLines()
        Scintilla1.TargetFromSelection()
        Dim lstart As Integer = Scintilla1.LineFromPosition(Scintilla1.TargetStart)
        Dim lend As Integer = Scintilla1.LineFromPosition(Scintilla1.TargetEnd)
        Select Case Language
            Case EditorLanguage.Ada
                For i As Integer = lstart To lend
                    SetTextForLine(i, "-- " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Assembly
                For i As Integer = lstart To lend
                    SetTextForLine(i, "; " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Batch
                For i As Integer = lstart To lend
                    SetTextForLine(i, ":: " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Cpp
                For i As Integer = lstart To lend
                    SetTextForLine(i, "// " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Csharp
                For i As Integer = lstart To lend
                    SetTextForLine(i, "// " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Css
                For i As Integer = lstart To lend
                    SetTextForLine(i, "/* " & Scintilla1.Lines(i).Text & " */")
                Next
            Case EditorLanguage.Fortran
                For i As Integer = lstart To lend
                    SetTextForLine(i, "C " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Html
                For i As Integer = lstart To lend
                    SetTextForLine(i, "<!-- " & Scintilla1.Lines(i).Text & " -->")
                Next
            Case EditorLanguage.Java
                For i As Integer = lstart To lend
                    SetTextForLine(i, "// " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.JavaScript
                For i As Integer = lstart To lend
                    SetTextForLine(i, "// " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Lisp
                For i As Integer = lstart To lend
                    SetTextForLine(i, ";;; " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Lua
                For i As Integer = lstart To lend
                    SetTextForLine(i, "-- " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Pascal
                For i As Integer = lstart To lend
                    SetTextForLine(i, "// " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Perl
                For i As Integer = lstart To lend
                    SetTextForLine(i, "# " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Php
                For i As Integer = lstart To lend
                    SetTextForLine(i, "// " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Psql
                For i As Integer = lstart To lend
                    SetTextForLine(i, "-- " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Python
                For i As Integer = lstart To lend
                    SetTextForLine(i, "# " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Ruby
                For i As Integer = lstart To lend
                    SetTextForLine(i, "# " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.SmallTalk
                For i As Integer = lstart To lend
                    SetTextForLine(i, """ " & Scintilla1.Lines(i).Text & " """)
                Next
            Case EditorLanguage.Sql
                For i As Integer = lstart To lend
                    SetTextForLine(i, "-- " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.VB
                For i As Integer = lstart To lend
                    SetTextForLine(i, "' " & Scintilla1.Lines(i).Text)
                Next
            Case EditorLanguage.Xml
                For i As Integer = lstart To lend
                    SetTextForLine(i, "<!-- " & Scintilla1.Lines(i).Text & " -->")
                Next
            Case EditorLanguage.Yaml
                For i As Integer = lstart To lend
                    SetTextForLine(i, "# " & Scintilla1.Lines(i).Text)
                Next
        End Select
    End Sub

    Public Sub UnCommentLines()
        Scintilla1.TargetFromSelection()
        Dim lstart As Integer = Scintilla1.LineFromPosition(Scintilla1.TargetStart)
        Dim lend As Integer = Scintilla1.LineFromPosition(Scintilla1.TargetEnd)
        Select Case Language
            Case EditorLanguage.Ada
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("--", ""))
                Next
            Case EditorLanguage.Assembly
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace(";", ""))
                Next
            Case EditorLanguage.Batch
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("::", ""))
                Next
            Case EditorLanguage.Cpp
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("//", ""))
                Next
            Case EditorLanguage.Csharp
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("//", ""))
                Next
            Case EditorLanguage.Css
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("/*", "").Replace("*/", ""))
                Next
            Case EditorLanguage.Fortran
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("C", ""))
                Next
            Case EditorLanguage.Html
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("<!--", "").Replace("-->", ""))
                Next
            Case EditorLanguage.Java
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("//", ""))
                Next
            Case EditorLanguage.JavaScript
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("//", ""))
                Next
            Case EditorLanguage.Lisp
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace(";;;", ""))
                Next
            Case EditorLanguage.Lua
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("--", ""))
                Next
            Case EditorLanguage.Pascal
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("//", ""))
                Next
            Case EditorLanguage.Perl
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("#", ""))
                Next
            Case EditorLanguage.Php
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("//", ""))
                Next
            Case EditorLanguage.Psql
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("--", ""))
                Next
            Case EditorLanguage.Python
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("#", ""))
                Next
            Case EditorLanguage.Ruby
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("#", ""))
                Next
            Case EditorLanguage.SmallTalk
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("""", ""))
                Next
            Case EditorLanguage.Sql
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("--", ""))
                Next
            Case EditorLanguage.VB
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("'", ""))
                Next
            Case EditorLanguage.Xml
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("<!--", "").Replace("-->", ""))
                Next
            Case EditorLanguage.Yaml
                For i As Integer = lstart To lend
                    SetTextForLine(i, Scintilla1.Lines(i).Text.Replace("#", ""))
                Next
        End Select
    End Sub

#End Region

#Region "Language Select Case"

    'Select Case Language
    '        Case EditorLanguage.Ada
    '        Case EditorLanguage.Assembly
    '        Case EditorLanguage.Batch
    '        Case EditorLanguage.Cpp
    '        Case EditorLanguage.Csharp
    '        Case EditorLanguage.Css
    '        Case EditorLanguage.Fortran
    '        Case EditorLanguage.Html
    '        Case EditorLanguage.Java
    '        Case EditorLanguage.JavaScript
    '        Case EditorLanguage.Lisp
    '        Case EditorLanguage.Lua
    '        Case EditorLanguage.Pascal
    '        Case EditorLanguage.Perl
    '        Case EditorLanguage.Php
    '        Case EditorLanguage.Psql
    '        Case EditorLanguage.Python
    '        Case EditorLanguage.Ruby
    '        Case EditorLanguage.SmallTalk
    '        Case EditorLanguage.Sql
    '        Case EditorLanguage.VB
    '        Case EditorLanguage.Xml
    '        Case EditorLanguage.Yaml
    '        Case Else
    '    End Select

#End Region

    Public Sub SetSyntaxHighlightingArray(ByVal ParamArray synt() As Color)
        COLOR_DEFAULT = synt(0)
        COLOR_COMMENT = synt(1)
        COLOR_COMMENTBLOCK = synt(2)
        COLOR_COMMENTLINE = synt(3)
        COLOR_COMMENTLINEDOC = synt(4)
        COLOR_NUMBER = synt(5)
        COLOR_WORD = synt(6)
        COLOR_WORD2 = synt(7)
        COLOR_WORD3 = synt(8)
        COLOR_STRING = synt(9)
        COLOR_CHARACTER = synt(10)
        COLOR_VERBATIM = synt(11)
        COLOR_STRINGEOL = synt(12)
        COLOR_CHARACTEREOL = synt(13)
        COLOR_OPERATOR = synt(14)
        COLOR_PREPROCESSOR = synt(15)
        COLOR_DELIMITER = synt(16)
        COLOR_LABEL = synt(17)
        COLOR_ILLEGAL = synt(18)
        COLOR_IDENTIFIER = synt(19)
        COLOR_CPUINSTRUCTION = synt(20)
        COLOR_MATHINSTRUCTION = synt(21)
        COLOR_EXTINSTRUCTION = synt(22)
        COLOR_REGISTER = synt(23)
        COLOR_DIRECTIVE = synt(24)
        COLOR_DIRECTIVEOPERAND = synt(25)
        COLOR_HIDE = synt(26)
        COLOR_TRIPLE = synt(27)
        COLOR_TRIPLEDOUBLE = synt(28)
        COLOR_CLASSNAME = synt(29)
        COLOR_DEFNAME = synt(30)
        COLOR_DECORATOR = synt(31)
        COLOR_UUID = synt(32)
        COLOR_REGEX = synt(33)
        COLOR_COMMENTDOCKEYWORD = synt(34)
        COLOR_COMMENTDOCKEYWORDERROR = synt(35)
        COLOR_TAG = synt(36)
        COLOR_TAGUNKNOWN = synt(37)
        COLOR_PSEUDOCLASS = synt(38)
        COLOR_UNKNOWNPSEUDOCLASS = synt(39)
        COLOR_UNKNOWNIDENTIFIER = synt(40)
        COLOR_VALUE = synt(41)
        COLOR_ID = synt(42)
        COLOR_IMPORTANT = synt(43)
        COLOR_ATTRIBUTE = synt(44)
        COLOR_ATTRIBUTEUNKNOWN = synt(45)
        COLOR_ENTITY = synt(46)
        COLOR_CONTINUATION = synt(47)
        COLOR_DOUBLESTRING = synt(48)
        COLOR_OTHER = synt(49)
        COLOR_XMLSTART = synt(50)
        COLOR_XMLEND = synt(51)
        COLOR_SCRIPT = synt(52)
        COLOR_ASP = synt(53)
        COLOR_ASPAT = synt(54)
        COLOR_QUESTION = synt(55)
        COLOR_CDATA = synt(56)
        COLOR_XCCOMMENT = synt(57)
        COLOR_SPECIAL = synt(58)
        COLOR_SYMBOL = synt(59)
        COLOR_INSTRUCTIONWORD = synt(60)
        COLOR_SCALAR = synt(61)
        COLOR_ARRAY = synt(62)
        COLOR_HASH = synt(63)
        COLOR_SYMBOLTABLE = synt(64)
        COLOR_DATASECTION = synt(65)
        COLOR_POD = synt(66)
        COLOR_LONGQUOTE = synt(67)
        COLOR_BACKTICKS = synt(68)
        COLOR_PUNCTUATION = synt(69)
        COLOR_VARIABLE = synt(70)
        COLOR_GLOBAL = synt(71)
        COLOR_MODULENAME = synt(72)
        COLOR_INSTANCEVAR = synt(73)
        COLOR_STDIN = synt(74)
        COLOR_STDOUT = synt(75)
        COLOR_STDERR = synt(76)
        COLOR_WORDDEMOTED = synt(77)
        COLOR_CLASSVAR = synt(78)
        COLOR_SPECSEL = synt(79)
        COLOR_ASSIGN = synt(80)
        COLOR_KWSEND = synt(81)
        COLOR_RETURN = synt(82)
        COLOR_NIL = synt(83)
        COLOR_BINARY = synt(84)
        COLOR_SUPER = synt(85)
        COLOR_SELF = synt(86)
    End Sub

    Public Sub ResetSyntaxHighlightingColorsToDefault()
        COLOR_DEFAULT = Color.Black
        COLOR_COMMENT = Color.FromArgb(0, 128, 0) 'Green
        COLOR_COMMENTBLOCK = Color.FromArgb(0, 128, 0) 'Green
        COLOR_COMMENTLINE = Color.FromArgb(0, 128, 0) 'Green
        COLOR_COMMENTLINEDOC = Color.FromArgb(128, 128, 128) 'Grey
        COLOR_NUMBER = Color.Goldenrod
        COLOR_WORD = Color.Blue
        COLOR_WORD2 = Color.Blue
        COLOR_WORD3 = Color.Blue
        COLOR_STRING = Color.FromArgb(163, 21, 21) 'Red
        COLOR_CHARACTER = Color.FromArgb(163, 21, 21) 'Red
        COLOR_VERBATIM = Color.FromArgb(163, 21, 21) 'Red
        COLOR_STRINGEOL = Color.Pink 'Use as BackColor
        COLOR_CHARACTEREOL = Color.Pink 'Use as BackColor
        COLOR_OPERATOR = Color.Purple
        COLOR_PREPROCESSOR = Color.Maroon
        COLOR_DELIMITER = Color.LightCoral
        COLOR_LABEL = Color.Brown
        COLOR_ILLEGAL = Color.Red
        COLOR_IDENTIFIER = Color.Black
        COLOR_CPUINSTRUCTION = Color.DarkBlue
        COLOR_MATHINSTRUCTION = Color.Blue
        COLOR_EXTINSTRUCTION = Color.LightBlue
        COLOR_REGISTER = Color.Purple
        COLOR_DIRECTIVE = Color.Blue
        COLOR_DIRECTIVEOPERAND = Color.DarkBlue
        COLOR_HIDE = Color.HotPink
        COLOR_TRIPLE = Color.FromArgb(&H7F, &H0, &H0)
        COLOR_TRIPLEDOUBLE = Color.FromArgb(&H7F, &H0, &H0)
        COLOR_CLASSNAME = Color.FromArgb(&H0, &H0, &HFF)
        COLOR_DEFNAME = Color.FromArgb(&H0, &H7F, &H7F)
        COLOR_DECORATOR = Color.FromArgb(&H80, &H50, &H0)
        COLOR_UUID = Color.FromArgb(163, 21, 21) 'Red
        COLOR_REGEX = Color.Black
        COLOR_COMMENTDOCKEYWORD = Color.DarkCyan
        COLOR_COMMENTDOCKEYWORDERROR = Color.DarkCyan
        COLOR_TAG = Color.Blue
        COLOR_TAGUNKNOWN = Color.Black
        COLOR_PSEUDOCLASS = Color.Orange
        COLOR_UNKNOWNPSEUDOCLASS = Color.LightCoral
        COLOR_UNKNOWNIDENTIFIER = Color.Black
        COLOR_VALUE = Color.Orange
        COLOR_ID = Color.RoyalBlue
        COLOR_IMPORTANT = Color.Red
        COLOR_ATTRIBUTE = Color.Red
        COLOR_ATTRIBUTEUNKNOWN = Color.Black
        COLOR_ENTITY = Color.Black
        COLOR_CONTINUATION = Color.FromArgb(0, 128, 0) 'Green
        COLOR_DOUBLESTRING = Color.Purple
        COLOR_OTHER = Color.Black
        COLOR_XMLSTART = Color.Blue
        COLOR_XMLEND = Color.Blue
        COLOR_SCRIPT = Color.Plum
        COLOR_ASP = Color.Plum
        COLOR_ASPAT = Color.Plum
        COLOR_QUESTION = Color.DarkGray
        COLOR_CDATA = Color.Orange
        COLOR_XCCOMMENT = Color.FromArgb(0, 128, 0) 'Green
        COLOR_SPECIAL = Color.RoyalBlue
        COLOR_SYMBOL = Color.Navy
        COLOR_INSTRUCTIONWORD = Color.Blue
        COLOR_SCALAR = Color.Orange
        COLOR_ARRAY = Color.Purple
        COLOR_HASH = Color.MediumPurple
        COLOR_SYMBOLTABLE = Color.Red
        COLOR_DATASECTION = Color.Maroon
        COLOR_POD = Color.Black
        COLOR_LONGQUOTE = Color.Orange
        COLOR_BACKTICKS = Color.Yellow
        COLOR_PUNCTUATION = Color.Brown
        COLOR_VARIABLE = Color.Navy
        COLOR_GLOBAL = Color.DarkBlue
        COLOR_MODULENAME = Color.Brown
        COLOR_INSTANCEVAR = Color.Black
        COLOR_STDIN = Color.LightBlue
        COLOR_STDOUT = Color.Blue
        COLOR_STDERR = Color.Red
        COLOR_WORDDEMOTED = Color.DarkGoldenrod
        COLOR_CLASSVAR = Color.DarkCyan
        COLOR_SPECSEL = Color.Pink
        COLOR_ASSIGN = Color.Red
        COLOR_KWSEND = Color.RoyalBlue
        COLOR_RETURN = Color.Blue
        COLOR_NIL = Color.Purple
        COLOR_BINARY = Color.Navy
        COLOR_SUPER = Color.LightBlue
        COLOR_SELF = Color.MediumSlateBlue
    End Sub

    Public Sub SurroundLine(ByVal lnum As Integer, ByVal txt As String)
        Dim bb As String = txt
        bb &= Scintilla1.Lines(lnum).Text & txt
        SetTextForLine(lnum, bb)
    End Sub

    Public Function GetSelectionStartLine() As Integer
        Return Scintilla1.LineFromPosition(Scintilla1.SelectionStart)
    End Function

    Public Function GetSelectionEndLine() As Integer
        Return Scintilla1.LineFromPosition(Scintilla1.SelectionEnd)
    End Function

    Public Sub SetBackColorForAllStyles(ByVal clr As Color)
        For Each stle As Style In Scintilla1.Styles
            stle.BackColor = clr
        Next
    End Sub

    Public Function GetTextForeColor() As Color
        Return Scintilla1.Styles(Style.[Default]).ForeColor
    End Function
    
    Public Sub SetTextForeColor(ByVal clr As Color)
        Scintilla1.Styles(Style.[Default]).ForeColor = clr
    End Sub

    Private Sub UpdateBraceStyling()
        Scintilla1.Styles(Style.BraceLight).BackColor = Color.LightGray
        Scintilla1.Styles(Style.BraceLight).ForeColor = Color.BlueViolet
        Scintilla1.Styles(Style.BraceBad).ForeColor = Color.Red
    End Sub

    Public Sub GoToMatchingBrace()
        Scintilla1.GotoPosition(Scintilla1.BraceMatch(Scintilla1.CurrentPosition))
    End Sub

    Public Sub GoToMatchingBrace(ByVal pos As Integer)
        Scintilla1.GotoPosition(Scintilla1.BraceMatch(pos))
    End Sub

    Public Function BraceMatch(ByVal pos As Integer) As Integer
        Return Scintilla1.BraceMatch(pos)
    End Function

    Public Sub AddTextToClipboardHistory(ByVal txt As String)
        If RecordClipboardHistory AndAlso Not PerformanceMode Then
            If Not listclipboardhistory.Contains(txt) Then
                ClipboardHistory.Add(txt)
                RaiseEvent TextAddedToClipboardHistory(txt)
            End If
        End If
    End Sub

    Public Sub ClearClipboardHistory()
        ClipboardHistory.Clear()
        RaiseEvent ClipboardHistoryCleared()
    End Sub

    Public Sub DeleteAllMarkers(ByVal marknum As Integer)
        Scintilla1.MarkerDeleteAll(marknum)
    End Sub

    Public Function GetWordFromCurrentPosition() As String
        Return Scintilla1.GetWordFromPosition(Scintilla1.CurrentPosition)
        'Scintilla1.GetTextRange(Scintilla1.WordStartPosition(Scintilla1.CurrentPosition, true), Scintilla1.WordStartPosition())
    End Function

    Public Sub CopyWordFromCurrentPosition()
        Dim b As String = GetWordFromCurrentPosition()
        If b <> "" Then
            Clipboard.SetText(b)
        End If
    End Sub

    Public Sub CutWordFromCurrentPosition()
        Dim b As String = GetWordFromCurrentPosition()
        If b <> "" Then
            Scintilla1.SetSelection(Scintilla1.WordStartPosition(Scintilla1.CurrentPosition, False), Scintilla1.WordEndPosition(Scintilla1.CurrentPosition, False))
            Scintilla1.Cut()
        End If
    End Sub

    Public Sub PasteWordFromCurrentPosition()
        Dim b As String = GetWordFromCurrentPosition()
        If b <> "" Then
            Scintilla1.SetSelection(Scintilla1.WordStartPosition(Scintilla1.CurrentPosition, False), Scintilla1.WordEndPosition(Scintilla1.CurrentPosition, False))
            Scintilla1.Paste()
        End If
    End Sub

    Public Sub CopyAsRtf()
        Scintilla1.Copy(CopyFormat.Rtf)
    End Sub

    Public Sub CopyAsHtml()
        If Scintilla1.SelectedText <> "" Then
            My.Computer.Clipboard.SetText(Scintilla1.GetTextRangeAsHtml(Scintilla1.SelectionStart, Scintilla1.SelectionEnd - Scintilla1.SelectionStart))
        End If
        'Scintilla1.Copy(CopyFormat.Html)
    End Sub

    Public Sub ConvertEols(ByVal neol As Eol)
        Scintilla1.ConvertEols(neol)
    End Sub

    Public Function GetColumn(ByVal pos As Integer) As Integer
        Return Scintilla1.GetColumn(pos)
    End Function

    Public Sub SetTextForLine(ByVal lnum As Integer, ByVal txt As String)
        Scintilla1.TargetStart = Scintilla1.Lines(lnum).Position
        Scintilla1.TargetEnd = Scintilla1.Lines(lnum).EndPosition
        Scintilla1.ReplaceTarget(txt)
    End Sub

    Public Sub EmptyUndoBuffer()
        Scintilla1.EmptyUndoBuffer()
    End Sub

    Public Function GetFirstVisibleLine() As Integer
        Return Scintilla1.FirstVisibleLine()
    End Function

    Public Function GetIfFoldPoint(ByVal linenum As Integer) As Boolean
        If Scintilla1.Lines(linenum).FoldLevel = 1024 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function GetLines() As ScintillaNET.LineCollection
        Return Scintilla1.Lines
    End Function

    Public Function GetWordFromPosition(ByVal pos As Integer) As String
        Return Scintilla1.GetWordFromPosition(pos)
    End Function

    Public Function GetTotalLines() As Integer
        Return Scintilla1.Lines.Count
    End Function

    Public Function GetTextLength() As Integer
        Return Scintilla1.TextLength
    End Function

    Public Sub InsertText(ByVal txt As String)
        Scintilla1.InsertText(Scintilla1.CurrentPosition, txt)
    End Sub

    Public Sub InsertText(ByVal position As Integer, ByVal txt As String)
        Scintilla1.InsertText(position, txt)
    End Sub

    Public Sub SetCustomLanguage(ByVal key0 As String, ByVal key1 As String, ByVal autoclist As String)
        _custlang_keyword0 = key0
        _custlang_keyword1 = key1
        _custlang_autoclist = autoclist
    End Sub

    Public Function GetTextFromLine(ByVal linenum As Integer) As String
        Return Scintilla1.Lines(linenum).Text
    End Function

    Public Function CurrentLine() As Integer
        Return Scintilla1.CurrentLine
    End Function

    Public Function LinesOnScreen() As Integer
        Return Scintilla1.LinesOnScreen
    End Function

    Public Sub SetFocus()
        Scintilla1.Focus()
    End Sub

    Public Function GetFocused() As Boolean
        Return Scintilla1.Focused
    End Function

    Public Sub GotoLine(ByVal linenum As Integer)
        Try
            If linenum > 0 Then
                If linenum <= Scintilla1.Lines.Count Then
                    Scintilla1.Lines(linenum - 1).Goto()
                Else
                    Scintilla1.Lines(Scintilla1.Lines.Count - 1).Goto()
                End If
            Else
                Scintilla1.Lines(0).Goto()
            End If
        Catch
        End Try
    End Sub

    Public Sub GotoLineNotArray(ByVal lnum As Integer)
        Dim linenum As Integer = lnum - 1
        Try
            If linenum > 0 Then
                If linenum <= Scintilla1.Lines.Count Then
                    Scintilla1.Lines(linenum - 1).Goto()
                Else
                    Scintilla1.Lines(Scintilla1.Lines.Count - 1).Goto()
                End If
            Else
                Scintilla1.Lines(0).Goto()
            End If
        Catch
        End Try
    End Sub

#End Region

#Region "Public Events"

    Public Event SavePointLeft(sender As Object, e As EventArgs)
    Public Event SavePointReached(sender As Object, e As EventArgs)
    Public Shadows Event MouseEnter(sender As Object, e As EventArgs)
    Public Event UpdateUI(sender As Object, e As UpdateUIEventArgs)
    Public Shadows Event TextChanged(sender As Object, e As EventArgs)
    Public Shadows Event Click(sender As Object, e As EventArgs)
    Public Shadows Event DragEnter(sender As Object, e As DragEventArgs)
    Public Shadows Event DragLeave(sender As Object, e As EventArgs)
    Public Event LanguageChanged()
    Public Shadows Event GotFocus(sender As Object, e As EventArgs)
    Public Event SelectionChanged(sender As Object, e As UpdateUIEventArgs)
    Public Event TextAddedToClipboardHistory(AddedText As String)
    Public Event ClipboardHistoryCleared()
    Public Event FinishedInitializing()
    Public Shadows Event KeyDown(sender As Object, e As KeyEventArgs)

#End Region

#Region "Events"

    Private Sub Scintilla1_CharAdded(sender As Object, e As ScintillaNET.CharAddedEventArgs) Handles Scintilla1.CharAdded
        'AutoComplete
        If EditorMode = Mode.Editor Then
            If AutoComplete And EditorMode = Mode.Editor And _autoclist <> "" Then
                Dim currentPos = Scintilla1.CurrentPosition
                Dim wordStartPos = Scintilla1.WordStartPosition(currentPos, True)
                ' Display the autocompletion list
                Dim lenEntered = currentPos - wordStartPos
                If lenEntered > 0 Then
                    Scintilla1.AutoCShow(lenEntered, _autoclist)
                End If
            End If
            If SmartCompletion And _smartcompletion_pressedkey <> Keys.Back And _smartcompletion_pressedkey <> Keys.Delete Then
                RunSmartCompletion()
            End If

            HideSnippetListIfVisible()
            HideIncrementalSearcherIfVisible()
            If SmartIndentation Then
                'The '}' char.
                If e.Char = 125 Then
                    Dim curLine As Integer = Scintilla1.LineFromPosition(Scintilla1.CurrentPosition)

                    If Scintilla1.Lines(curLine).Text.Trim() = "}" Then
                        'Check whether the bracket is the only thing on the line.. For cases like "if() { }".
                        Scintilla1.Lines(curLine).Indentation = Scintilla1.Lines(curLine).Indentation - 4
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ScintillaS1_MouseEnter(sender As Object, e As EventArgs) Handles Scintilla1.MouseEnter
        If EditorMode = Mode.Editor Then
            RaiseEvent MouseEnter(sender, e)
            Dim a As Form = Form.ActiveForm
            Dim b As Form = Me.Parent.FindForm()
            If a Is b And Not pnl_snippetlist.Visible And Not pnl_incrementalsearcher.Visible Then
                SetFocus()
            End If
        End If
    End Sub

    Private Sub Scintilla1_TextChanged(sender As Object, e As EventArgs) Handles Scintilla1.TextChanged
        RaiseEvent TextChanged(sender, e)
        If EditorMode = Mode.Editor Then
            'Display Line Number
            Dim maxLineNumberCharLength = Scintilla1.Lines.Count.ToString().Length
            If maxLineNumberCharLength = Me._maxLineNumberCharLength Then
                Return
            End If
            Const padding As Integer = 2
            Scintilla1.Margins(0).Width = Scintilla1.TextWidth(Style.LineNumber, New String("9"c, maxLineNumberCharLength + 1)) + padding
            Me._maxLineNumberCharLength = maxLineNumberCharLength
            '----------------
        End If
    End Sub

    Private Sub Scintilla1_UpdateUI(sender As Object, e As UpdateUIEventArgs) Handles Scintilla1.UpdateUI
        RaiseEvent UpdateUI(sender, e)
        'Brace Matching and Guide Highlighting
        If _bracematch Then
            Dim caretPos = Scintilla1.CurrentPosition
            If _lastCaretPos <> caretPos Then
                _lastCaretPos = caretPos
                Dim bracePos1 = -1
                Dim bracePos2 = -1

                ' Is there a brace to the left or right?
                If caretPos > 0 AndAlso XDev.EditorHelper.Helper.IsBrace(Scintilla1.GetCharAt(caretPos - 1)) Then
                    bracePos1 = (caretPos - 1)
                ElseIf XDev.EditorHelper.Helper.IsBrace(Scintilla1.GetCharAt(caretPos)) Then
                    bracePos1 = caretPos
                End If

                If bracePos1 >= 0 Then
                    ' Find the matching brace
                    bracePos2 = Scintilla1.BraceMatch(bracePos1)
                    If bracePos2 = Scintilla.InvalidPosition Then
                        Scintilla1.BraceBadLight(bracePos1)
                        Scintilla1.HighlightGuide = 0
                    Else
                        Scintilla1.BraceHighlight(bracePos1, bracePos2)
                        Scintilla1.HighlightGuide = Scintilla1.GetColumn(bracePos1)
                    End If
                Else
                    ' Turn off brace matching
                    Scintilla1.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition)
                    Scintilla1.HighlightGuide = 0
                End If
            End If
        End If
        If (e.Change And UpdateChange.Selection) > 0 Then
            RaiseEvent SelectionChanged(sender, e)
        End If
    End Sub

    Private Sub Scintilla1_InsertCheck(sender As Object, e As InsertCheckEventArgs) Handles Scintilla1.InsertCheck
        If RecordClipboardHistory AndAlso justpasted Then
            AddTextToClipboardHistory(e.Text)
            justpasted = False
        End If
        If SmartIndentation Then
            If (e.Text.EndsWith("" + Constants.vbCr) OrElse e.Text.EndsWith("" + Constants.vbLf)) Then
                Dim startPos As Integer = Scintilla1.Lines(Scintilla1.LineFromPosition(Scintilla1.CurrentPosition)).Position
                Dim endPos As Integer = e.Position
                Dim curLineText As String = Scintilla1.GetTextRange(startPos, (endPos - startPos))
                'Text until the caret so that the whitespace is always equal in every line.
                Dim indent As Match = Regex.Match(curLineText, "^[ \t]*")
                e.Text = (e.Text + indent.Value)
                If Regex.IsMatch(curLineText, "{\s*$") Then
                    e.Text = (e.Text + Constants.vbTab)
                End If
            End If
        End If
    End Sub

    Private Sub Scintilla1_KeyDown(sender As Object, e As KeyEventArgs) Handles Scintilla1.KeyDown
        If e.KeyCode = Keys.Delete Then
            _smartcompletion_pressedkey = Keys.Delete
        ElseIf e.KeyCode = Keys.Back Then
            _smartcompletion_pressedkey = Keys.Back
        Else
            _smartcompletion_pressedkey = Keys.None
        End If
        If TabTriggersEnabled Then
            If e.KeyCode = Keys.Tab Then
                If tabtriggerslist.Count > 0 Then
                    Dim arr() As String
                    For Each item As String In tabtriggerslist
                        arr = item.Split("|")
                        If arr(0) = Scintilla1.Lines(Scintilla1.CurrentLine).Text Then
                            e.SuppressKeyPress = True
                            If TabTriggersReplacePhrase Then
                                SetTextForLine(Scintilla1.CurrentLine, "")
                                Scintilla1.InsertText(Scintilla1.CurrentPosition, arr(1))
                            Else
                                Scintilla1.InsertText(Scintilla1.CurrentPosition, arr(1))
                            End If
                        End If
                    Next
                End If
            End If
        End If
        If e.Modifiers = Keys.Control Then
            Select Case e.KeyCode
                Case Keys.C
                    AddSelectedTextToClipboardHistory()
                Case Keys.X
                    AddSelectedTextToClipboardHistory()
                Case Keys.V
                    justpasted = True
            End Select
        End If
        RaiseEvent KeyDown(sender, e)
    End Sub

    Private Sub Scintilla1_SavePointLeft(sender As Object, e As EventArgs) Handles Scintilla1.SavePointLeft
        RaiseEvent SavePointLeft(sender, e)
    End Sub

    Private Sub Scintilla1_SavePointReached(sender As Object, e As EventArgs) Handles Scintilla1.SavePointReached
        RaiseEvent SavePointReached(sender, e)
    End Sub

    Private Sub Scintilla1_MouseClick(sender As Object, e As MouseEventArgs) Handles Scintilla1.MouseClick

        If HighlightMatchingWords Then
            If Scintilla1.GetWordFromPosition(Scintilla1.CurrentPosition) <> "" AndAlso Not String.IsNullOrWhiteSpace(Scintilla1.GetWordFromPosition(Scintilla1.CurrentPosition)) Then
                HighlightAllMatchingWords(Scintilla1.GetWordFromPosition(Scintilla1.CurrentPosition))
            Else
                ClearMatchingWordHighlights()
                If HighlightMatchingSelection Then
                    If Not String.IsNullOrWhiteSpace(Scintilla1.SelectedText) Then
                        HighlightAllMatchingWords(Scintilla1.SelectedText)
                    Else
                        ClearMatchingWordHighlights()
                    End If
                End If
            End If
        End If
        HideSnippetListIfVisible()
        HideIncrementalSearcherIfVisible()
    End Sub

    Private Sub Scintilla1_GotFocus(sender As Object, e As EventArgs) Handles Scintilla1.GotFocus
        RaiseEvent GotFocus(sender, e)
    End Sub

    Private Sub Scintilla1_Click(sender As Object, e As EventArgs) Handles Scintilla1.Click
        RaiseEvent Click(sender, e)
    End Sub

    Private Sub Scintilla1_DragEnter(sender As Object, e As DragEventArgs) Handles Scintilla1.DragEnter
        RaiseEvent DragEnter(sender, e)
    End Sub

    Private Sub Scintilla1_DragLeave(sender As Object, e As EventArgs) Handles Scintilla1.DragLeave
        RaiseEvent DragLeave(sender, e)
    End Sub

    Private Sub Scintilla1_DwellStart(sender As Object, e As DwellEventArgs) Handles Scintilla1.DwellStart
        mousedwellposition = e.Position
    End Sub

#End Region

#Region "XEditor"

    Private Sub XEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Font = New Font("Consolas", 10)
        'Brace Highlighting
        Scintilla1.Styles(Style.BraceLight).BackColor = Color.LightGray
        Scintilla1.Styles(Style.BraceLight).Bold = True
        Scintilla1.Styles(Style.BraceLight).ForeColor = Color.DeepPink
        Scintilla1.Styles(Style.BraceBad).ForeColor = Color.Red
        '-----------
        If EditorMode = Mode.DocumentMap Then
            Zoom = -10
            HScrollBar = False
            Scintilla1.ReadOnly = True
            Scintilla1.Margins(0).Width = 0
            Scintilla1.Margins(1).Width = 0
            Scintilla1.Margins(2).Width = 0
            Scintilla1.Styles(Style.Default).BackColor = Color.WhiteSmoke
        End If
        ManageKeyboardShortcuts()
        InitializeLists()
        RaiseEvent FinishedInitializing()
    End Sub

#End Region

#Region "Custom Keyboard Shortcuts"

    Private Sub InsertSymbolToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowInsertSymbol()
    End Sub

    Private Sub CodeTemplatesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowCodeTemplates()
    End Sub

    Private Sub ClipboardHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowClipboardHistory()
    End Sub

#End Region

End Class