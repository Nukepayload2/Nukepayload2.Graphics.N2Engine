Public Enum GameHitTestFilterBehavior
    ''' <summary>
    ''' 继续测试
    ''' </summary>
    ContinueHitest
    ''' <summary>
    ''' 不要测试当前的
    ''' </summary>
    SkipCurrent
    ''' <summary>
    ''' 不要继续测试这一组的。比如正在测试一组<see cref="StaticVisual"/>，遇到这个参数就不再测试这一组。
    ''' </summary>
    AbortCurrentGroup
End Enum