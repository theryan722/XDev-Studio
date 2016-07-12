Public Class dlgInsertSymbol

    Private editor As XEditor

#Region "Methods"

    Private Sub InsertSelectedSymbol()
        If ListBox1.SelectedIndex <> -1 Then
            editor.Scintilla1.InsertText(editor.Scintilla1.CurrentPosition, ListBox1.SelectedItem)
            Me.Close()
        End If
    End Sub

#End Region

#Region "ListBox1"

    Private Sub ListBox1_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            InsertSelectedSymbol()
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        InsertSelectedSymbol()
    End Sub


#End Region

#Region "dlgInsertSymbol"

    Public Sub New(ByRef ed As XEditor)
        InitializeComponent()
        editor = ed
    End Sub

    Private Sub dlgInsertSymbol_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        editor.insertsymboldlgshowing = False
    End Sub

    Private Sub dlgInsertSymbol_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormPosition.CenterForm(Me, editor.ParentForm)
        Catch
        End Try
    End Sub

#End Region

End Class