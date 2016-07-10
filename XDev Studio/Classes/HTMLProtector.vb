Friend Class HTMLProtector

    Public Shared Function ProtectHTML(ByVal code As String) As String
        Dim res As String = ""
        res += "<Script Language='Javascript'>" + vbNewLine
        res += "<!--HTML Source Encrypted using XDev Studio HTML Protector." + vbNewLine
        res += "document.write(unescape('" + Hex(code) + "'));" + vbNewLine
        res += "//-->" + vbNewLine
        res += "</Script>"
        Return res
    End Function

    Public Shared Function UnprotectHTML(ByVal code As String) As String
        Dim data As String = code

        data = Split(data, "document.write(unescape('")(1)
        data = Split(data, "'));")(0)

        data = data.ToString.Replace("%", String.Empty)
        Dim data2 As String = HexToString(data)
        Return data2
    End Function

#Region "Hex"

    Private Shared Function Hex(ByVal data)

        Dim str As String = data
        Dim byteArray() As Byte
        Dim hexNumbers As System.Text.StringBuilder = New System.Text.StringBuilder

        byteArray = System.Text.ASCIIEncoding.ASCII.GetBytes(str)

        For i As Integer = 0 To byteArray.Length - 1
            hexNumbers.Append("%" + byteArray(i).ToString("x"))
        Next

        Return hexNumbers.ToString()

    End Function

    Private Shared Function HexToString(ByVal hex As String) As String
        Dim text As New System.Text.StringBuilder(hex.Length \ 2)
        For i As Integer = 0 To hex.Length - 2 Step 2
            text.Append(Chr(Convert.ToByte(hex.Substring(i, 2), 16)))
        Next
        Return text.ToString
    End Function

#End Region

End Class
