Public NotInheritable Class CanvasAnimatedContainer
    Inherits UserControl
    WithEvents AnimControl As New CanvasAnimatedControl
    Sub New()
        Content = AnimControl
    End Sub
    Public Event Draw As TypedEventHandler(Of ICanvasAnimatedControl, CanvasAnimatedDrawEventArgs)
    Public Event CreateResources As TypedEventHandler(Of CanvasAnimatedControl, CanvasCreateResourcesEventArgs)
    Public ReadOnly Property Canvas As CanvasAnimatedControl
        Get
            Return AnimControl
        End Get
    End Property
    Sub OnDraw(snd As ICanvasAnimatedControl, ev As CanvasAnimatedDrawEventArgs) Handles AnimControl.Draw
        RaiseEvent Draw(snd, ev)
    End Sub
    Private Sub Win2DContainer_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        AnimControl.RemoveFromVisualTree()
        Content = Nothing
        AnimControl = Nothing
        Debug.WriteLine("画布已从控件分离")
    End Sub
    Protected Overrides Sub Finalize()
        Debug.WriteLine("回收画布")
        MyBase.Finalize()
    End Sub
    Private Sub CanvasControl_CreateResources(sender As CanvasAnimatedControl, args As CanvasCreateResourcesEventArgs) Handles AnimControl.CreateResources
        RaiseEvent CreateResources(sender, args)
    End Sub
End Class
