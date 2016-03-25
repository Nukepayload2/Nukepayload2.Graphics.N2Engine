Namespace Global.Nukepayload2.Graphics.N2Engine
    <ToolboxItemVisible>
    Public Class FlameThrower
        Inherits ParticleSystemThrowers

        Public Overrides Property Description As String = "火焰粒子系统"
        Public Overrides Property Name As String = "火焰"
        Public Overrides Property TargetType As Type = GetType(FlameParticleSystem)
    End Class
End Namespace