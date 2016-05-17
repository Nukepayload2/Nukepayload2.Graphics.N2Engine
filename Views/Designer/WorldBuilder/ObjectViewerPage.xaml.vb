' “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍
Imports System.Reflection
Imports System.Text

Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 可用于自身或导航至 Frame 内部的空白页。
    ''' </summary>
    Public NotInheritable Class ObjectViewerPage
        Inherits Page

        Private Sub inView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles inView.SelectionChanged
            If inView.SelectedIndex > -1 Then
                Dim sb As New StringBuilder
                Call New ObjectViewer().AnalyzeType(sb, DirectCast(inView.SelectedItem.tp, Type))
                If TxtObjCode IsNot Nothing Then
                    TxtObjCode.Text = sb.ToString
                    AdjustView()
                End If
            Else
                TxtObjCode.Text = ""
                AdjustView()
            End If
        End Sub

        Private Sub ObjectViewerPage_SizeChanged(sender As Object, e As SizeChangedEventArgs) Handles Me.SizeChanged
            AdjustView()
        End Sub

        Private Sub AdjustView()
            If ActualWidth / ActualHeight < 0.9 Then
                Grid.SetColumnSpan(LstTypes, 2)
                Grid.SetColumn(TxtObjCode, 0)
                Grid.SetColumnSpan(TxtObjCode, 2)
                If Not String.IsNullOrEmpty(TxtObjCode.Text) Then
                    TxtObjCode.Visibility = Visibility.Visible
                    TxtObjCode.Focus(FocusState.Programmatic)
                Else
                    TxtObjCode.Visibility = Visibility.Collapsed
                End If
            Else
                Grid.SetColumnSpan(LstTypes, 1)
                Grid.SetColumn(TxtObjCode, 1)
                Grid.SetColumnSpan(TxtObjCode, 1)
                TxtObjCode.Visibility = Visibility.Visible
            End If
        End Sub

        Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
            If Not String.IsNullOrEmpty(TxtObjCode.Text) AndAlso ActualWidth / ActualHeight < 0.9 Then
                inView.SelectedIndex = -1
            Else
                If Frame.CanGoBack Then
                    Frame.GoBack()
                Else
                    App.Current.Exit()
                End If
            End If
        End Sub

        Private Sub ObjectViewerPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            AdjustView()
        End Sub
    End Class
End Namespace