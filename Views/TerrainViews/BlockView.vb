Imports Microsoft.Graphics.Canvas.Brushes

Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class BlockView(Of TBrush As ICanvasBrush)
        Inherits TypedGameVisualPresenter(Of StaticBlock2D(Of TBrush))
        Dim BrushCreator As Func(Of ICanvasResourceCreator, CanvasCreateResourcesEventArgs, TBrush)
        Sub New(target As StaticBlock2D(Of TBrush), BrushCreator As Func(Of ICanvasResourceCreator, CanvasCreateResourcesEventArgs, TBrush))
            MyBase.New(target)
            Me.BrushCreator = BrushCreator
        End Sub

        Public Overrides Sub OnCreateCustomStaticResource(sender As CanvasControl, args As CanvasCreateResourcesEventArgs)
            MyBase.OnCreateCustomStaticResource(sender, args)
            Target.Fill = BrushCreator.Invoke(sender, args)
        End Sub

        Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
            DrawingSession.FillRectangle(Target.Location.X, Target.Location.Y, Target.Width, Target.Height, Target.Fill)
        End Sub

        Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

        End Sub
    End Class
End Namespace
