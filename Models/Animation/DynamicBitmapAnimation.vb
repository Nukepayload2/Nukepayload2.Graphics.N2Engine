''' <summary>
''' 带有动态信息的动画。但由于动态性能较低，此类动画中的动态信息多用于Mod。
''' </summary>
Public Class DynamicBitmapAnimation
    Inherits BitmapAnimation
    ''' <summary>
    ''' 用于存储拓展的属性。使用<see cref="Dynamic.ExpandoObject"/>存放内容。使用此成员时请设置Option Strict Off (Visual Basic) 或者用 dynamic 关键字 (Visual C#)
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property DynamicBag As Object = New Dynamic.ExpandoObject
End Class