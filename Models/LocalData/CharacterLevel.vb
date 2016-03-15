Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class CharacterLevel
        <PrimaryKey, AutoIncrement>
        Public Property Level As Integer
        Public Property Speed As Integer
        Public Property Attack As Integer
        Public Property BlockRate!
        Public Property CriticalRate!
        Public Property Defend As Integer
        Public Property Dodage As Integer
        Public Property LearnSkillId As Integer
        Public Property MagicAttack As Integer
        Public Property MaxHP As Integer
        Public Property MaxMP As Integer
        Public Property MagicDefend As Integer
        Public Property NextExperience As Integer
        Public Property SkillPoint As Integer
    End Class
End Namespace