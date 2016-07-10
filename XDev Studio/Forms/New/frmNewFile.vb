Imports System.Xml

Friend Class frmNewFile

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

    Private Function GetTotalLocation(ByVal loc As String) As String
        If loc.StartsWith("\") = False Then
            loc = "\" & loc
        End If
        If loc.EndsWith("\") = False Then
            loc = loc & "\"
        End If

        Return My.Settings.temp_projlocation & loc
    End Function

    Private Sub btn_create_Click(sender As Object, e As EventArgs) Handles btn_create.Click
        If CheckIfFieldsValid() Then
            If CheckIfFileValid() Then
                If combo_filelang.SelectedItem = "CustomLanguage" Then
                    Try
                        ProjectWriter.AddFile(txt_filename.Text, LanguageEnum.ConvertReadableToEnum(combo_filelang.Text))
                        '--------------------
                        System.IO.File.Create(GetTotalLocation(txt_fileloc.Text) + txt_filename.Text).Dispose()
                        'ProjectWriter.AddFile(txt_filename.Text, combo_filelang.Text, My.Settings.temp_projlocation + txt_filename.Text + LanguageEnum.GetLanguageExtension(combo_filelang.Text))
                        '--------------------

                        '================================================================================================================
                        'Tabs.AddCodeWithFile("", LanguageEnum.ConvertReadableToEnum(combo_filelang.Text), My.Settings.temp_projlocation + "\Files\" + txt_filename.Text + LanguageEnum.ConvertEnumToExtension(LanguageEnum.ConvertReadableToEnum(combo_filelang.Text)))
                        Tabs.AddCode(My.Settings.temp_projlocation + "\Files\" + txt_filename.Text)
                        'frmManager.SetProjectType(frmManager.ProjType.Project)
                        pnlProjectExplorer.RefreshProjectExplorer()
                        Me.Close()
                    Catch ex As Exception
                        Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                    End Try
                Else
                    Try
                        ProjectWriter.AddFile(txt_filename.Text & LanguageEnum.ConvertEnumToExtension(LanguageEnum.ConvertReadableToEnum(combo_filelang.Text)), LanguageEnum.ConvertReadableToEnum(combo_filelang.Text))
                        '--------------------
                        System.IO.File.Create(GetTotalLocation(txt_fileloc.Text) + txt_filename.Text + LanguageEnum.ConvertEnumToExtension(LanguageEnum.ConvertReadableToEnum(combo_filelang.Text))).Dispose()
                        'ProjectWriter.AddFile(txt_filename.Text, combo_filelang.Text, My.Settings.temp_projlocation + txt_filename.Text + LanguageEnum.GetLanguageExtension(combo_filelang.Text))
                        '--------------------

                        '================================================================================================================
                        'Tabs.AddCodeWithFile("", LanguageEnum.ConvertReadableToEnum(combo_filelang.Text), My.Settings.temp_projlocation + "\Files\" + txt_filename.Text + LanguageEnum.ConvertEnumToExtension(LanguageEnum.ConvertReadableToEnum(combo_filelang.Text)))
                        Tabs.AddCode(My.Settings.temp_projlocation + "\Files\" + txt_filename.Text + LanguageEnum.ConvertEnumToExtension(LanguageEnum.ConvertReadableToEnum(combo_filelang.Text)))
                        'frmManager.SetProjectType(frmManager.ProjType.Project)
                        pnlProjectExplorer.RefreshProjectExplorer()
                        Me.Close()
                    Catch ex As Exception
                        Logger.WriteError(Logger.TypeOfLog.Studio, ex)
                    End Try
                End If

            Else
                MetroFramework.MetroMessageBox.Show(frmManager, "A file with that name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txt_filename.Text = ""
            End If
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Please make sure you properly fill out the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function CheckIfFileValid() As Boolean
        If System.IO.File.Exists(My.Settings.temp_projlocation + "\Files\" + txt_filename.Text + LanguageEnum.ConvertEnumToExtension(LanguageEnum.ConvertReadableToEnum(combo_filelang.Text))) Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CheckIfFieldsValid() As Boolean
        If txt_filename.Text = "" Or combo_filelang.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub frmNewFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            combo_filelang.SelectedItem = LanguageEnum.ConvertEnumToReadable(ProjectReader.GetProjectLanguage())
        Catch
        End Try
    End Sub
End Class