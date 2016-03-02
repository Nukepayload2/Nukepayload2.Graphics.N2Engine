''' <summary>
''' 可视物体的基类
''' </summary>
Public MustInherit Class GameVisual
    ''' <summary>
    ''' 同类的动画Z序越高越靠外，反之靠里。注意：<see cref="StaticVisual"/>总是比<see cref="AnimatedVisual"/>靠里。有时需要多创建一些<see cref="GamePanelView"/>来打破这个规则。
    ''' </summary>
    Public Property ZIndex As Integer
    ''' <summary>
    ''' 物体的位置。这通常是物体的左上角。
    ''' </summary>
    Public Property Location As Vector2
    ''' <summary>
    ''' 派生类继承时在构造函数指定物体的物理属性以便于进行模拟。如果这个物体是一般的贴图则此属性留空。
    ''' </summary>
    Public Property Collision As Box2D.Body
    ''' <summary>
    ''' 用于放置绘制代码
    ''' </summary>
    Public MustOverride ReadOnly Property Presenter As GameVisualView
End Class