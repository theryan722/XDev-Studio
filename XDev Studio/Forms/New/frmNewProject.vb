Imports System.Xml
Imports System.IO

Friend Class frmNewProject

    Private Sub frmNewProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner = Nothing
    End Sub

    Private Sub frmNewProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Owner = frmManager
        If My.Settings.set_defaultprojlocation = "DEFAULT" Then
            txt_projlocation.Text = XDev.Path.Locator.GetWorkspacePath + "\Projects\"
        Else
            txt_projlocation.Text = My.Settings.set_defaultprojlocation
        End If

    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
    End Sub

    Private Function CheckIfFieldsValid() As Boolean
        If txt_projname.Text = "" Or combo_projlang.Text = "" Or txt_projlocation.Text = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function CheckIfProjectValid() As Boolean
        If System.IO.Directory.Exists(txt_projlocation.Text + txt_projname.Text) Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btn_create_Click(sender As Object, e As EventArgs) Handles btn_create.Click
        If CheckIfFieldsValid() Then
            If CheckIfProjectValid() Then
                If txt_projlocation.Text.Substring(txt_projlocation.Text.Length - 1) = "\" Then
                    System.IO.Directory.CreateDirectory(txt_projlocation.Text + txt_projname.Text)
                    My.Settings.temp_projlocation = txt_projlocation.Text + txt_projname.Text '+ "\"
                Else
                    System.IO.Directory.CreateDirectory(txt_projlocation.Text + "\" + txt_projname.Text)
                    My.Settings.temp_projlocation = txt_projlocation.Text + "\" + txt_projname.Text '+ "\"
                End If
                System.IO.Directory.CreateDirectory(My.Settings.temp_projlocation & "\Files")
                'MsgBox(My.Settings.temp_projlocation)
                '======================WRITE PROJECT DETAILS FILE=============================================       
                Dim writer As New XmlTextWriter(My.Settings.temp_projlocation + "\xdevproject_details.xdpf", System.Text.Encoding.UTF8)
                writer.WriteStartDocument(True)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2
                '--------------------
                writer.WriteStartElement("Project")
                writer.WriteStartElement("Name")
                writer.WriteString(txt_projname.Text) '& LanguageEnum.GetLanguageExtension(combo_projlang.SelectedItem)
                writer.WriteEndElement()
                writer.WriteStartElement("Developer")
                writer.WriteString(txt_projdev.Text)
                writer.WriteEndElement()
                writer.WriteStartElement("Website")
                writer.WriteString(txt_devwebsite.Text)
                writer.WriteEndElement()
                writer.WriteStartElement("Contact")
                writer.WriteString(txt_devcontact.Text)
                writer.WriteEndElement()
                writer.WriteStartElement("License")
                writer.WriteString(txt_projlicense.Text)
                writer.WriteEndElement()
                writer.WriteStartElement("Language")
                writer.WriteString(combo_projlang.SelectedItem)
                writer.WriteEndElement()
                writer.WriteStartElement("Version")
                writer.WriteString(txt_projversion.Text)
                writer.WriteEndElement()
                'writer.WriteStartElement("Location")
                'writer.WriteString(My.Settings.temp_projlocation)
                'writer.WriteEndElement()
                writer.WriteEndElement()

                '--------------------
                writer.WriteEndDocument()
                writer.Close()
                '=========================================================================================================
                '==========================================WRITE PROJECT FILES FILE=======================================
                Dim writer2 As New XmlTextWriter(My.Settings.temp_projlocation + "\xdevproject_files.xdf", System.Text.Encoding.UTF8)
                writer2.WriteStartDocument(True)
                writer2.Formatting = Formatting.Indented
                writer2.Indentation = 2
                writer2.WriteStartElement("XDevProject_Files")
                '--------------------
                System.IO.File.Create(My.Settings.temp_projlocation + "\Files\Main" + LanguageEnum.ConvertEnumToExtension(LanguageEnum.ConvertReadableToEnum(combo_projlang.SelectedItem))).Dispose()
                'MsgBox(LanguageEnum.GetLanguageExtension(combo_projlang.Text))
                ProjectWriter.WriteToProjectFiles("Main" & LanguageEnum.ConvertEnumToExtension(LanguageEnum.ConvertReadableToEnum(combo_projlang.SelectedItem)), LanguageEnum.ConvertReadableToEnum(combo_projlang.SelectedItem), writer2)
                '--------------------
                writer2.WriteEndElement()
                writer2.WriteEndDocument()
                writer2.Close()
                '================================================================================================================
                If Not File.Exists(My.Settings.temp_projlocation + "\PSS_Version.txt") Then
                    ' Create a file to write to.  
                    Using sw As StreamWriter = File.CreateText(My.Settings.temp_projlocation + "\PSS_Version.txt")
                        sw.WriteLine("Project created and stored using PSS Version " & My.Resources.PSSVersion)
                        sw.WriteLine("Copyright © 2010-2015 BioNetWorks Corp. All Rights Reserved.")
                    End Using
                End If
                '---------------------------
                frmManager.LoadProject(My.Settings.temp_projlocation)
                'Tabs.AddCode("", LanguageEnum.ConvertLanguageToScintilla(combo_projlang.SelectedItem), "Main" + LanguageEnum.GetLanguageExtension(combo_projlang.SelectedItem), My.Settings.temp_projlocation + "Main" + LanguageEnum.GetLanguageExtension(combo_projlang.Text))
                frmManager.SetProjectType(frmManager.ProjType.Project)
                If My.Settings.set_recentprojects.Contains(My.Settings.temp_projlocation) Then
                    'do nothing
                Else
                    My.Settings.set_recentprojects.Add(My.Settings.temp_projlocation)
                End If
                Me.Close()
            Else
                MetroFramework.MetroMessageBox.Show(frmManager, "A location with that project name already exists!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MetroFramework.MetroMessageBox.Show(frmManager, "Please make sure you properly fill out the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        Dim newb As New FolderBrowserDialog
        If My.Settings.set_defaultprojlocation = "DEFAULT" Then
            newb.SelectedPath = XDev.Path.Locator.GetWorkspacePath + "\Projects\"
        Else
            newb.SelectedPath = My.Settings.set_defaultprojlocation
        End If
        newb.Description = "Browse for the location where you want your project to be saved."
        newb.ShowNewFolderButton = True
        If newb.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_projlocation.Text = newb.SelectedPath
        End If

    End Sub

End Class