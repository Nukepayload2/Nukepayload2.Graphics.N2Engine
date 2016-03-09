Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 武器的弹头
    ''' </summary>
    Public MustInherit Class Warhead
        Sub New()

        End Sub
        ''' <summary>
        ''' 爆炸动画
        ''' </summary>
        Public MustOverride ReadOnly Property ExplosionAnimation As DynamicBitmapAnimation
        ''' <summary>
        ''' 装甲对应的伤害比。
        ''' </summary>
        Public MustOverride Property Verses As IDictionary(Of Ammor, Single)
        ''' <summary>
        ''' 受伤害的半径，默认1。注意，这与Tiberian Sun的CellSpread不一样，这个单位是设备无关单位。
        ''' </summary>
        Public Property DamageRadius! = 1
        ''' <summary>
        ''' 计算伤害
        ''' </summary>
        ''' <param name="OriginalDamage!">原本有多大伤害</param>
        ''' <param name="MiniumDistance!">爆炸点与目标距离</param>
        ''' <param name="TargetAmmor">目标的装甲</param>
        Public Overridable Function CalculateDamage(OriginalDamage!, MiniumDistance!, TargetAmmor As Ammor) As Single
            If Verses.ContainsKey(TargetAmmor) Then
                OriginalDamage *= Verses(TargetAmmor)
            End If
            Return If(MiniumDistance > DamageRadius, 0, OriginalDamage * (DamageRadius - MiniumDistance))
        End Function
    End Class
End Namespace
