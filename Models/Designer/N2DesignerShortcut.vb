Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class N2DesignerShortcut
        Sub New()

        End Sub
        Public Sub New(icon As FrameworkElement, description As String, onClick As RoutedEventHandler)
            Me.Icon = icon
            Me.Description = description
            Me.OnClick = onClick
        End Sub

        Public Property Icon As FrameworkElement
        Public Property Description$
        Public Property OnClick As RoutedEventHandler
    End Class
End Namespace
