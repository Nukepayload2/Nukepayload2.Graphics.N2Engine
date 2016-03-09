Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class TriggerAeraTagStayEventArgs
        Inherits TriggerAeraTagEventArgs
        Sub New(targetObject As GameVisual, ElapsedTimeMillSec%)
            MyBase.New(targetObject)
            Me.ElapsedTimeMillSec = ElapsedTimeMillSec
        End Sub
        ''' <summary>
        ''' 物体呆在触发区域的时间。以毫秒计时。
        ''' </summary>
        Public ReadOnly Property ElapsedTimeMillSec%
    End Class
End Namespace
