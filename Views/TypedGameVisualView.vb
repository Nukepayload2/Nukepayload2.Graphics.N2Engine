''' <summary>
''' 某种类型的可视对象视图, 使用Win2D绘制。
''' </summary>
''' <typeparam name="T">游戏可视对象类型</typeparam>
Public MustInherit Class TypedGameVisualPresenter(Of T As GameVisual)
    Inherits GameVisualView
    Protected Target As T
    Sub New(Target As T)
        Me.Target = Target
    End Sub
End Class