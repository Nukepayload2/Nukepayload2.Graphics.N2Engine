Namespace Global.Nukepayload2.Graphics.N2Engine
    Public MustInherit Class ConsoleClient
        Public MustOverride ReadOnly Property HelpText$
        Protected ResponsePair As New Dictionary(Of String, Func(Of String(), String))
        Public Sub AddCommand(Command As String, Process As Func(Of String(), String))
            Dim args As New ConsoleSingleLineCommand(Command)
            Dim actionname = args.Arguments.First.ToLowerInvariant
            If Not ResponsePair.ContainsKey(actionname) Then
                ResponsePair.Add(actionname, Process)
            End If
        End Sub
        Protected History As New LinkedList(Of String)
        Public Property HistroyLengthLimit As Integer
        Public Function Execute(Command$) As String
            Dim args As New ConsoleSingleLineCommand(Command)
            Dim act = args.Arguments.First
            Dim actionname = act.ToLowerInvariant
            History.AddLast(act)
            If HistroyLengthLimit < History.Count Then
                History.RemoveFirst()
            End If
            If ResponsePair.ContainsKey(actionname) Then
                Return ResponsePair(actionname).Invoke(args.Arguments)
            Else
                Return HelpText
            End If
        End Function
    End Class
End Namespace

