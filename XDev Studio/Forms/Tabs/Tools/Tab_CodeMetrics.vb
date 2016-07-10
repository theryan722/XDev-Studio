Imports System.IO
Friend Class Tab_CodeMetrics

    Dim fileloc As String

    Dim totallines As Integer
    Dim linesexcludingextras As Integer
    Dim maintainability As Integer = 100
    Dim complexity As Integer
    Dim blanklines As Integer

    'project
    Dim numoffilesinproject As Integer

    'for maintainability/complexity
    Dim num_openbrackets As Integer

#Region "Methods"

    Public Sub ResetValues()
        totallines = 0
        linesexcludingextras = 0
        maintainability = 100
        complexity = 0
        blanklines = 0
        numoffilesinproject = 0
        num_openbrackets = 0
    End Sub

    Public Sub EnableControls()
        pnl_controls.Enabled = True
    End Sub

    Public Sub DisableControls()
        pnl_controls.Enabled = False
    End Sub
    Public Sub UpdateTitle(ByVal title As String)
        Me.Parent.Text = title & " - CodeMetrics"
    End Sub

    Public Sub SetFileLocation(ByVal loc As String)
        fileloc = loc
        txt_docloc.Text = loc
        Me.DockHandler.ToolTipText = loc
    End Sub

    Public Function GetFileLocation() As String
        Return fileloc
    End Function

    Private Sub CalculateOtherMetrics()
        Dim readText() As String = File.ReadAllLines(GetFileLocation)
        Dim s As String
        For Each s In readText
            If s = "{" Then
                num_openbrackets += 1
            ElseIf s = "}" Then
            ElseIf s = "" Then
                blanklines += 1
            ElseIf s.StartsWith("//") Then
            ElseIf s.StartsWith("/*") Then
            ElseIf s.StartsWith("*") Then
            ElseIf s.StartsWith("(*") Then
            ElseIf s.StartsWith("--") Then
            Else
                linesexcludingextras += 1
            End If
            If s.EndsWith("{") Then
                num_openbrackets += 1
            End If
        Next
    End Sub

    Private Sub CalculateMaintainability()
        If linesexcludingextras < 30 Then
            'none
        ElseIf linesexcludingextras < 100 Then
            maintainability -= 1
        ElseIf linesexcludingextras < 150 Then
            maintainability -= 2
        ElseIf linesexcludingextras < 200 Then
            maintainability -= 3
        ElseIf linesexcludingextras < 250 Then
            maintainability -= 4
        ElseIf linesexcludingextras < 300 Then
            maintainability -= 5
        ElseIf linesexcludingextras < 350 Then
            maintainability -= 6
        ElseIf linesexcludingextras < 400 Then
            maintainability -= 7
        ElseIf linesexcludingextras < 450 Then
            maintainability -= 8
        ElseIf linesexcludingextras < 550 Then
            maintainability -= 9
        ElseIf linesexcludingextras > 550 Then
            maintainability -= 12
        End If

        If blanklines = 0 And linesexcludingextras < 100 Then
            maintainability -= 2
        ElseIf blanklines = 0 And linesexcludingextras < 150 Then
            maintainability -= 3
        ElseIf blanklines = 0 And linesexcludingextras < 200 Then
            maintainability -= 4
        ElseIf blanklines = 0 And linesexcludingextras < 250 Then
            maintainability -= 5
        ElseIf blanklines = 0 And linesexcludingextras < 300 Then
            maintainability -= 6
        ElseIf blanklines = 0 And linesexcludingextras < 400 Then
            maintainability -= 7
        ElseIf blanklines = 0 And linesexcludingextras < 500 Then
            maintainability -= 8
        ElseIf blanklines = 0 And linesexcludingextras > 500 Then
            maintainability -= 10
        Else
            If blanklines / linesexcludingextras <= 0.05 Then
                maintainability -= 6
            ElseIf blanklines / linesexcludingextras <= 0.1 Then
                maintainability -= 5
            ElseIf blanklines / linesexcludingextras <= 0.15 Then
                maintainability -= 4
            ElseIf blanklines / linesexcludingextras <= 0.2 Then
                maintainability -= 3
            ElseIf blanklines / linesexcludingextras <= 0.25 Then
                maintainability -= 2
            ElseIf blanklines / linesexcludingextras <= 0.3 Then
                maintainability -= 1
            End If
        End If

        If complexity < 20 Then
            maintainability -= 5
        ElseIf complexity < 30 Then
            maintainability -= 7
        ElseIf complexity < 40 Then
            maintainability -= 10
        ElseIf complexity < 50 Then
            maintainability -= 13
        ElseIf complexity < 60 Then
            maintainability -= 15
        ElseIf complexity < 70 Then
            maintainability -= 17
        ElseIf complexity < 75 Then
            maintainability -= 20
        ElseIf complexity < 80 Then
            maintainability -= 22
        ElseIf complexity < 85 Then
            maintainability -= 25
        ElseIf complexity < 90 Then
            maintainability -= 27
        ElseIf complexity < 95 Then
            maintainability -= 30
        ElseIf complexity < 100 Then
            maintainability -= 35
        End If

    End Sub

    Private Sub CalculateComplexity()
        If num_openbrackets < 10 Then
            complexity += 5
        ElseIf num_openbrackets < 20 Then
            complexity += 7
        ElseIf num_openbrackets < 30 Then
            complexity += 15
        ElseIf num_openbrackets < 40 Then
            complexity += 20
        ElseIf num_openbrackets < 60 Then
            complexity += 30
        ElseIf num_openbrackets < 100 Then
            complexity += 40
        ElseIf num_openbrackets > 100 Then
            complexity += 50
        End If
        If linesexcludingextras < 30 Then
            'none
        ElseIf linesexcludingextras < 100 Then
            complexity += 5
        ElseIf linesexcludingextras < 150 Then
            complexity += 7
        ElseIf linesexcludingextras < 200 Then
            complexity += 9
        ElseIf linesexcludingextras < 250 Then
            complexity += 15
        ElseIf linesexcludingextras < 300 Then
            complexity += 20
        ElseIf linesexcludingextras < 350 Then
            complexity += 25
        ElseIf linesexcludingextras < 400 Then
            complexity += 30
        ElseIf linesexcludingextras < 450 Then
            complexity += 35
        ElseIf linesexcludingextras < 550 Then
            complexity += 40
        ElseIf linesexcludingextras > 550 Then
            complexity += 50
        End If
    End Sub

    Private Sub DisplayOutput()
        txt_output.Text = "[XDev Studio Code Metrics Report Version 1.0] - Code Metrics for document: '" & Path.GetFileName(GetFileLocation) & "'" & vbNewLine & "==================================" & vbNewLine & "Total Lines: " & totallines & vbNewLine & "Lines Excluding Brackets, Blank Spaces, Comments, Etc. : " & linesexcludingextras & vbNewLine & "Complexity (Lower is better): " & complexity & vbNewLine & "Maintainability (Higher is better): " & maintainability & vbNewLine & "=================================="
    End Sub

    'Private Sub DisplayOutputForProject()

    'End Sub
