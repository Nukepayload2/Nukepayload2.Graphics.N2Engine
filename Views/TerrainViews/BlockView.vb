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
            UpdateFill(sender, args)
        End Sub

        Private Sub UpdateFill(sender As ICanvasResourceCreator, args As CanvasCreateResourcesEventArgs)
            If Target.Fill IsNot Nothing Then
                If Not Target.Fill.ContainsKey(sender) Then
                    Target.Fill.Add(sender, BrushCreator.Invoke(sender, args))
                Else
                    'Target.Fill(sender) = BrushCreator.Invoke(sender, args)
                End If
            End If
        End Sub

        Public Overrides Sub OnCreateCustomMinimapResource(sender As CanvasAnimatedControl, args As CanvasCreateResourcesEventArgs)
            MyBase.OnCreateCustomMinimapResource(sender, args)
            UpdateFill(sender, args)
        End Sub

        Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
            DrawingSession.FillRectangle(Target.Location.X, Target.Location.Y, Target.Width, Target.Height, Target.Fill(Canvas))
        End Sub

        Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

        End Sub
    End Class
End Namespace
