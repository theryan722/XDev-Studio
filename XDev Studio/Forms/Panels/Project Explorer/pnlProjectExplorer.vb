Imports System.Runtime.InteropServices
Imports System.IO
Imports MetroFramework

Friend Class pnlProjectExplorer

#Region "Variables"

    Private Structure SHFILEINFO
        Public hIcon As IntPtr            ' : icon
        Public iIcon As Integer           ' : icondex
        Public dwAttributes As Integer    ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public szTypeName As String
    End Structure

    Private Declare Auto Function SHGetFileInfo Lib "shell32.dll" _
            (ByVal pszPath As String, _
             ByVal dwFileAttributes As Integer, _
             ByRef psfi As SHFILEINFO, _
             ByVal cbFileInfo As Integer, _
             ByVal uFlags As Integer) As IntPtr

    Private Const SHGFI_ICON = &H100
    Private Const SHGFI_SMALLICON = &H1
    Private Const SHGFI_LARGEICON = &H0    ' Large icon
    Private Const MAX_PATH = 260

#End Region

#Region "Methods"

    Public Sub ClearTreeView()
        TreeView1.Nodes.Clear()
    End Sub

    Public Sub RefreshProjectExplorer()
        Dim b As TreeNode = TreeView1.SelectedNode
        LoadProject(My.Settings.temp_projlocation)
        TreeView1.SelectedNode = TreeView1.Nodes.Find(b.Name, True)(0)
        TreeView1.SelectedNode.Expand()
    End Sub

    Private Sub GotoSelection()
        If TreeView1.SelectedNode IsNot Nothing Then
            If Path.GetExtension(TreeView1.SelectedNode.Tag) <> "" Then
                If frmManager.GetEditorByFileLocation(TreeView1.SelectedNode.Tag) IsNot Nothing Then
                    Dim b As DialogResult = MetroMessageBox.Show(frmManager, "It appears this document is already open in the studio. Select [Yes] to switch to the document, or select [No] to open the document in a new tab.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    If b = Windows.Forms.DialogResult.Yes Then
                        frmManager.GetEditorByFileLocation(TreeView1.SelectedNode.Tag).Activate()
                    ElseIf b = Windows.Forms.DialogResult.No Then
                        Tabs.AddCode(TreeView1.SelectedNode.Tag)
                        RecentFilesManager.AddFile(TreeView1.SelectedNode.Tag)
                    End If
                Else
                    Tabs.AddCode(TreeView1.SelectedNode.Tag)
                    RecentFilesManager.AddFile(TreeView1.SelectedNode.Tag)
                End If
            End If
        End If


    End Sub

    Public Sub LoadProject(ByVal projloc As String)
        ClearTreeView()
        TreeView1.Sort()
        Dim Tnode As TreeNode = TreeView1.Nodes.Add("Project '" & ProjectReader.GetProjectName & "'")
        AddAllFolders(Tnode, My.Settings.temp_projlocation)
    End Sub

    Private Sub AddImages(ByVal strFileName As String)

        Dim shInfo As SHFILEINFO
        shInfo = New SHFILEINFO()
        shInfo.szDisplayName = New String(vbNullChar, MAX_PATH)
        shInfo.szTypeName = New String(vbNullChar, 80)
        Dim hIcon As IntPtr
        hIcon = SHGetFileInfo(strFileName, 0, shInfo, Marshal.SizeOf(shInfo), SHGFI_ICON Or SHGFI_SMALLICON)
        Dim MyIcon As System.Drawing.Bitmap
        MyIcon = System.Drawing.Icon.FromHandle(shInfo.hIcon).ToBitmap
        ImageList1.Images.Add(strFileName.ToString(), MyIcon)

    End Sub
    Private Sub AddAllFolders(ByVal TNode As TreeNode, ByVal FolderPath As String)
        Try
            For Each FolderNode As String In Directory.GetDirectories(FolderPath)
                Dim SubFolderNode As TreeNode = TNode.Nodes.Add(FolderNode.Substring(FolderNode.LastIndexOf("\"c) + 1))

                SubFolderNode.Tag = FolderNode
                SubFolderNode.Nodes.Add("Loading...")

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#End Region

#Region "Context Menu"

    Private Sub MoveSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveSelectedToolStripMenuItem.Click
        Dim b As String = TreeView1.SelectedNode.Tag
        Dim newb As New frmMoveFile(b, My.Settings.temp_projlocation & "\Files")
        newb.ShowDialog()
    End Sub

    Private Sub CopyFileLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyFileLocationToolStripMenuItem.Click
        If TreeView1.SelectedNode IsNot Nothing Then
            My.Computer.Clipboard.SetText(TreeView1.SelectedNode.Tag)
        End If
    End Sub

    Private Sub OpenFileLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenFileLocationToolStripMenuItem.Click
        If TreeView1.SelectedNode IsNot Nothing Then
            If Path.GetExtension(TreeView1.SelectedNode.Tag) = "" Then
                System.Diagnostics.Process.Start("Explorer.exe", TreeView1.SelectedNode.Tag)
            Else
                System.Diagnostics.Process.Start("Explorer.exe", Path.GetDirectoryName(TreeView1.SelectedNode.Tag))
            End If
        End If
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If TreeView1.SelectedNode IsNot Nothing Then
            If Path.GetExtension(TreeView1.SelectedNode.Tag) <> "" Then
                Dim newb As New frmPreview(My.Computer.FileSystem.ReadAllText(TreeView1.SelectedNode.Tag), LanguageEnum.ConvertExtensionToEnum(Path.GetExtension(TreeView1.SelectedNode.Tag)))
                newb.Show()
                Me.Cursor = New Cursor(Cursor.Current.Handle)
                Dim b As New Point(Cursor.Position.X, Cursor.Position.Y)
                newb.Location = b
                newb.Focus()
            End If
        End If
    End Sub

    Private Sub DeleteSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedToolStripMenuItem.Click
        Dim b As String = TreeView1.SelectedNode.Tag
        If TreeView1.SelectedNode IsNot Nothing Then
            If Path.GetExtension(b) = "" Then
                If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to delete the folder '" & b & "' ? This will delete the folder and all of its contents.", "Delete Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Try
                        System.IO.Directory.Delete(b, True)
                        RefreshProjectExplorer()
                    Catch ex As Exception
                        Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                    End Try
                End If
            Else
                If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to delete the file '" & b & "' ?", "Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Try
                        System.IO.File.Delete(b)
                        ProjectWriter.RemoveFile(Path.GetFileName(b))
                        RefreshProjectExplorer()
                    Catch ex As Exception
                        Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshProjectExplorer()
    End Sub

    Private Sub OpenSelectedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSelectedToolStripMenuItem.Click
        GotoSelection()
    End Sub

    Private Sub NewFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFolderToolStripMenuItem.Click
        Dim b As String = InputBox("Enter name of new folder:", "New Folder", GetDefaultFolderResponse())
        If b <> GetDefaultFolderResponse() Then
            Try
                System.IO.Directory.CreateDirectory(My.Settings.temp_projlocation & b)
                RefreshProjectExplorer()
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroFramework.MetroMessageBox.Show(frmManager, "There was an error attempting to create the folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function GetDefaultFolderResponse() As String
        Dim c As String = ""
        Dim b As String = TreeView1.SelectedNode.Tag
        If Path.GetExtension(b) = "" Then
            c = b.Replace(My.Settings.temp_projlocation, "")
        Else
            c = b.Replace(My.Settings.temp_projlocation, "")
            c = c.Replace(Path.GetFileName(b), "")
        End If
        If c.EndsWith("\") = False Then
            c = c & "\"
        End If
        If c.StartsWith("\") = False Then
            c = "\" & c
        End If
        Return c
    End Function

    Private Sub NewFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFileToolStripMenuItem.Click
        Dim newb As New frmNewFile
        Dim b As String = TreeView1.SelectedNode.Tag.ToString
        If Path.GetExtension(b) = "" Then
            newb.txt_fileloc.Text = b.Replace(My.Settings.temp_projlocation, "")
        Else
            b = b.Replace(My.Settings.temp_projlocation, "")
            b = b.Replace(Path.GetFileName(b), "")
            newb.txt_fileloc.Text = b
        End If
        newb.ShowDialog()

    End Sub

#End Region

#Region "TreeView1"

    Private Sub LoadSubNodes(ByVal e As TreeNode)
        Dim FileExtension As String
        Dim DateMod As String
        If TreeView1.SelectedNode.Nodes.Count = 1 AndAlso TreeView1.SelectedNode.Nodes(0).Text = "Loading..." Then
            TreeView1.SelectedNode.Nodes.Clear()
            AddAllFolders(TreeView1.SelectedNode, CStr(TreeView1.SelectedNode.Tag))
        End If
        Dim folder As String = CStr(TreeView1.SelectedNode.Tag)
        If Not folder Is Nothing AndAlso IO.Directory.Exists(folder) Then
            Try
                For Each file As String In IO.Directory.GetFiles(folder)
                    FileExtension = IO.Path.GetExtension(file)
                    DateMod = IO.File.GetLastWriteTime(file).ToString()
                    AddImages(file)
                    Dim exists As Boolean = False
                    Dim b As New TreeNode
                    b.Tag = file
                    b.Text = Path.GetFileName(file)
                    b.ImageKey = file.ToString
                    For Each nod As TreeNode In e.Nodes
                        If nod.Text = b.Text Then
                            exists = True
                            Exit For
                        End If
                    Next
                    If exists = False Then
                        e.Nodes.Add(b)
                    End If
                Next
                e.Expand()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        LoadSubNodes(e.Node)
    End Sub

    Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        If e.Node.Nodes.Count = 1 AndAlso e.Node.Nodes(0).Text = "Loading..." Then
            e.Node.Nodes.Clear()
            AddAllFolders(e.Node, CStr(e.Node.Tag))
        End If
        TreeView1.SelectedNode = e.Node
    End Sub

    Private Sub TreeView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseDoubleClick
        GotoSelection()
    End Sub

#End Region

#Region "frmProjectExplorer"

    Private Sub frmProjectExplorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmManager.GetPType = frmManager.ProjType.Project Then
            LoadProject(My.Settings.temp_projlocation)
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Cannot display the Project Explorer! The studio is not in project mode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If
    End Sub

#End Region

End Class