Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示鼠标光标。编辑器选定这个项目时或者单击鼠标右键时进入选择物体的模式。
    ''' </summary>
    Public Class InputPointer
        Inherits ToolboxItem

        Public Overrides Property Category As String = TerrainCategories.Preserved
        Public Overrides Property Description As String = "代表输入设备的指针, 如鼠标光标。"
        Public Overrides Property Name As String = "指针"
        Public Overrides Property TargetTypeName As String
    End Class
End Namespace
