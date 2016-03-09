Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Interface IParticleSystem(Of TParticle As IParticle)
        ''' <summary>
        ''' 关联哪种粒子
        ''' </summary>
        Property Particles As Queue(Of TParticle)
        ''' <summary>
        ''' 每多少帧产生一次粒子。最小值是1
        ''' </summary>
        Property SpawnInterval%
        ''' <summary>
        ''' 每次释放多少个粒子
        ''' </summary>
        Property SpawnCount%
        ''' <summary>
        ''' 释放多少帧
        ''' </summary>
        Property SpawnDuration%
    End Interface
End Namespace
