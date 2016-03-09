Imports Microsoft.Graphics.Canvas.Geometry
Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 抛射体的轨迹
    ''' </summary>
    Public Class ProjectileTrack
        Inherits AnimatedVisual
        ''' <summary>
        ''' 初始化时指定从哪里开火，飞向哪里。
        ''' </summary>
        Sub New(fireFrom As Vector2, targetLocation As Vector2)
            Me.FireFrom = fireFrom
            Me.TargetLocation = targetLocation
        End Sub
        Sub New()

        End Sub
        ''' <summary>
        ''' 起点
        ''' </summary>
        Public Property FireFrom As Vector2
        ''' <summary>
        ''' 目标点
        ''' </summary>
        Public Property TargetLocation As Vector2
        ''' <summary>
        ''' 轨迹线
        ''' </summary>
        Public Property TrackLine As CanvasGeometry
        Public Overrides ReadOnly Property Presenter As GameVisualView = New ProjectileTrackView(Me)
    End Class
End Namespace
