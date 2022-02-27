Imports System.Windows.Forms

Public Class Body
    Public Event BodyPartClicked(ByVal Part As Part)
    Public Event BodyPartMenuClicked(ByVal Part As Part, ByVal Method As String)

    Public Enum Part
        Head
        LeftEye
        RightEye
        Neck
        Chest
        Abdomen
        LeftArm
        LeftHand
        LeftLeg
        RightArm
        RightHand
        RightLeg
        Back
        Skin
        Tail
    End Enum

    Public Sub ChangeColor(ByVal Part As Part, ByVal Color As System.Drawing.Color)
        Select Case Part
            Case Body.Part.Head
                Head.Color = Color
                RightEye.BackColor = Color
                LeftEye.BackColor = Color
            Case Body.Part.Neck
                Neck.Color = Color
            Case Body.Part.Chest
                Chest.Color = Color
            Case Body.Part.Abdomen
                Abdomen.Color = Color
            Case Body.Part.RightArm
                RightArm.Color = Color
            Case Body.Part.LeftArm
                LeftArm.Color = Color
            Case Body.Part.RightEye
                RightEye.Color = Color
            Case Body.Part.LeftEye
                LeftEye.Color = Color
            Case Body.Part.RightLeg
                RightLeg.Color = Color
            Case Body.Part.LeftLeg
                LeftLeg.Color = Color
            Case Body.Part.RightHand
                RightHand.Color = Color
            Case Body.Part.LeftHand
                LeftHand.Color = Color
            Case Body.Part.Back
                Back.Color = Color
            Case Body.Part.Skin
                Skin.Color = Color
            Case Body.Part.Tail
                Tail.Color = Color
                Tail.Visible = True
        End Select
    End Sub

    Private Sub Head_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Head.Click
        RaiseEvent BodyPartClicked(Part.Head)
    End Sub

    Private Sub LeftEye_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftEye.Click
        RaiseEvent BodyPartClicked(Part.LeftEye)
    End Sub

    Private Sub Neck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Neck.Click
        RaiseEvent BodyPartClicked(Part.Neck)
    End Sub

    Private Sub Chest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chest.Click
        RaiseEvent BodyPartClicked(Part.Chest)
    End Sub

    Private Sub RightArm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightArm.Click
        RaiseEvent BodyPartClicked(Part.RightArm)
    End Sub

    Private Sub LeftArm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftArm.Click
        RaiseEvent BodyPartClicked(Part.LeftArm)
    End Sub

    Private Sub RightEye_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightEye.Click
        RaiseEvent BodyPartClicked(Part.RightEye)
    End Sub

    Private Sub Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Back.Click
        RaiseEvent BodyPartClicked(Part.Back)
    End Sub

    Private Sub Abdomen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Abdomen.Click
        RaiseEvent BodyPartClicked(Part.Abdomen)
    End Sub

    Private Sub RightHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightHand.Click
        RaiseEvent BodyPartClicked(Part.RightHand)
    End Sub

    Private Sub LeftHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftHand.Click
        RaiseEvent BodyPartClicked(Part.LeftHand)
    End Sub

    Private Sub RightLeg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightLeg.Click
        RaiseEvent BodyPartClicked(Part.RightLeg)
    End Sub

    Private Sub LeftLeg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftLeg.Click
        RaiseEvent BodyPartClicked(Part.LeftLeg)
    End Sub

    Private Sub Tail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tail.Click
        RaiseEvent BodyPartClicked(Part.Tail)
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AddHandler Neck.MouseEnter, AddressOf Element_MouseEnter
        AddHandler Head.MouseEnter, AddressOf ElementHead_MouseEnter
        AddHandler LeftEye.MouseEnter, AddressOf Element_MouseEnter
        AddHandler RightEye.MouseEnter, AddressOf Element_MouseEnter
        AddHandler Chest.MouseEnter, AddressOf Element_MouseEnter
        AddHandler Abdomen.MouseEnter, AddressOf Element_MouseEnter
        AddHandler LeftArm.MouseEnter, AddressOf Element_MouseEnter
        AddHandler LeftHand.MouseEnter, AddressOf Element_MouseEnter
        AddHandler LeftLeg.MouseEnter, AddressOf Element_MouseEnter
        AddHandler RightArm.MouseEnter, AddressOf Element_MouseEnter
        AddHandler RightHand.MouseEnter, AddressOf Element_MouseEnter
        AddHandler RightLeg.MouseEnter, AddressOf Element_MouseEnter
        AddHandler Back.MouseEnter, AddressOf Element_MouseEnter
        AddHandler Tail.MouseEnter, AddressOf Element_MouseEnter
        AddHandler Skin.MouseEnter, AddressOf Element_MouseEnter

        AddHandler Neck.MouseLeave, AddressOf Element_MouseLeave
        AddHandler Head.MouseLeave, AddressOf ElementHead_MouseLeave
        AddHandler LeftEye.MouseLeave, AddressOf Element_MouseLeave
        AddHandler RightEye.MouseLeave, AddressOf Element_MouseLeave
        AddHandler Neck.MouseLeave, AddressOf Element_MouseLeave
        AddHandler Chest.MouseLeave, AddressOf Element_MouseLeave
        AddHandler Abdomen.MouseLeave, AddressOf Element_MouseLeave
        AddHandler LeftArm.MouseLeave, AddressOf Element_MouseLeave
        AddHandler LeftHand.MouseLeave, AddressOf Element_MouseLeave
        AddHandler LeftLeg.MouseLeave, AddressOf Element_MouseLeave
        AddHandler RightArm.MouseLeave, AddressOf Element_MouseLeave
        AddHandler RightHand.MouseLeave, AddressOf Element_MouseLeave
        AddHandler RightLeg.MouseLeave, AddressOf Element_MouseLeave
        AddHandler Back.MouseLeave, AddressOf Element_MouseLeave
        AddHandler Tail.MouseLeave, AddressOf Element_MouseLeave
        AddHandler Skin.MouseLeave, AddressOf Element_MouseLeave
    End Sub

    Private Sub Element_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.Tag = sender.Color
        sender.Color = Drawing.Color.Aquamarine
    End Sub

    Private Sub Element_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.Color = CType(sender.Tag, System.Drawing.Color)
    End Sub

    ' Special for Eyes
    Private Sub ElementHead_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.Tag = sender.Color
        sender.Color = Drawing.Color.Aquamarine

        RightEye.BackColor = sender.Color
        LeftEye.BackColor = sender.Color
    End Sub

    ' Special for Eyes
    Private Sub ElementHead_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.Color = CType(sender.Tag, System.Drawing.Color)

        RightEye.BackColor = sender.Color
        LeftEye.BackColor = sender.Color
    End Sub

    Private Sub Skin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Skin.Click
        RaiseEvent BodyPartClicked(Part.Skin)
    End Sub


    Private Sub MenuClick(ByRef sender As System.Object, ByRef Method As String)
        If TypeOf sender Is ToolStripMenuItem Then
            Dim tsm As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
            If TypeOf tsm.Owner Is ContextMenuStrip Then
                Dim ms As ContextMenuStrip = DirectCast(tsm.Owner, ContextMenuStrip)
                If TypeOf ms.SourceControl Is BodyPart Then
                    Dim bp As BodyPart = DirectCast(ms.SourceControl, BodyPart)

                    RaiseEvent BodyPartMenuClicked(bp.BodyPart, Method)
                End If
            End If
        End If
    End Sub

    Private Sub TakeSomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeSomeToolStripMenuItem.Click
        MenuClick(sender, "part")
    End Sub

    Private Sub TakeHalfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeHalfToolStripMenuItem.Click
        MenuClick(sender, "half")
    End Sub

    Private Sub TakeMostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeMostToolStripMenuItem.Click
        MenuClick(sender, "most")
    End Sub

    Private Sub TakeAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TakeAllToolStripMenuItem.Click
        MenuClick(sender, "")
    End Sub

End Class
