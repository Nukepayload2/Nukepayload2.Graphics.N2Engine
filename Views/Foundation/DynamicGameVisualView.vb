﻿Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 可以动态指定绘制行为的可视对象视图, 使用Win2D绘制。
    ''' </summary>
    Public Class DynamicGameVisualView
        Inherits GameVisualView
        Sub New(OnDraw As Action(Of GamePanelView, CanvasDrawingSession, ICanvasResourceCreator))
            Draw = OnDraw
        End Sub
        Public ReadOnly Property GlobalQualityCopy As GraphicQualityOptions = GraphicQualityOptions.Shadow
        Public Property Draw As Action(Of GamePanelView, CanvasDrawingSession, ICanvasResourceCreator)
        Public Property DrawMinimap As Action(Of GamePanelView, CanvasDrawingSession, ICanvasResourceCreator)
        Public Property GlobalQualityChanged As Action(Of GraphicQualityManager)
        Public Property DisposeResources As Action
        Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
            Draw.Invoke(sender, DrawingSession, Canvas)
        End Sub
        Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)
            _GlobalQualityCopy = Quality.GraphicOption
            GlobalQualityChanged?.Invoke(Quality)
        End Sub
        Public Overrides Sub OnDrawMinimap(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
            DrawMinimap?.Invoke(sender, DrawingSession, Canvas)
        End Sub
        Public Overrides Sub Dispose()
            DisposeResources?.Invoke
        End Sub
    End Class
End Namespace
