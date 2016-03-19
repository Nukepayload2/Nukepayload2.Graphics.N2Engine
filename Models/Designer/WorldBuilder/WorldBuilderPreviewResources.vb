Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class WorldBuilderPreviewResources
        Inherits GameResourceManager(Of Integer, ICanvasImage)

        Public Overrides Async Function LoadAsync(Creator As ICanvasResourceCreator) As Task
            Await Task.Delay(0)
        End Function
    End Class
End Namespace