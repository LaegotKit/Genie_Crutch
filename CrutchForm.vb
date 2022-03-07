Imports System.Xml
Imports System.Windows.Forms
Imports System.Drawing
Imports XMLConfig
Imports Crutch
Public Class CrutchForm
    Private m_Host As GeniePlugin.Interfaces.IHost
    Private m_Config As XMLConfig


    Public Sub New(ByRef Host As GeniePlugin.Interfaces.IHost)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_Host = Host

        PopulateColors()
    End Sub

    Private m_Patient As String = String.Empty
    Private m_oWoundList As ArrayList
    Private m_oSelectedCrutchTab As CrutchTab

    Public Property Patient() As String
        Get
            Return m_Patient
        End Get
        Set(ByVal value As String)
            AddPatient(value)
            m_Patient = value
        End Set
    End Property

    Public ColorList(12) As System.Drawing.Color

    Private Sub PopulateColors()
        ColorList(0) = System.Drawing.Color.Black
        ColorList(1) = System.Drawing.Color.FromArgb(0, 94, 32)
        ColorList(2) = System.Drawing.Color.FromArgb(46, 121, 26)
        ColorList(3) = System.Drawing.Color.FromArgb(98, 151, 20)
        ColorList(4) = System.Drawing.Color.FromArgb(152, 182, 13)
        ColorList(5) = System.Drawing.Color.FromArgb(206, 213, 6)
        ColorList(6) = System.Drawing.Color.FromArgb(255, 242, 0)
        ColorList(7) = System.Drawing.Color.FromArgb(255, 204, 0)
        ColorList(8) = System.Drawing.Color.FromArgb(255, 153, 0)
        ColorList(9) = System.Drawing.Color.FromArgb(255, 102, 0)
        ColorList(10) = System.Drawing.Color.FromArgb(255, 51, 0)
        ColorList(11) = System.Drawing.Color.FromArgb(255, 0, 0)
    End Sub

    Delegate Sub SetVitalityDelegate(ByVal Percent As Integer)
    Public Sub SetVitality(ByVal Percent As Integer)
        If Me.InvokeRequired() = True Then
            Dim parameters() As Object = {Percent}
            Me.Invoke(New SetPoisonDelegate(AddressOf SetVitalityInternal), parameters)
        Else
            SetVitalityInternal(Percent)
        End If
    End Sub
    Private Sub SetVitalityInternal(ByVal Percent As Integer)
        If Not IsNothing(m_oSelectedCrutchTab) Then
            m_oSelectedCrutchTab.SetVitalityInternal(Percent)
        End If
    End Sub

    Delegate Sub SetPoisonDelegate(ByVal Counter As Integer)
    Public Sub SetPoison(ByVal Counter As Integer)
        If Me.InvokeRequired() = True Then
            Dim parameters() As Object = {Counter}
            Me.Invoke(New SetPoisonDelegate(AddressOf SetPoisonInternal), parameters)
        Else
            SetPoisonInternal(Counter)
        End If
    End Sub
    Private Sub SetPoisonInternal(ByVal Counter As Integer)
        If Not IsNothing(m_oSelectedCrutchTab) Then
            m_oSelectedCrutchTab.SetPoisonInternal(Counter)
        End If
    End Sub

    Delegate Sub ShowMeDelegate()
    Public Sub ShowMe()
        If Me.InvokeRequired() = True Then
            Me.Invoke(New ShowMeDelegate(AddressOf ShowMeInternal))
        Else
            ShowMeInternal()
        End If
    End Sub
    Private Sub ShowMeInternal()
        Me.Enabled = false
        Me.Show()
        Me.BringToFront()
        Me.Enabled = True
        Crutch.m_Shown = True
    End Sub
    

   Delegate Sub SetDiseaseDelegate()
    Public Sub SetDisease()
        If Me.InvokeRequired() = True Then
            Me.Invoke(New SetDiseaseDelegate(AddressOf SetDiseaseInternal))
        Else
            SetDiseaseInternal()
        End If
    End Sub
    Private Sub SetDiseaseInternal()
        If Not IsNothing(m_oSelectedCrutchTab) Then
            m_oSelectedCrutchTab.SetDiseaseInternal()
        End If
    End Sub

    Delegate Sub AddPatientDelegate(ByVal Name As String)
    Public Sub AddPatient(ByVal Name As String)
        If Me.InvokeRequired() = True Then
            Dim parameters() As Object = {Name}
            Me.Invoke(New AddPatientDelegate(AddressOf AddPatientInternal), parameters)
        Else
            AddPatientInternal(Name)
        End If
    End Sub
    Private Sub AddPatientInternal(ByVal Name As String)
        AddTab(Name)
    End Sub

    Delegate Sub UpdateImageDelegate(ByVal WoundType As Crutch.WoundType, ByVal BodyPart As Body.Part, ByVal Level As Integer)
    Public Sub UpdateImage(ByVal WoundType As Crutch.WoundType, ByVal BodyPart As Body.Part, ByVal Level As Integer)
        If Me.InvokeRequired() = True Then
            Dim parameters() As Object = {WoundType, BodyPart, Level}
            Me.Invoke(New UpdateImageDelegate(AddressOf UpdateImage), parameters)
        Else
            UpdateImageInternal(WoundType, BodyPart, Level)
        End If
    End Sub
    Private Sub UpdateImageInternal(ByVal WoundType As Crutch.WoundType, ByVal BodyPart As Body.Part, ByVal Level As Integer)
        If Not IsNothing(m_oSelectedCrutchTab) Then
            m_oSelectedCrutchTab.UpdateImageInternal(WoundType, BodyPart, Level)
        End If
    End Sub

    Private Sub TouchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ResetImages()
        SetParseTBPatient("touch")
    End Sub

    Delegate Sub ResetImagesDelegate()
    Public Sub ResetImages()
        If Me.InvokeRequired() = True Then
            Me.Invoke(New ResetImagesDelegate(AddressOf ResetImagesInternal))
        Else
            ResetImagesInternal()
        End If
    End Sub
    Private Sub ResetImagesInternal()
        If Not IsNothing(m_oSelectedCrutchTab) Then
            m_oSelectedCrutchTab.ResetImagesInternal()
        End If
    End Sub

    Private m_IsClosing As Boolean = False
    Public Property IsClosing() As Boolean
        Get
            Return m_IsClosing
        End Get
        Set(ByVal value As Boolean)
            m_IsClosing = value
        End Set
    End Property

    Private Sub Form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        If m_IsClosing = False Then
            Me.Hide()
            Crutch.m_Shown = False
            e.Cancel = True
        End If
    End Sub

    Dim m_oDialogTouchWho As New DialogTouchWho

    Private Sub ToolStripButtonTouch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonTouch.Click
        If m_Patient.Length > 0 Then
            SetParseTBPatient("touch")
        Else
            If m_TWButton = True Then
                m_oDialogTouchWho.TextBoxWho.Text = ""
                m_oDialogTouchWho.TextBoxWho.Focus()
                If m_oDialogTouchWho.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    m_Host.SendText("touch " & m_oDialogTouchWho.TextBoxWho.Text)
                End If
            ElseIf m_TWButton = False Then
                m_Host.SendText("#send -.25 Perceive health")
            End If
        End If
    End Sub

    Private Sub ToolStripButtonBreak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBreak.Click
        ResetImages()
        m_Host.SendText("#queue clear")
        m_Host.EchoText("#queue clear")

        If m_Patient.Length > 0 And m_Patient IsNot "Self" Then
            SetParseTBPatient("break")
        End If
    End Sub

    Private Sub BodyFreshExternal_Clicked(ByVal Part As Body.Part)
        TouchPart(Crutch.WoundType.FreshExternal, Part)
    End Sub

    Private Sub BodyScarExternal_Clicked(ByVal Part As Body.Part)
        TouchPart(Crutch.WoundType.ScarExternal, Part)
    End Sub

    Private Sub BodyFreshInternal_Clicked(ByVal Part As Body.Part)
        TouchPart(Crutch.WoundType.FreshInternal, Part)
    End Sub

    Private Sub BodyScarInternal_Clicked(ByVal Part As Body.Part)
        TouchPart(Crutch.WoundType.ScarInternal, Part)
    End Sub

    Private Sub BodyMenuFreshExternal_BodyPartMenuClicked(ByVal Part As Body.Part, ByVal Method As String)
        TouchPart(Crutch.WoundType.FreshExternal, Part, "", " " & Method)
    End Sub

    Private Sub BodyScarExternal_BodyPartMenuClicked(ByVal Part As Body.Part, ByVal Method As String)
        TouchPart(Crutch.WoundType.ScarExternal, Part, "", " " & Method)
    End Sub

    Private Sub BodyFreshInternal_BodyPartMenuClicked(ByVal Part As Body.Part, ByVal Method As String)
        TouchPart(Crutch.WoundType.FreshInternal, Part, "", " " & Method)
    End Sub

    Private Sub BodyScarInternal_BodyPartMenuClicked(ByVal Part As Body.Part, ByVal Method As String)
        TouchPart(Crutch.WoundType.ScarInternal, Part, "", " " & Method)
    End Sub

    Private Sub TouchPart(ByVal WoundType As Crutch.WoundType, ByVal BodyPart As Body.Part, Optional ByVal PreCommand As String = "", Optional ByVal PostCommand As String = "")
        Dim sTouchCommand As String = "take " & m_Patient & ""
        Dim sTouchBPCommand As String = " "
        Dim sTouchEICommand As String = " "
        Dim sTouchWSCommand As String = ""

        Select Case WoundType
            Case Crutch.WoundType.FreshInternal, Crutch.WoundType.ScarInternal
                sTouchEICommand &= "internal "
        End Select

        Select Case BodyPart
            Case Body.Part.Head
                sTouchBPCommand &= "head"
            Case Body.Part.LeftEye
                sTouchBPCommand &= "left eye"
            Case Body.Part.RightEye
                sTouchBPCommand &= "right eye"
            Case Body.Part.Neck
                sTouchBPCommand &= "neck"
            Case Body.Part.Chest
                sTouchBPCommand &= "chest"
            Case Body.Part.Abdomen
                sTouchBPCommand &= "abdomen"
            Case Body.Part.LeftArm
                sTouchBPCommand &= "left arm"
            Case Body.Part.LeftHand
                sTouchBPCommand &= "left hand"
            Case Body.Part.LeftLeg
                sTouchBPCommand &= "left leg"
            Case Body.Part.RightArm
                sTouchBPCommand &= "right arm"
            Case Body.Part.RightHand
                sTouchBPCommand &= "right hand"
            Case Body.Part.RightLeg
                sTouchBPCommand &= "right leg"
            Case Body.Part.Back
                sTouchBPCommand &= "back"
            Case Body.Part.Skin
                sTouchBPCommand &= "skin"
            Case Body.Part.Tail
                sTouchBPCommand &= "tail"
        End Select

        Select Case WoundType
            Case Crutch.WoundType.ScarExternal, Crutch.WoundType.ScarInternal
                sTouchWSCommand &= " scar"
        End Select
        If m_Patient IsNot "Self" Then
            sTouchCommand &= sTouchBPCommand & sTouchEICommand & sTouchWSCommand & ""
            m_Host.SendText("#send " & PreCommand & sTouchCommand & PostCommand)
        ElseIf m_Patient Is "Self" Then
            If sTouchWSCommand Is " scar" Then
                '                " & m_Host.SendText("GCSettingsManaHW") & "
                m_Host.SendText("#send " & PreCommand & "prep hs " & m_Host.Variable("GCTextBoxManaHS") & ";-" & m_Host.Variable("GCTextBoxDelayHS") & "cast " & sTouchBPCommand)
            Else
                m_Host.SendText("#send " & PreCommand & "prep hw " & m_Host.Variable("GCTextBoxManaHW") & ";-" & m_Host.Variable("GCTextBoxDelayHW") & "cast " & sTouchBPCommand)
            End If
        End If

    End Sub

    Private Sub TakeAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeAllToolStripMenuItem.Click
        TakeAll()
    End Sub

    Private Sub SetParseTBPatient(ByVal TBAction As String)
        If m_Patient IsNot "Self" And m_Patient IsNot "Advanced" Then
            m_Host.SendText(TBAction & " " & m_Patient)
        ElseIf m_Patient Is "Self" Then
            m_Host.SendText("-.5perceive self;-.1perceive health " & m_Patient)
        ElseIf m_Patient Is "Advanced" Then
            m_Host.SendText("-.5perceive self")
        End If
    End Sub

    Private Sub TakeAll()
        If IsNothing(m_oWoundList) Then Exit Sub
        If bLeaveBleeders = False And m_Patient IsNot "Self" Then
            SetParseTBPatient("touch")
            m_Host.SendText("take " & m_Patient & IIf(bQuickMode, " quick", "") & " all")
        ElseIf bLeaveBleeders = True Or bHalfOnMajor = True Or m_Patient Is "Self" Then
            m_oWoundList.Sort()
            Dim bSkip As Boolean = False
            For Each obj As Wound In m_oWoundList
                bSkip = False

                If m_Patient Is "Self" And (obj.WoundType = Crutch.WoundType.FreshInternal Or obj.WoundType = Crutch.WoundType.ScarInternal) Then
                    bSkip = True
                End If

                If bIncludeInternal = False And (obj.WoundType = Crutch.WoundType.FreshInternal Or obj.WoundType = Crutch.WoundType.ScarInternal) Then
                    bSkip = True
                End If

                If bIncludeScars = False And (obj.WoundType = Crutch.WoundType.ScarExternal Or obj.WoundType = Crutch.WoundType.ScarInternal) Then
                    bSkip = True
                End If

                If obj.Level > 5 And (obj.WoundType = Crutch.WoundType.FreshExternal Or obj.WoundType = Crutch.WoundType.FreshInternal) Then
                    bSkip = True
                End If

                If bSkip = False Then
                    TouchPart(obj.WoundType, obj.BodyPart, "0.25 ", IIf(bHalfOnMajor And obj.Level > 7, " half", "") & IIf(bQuickMode, " quick", ""))
                End If
            Next
            '   Assume we should take scars for all wounds...
            If bIncludeScars = True And m_Patient IsNot "Self" Then
                For Each obj As Wound In m_oWoundList
                    bSkip = False

                    If bIncludeInternal = False And (obj.WoundType = Crutch.WoundType.FreshInternal Or obj.WoundType = Crutch.WoundType.ScarInternal) Then
                        bSkip = True
                    End If

                    If bSkip = False Then
                        If obj.WoundType <> Crutch.WoundType.ScarExternal And obj.WoundType <> Crutch.WoundType.ScarInternal Then
                            Dim wt As Crutch.WoundType
                            If obj.WoundType = Crutch.WoundType.FreshExternal Then
                                wt = Crutch.WoundType.ScarExternal
                            ElseIf obj.WoundType = Crutch.WoundType.FreshInternal Then
                                wt = Crutch.WoundType.ScarInternal
                            End If

                            TouchPart(wt, obj.BodyPart, "0.25 ", IIf(bHalfOnMajor And obj.Level > 7, " half", "") & IIf(bQuickMode, " quick", ""))
                        End If
                    End If
                Next
            End If

            If m_Patient IsNot "Self" Then m_Host.SendText("#send 5 touch " & m_Patient)
        End If

    End Sub

    Private Sub TakeMinorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeMinorToolStripMenuItem.Click
        If IsNothing(m_oWoundList) Then Exit Sub

        If m_Patient IsNot "Self" Then SetParseTBPatient("touch")

        m_oWoundList.Sort()
        Dim bSkip As Boolean = False
        For Each obj As Wound In m_oWoundList
            bSkip = False
            If obj.Level < 5 Then
                If bIncludeInternal = False And (obj.WoundType = Crutch.WoundType.FreshInternal Or obj.WoundType = Crutch.WoundType.ScarInternal) Then
                    bSkip = True
                End If

                If bIncludeScars = False And (obj.WoundType = Crutch.WoundType.ScarExternal Or obj.WoundType = Crutch.WoundType.ScarInternal) Then
                    bSkip = True
                End If

                If bSkip = False Then
                    TouchPart(obj.WoundType, obj.BodyPart, "0.25 ", IIf(bQuickMode, " quick", ""))
                End If
            End If
        Next
    End Sub

    Dim bIncludeInternal As Boolean = True
    Dim bIncludeScars As Boolean = True
    Dim bQuickMode As Boolean = False
    Dim bHalfOnMajor As Boolean = False
    Dim bLeaveBleeders As Boolean = False
    Dim bAdvancedSettingForm As Boolean = False

    Private Sub QuickToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuickToolStripMenuItem.Click
        bQuickMode = QuickToolStripMenuItem.Checked
    End Sub

    Private Sub IncludingInternalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludingInternalToolStripMenuItem.Click
        bIncludeInternal = IncludingInternalToolStripMenuItem.Checked
    End Sub

    Private Sub IncludingScarsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludingScarsToolStripMenuItem.Click
        bIncludeScars = IncludingScarsToolStripMenuItem.Checked
    End Sub

    Private Sub HalfOnMajorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalfOnMajorToolStripMenuItem.Click
        bHalfOnMajor = HalfOnMajorToolStripMenuItem.Checked
    End Sub
    Private Sub LeaveBleedersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeaveBleedersToolStripMenuItem.Click
        bLeaveBleeders = LeaveBleedersToolStripMenuItem.Checked
    End Sub

    Private Sub AdvancedSettingForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancedSettingForm.Click
        bAdvancedSettingForm = AdvancedSettingForm.Checked
        AddTab("Advanced")

        Dim c As CrutchTab = FindCrutchTabByName("Advanced")
        If Not IsNothing(c) Then
        End If
    End Sub

    Private Sub HealthBar_Click()
        If m_Patient IsNot "Self" Then
            m_Host.SendText("#send -.5take " & m_Patient & " vitality")
        ElseIf m_Patient Is "Self" Then
            m_Host.SendText("#send -.5prep VH " & m_Host.Variable("GCTextBoxManaVH") & ";-" & m_Host.Variable("GCTextBoxDelayVH") & "cast ")
        End If
    End Sub

    Private Sub Poison_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If m_Patient IsNot "Self" Then
            m_Host.SendText("#send -.5take " & m_Patient & " poison")
        ElseIf m_Patient Is "Self" Then
            m_Host.SendText("#send -.5prep FP " & m_Host.Variable("GCTextBoxManaFP") & ";-" & m_Host.Variable("GCTextBoxDelayFP") & "cast ")
        End If
    End Sub

    Private Sub Disease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If m_Patient IsNot "Self" Then
            m_Host.SendText("#send -.5take " & m_Patient & " disease")
        ElseIf m_Patient Is "Self" Then
            m_Host.SendText("#send -.5prep CD " & m_Host.Variable("GCTextBoxManaCD") & ";-" & m_Host.Variable("GCTextBoxDelayCD") & "cast ")
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddTab("Testing")

        Dim c As CrutchTab = FindCrutchTabByName("Testing")
        If Not IsNothing(c) Then

        End If
    End Sub

    Private Sub AddTab(ByVal name As String)
        For Each t As TabPage In TabPatients.TabPages
            If t.Text = name Then
                TabPatients.SelectedTab = t
                SelectedTabChanged()
                Exit Sub
            End If
        Next
        If name Is "Advanced" Then
            Dim tab As New TabPage()
            Dim ct As New AdvancedSettingsTab()
            ct.CrutchForm = Me

            AddHandler ct.CloseTab, AddressOf CrutchTab_CloseTab
            AddHandler ct.TexboxRW_Changed, AddressOf AdvancedSettingsTab_TextBoxRW_TextChanged
            AddHandler ct.TexboxRW_Load, AddressOf LoadConfig
            AddHandler ct.TouchType, AddressOf CrutchTab_TouchType

            tab.Text = name
            tab.Controls.Add(ct)
            TabPatients.Controls.Add(tab)
            TabPatients.SelectedTab = tab
            SelectedTabChanged()
        Else
            Dim tab As New TabPage()
            Dim ct As New CrutchTab()
            ct.CrutchForm = Me

            AddHandler ct.CloseTab, AddressOf CrutchTab_CloseTab
            AddHandler ct.TouchPart, AddressOf CrutchTab_TouchPart
            AddHandler ct.TouchType, AddressOf CrutchTab_TouchType

            tab.Text = name
            tab.Controls.Add(ct)
            TabPatients.Controls.Add(tab)
            TabPatients.SelectedTab = tab
            SelectedTabChanged()
        End If

    End Sub

    Private Sub CrutchTab_TouchPart(ByVal WoundType As Crutch.WoundType, ByVal BodyPart As Body.Part, ByVal PreCommand As String, ByVal PostCommand As String)
        TouchPart(WoundType, BodyPart, PreCommand, PostCommand)
    End Sub

    Private Sub CrutchTab_TouchType(ByVal type As String)
        '        m_Host.SendText("#send take " & m_Patient & " " & type)
        If type Is "vitality" Then
            If m_Patient IsNot "Self" And m_Patient IsNot "Advanced" Then
                m_Host.SendText("#send take " & m_Patient & " vitality" & IIf(bQuickMode, " quick", ""))
            ElseIf m_Patient Is "Self" Or m_Patient Is "Advanced" Then
                m_Host.SendText("#send -.5prep VH " & m_Host.Variable("GCTextBoxManaVH") & ";-" & m_Host.Variable("GCTextBoxDelayVH") & "cast ")
            End If
        ElseIf type Is "poison" Then
            If m_Patient IsNot "Self" And m_Patient IsNot "Advanced" Then
                m_Host.SendText("#send take " & m_Patient & IIf(bQuickMode, " quick", "") & " poison")
            ElseIf m_Patient Is "Self" Or m_Patient Is "Advanced" Then
                m_Host.SendText("#send -.5prep FP " & m_Host.Variable("GCTextBoxManaFP") & ";-" & m_Host.Variable("GCTextBoxDelayFP") & "cast ")
            End If
        ElseIf type Is "disease" Then
            If m_Patient IsNot "Self" And m_Patient IsNot "Advanced" Then
                m_Host.SendText("#send take " & m_Patient & IIf(bQuickMode, " quick", "") & " disease")
            ElseIf m_Patient Is "Self" Or m_Patient Is "Advanced" Then
                m_Host.SendText("#send -.5prep CD " & m_Host.Variable("GCTextBoxManaCD") & ";-" & m_Host.Variable("GCTextBoxDelayCD") & "cast ")
            End If
        ElseIf type Is "REFR" And m_Patient Is "Advanced" Then
            m_Host.SendText("#send -.5prep refresh " & m_Host.Variable("GCTextBoxManaREFR") & ";-" & m_Host.Variable("GCTextBoxDelayREFR") & "cast ")
        ElseIf type Is "HEAL" And m_Patient Is "Advanced" Then
            m_Host.SendText("#send -.5prep heal " & m_Host.Variable("GCTextBoxManaHEAL") & ";-" & m_Host.Variable("GCTextBoxDelayHEAL") & "cast ")
        ElseIf type Is "REGE" And m_Patient Is "Advanced" Then
            m_Host.SendText("#send -.5prep regen " & m_Host.Variable("GCTextBoxManaREGE") & ";-" & m_Host.Variable("GCTextBoxDelayREGE") & "cast ")
        ElseIf type Is "BS" And m_Patient Is "Advanced" Then
            m_Host.SendText("#send -.5prep bs " & m_Host.Variable("GCTextBoxManaBS") & ";-" & m_Host.Variable("GCTextBoxDelayBS") & "cast ")
        End If
    End Sub

    Private Sub CrutchTab_CloseTab()
        TabPatients.Controls.Remove(TabPatients.SelectedTab)
    End Sub
    Private Sub AdvancedSettingsTab_TextBoxRW_TextChanged(ByVal section As String, ByVal child As String, ByVal value As String)
        If value IsNot "" Then
            m_Host.SendText("#var " & section & " " & value)
        End If
    End Sub
    Private Sub LoadConfig(ByRef settings, ByVal value)
        settings = m_Host.Variable(value)
    End Sub

    Private Function FindCrutchTabByName(ByVal name As String) As CrutchTab
        For Each t As TabPage In TabPatients.TabPages
            If t.Text = name Then
                For Each c As Control In t.Controls
                    If TypeOf c Is CrutchTab Then
                        Return c
                    End If
                Next
            End If
        Next

        Return Nothing
        End Function

    Private Function SelectedCrutchTab() As CrutchTab
        For Each c As Control In TabPatients.SelectedTab.Controls
            If TypeOf c Is CrutchTab Then
                Return c
            End If
        Next

        Return Nothing
    End Function

    Private Sub TabPatients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPatients.SelectedIndexChanged
            SelectedTabChanged()
        End Sub

    Private Sub SelectedTabChanged()
        If IsNothing(TabPatients.SelectedTab) Then
            m_Patient = String.Empty
            m_oWoundList = Nothing
            Exit Sub
        End If

        m_Patient = TabPatients.SelectedTab.Text

        Dim ct As CrutchTab = SelectedCrutchTab()
        m_oSelectedCrutchTab = ct
        If Not IsNothing(ct) Then
            m_oWoundList = ct.WoundList
        Else
            m_oWoundList = Nothing
        End If
    End Sub

    Private Sub ToolStripButtonTakeAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonTakeAll.Click
            TakeAll()
        End Sub

