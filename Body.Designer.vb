<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Body
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.LabelR = New System.Windows.Forms.Label
        Me.LabelL = New System.Windows.Forms.Label
        Me.Skin = New BodyPart
        Me.ContextMenuStripHeal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TakeSomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TakeHalfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TakeMostToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TakeAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LeftEye = New BodyPart
        Me.RightEye = New BodyPart
        Me.Tail = New BodyPart
        Me.LeftLeg = New BodyPart
        Me.RightLeg = New BodyPart
        Me.Abdomen = New BodyPart
        Me.Back = New BodyPart
        Me.LeftArm = New BodyPart
        Me.RightArm = New BodyPart
        Me.Chest = New BodyPart
        Me.Neck = New BodyPart
        Me.Head = New BodyPart
        Me.RightHand = New BodyPart
        Me.LeftHand = New BodyPart
        Me.ContextMenuStripHeal.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelR
        '
        Me.LabelR.AutoSize = True
        Me.LabelR.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelR.Location = New System.Drawing.Point(1, 28)
        Me.LabelR.Name = "LabelR"
        Me.LabelR.Size = New System.Drawing.Size(15, 13)
        Me.LabelR.TabIndex = 15
        Me.LabelR.Text = "R"
        '
        'LabelL
        '
        Me.LabelL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelL.AutoSize = True
        Me.LabelL.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.LabelL.Location = New System.Drawing.Point(44, 28)
        Me.LabelL.Name = "LabelL"
        Me.LabelL.Size = New System.Drawing.Size(13, 13)
        Me.LabelL.TabIndex = 16
        Me.LabelL.Text = "L"
        '
        'Skin
        '
        Me.Skin.BodyPart = Body.Part.Skin
        Me.Skin.BorderColor = System.Drawing.Color.White
        Me.Skin.Color = System.Drawing.Color.Black
        Me.Skin.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.Skin.Location = New System.Drawing.Point(47, 91)
        Me.Skin.Name = "Skin"
        Me.Skin.Shape = BodyPart.ShapeType.Round
        Me.Skin.Size = New System.Drawing.Size(15, 17)
        Me.Skin.TabIndex = 14
        Me.Skin.TabStop = False
        Me.Skin.Text = "S"
        '
        'ContextMenuStripHeal
        '
        Me.ContextMenuStripHeal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TakeSomeToolStripMenuItem, Me.TakeHalfToolStripMenuItem, Me.TakeMostToolStripMenuItem, Me.TakeAllToolStripMenuItem})
        Me.ContextMenuStripHeal.Name = "ContextMenuStripHeal"
        Me.ContextMenuStripHeal.Size = New System.Drawing.Size(153, 114)
        '
        'TakeSomeToolStripMenuItem
        '
        Me.TakeSomeToolStripMenuItem.Name = "TakeSomeToolStripMenuItem"
        Me.TakeSomeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TakeSomeToolStripMenuItem.Text = "Take Part"
        '
        'TakeHalfToolStripMenuItem
        '
        Me.TakeHalfToolStripMenuItem.Name = "TakeHalfToolStripMenuItem"
        Me.TakeHalfToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TakeHalfToolStripMenuItem.Text = "Take Half"
        '
        'TakeMostToolStripMenuItem
        '
        Me.TakeMostToolStripMenuItem.Name = "TakeMostToolStripMenuItem"
        Me.TakeMostToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TakeMostToolStripMenuItem.Text = "Take Most"
        '
        'TakeAllToolStripMenuItem
        '
        Me.TakeAllToolStripMenuItem.Name = "TakeAllToolStripMenuItem"
        Me.TakeAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TakeAllToolStripMenuItem.Text = "Take All"
        '
        'LeftEye
        '
        Me.LeftEye.BackColor = System.Drawing.Color.Black
        Me.LeftEye.BodyPart = Body.Part.LeftEye
        Me.LeftEye.BorderColor = System.Drawing.Color.White
        Me.LeftEye.Color = System.Drawing.Color.Black
        Me.LeftEye.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.LeftEye.Location = New System.Drawing.Point(30, 11)
        Me.LeftEye.Name = "LeftEye"
        Me.LeftEye.Shape = BodyPart.ShapeType.Round
        Me.LeftEye.Size = New System.Drawing.Size(12, 12)
        Me.LeftEye.TabIndex = 13
        Me.LeftEye.TabStop = False
        '
        'RightEye
        '
        Me.RightEye.BackColor = System.Drawing.Color.Black
        Me.RightEye.BodyPart = Body.Part.RightEye
        Me.RightEye.BorderColor = System.Drawing.Color.White
        Me.RightEye.Color = System.Drawing.Color.Black
        Me.RightEye.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.RightEye.Location = New System.Drawing.Point(16, 11)
        Me.RightEye.Name = "RightEye"
        Me.RightEye.Shape = BodyPart.ShapeType.Round
        Me.RightEye.Size = New System.Drawing.Size(12, 12)
        Me.RightEye.TabIndex = 12
        Me.RightEye.TabStop = False
        '
        'Tail
        '
        Me.Tail.BodyPart = Body.Part.Tail
        Me.Tail.BorderColor = System.Drawing.Color.White
        Me.Tail.Color = System.Drawing.Color.Black
        Me.Tail.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.Tail.Location = New System.Drawing.Point(6, 93)
        Me.Tail.Name = "Tail"
        Me.Tail.Shape = BodyPart.ShapeType.Square
        Me.Tail.Size = New System.Drawing.Size(8, 20)
        Me.Tail.TabIndex = 9
        Me.Tail.TabStop = False
        Me.Tail.Visible = False
        '
        'LeftLeg
        '
        Me.LeftLeg.BodyPart = Body.Part.LeftLeg
        Me.LeftLeg.BorderColor = System.Drawing.Color.White
        Me.LeftLeg.Color = System.Drawing.Color.Black
        Me.LeftLeg.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.LeftLeg.Location = New System.Drawing.Point(32, 95)
        Me.LeftLeg.Name = "LeftLeg"
        Me.LeftLeg.Shape = BodyPart.ShapeType.Square
        Me.LeftLeg.Size = New System.Drawing.Size(13, 37)
        Me.LeftLeg.TabIndex = 8
        Me.LeftLeg.TabStop = False
        '
        'RightLeg
        '
        Me.RightLeg.BodyPart = Body.Part.RightLeg
        Me.RightLeg.BorderColor = System.Drawing.Color.White
        Me.RightLeg.Color = System.Drawing.Color.Black
        Me.RightLeg.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.RightLeg.Location = New System.Drawing.Point(13, 95)
        Me.RightLeg.Name = "RightLeg"
        Me.RightLeg.Shape = BodyPart.ShapeType.Square
        Me.RightLeg.Size = New System.Drawing.Size(13, 37)
        Me.RightLeg.TabIndex = 7
        Me.RightLeg.TabStop = False
        '
        'Abdomen
        '
        Me.Abdomen.BodyPart = Body.Part.Abdomen
        Me.Abdomen.BorderColor = System.Drawing.Color.White
        Me.Abdomen.Color = System.Drawing.Color.Black
        Me.Abdomen.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.Abdomen.Location = New System.Drawing.Point(13, 80)
        Me.Abdomen.Name = "Abdomen"
        Me.Abdomen.Shape = BodyPart.ShapeType.Square
        Me.Abdomen.Size = New System.Drawing.Size(32, 16)
        Me.Abdomen.TabIndex = 6
        Me.Abdomen.TabStop = False
        '
        'Back
        '
        Me.Back.BodyPart = Body.Part.Back
        Me.Back.BorderColor = System.Drawing.Color.White
        Me.Back.Color = System.Drawing.Color.Black
        Me.Back.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.Back.Location = New System.Drawing.Point(13, 65)
        Me.Back.Name = "Back"
        Me.Back.Shape = BodyPart.ShapeType.Square
        Me.Back.Size = New System.Drawing.Size(32, 16)
        Me.Back.TabIndex = 5
        Me.Back.TabStop = False
        Me.Back.Text = "back"
        '
        'LeftArm
        '
        Me.LeftArm.BodyPart = Body.Part.LeftArm
        Me.LeftArm.BorderColor = System.Drawing.Color.White
        Me.LeftArm.Color = System.Drawing.Color.Black
        Me.LeftArm.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.LeftArm.Location = New System.Drawing.Point(44, 43)
        Me.LeftArm.Name = "LeftArm"
        Me.LeftArm.Shape = BodyPart.ShapeType.Square
        Me.LeftArm.Size = New System.Drawing.Size(12, 35)
        Me.LeftArm.TabIndex = 4
        Me.LeftArm.TabStop = False
        '
        'RightArm
        '
        Me.RightArm.BodyPart = Body.Part.RightArm
        Me.RightArm.BorderColor = System.Drawing.Color.White
        Me.RightArm.Color = System.Drawing.Color.Black
        Me.RightArm.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.RightArm.Location = New System.Drawing.Point(2, 43)
        Me.RightArm.Name = "RightArm"
        Me.RightArm.Shape = BodyPart.ShapeType.Square
        Me.RightArm.Size = New System.Drawing.Size(12, 35)
        Me.RightArm.TabIndex = 3
        Me.RightArm.TabStop = False
        '
        'Chest
        '
        Me.Chest.BodyPart = Body.Part.Chest
        Me.Chest.BorderColor = System.Drawing.Color.White
        Me.Chest.Color = System.Drawing.Color.Black
        Me.Chest.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.Chest.Location = New System.Drawing.Point(13, 43)
        Me.Chest.Name = "Chest"
        Me.Chest.Shape = BodyPart.ShapeType.Square
        Me.Chest.Size = New System.Drawing.Size(32, 23)
        Me.Chest.TabIndex = 2
        Me.Chest.TabStop = False
        '
        'Neck
        '
        Me.Neck.BodyPart = Body.Part.Neck
        Me.Neck.BorderColor = System.Drawing.Color.White
        Me.Neck.Color = System.Drawing.Color.Black
        Me.Neck.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.Neck.Location = New System.Drawing.Point(22, 35)
        Me.Neck.Name = "Neck"
        Me.Neck.Shape = BodyPart.ShapeType.Square
        Me.Neck.Size = New System.Drawing.Size(14, 9)
        Me.Neck.TabIndex = 1
        Me.Neck.TabStop = False
        '
        'Head
        '
        Me.Head.BodyPart = Body.Part.Head
        Me.Head.BorderColor = System.Drawing.Color.White
        Me.Head.Color = System.Drawing.Color.Black
        Me.Head.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.Head.Location = New System.Drawing.Point(12, 2)
        Me.Head.Name = "Head"
        Me.Head.Shape = BodyPart.ShapeType.Round
        Me.Head.Size = New System.Drawing.Size(34, 34)
        Me.Head.TabIndex = 0
        Me.Head.TabStop = False
        '
        'RightHand
        '
        Me.RightHand.BodyPart = Body.Part.RightHand
        Me.RightHand.BorderColor = System.Drawing.Color.White
        Me.RightHand.Color = System.Drawing.Color.Black
        Me.RightHand.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.RightHand.Location = New System.Drawing.Point(2, 77)
        Me.RightHand.Name = "RightHand"
        Me.RightHand.Shape = BodyPart.ShapeType.Round
        Me.RightHand.Size = New System.Drawing.Size(12, 12)
        Me.RightHand.TabIndex = 10
        Me.RightHand.TabStop = False
        '
        'LeftHand
        '
        Me.LeftHand.BodyPart = Body.Part.LeftHand
        Me.LeftHand.BorderColor = System.Drawing.Color.White
        Me.LeftHand.Color = System.Drawing.Color.Black
        Me.LeftHand.ContextMenuStrip = Me.ContextMenuStripHeal
        Me.LeftHand.Location = New System.Drawing.Point(44, 77)
        Me.LeftHand.Name = "LeftHand"
        Me.LeftHand.Shape = BodyPart.ShapeType.Round
        Me.LeftHand.Size = New System.Drawing.Size(12, 12)
        Me.LeftHand.TabIndex = 11
        Me.LeftHand.TabStop = False
        '
        'Body
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.Controls.Add(Me.LabelL)
        Me.Controls.Add(Me.LabelR)
        Me.Controls.Add(Me.Skin)
        Me.Controls.Add(Me.LeftEye)
        Me.Controls.Add(Me.RightEye)
        Me.Controls.Add(Me.Tail)
        Me.Controls.Add(Me.LeftLeg)
        Me.Controls.Add(Me.RightLeg)
        Me.Controls.Add(Me.Abdomen)
        Me.Controls.Add(Me.Back)
        Me.Controls.Add(Me.LeftArm)
        Me.Controls.Add(Me.RightArm)
        Me.Controls.Add(Me.Chest)
        Me.Controls.Add(Me.Neck)
        Me.Controls.Add(Me.Head)
        Me.Controls.Add(Me.RightHand)
        Me.Controls.Add(Me.LeftHand)
        Me.MinimumSize = New System.Drawing.Size(63, 134)
        Me.Name = "Body"
        Me.Size = New System.Drawing.Size(63, 134)
        Me.ContextMenuStripHeal.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Head As BodyPart
    Friend WithEvents Neck As BodyPart
    Friend WithEvents Chest As BodyPart
    Friend WithEvents RightArm As BodyPart
    Friend WithEvents LeftArm As BodyPart
    Friend WithEvents Back As BodyPart
    Friend WithEvents Abdomen As BodyPart
    Friend WithEvents RightLeg As BodyPart
    Friend WithEvents LeftLeg As BodyPart
    Friend WithEvents Tail As BodyPart
    Friend WithEvents RightHand As BodyPart
    Friend WithEvents LeftHand As BodyPart
    Friend WithEvents RightEye As BodyPart
    Friend WithEvents LeftEye As BodyPart
    Friend WithEvents Skin As BodyPart
    Friend WithEvents LabelR As System.Windows.Forms.Label
    Friend WithEvents LabelL As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripHeal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TakeSomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TakeHalfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TakeMostToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TakeAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
