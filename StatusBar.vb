Imports System.Drawing

Public Class StatusBar
    Public Event MyClick()

    Private m_CurrentValue As Integer = 0
    Private m_Text As String = String.Empty
    Private m_BackgroundColor As Color = System.Drawing.Color.Black
    Private m_ForegroundColor As Color = System.Drawing.Color.Gray
    Private m_BorderColor As Pen = Pens.Gray

    Private Sub PanelBar_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelBar.Paint
        If m_CurrentValue > 0 Then
            Dim myTextureBrush As SolidBrush = New SolidBrush(m_ForegroundColor)
            Dim w As Integer = Math.Round((Me.Width / 100) * m_CurrentValue)
            e.Graphics.FillRectangle(myTextureBrush, 0, 0, w, PanelBar.Height)
            DrawBorder(e.Graphics, m_BorderColor)
        End If
    End Sub

    Public Property BarText() As String
        Get
            Return m_Text
        End Get
        Set(ByVal value As String)
            m_Text = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BackgroundColor() As Color
        Get
            Return m_BackgroundColor
        End Get
        Set(ByVal value As Color)
            m_BackgroundColor = value
            PanelBar.BackColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ForegroundColor() As Color
        Get
            Return m_ForegroundColor
        End Get
        Set(ByVal value As Color)
            m_ForegroundColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderColor() As Color
        Get
            Return m_BorderColor.Color
        End Get
        Set(ByVal value As Color)
            m_BorderColor = New Pen(value)
            Me.Invalidate()
        End Set
    End Property

    Public Property Value() As Integer
        Get
            Return m_CurrentValue
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 0
            If value > 100 Then value = 100

            m_CurrentValue = value
            LabelValue.Text = m_Text & " " & m_CurrentValue.ToString & "%"
            Me.Invalidate()
        End Set
    End Property

    Private Sub DrawBorder(ByVal g As Graphics, ByRef p As Pen)
        g.DrawLine(p, New Point(Me.ClientRectangle.Left, Me.ClientRectangle.Top), New Point(Integer.Parse(Me.ClientRectangle.Width - p.Width), Me.ClientRectangle.Top))
        g.DrawLine(p, New Point(Me.ClientRectangle.Left, Me.ClientRectangle.Top), New Point(Me.ClientRectangle.Left, Integer.Parse(Me.ClientRectangle.Height - p.Width)))
        g.DrawLine(p, New Point(Me.ClientRectangle.Left, Integer.Parse(Me.ClientRectangle.Height - p.Width)), New Point(Integer.Parse(Me.ClientRectangle.Width - p.Width), Integer.Parse(Me.ClientRectangle.Height - p.Width)))
        g.DrawLine(p, New Point(Integer.Parse(Me.ClientRectangle.Width - p.Width), Me.ClientRectangle.Top), New Point(Integer.Parse(Me.ClientRectangle.Width - p.Width), Integer.Parse(Me.ClientRectangle.Height - p.Width)))
    End Sub

    Private Sub StatusBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, LabelValue.Click, PanelBar.Click
        RaiseEvent MyClick()
    End Sub

End Class
