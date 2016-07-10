

Public Class Tab_NetConverter

#Region "Context Menu Strip"

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        XEditor1.Copy()
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(XEditor1.Text)
    End Sub

    Private Sub OpenInEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInEditorToolStripMenuItem.Click
        Tabs.AddCodeWithoutFile(XEditor1.Text, XEditor1.Language)
    End Sub

#End Region

#Region "Menu Strip"

#Region "Convert"

#Region "VB to C#"

    Private Sub FromFileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromFileToolStripMenuItem1.Click
        Dim newb As New OpenFileDialog
        newb.Filter = "VB.Net File (*.vb)|*.vb|All Files (*.*)|*.*"
        If CurrentProfile.Name <> "" Then
            newb.InitialDirectory = CurrentProfile.Folder
        End If
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bb As String = My.Computer.FileSystem.ReadAllText(newb.FileName)
            XEditor1.Text = LanguageConverter.ConvertVBToCSharp(bb)
            XEditor1.Language = XDev.Editor.Language.EditorLanguage.Csharp
            MetroFramework.MetroMessageBox.Show(frmManager, "Converted VB.Net source to C#", ".Net Converter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FromClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromClipboardToolStripMenuItem.Click
        If My.Computer.Clipboard.GetText <> "" Then
            XEditor1.Text = LanguageConverter.ConvertVBToCSharp(My.Computer.Clipboard.GetText)
            XEditor1.Language = XDev.Editor.Language.EditorLanguage.Csharp
            MetroFramework.MetroMessageBox.Show(frmManager, "Converted VB.Net source to C#", ".Net Converter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#Region "C# to VB"

    Private Sub FromFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromFileToolStripMenuItem.Click
        Dim newb As New OpenFileDialog
        newb.Filter = "C# File (*.cs)|*.cs|All Files (*.*)|*.*"
        If CurrentProfile.Name <> "" Then
            newb.InitialDirectory = CurrentProfile.Folder
        End If
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bb As String = My.Computer.FileSystem.ReadAllText(newb.FileName)
            XEditor1.Text = LanguageConverter.ConvertCSharpToVB(bb)
            XEditor1.Language = XDev.Editor.Language.EditorLanguage.VB
            MetroFramework.MetroMessageBox.Show(frmManager, "Converted C# source to VB.Net", ".Net Converter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FromClipboardToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FromClipboardToolStripMenuItem1.Click
        If My.Computer.Clipboard.GetText <> "" Then
            XEditor1.Text = LanguageConverter.ConvertCSharpToVB(My.Computer.Clipboard.GetText)
            XEditor1.Language = XDev.Editor.Language.EditorLanguage.VB
            MetroFramework.MetroMessageBox.Show(frmManager, "Converted C# source to VB.Net", ".Net Converter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

#End Region

#End Region

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        XEditor1.Language = XDev.Editor.Language.EditorLanguage.PlainText
        XEditor1.ClearAll()
    End Sub

#End Region

#Region "Tab_NetConverter"

    Private Sub Tab_NetConverter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Tab_NetConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        XEditor1.SetSyntaxHighlightingArray(SyntaxHighlighting.GetHighlightArray)
    End Sub

#End Region

End Class