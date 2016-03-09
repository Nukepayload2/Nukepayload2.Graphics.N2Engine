Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Interface IGameResourceManager(Of TResID, TResource)
        Inherits IDisposable
        Function LoadAsync(Creator As ICanvasResourceCreator) As Task
        Function GetResource(ID As TResID) As TResource
    End Interface
End Namespace
