Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Module BinaryMath
        <Extension>
        Function BitContains(source As Integer, value As Integer) As Boolean
            Return (source And value) = value
        End Function
    End Module
End Namespace
