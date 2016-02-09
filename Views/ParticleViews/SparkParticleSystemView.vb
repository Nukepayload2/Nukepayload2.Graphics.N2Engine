Public Class SparkParticleSystemView
    Inherits TypedGameVisualPresenter(Of SparkParticleSystem)
    Sub New(Target As SparkParticleSystem)
        MyBase.New(Target)
    End Sub
    Public Overrides Sub OnDraw(sender As GamePanelView, DrawingSession As CanvasDrawingSession)
        '绘制当前粒子系统的代码
        Using cl As New CanvasCommandList(DrawingSession), ds = cl.CreateDrawingSession
            For Each SubPartial In Target.Particles
                ds.FillCircle(SubPartial.Location, SubPartial.SparkSize, SubPartial.SparkColor)
            Next
            DrawingSession.DrawImage(cl)
        End Using
    End Sub
    Public Overrides Sub OnGlobalQualityChanged(Quality As GraphicQualityManager)

    End Sub
End Class
