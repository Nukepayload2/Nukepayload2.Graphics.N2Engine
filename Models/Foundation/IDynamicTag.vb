Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 具备拓展能力的标签
    ''' </summary>
    Public Interface IDynamicTag
        ''' <summary>
        ''' 用于存储拓展的属性。使用<see cref="Dynamic.ExpandoObject"/>存放内容。使用此成员时请设置Option Strict Off (Visual Basic) 或者用 dynamic 关键字 (Visual C#)
        ''' </summary>
        ReadOnly Property Tag As Object
    End Interface
End Namespace