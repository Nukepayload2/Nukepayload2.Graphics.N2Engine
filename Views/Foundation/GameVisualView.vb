
Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 游戏可视对象视图, 使用Win2D绘制。
    ''' </summary>
    Public MustInherit Class GameVisualView
        Implements IDisposable
        ''' <summary>
        ''' 如果非空则覆盖全局质量设定
        ''' </summary>
        ''' <returns></returns>
        Public Property QualityOverride As GraphicQualityOptions?
        Public Overridable Sub OnCreateCustomAnimatedResource(sender As CanvasAnimatedControl, args As CanvasCreateResourcesEventArgs)

        End Sub
        Public Overridable Sub OnCreateCustomStaticResource(sender As CanvasControl, args As CanvasCreateResourcesEventArgs)

        End Sub
        Public Overridable Sub OnCreateCustomMinimapResource(sender As CanvasAnimatedControl, args As CanvasCreateResourcesEventArgs)

        End Sub
        Public MustOverride Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
        Public MustOverride Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)
        Public Overridable Sub OnDrawMinimap(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
            OnDraw(sender, DrawingSession, Canvas)
        End Sub
        Public Overridable Sub Dispose() Implements IDisposable.Dispose

        End Sub
        Sub New()
            AddHandler GraphicQualityManager.QualityChanged, AddressOf OnGlobalQualityChanged
        End Sub
    End Class

End Namespace
