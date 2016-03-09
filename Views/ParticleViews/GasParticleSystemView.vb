Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class GasParticleSystemView
        Inherits TypedGameVisualPresenter(Of GasParticleSystem)
        Sub New(Target As GasParticleSystem)
            MyBase.New(Target)
        End Sub
        Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
            '绘制当前粒子系统的代码
            Using cl As New CanvasCommandList(DrawingSession), ds = cl.CreateDrawingSession
                For Each part In Target.Particles
                    ds.DrawImage(part.Foreground.Frames(part.ImageIndex))
                Next
                DrawingSession.DrawImage(cl)
            End Using
        End Sub
        Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

        End Sub
    End Class

End Namespace
