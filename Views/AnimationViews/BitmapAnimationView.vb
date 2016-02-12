Imports 红警杀手机版

Public Class BitmapAnimationView
    Inherits TypedGameVisualPresenter(Of BitmapAnimation)
    Sub New(target As BitmapAnimation)
        MyBase.New(target)
    End Sub
    Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
        Using cl = New CanvasCommandList(DrawingSession), ds = cl.CreateDrawingSession
            Dim OriginalImage = Target.Frames(Target.GetImageIndex(Target.FrameCount))
            Dim CurImg As ICanvasImage = OriginalImage
            If Target.Effect IsNot Nothing Then
                If Target.Perspective.HasValue Then
                    Throw New InvalidOperationException($"如果指定了{NameOf(Target.Perspective)}, 则不能使用Effect。")
                End If
                Target.SetEffectSource.Invoke(CurImg)
                CurImg = Target.Effect
            End If
            If Target.Transform.HasValue Then
                ds.Transform = Target.Transform.Value
            End If
            If Target.Perspective.HasValue Then
                DrawingSession.DrawImage(OriginalImage, Target.Location, New Rect(Target.Location.ToPoint, OriginalImage.Size), Target.Opacity, CanvasImageInterpolation.NearestNeighbor, Target.Perspective.Value)
            Else
                DrawingSession.DrawImage(CurImg, Target.Location, New Rect(Target.Location.ToPoint, OriginalImage.Size), Target.Opacity, CanvasImageInterpolation.NearestNeighbor)
            End If
            DrawingSession.DrawImage(cl)
        End Using
    End Sub

    Public Overrides Sub OnDrawMinimap(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
        '这一类动画画到小地图上回影响小地图的效果，不要在小地图绘制。

    End Sub
    Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

    End Sub
End Class
