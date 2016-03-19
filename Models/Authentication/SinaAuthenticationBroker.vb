Imports System.Net
Imports Windows.Security.Authentication.Web
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SinaAuthenticationBroker
        Public Async Function AuthenticateAsync(clientID$, Optional callbackUriString$ = "https://api.weibo.com/oauth2/default.html") As Task(Of SinaAuthenticationResult)
            Dim callbackUri As New Uri(callbackUriString)
            Dim webAuthUri As New Uri($"https://api.weibo.com/oauth2/authorize?client_id={clientID}&response_type=code&redirect_uri={callbackUriString}")
            Dim result = Await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, webAuthUri, callbackUri)
            Select Case result.ResponseStatus
                Case WebAuthenticationStatus.Success
                    callbackUriString = result.ResponseData
                    Dim code = callbackUriString.Substring(callbackUriString.IndexOf("="c) + 1)
                    Return New SinaAuthenticationResult(callbackUriString, code)
                Case WebAuthenticationStatus.ErrorHttp
                    Throw New WebException(result.ResponseErrorDetail.ToString())
                Case Else
                    Throw New OperationCanceledException
            End Select
        End Function
    End Class
End Namespace