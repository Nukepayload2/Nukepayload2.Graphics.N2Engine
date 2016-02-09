Imports System.Reflection
''' <summary>
''' 可移植的可视对象面板
''' </summary>
Public MustInherit Class GamePanel
    Implements IDisposable
    Public Property PointerLocation As Point
    Public Property AnimObjects As New List(Of AnimatedVisual)
    Public Property StaticObjects As New List(Of StaticVisual)
    Public Property ViewingAera As New ViewingAeraRectangle(New Rect, Colors.Red)
    Public Event SizeChanged(NewSize As Size)
    Public Event Updating()
    Dim _SpaceSize As Size
    Public Property SpaceSize As Size
        Get
            Return _SpaceSize
        End Get
        Set(value As Size)
            If _SpaceSize <> value Then
                _SpaceSize = value
                RaiseEvent SizeChanged(value)
            End If
        End Set
    End Property
    Public Sub Add(obj As GameVisual)
        If obj Is Nothing Then Throw New ArgumentNullException(NameOf(obj))
        If obj.GetType.IsAssignableFrom(GetType(StaticVisual)) Then
            StaticObjects.Add(DirectCast(obj, StaticVisual))
        ElseIf obj.GetType.IsAssignableFrom(GetType(AnimatedVisual)) Then
            AnimObjects.Add(DirectCast(obj, AnimatedVisual))
        Else
            Throw New ArgumentException("类型不是AnimatedVisual也不是StaticVisual")
        End If
    End Sub
    Sub New(SpaceSize As Size)
        Me.SpaceSize = SpaceSize
        InitializeGameVisuals()
    End Sub
    ''' <summary>
    ''' 将初始游戏对象加入
    ''' </summary>
    Protected MustOverride Sub InitializeGameVisuals()
    Public Overridable Sub Update()
        RaiseEvent Updating()
        For Each anim In AnimObjects
            anim.Update(Me)
        Next
        For Each garb In RemovedAnimations
            Debug.WriteLine("移除粒子系统：" & garb.GetType.Name)
            AnimObjects.Remove(garb)
        Next
        RemovedAnimations.Clear()
    End Sub
    ''' <summary>
    ''' 用于回收播放完毕的粒子
    ''' </summary>
    Protected RemovedAnimations As New List(Of AnimatedVisual)
    ''' <summary>
    ''' 回收播放完毕的粒子
    ''' </summary>
    Protected Sub CollectUsedAnimation(Anim As AnimatedVisual)
        RemovedAnimations.Add(Anim)
    End Sub
    Protected Overridable Sub DisposeCustomObjects()

    End Sub
#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
                For Each anim In AnimObjects
                    anim.Presenter.Dispose()
                Next
                AnimObjects.Clear()
                For Each stat In StaticObjects
                    stat.Presenter.Dispose()
                Next
                StaticObjects.Clear()
                DisposeCustomObjects()
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
