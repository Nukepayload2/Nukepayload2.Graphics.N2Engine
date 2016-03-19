Imports System.Reflection
Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 可移植的可视对象面板
    ''' </summary>
    Public MustInherit Class GamePanel
        Implements IDisposable
        ''' <summary>
        ''' 如果要用Box2D进行碰撞检测，派生类继承时初始化这个对象。
        ''' </summary>
        Public Property Collision As Box2D.World
        ''' <summary>
        ''' 视图滚动时用于记录屏幕上指针的位置
        ''' </summary>
        Public Property PointerLocation As Point
        ''' <summary>
        ''' 关于点光源的定义
        ''' </summary>
        Public Property SpotLights As SpotLightInformation()
        ''' <summary>
        ''' 会变形的对象
        ''' </summary>
        Public Property AnimObjects As New List(Of AnimatedVisual)
        ''' <summary>
        ''' 不会变形的对象
        ''' </summary>
        Public Property StaticObjects As New List(Of StaticVisual)
        ''' <summary>
        ''' 视图滚动时记录现在在观测的区域
        ''' </summary>
        Public Property ViewingAera As New ViewingAeraRectangle(New Rect, Colors.Red)
        ''' <summary>
        ''' 设定Size属性时触发
        ''' </summary>
        Public Event SizeChanged(NewSize As Size)
        ''' <summary>
        ''' 提供正在更新画面的通知
        ''' </summary>
        Public Event Updating()
        Dim _SpaceSize As Size
        ''' <summary>
        ''' 整个空间的大小
        ''' </summary>
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
        ''' <summary>
        ''' 用于添加不知道具体类别的物件
        ''' </summary>
        Public Sub Add(obj As GameVisual)
            If obj Is Nothing Then Throw New ArgumentNullException(NameOf(obj))
            Dim objType = obj.GetType
            If GetType(StaticVisual).IsAssignableFrom(objType) Then
                StaticObjects.Add(DirectCast(obj, StaticVisual))
            ElseIf GetType(AnimatedVisual).IsAssignableFrom(objType) Then
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
        ''' <summary>
        ''' 更新画面
        ''' </summary>
        Public Overridable Sub Update()
            RaiseEvent Updating()
            SyncLock AnimObjects
                For Each anim In AnimObjects
                    anim.Update(Me)
                Next
            End SyncLock
            For Each garb In Aggregate anim In AnimObjects Where anim.IsStopped Into ToArray
                Debug.WriteLine("移除动画：" & garb.GetType.Name)
                AnimObjects.Remove(garb)
            Next
        End Sub
        ''' <summary>
        ''' 派生类继承时可以重写以释放自定义的对象
        ''' </summary>
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

End Namespace
