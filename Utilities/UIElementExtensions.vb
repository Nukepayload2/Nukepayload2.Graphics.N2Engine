Imports Microsoft.Graphics.Canvas
Imports Windows.Graphics.Imaging

Module UIElementExtensions
    <Extension>
    Async Function CaptureScreenshot(Source As UIElement, ResourceCreator As ICanvasResourceCreator) As Task(Of CanvasBitmap)
        Dim rt As New RenderTargetBitmap()
        Await rt.RenderAsync(Source)
        Dim buf = Await rt.GetPixelsAsync
        Return CanvasBitmap.CreateFromBytes(ResourceCreator, buf.ToArray, rt.PixelWidth, rt.PixelHeight, Windows.Graphics.DirectX.DirectXPixelFormat.B8G8R8A8UIntNormalized)
    End Function
    <Extension>
    Async Function CaptureScreenshot(Source As FrameworkElement, Optional Dpiscale! = 1) As Task(Of SoftwareBitmap)
        Dim rt As New RenderTargetBitmap()
        Await rt.RenderAsync(Source, Source.ActualWidth * Dpiscale, Source.ActualHeight * Dpiscale)
        Dim buf = Await rt.GetPixelsAsync
        Return SoftwareBitmap.CreateCopyFromBuffer(buf, BitmapPixelFormat.Bgra8, rt.PixelWidth, rt.PixelHeight, BitmapAlphaMode.Premultiplied)
    End Function
End Module
