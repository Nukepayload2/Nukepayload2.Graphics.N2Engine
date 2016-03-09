Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示能够设定偏色和大小的火焰粒子
    ''' </summary>
    Public Class FlameParticle
        Inherits Particle
        Public Sub New(acceleration As Vector2, lifeTime As Integer, location As Vector2, velocity As Vector2)
            MyBase.New(acceleration, lifeTime, location, velocity)
        End Sub
        Public M51 As Single = 3
        Public M52 As Single = 0.5
        Public M53 As Single = 0.2
    End Class
End Namespace
