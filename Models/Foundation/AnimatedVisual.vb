Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示每一帧都需要改变内部形状的可视对象
    ''' </summary>
    Public MustInherit Class AnimatedVisual
        Inherits GameVisual
        Dim _IsStopped As Boolean
        ''' <summary>
        ''' 动画是否已经停止了
        ''' </summary>
        Public Property IsStopped As Boolean
            Get
                Return _IsStopped
            End Get
            Friend Set(value As Boolean)
                _IsStopped = value
            End Set
        End Property
        ''' <summary>
        ''' 更新动画。默认没有任何行为。
        ''' </summary>
        Public Overridable Sub Update(sender As GamePanel)

        End Sub
    End Class

End Namespace
