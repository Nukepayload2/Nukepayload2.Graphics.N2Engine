Namespace Global.Nukepayload2.Graphics.N2Engine
    <ToolboxItemVisible>
    Public Class SparkGenerator
        Inherits ParticleSystemThrowers

        Public Overrides Property Description As String = "产生火花粒子系统"
        Public Overrides Property Name As String = "火花"
        Public Overrides Property TargetType As Type = GetType(FlameParticleSystem)
    End Class
End Namespace