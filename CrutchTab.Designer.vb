<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CrutchTab
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrutchTab))
        Me.PoisonCount = New System.Windows.Forms.Label()
        Me.LabelSI = New System.Windows.Forms.Label()
        Me.LabelFI = New System.Windows.Forms.Label()
        Me.LabelSE = New System.Windows.Forms.Label()
        Me.LabelFE = New System.Windows.Forms.Label()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.Vitality = New StatusBar()
        Me.Disease = New BodyPart()
        Me.Poison = New BodyPart()
        Me.BodyScarInternal = New Body()
        Me.BodyFreshInternal = New Body()
        Me.BodyScarExternal = New Body()
        Me.BodyFreshExternal = New Body()
        Me.SuspendLayout()
        '
        'PoisonCount
        '
        Me.PoisonCount.ForeColor = System.Drawing.Color.Red
        Me.PoisonCount.Location = New System.Drawing.Point(92, 29)
        Me.PoisonCount.Name = "PoisonCount"
        Me.PoisonCount.Size = New System.Drawing.Size(10, 13)
        Me.PoisonCount.TabIndex = 29
        Me.PoisonCount.Text = "0"
        Me.PoisonCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PoisonCount.Visible = False
        '
        'LabelSI
        '
        Me.LabelSI.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LabelSI.Location = New System.Drawing.Point(84, 308)
        Me.LabelSI.Name = "LabelSI"
        Me.LabelSI.Size = New System.Drawing.Size(82, 13)
        Me.LabelSI.TabIndex = 27
        Me.LabelSI.Text = "Scar Internal"
        Me.LabelSI.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelFI
        '
        Me.LabelFI.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LabelFI.Location = New System.Drawing.Point(2, 308)
        Me.LabelFI.Name = "LabelFI"
        Me.LabelFI.Size = New System.Drawing.Size(82, 13)
        Me.LabelFI.TabIndex = 26
        Me.LabelFI.Text = "Fresh Internal"
        Me.LabelFI.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelSE
        '
        Me.LabelSE.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LabelSE.Location = New System.Drawing.Point(84, 158)
        Me.LabelSE.Name = "LabelSE"
        Me.LabelSE.Size = New System.Drawing.Size(82, 13)
        Me.LabelSE.TabIndex = 25
        Me.LabelSE.Text = "Scar External"
        Me.LabelSE.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelFE
        '
        Me.LabelFE.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LabelFE.Location = New System.Drawing.Point(2, 158)
        Me.LabelFE.Name = "LabelFE"
        Me.LabelFE.Size = New System.Drawing.Size(82, 13)
        Me.LabelFE.TabIndex = 22
        Me.LabelFE.Text = "Fresh External"
        Me.LabelFE.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonClose
        '
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(144, 5)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(17, 17)
        Me.ButtonClose.TabIndex = 30
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'Vitality
        '
        Me.Vitality.BackColor = System.Drawing.Color.Black
        Me.Vitality.BackgroundColor = System.Drawing.Color.Black
        Me.Vitality.BarText = "Vitality"
        Me.Vitality.BorderColor = System.Drawing.Color.Gray
        Me.Vitality.ForegroundColor = System.Drawing.Color.Gray
        Me.Vitality.Location = New System.Drawing.Point(5, 5)
        Me.Vitality.Margin = New System.Windows.Forms.Padding(0)
        Me.Vitality.Name = "Vitality"
        Me.Vitality.Size = New System.Drawing.Size(135, 17)
        Me.Vitality.TabIndex = 28
        Me.Vitality.Value = 0
        '
        'Disease
        '
        Me.Disease.BodyPart = Body.Part.Head
        Me.Disease.BorderColor = System.Drawing.Color.White
        Me.Disease.Color = System.Drawing.Color.Black
        Me.Disease.Location = New System.Drawing.Point(75, 50)
        Me.Disease.Name = "Disease"
        Me.Disease.Shape = BodyPart.ShapeType.Square
        Me.Disease.Size = New System.Drawing.Size(16, 17)
        Me.Disease.TabIndex = 24
        Me.Disease.TabStop = False
        Me.Disease.Text = "D"
        '
        'Poison
        '
        Me.Poison.BodyPart = Body.Part.Head
        Me.Poison.BorderColor = System.Drawing.Color.White
        Me.Poison.Color = System.Drawing.Color.Black
        Me.Poison.Location = New System.Drawing.Point(75, 27)
        Me.Poison.Name = "Poison"
        Me.Poison.Shape = BodyPart.ShapeType.Square
        Me.Poison.Size = New System.Drawing.Size(16, 17)
        Me.Poison.TabIndex = 23
        Me.Poison.TabStop = False
        Me.Poison.Text = "P"
        '
        'BodyScarInternal
        '
        Me.BodyScarInternal.Location = New System.Drawing.Point(94, 175)
        Me.BodyScarInternal.MinimumSize = New System.Drawing.Size(63, 134)
        Me.BodyScarInternal.Name = "BodyScarInternal"
        Me.BodyScarInternal.Size = New System.Drawing.Size(63, 134)
        Me.BodyScarInternal.TabIndex = 21
        '
        'BodyFreshInternal
        '
        Me.BodyFreshInternal.Location = New System.Drawing.Point(11, 175)
        Me.BodyFreshInternal.MinimumSize = New System.Drawing.Size(63, 134)
        Me.BodyFreshInternal.Name = "BodyFreshInternal"
        Me.BodyFreshInternal.Size = New System.Drawing.Size(63, 134)
        Me.BodyFreshInternal.TabIndex = 20
        '
        'BodyScarExternal
        '
        Me.BodyScarExternal.Location = New System.Drawing.Point(94, 25)
        Me.BodyScarExternal.MinimumSize = New System.Drawing.Size(63, 134)
        Me.BodyScarExternal.Name = "BodyScarExternal"
        Me.BodyScarExternal.Size = New System.Drawing.Size(63, 134)
        Me.BodyScarExternal.TabIndex = 19
        '
        'BodyFreshExternal
        '
        Me.BodyFreshExternal.Location = New System.Drawing.Point(11, 25)
        Me.BodyFreshExternal.MinimumSize = New System.Drawing.Size(63, 134)
        Me.BodyFreshExternal.Name = "BodyFreshExternal"
        Me.BodyFreshExternal.Size = New System.Drawing.Size(63, 134)
        Me.BodyFreshExternal.TabIndex = 18
        '
        'CrutchTab
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.PoisonCount)
        Me.Controls.Add(Me.Vitality)
        Me.Controls.Add(Me.LabelSI)
        Me.Controls.Add(Me.LabelFI)
        Me.Controls.Add(Me.LabelSE)
        Me.Controls.Add(Me.Disease)
        Me.Controls.Add(Me.Poison)
        Me.Controls.Add(Me.LabelFE)
        Me.Controls.Add(Me.BodyScarInternal)
        Me.Controls.Add(Me.BodyFreshInternal)
        Me.Controls.Add(Me.BodyScarExternal)
        Me.Controls.Add(Me.BodyFreshExternal)
        Me.Name = "CrutchTab"
        Me.Size = New System.Drawing.Size(165, 322)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PoisonCount As System.Windows.Forms.Label
    Friend WithEvents Vitality As StatusBar
    Friend WithEvents LabelSI As System.Windows.Forms.Label
    Friend WithEvents LabelFI As System.Windows.Forms.Label
    Friend WithEvents LabelSE As System.Windows.Forms.Label
    Friend WithEvents Disease As BodyPart
    Friend WithEvents Poison As BodyPart
    Friend WithEvents LabelFE As System.Windows.Forms.Label
    Friend WithEvents BodyScarInternal As Body
    Friend WithEvents BodyFreshInternal As Body
    Friend WithEvents BodyScarExternal As Body
    Friend WithEvents BodyFreshExternal As Body
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
End Class
