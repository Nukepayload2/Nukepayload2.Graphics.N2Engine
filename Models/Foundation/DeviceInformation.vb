Public Module DeviceInformation
    Dim _IsSpriteBatchSupportedOnCurrentDevice As Boolean
    ''' <summary>
    ''' Windows 10 在2015年11月开始支持<see cref="CanvasSpriteBatch"/>
    ''' </summary>
    ''' <returns></returns>
    Public Property IsSpriteBatchSupportedOnCurrentDevice As Boolean
        Get
            Return _IsSpriteBatchSupportedOnCurrentDevice
        End Get
        Friend Set(value As Boolean)
            _IsSpriteBatchSupportedOnCurrentDevice = value
        End Set
    End Property
End Module
