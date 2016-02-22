Imports Microsoft.Graphics.Canvas.Geometry

Module CanvasGeometryExtension
    <Extension>
    Friend Function Union(geo As CanvasGeometry()) As CanvasGeometry
        If geo.Length = 0 Then Return Nothing
        Dim curgeo = geo(0)
        For i = 1 To geo.Length - 1
            curgeo = geo(i).CombineWith(curgeo, New Matrix3x2, CanvasGeometryCombine.Union)
        Next
        Return curgeo
    End Function
End Module