''' <summary>
''' 步兵单位
''' </summary>
Public MustInherit Class Infantry
    Inherits BattleUnit
    Public Event StatusChanged()
    Dim _Status As InfantryStatus
    ''' <summary>
    ''' 单位的状态，比如行走。
    ''' </summary>
    Public Property Status As InfantryStatus
        Get
            Return _Status
        End Get
        Set(value As InfantryStatus)
            If value <> _Status Then
                _Status = value
                RaiseEvent StatusChanged()
            End If
        End Set
    End Property
    ''' <summary>
    ''' 最大的移动速度
    ''' </summary>
    Public Property MaxSpeed!
    ''' <summary>
    ''' 加速度
    ''' </summary>
    Public Property Acceleration!
    ''' <summary>
    ''' 速度
    ''' </summary>
    Public Property Velocity!
    ''' <summary>
    ''' 用于记录状态的附加值。比如某个单位有三种攻击方式, <see cref="InfantryStatus.Attacking"/> 指定了攻击，这个属性指定了现在在用哪种攻击方式。
    ''' </summary>
    Public Property StatusIndex%
    ''' <summary>
    ''' 单位面朝的方向。包括八种方向。<see cref="UnitDirectionHelper.GetDirection(Single)"/> 可以把角度转换为方向。
    ''' </summary>
    Public MustOverride Property Direction As UnitDirections
End Class