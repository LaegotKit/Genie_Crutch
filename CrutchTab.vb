Imports System.Drawing

Public Class CrutchTab
    Public Event TouchPart(ByVal WoundType As Crutch.WoundType, ByVal BodyPart As Body.Part, ByVal PreCommand As String, ByVal PostCommand As String)
    Public Event TouchType(ByVal type As String)
    Public Event CloseTab()

    Private m_CrutchForm As CrutchForm
    Public Property CrutchForm() As CrutchForm
        Get
            Return m_CrutchForm
        End Get
        Set(ByVal value As CrutchForm)
            m_CrutchForm = value
        End Set
    End Property

    Private m_Patient As String = String.Empty
    Public Property Patient() As String
        Get
            Return m_Patient
        End Get
        Set(ByVal value As String)
            m_Patient = value
        End Set
    End Property

    Private m_WoundList As New ArrayList
    Public Property WoundList() As ArrayList
        Get
            Return m_WoundList
        End Get
        Set(ByVal value As ArrayList)
            m_WoundList = value
        End Set
    End Property

    Public Sub SetVitalityInternal(ByVal Percent As Integer)
        If Percent = 100 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(1)
        ElseIf Percent > 90 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(2)
        ElseIf Percent > 80 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(3)
        ElseIf Percent > 70 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(4)
        ElseIf Percent > 60 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(5)
        ElseIf Percent > 50 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(6)
        ElseIf Percent > 40 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(7)
        ElseIf Percent > 30 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(8)
        ElseIf Percent > 20 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(9)
        ElseIf Percent > 10 Then
            Vitality.ForegroundColor = CrutchForm.ColorList(10)
        Else
            Vitality.ForegroundColor = CrutchForm.ColorList(11)
        End If
        Vitality.Value = Percent
    End Sub

    Public Sub SetPoisonInternal(ByVal Counter As Integer)
        If Counter > 0 Then
            PoisonCount.Text = Counter.ToString
            PoisonCount.Visible = True
        End If

        Poison.Color = Color.Red
    End Sub

    Public Sub SetDiseaseInternal()
        Disease.Color = Color.Red
    End Sub

    Public Sub UpdateImageInternal(ByVal WoundType As Crutch.WoundType, ByVal BodyPart As Body.Part, ByVal Level As Integer)
        Dim oBody As Body = GetBodyControl(WoundType)
        If Not IsNothing(oBody) Then
            oBody.ChangeColor(BodyPart, CrutchForm.ColorList(Level))
        End If

        WoundList.Add(New Wound(WoundType, BodyPart, Level))
    End Sub

    Private Function GetBodyControl(ByVal WoundType As Crutch.WoundType) As Body
        Select Case WoundType
            Case Crutch.WoundType.FreshExternal
                Return BodyFreshExternal
            Case Crutch.WoundType.ScarExternal
                Return BodyScarExternal
            Case Crutch.WoundType.FreshInternal
                Return BodyFreshInternal
            Case Crutch.WoundType.ScarInternal
                Return BodyScarInternal
        End Select

        Return Nothing
    End Function

    Public Sub ResetImagesInternal()
        SetVitalityInternal(0)
        WoundList.Clear()
        PoisonCount.Visible = False
        Poison.Color = Color.Black
        Disease.Color = Color.Black

        ResetImageInternal(BodyFreshExternal)
        ResetImageInternal(BodyScarExternal)
        ResetImageInternal(BodyFreshInternal)
        ResetImageInternal(BodyScarInternal)
    End Sub

    Private Sub ResetImageInternal(ByRef Body As Body)
        Body.ChangeColor(Body.Part.Head, Color.Black)
        Body.ChangeColor(Body.Part.LeftEye, Color.Black)
        Body.ChangeColor(Body.Part.RightEye, Color.Black)
        Body.ChangeColor(Body.Part.Neck, Color.Black)
        Body.ChangeColor(Body.Part.Chest, Color.Black)
        Body.ChangeColor(Body.Part.Abdomen, Color.Black)
        Body.ChangeColor(Body.Part.LeftArm, Color.Black)
        Body.ChangeColor(Body.Part.LeftHand, Color.Black)
        Body.ChangeColor(Body.Part.LeftLeg, Color.Black)
        Body.ChangeColor(Body.Part.RightArm, Color.Black)
        Body.ChangeColor(Body.Part.RightHand, Color.Black)
        Body.ChangeColor(Body.Part.RightLeg, Color.Black)
        Body.ChangeColor(Body.Part.Back, Color.Black)
        Body.ChangeColor(Body.Part.Tail, Color.Black)
        Body.ChangeColor(Body.Part.Skin, Color.Black)
        Body.Tail.Visible = False
    End Sub

#Region "Events"

    Private Sub BodyFreshExternal_Clicked(ByVal Part As Body.Part) Handles BodyFreshExternal.BodyPartClicked
        RaiseEvent TouchPart(Crutch.WoundType.FreshExternal, Part, "", "")
    End Sub

    Private Sub BodyScarExternal_Clicked(ByVal Part As Body.Part) Handles BodyScarExternal.BodyPartClicked
        RaiseEvent TouchPart(Crutch.WoundType.ScarExternal, Part, "", "")
    End Sub

    Private Sub BodyFreshInternal_Clicked(ByVal Part As Body.Part) Handles BodyFreshInternal.BodyPartClicked
        RaiseEvent TouchPart(Crutch.WoundType.FreshInternal, Part, "", "")
    End Sub

    Private Sub BodyScarInternal_Clicked(ByVal Part As Body.Part) Handles BodyScarInternal.BodyPartClicked
        RaiseEvent TouchPart(Crutch.WoundType.ScarInternal, Part, "", "")
    End Sub

    Private Sub BodyMenuFreshExternal_BodyPartMenuClicked(ByVal Part As Body.Part, ByVal Method As String) Handles BodyFreshExternal.BodyPartMenuClicked
        RaiseEvent TouchPart(Crutch.WoundType.FreshExternal, Part, "", " " & Method)
    End Sub

    Private Sub BodyScarExternal_BodyPartMenuClicked(ByVal Part As Body.Part, ByVal Method As String) Handles BodyScarExternal.BodyPartMenuClicked
        RaiseEvent TouchPart(Crutch.WoundType.ScarExternal, Part, "", " " & Method)
    End Sub

    Private Sub BodyFreshInternal_BodyPartMenuClicked(ByVal Part As Body.Part, ByVal Method As String) Handles BodyFreshInternal.BodyPartMenuClicked
        RaiseEvent TouchPart(Crutch.WoundType.FreshInternal, Part, "", " " & Method)
    End Sub

    Private Sub BodyScarInternal_BodyPartMenuClicked(ByVal Part As Body.Part, ByVal Method As String) Handles BodyScarInternal.BodyPartMenuClicked
        RaiseEvent TouchPart(Crutch.WoundType.ScarInternal, Part, "", " " & Method)
    End Sub

    Private Sub HealthBar_Click() Handles Vitality.MyClick
        RaiseEvent TouchType("vitality")
    End Sub

    Private Sub Poison_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Poison.Click
        RaiseEvent TouchType("poison")
    End Sub

    Private Sub Disease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Disease.Click
        RaiseEvent TouchType("disease")
    End Sub

#End Region

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        RaiseEvent CloseTab()
    End Sub
End Class
