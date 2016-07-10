Friend Class Tab_Notepad

    Dim fileloc As String
    'Dim filename As String = "Untitled"
    Dim saved As Boolean = False
    Dim originaltext As String

#Region "Methods"

    Public Sub InsertText(ByVal txt As String)
        Dim insertPos As Integer = TextBox1.SelectionStart
        'TextBox1.SelectionLength = 0
        TextBox1.Text = TextBox1.Text.Insert(insertPos, txt)
        TextBox1.SelectionStart = insertPos + txt.Length
    End Sub

    Public Sub SetOriginalText(ByVal txt As String)
        originaltext = txt
    End Sub

    Public Function GetOriginalText() As String
        Return originaltext
    End Function

    Public Sub UpdateTitle(ByVal title As String)
        Me.Text = title
    End Sub

    Public Function GetSaved() As Boolean
        Return saved
    End Function

    Public Sub SetSaved(ByVal save As Boolean)
        saved = save
        If GetFileLocation() = "" Then
            If save = False Then
                UpdateTitle("Untitled*")
            Else
                UpdateTitle("Untitled")
            End If
        Else
            If save = False Then
                UpdateTitle(System.IO.Path.GetFileName(GetFileLocation) & "*")
            Else
                UpdateTitle(System.IO.Path.GetFileName(GetFileLocation))
            End If
        End If
    End Sub

    Public Function GetFileName() As String
        Return System.IO.Path.GetFileName(fileloc)
    End Function

    Public Function GetFileLocation() As String
        Return fileloc
    End Function

    Public Sub SetFileLocation(ByVal loc As String)
        fileloc = loc
        Me.DockHandler.ToolTipText = loc
    End Sub

#End Region

#Region "Textbox"

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> originaltext Then
            SetSaved(False)
        Else
            SetSaved(True)
        End If
    End Sub

    Private Sub TextBox1_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            frmDragContent.Show()
        End If
    End Sub

    Private Sub TextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TextBox1.LinkClicked
        If My.Settings.set_notepad_linksecuritynotification Then
            If MetroFramework.MetroMessageBox.Show(frmManager, "Caution: Some links may lead to harmful content. Proceed to navigate to link location?", "Link Security Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Tabs.AddWebBrowser(e.LinkText)
            End If
        Else
            Tabs.AddWebBrowser(e.LinkText)
        End If
    End Sub
    
#End Region

#Region "ContextMenuStrip"

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        TextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        TextBox1.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        TextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        TextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        TextBox1.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        TextBox1.SelectAll()
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearAllToolStripMenuItem.Click
        TextBox1.Clear()
    End Sub

#End Region

#Region "Tab_Notepad"

    Private Sub Tab_Notepad_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.Text.EndsWith("*") And e.CloseReason <> CloseReason.MdiFormClosing Then
            If MetroFramework.MetroMessageBox.Show(frmManager, "You have unsaved changes. Are you sure you want to close this document without saving?", "Notepad - Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Tab_Notepad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UpdateTitle(filename)
        TextBox1.AllowDrop = True
        'Fix bug where framework automatically sets to true
        TextBox1.AutoWordSelection = False
    End Sub

#End Region
    
End Class