Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 用于指定构造函数，属性和字段对编辑器可见。如果不写这个属性或者不是Public(在c#为public)则编辑器会跳过。
    ''' </summary>
    <AttributeUsage(AttributeTargets.Constructor Or AttributeTargets.Property Or AttributeTargets.Field)>
    Public Class N2DesignerVisibleAttribute
        Inherits Attribute
        Sub New()

        End Sub
        Sub New(DesignToolSelectionOverride As DesignToolSelections)
            DesignToolSelection = DesignToolSelectionOverride
        End Sub
        ''' <summary>
        ''' 指定属性和字段使用的设计工具
        ''' </summary>
        Public ReadOnly Property DesignToolSelection As DesignToolSelections
    End Class
End Namespace
