Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 设计器的状态
    ''' </summary>
    Public Class DesignerStatus
        ''' <summary>
        ''' 当前选择了哪种工具。如果没有则是选择了指针。
        ''' </summary>
        Public Property SelectedTool As ToolboxItem
        ''' <summary>
        ''' 设计器有改动但是还没同步到json
        ''' </summary>
        Public Property DesignerChanged As Boolean
        ''' <summary>
        ''' json有改动但是还没同步到设计器
        ''' </summary>
        Public Property JsonChanged As Boolean
        ''' <summary>
        ''' 用于对齐的网格
        ''' </summary>
        Public Property AlimentGrid As New DesignerGrid
        ''' <summary>
        ''' 画布的大小
        ''' </summary>
        Public Property CanvasSize As New Size(1920, 1080)
        ''' <summary>
        ''' 当前在编辑的项目
        ''' </summary>
        Public Property CurrentProject As N2DesignerProject
        ''' <summary>
        ''' 当前在编辑的项目中选择的文件组
        ''' </summary>
        Public Property CurrentProjectItem As N2DesignerProjectItem
        ''' <summary>
        ''' 快捷操作栏的内容
        ''' </summary>
        Public Property Shortcuts As IList(Of N2DesignerShortcut)
    End Class
End Namespace