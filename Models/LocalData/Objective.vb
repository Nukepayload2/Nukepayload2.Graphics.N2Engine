Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class Objective
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        Public Property Name As String
        Public Property Description As String
        Public Property Archived As Boolean
        Public Property Failed As Boolean
    End Class
End Namespace