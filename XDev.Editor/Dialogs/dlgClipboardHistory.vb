Public Class dlgClipboardHistory

    Private editor As XEditor

#Region "Methods"

    'Clear the listbox and fill it with the clipboard history
    Private Sub RefreshList()
        ListBox1.Items.Clear()
        If editor.ClipboardHistory.Count > 0 Then
            For Each item As String In editor.ClipboardHistory
                If item.Length > 35 Then
                    ListBox1.Items.Add(item.Substring(0, 34))
                Else
                    ListBox1.Items.Add(item)
                End If
            Next
        End If
    End Sub

    'Inserts the selected item from the listbox into the editor
    Private Sub InsertSelectedItem()
        If ListBox1.SelectedIndex <> -1 AndAlso editor.ClipboardHistory.Count > 0 Then
            editor.InsertText(editor.ClipboardHistory(ListBox1.SelectedIndex))
            If TrueToolStripMenuItem.Checked Then
                Me.Close()
            End If
        End If
    End Sub

    'Displays the selected item from the listbox in the preview box below it
    Private Sub PreviewSelectedItem()
        If ListBox1.SelectedIndex <> -1 AndAlso editor.ClipboardHistory.Count > 0 Then
            TextBox1.Text = editor.ClipboardHistory(ListBox1.SelectedIndex)
            ContextMenuStrip_Textbox.Enabled = True
        Else
            TextBox1.Clear()
            ContextMenuStrip_Textbox.Enabled = False
        End If
    End Sub

    Private Sub CopySelectedItem()
        If ListBox1.SelectedIndex <> -1 AndAlso editor.ClipboardHistory.Count > 0 Then
            My.Computer.Clipboard.SetText(editor.ClipboardHistory(ListBox1.SelectedIndex))
            If TrueToolStripMenuItem.Checked Then
                Me.Close()
            End If
        End If
    End Sub
    
    Private Sub ClearHistory()
        editor.ClearClipboardHistory()
        RefreshList()
    End Sub

#End Region
    
#Region "ContextMenuStrips"

#Region "Listbox"

    Private Sub InsertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertToolStripMenuItem.Click
        InsertSelectedItem()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        CopySelectedItem()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub

    Private Sub ClearHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearHistoryToolStripMenuItem.Click
        ClearHistory()
    End Sub

#End Region

#Region "Textbox"

    Private Sub InsertToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InsertToolStripMenuItem1.Click
        If TextBox1.Text <> "" Then
            editor.InsertText(TextBox1.Text)
            If TrueToolStripMenuItem.Checked Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem1.Click
        If TextBox1.Text <> "" Then
            My.Computer.Clipboard.SetText(TextBox1.Text)
            If TrueToolStripMenuItem.Checked Then
                Me.Close()
            End If
        End If
    End Sub

#End Region

#End Region
    
#Region "dlgClipBoardHistory"

    Public Sub New(ByRef ed As XEditor)
        InitializeComponent()
        editor = ed
    End Sub

    Private Sub dlgClipboardHistory_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        editor.clipboardhistorydlgshowing = False
    End Sub

    Private Sub dlgClipboardHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormPosition.CenterForm(Me, editor.ParentForm)
        Catch
        End Try
        RefreshList()
    End Sub

#End Region

#Region "StatusStrip"

    Private Sub TrueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrueToolStripMenuItem.Click
        TrueToolStripMenuItem.Checked = True
        FalseToolStripMenuItem.Checked = False
    End Sub

    Private Sub FalseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FalseToolStripMenuItem.Click
        TrueToolStripMenuItem.Checked = False
        FalseToolStripMenuItem.Checked = True
    End Sub

#End Region

#Region "Listbox"

    Private Sub ListBox1_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            InsertSelectedItem()
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        InsertSelectedItem()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        PreviewSelectedItem()
    End Sub

#End Region
    
End Class