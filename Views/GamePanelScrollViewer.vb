Option Strict Off
Public MustInherit Class GamePanelScrollViewer
    Inherits GamePanelView
    Public ReadOnly Property MinimapImageManager As GameResourceManager(Of Integer, ICanvasImage)
    WithEvents MinimapCanvas As CanvasAnimatedContainer
    WithEvents _Scroller As ScrollViewer
    Public ReadOnly Property Scroller As ScrollViewer
        Get
            Return _Scroller
        End Get
    End Property
    Sub New(Panel As GamePanel, MinimapCanvas As CanvasAnimatedContainer)
        MyBase.New(Panel)
        Me.MinimapCanvas = MinimapCanvas
        Content = Nothing
        _Scroller = New ScrollViewer With {
            .HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
            .VerticalScrollBarVisibility = ScrollBarVisibility.Hidden,
            .Content = PanelParent,
            .ZoomMode = ZoomMode.Enabled
        }
        Content = Scroller
    End Sub

    Dim DrawMinimap As New TypedEventHandler(Of ICanvasAnimatedControl, CanvasAnimatedDrawEventArgs)(
        Sub(sender, args)
            '仅绘制，不要试图在这里添加任何操纵可视对象状态的逻辑
            Try
                Using lck = sender.Device.Lock
                    Using cl = New CanvasCommandList(args.DrawingSession)
                        Using ds = cl.CreateDrawingSession
                            For Each a In Panel.AnimObjects
                                a.Presenter.OnDrawMinimap(Me, ds)
                            Next
                            For Each s In Panel.StaticObjects
                                s.Presenter.OnDrawMinimap(Me, ds)
                            Next
                            Panel.ViewingAera.Presenter.OnDrawMinimap(Me, ds)
                        End Using
                        args.DrawingSession.DrawImage(cl)
                    End Using
                End Using
            Catch
            End Try
        End Sub)

#Region "处理用户输入相关的运镜逻辑"
    Dim lastpos As Point
    Dim ofsx#, ofsy#, lastofsx%, lastofsy%
    Dim rightmousemoving As Boolean
    Dim movespeeddown# = 6
    Dim lastzoom! = 1
    Private Sub GamePanelPresenter_PointerMoved(sender As Object, e As PointerRoutedEventArgs) Handles Me.PointerMoved, Me.PointerPressed
        Dim pt = e.GetCurrentPoint(AnimatedCanvas)
        Dim curpos = pt.Position
        Dim pts = e.GetCurrentPoint(Scroller).Position
        If pt.PointerDevice.PointerDeviceType = Windows.Devices.Input.PointerDeviceType.Mouse Then
            If pt.Properties.IsRightButtonPressed Then
                lastofsx = (pts.X - lastpos.X) / movespeeddown
                lastofsy = (pts.Y - lastpos.Y) / movespeeddown
                rightmousemoving = True
            End If
        End If
        Panel.PointerLocation = curpos
    End Sub
    Private Sub GamePanelPresenter_PointerPressed2(sender As Object, e As PointerRoutedEventArgs) Handles Me.PointerPressed
        lastpos = e.GetCurrentPoint(Scroller).Position
        lastofsx = 0
        lastofsy = 0
    End Sub
    Private Async Sub Panel_Updating() Handles Panel.Updating
        If rightmousemoving Then
            Await Scroller.Dispatcher.RunAsync(Core.CoreDispatcherPriority.Normal,
                Sub()
                    ofsx += lastofsx
                    ofsy += lastofsy
                    ofsx = Math.Min(Math.Max(0, ofsx), lastzoom * (Panel.SpaceSize.Width) - Scroller.ActualWidth)
                    ofsy = Math.Min(Math.Max(0, ofsy), lastzoom * (Panel.SpaceSize.Height) - Scroller.ActualHeight)
                    Panel.ViewingAera.Aera = New Rect(ofsx / lastzoom, ofsy / lastzoom, Scroller.ViewportWidth / lastzoom, Scroller.ViewportHeight / lastzoom)
                    Scroller.ChangeView(ofsx, ofsy, Nothing)
                End Sub)
        End If
    End Sub
    Private Sub _Scroller_ViewChanging(sender As Object, e As ScrollViewerViewChangingEventArgs) Handles _Scroller.ViewChanging
        If Not rightmousemoving Then
            Dim v = e.FinalView
            lastzoom = v.ZoomFactor
            Panel.ViewingAera.Aera = New Rect(v.HorizontalOffset / lastzoom, v.VerticalOffset / lastzoom, Scroller.ViewportWidth / lastzoom, Scroller.ViewportHeight / lastzoom)
        End If
    End Sub

    Private Sub GamePanelPresenter_PointerReleased(sender As Object, e As PointerRoutedEventArgs) Handles Me.PointerReleased, Me.PointerExited
        rightmousemoving = False
    End Sub
#End Region
    Protected Overrides Sub Dispose(disposing As Boolean)
        MyBase.Dispose(disposing)
        If disposing Then
            DrawMinimap = AddressOf EmptyMethod
            MinimapImageManager.Dispose()
        End If
    End Sub

    Private Sub MinimapCanvas_CreateResources(sender As CanvasAnimatedControl, args As CanvasCreateResourcesEventArgs) Handles MinimapCanvas.CreateResources
        args.TrackAsyncAction((Async Function()
                                   If _MinimapImageManager Is Nothing Then _MinimapImageManager = InitializeImageManager(sender)
                                   Debug.WriteLine("加载minimap图片资源")
                                   Await MinimapImageManager.LoadAsync()
                                   For Each obj In Panel.AnimObjects
                                       obj.Presenter.OnCreateCustomMinimapResource(sender, args)
                                   Next
                               End Function).Invoke.AsAsyncAction)
    End Sub

    Private Sub MinimapCanvas_Draw(sender As ICanvasAnimatedControl, args As CanvasAnimatedDrawEventArgs) Handles MinimapCanvas.Draw
        DrawMinimap(sender, args)
    End Sub
End Class
