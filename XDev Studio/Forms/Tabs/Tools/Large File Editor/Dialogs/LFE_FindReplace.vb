﻿Imports System.Drawing
Imports ScintillaNET
Imports ScintillaNET.SearchFlags

Friend Class LFE_FindReplace
    Private editor As Tab_LargeFileEditor
    Private _cso As Boolean = True
    Private find_tstart As Integer
    Private find_tend As Integer

#Region "StatusStrip"

    Private Sub ConstrainSearchOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConstrainSearchOptionsToolStripMenuItem.Click
        If _cso Then
            ConstrainSearchOptionsToolStripMenuItem.Checked = False
            _cso = False
        Else
            ConstrainSearchOptionsToolStripMenuItem.Checked = True
            _cso = True
        End If
    End Sub

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
        Me.Opacity = 1
        ToolStripMenuItem2.Checked = True
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        ClearOpacityChecks()
        Me.Opacity = 0.9
        ToolStripMenuItem3.Checked = True
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        ClearOpacityChecks()
        Me.Opacity = 0.8
        ToolStripMenuItem4.Checked = True
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        ClearOpacityChecks()
        Me.Opacity = 0.7
        ToolStripMenuItem5.Checked = True
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        ClearOpacityChecks()
        Me.Opacity = 0.6
        ToolStripMenuItem6.Checked = True
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        ClearOpacityChecks()
        Me.Opacity = 0.5
        ToolStripMenuItem7.Checked = True
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        ClearOpacityChecks()
        Me.Opacity = 0.4
        ToolStripMenuItem8.Checked = True
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        ClearOpacityChecks()
        Me.Opacity = 0.3
        ToolStripMenuItem9.Checked = True
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        ClearOpacityChecks()
        Me.Opacity = 0.2
        ToolStripMenuItem10.Checked = True
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        ClearOpacityChecks()
        Me.Opacity = 0.1
        ToolStripMenuItem11.Checked = True
    End Sub

#End Region

#End Region

#Region "dlgFindReplace"

    Public Sub New(ByRef ed As Tab_LargeFileEditor)
        InitializeComponent()
        editor = ed
    End Sub

    Public Sub New(ByRef ed As Tab_LargeFileEditor, ByVal txt As String)
        InitializeComponent()
        editor = ed
        txt_find_find.Text = txt
    End Sub

    Private Sub dlgFindReplace_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        editor.finddlgshowing = False
    End Sub

#End Region

#Region "Tab Control"

