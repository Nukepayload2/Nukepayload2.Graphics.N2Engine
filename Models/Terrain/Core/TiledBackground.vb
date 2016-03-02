Imports Microsoft.Graphics.Canvas.Geometry
''' <summary>
''' 采用堆叠图案连接而成，并且带有光照的背景。通常用于动态添加场景的情况。
''' </summary>
Public MustInherit Class TiledBackground
    Inherits AnimatedVisual
    ''' <summary>
    ''' 背景图片的资源ID
    ''' </summary>
    Public MustOverride ReadOnly Property ResourceID As Integer
    ''' <summary>
    ''' 背景图片中哪些部分需要被堆叠
    ''' </summary>
    Public MustOverride ReadOnly Property TileRectangle As Rect
    ''' <summary>
    ''' 光照强度
    ''' </summary>
    Public Property SpotLight As SpotLightInformation
End Class
