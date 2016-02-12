''' <summary>
''' 抛射体的轨迹
''' </summary>
Public Class ProjectileTrack
    Inherits AnimatedVisual
    Public Property FireFrom As Vector2
    Public Property TargetLocation As Vector2
    Public Overrides ReadOnly Property Presenter As GameVisualView = New ProjectileTrackView(Me)
End Class
