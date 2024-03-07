Public Class CompleteQ
    Private Conn As New ADODB.Connection()
    Private ConnStr As New ADODB.Recordset()
    Private Conn2 As New ADODB.Connection()
    Private ConnStr2 As New ADODB.Recordset()
    Dim NP As Integer = 0
    Private Sub CompleteQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.Text = Databasesselecter.TextBox2.Text
        Try
            If Databasesselecter.CompletePC.Checked Then
                Conn.Open("Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & TextBox2.Text & ";Jet OLEDB:Database Password = " & Databasesselecter.CompleteP.Text)
                ConnStr.Open(Databasesselecter.CompleteT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            Else
                Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & TextBox2.Text)
                ConnStr.Open(Databasesselecter.CompleteT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            End If
        Catch
            MsgBox("(Complete)حدث خطأ أثناء محاولة تحميل قاعدة البيانات أو كلمة سر خاطئة", 0 Or 48 Or MsgBoxStyle.MsgBoxRight)
            Main.Show()
            Close()
            Exit Sub
        End Try
        If Databasesselecter.Timer.Checked = True And Databasesselecter.SelectC.Checked = True Then
            Sec.Value = SelectQ.Sec.Value.ToString
            Min.Value = SelectQ.Min.Value.ToString
            Hou.Value = SelectQ.Hou.Value.ToString
            sec2.Text = Sec.Value
            min2.Text = Min.Value
            hou2.Text = Hou.Value
        ElseIf Databasesselecter.Timer.Checked = True And Databasesselecter.SelectC.Checked = False Then
            Sec.Value = Databasesselecter.Sec.Value.ToString
            Min.Value = Databasesselecter.Min.Value.ToString
            Hou.Value = Databasesselecter.Hou.Value.ToString
            sec2.Text = Sec.Value
            min2.Text = Min.Value
            hou2.Text = Hou.Value
        ElseIf Databasesselecter.Timer.Checked = False Then
            Timer.Enabled = False
        End If
        Do While Not (ConnStr.EOF)
            Final_update(ConnStr.Fields("Degree").Value)
            ConnStr.MoveNext()
        Loop
        ConnStr.MoveFirst()
        If ConnStr.Fields("Question").Value.ToString.Contains(",") Then
            Dim Q() As String = ConnStr.Fields("Question").Value.ToString.Split(",")
            Label1.Text = Q(0).ToString()
            Try
                Label1.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                PictureBox1.ImageLocation = Q(3)
            Catch ex As IndexOutOfRangeException
            End Try
        Else
            PictureBox1.ImageLocation = ""
            Label1.Text = ConnStr.Fields("Question").Value.ToString
        End If
        Label2.Text = ConnStr.Fields("Degree").Value.ToString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button2.Enabled = True
        If NP = 0 Then
            ConnStr2.MoveNext()
            ConnStr2.AddNew()
        Else
            NP -= 1
        End If
        ConnStr2.Fields("Q").Value = Label1.Text
        ConnStr.Update()
        If TextBox1.Text = ConnStr.Fields("RA1").Value _
        Or TextBox1.Text = ConnStr.Fields("RA2").Value And Not (ConnStr.Fields("RA2").Value = "") _
        Or TextBox1.Text = ConnStr.Fields("RA3").Value And Not (ConnStr.Fields("RA3").Value = "") Then
            FMark.Value += Label2.Text
            ConnStr2.Fields("TF").Value = "True"
        Else
            ConnStr2.Fields("TF").Value = "False"
        End If
        ConnStr2.Fields("A").Value = TextBox1.Text
        ConnStr2.Fields("D").Value = Label2.Text
        ConnStr2.Update()
        ConnStr.MoveNext()
        If ConnStr.EOF Then
            Degree_Update(FMark.Value, 2, 0, CStr(Hou.Value & ":" & Min.Value & ":" & Sec.Value))
            If Databasesselecter.JoinC.Checked Then
                JoinQ.Show()
            Else
                Result.Show()
            End If
            Hide()
            Timer.Enabled = False
            TextBox1.Text = ""
            Exit Sub
        ElseIf ConnStr.BOF Then
            TextBox1.Text = ""
            Exit Sub
        End If
        If ConnStr.Fields("Question").Value.ToString.Contains(",") Then
            Dim Q() As String = ConnStr.Fields("Question").Value.ToString.Split(",")
            Label1.Text = Q(0).ToString()
            Try
                Label1.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                PictureBox1.ImageLocation = Q(3)
            Catch ex As IndexOutOfRangeException
            End Try
        Else
            PictureBox1.ImageLocation = ""
            Label1.Text = ConnStr.Fields("Question").Value.ToString
        End If
        Label2.Text = ConnStr.Fields("Degree").Value.ToString
        If NP > 0 Then
            If Not (ConnStr2.Fields("Q").Value.ToString = "Select:") Then
                ConnStr2.MoveFirst()
                Do While Label1.Text <> ConnStr2.Fields("Q").Value.ToString.Split(",").ElementAt(0)
                    ConnStr2.MoveNext()
                Loop
                TextBox1.Text = ConnStr2.Fields("A").Value.ToString
            End If
        Else
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub CompleteQ_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
    End Sub
    Public Sub timer_up()
        If Databasesselecter.CompletePC.Checked Then
            Conn.Open("Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & Databasesselecter.TextBox2.Text & ";Jet OLEDB:Database Password = " & Databasesselecter.CompleteP.Text)
            ConnStr.Open(Databasesselecter.CompleteT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        Else
            Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & Databasesselecter.TextBox2.Text)
            ConnStr.Open(Databasesselecter.CompleteT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
        End If
        Do While Not (ConnStr.EOF)
            Final_update(ConnStr.Fields("Degree").Value)
            ConnStr.MoveNext()
        Loop
        ConnStr.MoveFirst()
        If ConnStr.State = 1 Then
            ConnStr2.UpdateBatch()
            ConnStr.Close()
            Conn.Close()
        End If
    End Sub
    Private Sub SelectQ_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible = True And Databasesselecter.Timer.Checked = True Then
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
                ConnStr2.Fields("Q").Value = "Complete:"
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
                ConnStr2.Fields("Q").Value = "Complete:"
                ConnStr.Update()
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
                        If Databasesselecter.JoinC.Checked = True Then
                            JoinQ.timer_up()
                        End If
                        Degree_Update(FMark.Value, 2, 0, "00:00:00")
                        Hide()
                        Exit Sub
                    End If
                Else
                    Min.Value -= 1
                    min2.Text = Min.Value
                End If
            End If
            Sec.Value -= 1
            sec2.Text = Sec.Value
            Degree_Update(FMark.Value, 4, 0, Hou.Value & ":" & Min.Value & ":" & Sec.Value)
            Try
                ProgressBar.Value = ((((Hou.Value * 60) * 60) + (Min.Value * 60) + Sec.Value))
            Catch ex As System.ArgumentOutOfRangeException
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not (ConnStr2.BOF Or ConnStr.BOF Or ConnStr2.Fields("Q").Value = "Select:") Then
            ConnStr.MovePrevious()
            If ConnStr.BOF Then
                ConnStr.MoveNext()
                sender.enabled = False
                Exit Sub
            End If
            If ConnStr.Fields("Question").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Question").Value.ToString.Split(",")
                Label1.Text = Q(0).ToString()
                Try
                    Label1.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    PictureBox1.ImageLocation = Q(3)
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                PictureBox1.ImageLocation = ""
                Label1.Text = ConnStr.Fields("Question").Value.ToString
            End If
            Label2.Text = ConnStr.Fields("Degree").Value.ToString
            NP += 1
            If Not (ConnStr2.Fields("Q").Value.ToString = "Select:") Then
                ConnStr2.MoveFirst()
                Do While Label1.Text <> ConnStr2.Fields("Q").Value.ToString.Split(",").ElementAt(0)
                    ConnStr2.MoveNext()
                Loop
                TextBox1.Text = ConnStr2.Fields("A").Value.ToString
            Else
                sender.enabled = False
            End If
        Else
            sender.enabled = False
        End If
    End Sub

    Private Sub TextBox1_Enter(sender As Object, e As EventArgs) Handles TextBox1.Enter
        If sender.text = "......." Then
            sender.text = ""
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If sender.text = "" Then
            sender.text = "......."
        End If
    End Sub
End Class