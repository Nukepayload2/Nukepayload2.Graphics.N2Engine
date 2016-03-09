Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 阵营所在的边，又称大阵营。
    ''' </summary>
    Public MustInherit Class Side
        ''' <summary>
        ''' 显示名称
        ''' </summary>
        Public MustOverride ReadOnly Property DisplayName$
        ''' <summary>
        ''' 默认的颜色
        ''' </summary>
        Public MustOverride ReadOnly Property DefaultColor As Color
    End Class
End Namespace
