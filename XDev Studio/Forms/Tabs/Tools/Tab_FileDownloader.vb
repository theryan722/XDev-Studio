Imports System.Net
Imports System.IO
Imports System.Threading

Friend Class Tab_FileDownloader
    Dim wClient As WebClient
    Dim downloadloc As String
    Public Function CheckURL(ByVal HostAddress As String) As Boolean
        CheckURL = False

        Dim url As New System.Uri(HostAddress)
        Dim wRequest As System.Net.WebRequest
        wRequest = System.Net.WebRequest.Create(url)
        Dim wResponse As System.Net.WebResponse
        Try
            wResponse = wRequest.GetResponse()
            'Is the responding address the same as HostAddress to avoid false positive from an automatic redirect.
            If wResponse.ResponseUri.AbsoluteUri().ToString = HostAddress Then 'include query strings
                CheckURL = True
            End If
            wResponse.Close()
            wRequest = Nothing
        Catch ex As Exception
            wRequest = Nothing
            MsgBox(ex.ToString)
        End Try

        Return CheckURL
    End Function

    Public Sub DownloadFile(ByVal url As String, ByVal downloc As String)
        downloadloc = downloc
        ThreadPool.QueueUserWorkItem(AddressOf T_DownloadFile, url)
    End Sub

    Private Sub T_DownloadFile(ByVal url As String)
        Logger.Write(Logger.TypeOfLog.Studio, "Downloading file '" & url & "' to " & downloadloc)
        Dim b As String = downloadloc
        If b.EndsWith("\") Then
        Else
            b += "\"
        End If
        txt_filetodownload.Text = url
        txt_downloadlocation.Text = downloadloc
        txt_filetodownload.Enabled = False
        txt_downloadlocation.Enabled = False
        btn_downloadfile.Enabled = False
        btn_browse.Enabled = False
        btn_cancel.Enabled = True
        Try
            wClient = New WebClient
            AddHandler wClient.DownloadProgressChanged, AddressOf ProgressChanged
            AddHandler wClient.DownloadFileCompleted, AddressOf DownloadCompleted
            wClient.DownloadFileAsync(New Uri(url), b + Path.GetFileName(url))
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmManager, "There was an error attempting to download the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub Tab_FileDownloader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.set_defaultdownloadlocation = "DEFAULT" Then
            txt_downloadlocation.Text = XDev.Path.Locator.GetWorkspacePath + "\Downloads\"
        Else
            txt_downloadlocation.Text = My.Settings.set_defaultdownloadlocation
        End If
    End Sub

    Private Sub btn_downloadfile_Click(sender As Object, e As EventArgs) Handles btn_downloadfile.Click
        If CheckURL(txt_filetodownload.Text) = True Then
            downloadloc = txt_downloadlocation.Text
            ThreadPool.QueueUserWorkItem(AddressOf T_DownloadFile, txt_filetodownload.Text) 'DownloadFile(txt_filetodownload.Text, txt_downloadlocation.Text)
        Else
            If MetroFramework.MetroMessageBox.Show(frmManager, "The URL entered does not appear to be valid. Try downloading anyways?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then
                downloadloc = txt_downloadlocation.Text
                ThreadPool.QueueUserWorkItem(AddressOf T_DownloadFile, txt_filetodownload.Text)
            End If
        End If
    End Sub

    Private Sub ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        lblInfo.Text = String.Format("Downloaded {0} bytes from {1} bytes", e.BytesReceived, e.TotalBytesToReceive)
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub DownloadCompleted(ByVal sender As Object, ByVal e As EventArgs)
        RemoveHandler wClient.DownloadProgressChanged, AddressOf ProgressChanged
        RemoveHandler wClient.DownloadFileCompleted, AddressOf DownloadCompleted
        ProgressBar1.Value = 0
        lblInfo.Text = "[]"
        txt_filetodownload.Enabled = True
        txt_downloadlocation.Enabled = True
        btn_downloadfile.Enabled = True
        btn_browse.Enabled = True
        btn_cancel.Enabled = False
        If MetroFramework.MetroMessageBox.Show(frmManager, "Completed file download! Open download location?", "Download Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            btn_opendownloadlocation.PerformClick()
        End If
    End Sub

    Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        Dim newb As New FolderBrowserDialog
        newb.ShowNewFolderButton = True
        If My.Settings.set_defaultdownloadlocation = "DEFAULT" Then
            newb.RootFolder = XDev.Path.Locator.GetWorkspacePath + "\Downloads\"
        Else
            newb.RootFolder = My.Settings.set_defaultdownloadlocation
        End If
        If newb.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_downloadlocation.Text = newb.SelectedPath
        End If
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Try
            wClient.CancelAsync()
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmManager, "There was an error attempting to cancel the download.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

    Private Sub btn_opendownloadlocation_Click(sender As Object, e As EventArgs) Handles btn_opendownloadlocation.Click
        Try
            System.Diagnostics.Process.Start("Explorer.exe", txt_downloadlocation.Text)
        Catch ex As Exception
            MetroFramework.MetroMessageBox.Show(frmManager, "There was an error attempting to open the download folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub
End Class