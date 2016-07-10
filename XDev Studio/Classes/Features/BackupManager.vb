Imports System.IO

Friend Class BackupManager

#Region "Backup"

    'Creates a backup of the specified project
    Public Shared Sub BackupProject(ByVal projloc As String)
        If frmManager.GetPType = frmManager.ProjType.Project Then
            If My.Settings.set_backupsloc = "DEFAULT" Then
                Dim dir As String = XDev.Path.Locator.GetWorkspacePath + "\Backups\" & ProjectReader.GetProjectName & "\" & DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")
                System.IO.Directory.CreateDirectory(dir)
                CopyDirectory(projloc, dir)
                Logger.Write(Logger.TypeOfLog.Studio, "Backup++: Created backup of project " & ProjectReader.GetProjectName & " to " & dir)
            Else
                Dim dir As String = My.Settings.set_backupsloc & "\" & ProjectReader.GetProjectName & "\" & DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")
                System.IO.Directory.CreateDirectory(dir)
                CopyDirectory(projloc, dir)
                Logger.Write(Logger.TypeOfLog.Studio, "Backup++: Created backup of project " & ProjectReader.GetProjectName & " to " & dir)
            End If
        End If
    End Sub

    'Creates a backup of the specified file
    Public Shared Sub BackupFile(ByVal fileloc As String)
        If My.Settings.set_encryptbackup Then
            If My.Settings.set_backupsloc = "DEFAULT" Then
                Dim dir As String = XDev.Path.Locator.GetWorkspacePath + "\Backups\" & Path.GetFileName(fileloc) & "\" & DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")
                System.IO.Directory.CreateDirectory(dir)
                System.IO.File.Copy(fileloc, dir + "\" + Path.GetFileName(fileloc))
                Logger.Write(Logger.TypeOfLog.Studio, "Backup++: Created backup of document " & Path.GetFileName(fileloc) & " to " & dir)
                EncryptManager.EncryptDocument(dir)
            Else
                Dim dir As String = My.Settings.set_backupsloc & "\" & Path.GetFileName(fileloc) & "\" & DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")
                System.IO.Directory.CreateDirectory(dir)
                System.IO.File.Copy(fileloc, dir + "\" + Path.GetFileName(fileloc))
                Logger.Write(Logger.TypeOfLog.Studio, "Backup++: Created backup of document " & Path.GetFileName(fileloc) & " to " & dir)
                EncryptManager.EncryptDocument(dir)
            End If
        Else
            If My.Settings.set_backupsloc = "DEFAULT" Then
                Dim dir As String = XDev.Path.Locator.GetWorkspacePath + "\Backups\" & Path.GetFileName(fileloc) & "\" & DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")
                System.IO.Directory.CreateDirectory(dir)
                System.IO.File.Copy(fileloc, dir + "\" + Path.GetFileName(fileloc))
                Logger.Write(Logger.TypeOfLog.Studio, "Backup++: Created backup of document " & Path.GetFileName(fileloc) & " to " & dir)
            Else
                Dim dir As String = My.Settings.set_backupsloc & "\" & Path.GetFileName(fileloc) & "\" & DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")
                System.IO.Directory.CreateDirectory(dir)
                System.IO.File.Copy(fileloc, dir + "\" + Path.GetFileName(fileloc))
                Logger.Write(Logger.TypeOfLog.Studio, "Backup++: Created backup of document " & Path.GetFileName(fileloc) & " to " & dir)
            End If
        End If
    End Sub

#End Region

    '--------------------------Currently broken-----------------------------
#Region "Restore"

    Public Shared Sub RestoreProject(ByVal projloc As String)
        Dim newb As New OpenFileDialog
        newb.Filter = "XDev Studio Project Files (*.xdpf)|*.xdpf"
        If My.Settings.set_backupsloc = "DEFAULT" Then
            newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath + "\Backups"
        Else
            newb.InitialDirectory = My.Settings.set_backupsloc
        End If
        newb.Title = "Choose project backup to restore from"
        If newb.ShowDialog = DialogResult.Yes Then
            If newb.FileName.Contains(".xdpf") Then
                frmManager.CloseProject()
                System.IO.Directory.Delete(My.Settings.temp_projlocation, True)
                CopyDirectory(Path.GetDirectoryName(newb.FileName), projloc)
                frmManager.LoadProject(projloc)
            Else
                MetroFramework.MetroMessageBox.Show(frmManager, "Invalid Project Selected", "Backup++", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Public Shared Sub RestoreFile(ByVal fileloc As String)
        Dim newb As New OpenFileDialog
        If My.Settings.set_backupsloc = "DEFAULT" Then
            newb.InitialDirectory = XDev.Path.Locator.GetWorkspacePath + "\Backups"
        Else
            newb.InitialDirectory = My.Settings.set_backupsloc
        End If
        newb.Title = "Choose backup to restore from"
        If newb.ShowDialog = DialogResult.Yes Then
            If frmManager.IsCodeEditor() Then
                File.Delete(fileloc)
                File.Copy(newb.FileName, fileloc)
                CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_CodeEditor).GetCurrentEditor().Text = My.Computer.FileSystem.ReadAllText(fileloc)
                MetroFramework.MetroMessageBox.Show(frmManager, "Restored Document " & Path.GetFileName(fileloc), "Backup++", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf frmManager.IsNotepad() Then
                File.Delete(fileloc)
                File.Copy(newb.FileName, fileloc)
                CType(frmManager.DockPanel1.ActiveDocumentPane.ActiveContent, Tab_Notepad).TextBox1.Text = My.Computer.FileSystem.ReadAllText(fileloc)
                MetroFramework.MetroMessageBox.Show(frmManager, "Restored Document " & Path.GetFileName(fileloc), "Backup++", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

#End Region
    '-----------------------------------------------------------------

    'Copies a specified directory to a new location
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
                If My.Settings.set_encryptbackup Then
                    System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
                    EncryptManager.EncryptDocument(destinationFileName)
                Else
                    System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
                End If
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub

End Class
