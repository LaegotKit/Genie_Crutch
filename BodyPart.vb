Imports System.Drawing

Public Class BodyPart
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        If m_Shape = ShapeType.Square Then
            e.Graphics.FillRectangle(New SolidBrush(m_BgColor), 0, 0, Me.Width - 1, Me.Height - 1)
            e.Graphics.DrawRectangle(New Pen(m_BorderColor), 0, 0, Me.Width - 1, Me.Height - 1)
        Else
            e.Graphics.FillEllipse(New SolidBrush(m_BgColor), 0, 0, Me.Width - 1, Me.Height - 1)
            e.Graphics.DrawEllipse(New Pen(m_BorderColor, 1), 0, 0, Me.Width - 1, Me.Height - 1)
        End If

        If Me.Text.Length > 0 Then
            e.Graphics.DrawString(Me.Text, Me.Font, Brushes.White, 2, 2)
        End If
    End Sub

    Private m_TitleFont As Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte((0)))

    Private m_BgColor As Drawing.Color = Drawing.Color.Black
    Private m_BorderColor As Drawing.Color = Drawing.Color.White

    Public Enum ShapeType
        Square
        Round
    End Enum

    Private m_Shape As ShapeType = ShapeType.Square

    Public Property Shape() As ShapeType
        Get
            Return m_Shape
        End Get
        Set(ByVal value As ShapeType)
            m_Shape = value
        End Set
    End Property

    Public Property Color() As Drawing.Color
        Get
            Return m_BgColor
        End Get
        Set(ByVal value As Drawing.Color)
            m_BgColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderColor() As Drawing.Color
        Get
            Return m_BorderColor
        End Get
        Set(ByVal value As Drawing.Color)
            m_BorderColor = value
            Me.Invalidate()
        End Set
    End Property

    Private m_BodyPart As Body.Part
    Public Property BodyPart() As Body.Part
        Get
            Return m_BodyPart
        End Get
        Set(ByVal value As Body.Part)
            m_BodyPart = value
        End Set
    End Property

End Class