#Region "Find"

    Private Sub btn_find_clrfind_Click(sender As Object, e As EventArgs) Handles btn_find_clrfind.Click
        txt_find_find.Text = ""
    End Sub

    Private Sub txt_find_find_TextChanged(sender As Object, e As EventArgs) Handles txt_find_find.TextChanged
        If _cso Then
            txt_replace_find.Text = txt_find_find.Text
        End If
    End Sub

    Private Sub FindPreActions()
        lblStatus.Text = "[]"
        If txt_find_find.Text <> "" And txt_find_find.Text <> " " And Not txt_find_find.Items.Contains(txt_find_find.Text) Then
            txt_find_find.Items.Add(txt_find_find.Text)
        End If
    End Sub

    Private Function GetFindSearchFlags() As Integer
        Dim sflags As Integer = 0
        If check_find_matchcase.Checked Then
            sflags += SearchFlags.MatchCase
        End If
        If check_find_wholeword.Checked Then
            sflags += SearchFlags.WholeWord
        End If
        If check_find_wordstart.Checked Then
            sflags += SearchFlags.WordStart
        End If
        If Not check_find_matchcase.Checked And Not check_find_wholeword.Checked And Not check_find_wordstart.Checked Then
            sflags = SearchFlags.None
        End If
        Return sflags
    End Function

    Private Sub btn_find_previous_Click(sender As Object, e As EventArgs) Handles btn_find_previous.Click
        If radio_find_normal.Checked Then
            FindPreActions()
            Dim res As Integer = editor.FindPrevious(txt_find_find.Text, GetFindSearchFlags())
            If res = -1 Then
                lblStatus.Text = "Match could not be found"
            End If
        Else
            FindPreActions()
            Dim res As Integer = editor.FindPreviousReg(txt_find_find.Text)
            If res = -1 Then
                lblStatus.Text = "Match could not be found"
            End If
        End If
    End Sub

    Private Sub btn_find_next_Click(sender As Object, e As EventArgs) Handles btn_find_next.Click
        FindPreActions()
        If radio_find_normal.Checked Then
            Dim res As Integer = editor.FindNext(txt_find_find.Text, GetFindSearchFlags())
            If res = -1 Then
                lblStatus.Text = "Match could not be found"
            End If
        Else
            Dim res As Integer = editor.FindNextReg(txt_find_find.Text)
            If res = -1 Then
                lblStatus.Text = "Match could not be found"
            End If
        End If
    End Sub

    Private Sub btn_find_all_Click(sender As Object, e As EventArgs) Handles btn_find_all.Click
        If radio_find_normal.Checked Then
            FindPreActions()
            lblStatus.Text = "Total Found Matches: " & editor.FindAll(txt_find_find.Text, GetFindSearchFlags()).Count
        Else
            FindPreActions()
            lblStatus.Text = "Total Found Matches: " & editor.FindAllReg(txt_find_find.Text).Count
        End If

    End Sub

    Private Sub check_find_wordstart_CheckedChanged(sender As Object, e As EventArgs) Handles check_find_wordstart.CheckedChanged
        If _cso Then
            check_replace_wordstart.CheckState = check_find_wordstart.CheckState
        End If
    End Sub

    Private Sub btn_find_highlightmatches_Click(sender As Object, e As EventArgs) Handles btn_find_highlightmatches.Click
        editor.HighlightFoundWords(txt_find_find.Text, Color.Yellow)
    End Sub

    Private Sub btn_find_clearhighlighting_Click(sender As Object, e As EventArgs) Handles btn_find_clearhighlighting.Click
        editor.ClearFoundHighlightedWords()
    End Sub

    Private Sub radio_find_normal_CheckedChanged(sender As Object, e As EventArgs) Handles radio_find_normal.CheckedChanged
        If _cso Then
            If radio_find_normal.Checked Then
                radio_replace_normal.Checked = True
            Else
                radio_replace_regex.Checked = True
            End If
        End If
    End Sub

    Private Sub check_find_matchcase_CheckedChanged(sender As Object, e As EventArgs) Handles check_find_matchcase.CheckedChanged
        If _cso Then
            check_replace_matchcase.CheckState = check_find_matchcase.CheckState
        End If
    End Sub

    Private Sub check_find_wholeword_CheckedChanged(sender As Object, e As EventArgs) Handles check_find_wholeword.CheckedChanged
        If _cso Then
            check_replace_wholeword.CheckState = check_find_wholeword.CheckState
        End If
    End Sub

#End Region

