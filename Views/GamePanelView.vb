''' <summary>
''' 用于呈现GamePanel, 将加入到VisualTree。
''' </summary>
Public MustInherit Class GamePanelView
    Inherits UserControl
    Implements IDisposable
    Public Property Quality As New GraphicQualityManager
    Public ReadOnly Property AnimatedImageManager As GameResourceManager(Of Integer, ICanvasImage)
    Public ReadOnly Property StaticImageManager As GameResourceManager(Of Integer, ICanvasImage)
    Public WithEvents Panel As GamePanel
    Protected WithEvents AnimatedCanvas As New CanvasAnimatedContainer
    Protected WithEvents StaticCanvas As New CanvasContainer
    Public ReadOnly PanelParent As New Grid
    Public Property AnimationDpiScale!
    Public Property StaticDpiScale!
    Sub New(Panel As GamePanel)
        Me.Panel = Panel
        Dim siz = Panel.SpaceSize
        PanelParent.Width = siz.Width
        PanelParent.Height = siz.Height
        AnimationDpiScale = 96 / AnimatedCanvas.Canvas.Dpi
        AnimatedCanvas.Canvas.DpiScale = AnimationDpiScale
        StaticDpiScale = 96 / StaticCanvas.Canvas.Dpi
        StaticCanvas.Canvas.DpiScale = StaticDpiScale
        PanelParent.Children.Add(AnimatedCanvas)
        PanelParent.Children.Add(StaticCanvas)
        Content = PanelParent
    End Sub

    Private Sub AnimatedCanvas_CreateResources(sender As CanvasAnimatedControl, args As CanvasCreateResourcesEventArgs) Handles AnimatedCanvas.CreateResources
        args.TrackAsyncAction((Async Function()
                                   If _AnimatedImageManager Is Nothing Then _AnimatedImageManager = InitializeImageManager(sender)
                                   Debug.WriteLine("加载动态图片资源")
                                   Await AnimatedImageManager.LoadAsync(sender)
                                   For Each obj In Panel.AnimObjects
                                       obj.Presenter.OnCreateCustomAnimatedResource(sender, args)
                                   Next
                               End Function).Invoke.AsAsyncAction)
    End Sub

    Protected MustOverride Function InitializeImageManager(creator As ICanvasResourceCreator) As GameResourceManager(Of Integer, ICanvasImage)

    Private Sub AnimatedCanvas_Draw(sender As ICanvasAnimatedControl, args As CanvasAnimatedDrawEventArgs) Handles AnimatedCanvas.Draw
        Try
            DrawAnim(sender, args)
        Catch ex As Exception
        End Try
    End Sub
    Public ReadOnly Property Timing As CanvasTimingInformation?
    Dim DrawAnim As New Action(Of ICanvasAnimatedControl, CanvasAnimatedDrawEventArgs)(
        Sub(sender, args)
            '仅绘制，不要试图在这里添加任何操纵可视对象状态的逻辑
            _Timing = New CanvasTimingInformation?(args.Timing)
            Using lck = sender.Device.Lock
                Using cl = New CanvasCommandList(args.DrawingSession)
                    Using ds = cl.CreateDrawingSession
                        For Each a In Panel.AnimObjects
                            a.Presenter.OnDraw(Me, ds)
                        Next
                    End Using
                    args.DrawingSession.DrawImage(cl)
                End Using
            End Using
            Panel.Update()
        End Sub)

    Private Sub StaticCanvas_Draw(sender As CanvasControl, args As CanvasDrawEventArgs) Handles StaticCanvas.Draw
        Try
            DrawStatic(args)
        Catch ex As Exception
        End Try
    End Sub

    Dim DrawStatic As New Action(Of CanvasDrawEventArgs)(
        Sub(args As CanvasDrawEventArgs)
            '仅绘制，不要试图在这里添加任何操纵可视对象状态的逻辑
            Using lck = args.DrawingSession.Device.Lock
                Using cl = New CanvasCommandList(args.DrawingSession)
                    Using ds = cl.CreateDrawingSession
                        For Each a In Panel.StaticObjects
                            a.Presenter.OnDraw(Me, ds)
                        Next
                    End Using
                    args.DrawingSession.DrawImage(cl)
                End Using
            End Using
        End Sub)

    Private Sub Panel_SizeChanged(NewSize As Size) Handles Panel.SizeChanged
        PanelParent.Width = NewSize.Width
        PanelParent.Height = NewSize.Height
    End Sub

    Private Sub StaticCanvas_CreateResources(sender As CanvasControl, args As CanvasCreateResourcesEventArgs) Handles StaticCanvas.CreateResources
        args.TrackAsyncAction((Async Function()
                                   If _StaticImageManager Is Nothing Then _StaticImageManager = InitializeImageManager(sender)
                                   Debug.WriteLine("加载静态图片资源")
                                   Await StaticImageManager.LoadAsync(sender)
                                   For Each obj In Panel.AnimObjects
                                       obj.Presenter.OnCreateCustomStaticResource(sender, args)
                                   Next
                               End Function).Invoke.AsAsyncAction)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用
    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
                DrawAnim = AddressOf EmptyMethod
                DrawStatic = AddressOf EmptyMethod
                AnimatedCanvas = Nothing
                StaticCanvas = Nothing
                AnimatedImageManager.Dispose()
                StaticImageManager.Dispose()
                Panel.Dispose()
                _Timing = New CanvasTimingInformation?
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

    Sub EmptyMethod()

    End Sub
End Class
