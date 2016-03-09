Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 设计器的状态
    ''' </summary>
    Public Class DesignerStatus
        ''' <summary>
        ''' 当前选择了哪种工具
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
    End Class
End Namespace