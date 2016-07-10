Friend Class EncryptManager

    'Encrypt the specified file
    Public Shared Sub EncryptDocument(ByVal fileloc As String)
        Try
            System.IO.File.Encrypt(fileloc)
            Logger.Write(Logger.TypeOfLog.Studio, "Encrypt++: Encrypted file '" & System.IO.Path.GetFileName(fileloc) & "'")
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    'Decrypt the specified file
    Public Shared Sub DecryptDocument(ByVal fileloc As String)
        Try
            System.IO.File.Decrypt(fileloc)
            Logger.Write(Logger.TypeOfLog.Studio, "Encrypt++: Decrypted file '" & System.IO.Path.GetFileName(fileloc) & "'")
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    'Encrypt the specified project
    Public Shared Sub EncryptProject(ByVal projloc As String)
        If frmManager.GetPType = frmManager.ProjType.Project Then
            Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(projloc)
            ' If the destination folder don't exist then create it
            Dim fileSystemInfo As System.IO.FileSystemInfo
            For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
                ' Now check whether its a file or a folder and take action accordingly
                If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                    EncryptDocument(fileSystemInfo.FullName)
                Else
                    ' Recursively call the mothod to copy all the neste folders
                    EncryptProject(fileSystemInfo.FullName)
                End If
            Next
            Logger.Write(Logger.TypeOfLog.Studio, "Encrypt++: Encrypted project " & ProjectReader.GetProjectName)
        End If

    End Sub

    'Decrypt the specified project
    Public Shared Sub DecryptProject(ByVal projloc As String)
        If frmManager.GetPType = frmManager.ProjType.Project Then
            Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(projloc)
            ' If the destination folder don't exist then create it
            Dim fileSystemInfo As System.IO.FileSystemInfo
            For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
                ' Now check whether its a file or a folder and take action accordingly
                If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                    DecryptDocument(fileSystemInfo.FullName)
                Else
                    ' Recursively call the mothod to copy all the neste folders
                    DecryptProject(fileSystemInfo.FullName)
                End If
            Next
            Logger.Write(Logger.TypeOfLog.Studio, "Encrypt++: Decrypted project " & ProjectReader.GetProjectName)
        End If

    End Sub

End Class
