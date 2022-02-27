<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StatusBar
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Me.PanelBar = New System.Windows.Forms.Panel
        Me.LabelValue = New System.Windows.Forms.Label
        Me.TimerRT = New System.Windows.Forms.Timer(Me.components)
        Me.PanelBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelBar
        '
        Me.PanelBar.Controls.Add(Me.LabelValue)
        Me.PanelBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBar.Location = New System.Drawing.Point(0, 0)
        Me.PanelBar.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelBar.Name = "PanelBar"
        Me.PanelBar.Size = New System.Drawing.Size(162, 20)
        Me.PanelBar.TabIndex = 0
        '
        'LabelValue
        '
        Me.LabelValue.BackColor = System.Drawing.Color.Transparent
        Me.LabelValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelValue.ForeColor = System.Drawing.Color.White
        Me.LabelValue.Location = New System.Drawing.Point(0, 0)
        Me.LabelValue.Name = "LabelValue"
        Me.LabelValue.Size = New System.Drawing.Size(162, 20)
        Me.LabelValue.TabIndex = 0
        Me.LabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerRT
        '
        Me.TimerRT.Interval = 1000
        '
        'StatusBar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.PanelBar)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "StatusBar"
        Me.Size = New System.Drawing.Size(162, 20)
        Me.PanelBar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBar As System.Windows.Forms.Panel
    Friend WithEvents LabelValue As System.Windows.Forms.Label
    Friend WithEvents TimerRT As System.Windows.Forms.Timer

End Class
