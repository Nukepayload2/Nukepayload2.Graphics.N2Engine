Imports Microsoft.Graphics.Canvas.Geometry
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class SpotLightInformation
        ''' <summary>
        ''' 光照强度
        ''' </summary>
        Public Property LightStrength! = 0.5
        ''' <summary>
        ''' 不被照亮区域的亮度
        ''' </summary>
        Public Property SpriteBrightness! = 0.5
        ''' <summary>
        ''' 漫反射的比重
        ''' </summary>
        Public Property DiffuseAmount! = 1
        ''' <summary>
        ''' 灯光颜色
        ''' </summary>
        Public Property LightColor As Color = Colors.White
        ''' <summary>
        ''' 灯光的HDR
        ''' </summary>
        Public Property LightHDR As New Vector4(1, 1, 1, 1)
        ''' <summary>
        ''' 灯光的位置
        ''' </summary>
        Public Property LightPosition As Vector3
        ''' <summary>
        ''' 镜面反射的比重
        ''' </summary>
        Public Property SpecularAmount As Single = 1
        ''' <summary>
        ''' 镜面反射指数, 用于控制灯光的焦点
        ''' </summary>
        Public Property SpecularExponent As Single = 1
        ''' <summary>
        ''' 定义用于遮光的几何体
        ''' </summary>
        Public Property LightCollision As CanvasGeometry()
    End Class
End Namespace
