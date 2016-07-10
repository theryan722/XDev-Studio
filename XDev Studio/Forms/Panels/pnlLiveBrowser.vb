Friend Class pnlLiveBrowser
    Private Shared _liveeditor As New XDockContent


#Region "Methods"

    Public Sub SetEditor(ByRef editor As XDockContent)
        _liveeditor = editor
        If CType(_liveeditor, Tab_CodeEditor).GetFileName <> "" Then
            Me.Text = "Live Browser - " & CType(_liveeditor, Tab_CodeEditor).GetFileName
        Else
            Me.Text = "Live Browser - Untitled"
        End If
        UpdateHTML()
    End Sub

    Public Sub UpdateHTML()
        WebBrowser1.Document.OpenNew(False)
        WebBrowser1.Document.Write(CType(_liveeditor, Tab_CodeEditor).TextBox1.Text)
        'CType(_liveeditor, Tab_CodeEditor).GetCurrentEditor.Focus()
    End Sub

    Public Function GetEditor() As XDockContent
        Return _liveeditor
    End Function

    Public Sub ClearEditor()
        _liveeditor = Nothing
        Me.Text = "Live Browser"
    End Sub

#End Region

#Region "Context Menu Strip"

    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        If WebBrowser1.CanGoBack() Then
            WebBrowser1.GoBack()
        End If
    End Sub

    Private Sub ForwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForwardToolStripMenuItem.Click
        If WebBrowser1.CanGoForward() Then
            WebBrowser1.GoForward()
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        WebBrowser1.Refresh()
    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click
        WebBrowser1.Stop()
    End Sub

    Private Sub SuppressScriptErrorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppressScriptErrorsToolStripMenuItem.Click
        If WebBrowser1.ScriptErrorsSuppressed Then
            WebBrowser1.ScriptErrorsSuppressed = False
            SuppressScriptErrorsToolStripMenuItem.Checked = False
        Else
            WebBrowser1.ScriptErrorsSuppressed = True
            SuppressScriptErrorsToolStripMenuItem.Checked = True
        End If
    End Sub

#End Region

#Region "pnlLiveBrowser"

    Private Sub pnlLiveBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("about:blank")
    End Sub

    Private Sub pnlLiveBrowser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmManager.livebrowser = Nothing
    End Sub

#End Region

End Class