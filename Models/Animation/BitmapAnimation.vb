Public Class BitmapAnimation
    Inherits AnimatedVisual

    Implements IDisposable
    ''' <summary>
    ''' 已经解析过的图像。以帧的形式存放。必须根据相应的<see cref="CanvasCreateResourcesEventArgs"/>创建这些位图。
    ''' </summary>
    Public Property Frames As ICollection(Of CanvasBitmap)
    ''' <summary>
    ''' 透明度
    ''' </summary>
    Public Property Opacity!
    ''' <summary>
    ''' 二维的平移，旋转和缩放。
    ''' </summary>
    Public Property Transform As Matrix3x2?
    ''' <summary>
    ''' 透视视角。注意: 如果使用这个功能就不能使用Effect功能了。
    ''' </summary>
    Public Property Perspective As Matrix4x4?
    ''' <summary>
    ''' 施加的与<see cref="Transform"/>无关的滤镜效果, 比如透明度，瓷砖，扭曲。
    ''' </summary>
    Public Property Effect As ICanvasEffect
    ''' <summary>
    ''' 如果指定了Effect，则要设定特效的数据源
    ''' </summary>
    ''' <returns></returns>
    Public Property SetEffectSource As Action(Of ICanvasImage)
    ''' <summary>
    ''' 重写默认的循环行为
    ''' </summary>
    Public Property LoopInformation As LoopInformation
    ''' <summary>
    ''' 计算当前所处的下标
    ''' </summary>
    Public Function GetImageIndex%(FrameCount%)
        Return If(LoopInformation Is Nothing, FrameCount Mod Frames.Count, LoopInformation.LoopStart + (FrameCount \ LoopInformation.Rate) Mod (LoopInformation.LoopEnd - LoopInformation.LoopStart + 1))
    End Function
    ''' <summary>
    ''' 判断是否已经播放完成了
    ''' </summary>
    Public Function IsEnded(FrameCount%) As Boolean
        Return If(LoopInformation Is Nothing, False, LoopInformation.LoopCount >= 0 AndAlso ((FrameCount \ LoopInformation.Rate) \ (LoopInformation.LoopEnd - LoopInformation.LoopStart + 1) > LoopInformation.LoopCount))
    End Function
    ''' <summary>
    ''' 如果不是空值，则会产生尾焰
    ''' </summary>
    Public Property Trailer As Trailer
    ''' <summary>
    ''' 当视图报告此动画播放完毕时切换到这些动画继续播放。
    ''' </summary>
    Public ReadOnly Property NextAnimations As ICollection(Of BitmapAnimation)
    ''' <summary>
    ''' 更新画面了多少次。
    ''' </summary>
    Public FrameCount% = 0
    ''' <summary>
    ''' 呈现此动画
    ''' </summary>
    Public Overrides ReadOnly Property Presenter As GameVisualView = New BitmapAnimationView(Me)
    Public Overrides Sub Update(sender As GamePanel)
        MyBase.Update(sender)
        FrameCount += 1
    End Sub
#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
                For Each f In Frames
                    f.Dispose()
                Next
            End If
            ' TODO: 释放未托管资源(未托管对象)并在以下内容中替代 Finalize()。
            ' TODO: 将大型字段设置为 null。
        End If
        disposedValue = True
    End Sub

    ' TODO: 仅当以上 Dispose(disposing As Boolean)拥有用于释放未托管资源的代码时才替代 Finalize()。
    'Protected Overrides Sub Finalize()
    '    ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic 添加此代码以正确实现可释放模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
        Dispose(True)
        ' TODO: 如果在以上内容中替代了 Finalize()，则取消注释以下行。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class