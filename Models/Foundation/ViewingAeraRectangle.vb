Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示在<see cref="GamePanelScrollViewer"/>中使用的方框
    ''' </summary>
    Public Class ViewingAeraRectangle
        Inherits AnimatedVisual

        Public Property Aera As Rect
        Public Property BorderColor As Color

        Public Overrides ReadOnly Property Presenter As GameVisualView = New ViewAeraRectangleView(Me)

        Sub New(Aera As Rect, BorderColor As Color)
            Me.Aera = Aera
            Me.BorderColor = BorderColor
        End Sub
    End Class

End Namespace
