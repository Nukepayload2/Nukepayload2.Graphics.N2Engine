Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SolidColorBlock
        Inherits StaticBlock2D
        <N2DesignerVisible>
        Sub New(width As Single, height As Single, brush As Brushes.CanvasSolidColorBrush)
            MyBase.New(width, height, brush)
        End Sub
        <N2DesignerVisible>
        Public Property Color As Color
            Get
                Return DirectCast(Fill, Brushes.CanvasSolidColorBrush).Color
            End Get
            Set
                DirectCast(Fill, Brushes.CanvasSolidColorBrush).Color = Value
            End Set
        End Property
        <N2DesignerVisible>
        Public Property Opacity As Single
            Get
                Return DirectCast(Fill, Brushes.CanvasSolidColorBrush).Opacity
            End Get
            Set
                DirectCast(Fill, Brushes.CanvasSolidColorBrush).Opacity = Value
            End Set
        End Property
        <N2DesignerVisible>
        Public Property ColorHdr As Vector4
            Get
                Return DirectCast(Fill, Brushes.CanvasSolidColorBrush).ColorHdr
            End Get
            Set
                DirectCast(Fill, Brushes.CanvasSolidColorBrush).ColorHdr = Value
            End Set
        End Property
        <N2DesignerVisible>
        Public Property Transform As Matrix3x2
            Get
                Return DirectCast(Fill, Brushes.CanvasSolidColorBrush).Transform
            End Get
            Set
                DirectCast(Fill, Brushes.CanvasSolidColorBrush).Transform = Value
            End Set
        End Property
    End Class
End Namespace
