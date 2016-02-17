''' <summary>
''' 可视物体的基类
''' </summary>
Public MustInherit Class GameVisual
    ''' <summary>
    ''' 物体的位置。这通常是物体的左上角。
    ''' </summary>
    ''' <returns></returns>
    Public Property Location As Vector2
    ''' <summary>
    ''' 指定物体的大致形状以进行碰撞检测。如果不需要碰撞检测就不用指定形状。
    ''' </summary>
    Public Property Shape As Geometry
    ''' <summary>
    ''' 用于放置绘制代码
    ''' </summary>
    Public MustOverride ReadOnly Property Presenter As GameVisualView
End Class