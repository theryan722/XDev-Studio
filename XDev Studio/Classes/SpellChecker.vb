Imports NHunspell

Friend Class SpellChecker

    Private Shared en_us_dicloc As String = XDev.Path.Locator.GetAppPath + "\Engine\SpellChecker\en_US\en_us.dic"
    Private Shared en_us_affloc As String = XDev.Path.Locator.GetAppPath + "\Engine\SpellChecker\en_US\en_us.aff"
    Private Shared custom_1 As String = XDev.Path.Locator.GetAppPath + "\Engine\SpellChecker\Custom\custom1.txt"

#Region "Spelling"

    Public Shared Function IsWordSpelledCorrectly(ByVal word As String) As Boolean
        Using hunspell As New Hunspell(en_us_affloc, en_us_dicloc)
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(custom_1)
                For Each i As String In lines
                    hunspell.Add(i)
                Next
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
            Return hunspell.Spell(word)
        End Using
    End Function

    Public Shared Function GetSpellingRecommendations(ByVal word As String) As List(Of String)
        Using hunspell As New Hunspell(en_us_affloc, en_us_dicloc)
            Try
                Dim lines() As String = System.IO.File.ReadAllLines(custom_1)
                For Each i As String In lines
                    hunspell.Add(i)
                Next
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
            Dim sug As List(Of String) = hunspell.Suggest(word)
            Return sug
        End Using
    End Function

#End Region

#Region "Dictionary"
    Public Shared Sub AddCustomWordToDictionary(ByVal word As String)
        If System.IO.File.ReadAllLines(custom_1).Contains(word) = False Then
            Try
                Dim objWriter As New System.IO.StreamWriter(custom_1, True)
                objWriter.WriteLine(word)
                objWriter.Close()
            Catch ex As Exception
                Logger.WriteError(Logger.TypeOfLog.Studio, ex)
            End Try
        End If
    End Sub

    Public Shared Sub RemoveCustomWordFromDictionary(ByVal word As String)
        Try
            Dim lines() As String
            Dim outputlines As New List(Of String)
            Dim searchString As String = word
            lines = IO.File.ReadAllLines(custom_1)
            For Each line As String In lines
                If line.Equals(word) = False Then
                    outputlines.Add(line)
                End If
            Next
            Dim objWriter As New System.IO.StreamWriter(custom_1, False)
            For Each item As String In outputlines
                objWriter.WriteLine(item)
            Next
            objWriter.Close()
        Catch ex As Exception
            Logger.WriteError(Logger.TypeOfLog.Studio, ex)
        End Try
    End Sub

#End Region

End Class
