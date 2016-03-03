' “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

Imports Windows.UI.Xaml.Shapes
''' <summary>
''' 可用于自身或导航至 Frame 内部的空白页。
''' </summary>
Public NotInheritable Class WorldBuilderPage
    Inherits Page

    Dim PressPoint As Point
    Dim IsDrawing As Boolean
    Dim CurRect As New Rectangle With {.Stroke = New SolidColorBrush(Colors.Red), .StrokeThickness = 2}
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
            CurRect.Width = RectSize.X
            CurRect.Height = RectSize.Y
            Canvas.SetLeft(CurRect, UpperPoint.X)
            Canvas.SetTop(CurRect, UpperPoint.Y)
        End If
    End Sub
    Private Sub InkInputAera_PointerPressed(sender As Object, e As PointerRoutedEventArgs) Handles InkInputAera.PointerPressed
        PressPoint = e.GetCurrentPoint(InkInputAera).Position
        IsDrawing = True
        CurRect.Width = 0
        CurRect.Height = 0
        Canvas.SetLeft(CurRect, PressPoint.X)
        Canvas.SetTop(CurRect, PressPoint.Y)
        InkInputAera.CapturePointer(e.Pointer)
        CurRect.Visibility = Visibility.Visible
    End Sub
    Private Sub InkInputAera_PointerCaptureLostOrReleased(sender As Object, e As PointerRoutedEventArgs) Handles InkInputAera.PointerCaptureLost, InkInputAera.PointerReleased
        IsDrawing = False
        InkInputAera.ReleasePointerCaptures()
        CurRect.Visibility = Visibility.Collapsed
        If CurRect.Width < 4 OrElse CurRect.Height < 4 Then
            Return
        End If
        Dim placeholder = New Rectangle With {.Width = CurRect.Width, .Height = CurRect.Height, .Fill = New SolidColorBrush(Colors.White)}
        Canvas.SetLeft(placeholder, Canvas.GetLeft(CurRect))
        Canvas.SetTop(placeholder, Canvas.GetTop(CurRect))
        InkInputAera.Children.Add(placeholder)
    End Sub
    Private Sub WorldBuilderPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        InkInputAera.Children.Add(CurRect)
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
End Class