#Region "Calculate Code Metrics"

    Public Sub CalculateCodeMetrics()
        Try
            DisableControls()
            UpdateTitle(Path.GetFileName(GetFileLocation))
            totallines = File.ReadAllLines(GetFileLocation).Length
            CalculateOtherMetrics()
            CalculateComplexity()
            CalculateMaintainability()
            DisplayOutput()
            ResetValues()
            EnableControls()
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Public Sub CalculateCodeMetrics(ByVal fileloc As String)
        SetFileLocation(fileloc)
        CalculateCodeMetrics()
    End Sub

    'Public Sub CalculateCodeMetricsForProject()
    '    If frmManager.GetPType = frmManager.ProjType.Project Then
    '        Try

    '        Catch ex As Exception
    '            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
    '        End Try
    '    End If
    'End Sub

#End Region

#End Region

    Private Sub Tab_CodeMetrics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '----
    End Sub

    Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        Dim newb As New OpenFileDialog
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SetFileLocation(newb.FileName)
        End If
    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to clear the results? All info will be reset.", "Code Metrics", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SetFileLocation("")
            txt_output.Clear()
            ResetValues()
            Me.Parent.Text = "Code Metrics"
        End If
    End Sub

    Private Sub btn_openinnotepad_Click(sender As Object, e As EventArgs) Handles btn_openinnotepad.Click
        Tabs.AddNotepad(txt_output.Text)
    End Sub

    Private Sub btn_copyclipboard_Click(sender As Object, e As EventArgs) Handles btn_copyclipboard.Click
        My.Computer.Clipboard.SetText(txt_output.Text)
        MetroFramework.MetroMessageBox.Show(frmManager, "Output copied to clipboard!", "Code Metrics", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btn_calculatedocument_Click(sender As Object, e As EventArgs) Handles btn_calculatedocument.Click
        If txt_docloc.Text = "" Then
        Else
            CalculateCodeMetrics()
        End If
    End Sub

    'Private Sub btn_calculateproject_Click(sender As Object, e As EventArgs) Handles btn_calculateproject.Click
    '    If frmManager.GetPType = frmManager.ProjType.Project Then
    '        CalculateCodeMetricsForProject()
    '        DisableControls()
    '    End If
    'End Sub
End Class