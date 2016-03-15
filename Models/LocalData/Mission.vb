Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class Mission
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        Public Property Name As String
        Public Property Description As String
        Public Property Chapter As Integer
        Public Property SubChapter As String
        Public Property SideId As Integer
        Public Property MissionObjectiveIds As Integer()
        Public Property BonusObjectiveIds As Integer()
    End Class
End Namespace