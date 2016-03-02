Public NotInheritable Class CanvasContainer
    Inherits UserControl
    WithEvents StaticControl As New CanvasControl
    Sub New()
        Content = StaticControl
    End Sub
    Public Event Draw As TypedEventHandler(Of CanvasControl, CanvasDrawEventArgs)
    Public Event CreateResources As TypedEventHandler(Of CanvasControl, CanvasCreateResourcesEventArgs)
    Public ReadOnly Property Canvas As CanvasControl
        Get
            Return StaticControl
        End Get
    End Property
    Sub OnDraw(snd As CanvasControl, ev As CanvasDrawEventArgs) Handles StaticControl.Draw
        RaiseEvent Draw(snd, ev)
    End Sub
    Private Sub Win2DContainer_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        StaticControl.RemoveFromVisualTree()
        Content = Nothing
        StaticControl = Nothing
        Debug.WriteLine("画布已从控件分离")
    End Sub
    Protected Overrides Sub Finalize()
        Debug.WriteLine("回收画布")
        MyBase.Finalize()
    End Sub
    Private Sub CanvasControl_CreateResources(sender As CanvasControl, args As CanvasCreateResourcesEventArgs) Handles StaticControl.CreateResources
        RaiseEvent CreateResources(sender, args)
    End Sub
End Class