Imports System.IO

Friend Class frmMoveFile



#Region "Browse"

    Private Sub btnFromBrowse_Click(sender As Object, e As EventArgs) Handles btnFromBrowse.Click
        Dim newb As New OpenFileDialog
        newb.Title = "Select File to Move"
        newb.InitialDirectory = My.Settings.temp_projlocation & "\Files"
        newb.Filter = "All Files (*.*)|*.*|Plain Text File (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf|Action Script File (*.as)|*.as|Ada file (*.ada)|*.ada|Assembly Language File (*.asm)|*.asm|ASP Script (*.asp)|*.asp|Unix Script (*.sh)|*.sh|Batch File (*.bat)|*.bat|C File (*.c)|*.c|COBOL File (*.cbl)|*.cbl|C++ File (*.cpp)|*.cpp|C# File (*.cs)|*.cs|CSS File (*.css)|*.css|D File (*.d)|*.d|Fortran File (*.f)|*.f|HTML File (*.html)|*.html|Java File (*.java)|*.java|JavaScript File (*.js)|*.js|LISP File (*.lsp)|*.lsp|Lua File (*.lua)|*.lua|NFO File (*.nfo)|*.nfo|Pascal File (*.pas)|*.pas|Perl File (*.pl)|*.pl|PHP File (*.php)|*.php|Postscript File (*.ps)|*.ps|Python File (*.py)|*.py|R File (*.r)|*.r|Ruby File (*.rb)|*.rb|SmallTalk File (*.st)|*.st|SQL/PostgreSQL File (*.sql)|*.sql|Visual Basic File (*.vb)|*.vb|Visual Basic Script (*.vbs)|*.vbs|XML File (*.xml)|*.xml|YAML File (*.yaml)|*.yaml|XDev Language File (*.xdlf)|*.xdlf"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFrom.Text = newb.FileName
        End If
    End Sub

    Private Sub btnToBrowse_Click(sender As Object, e As EventArgs) Handles btnToBrowse.Click
        Dim newb As New FolderBrowserDialog
        newb.SelectedPath = My.Settings.temp_projlocation & "\Files"
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtTo.Text = newb.SelectedPath
        End If
    End Sub

#End Region

#Region "Methods"

    Private Function CheckIfFieldsValid() As Boolean
        If txtFrom.Text = "" Or txtTo.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Shared Sub CopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
                System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
                If frmManager.CheckIfEditorIsOpenByFileLocation(fileSystemInfo.FullName) Then
                    CType(frmManager.GetEditorByFileLocation(fileSystemInfo.FullName), Tab_CodeEditor).SetFileLocation(destinationFileName)
                End If
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

    Public Shared Function GetFilesRecursive(ByVal initial As String) As List(Of String)
        ' This list stores the results.
        Dim result As New List(Of String)

        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(initial)

        ' Continue processing for each stacked directory
        Do While (stack.Count > 0)
            ' Get top directory string
            Dim dir As String = stack.Pop
            Try
                ' Add all immediate file paths
                result.AddRange(Directory.GetFiles(dir, "*.*"))

                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
            End Try
        Loop

        ' Return the list
        Return result
    End Function

#End Region

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Sub New(ByVal fromfile As String, ByVal toloc As String)
        InitializeComponent()
        txtFrom.Text = fromfile
        txtTo.Text = toloc
    End Sub

    Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click
        If CheckIfFieldsValid() Then
            Try
                Dim isDir As Boolean = (File.GetAttributes(txtFrom.Text) And FileAttributes.Directory) = FileAttributes.Directory
                If isDir Then
                    Dim xResult = txtFrom.Text.Substring(txtFrom.Text.LastIndexOf("\"))
                    CopyDirectory(txtFrom.Text, txtTo.Text & "\" & xResult)
                    System.IO.Directory.Delete(txtFrom.Text, True)
                    Logger.Write(Logger.TypeOfLog.Studio, "Moving directory " & Path.GetFileName(txtFrom.Text) & " to '" & txtTo.Text & "'")
                Else
                    System.IO.File.Copy(txtFrom.Text, txtTo.Text & "\" & Path.GetFileName(txtFrom.Text))
                    System.IO.File.Delete(txtFrom.Text)
                    Logger.Write(Logger.TypeOfLog.Studio, "Moving file " & Path.GetFileName(txtFrom.Text) & " to '" & txtTo.Text & "'")
                    If frmManager.CheckIfEditorIsOpenByFileLocation(txtFrom.Text) Then
                        CType(frmManager.GetEditorByFileLocation(txtFrom.Text), Tab_CodeEditor).SetFileLocation(txtTo.Text & "\" & Path.GetFileName(txtFrom.Text))
                    End If
                End If
                pnlProjectExplorer.RefreshProjectExplorer()
                Me.Close()
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                MetroFramework.MetroMessageBox.Show(frmManager, "There was an error attempting to move the file or directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Please make sure you properly fill out the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class