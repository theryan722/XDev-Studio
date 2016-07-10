Public Class Tab_FileHistory

#Region "Methods"

    Private Sub Search(ByVal txt As String)
        If txt = "" Then
            RefreshList()
        Else
            lbHistory.Items.Clear()
            For Each item In My.Settings.set_filehistory
                If item.Contains(txt) Then
                    lbHistory.Items.Add(item)
                End If
            Next
        End If
    End Sub

    Private Sub ClearHistory()
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to clear the file history?", "Clear History", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            My.Settings.set_filehistory.Clear()
            lbHistory.Items.Clear()
        End If
    End Sub

    Private Sub OpenInEditor()
        If lbHistory.SelectedIndex <> -1 Then
            Dim bb As String() = lbHistory.SelectedItem.ToString.Split("|")
            Tabs.AddCode(bb(1))
        End If
    End Sub

    Private Sub RemoveSelected()
        If lbHistory.SelectedIndex <> -1 Then
            My.Settings.set_filehistory.RemoveAt(lbHistory.SelectedIndex)
            lbHistory.Items.RemoveAt(lbHistory.SelectedIndex)
        End If
    End Sub

    Private Sub RefreshList()
        lbHistory.Items.Clear()
        For Each item As String In My.Settings.set_filehistory
            lbHistory.Items.Add(item)
        Next
    End Sub


#End Region

#Region "Top Panel"

    Private Sub btnRemoveSelected_Click(sender As Object, e As EventArgs) Handles btnRemoveSelected.Click
        RemoveSelected()
    End Sub

    Private Sub btnOpenInEditor_Click(sender As Object, e As EventArgs) Handles btnOpenInEditor.Click
        OpenInEditor()
    End Sub

    Private Sub btnClearHistory_Click(sender As Object, e As EventArgs) Handles btnClearHistory.Click
        ClearHistory()
    End Sub

#End Region

#Region "Context Menu Strip"

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        RemoveSelected()
    End Sub

    Private Sub OpenInEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInEditorToolStripMenuItem.Click
        OpenInEditor()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub

#End Region

#Region "lbHistory"

    Private Sub lbHistory_KeyDown(sender As Object, e As KeyEventArgs) Handles lbHistory.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenInEditor()
        ElseIf e.KeyCode = Keys.Delete Then
            RemoveSelected()
        End If
    End Sub

    Private Sub lbHistory_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbHistory.MouseDoubleClick
        OpenInEditor()
    End Sub

#End Region

#Region "Tab_FileHistory"

    Private Sub Tab_FileHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

#End Region
    
#Region "txtSearch"

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Search(txtSearch.Text)
    End Sub

#End Region
   
End Class