#Region "Replace"

    Private Sub btn_replace_all_Click(sender As Object, e As EventArgs) Handles btn_replace_all.Click
        If radio_replace_normal.Checked Then
            ReplacePreActions()
            lblStatus.Text = "Replaced Instances: " & editor.ReplaceAll(txt_replace_find.Text, txt_replace_replace.Text, GetReplaceSearchFlags()).Count
        Else
            ReplacePreActions()
            lblStatus.Text = "Replaced Instances: " & editor.ReplaceAllReg(txt_replace_find.Text, txt_replace_replace.Text).Count
        End If
    End Sub

    Private Sub btn_replace_clrfind_Click(sender As Object, e As EventArgs) Handles btn_replace_clrfind.Click
        txt_replace_find.Text = ""
    End Sub

    Private Sub btn_replace_clrreplace_Click(sender As Object, e As EventArgs) Handles btn_replace_clrreplace.Click
        txt_replace_replace.Text = ""
    End Sub

    Private Sub btn_replace_previous_Click(sender As Object, e As EventArgs) Handles btn_replace_previous.Click
        If radio_replace_normal.Checked Then
            ReplacePreActions()
            If Not check_replace_wholeword.Checked And txt_replace_replace.Text.StartsWith(txt_replace_find.Text) Then
                Dim res As Integer = editor.ReplacePrevious(txt_replace_find.Text, txt_replace_replace.Text, GetReplaceSearchFlags() + SearchFlags.WholeWord)
                If res = -1 Then
                    lblStatus.Text = "Match could not be found"
                End If
            Else
                Dim res As Integer = editor.ReplacePrevious(txt_replace_find.Text, txt_replace_replace.Text, GetReplaceSearchFlags())
                If res = -1 Then
                    lblStatus.Text = "Match could not be found"
                End If
            End If
        Else
            ReplacePreActions()
            Dim res As Integer = editor.ReplacePreviousReg(txt_replace_find.Text, txt_replace_replace.Text)
            If res = -1 Then
                lblStatus.Text = "Match could not be found"
            End If
        End If
    End Sub

    Private Sub btn_replace_next_Click(sender As Object, e As EventArgs) Handles btn_replace_next.Click
        If radio_replace_normal.Checked Then
            ReplacePreActions()
            If Not check_replace_wholeword.Checked And txt_replace_replace.Text.StartsWith(txt_replace_find.Text) Then
                Dim res As Integer = editor.ReplaceNext(txt_replace_find.Text, txt_replace_replace.Text, GetReplaceSearchFlags() + SearchFlags.WholeWord)
                If res = -1 Then
                    lblStatus.Text = "Match could not be found"
                End If
            Else
                Dim res As Integer = editor.ReplaceNext(txt_replace_find.Text, txt_replace_replace.Text, GetReplaceSearchFlags())
                If res = -1 Then
                    lblStatus.Text = "Match could not be found"
                End If
            End If

        Else
            ReplacePreActions()
            Dim res As Integer = editor.ReplaceNextReg(txt_replace_find.Text, txt_replace_replace.Text)
            If res = -1 Then
                lblStatus.Text = "Match could not be found"
            End If
        End If
    End Sub

    Private Sub txt_replace_find_TextChanged(sender As Object, e As EventArgs) Handles txt_replace_find.TextChanged
        If _cso Then
            txt_find_find.Text = txt_replace_find.Text
        End If
    End Sub

    Private Sub ReplacePreActions()
        lblStatus.Text = "[]"
        If txt_replace_find.Text <> "" And txt_replace_find.Text <> " " And Not txt_replace_find.Items.Contains(txt_replace_find.Text) Then
            txt_replace_find.Items.Add(txt_replace_find.Text)
        End If
        If txt_replace_replace.Text <> "" And txt_replace_replace.Text <> " " And Not txt_replace_replace.Items.Contains(txt_replace_replace.Text) Then
            txt_replace_replace.Items.Add(txt_replace_replace.Text)
        End If
    End Sub

    Private Function GetReplaceSearchFlags() As Integer
        Dim sflags As Integer = 0
        If check_replace_matchcase.Checked Then
            sflags += SearchFlags.MatchCase
        End If
        If check_replace_wholeword.Checked Then
            sflags += SearchFlags.WholeWord
        End If
        If check_replace_wordstart.Checked Then
            sflags += SearchFlags.WordStart
        End If
        If Not check_replace_matchcase.Checked And Not check_replace_wholeword.Checked And Not check_replace_wordstart.Checked Then
            sflags = SearchFlags.None
        End If
        Return sflags
    End Function
    Private Sub check_replace_wordstart_CheckedChanged(sender As Object, e As EventArgs) Handles check_replace_wordstart.CheckedChanged
        If _cso Then
            check_find_wordstart.CheckState = check_replace_wordstart.CheckState
        End If
    End Sub

    Private Sub radio_replace_normal_CheckedChanged(sender As Object, e As EventArgs) Handles radio_replace_normal.CheckedChanged
        If _cso Then
            If radio_replace_normal.Checked Then
                radio_find_normal.Checked = True
            Else
                radio_find_regex.Checked = True
            End If
        End If
    End Sub

    Private Sub check_replace_matchcase_CheckedChanged(sender As Object, e As EventArgs) Handles check_replace_matchcase.CheckedChanged
        If _cso Then
            check_find_matchcase.CheckState = check_replace_matchcase.CheckState
        End If
    End Sub

    Private Sub check_replace_wholeword_CheckedChanged(sender As Object, e As EventArgs) Handles check_replace_wholeword.CheckedChanged
        If _cso Then
            check_find_wholeword.CheckState = check_replace_wholeword.CheckState
        End If
    End Sub

#End Region

#End Region

End Class