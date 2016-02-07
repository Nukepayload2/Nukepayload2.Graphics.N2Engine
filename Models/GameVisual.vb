''' <summary>
''' 可视物体的基类
''' </summary>
Public MustInherit Class GameVisual
    Public Property Location As Vector2
    Public MustOverride ReadOnly Property Presenter As GameVisualView
End Class
