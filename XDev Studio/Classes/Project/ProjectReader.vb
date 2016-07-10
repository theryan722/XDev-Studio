Imports System.Xml
Imports System.IO

Friend Class ProjectReader

#Region "xdevproject_details"

    Public Shared Function GetProjectName() As String
        Dim xml = XDocument.Load(My.Settings.temp_projlocation & "\xdevproject_details.xdpf")
        Dim projname As String = xml.<Project>.<Name>.Value
        Return projname
    End Function

    Public Shared Function GetProjectName(ByVal projloc As String) As String
        Dim xml = XDocument.Load(projloc + "\xdevproject_details.xdpf")
        Dim projname As String = xml.<Project>.<Name>.Value
        Return projname
    End Function

    Public Shared Function GetDeveloperName() As String
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        Dim devname As String = xml.<Project>.<Developer>.Value
        Return devname
    End Function

    Public Shared Function GetDeveloperWebsite() As String
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        Dim devweb As String = xml.<Project>.<Website>.Value
        Return devweb
    End Function

    Public Shared Function GetDeveloperContact() As String
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        Dim devcontact As String = xml.<Project>.<Contact>.Value
        Return devcontact
    End Function

    Public Shared Function GetProjectLicense() As String
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        Dim projlicense As String = xml.<Project>.<License>.Value
        Return projlicense
    End Function

    Public Shared Function GetProjectLanguage() As XDev.Editor.Language.EditorLanguage
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        Dim projlang As String = xml.<Project>.<Language>.Value
        Return LanguageEnum.ConvertReadableToEnum(projlang)
    End Function

    Public Shared Function GetProjectVersion() As String
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        Dim projver As String = xml.<Project>.<Version>.Value
        Return projver
    End Function

    Public Shared Function GetProjectLocation() As String
        Dim xml = XDocument.Load(My.Settings.temp_projlocation + "\xdevproject_details.xdpf")
        Dim projloc As String = xml.<Project>.<Location>.Value
        Return projloc
    End Function

    Public Shared Function GetProjectLocation(ByVal fileloc As String) As String
        Dim xml = XDocument.Load(fileloc & "\xdevproject_details.xdpf")
        Dim projloc As String = xml.<Project>.<Location>.Value
        Return projloc
    End Function

#End Region

#Region "xdevproject_files"

    Public Shared Function GetProjectFiles() As List(Of FileObject)
        Dim dlist As New List(Of FileObject)
        Try
            Dim _doc As New XmlDocument
            '_doc.LoadXml("xdevproject_files.xdf")
            _doc.Load(My.Settings.temp_projlocation + "\xdevproject_files.xdf")
            Dim names As XmlNodeList = _doc.GetElementsByTagName("Name")
            Dim langs As XmlNodeList = _doc.GetElementsByTagName("Language")
            'Dim locs As XmlNodeList = _doc.GetElementsByTagName("Location")

            'For i As Integer = 0 To names.Count - 1
            '    dlist.Add(New FileObject(names(i).InnerText, langs(i).InnerText, locs(i).InnerText))
            'Next
            Dim FileLocation As New DirectoryInfo(My.Settings.temp_projlocation)
            For i As Integer = 0 To names.Count - 1
                dlist.Add(New FileObject(names(i).InnerText, LanguageEnum.ConvertReadableToEnum(langs(i).InnerText), GetFileLocation(My.Settings.temp_projlocation, names(i).InnerText)))
            Next
            'Make sure files exist
            Dim remlist As New List(Of FileObject)
            For Each item As FileObject In dlist
                If Not File.Exists(item.GetFileLocation) Then
                    remlist.Add(item)
                End If
            Next
            For Each item As FileObject In remlist
                dlist.Remove(item)
            Next
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
        Return dlist
    End Function

    Private Shared Function GetFileLocation(ByVal folderloc As String, ByVal fname As String) As String
        ' This list stores the results.
        Dim result As New List(Of String)

        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(folderloc)

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
        Dim ret As String = ""
        For Each item As String In result
            If item.EndsWith(fname) Then
                ret = item
                Exit For
            End If
        Next

        'Dim b As Integer = result.IndexOf(initial)

        ' Return the list
        Return ret
    End Function

#End Region

End Class