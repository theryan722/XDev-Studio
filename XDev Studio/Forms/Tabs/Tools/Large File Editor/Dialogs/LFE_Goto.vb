Imports System.Windows.Forms

Friend Class LFE_Goto

    Private _editor As Tab_LargeFileEditor
    Private _totallines As Integer = 0
    Private _currentline As Integer = 0
    Private _gotoline As Integer

#Region "dlgGoto"

    Public Sub New(ByRef ed As Tab_LargeFileEditor, ByVal totline As Integer, ByVal curline As Integer)
        InitializeComponent()
        _editor = ed
        lblTotal.Text = "Total Lines: " & totline
        lblCurrent.Text = "Current Line: " & curline
        txtLine.Text = curline
    End Sub

#End Region

#Region "Buttons"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            _editor.GotoLine(CInt(txtLine.Text))
            Me.Close()
        Catch
        End Try
    End Sub

#End Region

    Private Sub txtLine_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtLine.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOk.PerformClick()
        End If
    End Sub

End Class