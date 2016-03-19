Imports SQLite.Net
Imports SQLite.Net.Async

Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SaveFile
        Protected Sub New()

        End Sub

        Public Property Items As New List(Of SaveFilesIndex)


        Public Async Function LoadAsync(dbFileName$) As Task(Of SaveFile)
            Dim conn = GetDatabaseAsyncConnection(dbFileName)
            Dim query = conn.Table(Of SaveFilesIndex)
            Dim sav As New SaveFile
            sav.Items = Await query.ToListAsync
            Return sav
        End Function

        Protected Shared Function GetDatabaseAsyncConnection(dbFileName As String) As SQLiteAsyncConnection
            Dim dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbFileName)
            Return New SQLiteAsyncConnection(Function() New SQLiteConnectionWithLock(New Platform.WinRT.SQLitePlatformWinRT(), New SQLiteConnectionString(dbPath, False)))
        End Function
    End Class

End Namespace