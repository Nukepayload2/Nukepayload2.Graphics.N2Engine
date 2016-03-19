Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SinaAuthenticationResult
        Sub New(callbackUriString As String, authenticationCode As String)
            Me.CallbackUriString = callbackUriString
            Me.AuthenticationCode = authenticationCode
        End Sub

        Public Property CallbackUriString$
        Public Property AuthenticationCode$
    End Class

End Namespace