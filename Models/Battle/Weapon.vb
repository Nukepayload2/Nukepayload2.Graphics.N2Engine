Public MustInherit Class Weapon
    ''' <summary>
    ''' 伤害
    ''' </summary>
    Public Property Damage!
    ''' <summary>
    ''' 开火频率
    ''' </summary>
    Public Property RateOfFire%
    ''' <summary>
    ''' 攻击范围外径
    ''' </summary>
    Public Property Range!
    ''' <summary>
    ''' 攻击范围内径
    ''' </summary>
    Public Property MinRange! = 0
    ''' <summary>
    ''' 抛射体
    ''' </summary>
    Public Property Projectile As Projectile
    ''' <summary>
    ''' 附加的粒子系统
    ''' </summary>
    Public Property AttachedParticleSystem As IParticleSystem(Of IParticle)
    ''' <summary>
    ''' 一次发射几个这种武器
    ''' </summary>
    Public Property Burst% = 1
    ''' <summary>
    ''' 开火声音
    ''' </summary>
    Public MustOverride Sub PlayReport()
    ''' <summary>
    ''' 开火动画
    ''' </summary>
    Public Property ShootingAnimation As BitmapAnimation
End Class