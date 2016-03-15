Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class ItemStatus
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        Public Property CategoryId%
        Public Property SubCategoryId%
        Public Property ExtraBuffId%
        Public Property Name$
        Public Property Description$
        Public Property PayloadSceneId%
        Public Property IconName$
        Public Property ItemLevel As Short
        Public Property Strength%
        Public Property DamageLevel%
        Public Property MaxStack%
        Public Property Cost%
        Public Property PlayerLevelLimit%
        Public Property Sellable As Boolean
        Public Property Throwable As Boolean
        Public Property Droppable As Boolean
        Public Property Smithable As Boolean
        Public Property RecipeId%
        Public Property IsSpecialWeapon As Boolean
        Public Property RoleAppendCustomAttribId%
        ''' <summary>
        ''' 镶嵌
        ''' </summary>
        Public Property CustomMosaicId%
        Public Property MaxMosaicCount As Short

    End Class
End Namespace