<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompleteQ
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompleteQ))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FMark = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Hou = New System.Windows.Forms.NumericUpDown()
        Me.Min = New System.Windows.Forms.NumericUpDown()
        Me.Sec = New System.Windows.Forms.NumericUpDown()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.hou2 = New System.Windows.Forms.Label()
        Me.min2 = New System.Windows.Forms.Label()
        Me.sec2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.FMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Hou, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 255)
        Me.Label1.MaximumSize = New System.Drawing.Size(321, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "    "
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.Location = New System.Drawing.Point(502, 255)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(265, 27)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(392, 406)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 27)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "التالي >"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(705, 415)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(64, 20)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(632, 394)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 26)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Mark"
        Me.Label2.Visible = False
        '
        'FMark
        '
        Me.FMark.Location = New System.Drawing.Point(635, 416)
        Me.FMark.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.FMark.Name = "FMark"
        Me.FMark.Size = New System.Drawing.Size(64, 20)
        Me.FMark.TabIndex = 5
        Me.FMark.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 19)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "الوقت المتبقي :"
        '
        'Hou
        '
        Me.Hou.BackColor = System.Drawing.Color.SandyBrown
        Me.Hou.Enabled = False
        Me.Hou.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Hou.Location = New System.Drawing.Point(690, 350)
        Me.Hou.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.Hou.Name = "Hou"
        Me.Hou.Size = New System.Drawing.Size(69, 27)
        Me.Hou.TabIndex = 26
        Me.Hou.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Hou.Value = New Decimal(New Integer() {24, 0, 0, 0})
        Me.Hou.Visible = False
        '
        'Min
        '
        Me.Min.BackColor = System.Drawing.Color.SpringGreen
        Me.Min.Enabled = False
        Me.Min.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Min.Location = New System.Drawing.Point(594, 350)
        Me.Min.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Min.Name = "Min"
        Me.Min.Size = New System.Drawing.Size(69, 27)
        Me.Min.TabIndex = 27
        Me.Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Min.Value = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Min.Visible = False
        '
        'Sec
        '
        Me.Sec.BackColor = System.Drawing.Color.DodgerBlue
        Me.Sec.Enabled = False
        Me.Sec.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Sec.ForeColor = System.Drawing.Color.Gold
        Me.Sec.InterceptArrowKeys = False
        Me.Sec.Location = New System.Drawing.Point(502, 350)
        Me.Sec.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Sec.Name = "Sec"
        Me.Sec.Size = New System.Drawing.Size(69, 27)
        Me.Sec.TabIndex = 28
        Me.Sec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Sec.Value = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Sec.Visible = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(145, 40)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(257, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 25
        Me.ProgressBar.Value = 100
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Stencil", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(314, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 19)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Stencil", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(218, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 19)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = ":"
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 1000
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(302, 406)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 27)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "< السابق"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'hou2
        '
        Me.hou2.BackColor = System.Drawing.Color.Cyan
        Me.hou2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.hou2.Location = New System.Drawing.Point(327, 7)
        Me.hou2.Name = "hou2"
        Me.hou2.Size = New System.Drawing.Size(69, 27)
        Me.hou2.TabIndex = 30
        Me.hou2.Text = "24"
        Me.hou2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'min2
        '
        Me.min2.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.min2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.min2.Location = New System.Drawing.Point(241, 7)
        Me.min2.Name = "min2"
        Me.min2.Size = New System.Drawing.Size(69, 27)
        Me.min2.TabIndex = 31
        Me.min2.Text = "60"
        Me.min2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sec2
        '
        Me.sec2.BackColor = System.Drawing.Color.Lime
        Me.sec2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.sec2.Location = New System.Drawing.Point(145, 7)
        Me.sec2.Name = "sec2"
        Me.sec2.Size = New System.Drawing.Size(69, 27)
        Me.sec2.TabIndex = 32
        Me.sec2.Text = "60"
        Me.sec2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(408, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(359, 237)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'CompleteQ
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 445)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.hou2)
        Me.Controls.Add(Me.min2)
        Me.Controls.Add(Me.sec2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Hou)
        Me.Controls.Add(Me.Min)
        Me.Controls.Add(Me.Sec)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FMark)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CompleteQ"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "أكمل العبارات الأتية بما يناسبها :-"
        Me.TopMost = True
        CType(Me.FMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Hou, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FMark As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Hou As NumericUpDown
    Friend WithEvents Min As NumericUpDown
    Friend WithEvents Sec As NumericUpDown
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Timer As Timer
    Friend WithEvents Button2 As Button
    Friend WithEvents hou2 As Label
    Friend WithEvents min2 As Label
    Friend WithEvents sec2 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
