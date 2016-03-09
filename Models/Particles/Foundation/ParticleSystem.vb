Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 引擎实现的粒子系统一定是继承这个类的，但外部实现的不一定。
    ''' </summary>
    ''' <typeparam name="TParticle"></typeparam>
    Public MustInherit Class ParticleSystem(Of TParticle As IParticle)
        Inherits AnimatedVisual
        Implements IParticleSystem(Of TParticle)

        Public MustOverride Property Particles As Queue(Of TParticle) Implements IParticleSystem(Of TParticle).Particles
        Public MustOverride Property SpawnCount As Integer Implements IParticleSystem(Of TParticle).SpawnCount
        Public MustOverride Property SpawnDuration As Integer Implements IParticleSystem(Of TParticle).SpawnDuration
        Public MustOverride Property SpawnInterval As Integer Implements IParticleSystem(Of TParticle).SpawnInterval
        Protected MustOverride Function CreateParticle() As TParticle
        Public Overrides Sub Update(sender As GamePanel)
            MyBase.Update(sender)
            If SpawnDuration >= 0 Then
                If SpawnInterval <= 1 OrElse (SpawnDuration Mod (SpawnInterval - 1) <= 0) Then
                    For i = 1 To SpawnCount
                        Particles.Enqueue(CreateParticle())
                    Next
                End If
                SpawnDuration -= 1
            Else
                If Particles.Count = 0 Then
                    IsStopped = True
                End If
            End If
            Dim deq = 0
            For Each par In Particles
                par.Update()
                If par.Age >= par.LifeTime Then
                    deq += 1
                End If
            Next
            For i = 1 To deq
                Particles.Dequeue()
            Next
        End Sub
    End Class

End Namespace
