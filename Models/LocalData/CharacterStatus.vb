Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class CharacterStatus
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        Public Property Name$
        Public Property Description$
        Public Property IconName$
        Public Property CategoryId%
        Public Property SubCategoryId%
        Public Property MaxStack%
        Public Property Cost%
        Public Property Sellable As Boolean
        Public Property Throwable As Boolean
        Public Property Droppable As Boolean
        Public Property Smithable As Boolean
        Public Property JobId%
        Public Property IsMale%
        Public Property Catchable As Boolean
        Public Property CatchHardLevel As Short
        Public Property CanShow As Boolean
        Public Property ShowFlag As Short
        Public Property InfDeath%
        Public Property Stealable As Boolean
        Public Property StealHardLevel As Short

        Public Property CurrentLevel As Integer
        Public Property AILevel As Integer
        Public Property Attack As Integer
        Public Property AttackEffectIds As Integer()
        Public Property AttackSound As String
        Public Property BuffIds As Integer()
        Public Property BlockRate!
        Public Property CriticalRate!
        Public Property CriticalEffectArtId As Integer
        Public Property DeathWeaponId As Integer
        Public Property Defend As Integer
        Public Property DefendElementSlot As Integer()
        Public Property DodgeRate!
        Public Property DropItemIds As Integer()
        Public Property NewFigure As Integer
        Public Property CustomFormationId As Integer
        Public Property DropExp As Integer
        Public Property CurrentExp As Integer
        Public Property CurrentMoney As Integer
        Public Property DropMoney As Integer
        Public Property HitSkillCount As Integer
        Public Property HitSkillID As Integer
        Public Property HitSkillRate As Integer
        Public Property MagicAtk As Integer
        Public Property MaxHP As Integer
        Public Property MaxMP As Integer
        Public Property MagicDef As Integer
        Public Property Speed As Single
        Public Property NormalSkillIds As Integer()
        Public Property PayloadSceneId%
    End Class
End Namespace