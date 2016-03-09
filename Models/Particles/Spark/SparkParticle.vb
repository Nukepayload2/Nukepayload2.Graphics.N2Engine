Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SparkParticle
        Inherits Particle
        Public Sub New(acceleration As Vector2, lifeTime As Integer, location As Vector2, velocity As Vector2)
            MyBase.New(acceleration, lifeTime, location, velocity)
        End Sub
        Public Property Mass As Single = 10.0 '质量大小
        Public Property SparkSize As Single = 1 '粒子图像的大小
        Public Property SparkColor As Color '粒子颜色
        Public Property MaxSpeed! = 5

        Public Overrides Sub Update()
            MyBase.Update()
            Velocity.LimitMag(MaxSpeed)
        End Sub
    End Class
End Namespace
