Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class AnimationStatus
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        Public Property Name As String
        Public Property Description As String
        Public Property PayloadLevel As Short
        Public Property FormatLevel As Short
    End Class
End Namespace