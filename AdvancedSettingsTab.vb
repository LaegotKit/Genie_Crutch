Imports System.Drawing
Imports System.Windows.Forms

Public Class AdvancedSettingsTab

    Public AdvancedSettingsLoaded As Boolean

    Public Event CloseTab()
    Public Event TexboxRW_Changed(ByVal Node As String, ByVal TextBoxName As String, ByVal TextBoxText As String)
    Public Event TexboxRW_Load(ByRef Setting As String, ByVal Value As String)
    Public Event TouchType(ByVal type As String)

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



#Region "Events"
    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        RaiseEvent CloseTab()
    End Sub

    Private Sub SpellName_Enter(sender As Object, e As EventArgs) Handles LabelSpellVH.MouseEnter, LabelSpellREGE.MouseEnter, LabelSpellREFR.MouseEnter, LabelSpellHeal.MouseEnter, LabelSpellFP.MouseEnter, LabelSpellCD.MouseEnter, LabelSpellBS.MouseEnter
        Dim fle As Label = DirectCast(sender, Label)
        fle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        fle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
    End Sub

    Private Sub SpellName_Leave(sender As Object, e As EventArgs) Handles LabelSpellVH.MouseLeave, LabelSpellREGE.MouseLeave, LabelSpellREFR.MouseLeave, LabelSpellHeal.MouseLeave, LabelSpellFP.MouseLeave, LabelSpellCD.MouseLeave, LabelSpellBS.MouseLeave
        Dim fle As Label = DirectCast(sender, Label)
        fle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        fle.BackColor = System.Drawing.SystemColors.Control
    End Sub

#End Region
#Region "Textbox Text"
    Private Sub AdvancedSettingsTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTabConfig()
    End Sub
    Private Sub TextBoxRW_TextChanged(sender As Object, e As EventArgs) Handles TextBoxManaCD.TextChanged, TextBoxManaHW.TextChanged, TextBoxManaVH.TextChanged, TextBoxManaREGE.TextChanged, TextBoxManaREFR.TextChanged, TextBoxManaHS.TextChanged, TextBoxManaHEAL.TextChanged, TextBoxManaFP.TextChanged, TextBoxManaBS.TextChanged, TextBoxDelayVH.TextChanged, TextBoxDelayREGE.TextChanged, TextBoxDelayREFR.TextChanged, TextBoxDelayHW.TextChanged, TextBoxDelayHS.TextChanged, TextBoxDelayHEAL.TextChanged, TextBoxDelayFP.TextChanged, TextBoxDelayCD.TextChanged, TextBoxDelayBS.TextChanged
        If AdvancedSettingsLoaded = True Then
            Dim TextBoxName As String = Me.ActiveControl.Name
            Dim PropName As String = Mid(Me.ActiveControl.Name, 8)
            Dim TextBoxText As String = Me.ActiveControl.Text
            Dim TextBox As String = PropName & "#var " & TextBoxName & " " & TextBoxText
            Dim Node As String = "GC" & TextBoxName
            RaiseEvent TexboxRW_Changed(Node, TextBoxName, TextBoxText)
        End If
    End Sub

    Public Sub LoadTabConfig()
        AdvancedSettingsLoaded = False
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayBS.Text, "GCTextBoxDelayBS")
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayCD.Text, "GCTextBoxDelayCD")
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayFP.Text, "GCTextBoxDelayFP")
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayHEAL.Text, "GCTextBoxDelayHEAL")
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayHS.Text, "GCTextBoxDelayHS")
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayHW.Text, "GCTextBoxDelayHW")
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayREFR.Text, "GCTextBoxDelayREFR")
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayREGE.Text, "GCTextBoxDelayREGE")
        RaiseEvent TexboxRW_Load(Me.TextBoxDelayVH.Text, "GCTextBoxDelayVH")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaBS.Text, "GCTextBoxManaBS")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaCD.Text, "GCTextBoxManaCD")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaFP.Text, "GCTextBoxManaFP")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaHEAL.Text, "GCTextBoxManaHEAL")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaHS.Text, "GCTextBoxManaHS")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaHW.Text, "GCTextBoxManaHW")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaREFR.Text, "GCTextBoxManaREFR")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaREGE.Text, "GCTextBoxManaREGE")
        RaiseEvent TexboxRW_Load(Me.TextBoxManaVH.Text, "GCTextBoxManaVH")

        LoadTimers()

        AdvancedSettingsLoaded = True
    End Sub

    Sub LoadTimers()
        ModifyTextBoxTimer(Me.TextBoxTimerBS, "SpellTimer.BloodStaunching.duration")
        ModifyTextBoxTimer(Me.TextBoxTimerCD, "SpellTimer.CureDisease.duration")
        ModifyTextBoxTimer(Me.TextBoxTimerFP, "SpellTimer.FlushPoisons.duration")
        ModifyTextBoxTimer(Me.TextBoxTimerHEAL, "SpellTimer.Heal.duration")
        ModifyTextBoxTimer(Me.TextBoxTimerREFR, "SpellTimer.Refresh.duration")
        ModifyTextBoxTimer(Me.TextBoxTimerREGE, "SpellTimer.Regenerate.duration")
    End Sub

    Sub ModifyTextBoxTimer(setting As TextBox, value As String)
        setting.ReadOnly = False
        RaiseEvent TexboxRW_Load(setting.Text, value)
        setting.ReadOnly = True
    End Sub

#End Region
#Region "Spell Casting"
    Private Sub LabelSpellFP_clicked(sender As Object, e As MouseEventArgs) Handles LabelSpellFP.MouseClick
        RaiseEvent TouchType("poison")
    End Sub
    Private Sub LabelSpellCD_clicked(sender As Object, e As MouseEventArgs) Handles LabelSpellCD.MouseClick
        RaiseEvent TouchType("disease")
    End Sub
    Private Sub LabelSpellVH_clicked(sender As Object, e As MouseEventArgs) Handles LabelSpellVH.MouseClick
        RaiseEvent TouchType("vitality")
    End Sub

    Private Sub LabelSpellREFR_clicked(sender As Object, e As MouseEventArgs) Handles LabelSpellREFR.MouseClick
        RaiseEvent TouchType("REFR")
    End Sub

    Private Sub LabelSpellHEAL_Clicked(sender As Object, e As MouseEventArgs) Handles LabelSpellHeal.MouseClick
        RaiseEvent TouchType("HEAL")
    End Sub

    Private Sub LabelSpellREGE_clicked(sender As Object, e As MouseEventArgs) Handles LabelSpellREGE.MouseClick
        RaiseEvent TouchType("REGE")
    End Sub

    Private Sub LabelSpellBS_clicked(sender As Object, e As MouseEventArgs) Handles LabelSpellBS.MouseClick
        RaiseEvent TouchType("BS")
    End Sub
#End Region

End Class
