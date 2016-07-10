Friend Class Bases
    Private Const list As String = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
    Private Const zero As Char = "0"
    'converts a number in base 10 to a number in base x
    Public Function Num2Base(ByVal number As Integer, ByVal base As Integer) As String
        Dim tmp As Integer = 0
        Dim num As Integer = System.Math.Abs(number)
        Dim val As String = ""
        Do
            'gets number for new base
            tmp = num Mod base
            'gets digit in new base
            Select Case tmp
                Case 0 : val.Insert(0, zero)
                Case Else : val.Insert(0, list.ToCharArray()(tmp - 1))
            End Select
            'retrieves next number
            num = num \ base
        Loop While num <> 0
        Return val
    End Function
    'converts a number in base x to a number in base 10 (we could let the framework handle bases 2,8,10,16, but we want to)
    Public Function Base2Num(ByVal data As String, ByVal base As Integer) As Integer
        Dim val, tmp As Integer      'integers are automatically initiallized to zero
        For a As Integer = 1 To data.Length
            tmp = 0
            If Mid(data, a, 1) <> zero Then
                tmp = (InStr(1, list, Mid(data, a, 1)) * (base ^ (data.Length - a)))
            End If
            val += tmp
        Next a
        Return val
    End Function
    'converts a number in base x to a number in base x
    Public Function BaseX2BaseX(ByVal data As String, ByVal newBase As Long, ByVal currentBase As Long) As String
        Return Num2Base(Base2Num(data, currentBase), newBase)
    End Function
End Class