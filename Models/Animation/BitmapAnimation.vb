Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 表示位图动画
    ''' </summary>
    Public Class BitmapAnimation
        Inherits AnimatedVisual
        Implements IDisposable
        ''' <summary>
        ''' 仅使用图像列表初始化
        ''' </summary>
        ''' <param name="Frames">图像列表</param>
        Sub New(Frames As IList(Of CanvasBitmap))
            Me.Frames = Frames
        End Sub
        ''' <summary>
        ''' 创建带二维变换和透明度的动画
        ''' </summary>
        ''' <param name="Frames">图像列表</param>
        ''' <param name="Transform">二位变换</param>
        ''' <param name="Opacity">透明度。0透明，1不透明</param>
        Sub New(Frames As IList(Of CanvasBitmap), Transform As Matrix3x2, Opacity!)
            MyClass.New(Frames)
            Me.Transform = New Matrix3x2?(Transform)
            Me.Opacity = Opacity
        End Sub
        ''' <summary>
        ''' 创建带二维变换和透明度的动画到带有透视的空间中
        ''' </summary>
        ''' <param name="Frames">图像列表</param>
        ''' <param name="Transform">二位变换</param>
        ''' <param name="Opacity">透明度。0透明，1不透明</param>
        ''' <param name="Perspective">三维场景的透视</param>
        Sub New(Frames As IList(Of CanvasBitmap), Transform As Matrix3x2, Opacity!, Perspective As Matrix4x4)
            MyClass.New(Frames, Transform, Opacity)
            Me.Perspective = New Matrix4x4?(Perspective)
        End Sub
        ''' <summary>
        ''' 创建带二维变换和透明度的动画, 并且指定每一帧的特效
        ''' </summary>
        ''' <param name="Frames">图像列表</param>
        ''' <param name="Transform">二位变换</param>
        ''' <param name="Opacity">透明度。0透明，1不透明</param>
        ''' <param name="ApplyEffect">设置Effect的方法</param>
        Sub New(Frames As IList(Of CanvasBitmap), Transform As Matrix3x2, Opacity!, ApplyEffect As Func(Of ICanvasImage, ICanvasResourceCreator, ICanvasEffect))
            MyClass.New(Frames, Transform, Opacity)
            Me.ApplyEffect = ApplyEffect
        End Sub
        ''' <summary>
        ''' 已经解析过的图像。以帧的形式存放。必须根据相应的<see cref="CanvasCreateResourcesEventArgs"/>创建这些位图。
        ''' </summary>
        Public Property Frames As IList(Of CanvasBitmap)
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
        ''' 处理特效
        ''' </summary>
        Public Property ApplyEffect As Func(Of ICanvasImage, ICanvasResourceCreator, ICanvasEffect)
        ''' <summary>
        ''' 重写默认的循环行为
        ''' </summary>
        Public Property LoopInformation As AnimatioLoopInformation
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
        ''' 如果切换到了下一个动画，则用这个属性记录切换到了哪个动画
        ''' </summary>
        ''' <returns></returns>
        Public Property NextAnimationIndex% = -1
        ''' <summary>
        ''' 更新画面了多少次。
        ''' </summary>
        Public Property FrameCount% = 0
        ''' <summary>
        ''' 呈现此动画
        ''' </summary>
        Public Overrides ReadOnly Property Presenter As GameVisualView = New BitmapAnimationView(Me)
        ''' <summary>
        ''' 更新此动画，这会增加<see cref="FrameCount"/>
        ''' </summary>
        ''' <param name="sender"></param>
        Public Overrides Sub Update(sender As GamePanel)
            MyBase.Update(sender)
            _FrameCount += 1
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
End Namespace
