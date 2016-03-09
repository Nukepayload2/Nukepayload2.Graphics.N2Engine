Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 由单位或触发发出的武器
    ''' </summary>
    Public MustInherit Class Weapon
        Sub New()

        End Sub
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
        Public Property MinRange! = 4
        ''' <summary>
        ''' 抛射体
        ''' </summary>
        Public Property Projectile As Projectile
        ''' <summary>
        ''' 附加的粒子系统。每次开火的时候会释放这种粒子。
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
End Namespace
