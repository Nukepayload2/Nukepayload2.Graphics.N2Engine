﻿Imports System
Imports System.Numerics

Namespace Global.Box2D
    Public Class PrismaticJointDef
        Inherits JointDef
        ' Methods
        Public Sub New()
            MyBase.type = JointType.Prismatic
            Me.localAnchor1 = Vector2.Zero
            Me.localAnchor2 = Vector2.Zero
            Me.localAxis1 = New Vector2(1!, 0!)
            Me.referenceAngle = 0!
            Me.enableLimit = False
            Me.lowerTranslation = 0!
            Me.upperTranslation = 0!
            Me.enableMotor = False
            Me.maxMotorForce = 0!
            Me.motorSpeed = 0!
        End Sub

        Public Sub Initialize(ByVal b1 As Body, ByVal b2 As Body, ByVal anchor As Vector2, ByVal axis As Vector2)
            MyBase.body1 = b1
            MyBase.body2 = b2
            Me.localAnchor1 = MyBase.body1.GetLocalPoint(anchor)
            Me.localAnchor2 = MyBase.body2.GetLocalPoint(anchor)
            Me.localAxis1 = MyBase.body1.GetLocalVector(axis)
            Me.referenceAngle = (MyBase.body2.GetAngle - MyBase.body1.GetAngle)
        End Sub


        ' Fields
        Public enableLimit As Boolean
        Public enableMotor As Boolean
        Public localAnchor1 As Vector2
        Public localAnchor2 As Vector2
        Public localAxis1 As Vector2
        Public lowerTranslation As Single
        Public maxMotorForce As Single
        Public motorSpeed As Single
        Public referenceAngle As Single
        Public upperTranslation As Single
    End Class
End Namespace

