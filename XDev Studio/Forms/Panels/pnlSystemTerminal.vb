Friend Class pnlSystemTerminal

    Private WithEvents MyProcess As Process
    Private Delegate Sub AppendOutputTextDelegate(ByVal text As String)

#Region "Methods"

    Private Sub RunCommand()
        If txt_command.Text <> "" Then
            MyProcess.StandardInput.WriteLine(txt_command.Text)
            MyProcess.StandardInput.Flush()
            txt_command.Text = ""
        End If
    End Sub

    Private Sub AppendOutputText(ByVal text As String)
        Try
            If txt_output.InvokeRequired Then
                Dim myDelegate As New AppendOutputTextDelegate(AddressOf AppendOutputText)
                Me.Invoke(myDelegate, text)
            Else
                txt_output.AppendText(text)
            End If
        Catch
        End Try
    End Sub

#End Region

#Region "Process Events"

    Private Sub MyProcess_ErrorDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles MyProcess.ErrorDataReceived
        AppendOutputText(vbCrLf & "Error: " & e.Data)
    End Sub

    Private Sub MyProcess_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles MyProcess.OutputDataReceived
        AppendOutputText(vbCrLf & e.Data)
    End Sub

#End Region

#Region "TextBoxes"

#Region "Command"

    Private Sub txt_command_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_command.KeyDown
        If e.KeyCode = Keys.Enter Then
            RunCommand()
        End If
    End Sub

#End Region

#Region "Output"

    Private Sub txt_output_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_output.KeyDown
        If e.Modifiers = Keys.Control Then
            Select Case e.KeyCode
                Case Keys.C
                Case Keys.X
                Case Keys.V
                    txt_command.Focus()
                Case Else
                    txt_command.Focus()
            End Select
        Else
            txt_command.Focus()
        End If
    End Sub

#End Region

#End Region

#Region "ContextMenuStrips"

#Region "Command"

    Private Sub InsertToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertToolStripMenuItem.Click
        txt_command.Text = My.Computer.Clipboard.GetText
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem1.Click
        My.Computer.Clipboard.SetText(txt_command.Text)
    End Sub

    Private Sub ClearRecentCommandsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearRecentCommandsToolStripMenuItem.Click
        txt_command.Items.Clear()
    End Sub

#End Region

#Region "Output"

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        txt_output.Copy()
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(txt_output.Text)
    End Sub

#End Region

#End Region

#Region "pnlSystemTerminal"

    Private Sub pnlSystemTerminal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MyProcess.StandardInput.WriteLine("EXIT") 'send an EXIT command to the Command Prompt
        MyProcess.StandardInput.Flush()
        MyProcess.Close()
        MyProcess.Dispose()
    End Sub

    Private Sub pnlSystemTerminal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyProcess = New Process
        With MyProcess.StartInfo
            .FileName = "CMD.EXE"
            .UseShellExecute = False
            .CreateNoWindow = True
            .RedirectStandardInput = True
            .RedirectStandardOutput = True
            .RedirectStandardError = True
        End With
        MyProcess.Start()
        MyProcess.BeginErrorReadLine()
        MyProcess.BeginOutputReadLine()
    End Sub

#End Region

End Class