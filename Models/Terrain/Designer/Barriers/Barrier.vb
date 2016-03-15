Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示障碍物。引擎会附带示例的障碍物，请不要制作出重复的障碍物。
    ''' </summary>
    Public MustInherit Class Barrier
        Inherits ToolboxItem
        Public Overrides Property Category As String = TerrainCategories.Barriers
    End Class
End Namespace