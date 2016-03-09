
Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 强制同步运行异步的任务。仅用于绘制。
    ''' </summary>
    Module WaitTask
        ''' <summary>
        ''' 强制同步运行无返回值的任务
        ''' </summary>
        <Extension>
        Sub RunSync(Source As Task)
            Dim tsk = Task.Run(Async Function()
                                   Await Source
                               End Function)
            tsk.Wait()
        End Sub
        ''' <summary>
        ''' 强制同步运行有返回值的任务
        ''' </summary>
        <Extension>
        Function RunSync(Of T)(Source As Task(Of T)) As T
            Dim retv As T
            Dim tsk = Task.Run(Async Function()
                                   retv = Await Source
                               End Function)
            tsk.Wait()
            Return retv
        End Function
        ''' <summary>
        ''' 在CoreDispatcher所在线程强制同步运行无返回值的任务
        ''' </summary>
        <Extension>
        Sub RunSync(act As Func(Of Task), Dispatcher As Core.CoreDispatcher)
            Dim tsk = Task.Run(Async Function() As Task
                                   Await Dispatcher.RunAsync(Core.CoreDispatcherPriority.Normal,
                                    Async Sub()
                                        Await (act.Invoke)
                                    End Sub)
                               End Function)
            tsk.Wait()
        End Sub
        ''' <summary>
        ''' 在CoreDispatcher所在线程强制同步运行有返回值的任务
        ''' </summary>
        <Extension>
        Function RunSync(Of T)(fun As Func(Of Task(Of T)), Dispatcher As Core.CoreDispatcher) As T
            Dim retv As T
            Dim unlck = False
            Dim tsk = Task.Run(Async Function()
                                   Await Dispatcher.RunAsync(Core.CoreDispatcherPriority.Normal,
                                    Async Sub()
                                        retv = Await (fun.Invoke)
                                        unlck = True
                                    End Sub)
                               End Function)
            tsk.Wait()
            Threading.SpinWait.SpinUntil(Function() unlck)
            Return retv
        End Function
    End Module

End Namespace
