Imports System.IO
Imports System.Xml

Friend Class ProfileManager

    Public Shared Sub LogoutCurrentProfile()
        CurrentProfile.Name = ""
        CurrentProfile.Folder = ""
        CurrentProfile.Password = ""
    End Sub

#Region "Create/Load/Delete"

    Public Shared Sub DeleteProfile(ByVal name As String)
        If IO.File.Exists(XDev.Path.Locator.GetDataPath & "\Profiles\" & name & ".xdup") Then
            System.IO.File.Delete(XDev.Path.Locator.GetDataPath & "\Profiles\" & name & ".xdup")
            LogoutCurrentProfile()
        End If
    End Sub

    Public Shared Sub CreateProfile(ByVal name As String, ByVal password As String, ByVal folderlocation As String)
        If Not IO.File.Exists(XDev.Path.Locator.GetDataPath & "\Profiles\" & name & ".xdup") Then
            Dim writer As New XmlTextWriter(XDev.Path.Locator.GetDataPath & "\Profiles\" & name & ".xdup", System.Text.Encoding.UTF8)
            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            writer.WriteStartElement("XDev_UserProfile")

            writer.WriteStartElement("Name")
            writer.WriteString(name)
            writer.WriteEndElement()
            writer.WriteStartElement("Password")
            writer.WriteString(password)
            writer.WriteEndElement()
            writer.WriteStartElement("Folder")
            writer.WriteString(folderlocation)
            writer.WriteEndElement()

            writer.WriteEndDocument()
            writer.Close()
        End If
    End Sub

    Public Shared Function LoadProfile(ByVal name As String)
        If IO.File.Exists(XDev.Path.Locator.GetDataPath & "\Profiles\" & name & ".xdup") Then
            Dim xml = XDocument.Load(XDev.Path.Locator.GetDataPath & "\Profiles\" & name & ".xdup")
            CurrentProfile.Name = xml.<XDev_UserProfile>.<Name>.Value
            CurrentProfile.Password = xml.<XDev_UserProfile>.<Password>.Value
            CurrentProfile.Folder = xml.<XDev_UserProfile>.<Folder>.Value
            Return True
        Else
            Return False
        End If
    End Function

#End Region

#Region "Get from Specific Profile"


    Public Shared Function GetPassword(ByVal name As String)
        Dim xml = XDocument.Load(XDev.Path.Locator.GetDataPath & "\Profiles\" & name & ".xdup")
        Return xml.<XDev_UserProfile>.<Password>.Value
    End Function

#End Region

End Class