Public Class JoinQ
    Private ConnStr As New ADODB.Recordset()
    Private Conn As New ADODB.Connection()
    Private ConnStr2 As New ADODB.Recordset
    Private Conn2 As New ADODB.Connection
    Dim LLX As Integer = 0
    Dim LLY As Integer = 0
    Dim LRX As Integer = 0
    Dim LRY As Integer = 0
    Dim LN, RN As String
    Dim B As Boolean
    Dim Lin As Graphics = CreateGraphics()
    Dim Gsaver As Bitmap
    Private Sub JoinQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Databasesselecter.TextBox3.Text
        Try
            If Databasesselecter.JoinPC.Checked Then
                Conn.Open("Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & TextBox1.Text & ";Jet OLEDB:Database Password = " & Databasesselecter.JoinP.Text)
                ConnStr.Open(Databasesselecter.JoinT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            Else
                Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & TextBox1.Text)
                ConnStr.Open(Databasesselecter.JoinT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            End If
        Catch ex As Exception
            MsgBox("(Join)حدث خطأ أثناء محاولة تحميل قاعدة البيانات أو كلمة سر خاطئة", 0 Or 48 Or MsgBoxStyle.MsgBoxRight)
            Debug.WriteLine(ex.Message & " " & ex.StackTrace)
            er = True
            Main.Show()
            Close()
            Exit Sub
        End Try
        If Databasesselecter.Timer.Checked = True And Databasesselecter.CompleteC.Checked = True Then
            Sec.Value = CompleteQ.Sec.Value.ToString
            Min.Value = CompleteQ.Min.Value.ToString
            Hou.Value = CompleteQ.Hou.Value.ToString
            sec2.Text = Sec.Value
            min2.Text = Min.Value
            hou2.Text = Hou.Value
        ElseIf Databasesselecter.Timer.Checked = True And Databasesselecter.CompleteC.Checked = False And Databasesselecter.SelectC.Checked = True Then
            Sec.Value = SelectQ.Sec.Value.ToString
            Min.Value = SelectQ.Min.Value.ToString
            Hou.Value = SelectQ.Hou.Value.ToString
            sec2.Text = Sec.Value
            min2.Text = Min.Value
            hou2.Text = Hou.Value
        ElseIf Databasesselecter.Timer.Checked = True And Databasesselecter.SelectC.Checked = False And Databasesselecter.CompleteC.Checked = False Then
            Sec.Value = Databasesselecter.Sec.Value.ToString
            Min.Value = Databasesselecter.Min.Value.ToString
            Hou.Value = Databasesselecter.Hou.Value.ToString
            sec2.Text = Sec.Value
            min2.Text = Min.Value
            hou2.Text = Hou.Value
        ElseIf Databasesselecter.Timer.Checked = False Then
            Timer.Enabled = False
        End If
        If ConnStr.Fields("Q").Value.ToString.Contains(",") Then
            Dim Q() As String = ConnStr.Fields("Q").Value.ToString.Split(",")
            B1.Text = Q(0).ToString()
            Try
                B1.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                PictureBox1.ImageLocation = Q(3).ToString
                PictureBox1.Refresh()
                B1.BackgroundImage = PictureBox1.Image
            Catch ex As IndexOutOfRangeException
            End Try
        Else
            PictureBox1.ImageLocation = ""
            B1.Text = ConnStr.Fields("Q").Value.ToString
        End If
        If ConnStr.Fields("A").Value.ToString.Contains(",") Then
            Dim Q() As String = ConnStr.Fields("A").Value.ToString.Split(",")
            B8.Text = Q(0).ToString()
            Try
                B8.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                PictureBox1.ImageLocation = Q(3)
                B8.BackgroundImage = PictureBox1.Image
            Catch ex As IndexOutOfRangeException
            End Try
        Else
            PictureBox1.ImageLocation = ""
            B8.Text = ConnStr.Fields("A").Value.ToString
        End If
        Try
            ConnStr.MoveNext()
            If ConnStr.Fields("Q").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Q").Value.ToString.Split(",")
                B2.Text = Q(0).ToString()
                Try
                    B2.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B2.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B2.Text = ConnStr.Fields("Q").Value.ToString
            End If
            If ConnStr.Fields("A").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("A").Value.ToString.Split(",")
                B9.Text = Q(0).ToString()
                Try
                    B9.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B9.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B9.Text = ConnStr.Fields("A").Value.ToString
            End If
        Catch
            B2.Hide()
            B9.Hide()
        End Try
        Try
            ConnStr.MoveNext()
            If ConnStr.Fields("Q").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Q").Value.ToString.Split(",")
                B3.Text = Q(0).ToString()
                Try
                    B3.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B3.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B3.Text = ConnStr.Fields("Q").Value.ToString
            End If
            If ConnStr.Fields("A").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("A").Value.ToString.Split(",")
                B10.Text = Q(0).ToString()
                Try
                    B10.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B10.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B10.Text = ConnStr.Fields("A").Value.ToString
            End If
        Catch
            B3.Hide()
            B10.Hide()
        End Try
        Try
            ConnStr.MoveNext()
            If ConnStr.Fields("Q").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Q").Value.ToString.Split(",")
                B4.Text = Q(0).ToString()
                Try
                    B4.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B4.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B4.Text = ConnStr.Fields("Q").Value.ToString
            End If
            If ConnStr.Fields("A").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("A").Value.ToString.Split(",")
                B11.Text = Q(0).ToString()
                Try
                    B11.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B11.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B11.Text = ConnStr.Fields("A").Value.ToString
            End If
        Catch
            B4.Hide()
            B11.Hide()
        End Try
        Try
            ConnStr.MoveNext()
            If ConnStr.Fields("Q").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Q").Value.ToString.Split(",")
                B5.Text = Q(0).ToString()
                Try
                    B5.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B5.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B5.Text = ConnStr.Fields("Q").Value.ToString
            End If
            If ConnStr.Fields("A").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("A").Value.ToString.Split(",")
                B12.Text = Q(0).ToString()
                Try
                    B12.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B12.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B12.Text = ConnStr.Fields("A").Value.ToString
            End If
        Catch
            B5.Hide()
            B12.Hide()
        End Try
        Try
            ConnStr.MoveNext()
            If ConnStr.Fields("Q").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Q").Value.ToString.Split(",")
                B6.Text = Q(0).ToString()
                Try
                    B6.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B6.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B6.Text = ConnStr.Fields("Q").Value.ToString
            End If
            If ConnStr.Fields("A").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("A").Value.ToString.Split(",")
                B13.Text = Q(0).ToString()
                Try
                    B13.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B13.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B13.Text = ConnStr.Fields("A").Value.ToString
            End If
        Catch
            B6.Hide()
            B13.Hide()
        End Try
        Try
            ConnStr.MoveNext()
            If ConnStr.Fields("Q").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Q").Value.ToString.Split(",")
                B7.Text = Q(0).ToString()
                Try
                    B7.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B7.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B7.Text = ConnStr.Fields("Q").Value.ToString
            End If
            If ConnStr.Fields("A").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("A").Value.ToString.Split(",")
                B14.Text = Q(0).ToString()
                Try
                    B14.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                    B14.BackgroundImage = PictureBox1.Image
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                B14.Text = ConnStr.Fields("A").Value.ToString
            End If
        Catch
            B7.Hide()
            B14.Hide()
        End Try
        If B2.Text = "Total" Then
            B2.Hide()
            B9.Hide()
        ElseIf B3.Text = "Total" Then
            B3.Hide()
            B10.Hide()
        ElseIf B4.Text = "Total" Then
            B4.Hide()
            B11.Hide()
        ElseIf B5.Text = "Total" Then
            B5.Hide()
            B12.Hide()
        ElseIf B6.Text = "Total" Then
            B6.Hide()
            B13.Hide()
        ElseIf B7.Text = "Total" Then
            B7.Hide()
            B14.Hide()
        End If
        ConnStr.MoveFirst()
        If calcd Then
            Do While Not (ConnStr.EOF)
                If Not (ConnStr.Fields("Q").Value.ToString = "Total") Then
                    Final_update(ConnStr.Fields("Degree").Value)
                End If
                ConnStr.MoveNext()
            Loop
        End If
        ConnStr.MoveFirst()
        Gsaver = New Bitmap(Me.ClientRectangle.Width, Me.ClientRectangle.Height, Drawing.Imaging.PixelFormat.Format24bppRgb)
        Lin = Graphics.FromImage(Gsaver)
        Lin.Clear(System.Drawing.SystemColors.Control)
    End Sub
    Dim counter As Integer = 0
    Dim er As Boolean = False
    Private Sub SelectQ_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Not er Then
            If Me.Visible = True And Databasesselecter.Timer.Checked = True Then
                Timer.Enabled = True
                ProgressBar.Maximum = ((Databasesselecter.Hou.Value * 60) * 60) + (Databasesselecter.Min.Value * 60) + Databasesselecter.Sec.Value
                ProgressBar.Value = ((Databasesselecter.Hou.Value * 60) * 60) + (Databasesselecter.Min.Value * 60) + Databasesselecter.Sec.Value
                If Conn2.State = 0 Then
                    If Databasesselecter.ASSC.Checked = True Then
                        Conn2.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & Databasesselecter.ASST.Text & "\" & Databasesselecter.Nam2.Text & ".mdb")
                    Else
                        Conn2.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\" & Databasesselecter.Nam2.Text & ".mdb")
                    End If
                    ConnStr2.Open("ASS", Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    ConnStr2.AddNew()
                    ConnStr2.Fields("Q").Value = "Join:"
                    ConnStr.Update()
                End If
            ElseIf Visible = True Then
                If Conn2.State = 0 Then
                    If Databasesselecter.ASSC.Checked = True Then
                        Conn2.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & Databasesselecter.ASST.Text & "\" & Databasesselecter.Nam2.Text & ".mdb")
                    Else
                        Conn2.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\" & Databasesselecter.Nam2.Text & ".mdb")
                    End If
                    ConnStr2.Open("ASS", Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    ConnStr2.AddNew()
                    ConnStr2.Fields("Q").Value = "Join:"
                    ConnStr.Update()
                End If
            End If
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If Databasesselecter.Timer.Checked = True And Me.Visible = True Then
            If Sec.Value = 0 Then
                Sec.Value = 60
                sec2.Text = Sec.Value
                If Min.Value = 0 Then
                    Min.Value = 59
                    min2.Text = Min.Value
                    If (Not Hou.Value = 0) Then
                        Hou.Value -= 1
                        hou2.Text = Hou.Value
                    Else
                        MsgBox("إنتهي الوقت!", MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.Exclamation)
                        Hou.Value = 0
                        Min.Value = 0
                        Sec.Value = 0
                        sec2.Text = min2.Text = hou2.Text = 0
                        ProgressBar.Value = 0
                        Timer.Enabled = False
                        Degree_Update(FMark.Value, 3, 0, "00:00:00")
                        Close()
                        Exit Sub
                    End If
                Else
                    Min.Value -= 1
                    min2.Text = Min.Value
                End If
            End If
            Sec.Value -= 1
            sec2.Text = Sec.Value
            Degree_Update(FMark.Value, 4, 0, CStr(Hou.Value & ":" & Min.Value & ":" & Sec.Value))
            Try
                ProgressBar.Value = ((((Hou.Value * 60) * 60) + (Min.Value * 60) + Sec.Value))
            Catch ex As System.ArgumentOutOfRangeException
            End Try
        End If
    End Sub
    Public Function RorF(ByRef Bo As Boolean)
        ConnStr.MoveFirst()
        Dim Q As String() = ConnStr.Fields("Q").Value.ToString.Split(",") ' insert in complete and select for back Q
        While Q(0) <> LN
            ConnStr.MoveNext()
            Q = ConnStr.Fields("Q").Value.ToString.Split(",")
        End While
        ConnStr2.AddNew()
        ConnStr2.Fields("Q").Value = LN
        QMark.Value = ConnStr.Fields("Degree").Value.ToString
        ConnStr2.Fields("D").Value = ConnStr.Fields("Degree").Value.ToString
        LN = ConnStr.Fields("TAI").Value.ToString
        ConnStr.MoveFirst()
        Q = ConnStr.Fields("Q").Value.ToString.Split(",")
        Dim A As String() = ConnStr.Fields("A").Value.ToString.Split(",")
        While A(0) <> RN
            ConnStr.MoveNext()
        End While
        ConnStr2.Fields("A").Value = RN
        RN = ConnStr.Fields("TQI").Value.ToString
        If RN = LN Then
            Bo = True
        Else
            Bo = False
        End If
        ConnStr2.Fields("TF").Value = Bo.ToString
        ConnStr2.Update()
        Return Bo
        LN = ""
        RN = ""
    End Function
    Public sender2 As New List(Of System.Object)
    Private Sub B8_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles B9.MouseClick, B8.MouseClick, B7.MouseClick, B6.MouseClick, B5.MouseClick, B4.MouseClick, B3.MouseClick, B2.MouseClick, B14.MouseClick, B13.MouseClick, B12.MouseClick, B11.MouseClick, B10.MouseClick, B1.MouseClick
        Select Case sender.Name
            Case Is = "B1", "B2", "B3", "B4", "B5", "B6", "B7"
                LN = sender.text
                If LLX = 0 And LLY = 0 And LRX = 0 And LRY = 0 Then
                    LLX = sender.location.x + sender.width
                    LLY = sender.location.y
                    B1.Enabled = False
                    B2.Enabled = False
                    B3.Enabled = False
                    B4.Enabled = False
                    B5.Enabled = False
                    B6.Enabled = False
                    B7.Enabled = False
                    sender2.Add(sender)
                ElseIf Not (IsNothing(LRX = 0)) And Not (IsNothing(LRY = 0)) Then
                    LLX = sender.location.x + sender.width
                    LLY = sender.location.y
                    Lin = Graphics.FromImage(Gsaver)
                    Lin.DrawLine(Pens.Black, LLX, LLY + 23, LRX, LRY + 23)
                    Me.Invalidate()
                    RorF(B)
                    If B Then
                        FMark.Value += QMark.Value
                    End If
                    LRX = 0
                    LRY = 0
                    LLX = 0
                    LLY = 0
                    B8.Enabled = True
                    B9.Enabled = True
                    B10.Enabled = True
                    B11.Enabled = True
                    B12.Enabled = True
                    B13.Enabled = True
                    B14.Enabled = True
                    sender.enabled = False
                    sender2.Add(sender)
                    For Each item As Object In sender2
                        item.enabled = False
                    Next
                End If
            Case Is = "B8", "B9", "B10", "B11", "B12", "B13", "B14"
                RN = sender.text
                If LRX = 0 And LRY = 0 And LLX = 0 And LLY = 0 Then
                    LRX = sender.location.x
                    LRY = sender.location.y
                    B8.Enabled = False
                    B9.Enabled = False
                    B10.Enabled = False
                    B11.Enabled = False
                    B12.Enabled = False
                    B13.Enabled = False
                    B14.Enabled = False
                    sender2.Add(sender)
                ElseIf Not (IsNothing(LLX = 0)) And Not (IsNothing(LLY = 0)) Then
                    LRX = sender.location.x
                    LRY = sender.location.y
                    Lin = Graphics.FromImage(Gsaver)
                    Lin.DrawLine(Pens.Black, LLX, LLY + 23, LRX, LRY + 23)
                    Me.Invalidate()
                    RorF(B)
                    If B Then
                        FMark.Value += QMark.Value
                    End If
                    LRX = 0
                    LRY = 0
                    LLX = 0
                    LLY = 0
                    B1.Enabled = True
                    B2.Enabled = True
                    B3.Enabled = True
                    B4.Enabled = True
                    B5.Enabled = True
                    B6.Enabled = True
                    B7.Enabled = True
                    sender.enabled = False
                    sender2.Add(sender)
                    For Each item As Object In sender2
                        item.enabled = False
                    Next
                End If
        End Select
    End Sub

    Private Sub JoinQ_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Lin = e.Graphics
        Lin.DrawImage(Gsaver, 0, 0, Gsaver.Width, Gsaver.Height)
    End Sub
    Public deleteall As Boolean = False
    Public Sub JoinQ_FormClosing(sender As Object,e As FormClosingEventArgs ) Handles MyBase.FormClosing
        If Not (deleteall) Then
            Try
                If ConnStr.State = 1 Then
                    ConnStr.UpdateBatch()
                    ConnStr.Close()
                    Conn.Close()
                End If
                If ConnStr2.State = 1 Then
                    ConnStr2.UpdateBatch()
                    ConnStr2.Close()
                    Conn2.Close()
                End If
                If Databasesselecter.ASSC.Checked = False Then
                    My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\" & Databasesselecter.Nam2.Text & ".mdb")
                End If
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
            End Try
        End If
    End Sub
    Public Sub timer_up()
        If Databasesselecter.CompletePC.Checked Then
            Conn.Open("Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & Databasesselecter.TextBox3.Text & ";Jet OLEDB:Database Password = " & Databasesselecter.CompleteP.Text)
            ConnStr.Open(Databasesselecter.CompleteT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Else
            Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & Databasesselecter.TextBox3.Text)
            ConnStr.Open(Databasesselecter.CompleteT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        End If
        Do While Not (ConnStr.EOF)
            Final_update(ConnStr.Fields("Degree").Value)
            ConnStr.MoveNext()
        Loop
        ConnStr.MoveFirst()
        If ConnStr.State = 1 Then
            ConnStr.UpdateBatch()
            ConnStr.Close()
            Conn.Close()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Degree_Update(FMark.Value, 3, 0, CStr(Hou.Value & ":" & Min.Value & ":" & Sec.Value))
        calcd = True
        CompleteQ.Close()
        SelectQ.Close()
        Me.Close()
    End Sub
End Class