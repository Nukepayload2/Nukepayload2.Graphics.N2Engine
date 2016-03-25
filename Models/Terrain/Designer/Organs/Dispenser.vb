Namespace Global.Nukepayload2.Graphics.N2Engine
    <ToolboxItemVisible>
    Public Class Dispenser
        Inherits Organs

        Public Overrides Property Description As String = "能够快速发射物品的机器。被砸中的物体可能会受损。"
        Public Overrides Property Name As String = "发射器"
        Public Overrides Property TargetType As Type = GetType(ImageBlock)
    End Class
End Namespace