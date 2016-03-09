
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class ConsoleSingleLineCommand
        Public ReadOnly Property Source$
        Public ReadOnly Property Arguments As String()
        Sub New(Command$)
            Source = Command
            Arguments = SeperateArguments()
        End Sub

        Private Function SeperateArguments() As String()
            Dim args As New List(Of String)
            Dim startpos = 0
            For i = 0 To Source.Length - 1
                Dim ch = Source(i)
                If ch = " "c Then
                    If i - startpos > 0 Then
                        args.Add(Source.Substring(startpos, i - startpos))
                        startpos = i + 1
                    End If
                End If
            Next
            If startpos <= Source.Length - 1 Then
                args.Add(Source.Substring(startpos))
            End If
            Return args.ToArray
        End Function

        Public Overrides Function ToString() As String
            Return Source
        End Function
    End Class

End Namespace
