Public MustInherit Class Projectile
    ''' <summary>
    ''' 抛射体轨迹
    ''' </summary>
    Public Property Track As ProjectileTrack
    ''' <summary>
    ''' 移动弹丸
    ''' </summary>
    Public MustOverride Sub Update()
    ''' <summary>
    ''' 弹丸的动画，多用于火箭，炮弹等。
    ''' </summary>
    Public Property Animation As DynamicBitmapAnimation
    ''' <summary>
    ''' 现在弹丸位于哪里
    ''' </summary>
    Public Property Location As Vector2
    ''' <summary>
    ''' 是否已经命中目标或者由于距离太远而被废弃。这个值由命中测试进行判断。
    ''' </summary>
    Public Property IsHitOrAbandoned As Boolean
    ''' <summary>
    ''' 如果不是轨迹不是直线, 则要指定贝塞尔曲线的控制点的位置
    ''' </summary>
    Public Property BezelControlPoint As Vector2?
End Class