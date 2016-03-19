Imports Windows.Storage

Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class N2DesignerProject
        Public Property File As IStorageFile
        ''' <summary>
        ''' 首次使用时让用户选择文件夹
        ''' </summary>
        Public Property Directory As IStorageFolder
        Public ReadOnly Property ProjectItemFileList As IList(Of N2DesignerProjectItem)
    End Class
End Namespace