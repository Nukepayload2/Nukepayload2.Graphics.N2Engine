Public Class GameObjectsHelper
    Public Property Panel As GamePanel
    Sub New(panel As GamePanel)
        Me.Panel = panel
    End Sub
    ''' <summary>
    ''' 进行射线碰撞检测
    ''' </summary>
    ''' <param name="obj">要进行判断的对象</param>
    ''' <param name="Filter">判断和设定碰撞检测进行的行为</param>
    ''' <param name="Result">当命中时决定碰撞检测的行为</param>
    ''' <param name="Params">射线的参数</param>
    Public Sub HitTest(obj As GameVisual, Filter As Func(Of GameVisual, GameHitTestFilterBehavior), Result As Func(Of GameVisual, GameHitTestResultBehavior), Params As GameRayHitTestParameters)
        Throw New NotImplementedException
    End Sub
    ''' <summary>
    ''' 进行点碰撞检测
    ''' </summary>
    ''' <param name="obj">要进行判断的对象</param>
    ''' <param name="Filter">判断和设定碰撞检测进行的行为</param>
    ''' <param name="Result">当命中时决定碰撞检测的行为</param>
    ''' <param name="Params">点的相关信息</param>
    Public Sub HitTest(obj As GameVisual, Filter As Func(Of GameVisual, GameHitTestFilterBehavior), Result As Func(Of GameVisual, GameHitTestResultBehavior), Params As GamePointHitTestParameter)
        Throw New NotImplementedException
    End Sub
End Class