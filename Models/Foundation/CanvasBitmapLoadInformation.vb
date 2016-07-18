Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class CanvasBitmapLoadInformation
        Public Property ResourceId As String
        Public Property Stretch As BitmapStretch

    End Class

    Public Enum BitmapStretch
        ''' <summary>
        '''  内容保持其原始大小。
        ''' </summary>
        None = 0
        ''' <summary>
        ''' 调整内容的大小以填充目标尺寸。不保留纵横比。
        ''' </summary>
        Fill = 1
        ''' <summary>
        ''' 在保留内容原有纵横比的同时调整内容的大小，以适合目标尺寸。
        ''' </summary>
        Uniform = 2
        ''' <summary>
        ''' 在保留内容原有纵横比的同时调整内容的大小，以填充目标尺寸。如果目标矩形的纵横比不同于源矩形的纵横比，则对源内容进行剪裁以适合目标尺寸。
        ''' </summary>
        UniformToFill = 3
    End Enum
End Namespace