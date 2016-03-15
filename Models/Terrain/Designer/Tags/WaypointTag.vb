
Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 路径点通常位于地图上，用于为各个事件的脚本提供位置标记。
    ''' </summary>
    <ToolboxItemVisible>
    Public Class WaypointTag
        Inherits Tags

        Public Overrides Property Description As String = "路径点通常位于地图上，用于为各个事件的脚本提供位置标记。"
        Public Overrides Property Name As String = "路径点"
        ''' <summary>
        ''' 路径点的标号
        ''' </summary>
        Public Property Id%
        Public Overrides Property TargetType As Type
    End Class
End Namespace
