Public MustInherit Class InfantryAnimation
    ''' <summary>
    ''' 附加的动画，比如各种Buff动画。
    ''' </summary>
    ''' <returns></returns>
    Public Property AttachedAnimation As New List(Of DynamicBitmapAnimation)
    Public ReadOnly Property Animations As New Dictionary(Of InfantryStatus, IList(Of IList(Of CanvasBitmap)))

    Public MustOverride Function GetImage(LastStatus As InfantryStatus, NewStatus As InfantryStatus, ByRef Index%, Optional StatusParameter% = -1) As ICanvasImage

End Class