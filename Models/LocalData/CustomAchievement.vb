Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class CustomAchievement
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        Public Property Name$
        Public Property Description$
        Public Property FinishTimeSec As Integer?
        Public Property Visible As Boolean
        Public Property Group As AchievementGroups
        Public Property Difficulty As DifficultyLevels

    End Class
End Namespace