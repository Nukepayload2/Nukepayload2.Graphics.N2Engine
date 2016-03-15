Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class InitialCharacterStatus
        <PrimaryKey, AutoIncrement>
        Public Property Id As Integer
        Public Property Name As String
        Public Property HP As Integer
        Public Property MP As Integer
        Public Property Speed As Integer
        Public Property Attack As Integer
        Public Property DefaultAttackElement As Integer()
        Public Property DefaultCarriedItems As Integer()
        Public Property DefaultEquipItems As Integer()
        Public Property BlockRate!
        Public Property SkillPoint As Integer
        Public Property CriticalRate!
        Public Property DefendRate!
        Public Property DodgeRate!
        Public Property WeaponId As Integer
        Public Property FamilyName As String
        Public Property IsFightable As Boolean
        Public Property InFightGroup As Boolean
        Public Property IsNpc As Boolean
        Public Property Level As Integer
        Public Property MagicAttack As Integer
        Public Property MaxHP As Integer
        Public Property MaxMP As Integer
        Public Property MagicDefence As Integer
        Public Property TotalExp As Integer
        Public Property TotalSkillPoint As Integer
    End Class
End Namespace