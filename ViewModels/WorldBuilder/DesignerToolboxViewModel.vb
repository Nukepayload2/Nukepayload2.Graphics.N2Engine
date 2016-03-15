Imports System.Reflection

Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class DesignerToolboxViewModel
        ''' <summary>
        ''' 包含工具栏的动态信息。
        ''' 其中，分类名<see cref="ToolboxItem.Category"/>, 组名Group, 工具名<see cref="ToolboxItem.Name"/>, 工具描述<see cref="ToolboxItem.Description"/>
        ''' </summary>
        Public ReadOnly Property ToolboxGroups As IEnumerable
        Sub New()
            Dim myType = Me.GetType
            Dim myNamespace = myType.Namespace
            Dim asm = Me.GetType.GetTypeInfo.Assembly
            ToolboxGroups = From tp In asm.GetTypes
                            Where tp.GetTypeInfo.GetCustomAttributes(Of ToolboxItemVisibleAttribute).Any AndAlso
                                GetType(ToolboxItem).IsAssignableFrom(tp)
                            Select instance = DirectCast(Activator.CreateInstance(tp), ToolboxItem), tp
                            Select tp, instance.Name, instance.Description, instance.Category
                            Group By Category Into Group
        End Sub
    End Class
End Namespace