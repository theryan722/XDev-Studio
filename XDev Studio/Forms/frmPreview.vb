Friend Class frmPreview
    
#Region "Methods"

    Private Sub SetText(ByVal txt As String, ByVal lang As XDev.Editor.Language.EditorLanguage)
        TextBox1.Language = lang
        TextBox1.IsReadOnly = False
        TextBox1.Text = txt
        TextBox1.IsReadOnly = True
    End Sub
    
#End Region

    Public Sub New(ByVal txt As String, ByVal lang As XDev.Editor.Language.EditorLanguage)
        InitializeComponent()
        SetText(txt, lang)
    End Sub

    Private Sub frmPreview_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
        frmManager.Focus()
    End Sub

    Private Sub frmPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmManager
    End Sub

    Private Sub ClosePreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClosePreviewToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class