Public Interface IGameResourceManager(Of TResID, TResource)
    Inherits IDisposable
    Function LoadAsync(Creator As ICanvasResourceCreator) As Task
    Function GetResource(ID As TResID) As TResource
End Interface