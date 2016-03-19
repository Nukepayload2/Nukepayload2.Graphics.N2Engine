Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SparkParticleSystemView
        Inherits TypedGameVisualPresenter(Of SparkParticleSystem)
        Sub New(Target As SparkParticleSystem)
            MyBase.New(Target)
        End Sub
        Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession, Canvas As ICanvasResourceCreator)
            '绘制当前粒子系统的代码
            Using cl As New CanvasCommandList(DrawingSession), ds = cl.CreateDrawingSession
                For Each part In Target.Particles
                    ds.FillCircle(part.Location, part.SparkSize, part.SparkColor)
                Next
                DrawingSession.DrawImage(cl)
            End Using
        End Sub
        Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

        End Sub
    End Class

End Namespace
