Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class GameObjectsHelper
        Public Property Panel As GamePanel
        Sub New(panel As GamePanel)
            Me.Panel = panel
        End Sub
        ''' <summary>
        ''' 进行点碰撞检测
        ''' </summary>
        ''' <param name="obj">要进行判断的对象</param>
        ''' <param name="point">测试点</param>
        Public Function HitTest(obj As IEnumerable(Of GameVisual), point As Vector2) As IEnumerable(Of GameVisual)
            Return From o In obj Where o.Outline?.FillContainsPoint(point - o.Location)
        End Function
        ''' <summary>
        ''' 进行物体交叉的碰撞检测
        ''' </summary>
        ''' <param name="objs">要进行判断的对象</param>
        ''' <param name="obj">源对象</param>
        Public Function HitTest(objs As IEnumerable(Of GameVisual), obj As GameVisual) As IEnumerable(Of GameVisual)
            If obj.Outline Is Nothing Then Return Nothing
            Return From o In objs Where o.Outline IsNot Nothing AndAlso Union({o.Outline, obj.Outline}).Tessellate.Any
        End Function
        ''' <summary>
        ''' 进行射线碰撞检测
        ''' </summary>
        ''' <param name="obj">要进行判断的对象</param>
        ''' <param name="Filter">判断和设定碰撞检测进行的行为</param>
        ''' <param name="Result">当命中时决定碰撞检测的行为</param>
        ''' <param name="Params">射线的参数</param>
        Public Sub HitTest(obj As GameVisual(), Filter As Func(Of GameVisual, GameHitTestFilterBehavior), Result As Func(Of GameVisual, GameHitTestResultBehavior), Params As GameRayHitTestParameters)
            Throw New NotImplementedException
        End Sub
        ''' <summary>
        ''' 进行点碰撞检测
        ''' </summary>
        ''' <param name="obj">要进行判断的对象</param>
        ''' <param name="Filter">判断和设定碰撞检测进行的行为</param>
        ''' <param name="Result">当命中时决定碰撞检测的行为</param>
        ''' <param name="Params">点的相关信息</param>
        Public Sub HitTest(obj As IEnumerable(Of GameVisual), Filter As Func(Of GameVisual, GameHitTestFilterBehavior), Result As Func(Of GameVisual, GameHitTestResultBehavior), Params As GamePointHitTestParameter)
            For Each o In obj
                Select Case Filter(o)
                    Case GameHitTestFilterBehavior.AbortCurrentGroup
                        Return
                    Case GameHitTestFilterBehavior.ContinueHitest
                        If o.Outline?.FillContainsPoint(Params.Point - o.Location) Then
                            If Result(o) = GameHitTestResultBehavior.StopTest Then
                                Return
                            End If
                        End If
                End Select
            Next
        End Sub
    End Class
End Namespace
