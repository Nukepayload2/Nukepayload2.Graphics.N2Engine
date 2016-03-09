Imports System.Reflection
Imports System.Text
Namespace Global.Nukepayload2.Graphics.N2Engine
    Public Class ObjectViewer
        Public Function AnalyzeMethod(mt As MethodInfo) As String
            Dim sb As New StringBuilder
            With mt
                For Each attrib In mt.CustomAttributes
                    AnalyzeCustomAttributes(sb, attrib)
                Next
                sb.AppendLine()
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
                'sb.AppendLine("MSIL格式的声明:")
                'sb.Append(".method " + mt.Attributes.ToString.Replace(",", "").ToLowerInvariant + " " + mt.ReturnType.Name + " " + mt.Name + "(" + AnalyzeParameter(mt, True) + ") cil managed")
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
                For Each cust In param.CustomAttributes
                    AnalyzeCustomAttributes(params, cust)
                Next
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

        Private Shared Sub AnalyzeCustomAttributes(params As StringBuilder, cust As CustomAttributeData)
            Dim attr = cust.AttributeType.ToString
            params.Append($"<{attr.Substring(0, attr.Length - 9)}(")
            For i = 0 To cust.NamedArguments.Count - 1
                Dim args = cust.NamedArguments(i)
                params.Append(args.MemberName).Append(" := ").Append(args.TypedValue.Value.ToString)
            Next
            params.Append(")>")
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
                AnalyzeType(bigsb, htp)
            Next
            Return bigsb.ToString
        End Function

        Public Sub AnalyzeType(bigsb As StringBuilder, htp As Type)
            Dim tp = htp.GetTypeInfo
            AnalyzeTypeInformation(bigsb, htp, tp)
            For Each cto As ConstructorInfo In htp.GetConstructors
                bigsb.AppendLine("Sub New(" + AnalyzeConstructor(cto, False) + ")") ' + vbCrLf + "MSIL格式的声明:" + vbCrLf + ".method " + cto.Attributes.ToString.Replace(",", "").ToLowerInvariant + " " + " " + cto.Name + "(" + AnalyzeConstructor(cto, True) + ") cil managed"
            Next
            For Each mt As MethodInfo In htp.GetMethods
                If Not mt.IsSpecialName Then bigsb.AppendLine(AnalyzeMethod(mt))
            Next
            For Each pr As PropertyInfo In htp.GetProperties
                AnalyzeProperty(bigsb, pr)
            Next
            For Each fi As FieldInfo In htp.GetFields()
                AnalyzeField(bigsb, fi)
            Next
            For Each ev As EventInfo In htp.GetEvents
                bigsb.AppendLine("Event " + ev.Name + " As " + ev.EventHandlerType.ToString).AppendLine()
            Next
        End Sub

        Private Shared Sub AnalyzeTypeInformation(bigsb As StringBuilder, htp As Type, tp As TypeInfo)
            Dim ismodule As Boolean = True
            With tp
                Dim sb As New StringBuilder
                For Each attrib In tp.CustomAttributes
                    AnalyzeCustomAttributes(sb, attrib)
                Next
                sb.AppendLine()
                If .IsPublic Then sb.Append("Public ")
                If .IsArray Then
                    sb.AppendLine(tp.Name + "(" + tp.GetArrayRank.ToString + ") As " + tp.ToString.Replace("[]", ""))
                ElseIf .IsClass Then
                    If .IsAbstract AndAlso Not .IsSealed Then
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
                    If .IsSealed AndAlso Not ismodule Then sb.Append("NotInheritable ")
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
                    Dim inh As String = ""
                    If tp.BaseType IsNot Nothing AndAlso tp.BaseType IsNot GetType(Object) Then
                        inh = vbCrLf + "Inherits " + tp.BaseType.FullName
                    End If
                    If Not Intf.Length = 0 Then
                        itf = vbCrLf + "Implements " + Intf.ToString.Replace("+", ".").Substring(0, Intf.Length - 1)
                    End If
                    sb.AppendLine(classdpart + tp.Name + itf + inh)
                    'sb.AppendLine("'MSIL格式的声明:" + vbCrLf + ".class " + tp.Attributes.ToString.Replace(",", "").ToLowerInvariant.Replace(" class ", " ") + " " + tp.Name)
                    'sb.AppendLine("extends [" + tp.BaseType.GetTypeInfo.Module.Name.Substring(0, tp.BaseType.GetTypeInfo.Module.Name.LastIndexOf(".")) + "]" + tp.BaseType.FullName)
                    'If Not Intf.Length = 0 Then sb.AppendLine("implements " + Intf.ToString.Replace("+", ".").Substring(0, Intf.Length - 1))
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
        End Sub

        Public Sub AnalyzeField(bigsb As StringBuilder, fi As FieldInfo)
            With fi
                Dim sb As New StringBuilder
                AppendPrefix(sb, fi)
                Dim ft As Type = fi.FieldType
                sb.Append(fi.Name + " As " + ft.ToString.Replace("+", ".").Replace("[]", "()"))
                bigsb.AppendLine(sb.ToString)
            End With
        End Sub

        Public Sub AnalyzeProperty(bigsb As StringBuilder, pr As PropertyInfo)
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
                Dim skipdecl As Boolean = True
                If .CanRead AndAlso .CanWrite Then
                    AppendPrefixForPropertyMethod(sb, .GetMethod)
                    skipdecl = .GetMethod.IsPublic AndAlso .SetMethod.IsPublic OrElse
                        .GetMethod.IsFamily AndAlso .SetMethod.IsFamily OrElse
                        .GetMethod.IsPrivate AndAlso .SetMethod.IsPrivate OrElse
                        .GetMethod.IsAssembly AndAlso .SetMethod.IsAssembly
                End If
                sb.AppendLine("Property " + .Name + " As " + .PropertyType.ToString.Replace("+", ".").Replace("[]", "()"))
                If Not skipdecl Then
                    sb.AppendLine("    Get
        '...
    End Get")
                    AppendPrefixForPropertyMethod(sb, .SetMethod)
                    sb.AppendLine("    Set
        '...
    End Get
End Property")
                End If
                bigsb.AppendLine(sb.ToString)
            End With
        End Sub

        Private Sub AppendPrefixForPropertyMethod(sb As StringBuilder, mem As MethodInfo)
            With mem
                If .IsPublic Then sb.Append("Public ")
                If .IsPrivate Then sb.Append("Private ")
                If .IsFamily Then sb.Append("Protected ")
                If .IsAssembly Then sb.Append("Friend ")
                If .IsAbstract Then
                    sb.Append("MustOverride ")
                Else
                    If .IsVirtual AndAlso Not .IsFinal Then sb.Append("Overridable ")
                End If
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
End Namespace