Option Strict Off
Public Class GraphicQualityManager
    Public Shared ReadOnly Property Current As GraphicQualityManager
    Public Shared Event QualityChanged(Quality As GraphicQualityManager)
    Sub New()
        _Current = Me
    End Sub
    Public Property DpiScale As Single = 1
    Dim _GraphicOption As GraphicQualityOptions = GraphicQualityOptions.Shadow
    Dim _EffectQuality As EffectOptimization?
    Public Property EffectQuality As EffectOptimization?
        Get
            Return _EffectQuality
        End Get
        Set(value As EffectOptimization?)
            _EffectQuality = value
            RaiseEvent QualityChanged(Me)
        End Set
    End Property
    Public Property Antialias As CanvasAntialiasing
    Public Property TextAntialias As CanvasTextAntialiasing
    Public Property GraphicOption As GraphicQualityOptions
        Get
            Return _GraphicOption
        End Get
        Set(value As GraphicQualityOptions)
            If value <>GraphicOption Then
                _GraphicOption = value
                RaiseEvent QualityChanged(Me)
            End If
        End Set
    End Property
    Public Property Shadow As Boolean
        Get
            Return GraphicOption And GraphicQualityOptions.Shadow
        End Get
        Set(value As Boolean)
            If value Then
                GraphicOption = GraphicOption Or GraphicQualityOptions.Shadow
            Else
                GraphicOption = GraphicOption And Not GraphicQualityOptions.Shadow
            End If
        End Set
    End Property
    Public Property RealtimeShapes As Boolean
        Get
            Return GraphicOption And GraphicQualityOptions.RealtimeShapes
        End Get
        Set(value As Boolean)
            If value Then
                GraphicOption = GraphicOption Or GraphicQualityOptions.RealtimeShapes
            Else
                GraphicOption = GraphicOption And Not GraphicQualityOptions.RealtimeShapes
            End If
        End Set
    End Property
End Class