#Region "Contextmenu"
    Public Shared m_TabIndex As Integer = -1
    Public Shared cm_Patient As String = "none"

    Private Sub CrutchTabHeader_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabPatients.MouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then
            m_TabIndex = TabControlHitTest(TabPatients, e.Location)
            cm_Patient = TabPatients.TabPages(m_TabIndex).Text
            If m_TabIndex >= 0 And (cm_Patient IsNot "Self" And cm_Patient IsNot "Advanced") Then
                ContextMenuStrip1.Show(System.Windows.Forms.Control.MousePosition)
            End If
        End If

    End Sub
    Private Sub CrutchTabHeader_DoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabPatients.DoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            m_TabIndex = TabControlHitTest(TabPatients, e.Location)
            If m_TabIndex >= 0 Then
                ContextMenuStrip2.Show(System.Windows.Forms.Control.MousePosition)
            End If
        End If
    End Sub

    Private Function TabControlHitTest(ByVal TabCtrl As TabControl, ByVal pt As Point) As Integer

        For i As Integer = 0 To TabCtrl.TabPages.Count - 1
            If TabCtrl.GetTabRect(i).Contains(pt) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Sub ContextMenuL_clicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked

        Dim cm_Patient As String
        Dim cm_option As String = Mid(e.ClickedItem.Text, 5)
        cm_Patient = TabPatients.TabPages(m_TabIndex).Text
        If cm_Patient IsNot "Self" And cm_Patient IsNot "Advanced" Then
            If e.ClickedItem.Text IsNot "Shift" Then
                If cm_option = " Persistent" Then
                    m_Host.SendText("#send -.25Touch " & cm_Patient & ";-.25Link " & cm_Patient & cm_option)
                ElseIf cm_option = " Hodierna" Then
                    m_Host.SendText("#send -.25Touch " & cm_Patient & ";-.25Link " & cm_Patient & " Persistent" & ";-.25Link " & cm_Patient & cm_option)
                ElseIf cm_option = " Unity" Then
                    m_Host.SendText("#send -.25Touch " & cm_Patient & ";-.25Link " & cm_Patient & cm_option)
                ElseIf e.ClickedItem.Text = "Take All" Then
                    m_Host.SendText("#send -.25Touch " & cm_Patient & ";-.25Take " & cm_Patient & IIf(bQuickMode, " quick", "") & " all")
                ElseIf e.ClickedItem.Text = "Take Part" Then
                    m_Host.SendText("#send -.25Touch " & cm_Patient & ";-.25Take " & cm_Patient & " part" & IIf(bQuickMode, " quick", "") & " all")
                ElseIf e.ClickedItem.Text = "Take Half" Then
                    m_Host.SendText("#send -.25Touch " & cm_Patient & ";-.25Take " & cm_Patient & " half" & IIf(bQuickMode, " quick", "") & " all")
                ElseIf e.ClickedItem.Text = "Take Most" Then
                    m_Host.SendText("#send -.25Touch " & cm_Patient & ";-.25Take " & cm_Patient & " most" & IIf(bQuickMode, " quick", "") & " all")
                End If
            End If
        End If
    End Sub
    Private Sub ContextMenuClose_clicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStrip2.ItemClicked
        If e.ClickedItem.Text Is "Close Tab" Then
            TabPatients.TabPages.Remove(TabPatients.SelectedTab)
        ElseIf e.ClickedItem.Text Is "Close Other Tabs" Then
            For Each tab As TabPage In TabPatients.TabPages
                If tab IsNot TabPatients.SelectedTab Then
                    TabPatients.TabPages.Remove(tab)
                End If
            Next
        End If

    End Sub
    Private Sub ContextMenuS_clicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStripMenuItem4.DropDownItemClicked

        Dim cm_Patient As String
        Dim cm_option As String = e.ClickedItem.Text
        cm_Patient = TabPatients.TabPages(m_TabIndex).Text
        If cm_Patient IsNot "Self" And cm_Patient IsNot "Advanced" Then
            If e.ClickedItem.Text IsNot "Shift" Then
                m_Host.SendText("#send -.25Shift " & cm_Patient & cm_option)
            End If

        End If
    End Sub



#End Region

End Class
