Public Enum InfantryStatus
    ''' <summary>
    ''' 空闲状态。播放空闲的动画。
    ''' </summary>
    Idle
    ''' <summary>
    ''' 用主武器攻击中
    ''' </summary>
    Attacking
    ''' <summary>
    ''' 使用特殊能力
    ''' </summary>
    UsingSpecialAbility
    ''' <summary>
    ''' 使用某一类道具, 用途不是攻击
    ''' </summary>
    UsingItem
    ''' <summary>
    ''' 爬行。通常是受到火力压制时做出这种动作。
    ''' </summary>
    Crawling
    ''' <summary>
    ''' 趴着攻击。通常用于反击。
    ''' </summary>
    CrawlFire
    ''' <summary>
    ''' 蹲下。用于紧急回避。
    ''' </summary>
    Crouch
    ''' <summary>
    ''' 潜行。使用隐形能力和降低速度，避免敌人注意。此时不能攻击。
    ''' </summary>
    Stealth
    ''' <summary>
    ''' 欢呼
    ''' </summary>
    Cheering
    ''' <summary>
    ''' 遭到火力压制，从站立切换到匍匐。
    ''' </summary>
    Prone
    ''' <summary>
    ''' 如果这个单位会踩水，那么用这个动画。
    ''' </summary>
    Tread
    ''' <summary>
    ''' 游泳
    ''' </summary>
    Swimming
    ''' <summary>
    ''' 悬浮或者是已经跳在空中
    ''' </summary>
    Hovering
    ''' <summary>
    ''' 落地
    ''' </summary>
    Landing
    ''' <summary>
    ''' 在查看某个方向的情况
    ''' </summary>
    Viewing
    ''' <summary>
    ''' 受到攻击
    ''' </summary>
    UnderAttack
    ''' <summary>
    ''' 常规的走动
    ''' </summary>
    Walk
    ''' <summary>
    ''' 向某个方向进行冲刺
    ''' </summary>
    Dash
    ''' <summary>
    ''' 吓尿了
    ''' </summary>
    Panic
    ''' <summary>
    ''' GG
    ''' </summary>
    Die
    ''' <summary>
    ''' 未定义的拓展状态
    ''' </summary>
    Extended
End Enum