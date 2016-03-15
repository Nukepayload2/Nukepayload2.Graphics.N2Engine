Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class ActionStatus
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        ''' <summary>
        ''' 必须在<see cref="InfantryStatus"/>中
        ''' </summary>
        Public Property Action%

    End Class
End Namespace
