Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 呈现在<see cref="GamePanelScrollViewer"/>中使用的方框
    ''' </summary>
    Friend Class ViewAeraRectangleView
        Inherits TypedGameVisualPresenter(Of ViewingAeraRectangle)
        Sub New(Target As ViewingAeraRectangle)
            MyBase.New(Target)
        End Sub
        Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
            DrawingSession.DrawRectangle(Target.Aera, Target.BorderColor, 10)
        End Sub

        Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

        End Sub
    End Class

End Namespace
