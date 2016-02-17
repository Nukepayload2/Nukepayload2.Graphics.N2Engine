Public MustInherit Class BattleUnit
    ''' <summary>
    ''' 生命的上限
    ''' </summary>
    Public ReadOnly Property MaxStrength!
    ''' <summary>
    ''' 强度。如果小于0则会被摧毁。
    ''' </summary>
    Public Property Strength!
    ''' <summary>
    ''' 武器和它们的位置
    ''' </summary>
    Public Property Weapons As IDictionary(Of Weapon, Vector2)
    ''' <summary>
    ''' 装甲
    ''' </summary>
    Public Property Ammor As Ammor
    ''' <summary>
    ''' 正常工作时产生的粒子系统
    ''' </summary>
    Public Property NormalParticleSystems As ParticleSystem(Of IParticle)
    ''' <summary>
    ''' 受伤的时候产生的粒子系统
    ''' </summary>
    Public Property DamageParticleSystems As ParticleSystem(Of IParticle)
    ''' <summary>
    ''' 被破坏的声音
    ''' </summary>
    Public MustOverride Sub PlayCrushSound()
    ''' <summary>
    ''' 被摧毁时产生的粒子系统
    ''' </summary>
    Public Property Debris As ParticleSystem(Of IParticle)
End Class