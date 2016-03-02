Public Class StaticBlock2D
    Inherits StaticVisual
    Public Property Width!
    Public Property Height!
    Public Property Brush As Brushes.ICanvasBrush
    Public Overrides ReadOnly Property Presenter As GameVisualView = New BlockView(Me)
End Class