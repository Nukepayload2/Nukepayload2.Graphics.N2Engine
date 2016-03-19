Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class RailgunParticleSystemView
        Inherits TypedGameVisualPresenter(Of RailgunParticleSystem)
        Sub New(Target As RailgunParticleSystem)
            MyBase.New(Target)
        End Sub
        Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
            '绘制当前粒子系统的代码
            Using cl As New CanvasCommandList(DrawingSession), ds = cl.CreateDrawingSession
                For Each part In Target.Particles
                    ds.FillCircle(part.Location, 1, part.Foreground)
                Next
                DrawingSession.DrawImage(cl)
            End Using
        End Sub
        Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

        End Sub
    End Class

End Namespace
