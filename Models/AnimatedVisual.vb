''' <summary>
''' 表示每一帧都需要改变内部形状的可视对象
''' </summary>
Public MustInherit Class AnimatedVisual
    Inherits GameVisual
    Dim _IsStopped As Boolean
    Public Property IsStopped As Boolean
        Get
            Return _IsStopped
        End Get
        Protected Set(value As Boolean)
            _IsStopped = value
        End Set
    End Property
    Public Overridable Sub Update(sender As GamePanel)

    End Sub
End Class
