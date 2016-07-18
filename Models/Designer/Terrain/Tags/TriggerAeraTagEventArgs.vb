Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class TriggerAeraTagEventArgs
        Inherits EventArgs

        Sub New(targetObject As GameVisual)
            Me.TargetObject = targetObject
        End Sub

        Public ReadOnly Property TargetObject As GameVisual
    End Class
End Namespace
