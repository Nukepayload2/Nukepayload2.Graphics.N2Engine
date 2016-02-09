Option Strict Off
Imports Microsoft.Graphics.Canvas.Geometry

Public Class FlameParticleSystemView
    Inherits TypedGameVisualPresenter(Of FlameParticleSystem)
    Public Sub New(flamePartialSystem As FlameParticleSystem)
        MyBase.New(flamePartialSystem)
    End Sub
    Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
        For Each part In Target.Particles
            Using textCommandList As New CanvasCommandList(DrawingSession),
                ds = textCommandList.CreateDrawingSession()
                ds.Clear(Color.FromArgb(0, 0, 0, 0))
                Dim CurFlameSize = Target.FlameSize * ((part.Age / part.LifeTime) ^ 2)
                Dim centerPoint As New Vector2(0, CurFlameSize * 1.4)
                Using FlameEffect As New Transform2DEffect With
                {
                    .Source = New DisplacementMapEffect With
                    {
                        .Source = New ColorMatrixEffect With
                        {
                            .Source = New GaussianBlurEffect With
                            {
                                .Source = New MorphologyEffect With
                                {
                                    .Source = textCommandList,
                                    .Mode = MorphologyEffectMode.Dilate,
                                    .Width = 7,
                                    .Height = 1
                                },
                                .BlurAmount = 3.0F
                            },
                            .ColorMatrix = New Matrix5x4 With
                            {
                                .M42 = 1.0F, .M44 = 1.0F - CSng((part.Age / part.LifeTime) ^ 2),
                                .M51 = part.M51, .M52 = part.M52, .M53 = part.M53
                            }
                        },
                        .Displacement = New Transform2DEffect With
                        {
                            .Source = New BorderEffect With
                            {
                                .Source = New TurbulenceEffect With
                                {
                                    .Frequency = New Vector2(0.109F, 0.109F),
                                    .Size = New Vector2(500.0F, 80.0F)
                                },
                                .ExtendX = CanvasEdgeBehavior.Mirror,
                                .ExtendY = CanvasEdgeBehavior.Mirror
                            },
                            .TransformMatrix = Matrix3x2.CreateTranslation(0, -part.Age / 4)
                        },
                        .Amount = 40.0F
                    },
                    .TransformMatrix = Matrix3x2.CreateScale(1, 2, centerPoint)}
                    'Dim pathb As New CanvasPathBuilder(ds)
                    'pathb.BeginFigure(New Vector2(CurFlameSize / 2, 0))
                    'pathb.AddCubicBezier(New Vector2(0, CurFlameSize * 2), New Vector2(CurFlameSize, CurFlameSize * 2), New Vector2(CurFlameSize / 2, 0))
                    'pathb.EndFigure(CanvasFigureLoop.Closed)
                    'ds.FillGeometry(CanvasGeometry.CreatePath(pathb), New Vector2(CurFlameSize / 2, 0), Colors.White)
                    ds.FillCircle(New Vector2, CurFlameSize, Colors.White)
                    DrawingSession.DrawImage(FlameEffect, part.Location)
                End Using
            End Using
        Next
    End Sub
    Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

    End Sub
End Class
