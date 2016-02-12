Public MustInherit Class Warhead
    Public MustOverride ReadOnly Property ExplosionAnimation As DynamicBitmapAnimation
    Public MustOverride Property Verses As IDictionary(Of Ammor, Single)
    Public Property CellSpread! = 0.5

    Public Overridable Function CalculateDamage(OriginalDamage!, MiniumDistance!, TargetAmmor As Ammor) As Single
        If Verses.ContainsKey(TargetAmmor) Then
            OriginalDamage *= Verses(TargetAmmor)
        End If
        Return If(MiniumDistance > CellSpread, 0, OriginalDamage * (CellSpread - MiniumDistance))
    End Function
End Class