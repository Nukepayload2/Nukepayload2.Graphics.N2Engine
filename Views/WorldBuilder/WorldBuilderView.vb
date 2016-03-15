Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class WorldBuilderView
        Inherits GamePanelScrollViewer
        Sub New(panel As GamePanel, minimapCanvas As CanvasAnimatedContainer)
            MyBase.New(panel, minimapCanvas)
        End Sub
        Protected Overrides Function InitializeImageManager(creator As ICanvasResourceCreator) As GameResourceManager(Of Integer, ICanvasImage)
            Return New WorldBuilderPreviewResources
        End Function
    End Class
End Namespace