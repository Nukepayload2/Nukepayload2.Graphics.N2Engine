Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Module ScreenCapture
        ''' <summary>
        ''' 设置是否禁止在应用视图内的屏幕截图。这对Desktop无效，但是对手机有效。
        ''' </summary>
        Public Property AllowScreenCapture As Boolean
            Get
                Return ApplicationView.GetForCurrentView().IsScreenCaptureEnabled
            End Get
            Set
                ApplicationView.GetForCurrentView().IsScreenCaptureEnabled = Value
            End Set
        End Property
    End Module
End Namespace
