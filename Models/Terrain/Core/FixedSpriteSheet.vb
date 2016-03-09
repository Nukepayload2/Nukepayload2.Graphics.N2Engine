Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 固定图块大小的图块表。用于分割一张图上的多个图片
    ''' </summary>
    Public Class FixedSpriteSheet
        Inherits SpriteSheet
        Private spritesPerRow As Integer
        Public Property SpriteSize As Vector2

        Public Sub New(bitmap As CanvasBitmap, spriteSize As Vector2, origin As Vector2)
            MyBase.New(bitmap, origin)
            Me.SpriteSize = spriteSize
            spritesPerRow = CInt(bitmap.Size.Width / spriteSize.X)
        End Sub

        Public Overrides Function GetSourceRect(sprite As Integer) As Rect
            Dim row As Integer = sprite \ spritesPerRow
            Dim column As Integer = sprite Mod spritesPerRow
            Return New Rect(CSng(SpriteSize.X * column), CSng(SpriteSize.Y * row), CSng(SpriteSize.X), CSng(SpriteSize.Y))
        End Function
    End Class
End Namespace
