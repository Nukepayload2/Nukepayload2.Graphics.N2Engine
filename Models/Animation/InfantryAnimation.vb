Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 步兵动画
    ''' </summary>
    Public MustInherit Class InfantryAnimation
        ''' <summary>
        ''' 附加的动画，比如各种Buff动画。
        ''' </summary>
        Public Property AttachedAnimation As New List(Of DynamicBitmapAnimation)
        ''' <summary>
        ''' 对应步兵状态的动画。使用步兵的状态查询到状态表，再根据状态索引选出每一帧的表。
        ''' </summary>
        Public ReadOnly Property ActonSequence As New Dictionary(Of InfantryStatus, IList(Of IList(Of CanvasBitmap)))
        ''' <summary>
        ''' 获取某一帧的步兵动画
        ''' </summary>
        ''' <param name="LastStatus">上一个状态</param>
        ''' <param name="NewStatus">新的状态</param>
        ''' <param name="Index%">帧数索引。如果上一个状态与新的状态不同，索引会被设置为0</param>
        ''' <param name="StatusParameter%">如果状态有多个下标，则指定使用哪个子状态。如果设定为-1则认为随机选择。</param>
        ''' <returns></returns>
        Public MustOverride Function GetImage(LastStatus As InfantryStatus, NewStatus As InfantryStatus, ByRef Index%, Optional StatusParameter% = -1) As ICanvasImage

    End Class
End Namespace
