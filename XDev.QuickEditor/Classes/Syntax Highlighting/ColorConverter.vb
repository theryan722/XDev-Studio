Friend Class ColorConverter

    ''' <summary>
    ''' Converts a color to string equivalent
    ''' </summary>
    ''' <param name="convcolor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertColorToString(ByVal convcolor As Color) As String
        Return convcolor.ToArgb.ToString
    End Function

    Public Shared Function ConvertStringToColor(ByVal convstr As String) As Color
        Return Color.FromArgb(convstr)
    End Function

End Class