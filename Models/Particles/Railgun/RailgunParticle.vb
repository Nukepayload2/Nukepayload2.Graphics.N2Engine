Public Class RailgunParticle
    Inherits Particle
    Public ReadOnly Property Foreground As Color
    Sub New(acceleration As Vector2, lifeTime As Integer, location As Vector2, velocity As Vector2, Foreground As Color)
        MyBase.New(acceleration, lifeTime, location, velocity)
        Me.Foreground = Foreground
    End Sub
    Shared rnd As New Random
    Public Overrides Sub Update()
        MyBase.Update()
        Dim col = Foreground
        col.A = CByte(255 - Math.Min(255, Age / LifeTime))
        _Foreground = col
    End Sub
End Class