Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class AtlasStatus
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        Public Property Name As String
        Public Property Sprite As String
        Public Property SpriteIndex%
    End Class
End Namespace