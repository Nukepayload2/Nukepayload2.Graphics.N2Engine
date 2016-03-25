Namespace Global.Nukepayload2.Graphics.N2Engine
    <ToolboxItemVisible>
    Public Class Dropper
        Inherits Organs

        Public Overrides Property Description As String = "能把物品抛射到近处的机器"
        Public Overrides Property Name As String = "抛射器"
        Public Overrides Property TargetType As Type = GetType(ImageBlock)
    End Class
End Namespace