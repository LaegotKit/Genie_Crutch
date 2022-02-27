<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrutchForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrutchForm))
        Me.TabPatients = New System.Windows.Forms.TabControl()
        Me.MenuToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonTouch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonBreak = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonTakeDropDown = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TakeMinorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TakeAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuSeperator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.IncludingInternalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncludingScarsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuSeperator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HalfOnMajorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeaveBleedersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButtonTakeAll = New System.Windows.Forms.ToolStripButton()
        Me.AdvancedSettingForm = New System.Windows.Forms.ToolStripButton()
        Me.MenuToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPatients
        '
        Me.TabPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPatients.Location = New System.Drawing.Point(0, 25)
        Me.TabPatients.Name = "TabPatients"
        Me.TabPatients.SelectedIndex = 0
        Me.TabPatients.Size = New System.Drawing.Size(173, 348)
        Me.TabPatients.TabIndex = 1
        Me.TabPatients.Tag = ""
        '
        'MenuToolStrip1
        '
        Me.MenuToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MenuToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonTouch, Me.ToolStripButtonBreak, Me.ToolStripButtonTakeDropDown, Me.ToolStripButtonTakeAll, Me.AdvancedSettingForm})
        Me.MenuToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuToolStrip1.Name = "MenuToolStrip1"
        Me.MenuToolStrip1.Size = New System.Drawing.Size(173, 25)
        Me.MenuToolStrip1.TabIndex = 9
        Me.MenuToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonTouch
        '
        Me.ToolStripButtonTouch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonTouch.Image = CType(resources.GetObject("ToolStripButtonTouch.Image"), System.Drawing.Image)
        Me.ToolStripButtonTouch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonTouch.Name = "ToolStripButtonTouch"
        Me.ToolStripButtonTouch.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripButtonTouch.Text = "Touch"
        '
        'ToolStripButtonBreak
        '
        Me.ToolStripButtonBreak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonBreak.Image = CType(resources.GetObject("ToolStripButtonBreak.Image"), System.Drawing.Image)
        Me.ToolStripButtonBreak.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonBreak.Name = "ToolStripButtonBreak"
        Me.ToolStripButtonBreak.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripButtonBreak.Text = "Break"
        '
        'ToolStripButtonTakeDropDown
        '
        Me.ToolStripButtonTakeDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonTakeDropDown.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TakeMinorToolStripMenuItem, Me.TakeAllToolStripMenuItem, Me.ToolStripMenuSeperator1, Me.IncludingInternalToolStripMenuItem, Me.IncludingScarsToolStripMenuItem, Me.ToolStripMenuSeperator2, Me.QuickToolStripMenuItem, Me.HalfOnMajorToolStripMenuItem, Me.LeaveBleedersToolStripMenuItem})
        Me.ToolStripButtonTakeDropDown.Image = CType(resources.GetObject("ToolStripButtonTakeDropDown.Image"), System.Drawing.Image)
        Me.ToolStripButtonTakeDropDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonTakeDropDown.Name = "ToolStripButtonTakeDropDown"
        Me.ToolStripButtonTakeDropDown.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripButtonTakeDropDown.Text = "Take"
        '
        'TakeMinorToolStripMenuItem
        '
        Me.TakeMinorToolStripMenuItem.Name = "TakeMinorToolStripMenuItem"
        Me.TakeMinorToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TakeMinorToolStripMenuItem.Text = "Take Minor"
        '
        'TakeAllToolStripMenuItem
        '
        Me.TakeAllToolStripMenuItem.Name = "TakeAllToolStripMenuItem"
        Me.TakeAllToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.TakeAllToolStripMenuItem.Text = "Take All"
        '
        'ToolStripMenuSeperator1
        '
        Me.ToolStripMenuSeperator1.Name = "ToolStripMenuSeperator1"
        Me.ToolStripMenuSeperator1.Size = New System.Drawing.Size(177, 6)
        '
        'IncludingInternalToolStripMenuItem
        '
        Me.IncludingInternalToolStripMenuItem.Checked = True
        Me.IncludingInternalToolStripMenuItem.CheckOnClick = True
        Me.IncludingInternalToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IncludingInternalToolStripMenuItem.Name = "IncludingInternalToolStripMenuItem"
        Me.IncludingInternalToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.IncludingInternalToolStripMenuItem.Text = "Including Internal"
        '
        'IncludingScarsToolStripMenuItem
        '
        Me.IncludingScarsToolStripMenuItem.Checked = True
        Me.IncludingScarsToolStripMenuItem.CheckOnClick = True
        Me.IncludingScarsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IncludingScarsToolStripMenuItem.Name = "IncludingScarsToolStripMenuItem"
        Me.IncludingScarsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.IncludingScarsToolStripMenuItem.Text = "Including Scars"
        '
        'ToolStripMenuSeperator2
        '
        Me.ToolStripMenuSeperator2.Name = "ToolStripMenuSeperator2"
        Me.ToolStripMenuSeperator2.Size = New System.Drawing.Size(177, 6)
        '
        'QuickToolStripMenuItem
        '
        Me.QuickToolStripMenuItem.CheckOnClick = True
        Me.QuickToolStripMenuItem.Name = "QuickToolStripMenuItem"
        Me.QuickToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.QuickToolStripMenuItem.Text = "Quick"
        '
        'HalfOnMajorToolStripMenuItem
        '
        Me.HalfOnMajorToolStripMenuItem.CheckOnClick = True
        Me.HalfOnMajorToolStripMenuItem.Name = "HalfOnMajorToolStripMenuItem"
        Me.HalfOnMajorToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.HalfOnMajorToolStripMenuItem.Text = "Half On Major"
        '
        'LeaveBleedersToolStripMenuItem
        '
        Me.LeaveBleedersToolStripMenuItem.CheckOnClick = True
        Me.LeaveBleedersToolStripMenuItem.Name = "LeaveBleedersToolStripMenuItem"
        Me.LeaveBleedersToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LeaveBleedersToolStripMenuItem.Text = "Leave Bleeders"
        '
        'ToolStripButtonTakeAll
        '
        Me.ToolStripButtonTakeAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonTakeAll.Image = CType(resources.GetObject("ToolStripButtonTakeAll.Image"), System.Drawing.Image)
        Me.ToolStripButtonTakeAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonTakeAll.Name = "ToolStripButtonTakeAll"
        Me.ToolStripButtonTakeAll.Size = New System.Drawing.Size(25, 22)
        Me.ToolStripButtonTakeAll.Text = "All"
        Me.ToolStripButtonTakeAll.ToolTipText = "Take All"
        '
        'AdvancedSettingForm
        '
        Me.AdvancedSettingForm.Checked = True
        Me.AdvancedSettingForm.CheckOnClick = True
        Me.AdvancedSettingForm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AdvancedSettingForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AdvancedSettingForm.Image = CType(resources.GetObject("AdvancedSettingForm.Image"), System.Drawing.Image)
        Me.AdvancedSettingForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AdvancedSettingForm.Name = "AdvancedSettingForm"
        Me.AdvancedSettingForm.Size = New System.Drawing.Size(64, 19)
        Me.AdvancedSettingForm.Text = "Advanced"
        Me.AdvancedSettingForm.ToolTipText = "Advanced settings"
        '
        'CrutchForm
        '
        Me.ClientSize = New System.Drawing.Size(173, 373)
        Me.Controls.Add(Me.TabPatients)
        Me.Controls.Add(Me.MenuToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CrutchForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Genie Crutch"
        Me.MenuToolStrip1.ResumeLayout(False)
        Me.MenuToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabPatients As System.Windows.Forms.TabControl
    Friend WithEvents MenuToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonTakeDropDown As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripButtonTouch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonBreak As System.Windows.Forms.ToolStripButton
    Friend WithEvents TakeMinorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuSeperator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuickToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncludingInternalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncludingScarsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HalfOnMajorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuSeperator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TakeAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButtonTakeAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents LeaveBleedersToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvancedSettingForm As Windows.Forms.ToolStripButton
End Class
