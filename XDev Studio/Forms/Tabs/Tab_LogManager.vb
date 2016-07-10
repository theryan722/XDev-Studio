Imports System.Threading

Friend Class Tab_LogManager
    Private Shared codeloc As String = XDev.Path.Locator.GetDataPath + "\Logs\log_code.txt"
    Private Shared studioloc As String = XDev.Path.Locator.GetDataPath + "\Logs\log_studio.txt"
    Private Shared pluginloc As String = XDev.Path.Locator.GetDataPath + "\Logs\log_plugin.txt"

    Private Sub Tab_LogManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshStudioLog()
        RefreshPluginLog()
        RefreshCodeLog()
    End Sub

#Region "Refresh"

#Region "Studio Log"

    Private Sub thread_refreshstudiolog()
        txt_studio.Clear()
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(studioloc)
            For Each i As String In lines
                txt_studio.Text = txt_studio.Text + vbNewLine
                txt_studio.Text = txt_studio.Text + vbNewLine
                txt_studio.Text = txt_studio.Text + i
            Next
        Catch
        End Try
    End Sub

    Private Sub RefreshStudioLog()
        ThreadPool.QueueUserWorkItem(AddressOf thread_refreshstudiolog)
    End Sub

#End Region

#Region "Plugin Log"

    Private Sub RefreshPluginLog()
        ThreadPool.QueueUserWorkItem(AddressOf thread_refreshpluginlog)
    End Sub

    Private Sub thread_refreshpluginlog()
        txt_plugin.Clear()
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(pluginloc)
            For Each i As String In lines
                txt_plugin.Text = txt_plugin.Text + vbNewLine
                txt_plugin.Text = txt_plugin.Text + vbNewLine
                txt_plugin.Text = txt_plugin.Text + i
            Next
        Catch
        End Try
    End Sub

#End Region

#Region "Code Log"

    Private Sub thread_refreshcodelog()
        txt_code.Clear()
        Try
            Dim lines() As String = System.IO.File.ReadAllLines(codeloc)
            For Each i As String In lines
                txt_code.Text = txt_code.Text + vbNewLine
                txt_code.Text = txt_code.Text + vbNewLine
                txt_code.Text = txt_code.Text + i
            Next
        Catch
        End Try
    End Sub

    Private Sub RefreshCodeLog()
        ThreadPool.QueueUserWorkItem(AddressOf thread_refreshcodelog)
    End Sub

#End Region

#End Region

#Region "Tabs"

#Region "Studio Log"
    Private Sub btn_clearstudio_Click(sender As Object, e As EventArgs) Handles btn_clearstudio.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to clear the Studio Log? This is irreversible.", "Clear Studio Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Logger.ClearLog(Logger.TypeOfLog.Studio)
            RefreshStudioLog()
        End If
    End Sub

    Private Sub btn_refreshstudio_Click(sender As Object, e As EventArgs) Handles btn_refreshstudio.Click
        RefreshStudioLog()
    End Sub

    Private Sub btn_copystudio_Click(sender As Object, e As EventArgs) Handles btn_copystudio.Click
        My.Computer.Clipboard.SetText(txt_studio.Text)
        MetroFramework.MetroMessageBox.Show(frmManager, "Studio Log copied to Clipboard!", "Studio Log", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#Region "Plugin Log"

    Private Sub btn_clearplugin_Click(sender As Object, e As EventArgs) Handles btn_clearplugin.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to clear the Plugin Log? This is irreversible.", "Clear Plugin Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Logger.ClearLog(Logger.TypeOfLog.Plugin)
            RefreshStudioLog()
        End If
    End Sub

    Private Sub btn_refreshplugin_Click(sender As Object, e As EventArgs) Handles btn_refreshplugin.Click
        RefreshPluginLog()
    End Sub

    Private Sub btn_copyplugin_Click(sender As Object, e As EventArgs) Handles btn_copyplugin.Click
        My.Computer.Clipboard.SetText(txt_plugin.Text)
        MetroFramework.MetroMessageBox.Show(frmManager, "Plugin Log copied to Clipboard!", "Plugin Log", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#Region "Code Log"
    Private Sub btn_clearcode_Click(sender As Object, e As EventArgs) Handles btn_clearcode.Click
        If MetroFramework.MetroMessageBox.Show(frmManager, "Are you sure you want to clear the Code Log? This is irreversible.", "Clear Code Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Logger.ClearLog(Logger.TypeOfLog.Code)
            RefreshCodeLog()
        End If
    End Sub

    Private Sub btn_refreshcode_Click(sender As Object, e As EventArgs) Handles btn_refreshcode.Click
        RefreshCodeLog()
    End Sub

    Private Sub btn_copycode_Click(sender As Object, e As EventArgs) Handles btn_copycode.Click
        My.Computer.Clipboard.SetText(txt_code.Text)
        MetroFramework.MetroMessageBox.Show(frmManager, "Plugin Log copied to Clipboard!", "Studio Log", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region

#End Region

End Class