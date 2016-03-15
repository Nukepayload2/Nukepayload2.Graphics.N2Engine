Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class BuffStatus
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        ''' <summary>
        ''' Buff的名字
        ''' </summary>
        Public Property Name$
        ''' <summary>
        ''' 攻击力加上多少
        ''' </summary>
        Public Property AddAttack%
        ''' <summary>
        ''' 防御力加上多少
        ''' </summary>
        Public Property AddDefend%
        Public Property AddMagicAttack%
        Public Property AddMagicDefend%
        Public Property SpeedRate%
        Public Property RofRate%
        Public Property AttackRate!
        Public Property DefendRate!
        Public Property MagicAttackRate!
        Public Property MagicDefendRate!
        ''' <summary>
        ''' 状态此时一次性补多少血
        ''' </summary>
        Public Property HealAmount!
        ''' <summary>
        ''' 状态此时一次性补多少MP
        ''' </summary>
        Public Property MpRecoverRate!
        ''' <summary>
        ''' 对暴击率的影响
        ''' </summary>
        Public Property CriticalRate!
        ''' <summary>
        ''' Minecraft 时运和抢夺
        ''' </summary>
        Public Property DropRate!
        ''' <summary>
        ''' 仙剑奇侠传 闪避符咒
        ''' </summary>
        Public Property DodgeRate!
        ''' <summary>
        ''' 自定义的魔法类型产生的伤害和MP消耗变化
        ''' </summary>
        Public Property CustomMagicAttributeDeltaId%
        ''' <summary>
        ''' 红警3 升阳套子协议
        ''' </summary>
        Public Property AbsorbDamage%
        ''' <summary>
        ''' 最终幻想 镜面反射
        ''' </summary>
        Public Property ReflectDamage%
        ''' <summary>
        ''' 红警3 盟军驱逐舰黑洞装甲的半径
        ''' </summary>
        Public Property FocusRadius!
        ''' <summary>
        ''' 红警3 升阳海啸坦克技能
        ''' </summary>
        Public Property AvoidRadius!
        ''' <summary>
        ''' 红警3 升阳天皇之怒
        ''' </summary>
        Public Property BerserkerLevel%
        ''' <summary>
        ''' 红警3 铁幕, 超时空, 谭雅C4 的秒杀效果对特定装甲的作用
        ''' </summary>
        Public Property ExecuteToCustomAmmorId%
        ''' <summary>
        ''' 红警3 铁幕对特定装甲的作用
        ''' </summary>
        Public Property ImmuneToCustomAmmorId%
        ''' <summary>
        ''' 凯恩之怒 步兵死尸产生救赎者对步兵装甲的作用
        ''' </summary>
        Public Property RedemptionToCustomAmmorId%
        ''' <summary>
        ''' 红警3 帝国武士拔刀不再被压制
        ''' </summary>
        Public Property Fearless%
        ''' <summary>
        ''' 红警3 海啸坦克F技能回血
        ''' </summary>
        Public Property AddStrength%
        ''' <summary>
        ''' 最终幻想 恢复MP
        ''' </summary>
        Public Property AddMagic%
        ''' <summary>
        ''' 仙剑奇侠传 降低HP上限
        ''' </summary>
        Public Property MaxStrengthRate%
        ''' <summary>
        ''' 仙剑奇侠传 降低MP上限
        ''' </summary>
        Public Property MaxMagicRate%
    End Class
End Namespace