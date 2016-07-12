Public Class dlgCodeTemplates
    Private editor As XEditor

#Region "Methods"

    'Clears the listbox and populates it with code templates
    Public Sub RefreshList()
        Dim arr() As String
        ListBox1.Items.Clear()
        For Each item As String In editor.codetemplatelist
            arr = item.Split("|")
            ListBox1.Items.Add(arr(0))
        Next
    End Sub

    'Replaces the delimeters in the template with the appropriate value
    Private Function ProcessTemplateText(ByVal txt As String) As String
        Dim finarg As String = txt
        finarg = finarg.Replace("$st$", editor.Scintilla1.SelectedText)
        finarg = finarg.Replace("$cd$", editor.Scintilla1.Text)
        finarg = finarg.Replace("$ct$", DateTime.Now.ToString)
        Return finarg
    End Function

    'Inserts the selected item into the editor
    Private Sub InsertSelected()
        If ListBox1.SelectedIndex <> -1 Then
            If editor.codetemplatelist.Count > 0 Then
                Dim arr() As String = editor.codetemplatelist.Item(ListBox1.SelectedIndex).Split("|")
                editor.Scintilla1.InsertText(editor.Scintilla1.CurrentPosition, ProcessTemplateText(arr(1)))
                Me.Close()
            End If
        End If
    End Sub

#End Region

#Region "ListBox"

    Private Sub ListBox1_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            InsertSelected()
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        InsertSelected()
    End Sub

#End Region

#Region "dlgCodeTemplates"

    Public Sub New(ByRef ed As XEditor)
        InitializeComponent()
        editor = ed
    End Sub

    'Set in the editor that the dialog is no longer being displayed
    Private Sub dlgCodeTemplates_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        editor.codetemplatesdlgshowing = False
    End Sub

    Private Sub dlgCodeTemplates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormPosition.CenterForm(Me, editor.ParentForm)
        Catch
        End Try
        RefreshList()
    End Sub

#End Region

#Region "ContextMenuStrip"

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub

#End Region

End Class