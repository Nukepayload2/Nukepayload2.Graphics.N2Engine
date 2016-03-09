﻿Imports Microsoft.Graphics.Canvas.Brushes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class StaticBlock2D
        Inherits StaticVisual

        Public Sub New(width As Single, height As Single, fill As ICanvasBrush)
            Me.Width = width
            Me.Height = height
            Me.Fill = fill
        End Sub
        ''' <summary>
        ''' 碰撞的模式。默认情况下忽略一切碰撞。
        ''' </summary>
        Public Property CollisionMode As BlockCollisionModes
        ''' <summary>
        ''' 如果<see cref="CollisionMode"/>为<see cref="BlockCollisionModes.Platform"/>, 这条线角色可以跳上来, 但是必须通过特殊指令跳下。此时<see cref="Collision"/>和<see cref="Outline"/>不会影响角色的跳跃行为。
        ''' </summary>
        ''' <returns></returns>
        Public Property PlatformLine As Tuple(Of Vector2, Vector2)
        ''' <summary>
        ''' 方块的宽度。此数据将覆盖<see cref="Outline"/>。
        ''' </summary>
        Public Property Width!
        ''' <summary>
        ''' 方块的高度。此数据将覆盖<see cref="Outline"/>。
        ''' </summary>
        Public Property Height!
        ''' <summary>
        ''' 表示如何填充这个方块
        ''' </summary>
        Public Property Fill As ICanvasBrush
        Public Overrides ReadOnly Property Presenter As GameVisualView = New BlockView(Me)
    End Class
End Namespace
