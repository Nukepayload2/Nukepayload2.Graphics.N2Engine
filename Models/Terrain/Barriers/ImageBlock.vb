Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class ImageBlock
        Inherits StaticBlock2D(Of Brushes.CanvasImageBrush)
        <N2DesignerVisible>
        Sub New(width As Single, height As Single, ImageName As String)
            MyBase.New(width, height)
            Me.ImageName = ImageName
        End Sub
        <N2DesignerVisible>
        Public ReadOnly Property ImageName As String
        Public ReadOnly Property CurrentBrush As Brushes.CanvasImageBrush
        Public Overrides ReadOnly Property Presenter As GameVisualView = New BlockView(Of Brushes.CanvasImageBrush)(Me,
            Function(sender, e)
                e.TrackAsyncAction((Async Function()
                                        _CurrentBrush = New Brushes.CanvasImageBrush(sender, Await CanvasBitmap.LoadAsync(sender, ImageName))
                                    End Function).Invoke)
                Return CurrentBrush
            End Function)
    End Class
End Namespace