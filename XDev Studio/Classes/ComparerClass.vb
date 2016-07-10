Option Strict Off
Option Explicit On
Friend Class ComparerClass
    Implements IComparer
    Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Return x > y
    End Function
End Class
