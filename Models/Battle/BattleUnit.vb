Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 参战的单位
    ''' </summary>
    Public MustInherit Class BattleUnit
        Sub New()

        End Sub
        ''' <summary>
        ''' 生命的上限
        ''' </summary>
        Public ReadOnly Property MaxStrength!
        ''' <summary>
        ''' 强度。如果小于0则会被摧毁。
        ''' </summary>
        Public Property Strength!
        ''' <summary>
        ''' 挂载的武器和它们的位置
        ''' </summary>
        Public Property Weapons As IDictionary(Of Weapon, Vector2)
        ''' <summary>
        ''' 在死亡的时候释放的武器
        ''' </summary>
        Public Property DeathWeapon As Weapon
        ''' <summary>
        ''' 装甲
        ''' </summary>
        Public Property Ammor As Ammor
        ''' <summary>
        ''' 正常工作时产生的粒子系统
        ''' </summary>
        Public Property NormalParticleSystems As IParticleSystem(Of IParticle)
        ''' <summary>
        ''' 受伤的时候产生的粒子系统
        ''' </summary>
        Public Property DamageParticleSystems As IParticleSystem(Of IParticle)
        ''' <summary>
        ''' 被破坏的声音
        ''' </summary>
        Public MustOverride Sub PlayCrushSound()
        ''' <summary>
        ''' 被摧毁时产生的碎片粒子系统
        ''' </summary>
        Public Property Debris As IParticleSystem(Of IParticle)
    End Class
End Namespace
