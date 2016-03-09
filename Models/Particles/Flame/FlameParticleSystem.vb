Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示某种火焰粒子系统
    ''' </summary>
    Public MustInherit Class FlameParticleSystem
        Inherits ParticleSystem(Of FlameParticle)

        Public Overrides Property Particles As New Queue(Of FlameParticle)
        Public Overrides ReadOnly Property Presenter As GameVisualView = New FlameParticleSystemView(Me)
        Public Overrides Property SpawnCount As Integer = 1
        Public Overrides Property SpawnDuration As Integer = 600
        Public Overrides Property SpawnInterval As Integer = 6
        Public Property FlameSize As Integer = 40

    End Class

End Namespace
