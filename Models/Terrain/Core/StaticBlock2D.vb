Option Strict Off
Imports Microsoft.Graphics.Canvas.Brushes
Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 静态呈现的带有碰撞功能的方块的游戏对象的基类
    ''' </summary>
    Public MustInherit Class StaticBlock2D
        Inherits StaticVisual
        Sub New(Region As Rect)
            Me.Width = Region.Width
            Me.Height = Region.Height
            Location = New Vector2(Region.X, Region.Y)
        End Sub
        Sub New(width As Single, height As Single)
            Me.Width = width
            Me.Height = height
        End Sub
        ''' <summary>
        ''' 碰撞的模式。默认情况下忽略一切碰撞。
        ''' </summary>
        <N2DesignerVisible>
        Public Property CollisionMode As BlockCollisionModes
        ''' <summary>
        ''' 如果<see cref="CollisionMode"/>为<see cref="BlockCollisionModes.Platform"/>, 这条线角色可以跳上来, 但是必须通过特殊指令跳下。此时<see cref="Collision"/>和<see cref="Outline"/>不会影响角色的跳跃行为。
        ''' </summary>
        <N2DesignerVisible(DesignToolSelections.ObjectEditor)>
        Public Property PlatformLine As Tuple(Of Vector2, Vector2)
        ''' <summary>
        ''' 方块的宽度。此数据将覆盖<see cref="Outline"/>。
        ''' </summary>
        <N2DesignerVisible>
        Public Property Width!
        ''' <summary>
        ''' 方块的高度。此数据将覆盖<see cref="Outline"/>。
        ''' </summary>
        <N2DesignerVisible>
        Public Property Height!
    End Class
    Public MustInherit Class AnimatedBlock2D
        Inherits AnimatedVisual

    End Class
    ''' <summary>
    ''' 特定的静态呈现的方块
    ''' </summary>
    ''' <typeparam name="TBrush">方块的呈现方式</typeparam>
    Public MustInherit Class StaticBlock2D(Of TBrush As ICanvasBrush)
        Inherits StaticBlock2D
        Sub New(Region As Rect)
            MyBase.New(Region)
        End Sub
        Sub New(width As Single, height As Single)
            MyBase.New(width, height)
        End Sub
        ''' <summary>
        ''' 表示如何填充这个方块。创建绘制资源的时候才会创建它。
        ''' </summary>
        Public Property Fill As New Dictionary(Of ICanvasResourceCreator, TBrush)
    End Class
End Namespace
