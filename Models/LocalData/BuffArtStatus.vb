Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class BuffArtStatus
        <PrimaryKey, AutoIncrement>
        Public Property Id%
        Public Property Name$
        Public Property Description$
        Public Property IconName$
        Public Property BuffId%
        Public Property EffectX!
        Public Property EffectY!
        Public Property EffectZ!
        Public Property Level As Short
        Public Property TotalTimeMillSec As Integer
        Public Property Stage As UShort
        Public Property LoopCount As UShort
        Public Property NextId%
        Public Property NextRoleAttribPlusId%
    End Class
End Namespace