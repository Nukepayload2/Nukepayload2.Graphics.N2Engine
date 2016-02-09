Option Strict Off
''' <summary>
''' 火花粒子系统
''' </summary>
Public MustInherit Class SparkParticleSystem
    Inherits ParticleSystem(Of SparkParticle)
    Implements IPartialSystem(Of SparkParticle)

    Public Overrides ReadOnly Property Presenter As GameVisualView = New SparkParticleSystemView(Me)
    Public Overrides Property Particles As New Queue(Of SparkParticle)
    Public Overrides Property SpawnCount As Integer = 1
    Public Overrides Property SpawnDuration As Integer = Integer.MaxValue
    Public Overrides Property SpawnInterval As Integer = 1

    Sub New(Location As Vector2, ParticleCount As Integer)
        Me.Location = Location
        For i = 0 To ParticleCount - 1
            Dim p = CreateParticle()
            p.Age = i
            p.Location = Location
            Particles.Enqueue(p)
        Next
    End Sub

    Protected Shared Rnd As New Random
    Protected Shared Directions() As Vector2 = {New Vector2(0, 1), New Vector2(0, -1), New Vector2(-1, 0), New Vector2(1, 0), New Vector2(0.7, 0.7), New Vector2(0.7, -0.7), New Vector2(-0.7, 0.7), New Vector2(-0.7, -0.7)}

    Protected Overrides Function CreateParticle() As SparkParticle
        Dim s As New SparkParticle(Directions(Rnd.Next(8)).RotateNew(Rnd.Next(60)) * Rnd.NextDouble, 400, Location, New Vector2) With
        {
            .Age = Rnd.NextDouble * 80,
            .SparkSize = 1 + Rnd.NextDouble * 3,
            .SparkColor = Color.FromArgb(10 + Rnd.NextDouble * 245, 255, 255, 255)
        }
        Return s
    End Function
    Public Overrides Sub Update(sender As GamePanel)
        MyBase.Update(sender)
        DeflectParticles(sender)
    End Sub
    ''' <summary>
    ''' 在粒子需要偏转的时候调用。控制粒子额外的运动形态。
    ''' </summary>
    ''' <param name="sender"></param>
    Protected MustOverride Sub DeflectParticles(sender As GamePanel)
End Class