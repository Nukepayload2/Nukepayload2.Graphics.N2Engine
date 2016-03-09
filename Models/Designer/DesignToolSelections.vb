Namespace Global.Nukepayload2.Graphics.N2Engine
    ''' <summary>
    ''' 编辑器怎样编辑一段数据
    ''' </summary>
    Public Enum DesignToolSelections
        ''' <summary>
        ''' 自动选择
        ''' </summary>
        Auto
        ''' <summary>
        ''' 按文本格式编辑
        ''' </summary>
        TextEditor
        ''' <summary>
        ''' 按数字格式编辑
        ''' </summary>
        NumberEditor
        ''' <summary>
        ''' 用于编辑<see cref="Vector2"/>, <see cref="Vector3"/>和<see cref="Vector4"/>
        ''' </summary>
        VectorEditor
        ''' <summary>
        ''' 用于编辑<see cref="Matrix3x2"/>, <see cref="Matrix4x4"/>和<see cref="Matrix5x4"/>
        ''' </summary>
        MatrixEditor
        ''' <summary>
        ''' 用于编辑一组数据
        ''' </summary>
        ArrayEditor
        ''' <summary>
        ''' 用于选取单一的颜色
        ''' </summary>
        SolidColorEditor
        ''' <summary>
        ''' 用于生成线性渐变的颜色
        ''' </summary>
        LinearGradientEditor
        ''' <summary>
        ''' 用于生成径向渐变的颜色
        ''' </summary>
        RadiusGradientEditor

    End Enum
End Namespace

