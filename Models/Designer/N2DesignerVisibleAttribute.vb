Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 用于指定构造函数，属性和字段对编辑器可见。如果不写这个属性或者不是 Public(在c#为public), 除非它的实例在某处附加了这个特效并且编辑工具指定为<see cref="DesignToolSelections.ObjectEditor"/>, 否则编辑器会跳过。
    ''' </summary>
    <AttributeUsage(AttributeTargets.Constructor Or AttributeTargets.Property Or AttributeTargets.Field)>
    Public Class N2DesignerVisibleAttribute
        Inherits Attribute
        Sub New()

        End Sub
        Sub New(DesignToolSelectionOverride As DesignToolSelections, Optional SubToolSelection As DesignToolSelections = DesignToolSelections.Auto)
            DesignToolSelection = DesignToolSelectionOverride
            Me.SubToolSelection = SubToolSelection
        End Sub
        ''' <summary>
        ''' 指定属性和字段使用的设计工具
        ''' </summary>
        Public ReadOnly Property DesignToolSelection As DesignToolSelections
        ''' <summary>
        ''' 对于<see cref="DesignToolSelection"/>为<see cref="DesignToolSelections.ArrayEditor"/>这种情况, 指定子类型使用的编辑器
        ''' </summary>
        Public ReadOnly Property SubToolSelection As DesignToolSelections
    End Class
End Namespace