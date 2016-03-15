Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SolidColorBlock
        Inherits StaticBlock2D(Of Brushes.CanvasSolidColorBrush)
        <N2DesignerVisible>
        Sub New(width As Single, height As Single, Color As Color)
            MyBase.New(width, height)
            Me.Color = Color
        End Sub
        <N2DesignerVisible>
        Public Property Color As Color

        Public Overrides ReadOnly Property Presenter As GameVisualView = New BlockView(Of Brushes.CanvasSolidColorBrush)(Me,
                 Function(sender, e) New Brushes.CanvasSolidColorBrush(sender, Color))
    End Class
End Namespace