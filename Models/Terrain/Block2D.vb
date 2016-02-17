Public Class Block2D
    Inherits StaticVisual
    Public Property Width!
    Public Property Height!
    Public Property Brush As Brushes.ICanvasBrush
    Public Overrides ReadOnly Property Presenter As GameVisualView
End Class