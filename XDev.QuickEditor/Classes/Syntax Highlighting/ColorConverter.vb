Friend Class ColorConverter

    Public Shared Function ConvertColorToString(ByVal convcolor As Color) As String
        Return convcolor.ToArgb.ToString
    End Function

    Public Shared Function ConvertStringToColor(ByVal convstr As String) As Color
        Return Color.FromArgb(convstr)
    End Function

End Class