Public Class BlockView
    Inherits TypedGameVisualPresenter(Of Block2D)
    Sub New(target As Block2D)
        MyBase.New(target)
    End Sub
    Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
        DrawingSession.FillRectangle(Target.Location.X, Target.Location.Y, Target.Width, Target.Height, Target.Brush)
    End Sub

    Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

    End Sub
End Class
