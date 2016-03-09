Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class RailgunParticleSystem
        Inherits ParticleSystem(Of RailgunParticle)
        Sub New(Target As Vector2)
            MyBase.New
            Me.Target = Target
        End Sub
        Public ReadOnly Property Target As Vector2
        Public Property Foreground As Color = Colors.DodgerBlue
        Public Overrides Property Particles As New Queue(Of RailgunParticle)
        Public Overrides ReadOnly Property Presenter As GameVisualView = New RailgunParticleSystemView(Me)
        Public Overrides Property SpawnCount As Integer = 400
        Public Overrides Property SpawnDuration As Integer = 0
        Public Overrides Property SpawnInterval As Integer = 1
        Dim progress% = 1
        Shared rnd As New Random
        Protected Overrides Function CreateParticle() As RailgunParticle
            Dim InitLoc As Vector2 = If(rnd.NextDouble < 0.4, New Vector2, New Vector2(CSng(rnd.NextDouble * 6 + 5 * Math.Cos(progress / 4)) - 5.5F, CSng(rnd.NextDouble * 6 + 5 * Math.Sin(progress / 4)) - 5.5F))
            Return New RailgunParticle(New Vector2(CSng(rnd.NextDouble / 200 - 0.0025), CSng(rnd.NextDouble / 200 - 0.0025)), CInt(rnd.NextDouble * 10) + 110, InitLoc + Location + (Target - Location) * CSng(Threading.Interlocked.Increment(progress) / SpawnCount), New Vector2, Foreground)
        End Function
    End Class
End Namespace
