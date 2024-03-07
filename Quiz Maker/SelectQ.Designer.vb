<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelectQ
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectQ))
        Me.QLabel = New System.Windows.Forms.Label()
        Me.A1Label = New System.Windows.Forms.RadioButton()
        Me.A2Label = New System.Windows.Forms.RadioButton()
        Me.A3Label = New System.Windows.Forms.RadioButton()
        Me.A4Label = New System.Windows.Forms.RadioButton()
        Me.RALabel = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FMark = New System.Windows.Forms.NumericUpDown()
        Me.DL = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Sec = New System.Windows.Forms.NumericUpDown()
        Me.Min = New System.Windows.Forms.NumericUpDown()
        Me.Hou = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Picture = New System.Windows.Forms.PictureBox()
        CType(Me.FMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Hou, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QLabel
        '
        Me.QLabel.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.QLabel.Location = New System.Drawing.Point(12, 255)
        Me.QLabel.Name = "QLabel"
        Me.QLabel.Size = New System.Drawing.Size(731, 56)
        Me.QLabel.TabIndex = 6
        Me.QLabel.Text = "السؤال:"
        Me.QLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'A1Label
        '
        Me.A1Label.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.A1Label.Location = New System.Drawing.Point(12, 313)
        Me.A1Label.Name = "A1Label"
        Me.A1Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.A1Label.Size = New System.Drawing.Size(335, 39)
        Me.A1Label.TabIndex = 0
        Me.A1Label.Text = "إجابة 1:"
        '
        'A2Label
        '
        Me.A2Label.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.A2Label.Location = New System.Drawing.Point(368, 313)
        Me.A2Label.Name = "A2Label"
        Me.A2Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.A2Label.Size = New System.Drawing.Size(335, 39)
        Me.A2Label.TabIndex = 1
        Me.A2Label.Text = "إجابة 2:"
        '
        'A3Label
        '
        Me.A3Label.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.A3Label.Location = New System.Drawing.Point(12, 358)
        Me.A3Label.Name = "A3Label"
        Me.A3Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.A3Label.Size = New System.Drawing.Size(335, 39)
        Me.A3Label.TabIndex = 2
        Me.A3Label.Text = "إجابة 3:"
        '
        'A4Label
        '
        Me.A4Label.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.A4Label.Location = New System.Drawing.Point(368, 358)
        Me.A4Label.Name = "A4Label"
        Me.A4Label.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.A4Label.Size = New System.Drawing.Size(335, 39)
        Me.A4Label.TabIndex = 3
        Me.A4Label.Text = "إجابة 4:"
        '
        'RALabel
        '
        Me.RALabel.Location = New System.Drawing.Point(350, 12)
        Me.RALabel.Name = "RALabel"
        Me.RALabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RALabel.Size = New System.Drawing.Size(116, 28)
        Me.RALabel.TabIndex = 10
        Me.RALabel.Text = "الإجابة الصحيحة:"
        Me.RALabel.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(500, 35)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(70, 20)
        Me.TextBox1.TabIndex = 15
        Me.TextBox1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(380, 436)
        Me.Button2.Name = "Button2"
        Me.Button2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button2.Size = New System.Drawing.Size(82, 41)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "< التالي"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FMark
        '
        Me.FMark.Location = New System.Drawing.Point(524, 12)
        Me.FMark.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.FMark.Name = "FMark"
        Me.FMark.Size = New System.Drawing.Size(46, 20)
        Me.FMark.TabIndex = 17
        Me.FMark.Visible = False
        '
        'DL
        '
        Me.DL.Location = New System.Drawing.Point(472, 12)
        Me.DL.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.DL.Name = "DL"
        Me.DL.Size = New System.Drawing.Size(46, 20)
        Me.DL.TabIndex = 17
        Me.DL.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Stencil", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(236, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Stencil", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(332, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 19)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = ":"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(163, 90)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(257, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 20
        Me.ProgressBar.Value = 100
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 1000
        '
        'Sec
        '
        Me.Sec.BackColor = System.Drawing.Color.DodgerBlue
        Me.Sec.Enabled = False
        Me.Sec.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Sec.ForeColor = System.Drawing.Color.Gold
        Me.Sec.Location = New System.Drawing.Point(52, 5)
        Me.Sec.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Sec.Name = "Sec"
        Me.Sec.Size = New System.Drawing.Size(69, 27)
        Me.Sec.TabIndex = 8
        Me.Sec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Sec.Value = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Sec.Visible = False
        '
        'Min
        '
        Me.Min.BackColor = System.Drawing.Color.SpringGreen
        Me.Min.Enabled = False
        Me.Min.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Min.Location = New System.Drawing.Point(144, 5)
        Me.Min.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Min.Name = "Min"
        Me.Min.Size = New System.Drawing.Size(69, 27)
        Me.Min.TabIndex = 21
        Me.Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Min.Value = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Min.Visible = False
        '
        'Hou
        '
        Me.Hou.BackColor = System.Drawing.Color.SandyBrown
        Me.Hou.Enabled = False
        Me.Hou.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Hou.Location = New System.Drawing.Point(240, 5)
        Me.Hou.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.Hou.Name = "Hou"
        Me.Hou.Size = New System.Drawing.Size(69, 27)
        Me.Hou.TabIndex = 21
        Me.Hou.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Hou.Value = New Decimal(New Integer() {24, 0, 0, 0})
        Me.Hou.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(30, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(127, 19)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "الوقت المتبقي :"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(292, 436)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(82, 41)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "السابق >"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Lime
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(161, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 27)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "60"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(257, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 27)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "60"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Cyan
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(343, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 27)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "24"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Picture
        '
        Me.Picture.Location = New System.Drawing.Point(426, 5)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(317, 247)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture.TabIndex = 23
        Me.Picture.TabStop = False
        '
        'SelectQ
        '
        Me.AcceptButton = Me.Button2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 489)
        Me.ControlBox = False
        Me.Controls.Add(Me.Picture)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Hou)
        Me.Controls.Add(Me.Min)
        Me.Controls.Add(Me.Sec)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DL)
        Me.Controls.Add(Me.FMark)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.QLabel)
        Me.Controls.Add(Me.A1Label)
        Me.Controls.Add(Me.A2Label)
        Me.Controls.Add(Me.A3Label)
        Me.Controls.Add(Me.A4Label)
        Me.Controls.Add(Me.RALabel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SelectQ"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "إختر الإجابة الصحيحة مما يأتي :-"
        Me.TopMost = True
        CType(Me.FMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Hou, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents QLabel As System.Windows.Forms.Label
    Friend WithEvents A1Label As System.Windows.Forms.RadioButton
    Friend WithEvents A2Label As System.Windows.Forms.RadioButton
    Friend WithEvents A3Label As System.Windows.Forms.RadioButton
    Friend WithEvents A4Label As System.Windows.Forms.RadioButton
    Friend WithEvents RALabel As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents FMark As System.Windows.Forms.NumericUpDown
    Friend WithEvents DL As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Timer As Timer
    Friend WithEvents Sec As NumericUpDown
    Friend WithEvents Min As NumericUpDown
    Friend WithEvents Hou As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Picture As PictureBox
End Class
