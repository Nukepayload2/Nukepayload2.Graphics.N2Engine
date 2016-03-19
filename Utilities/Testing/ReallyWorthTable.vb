Option Strict On
Imports System.Text

Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class ReallyWorthTable
        Public Function Test$(value1$, value2$, value3$, expression As Func(Of Double, Double, Double, Double))
            Dim sb As New StringBuilder
            sb.AppendLine(value1 & vbTab & value2 & vbTab & value3 & vbTab & "结果")
            For i = 0 To 1
                For j = 0 To 1
                    For k = 0 To 1
                        sb.AppendLine(i & vbTab & j & vbTab & k & vbTab & expression(i, j, k))
                    Next
                Next
            Next
            Return sb.ToString
        End Function
    End Class
End Namespace