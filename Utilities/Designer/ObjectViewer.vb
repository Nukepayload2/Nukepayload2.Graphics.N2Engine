Imports System.Reflection
Imports System.Text

Public Class ObjectViewer
    Public Function AnalyzeMethod(mt As MethodInfo) As String
        Dim sb As New StringBuilder
        With mt
            Dim parampart As String = AnalyzeParameter(mt, False)
            AppendPrefixForPropertyMethod(sb, mt)
            If .IsAbstract Then sb.Append("MustOverride ")
            If .IsFinal Then sb.Append("NotOverridable ")
            If .IsConstructor Then
                Return "Sub New(" + parampart + ")"
            ElseIf .ReturnType Is GetType(Void) Then
                sb.Append("Sub " + mt.Name + "(" + parampart + ")")
            Else
                sb.Append("Function " + mt.Name + "(" + parampart + ") As " + .ReturnType.ToString.Replace("+", ".").Replace("[]", "()"))
            End If
            sb.AppendLine()
            sb.AppendLine("'MSIL格式的声明:")
            sb.Append(".method " + mt.Attributes.ToString.Replace(",", "").ToLowerInvariant + " " + mt.ReturnType.Name + " " + mt.Name + "(" + AnalyzeParameter(mt, True) + ") cil managed")
        End With
        Return sb.ToString
    End Function

    Public Function AnalyzeParameter(mt As MethodInfo, IsIL As Boolean) As String
        Dim params As New StringBuilder
        For Each param As ParameterInfo In mt.GetParameters()
            If IsIL Then
                params.Append(param.ToString + ",")
            Else
                ProcessParamForVB(params, param)
            End If
        Next
        Return FormatArraySymbolForVB(params)
    End Function

    Private Shared Sub ProcessParamForVB(params As StringBuilder, param As ParameterInfo)
        With param
            If .IsOptional Then
                If .IsIn AndAlso Not .IsOut Then
                    params.Append("Optional " + .Name + " As " + .ParameterType.ToString.Replace("+", ".") + " = " + .DefaultValue.ToString + ",")
                ElseIf .IsOut Then
                    params.Append("Optional ByRef " + .Name + " As " + .ParameterType.ToString.Replace("&", "").Replace("+", ".") + " = " + .DefaultValue.ToString + ",")
                End If
            Else
                Dim paramsa = ""
                If Aggregate p In param.CustomAttributes Where p.AttributeType Is GetType(ParamArrayAttribute) Into Any Then
                    paramsa = "ParamArray "
                End If
                If .IsOut Then
                    params.Append("ByRef " + paramsa + .Name + " As " + .ParameterType.ToString.Replace("&", "").Replace("+", ".") + ",")
                Else
                    params.Append(paramsa + .Name + " As " + .ParameterType.ToString.Replace("+", ".") + ",")
                End If
            End If
        End With
    End Sub

    Public Function AnalyzeConstructor(mt As ConstructorInfo, IsIL As Boolean) As String
        Dim params As New StringBuilder
        For Each param As ParameterInfo In mt.GetParameters()
            If IsIL Then
                params.Append(param.ToString + ",")
            Else
                ProcessParamForVB(params, param)
            End If
        Next
        Return FormatArraySymbolForVB(params)
    End Function

    Private Shared Function FormatArraySymbolForVB(params As StringBuilder) As String
        If params.Length > 0 Then
            params.Remove(params.Length - 1, 1)
            Return params.ToString.Replace("[]", "()")
        Else
            Return String.Empty
        End If
    End Function

    Public Function AnalyzeCurrentAssembly() As String
        Dim asm1 As Assembly = Me.GetType.GetTypeInfo.Assembly
        Dim asmtypes As Type() = asm1.GetTypes
        Dim bigsb As New StringBuilder
        bigsb.AppendLine("'" + asm1.GetName.ToString)
        For Each htp As Type In asmtypes
            Dim tp = htp.GetTypeInfo
            Dim ismodule As Boolean = True
            With tp
                Dim sb As New StringBuilder
                If .IsSerializable Then sb.Append("<Serializable()>")
                If .IsPublic Then sb.Append("Public ")
                If .IsArray Then
                    sb.AppendLine(tp.Name + "(" + tp.GetArrayRank.ToString + ") As " + tp.ToString.Replace("[]", ""))
                ElseIf .IsClass Then
                    If .IsAbstract Then
                        sb.Append("MustInherit ")
                        ismodule = False
                    End If
                    For Each cto As ConstructorInfo In htp.GetConstructors
                        ismodule = False
                        Exit For
                    Next
                    For Each mt As MethodInfo In htp.GetMethods
                        Select Case mt.Name
                            Case "ToString", "GetHashCode", "GetType", "Equals"
                            Case Else
                                If Not mt.IsStatic Then ismodule = False : Exit For
                        End Select
                    Next
                    For Each fi As FieldInfo In htp.GetFields()
                        If Not fi.IsStatic Then ismodule = False : Exit For
                    Next
                    If .IsSealed And Not ismodule Then sb.Append("NotInheritable ")
                    Dim classdpart As String = "Module "
                    Dim isClass = Aggregate c In htp.GetConstructors Where Not c.IsStatic Into Any
                    If isClass Then
                        classdpart = "Class "
                    End If
                    If Not ismodule Then
                        classdpart = "Class "
                    End If
                    Dim Intf As New StringBuilder
                    Dim itf As String = ""
                    For Each irf In htp.GetInterfaces
                        Intf.Append(irf.FullName + ",")
                    Next
                    If Not Intf.Length = 0 Then
                        itf = vbCrLf + "Implements " + Intf.ToString.Replace("+", ".").Substring(0, Intf.Length - 1)
                    End If
                    Dim inh As String = ""
                    If tp.BaseType IsNot Nothing Then
                        inh = vbCrLf + "Inherits " + tp.BaseType.FullName
                    End If
                    sb.AppendLine(classdpart + tp.Name + itf + inh)
                    sb.AppendLine("'MSIL格式的声明:" + vbCrLf + ".class " + tp.Attributes.ToString.Replace(",", "").ToLowerInvariant.Replace(" class ", " ") + " " + tp.Name)
                    sb.AppendLine("extends [" + tp.BaseType.GetTypeInfo.Module.Name.Substring(0, tp.BaseType.GetTypeInfo.Module.Name.LastIndexOf(".")) + "]" + tp.BaseType.FullName)
                    If Not Intf.Length = 0 Then sb.AppendLine("implements " + Intf.ToString.Replace("+", ".").Substring(0, Intf.Length - 1))
                ElseIf .IsEnum Then
                    sb.AppendLine("Enum " + tp.Name)
                ElseIf .IsInterface Then
                    sb.AppendLine("Interface " + tp.Name)
                ElseIf .IsPointer Then
                    sb.AppendLine(tp.Name + " As " + tp.Name)
                Else
                    sb.AppendLine("Structure " + tp.ToString.Replace("+", "."))
                End If
                bigsb.AppendLine(sb.ToString)
            End With
            For Each cto As ConstructorInfo In htp.GetConstructors
                bigsb.AppendLine("Sub New(" + AnalyzeConstructor(cto, False) + ")" + vbCrLf + "'MSIL格式的声明:" + vbCrLf + ".method " + cto.Attributes.ToString.Replace(",", "").ToLowerInvariant + " " + " " + cto.Name + "(" + AnalyzeConstructor(cto, True) + ") cil managed")
            Next
            For Each mt As MethodInfo In htp.GetMethods
                bigsb.AppendLine(AnalyzeMethod(mt))
            Next
            For Each pr As PropertyInfo In htp.GetProperties
                With pr
                    Dim sb As New StringBuilder
                    If Not .CanRead Then
                        AppendPrefixForPropertyMethod(sb, .SetMethod)
                        sb.Append("WriteOnly ")
                    End If
                    If Not .CanWrite Then
                        AppendPrefixForPropertyMethod(sb, .GetMethod)
                        sb.Append("ReadOnly ")
                    End If
                    If .CanRead AndAlso .CanWrite Then
                        AppendPrefixForPropertyMethod(sb, .GetMethod)
                    End If
                    sb.AppendLine("Property " + .Name + " As " + .PropertyType.ToString.Replace("+", ".").Replace("[]", "()"))
                    sb.AppendLine("Get
'...
End Get")
                    If .CanRead AndAlso .CanWrite Then
                        AppendPrefixForPropertyMethod(sb, .SetMethod)
                    End If
                    sb.AppendLine("Set
'...
End Get
End Property")
                    bigsb.AppendLine(sb.ToString)
                End With
            Next
            For Each fi As FieldInfo In htp.GetFields()
                With fi
                    Dim sb As New StringBuilder
                    AppendPrefix(sb, fi)
                    Dim ft As Type = fi.FieldType
                    sb.Append(fi.Name + " As " + ft.ToString.Replace("+", ".").Replace("[]", "()"))
                    bigsb.AppendLine(sb.ToString)
                End With
            Next
            For Each ev As EventInfo In htp.GetEvents
                bigsb.AppendLine("Event " + ev.Name + " As " + ev.EventHandlerType.ToString)
            Next
        Next
        Return bigsb.ToString
    End Function
    Private Sub AppendPrefixForPropertyMethod(sb As StringBuilder, mem As MethodInfo)
        With mem
            If .IsPublic Then sb.Append("Public ")
            If .IsPrivate Then sb.Append("Private ")
            If .IsFamily Then sb.Append("Protected ")
            If .IsAssembly Then sb.Append("Friend ")
            If .IsStatic Then sb.Append("Shared ")
        End With
    End Sub
    Private Sub AppendPrefix(sb As StringBuilder, mem As FieldInfo)
        With mem
            If .IsPublic Then sb.Append("Public ")
            If .IsPrivate Then sb.Append("Private ")
            If .IsFamily Then sb.Append("Protected ")
            If .IsAssembly Then sb.Append("Friend ")
            If .IsStatic Then sb.Append("Shared ")
            If .IsInitOnly Then sb.Append("ReadOnly")
            If .IsLiteral Then sb.Append("Const ")
        End With
    End Sub
End Class
