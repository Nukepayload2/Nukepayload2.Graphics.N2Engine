Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class GasParticle
        Inherits ImageParticle
        Sub New(acceleration As Vector2, lifeTime As Integer, location As Vector2, velocity As Vector2, Foreground As BitmapAnimation)
            MyBase.New(acceleration, lifeTime, location, velocity, Foreground)
        End Sub
    End Class

End Namespace
