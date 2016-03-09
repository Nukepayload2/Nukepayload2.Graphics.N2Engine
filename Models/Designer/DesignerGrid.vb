Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 设计器用于对齐的网格
    ''' </summary>
    Public Class DesignerGrid
        ''' <summary>
        ''' 将物体的位置和大小对齐到多少倍。设置为小于等于1的数字的话会关闭这个功能。
        ''' </summary>
        Public Property GridAlignment As Integer = 32
        ''' <summary>
        ''' 将指定的数字向下对齐到<see cref="GridAlignment"/>
        ''' </summary>
        ''' <param name="source">需要对齐的数字</param>
        Public Function FloorAlign#(source#)
            source -= source Mod GridAlignment
            Return source
        End Function
        ''' <summary>
        ''' 将指定的数字向上对齐到<see cref="GridAlignment"/>
        ''' </summary>
        ''' <param name="source">需要对齐的数字</param>
        Public Function CeilingAlign#(source#)
            source -= source Mod GridAlignment
            Return source + GridAlignment
        End Function
    End Class
End Namespace
