Public Class Wound
    Implements IComparable

    Private m_oBodyPart As Body.Part
    Public Property BodyPart() As Body.Part
        Get
            Return m_oBodyPart
        End Get
        Set(ByVal value As Body.Part)
            m_oBodyPart = value
        End Set
    End Property

    Private m_oWoundType As Crutch.WoundType
    Public Property WoundType() As Crutch.WoundType
        Get
            Return m_oWoundType
        End Get
        Set(ByVal value As Crutch.WoundType)
            m_oWoundType = value
        End Set
    End Property

    Private m_iLevel As Integer = 0
    Public Property Level() As Integer
        Get
            Return m_iLevel
        End Get
        Set(ByVal value As Integer)
            m_iLevel = value
        End Set
    End Property

    Public Sub New(ByVal WoundType As Crutch.WoundType, ByVal BodyPart As Body.Part, ByVal Level As Integer)
        m_oWoundType = WoundType
        m_oBodyPart = BodyPart
        m_iLevel = Level
    End Sub

    ' Sort list by woundlevel desc
    Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
        If Not TypeOf obj Is Wound Then
            Throw New Exception("Object is not of type: Wound")
        End If

        Dim oComparer As Wound = DirectCast(obj, Wound)

        Return -Me.Level.CompareTo(oComparer.Level)
    End Function
End Class
