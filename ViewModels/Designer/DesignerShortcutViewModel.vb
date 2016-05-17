Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class DesignerShortcutViewModel
        Public Property Items As New List(Of N2DesignerShortcut)
        Sub New()
            Items.Add(New N2DesignerShortcut(New DropperIcon, "用于拾取颜色和设定画笔粗细", Async Sub(sender, e) Await New ColorPickerDialog().ShowAsync))
        End Sub
    End Class
End Namespace