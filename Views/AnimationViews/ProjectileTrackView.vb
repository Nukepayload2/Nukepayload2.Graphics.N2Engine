
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class ProjectileTrackView
        Inherits TypedGameVisualPresenter(Of ProjectileTrack)
        Sub New(target As ProjectileTrack)
            MyBase.New(target)
        End Sub
        Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
            '默认的行为是不绘制任何轨迹

        End Sub
        Public Overrides Sub OnDrawMinimap(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
            '不要在小地图绘制任何抛射体动画

        End Sub
        Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

        End Sub
    End Class

End Namespace
