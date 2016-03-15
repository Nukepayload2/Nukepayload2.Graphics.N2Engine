Imports SQLite.Net.Attributes
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SaveFilesIndex
        ''' <summary>
        ''' 存档编号
        ''' </summary>
        <PrimaryKey, AutoIncrement>
        Public Property SaveId%
        Public Property WorldId As Short
        Public Property StageId As Short
    End Class
End Namespace