Imports System.Reflection
''' <summary>
''' 表示设计器的工具箱里面的东西
''' </summary>
Public MustInherit Class ToolboxItem
    ''' <summary>
    ''' 分类名。通常自带的对象在<see cref="TerrainCategories"/>中选取分类名。
    ''' </summary>
    Public MustOverride Property Category$
    ''' <summary>
    ''' 这个场景物体叫什么
    ''' </summary>
    Public MustOverride Property Name$
    ''' <summary>
    ''' 介绍这个场景物体
    ''' </summary>
    Public MustOverride Property Description$
    ''' <summary>
    ''' 目标<see cref="GameVisual"/>的类型名
    ''' </summary>
    Public MustOverride Property TargetTypeName$
    ''' <summary>
    ''' 当前使用的构造函数中的参数代码
    ''' </summary>
    Public Property ConstructorFillCode As String
    ''' <summary>
    ''' 已经填过的属性。存放属性名和具体的属性操作语句。
    ''' </summary>
    Public Property FilledProperties As Tuple(Of String, String)()
    ''' <summary>
    ''' 从当前程序集检索目标具体的<see cref="ToolboxItem"/>类型。如果找不到则返回空。
    ''' </summary>
    Public Function TrySearchTargetType() As Type
        If String.IsNullOrEmpty(TargetTypeName) Then Return Nothing
        Dim asm = Me.GetType.GetTypeInfo.Assembly
        Return asm.GetType(TargetTypeName, False, False)
    End Function
End Class