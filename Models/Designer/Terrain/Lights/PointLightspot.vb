Namespace Global.Nukepayload2.Graphics.N2Engine
    <ToolboxItemVisible>
    Public Class PointLightspot
        Inherits Lights

        Public Overrides Property Description As String = "能发出光的点"
        Public Overrides Property Name As String = "点光源"
        Public Overrides Property TargetType As Type = GetType(ImageBlock)
    End Class
End Namespace