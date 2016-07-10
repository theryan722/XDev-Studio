Imports rsp.ConVert
Imports ICSharpCode.NRefactory

Public Class LanguageConverter

#Region "C# to VB"

    Public Shared Function ConvertCSharpToVB(ByVal txt As String, Optional withoutfix As Boolean = False) As String
        Try
            If withoutfix Then
                Dim TmpConv As CSVBConverter
                TmpConv = CSVBConverter.Convert(txt)
                Return TmpConv.VBSource
            Else
                Dim TmpConv As CSVBConverter
                TmpConv = CSVBConverter.Convert(txt)
                Return LanguageFormatter.FixVB2(LanguageFormatter.FixVB(TmpConv.VBSource))
            End If
        Catch ex As Exception
            Logger.WriteError(ex)
            Return Nothing
        End Try
    End Function
    
#End Region

#Region "VB to C#"

    Public Shared Function ConvertVBToCSharp(ByVal txt As String, Optional withoutfix As Boolean = False) As String
        Try
            If withoutfix Then
                Dim TmpConv As VBCSConverter
                TmpConv = VBCSConverter.Convert(txt)
                Return TmpConv.CSharpSource
            Else
                Dim TmpConv As VBCSConverter
                TmpConv = VBCSConverter.Convert(txt)
                Return LanguageFormatter.FixCS(TmpConv.CSharpSource)
            End If
        Catch ex As Exception
            Logger.WriteError(ex)
            Return Nothing
        End Try
    End Function

#End Region
    
End Class
