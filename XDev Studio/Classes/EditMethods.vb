Imports System.Text.RegularExpressions

Module EditMethods

    Public Function RemoveSpecialCharacters(ByVal original As String) As String
        Return Regex.Replace(original, "[^a-zA-Z0-9_. ]+", "", RegexOptions.Compiled)
    End Function

End Module
