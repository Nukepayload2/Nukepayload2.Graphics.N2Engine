' “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供
Option Strict Off
Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 可用于自身或导航至 Frame 内部的空白页。
    ''' </summary>
    Public NotInheritable Class WorldBuilderPage
        Inherits Page

        Dim PressPoint As Point
        Dim IsDrawing As Boolean
        Dim CurRect As New ViewingAeraRectangle(New Rect, Colors.Red) With {.ZIndex = 16}
        Dim DesignStatus As New DesignerStatus

        Dim GameView As WorldBuilderView
        Dim GamePanel As WorldBuilderPanelViewModel
        Private Sub WorldBuilderPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            [AddHandler](Page.KeyDownEvent, New KeyEventHandler(AddressOf Page_KeyDown), True)
            GamePanel = New WorldBuilderPanelViewModel(DesignStatus.CanvasSize)
            Minimap.Width = DesignStatus.CanvasSize.Width
            Minimap.Height = DesignStatus.CanvasSize.Height
            GameView = New WorldBuilderView(GamePanel, Minimap)
            GamePanel.AnimObjects.Add(CurRect)
            GameObjectViewerContainer.Content = GameView
            ChkIsEditMode.IsChecked = True
        End Sub
        Private Sub GameObjectViewerContainer_PointerMoved(sender As Object, e As PointerRoutedEventArgs) Handles GameObjectViewerContainer.PointerMoved
            If IsDrawing Then
                Dim CurPressPoint = e.GetCurrentPoint(GameView.Scroller.Content).Position
                Dim UpperPoint As Point
                Dim LowerPoint As Point
                UpperPoint.X = Math.Min(CurPressPoint.X, PressPoint.X)
                UpperPoint.Y = Math.Min(CurPressPoint.Y, PressPoint.Y)
                LowerPoint.X = Math.Max(CurPressPoint.X, PressPoint.X)
                LowerPoint.Y = Math.Max(CurPressPoint.Y, PressPoint.Y)
                Dim RectSize = LowerPoint.ToVector2 - UpperPoint.ToVector2
                Dim a = CurRect.Aera
                a.Width = DesignStatus.AlimentGrid.CeilingAlign(RectSize.X)
                a.Height = DesignStatus.AlimentGrid.CeilingAlign(RectSize.Y)
                a.X = DesignStatus.AlimentGrid.FloorAlign(UpperPoint.X)
                a.Y = DesignStatus.AlimentGrid.FloorAlign(UpperPoint.Y)
                CurRect.Aera = a
            End If
        End Sub
        Private Sub GameObjectViewerContainer_PointerPressed(sender As Object, e As PointerRoutedEventArgs) Handles GameObjectViewerContainer.PointerPressed
            Dim pt = e.GetCurrentPoint(GameView.Scroller.Content)
            If pt.PointerDevice.PointerDeviceType = Windows.Devices.Input.PointerDeviceType.Mouse Then
                If pt.Properties.IsRightButtonPressed Then
                    Return
                End If
            End If
            If GameObjectViewerContainer.ManipulationMode = ManipulationModes.System Then
                Return
            End If
            PressPoint = pt.Position
            IsDrawing = True
            Dim a = CurRect.Aera
            a.Width = 0
            a.Height = 0
            a.X = DesignStatus.AlimentGrid.FloorAlign(PressPoint.X)
            a.Y = DesignStatus.AlimentGrid.FloorAlign(PressPoint.Y)
            CurRect.Aera = a
            GameObjectViewerContainer.CapturePointer(e.Pointer)
        End Sub
        Dim rnd As New Random
        Private Sub GameObjectViewerContainer_PointerReleased(sender As Object, e As PointerRoutedEventArgs) Handles GameObjectViewerContainer.PointerReleased
            If Not IsDrawing Then
                Return
            End If
            IsDrawing = False
            GameObjectViewerContainer.ReleasePointerCaptures()
            If CurRect.Aera.Width < 4 OrElse CurRect.Aera.Height < 4 Then
                Return
            End If
            Dim buf(2) As Byte
            rnd.NextBytes(buf)
            Dim solidBlock As New SolidColorBlock(CurRect.Aera, Color.FromArgb(255, buf(0), buf(1), buf(2)))
            GamePanel.Add(solidBlock)
            GameView.RaiseResourceReload()
        End Sub

        Private Sub BtnToggleBurgerL1_Click(sender As Object, e As RoutedEventArgs)
            BurgerL1.IsPaneOpen = Not BurgerL1.IsPaneOpen
            If Not BurgerL1.IsPaneOpen Then
                LstLeftBarLv1.SelectedIndex = -1
            End If
        End Sub

        Private Sub LstLeftBarLv1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles LstLeftBarLv1.SelectionChanged
            BurgerL2.IsPaneOpen = LstLeftBarLv1.SelectedIndex >= 0
        End Sub

        '选择Xaml对象
        Private Sub GameObjectViewerContainer_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles GameObjectViewerContainer.Tapped
            Dim selectedobj = From o In VisualTreeHelper.FindElementsInHostCoordinates(e.GetPosition(Me), GameObjectViewerContainer)
                              Order By Canvas.GetZIndex(o) Descending
            If selectedobj.Any Then
                Dim elem = selectedobj.First
                Debug.WriteLine($"选择了Xaml对象: 左:{Canvas.GetLeft(elem)}, 上:{Canvas.GetTop(elem)}")
            Else
                Debug.WriteLine("什么都没选择")
            End If
        End Sub

        Private Sub BtnToggleProp_Click(sender As Object, e As RoutedEventArgs)
            BurgerL3.IsPaneOpen = Not BurgerL3.IsPaneOpen
        End Sub

        Dim isCtrlPressed As Boolean
        Private Sub WorldBuilderPage_KeyUp(sender As Object, e As KeyRoutedEventArgs) Handles Me.KeyUp
            Select Case e.Key
                Case Windows.System.VirtualKey.Control
                    isCtrlPressed = False

            End Select
        End Sub

        Private Sub Page_KeyDown(sender As Object, e As KeyRoutedEventArgs)
            Select Case e.Key
                Case Windows.System.VirtualKey.Control
                    isCtrlPressed = True
                Case Windows.System.VirtualKey.Z
                    If isCtrlPressed Then
                        Undo()
                    End If
            End Select
        End Sub

        Private Sub Undo()
            Dim count = GamePanel.StaticObjects.Count
            If count > 0 Then
                GamePanel.StaticObjects.RemoveAt(count - 1)
            End If
        End Sub

        '网格对齐
        Private Async Sub AlignmentSelectionMenuItems_Click(sender As Object, e As RoutedEventArgs)
            Dim item = DirectCast(sender, ToggleMenuFlyoutItem)
            Dim align%
            Dim updateCheck = True
            Select Case item.Text
                Case "无"
                    DesignStatus.AlimentGrid.GridAlignment = 1
                Case "自定义..."
                    Dim str = Await InputBoxAsync("输入自定义的网格对齐", "输入数值", InputScopeNameValue.Number)
                    If Integer.TryParse(str, align) Then
                        If align <= 1 Then
                            DesignStatus.AlimentGrid.GridAlignment = 1
                        Else
                            DesignStatus.AlimentGrid.GridAlignment = align
                        End If
                    Else
                        updateCheck = False
                    End If
                Case Else
                    If Integer.TryParse(item.Text, align) Then
                        DesignStatus.AlimentGrid.GridAlignment = align
                    Else
                        updateCheck = False
                    End If
            End Select
            If updateCheck Then
                For Each itm As ToggleMenuFlyoutItem In AlignmentSubMenu.Items
                    itm.IsChecked = itm.Text = item.Text
                Next
            Else
                item.IsChecked = False
                Await MsgBoxAsync("输入的数字格式不正确", False, "输入错误")
            End If
        End Sub

        Private Sub BtnObjViewer_Click(sender As Object, e As RoutedEventArgs)
            Frame.Navigate(GetType(ObjectViewerPage))
        End Sub

        Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
            If Frame.CanGoBack Then
                Frame.GoBack()
            Else
                App.Current.Exit()
            End If
        End Sub

        Private Sub BtnUndo_Click(sender As Object, e As RoutedEventArgs)
            Undo()
        End Sub

        Private Sub ChkIsEditMode_Checked(sender As Object, e As RoutedEventArgs) Handles ChkIsEditMode.Checked
            GameObjectViewerContainer.ManipulationMode = ManipulationModes.All
        End Sub

        Private Sub ChkIsEditMode_Unchecked(sender As Object, e As RoutedEventArgs) Handles ChkIsEditMode.Unchecked
            GameObjectViewerContainer.ManipulationMode = ManipulationModes.System
        End Sub

        Private Sub BtnShortcut_Click(sender As Object, e As TappedRoutedEventArgs)
            Dim btn = DirectCast(sender, FrameworkElement)
            Dim shortcut = TryCast(btn.DataContext, N2DesignerShortcut)
            If shortcut IsNot Nothing Then
                shortcut.OnClick?.Invoke(sender, e)
            End If
        End Sub
    End Class
End Namespace