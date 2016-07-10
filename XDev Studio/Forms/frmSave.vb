Imports WeifenLuo.WinFormsUI.Docking

Friend Class frmSave

    Dim _DocsToSave As DockContent()

    Public Property DocsToSave() As DockContent()
        Get
            Return _DocsToSave
        End Get
        Set(ByVal value As DockContent())
            _DocsToSave = value
        End Set
    End Property

    Public Sub New(ByVal docs() As DockContent)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lst.Columns.Add("Document")
        lst.Columns.Add("Path")
        lst.Columns(0).Width = lst.Width / 4
        lst.Columns(1).Width = lst.Width * 3 / 4

        For i As Integer = 0 To docs.GetUpperBound(0)
            If docs(i) IsNot Nothing Then
                If frmManager.IsCodeEditor(docs(i)) Then
                    Dim doc As DockContent = docs(i)
                    Dim lvi As New ListViewItem
                    If CType(doc, Tab_CodeEditor).GetFileName = "" Then
                        lvi.Text = "Untitled*"
                    Else
                        lvi.Text = CType(doc, Tab_CodeEditor).GetFileName
                    End If
                    lvi.SubItems.Add(CType(doc, Tab_CodeEditor).GetFileLocation)
                    lvi.Tag = doc
                    lvi.ImageIndex = 0
                    lvi.Checked = True
                    lst.Items.Add(lvi)
                ElseIf frmManager.IsNotepad(docs(i)) Then
                    Dim doc As DockContent = docs(i)
                    Dim lvi As New ListViewItem
                    If CType(doc, Tab_Notepad).GetFileName = "" Then
                        lvi.Text = "Untitled*"
                    Else
                        lvi.Text = CType(doc, Tab_Notepad).GetFileName
                    End If
                    lvi.SubItems.Add(CType(doc, Tab_Notepad).GetFileLocation)
                    lvi.Tag = doc
                    lvi.ImageIndex = 0
                    lvi.Checked = True
                    lst.Items.Add(lvi)
                End If
            End If
        Next

        Me.DialogResult = Windows.Forms.DialogResult.None
    End Sub

    Public Sub New(ByVal docs() As DockContent, ByVal msgtext As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        lblTop.Text = msgtext

        ' Add any initialization after the InitializeComponent() call.
        lst.Columns.Add("Document")
        lst.Columns.Add("Path")
        lst.Columns(0).Width = lst.Width / 4
        lst.Columns(1).Width = lst.Width * 3 / 4

        For i As Integer = 0 To docs.GetUpperBound(0)
            If docs(i) IsNot Nothing Then
                If frmManager.IsCodeEditor(docs(i)) Then
                    Dim doc As DockContent = docs(i)
                    Dim lvi As New ListViewItem
                    lvi.Text = CType(doc, Tab_CodeEditor).GetFileName
                    lvi.SubItems.Add(CType(doc, Tab_CodeEditor).GetFileLocation)
                    lvi.Tag = doc
                    lvi.ImageIndex = 0
                    lvi.Checked = True
                    lst.Items.Add(lvi)
                ElseIf frmManager.IsNotepad(docs(i)) Then
                    Dim doc As DockContent = docs(i)
                    Dim lvi As New ListViewItem
                    lvi.Text = CType(doc, Tab_Notepad).GetFileName
                    lvi.SubItems.Add(CType(doc, Tab_Notepad).GetFileLocation)
                    lvi.Tag = doc
                    lvi.ImageIndex = 0
                    lvi.Checked = True
                    lst.Items.Add(lvi)
                End If
            End If
        Next

        Me.DialogResult = Windows.Forms.DialogResult.None
    End Sub

    Private Sub frmSave_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Dim docs(0 To lst.CheckedItems.Count - 1) As DockContent
        For i As Integer = 0 To lst.CheckedItems.Count - 1
            docs(i) = lst.CheckedItems(i).Tag
        Next
        DocsToSave = docs
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lst_ItemChecked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lst.ItemChecked
        If lst.CheckedItems.Count = 0 Then
            btnYes.Enabled = False
        Else
            btnYes.Enabled = True
        End If
    End Sub
End Class