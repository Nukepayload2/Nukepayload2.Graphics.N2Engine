Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class GasParticleSystem
        Inherits ParticleSystem(Of GasParticle)
        Sub New(Foreground As BitmapAnimation)
            MyBase.New
            Me.Foreground = Foreground
        End Sub
        Dim LoopStart%, LoopEnd%, Rate%
        Public Property Foreground As BitmapAnimation
        Public Overrides Property Particles As New Queue(Of GasParticle)
        Public Overrides ReadOnly Property Presenter As GameVisualView = New GasParticleSystemView(Me)
        Public Overrides Property SpawnCount As Integer = 1
        Public Overrides Property SpawnDuration As Integer = 0
        Public Overrides Property SpawnInterval As Integer = 1
        Shared rnd As New Random
        Protected Overrides Function CreateParticle() As GasParticle
            Return New GasParticle(New Vector2, Rate * (LoopEnd - LoopStart + 1), Location, New Vector2, Foreground)
        End Function
    End Class
End Namespace

