Imports SQLite.Net
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SaveFile
        Public Property Items As New List(Of SaveFileItem)
        Public Sub LoadFrom(dbPath$)
            Dim conn As New SQLiteConnection(New Platform.WinRT.SQLitePlatformWinRT(), dbPath)

        End Sub
    End Class

End Namespace
