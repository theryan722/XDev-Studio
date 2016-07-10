Imports System.Xml

Friend Class ProjectWriter

    Private Shared xdDoc As New XmlDocument()

#Region "xdevproject_files"
    Public Shared Sub WriteToProjectFiles(ByVal docname As String, ByVal doclang As XDev.Editor.Language.EditorLanguage, ByVal writer1 As XmlTextWriter)
        writer1.WriteStartElement("File")
        writer1.WriteStartElement("Name")
        writer1.WriteString(docname)
        writer1.WriteEndElement()
        writer1.WriteStartElement("Language")
        writer1.WriteString(LanguageEnum.ConvertEnumToReadable(doclang))
        writer1.WriteEndElement()
        'writer1.WriteStartElement("Location")
        'writer1.WriteString(docloc)
        'writer1.WriteEndElement()
        writer1.WriteEndElement()
    End Sub

    Public Shared Sub AddFile(ByVal filename As String, ByVal filelanguage As XDev.Editor.Language.EditorLanguage)

        xdDoc.Load(My.Settings.temp_projlocation + "\xdevproject_files.xdf")

        Dim xnRoot As XmlNode = xdDoc.DocumentElement 'Determine Root Of XML Document


        Dim xeMainElement As XmlElement = xdDoc.CreateElement("File")
        Dim xeSubElement As XmlElement = xdDoc.CreateElement("Name")
        Dim xeSubElement1 As XmlElement = xdDoc.CreateElement("Language")
        'Dim xeSubElement2 As XmlElement = xdDoc.CreateElement("Location")
        xeSubElement.InnerText = filename
        xeSubElement1.InnerText = LanguageEnum.ConvertEnumToReadable(filelanguage)
        'xeSubElement2.InnerText = fileloc

        xnRoot.AppendChild(xeMainElement)

        xeMainElement.AppendChild(xeSubElement)
        xeMainElement.AppendChild(xeSubElement1)
        'xeMainElement.AppendChild(xeSubElement2)
        'Save
        Dim xtwWriter As New XmlTextWriter(My.Settings.temp_projlocation + "\xdevproject_files.xdf", Nothing)

        xtwWriter.Formatting = Formatting.Indented
        xdDoc.Save(xtwWriter)

        xtwWriter.Close()
    End Sub

    Public Shared Sub UpdateFile(ByVal origfilename As String, ByVal nfilename As String, ByVal nfilelanguage As String, ByVal nfileloc As String)
        RemoveFile(origfilename)
        AddFile(nfilename, nfilelanguage)
    End Sub

    Public Shared Sub RemoveFile(ByVal filename As String)
        Dim xd As New XmlDocument()
        xd.Load(My.Settings.temp_projlocation + "\xdevproject_files.xdf")
        Dim nod As XmlNode = xd.SelectSingleNode("//Name[. = '" + filename + "']" &
        "/parent::node()/Name")
        If nod IsNot Nothing Then
            nod.ParentNode.ParentNode.RemoveChild(nod.ParentNode)
            nod.ParentNode.RemoveAll()
            xd.Save(My.Settings.temp_projlocation + "\xdevproject_files.xdf")
        End If
    End Sub
#End Region

#Region "xdevproject_details"

    Public Shared Sub SetProjectName(ByVal projname As String)
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        xml.<Project>.<Name>.Value = projname
        xml.Save(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
    End Sub

    Public Shared Sub SetDeveloperName(ByVal devname As String)
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        xml.<Project>.<Developer>.Value = devname
        xml.Save(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
    End Sub

    Public Shared Sub SetDeveloperWebsite(ByVal devwebsite As String)
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        xml.<Project>.<Website>.Value = devwebsite
        xml.Save(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
    End Sub

    Public Shared Sub SetDeveloperContact(ByVal devcontact As String)
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        xml.<Project>.<Contact>.Value = devcontact
        xml.Save(My.Settings.temp_projlocation + "xdevproject_details.xdpf")
    End Sub

    Public Shared Sub SetProjectLicense(ByVal projlicense As String)
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        xml.<Project>.<License>.Value = projlicense
        xml.Save(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
    End Sub

    Public Shared Sub SetProjectLanguage(ByVal projlang As XDev.Editor.Language.EditorLanguage)
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        xml.<Project>.<Language>.Value = LanguageEnum.ConvertEnumToReadable(projlang)
        xml.Save(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
    End Sub

    Public Shared Sub SetProjectVersion(ByVal projver As String)
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        xml.<Project>.<Version>.Value = projver
        xml.Save(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
    End Sub

    Public Shared Sub SetProjectLocation(ByVal projloc As String)
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        xml.<Project>.<Location>.Value = projloc
        xml.Save(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
    End Sub

#End Region

End Class