' “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供
Imports MysteryStates
Imports Nukepayload2.Graphics.N2Engine
Imports Nukepayload2.VisualBasicExtensions.UWP
Imports Windows.UI.Xaml.Shapes
Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 可用于自身或导航至 Frame 内部的空白页。
    ''' </summary>
    Public NotInheritable Class WorldBuilderPage
        Inherits Page

        Dim PressPoint As Point
        Dim IsDrawing As Boolean
        Dim CurRect As New Rectangle With {.Stroke = New SolidColorBrush(Colors.Red), .StrokeThickness = 2}
        Dim DesignStatus As New DesignerStatus
        Private Sub InkInputAera_PointerMoved(sender As Object, e As PointerRoutedEventArgs) Handles InkInputAera.PointerMoved
            If IsDrawing Then
                Dim CurPressPoint = e.GetCurrentPoint(InkInputAera).Position
                Dim UpperPoint As Point
                Dim LowerPoint As Point
                UpperPoint.X = Math.Min(CurPressPoint.X, PressPoint.X)
                UpperPoint.Y = Math.Min(CurPressPoint.Y, PressPoint.Y)
                LowerPoint.X = Math.Max(CurPressPoint.X, PressPoint.X)
                LowerPoint.Y = Math.Max(CurPressPoint.Y, PressPoint.Y)
                Dim RectSize = LowerPoint.ToVector2 - UpperPoint.ToVector2
                CurRect.Width = DesignStatus.AlimentGrid.CeilingAlign(RectSize.X)
                CurRect.Height = DesignStatus.AlimentGrid.CeilingAlign(RectSize.Y)
                Canvas.SetLeft(CurRect, DesignStatus.AlimentGrid.FloorAlign(UpperPoint.X))
                Canvas.SetTop(CurRect, DesignStatus.AlimentGrid.FloorAlign(UpperPoint.Y))
            End If
        End Sub
        Private Sub InkInputAera_PointerPressed(sender As Object, e As PointerRoutedEventArgs) Handles InkInputAera.PointerPressed
            PressPoint = e.GetCurrentPoint(InkInputAera).Position
            IsDrawing = True
            CurRect.Width = 0
            CurRect.Height = 0
            Canvas.SetLeft(CurRect, DesignStatus.AlimentGrid.FloorAlign(PressPoint.X))
            Canvas.SetTop(CurRect, DesignStatus.AlimentGrid.FloorAlign(PressPoint.Y))
            InkInputAera.CapturePointer(e.Pointer)
            CurRect.Visibility = Visibility.Visible
        End Sub
        Dim rnd As New Random
        Private Sub InkInputAera_PointerReleased(sender As Object, e As PointerRoutedEventArgs) Handles InkInputAera.PointerReleased
            IsDrawing = False
            InkInputAera.ReleasePointerCaptures()
            CurRect.Visibility = Visibility.Collapsed
            If CurRect.Width < 4 OrElse CurRect.Height < 4 Then
                Return
            End If
            Dim buf(2) As Byte
            rnd.NextBytes(buf)
            Dim placeholder = New Rectangle With {.Width = CurRect.Width, .Height = CurRect.Height, .Fill = New SolidColorBrush(Color.FromArgb(255, buf(0), buf(1), buf(2)))}
            Canvas.SetLeft(placeholder, Canvas.GetLeft(CurRect))
            Canvas.SetTop(placeholder, Canvas.GetTop(CurRect))
            InkInputAera.Children.Add(placeholder)
        End Sub
        Private Sub WorldBuilderPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            InkInputAera.Children.Add(CurRect)
            Canvas.SetZIndex(CurRect, 16)
            [AddHandler](Page.KeyDownEvent, New KeyEventHandler(AddressOf Page_KeyDown), True)
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
        Private Sub InkInputAera_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles InkInputAera.Tapped
            Dim selectedobj = From o In VisualTreeHelper.FindElementsInHostCoordinates(e.GetPosition(Me), InkInputAera)
                              Order By Canvas.GetZIndex(o) Descending
            If selectedobj.Any Then
                Dim elem = selectedobj.First
                Debug.WriteLine($"选择了对象: 左:{Canvas.GetLeft(elem)}, 上:{Canvas.GetTop(elem)}")
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
            Dim count = InkInputAera.Children.Count
            If count > 0 Then
                InkInputAera.Children.RemoveAt(count - 1)
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
    End Class
End Namespace