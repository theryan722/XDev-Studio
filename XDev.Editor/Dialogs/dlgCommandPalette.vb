Public Class dlgCommandPalette
    Private editor As XEditor
    Private cmdlist As New List(Of String)

#Region "Methods"

    'Clears the listbox and populates it with editor commands
    Private Sub RefreshList()
        ListBox1.Items.Clear()
        For Each item As String In cmdlist
            ListBox1.Items.Add(item)
        Next
    End Sub

    'The list of commands that are placed in the listbox
    Private Sub AddCommandsToList()
        cmdlist.Add("BackTab")
        cmdlist.Add("Cancel")
        cmdlist.Add("CharLeft")
        cmdlist.Add("CharLeftExtend")
        cmdlist.Add("CharLeftRectExtend")
        cmdlist.Add("CharRight")
        cmdlist.Add("CharRightExtend")
        cmdlist.Add("CharRightRectExtend")
        cmdlist.Add("DelLineLeft")
        cmdlist.Add("DelLineRight")
        cmdlist.Add("DelWordLeft")
        cmdlist.Add("DelWordRight")
        cmdlist.Add("DelWordRightEnd")
        cmdlist.Add("DeleteBack")
        cmdlist.Add("DeleteBackNotLine")
        cmdlist.Add("DocumentEnd")
        cmdlist.Add("DocumentEndExtend")
        cmdlist.Add("DocumentStart")
        cmdlist.Add("DocumentStartExtend")
        cmdlist.Add("EditToggleOvertype")
        cmdlist.Add("FormFeed")
        cmdlist.Add("Home")
        cmdlist.Add("HomeDisplay")
        cmdlist.Add("HomeDisplayExtend")
        cmdlist.Add("HomeExtend")
        cmdlist.Add("HomeRectExtend")
        cmdlist.Add("HomeWrap")
        cmdlist.Add("HomeWrapExtend")
        cmdlist.Add("LineCopy")
        cmdlist.Add("LineCut")
        cmdlist.Add("LineDelete")
        cmdlist.Add("LineDown")
        cmdlist.Add("LineDownExtend")
        cmdlist.Add("LineDownRectExtend")
        cmdlist.Add("LineDuplicate")
        cmdlist.Add("LineEnd")
        cmdlist.Add("LineEndDisplay")
        cmdlist.Add("LineEndDisplayExtend")
        cmdlist.Add("LineEndExtend")
        cmdlist.Add("LineEndRectExtend")
        cmdlist.Add("LineEndWrap")
        cmdlist.Add("LineEndWrapExtend")
        cmdlist.Add("LineScrollDown")
        cmdlist.Add("LineScrollUp")
        cmdlist.Add("LineTranspose")
        cmdlist.Add("LineUp")
        cmdlist.Add("LineUpExtend")
        cmdlist.Add("LineUpRectExtend")
        cmdlist.Add("Lowercase")
        cmdlist.Add("MoveSelectedLinesDown")
        cmdlist.Add("MoveSelectedLinesUp")
        cmdlist.Add("MultipleSelectAddEach")
        cmdlist.Add("MultipleSelectAddNext")
        cmdlist.Add("NewLine")
        cmdlist.Add("PageDown")
        cmdlist.Add("PageDownExtend")
        cmdlist.Add("PageDownRectExtend")
        cmdlist.Add("PageUp")
        cmdlist.Add("PageUpExtend")
        cmdlist.Add("PageUpRectExtend")
        cmdlist.Add("ParaDown")
        cmdlist.Add("ParaDownExtend")
        cmdlist.Add("ParaUp")
        cmdlist.Add("ParaUpExtend")
        cmdlist.Add("Redo")
        cmdlist.Add("RotateSelection")
        cmdlist.Add("ScrollToEnd")
        cmdlist.Add("ScrollToStart")
        cmdlist.Add("SelectAll")
        cmdlist.Add("SelectionDuplicate")
        cmdlist.Add("StutteredPageDown")
        cmdlist.Add("StutteredPageDownExtend")
        cmdlist.Add("StutteredPageUp")
        cmdlist.Add("StutteredPageUpExtend")
        cmdlist.Add("SwapMainAnchorCaret")
        cmdlist.Add("Tab")
        cmdlist.Add("Undo")
        cmdlist.Add("Uppercase")
        cmdlist.Add("VcHome")
        cmdlist.Add("VcHomeDisplay")
        cmdlist.Add("VcHomeDisplayExtend")
        cmdlist.Add("VcHomeExtend")
        cmdlist.Add("VcHomeRectExtend")
        cmdlist.Add("VcHomeWrap")
        cmdlist.Add("VcHomeWrapExtend")
        cmdlist.Add("VerticalCenterCaret")
        cmdlist.Add("WordLeft")
        cmdlist.Add("WordLeftEnd")
        cmdlist.Add("WordLeftEndExtend")
        cmdlist.Add("WordLeftExtend")
        cmdlist.Add("WordPartLeft")
        cmdlist.Add("WordPartLeftExtend")
        cmdlist.Add("WordPartRight")
        cmdlist.Add("WordPartRightExtend")
        cmdlist.Add("WordRight")
        cmdlist.Add("WordRightEnd")
        cmdlist.Add("WordRightEndExtend")
        cmdlist.Add("WordRightExtend")
        cmdlist.Add("ZoomIn")
        cmdlist.Add("ZoomOut")
    End Sub

    Private Sub ProcessCommand(ByVal txt As String)
        Select Case txt
            Case "BackTab"
                editor.ExecuteCommand(ScintillaNET.Command.BackTab)
            Case "Cancel"
                editor.ExecuteCommand(ScintillaNET.Command.Cancel)
            Case "CharLeft"
                editor.ExecuteCommand(ScintillaNET.Command.CharLeft)
            Case "CharLeftExtend"
                editor.ExecuteCommand(ScintillaNET.Command.CharLeftExtend)
            Case "CharLeftRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.CharLeftRectExtend)
            Case "CharRight"
                editor.ExecuteCommand(ScintillaNET.Command.CharRight)
            Case "CharRightExtend"
                editor.ExecuteCommand(ScintillaNET.Command.CharRightExtend)
            Case "CharRightRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.CharRightRectExtend)
            Case "DelLineLeft"
                editor.ExecuteCommand(ScintillaNET.Command.DelLineLeft)
            Case "DelLineRight"
                editor.ExecuteCommand(ScintillaNET.Command.DelLineRight)
            Case "DelWordLeft"
                editor.ExecuteCommand(ScintillaNET.Command.DelWordLeft)
            Case "DelWordRight"
                editor.ExecuteCommand(ScintillaNET.Command.DelWordRight)
            Case "DelWordRightEnd"
                editor.ExecuteCommand(ScintillaNET.Command.DelWordRightEnd)
            Case "DeleteBack"
                editor.ExecuteCommand(ScintillaNET.Command.DeleteBack)
            Case "DeleteBackNotLine"
                editor.ExecuteCommand(ScintillaNET.Command.DeleteBackNotLine)
            Case "DocumentEnd"
                editor.ExecuteCommand(ScintillaNET.Command.DocumentEnd)
            Case "DocumentEndExtend"
                editor.ExecuteCommand(ScintillaNET.Command.DocumentEndExtend)
            Case "DocumentStart"
                editor.ExecuteCommand(ScintillaNET.Command.DocumentStart)
            Case "DocumentStartExtend"
                editor.ExecuteCommand(ScintillaNET.Command.DocumentStartExtend)
            Case "EditToggleOvertype"
                editor.ExecuteCommand(ScintillaNET.Command.EditToggleOvertype)
            Case "FormFeed"
                editor.ExecuteCommand(ScintillaNET.Command.FormFeed)
            Case "Home"
                editor.ExecuteCommand(ScintillaNET.Command.Home)
            Case "HomeDisplay"
                editor.ExecuteCommand(ScintillaNET.Command.HomeDisplay)
            Case "HomeDisplayExtend"
                editor.ExecuteCommand(ScintillaNET.Command.HomeDisplayExtend)
            Case "HomeExtend"
                editor.ExecuteCommand(ScintillaNET.Command.HomeExtend)
            Case "HomeRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.HomeRectExtend)
            Case "HomeWrap"
                editor.ExecuteCommand(ScintillaNET.Command.HomeWrap)
            Case "HomeWrapExtend"
                editor.ExecuteCommand(ScintillaNET.Command.HomeWrapExtend)
            Case "LineCopy"
                editor.ExecuteCommand(ScintillaNET.Command.LineCopy)
            Case "LineCut"
                editor.ExecuteCommand(ScintillaNET.Command.LineCut)
            Case "LineDelete"
                editor.ExecuteCommand(ScintillaNET.Command.LineDelete)
            Case "LineDown"
                editor.ExecuteCommand(ScintillaNET.Command.LineDown)
            Case "LineDownExtend"
                editor.ExecuteCommand(ScintillaNET.Command.LineDownExtend)
            Case "LineDownRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.LineDownRectExtend)
            Case "LineDuplicate"
                editor.ExecuteCommand(ScintillaNET.Command.LineDuplicate)
            Case "LineEnd"
                editor.ExecuteCommand(ScintillaNET.Command.LineEnd)
            Case "LineEndDisplay"
                editor.ExecuteCommand(ScintillaNET.Command.LineEndDisplay)
            Case "LineEndDisplayExtend"
                editor.ExecuteCommand(ScintillaNET.Command.LineEndDisplayExtend)
            Case "LineEndExtend"
                editor.ExecuteCommand(ScintillaNET.Command.LineEndExtend)
            Case "LineEndRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.LineEndRectExtend)
            Case "LineEndWrap"
                editor.ExecuteCommand(ScintillaNET.Command.LineEndWrap)
            Case "LineEndWrapExtend"
                editor.ExecuteCommand(ScintillaNET.Command.LineEndWrapExtend)
            Case "LineScrollDown"
                editor.ExecuteCommand(ScintillaNET.Command.LineScrollDown)
            Case "LineScrollUp"
                editor.ExecuteCommand(ScintillaNET.Command.LineScrollUp)
            Case "LineTranspose"
                editor.ExecuteCommand(ScintillaNET.Command.LineTranspose)
            Case "LineUp"
                editor.ExecuteCommand(ScintillaNET.Command.LineUp)
            Case "LineUpExtend"
                editor.ExecuteCommand(ScintillaNET.Command.LineUpExtend)
            Case "LineUpRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.LineUpRectExtend)
            Case "Lowercase"
                editor.ExecuteCommand(ScintillaNET.Command.Lowercase)
            Case "MoveSelectedLinesDown"
                editor.ExecuteCommand(ScintillaNET.Command.MoveSelectedLinesDown)
            Case "MoveSelectedLinesUp"
                editor.ExecuteCommand(ScintillaNET.Command.MoveSelectedLinesUp)
            Case "MultipleSelectAddEach"
                editor.ExecuteCommand(ScintillaNET.Command.MultipleSelectAddEach)
            Case "MultipleSelectAddNext"
                editor.ExecuteCommand(ScintillaNET.Command.MultipleSelectAddNext)
            Case "NewLine"
                editor.ExecuteCommand(ScintillaNET.Command.NewLine)
            Case "PageDown"
                editor.ExecuteCommand(ScintillaNET.Command.PageDown)
            Case "PageDownExtend"
                editor.ExecuteCommand(ScintillaNET.Command.PageDownExtend)
            Case "PageDownRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.PageDownRectExtend)
            Case "PageUp"
                editor.ExecuteCommand(ScintillaNET.Command.PageUp)
            Case "PageUpExtend"
                editor.ExecuteCommand(ScintillaNET.Command.PageUpExtend)
            Case "PageUpRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.PageUpRectExtend)
            Case "ParaDown"
                editor.ExecuteCommand(ScintillaNET.Command.ParaDown)
            Case "ParaDownExtend"
                editor.ExecuteCommand(ScintillaNET.Command.ParaDownExtend)
            Case "ParaUp"
                editor.ExecuteCommand(ScintillaNET.Command.ParaUp)
            Case "ParaUpExtend"
                editor.ExecuteCommand(ScintillaNET.Command.ParaUpExtend)
            Case "Redo"
                editor.ExecuteCommand(ScintillaNET.Command.Redo)
            Case "RotateSelection"
                editor.ExecuteCommand(ScintillaNET.Command.RotateSelection)
            Case "ScrollToEnd"
                editor.ExecuteCommand(ScintillaNET.Command.ScrollToEnd)
            Case "ScrollToStart"
                editor.ExecuteCommand(ScintillaNET.Command.ScrollToStart)
            Case "SelectAll"
                editor.ExecuteCommand(ScintillaNET.Command.SelectAll)
            Case "SelectionDuplicate"
                editor.ExecuteCommand(ScintillaNET.Command.SelectionDuplicate)
            Case "StutteredPageDown"
                editor.ExecuteCommand(ScintillaNET.Command.StutteredPageDown)
            Case "StutteredPageDownExtend"
                editor.ExecuteCommand(ScintillaNET.Command.StutteredPageDownExtend)
            Case "StutteredPageUp"
                editor.ExecuteCommand(ScintillaNET.Command.StutteredPageUp)
            Case "StutteredPageUpExtend"
                editor.ExecuteCommand(ScintillaNET.Command.StutteredPageUpExtend)
            Case "SwapMainAnchorCaret"
                editor.ExecuteCommand(ScintillaNET.Command.SwapMainAnchorCaret)
            Case "Tab"
                editor.ExecuteCommand(ScintillaNET.Command.Tab)
            Case "Undo"
                editor.ExecuteCommand(ScintillaNET.Command.Undo)
            Case "Uppercase"
                editor.ExecuteCommand(ScintillaNET.Command.Uppercase)
            Case "VcHome"
                editor.ExecuteCommand(ScintillaNET.Command.VcHome)
            Case "VcHomeDisplay"
                editor.ExecuteCommand(ScintillaNET.Command.VcHomeDisplay)
            Case "VcHomeDisplayExtend"
                editor.ExecuteCommand(ScintillaNET.Command.VcHomeDisplayExtend)
            Case "VcHomeExtend"
                editor.ExecuteCommand(ScintillaNET.Command.VcHomeExtend)
            Case "VcHomeRectExtend"
                editor.ExecuteCommand(ScintillaNET.Command.VcHomeRectExtend)
            Case "VcHomeWrap"
                editor.ExecuteCommand(ScintillaNET.Command.VcHomeWrap)
            Case "VcHomeWrapExtend"
                editor.ExecuteCommand(ScintillaNET.Command.VcHomeWrapExtend)
            Case "VerticalCenterCaret"
                editor.ExecuteCommand(ScintillaNET.Command.VerticalCenterCaret)
            Case "WordLeft"
                editor.ExecuteCommand(ScintillaNET.Command.WordLeft)
            Case "WordLeftEnd"
                editor.ExecuteCommand(ScintillaNET.Command.WordLeftEnd)
            Case "WordLeftEndExtend"
                editor.ExecuteCommand(ScintillaNET.Command.WordLeftEndExtend)
            Case "WordLeftExtend"
                editor.ExecuteCommand(ScintillaNET.Command.WordLeftExtend)
            Case "WordPartLeft"
                editor.ExecuteCommand(ScintillaNET.Command.WordPartLeft)
            Case "WordPartLeftExtend"
                editor.ExecuteCommand(ScintillaNET.Command.WordPartLeftExtend)
            Case "WordPartRight"
                editor.ExecuteCommand(ScintillaNET.Command.WordPartRight)
            Case "WordPartRightExtend"
                editor.ExecuteCommand(ScintillaNET.Command.WordPartRightExtend)
            Case "WordRight"
                editor.ExecuteCommand(ScintillaNET.Command.WordRight)
            Case "WordRightEnd"
                editor.ExecuteCommand(ScintillaNET.Command.WordRightEnd)
            Case "WordRightEndExtend"
                editor.ExecuteCommand(ScintillaNET.Command.WordRightEndExtend)
            Case "WordRightExtend"
                editor.ExecuteCommand(ScintillaNET.Command.WordRightExtend)
            Case "ZoomIn"
                editor.ExecuteCommand(ScintillaNET.Command.ZoomIn)
            Case "ZoomOut"
                editor.ExecuteCommand(ScintillaNET.Command.ZoomOut)
        End Select
        If check_closeaftercommandexecuted.Checked Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "txt_search"

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        If txt_search.Text = "" Then
            RefreshList()
        Else
            ListBox1.Items.Clear()
            For Each item As String In cmdlist
                If item.ToLower.Contains(txt_search.Text.ToLower) Then
                    ListBox1.Items.Add(item)
                End If
            Next
        End If
    End Sub

#End Region

#Region "ListBox1"

    Private Sub ListBox1_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If ListBox1.SelectedIndex <> -1 Then
                ProcessCommand(ListBox1.SelectedItem)
            End If
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        If ListBox1.SelectedIndex <> -1 Then
            ProcessCommand(ListBox1.SelectedItem)
        End If
    End Sub

#End Region

#Region "dlgCommandPalette"

    Public Sub New(ByRef ed As XEditor)
        InitializeComponent()
        editor = ed
    End Sub

    Private Sub dlgCommandPalette_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        editor.cmdpalettedlgshowing = False
    End Sub

    Private Sub dlgCommandPalette_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormPosition.CenterForm(Me, editor.ParentForm)
        Catch
        End Try
        AddCommandsToList()
        RefreshList()
    End Sub

#End Region

End Class