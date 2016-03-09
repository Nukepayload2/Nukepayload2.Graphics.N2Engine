Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 基本的粒子
    ''' </summary>
    Public Interface IParticle
        ''' <summary>
        ''' 造成伤害（如果有）
        ''' </summary>
        ''' <returns></returns>
        Property Damage!
        ''' <summary>
        ''' 用于计算伤害的弹头，不包括弹头的动画
        ''' </summary>
        ''' <returns></returns>
        Property Warhead As Warhead
        ''' <summary>
        ''' 位置
        ''' </summary>
        Property Location As Vector2
        ''' <summary>
        ''' 速度
        ''' </summary>
        Property Velocity As Vector2
        ''' <summary>
        ''' 加速度
        ''' </summary>
        Property Acceleration As Vector2
        ''' <summary>
        ''' 已经存在了多少帧了
        ''' </summary>
        Property Age%
        ''' <summary>
        ''' 最大生存时间
        ''' </summary>
        ReadOnly Property LifeTime%
        Sub Update()
    End Interface
End Namespace
