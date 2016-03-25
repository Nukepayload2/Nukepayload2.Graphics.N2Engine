Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class LinearGradientBlock
        Inherits StaticBlock2D(Of Brushes.CanvasLinearGradientBrush)
        <N2DesignerVisible>
        Sub New(width As Single, height As Single, Stops As Brushes.CanvasGradientStop())
            MyBase.New(width, height)
            Me.Stops = Stops
        End Sub
        <N2DesignerVisible(DesignToolSelections.ArrayEditor)>
        Public Property Stops As Brushes.CanvasGradientStop()
        Public Overrides ReadOnly Property Presenter As GameVisualView = New BlockView(Of Brushes.CanvasLinearGradientBrush)(Me,
            Function(sender, e) New Brushes.CanvasLinearGradientBrush(sender, Stops))
    End Class
End Namespace