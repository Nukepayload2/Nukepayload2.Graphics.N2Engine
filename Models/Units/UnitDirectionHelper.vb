Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class UnitDirectionHelper
        ''' <summary>
        ''' 在X轴向右，Y轴向下的坐标系中获取方向
        ''' </summary>
        Public Shared Function GetDirection(angle!) As UnitDirections
            Dim ang = angle Mod (2 * Math.PI)
            If ang < 0 Then ang += 2 * Math.PI
            Return CType(CInt(ang * 4 / Math.PI) - 1, UnitDirections)
        End Function
    End Class
End Namespace
