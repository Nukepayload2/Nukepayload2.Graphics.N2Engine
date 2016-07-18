Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 触发区域用于引发事件
    ''' </summary>
    <ToolboxItemVisible>
    Public Class TriggerAeraTag
        Inherits Tags

        Public Overrides Property Description As String = "触发区域用于引发事件"
        Public Overrides Property Name As String = "触发区域"
        Public Overrides Property TargetType As Type
        ''' <summary>
        ''' 触发区域的位置和大小
        ''' </summary>
        Public Property TriggerAera As Rect
        ''' <summary>
        ''' 触发间隔，单位为帧
        ''' </summary>
        Public Property CheckInterval% = 5
        ''' <summary>
        ''' 某个物体具有<see cref="GameVisual.Outline"/>, 并且进入了触发区域
        ''' </summary>
        Public Event Entered(sender As TriggerAeraTag, e As TriggerAeraTagEventArgs)
        ''' <summary>
        ''' 某个物体具有<see cref="GameVisual.Outline"/>, 并且保持在触发区域
        ''' </summary>
        Public Event Stayed(sender As TriggerAeraTag, e As TriggerAeraTagStayEventArgs)
        ''' <summary>
        ''' 某个物体具有<see cref="GameVisual.Outline"/>, 并且离开触发区域
        ''' </summary>
        Public Event Leaving(sender As TriggerAeraTag, e As TriggerAeraTagEventArgs)
    End Class
End Namespace
