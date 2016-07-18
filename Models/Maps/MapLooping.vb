Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示地图的循环
    ''' </summary>
    Public Class MapLooping
        ''' <summary>
        ''' 地图的循环模式
        ''' </summary>
        Public Property MapLoopMode As MapLoopMode
        ''' <summary>
        ''' 人物横向距离边缘多少Tile的时候横向卷动
        ''' </summary>
        Public Property AutoScrollX As Integer
        ''' <summary>
        ''' 人物纵向距离边缘多少Tile的时候纵向卷动
        ''' </summary>
        Public Property AutoScrollY As Integer
    End Class
    ''' <summary>
    ''' 表示地图的循环模式
    ''' </summary>
    Public Enum MapLoopMode
        None
        LoopX
        LoopY
        Both
    End Enum
End Namespace