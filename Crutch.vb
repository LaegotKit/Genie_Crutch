Imports System.Xml
Imports System.Drawing

Public Class Crutch
    Implements GeniePlugin.Interfaces.IPlugin

    Private m_Host As GeniePlugin.Interfaces.IHost
    Private m_Form As CrutchForm
    Private m_Config As XMLConfig
    Public Shared m_SHButton As Boolean = True
    Public Shared m_TWButton As Boolean = True
    Public Shared m_Shown As Boolean = False

    Public ReadOnly Property Description() As String Implements GeniePlugin.Interfaces.IPlugin.Description
        Get
            Return "Updated Genie Crutch for new healing methods"
        End Get
    End Property

    Public ReadOnly Property Author() As String Implements GeniePlugin.Interfaces.IPlugin.Author
        Get
            Return "Conny. Jon for 2+"
        End Get
    End Property
 
    Public ReadOnly Property Name() As String Implements GeniePlugin.Interfaces.IPlugin.Name
        Get
            Return "Genie Crutch"
        End Get
    End Property

    Public ReadOnly Property Version() As String Implements GeniePlugin.Interfaces.IPlugin.Version
        Get
            Return "2.0"
        End Get
    End Property

    Public Sub Initialize(ByVal Host As GeniePlugin.Interfaces.IHost) Implements GeniePlugin.Interfaces.IPlugin.Initialize
        m_Host = Host

        m_Form = New CrutchForm(m_Host)
        m_Config = New XMLConfig(m_Host, Me)

        LoadConfig()

        If Not IsNothing(m_Host.ParentForm) Then
            m_Form.MdiParent = m_Host.ParentForm
        End If
    End Sub

    Public Sub LoadConfig()
        m_Config.SetPath()

        Dim section As XmlNode
        Try
            m_Config.OpenConfig()
            section = m_Config.GetSection("Position")
            If section IsNot Nothing Then
                m_Form.Top = Integer.Parse(m_Config.GetKeyValue(section, "Top", "10"))
                m_Form.Left = Integer.Parse(m_Config.GetKeyValue(section, "Left", "10"))
            Else
                section = m_Config.AddSection("Position")
                m_Config.SetKeyValue(section, "Top", m_Form.Top.ToString())
                m_Config.SetKeyValue(section, "Left", m_Form.Left.ToString())
            End If
        Catch ex As Exception
            m_Host.EchoText("Could not load config file " & ex.Message & vbNewLine)
        End Try
    End Sub

    Public Sub SaveConfig()
        Dim node As XmlNode

        Try
            node = m_Config.GetSection("Position")
            m_Config.SetKeyValue(node, "Top", m_Form.Top.ToString())
            m_Config.SetKeyValue(node, "Left", m_Form.Left.ToString())
            m_Config.SaveConfig()
        Catch ex As Exception
            m_Host.EchoText("Could not save config file " & ex.Message & vbLf)
        End Try
    End Sub
    Public Sub Show() Implements GeniePlugin.Interfaces.IPlugin.Show
        m_Form.ShowMe()
    End Sub

    Public Enum WoundType
        FreshExternal
        ScarExternal
        FreshInternal
        ScarInternal
    End Enum

    Private m_Patient As String = ""
    Private m_iPoisonCount As Integer = 0
    Private m_bIsParsing As Boolean = False
    Private m_oCurrentParsePart As Body.Part
    Private m_oCurentWoundType As WoundType
    Private m_iCurrentWoundLevel As Integer = 0

    Private Sub SetPatient(ByRef Text As String)
        m_Form.Patient = m_Patient.Trim
        m_iPoisonCount = 0
    End Sub

    Public Function ParseText(Text As String, Window As String) As String Implements GeniePlugin.Interfaces.IPlugin.ParseText
        
    'Public Function ParseText(ByVal Text As String) As String Implements GeniePlugin.Interfaces.IPlugin.ParseText
        If IsNothing(m_Form) Then Return Text ' Bail if no window

        Try
            If Not IsNothing(m_Host) And (Crutch.m_SHButton = True Or Crutch.m_Shown = True) Then
                m_iCurrentWoundLevel = 0
                If Text.StartsWith("You reluctantly touch ") Then
                    m_Patient = Text.Substring(22).Replace(".", "").Replace(", a faint expression of distaste on your face", "").Trim
                    SetPatient(m_Patient)
                ElseIf Text.StartsWith("You lightly touch ") Then
                    m_Patient = Text.Substring(18).Replace(".", "").Replace(", barely brushing her skin", "").Replace(", barely brushing his skin", "").Trim
                    SetPatient(m_Patient)
                ElseIf Text.StartsWith("You touch ") Then
                    m_Patient = Text.Substring(10).Replace(".", "").Trim
                    SetPatient(m_Patient)
                ElseIf Text.StartsWith("You lay your hand on ") Then
                    m_Patient = Text.Substring(21).Replace(".", "").Replace("'s arm", "").Trim
                    SetPatient(m_Patient)
                ElseIf Text.StartsWith("You rest your hand on ") Then
                    m_Patient = Text.Substring(22).Replace(".", "").Replace("'s arm with a soft smile", "").Trim
                    SetPatient(m_Patient)
                End If

                If Text.StartsWith("Your injuries include") Then
                    m_Patient = "Self"
                    SetPatient(m_Patient)
                    m_bIsParsing = True
                    m_Form.ResetImages()
                End If

                If Text.StartsWith(m_Patient & "'s injuries include") Then
                    m_bIsParsing = True
                    m_Form.ResetImages()
                End If

                If Text.StartsWith("You sense :") Or Text.StartsWith("You close your eyes, drawing all your thoughts inward") Then
                    If Crutch.m_TWButton = False Then
                        m_bIsParsing = True
                    End If
                End If

                If m_bIsParsing = True And Text.StartsWith("    The presence of ") Then
                    m_Patient = Text.Substring(20).Replace(".", "").Replace(", a fellow Empath", "").Trim
                    SetPatient(m_Patient)
                    m_Form.ResetImages()
                End If


                If m_bIsParsing = True Then
                    If Text.StartsWith(m_Patient & " has ") Or Text.StartsWith("You have ") Then
                        If Text.Trim.EndsWith("normal vitality.") Then
                            m_Form.SetVitality(100)
                        End If

                        m_bIsParsing = False
                    End If

                    If (Text.StartsWith(m_Patient & " is ") Or Text.StartsWith("You are ")) And Text.Trim.EndsWith("%).") Then
                        Dim iLength = Text.IndexOf("%") - Text.IndexOf("(")
                        Dim sVitality As String = Text.Substring(Text.IndexOf("(") + 1, iLength - 1)
                        m_Host.EchoText("Target Vitality Loss = " & sVitality)
                        m_Form.SetVitality(100 - Integer.Parse(sVitality))

                        m_bIsParsing = False
                    End If
                    If Text.StartsWith("Roundtime") Or Text.StartsWith("You sense (") Or Text.EndsWith("from your current position: ") Then
                        m_bIsParsing = False
                    End If

                    If Text.StartsWith("Wounds to the ") Then
                        SetParsePart(Text.Substring(14).Replace(":", "").Trim)
                    End If

                    If Text.StartsWith("  Fresh External:  ") Then
                        SetWoundLevel(Text.Substring(19).Trim)
                        m_Form.UpdateImage(WoundType.FreshExternal, m_oCurrentParsePart, m_iCurrentWoundLevel)
                    End If

                    If Text.StartsWith("  Scars External:  ") Then
                        SetWoundLevel(Text.Substring(19).Trim)
                        m_Form.UpdateImage(WoundType.ScarExternal, m_oCurrentParsePart, m_iCurrentWoundLevel)
                    End If

                    If Text.StartsWith("  Fresh Internal:  ") Then
                        SetWoundLevel(Text.Substring(19).Trim)
                        m_Form.UpdateImage(WoundType.FreshInternal, m_oCurrentParsePart, m_iCurrentWoundLevel)
                    End If

                    If Text.StartsWith("  Scars Internal:  ") Then
                        SetWoundLevel(Text.Substring(19).Trim)
                        m_Form.UpdateImage(WoundType.ScarInternal, m_oCurrentParsePart, m_iCurrentWoundLevel)
                    End If

                    If Text.Trim.EndsWith("poison") Or Text.Contains("poisoned") Then
                        m_iPoisonCount += 1
                        m_Form.SetPoison(m_iPoisonCount)
                    End If

                    If Text.Contains("infected") Or Text.Contains("open oozing sores") Or Text.Contains("dormant infection") Or Text.Contains("gangrene") Or Text.Contains("disease") Then
                        m_Form.SetDisease()
                    End If

                    If m_bIsParsing = False Then ' Show Form
                        m_Form.ShowMe()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return Text
    End Function

    Public Function ParseInput(ByVal Text As String) As String Implements GeniePlugin.Interfaces.IPlugin.ParseInput
        If Text.StartsWith(m_Host.Variable("CommandChar")) Then
            Dim I As Integer = Text.IndexOf(" ")
            Dim Command As String = Text.Substring(1).Trim
            If I > 0 Then
                Command = Command.Substring(0, I - 1).Trim
            End If

            Select Case Command
                Case "crutch"
                    m_Form.ShowMe()
            End Select
        End If

        Return Text
    End Function

    Private Sub SetParsePart(ByVal Text As String)
        Select Case Text
            Case "HEAD"
                m_oCurrentParsePart = Body.Part.Head
            Case "RIGHT EYE"
                m_oCurrentParsePart = Body.Part.RightEye
            Case "LEFT EYE"
                m_oCurrentParsePart = Body.Part.LeftEye
            Case "NECK"
                m_oCurrentParsePart = Body.Part.Neck
            Case "CHEST"
                m_oCurrentParsePart = Body.Part.Chest
            Case "ABDOMEN"
                m_oCurrentParsePart = Body.Part.Abdomen
            Case "RIGHT ARM"
                m_oCurrentParsePart = Body.Part.RightArm
            Case "LEFT ARM"
                m_oCurrentParsePart = Body.Part.LeftArm
            Case "RIGHT LEG"
                m_oCurrentParsePart = Body.Part.RightLeg
            Case "LEFT LEG"
                m_oCurrentParsePart = Body.Part.LeftLeg
            Case "RIGHT HAND"
                m_oCurrentParsePart = Body.Part.RightHand
            Case "LEFT HAND"
                m_oCurrentParsePart = Body.Part.LeftHand
            Case "BACK"
                m_oCurrentParsePart = Body.Part.Back
            Case "SKIN"
                m_oCurrentParsePart = Body.Part.Skin
            Case "TAIL"
                m_oCurrentParsePart = Body.Part.Tail
        End Select
    End Sub

    Private Sub SetWoundLevel(ByVal Text As String)
        If Text.EndsWith("insignificant") Then
            m_iCurrentWoundLevel = 1
        ElseIf Text.EndsWith("insignificant to negligible") Then
            m_iCurrentWoundLevel = 2
        ElseIf Text.EndsWith("negligible") Then
            m_iCurrentWoundLevel = 3
        ElseIf Text.EndsWith("more than minor") Then
            m_iCurrentWoundLevel = 5
        ElseIf Text.EndsWith("minor") Then
            m_iCurrentWoundLevel = 4
        ElseIf Text.EndsWith("very harmful") Then
            m_iCurrentWoundLevel = 7
        ElseIf Text.EndsWith("harmful") Then
            m_iCurrentWoundLevel = 6
        ElseIf Text.EndsWith("very damaging") Then
            m_iCurrentWoundLevel = 9
        ElseIf Text.EndsWith("damaging") Then
            m_iCurrentWoundLevel = 8
        ElseIf Text.EndsWith("very severe") Then
            m_iCurrentWoundLevel = 10
        ElseIf Text.EndsWith("severe") Then
            m_iCurrentWoundLevel = 10
        ElseIf Text.EndsWith("very devastating") Then
            m_iCurrentWoundLevel = 11
        ElseIf Text.EndsWith("devastating") Then
            m_iCurrentWoundLevel = 11
        ElseIf Text.EndsWith("useless") Then
            m_iCurrentWoundLevel = 11
        End If
    End Sub

    Public Sub ParseXML(ByVal XML As String) Implements GeniePlugin.Interfaces.IPlugin.ParseXML
    End Sub

    Public Sub VariableChanged(ByVal Variable As String) Implements GeniePlugin.Interfaces.IPlugin.VariableChanged
        Select Case Variable
            Case "prompt"
                If m_bIsParsing = True Then
                    m_bIsParsing = False
                End If
        End Select
    End Sub

    Private m_Enabled As Boolean = True
    Public Property Enabled() As Boolean Implements GeniePlugin.Interfaces.IPlugin.Enabled
        Get
            Return m_Enabled
        End Get
        Set(ByVal value As Boolean)
            m_Enabled = value
        End Set
    End Property

    Public Sub ParentClosing() Implements GeniePlugin.Interfaces.IPlugin.ParentClosing
        m_Form.IsClosing = True
        SaveConfig()
    End Sub

End Class
