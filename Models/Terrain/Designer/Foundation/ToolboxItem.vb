Imports System.Reflection

Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示设计器的工具箱里面的东西。它必须有无参数的构造函数。
    ''' </summary>
    Public MustInherit Class ToolboxItem
        ''' <summary>
        ''' 分类名。通常自带的对象在<see cref="TerrainCategories"/>中选取分类名。
        ''' </summary>
        Public MustOverride Property Category$
        ''' <summary>
        ''' 这个工具箱物件叫什么
        ''' </summary>
        Public MustOverride Property Name$
        ''' <summary>
        ''' 介绍这个工具箱物件
        ''' </summary>
        Public MustOverride Property Description$
        ''' <summary>
        ''' 目标<see cref="GameVisual"/>的类型名
        ''' </summary>
        Public MustOverride Property TargetType As Type
        ''' <summary>
        ''' 当前使用的构造函数中的参数代码
        ''' </summary>
        Public Property ConstructorFillCode As String
        ''' <summary>
        ''' 已经填过的属性。存放属性名和具体的属性操作语句。
        ''' </summary>
        Public Property FilledProperties As Tuple(Of String, String)()

        ''' <summary>
        ''' 筛选全部公共的非共享(在Visual C#为static)构造函数, 并返回声明
        ''' </summary>
        ''' <param name="target">要分析的类型</param>
        Public Iterator Function FilterConstructors(target As Type) As IEnumerable(Of String)
            Dim objv As New ObjectViewer
            For Each ctor In target.GetConstructors
                If ctor.IsPublic AndAlso Not ctor.IsStatic Then
                    Yield objv.AnalyzeConstructor(ctor, False)
                End If
            Next
        End Function
    End Class
End Namespace