Imports System.Reflection
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class ObjectViewerViewModel
        Public Property Types As New CollectionViewSource With {.IsSourceGrouped = True, .ItemsPath = New PropertyPath("Group")}
        Sub New()
            Dim asm = Me.GetType.GetTypeInfo.Assembly
            Dim grouped = From tp In asm.GetTypes Select tp, tp.Name Group By tp.Namespace Into Group
            Types.Source = grouped
        End Sub
    End Class
End Namespace