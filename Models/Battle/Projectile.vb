Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示武器的抛射体
    ''' </summary>
    Public MustInherit Class Projectile
        Sub New(SourceWeapon As Weapon)
            Me.SourceWeapon = SourceWeapon
        End Sub
        Sub New()

        End Sub
        ''' <summary>
        ''' 发射的武器
        ''' </summary>
        Public Property SourceWeapon As Weapon
        ''' <summary>
        ''' 抛射体轨迹。可以在每次Update的时候修改轨迹实现追踪和偏转效果。
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
        ''' 弹丸的速度。如果不指定则会立即击中。
        ''' </summary>
        Public Property Speed As Vector2?
        ''' <summary>
        ''' 是否能够飞向较高的单位
        ''' </summary>
        Public Property AntiAir As Boolean
        ''' <summary>
        ''' 是否攻击潜艇单位。这个功能在有潜水设定的游戏才有用。
        ''' </summary>
        Public Property AntiSubmarine As Boolean
    End Class
End Namespace
