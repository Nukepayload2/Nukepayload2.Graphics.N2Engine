Imports System.Dynamic

Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示游戏地图本身，不含地图上的附加物体。
    ''' </summary>
    Public Class GameMap
        Implements IDynamicTag

        Public Property Name$
        Public Property Description$
        Public Property ResourceId$
        ''' <summary>
        ''' 近景的静态装饰性分块贴图。
        ''' </summary>
        Public Property Tiles As TileDefinition(,)
        Public Property SpriteSheets As New Dictionary(Of String, Func(Of SpriteSheet))
        Public Property HorizontalTileCount As Integer
        Public Property VerticalTileCount As Integer
        Public Property Looping As MapLooping
        ''' <summary>
        ''' 地图背景远景
        ''' </summary>
        Public Property Background As CanvasBitmapLoadInformation
        Public ReadOnly Property Tag As Object = New ExpandoObject Implements IDynamicTag.Tag

    End Class
    ''' <summary>
    ''' 地图内近景装饰贴图的定义
    ''' </summary>
    Public Class TileDefinition
        Public Property SpriteSheetName As String
        Public Property Tile As Integer
        ''' <summary>
        ''' 移动中的物体是否会顺利进入这个图块内。这用于创建方形的地形阻隔。
        ''' </summary>
        Public Property IsBlocked As Boolean
    End Class
End Namespace