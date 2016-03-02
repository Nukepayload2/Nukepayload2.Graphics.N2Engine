Imports Microsoft.Graphics.Canvas.Geometry

Public Class TiledBackgroundView
    Inherits TypedGameVisualPresenter(Of TiledBackground)
    Sub New(target As TiledBackground)
        MyBase.New(target)
    End Sub
    Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
        Using tile = New TileEffect() With {
                .Source = sender.AnimatedImageManager.GetResource(Target.ResourceID),
                .SourceRectangle = New Rect(0, 0, 58, 58)
            },
            lightdif = New PointDiffuseEffect With {
                .Source = tile, .LightColor = Target.SpotLight.LightColor, .LightColorHdr = Target.SpotLight.LightHDR,
                .LightPosition = Target.SpotLight.LightPosition, .DiffuseAmount = Target.SpotLight.DiffuseAmount
            },
            lightspe = New PointSpecularEffect With {
                .Source = tile, .LightColor = Target.SpotLight.LightColor, .LightColorHdr = Target.SpotLight.LightHDR,
                .LightPosition = Target.SpotLight.LightPosition, .SpecularAmount = Target.SpotLight.SpecularAmount,
                .SpecularExponent = Target.SpotLight.SpecularExponent
            },
            composite = New ArithmeticCompositeEffect With {
                .Source1 = lightdif, .Source1Amount = 0.5,
                .Source2 = lightspe, .Source2Amount = 0.5
            },
            composite2 = New ArithmeticCompositeEffect With {
                .Source1 = composite, .Source1Amount = Target.SpotLight.LightStrength, .MultiplyAmount = Target.SpotLight.SpriteBrightness,
                .Source2 = tile, .Source2Amount = Target.SpotLight.SpriteBrightness
            }
            If Target.SpotLight.LightCollision IsNot Nothing Then
                Using layer = DrawingSession.CreateLayer(Target.SpotLight.SpriteBrightness)
                    DrawingSession.DrawImage(tile)
                End Using
                Dim lightpos2d = New Vector2(Target.SpotLight.LightPosition.X, Target.SpotLight.LightPosition.Y)
                Dim clipgeo = New LightClipCalculator().CalculateClipGeometry(DrawingSession, lightpos2d, Target.SpotLight.LightCollision, sender.Panel.SpaceSize)
                Dim clipsrc = CanvasGeometry.CreateGroup(DrawingSession, {
                                                            clipgeo,
                                                            CanvasGeometry.CreateRectangle(DrawingSession, New Rect(New Point, sender.Panel.SpaceSize))
                                                         })
                Using layer = DrawingSession.CreateLayer(1, clipsrc)
                    DrawingSession.DrawImage(composite2)
                End Using
            Else
                DrawingSession.DrawImage(composite2)
            End If
        End Using
    End Sub
    '光照效果不要画到小地图上面
    Public Overrides Sub OnDrawMinimap(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
        Using tile = New TileEffect() With {
                .Source = sender.AnimatedImageManager.GetResource(Target.ResourceID),
                .SourceRectangle = New Rect(0, 0, 58, 58)
            }
            DrawingSession.DrawImage(tile)
        End Using
    End Sub
    Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

    End Sub
End Class
