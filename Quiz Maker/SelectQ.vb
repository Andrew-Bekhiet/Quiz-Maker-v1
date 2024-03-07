Public Class SelectQ
    Private Conn As New ADODB.Connection()
    Private ConnStr As New ADODB.Recordset()
    Private Conn2 As New ADODB.Connection()
    Private ConnStr2 As New ADODB.Recordset()
    Dim a As List(Of String)
    Dim NP As Integer = 0
    Private Sub SelectQ_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
    Private Sub SelectQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = "Data Source= " & Databasesselecter.TextBox1.Text
        Try
            If Databasesselecter.SelectPC.Checked Then
                Conn.Open("Provider = Microsoft.Jet.OLEDB.4.0 ;" & TextBox1.Text & ";Jet OLEDB:Database Password = " & Databasesselecter.SelectP.Text)
                ConnStr.Open(Databasesselecter.SelectT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            Else
                Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;" & TextBox1.Text)
                ConnStr.Open(Databasesselecter.SelectT.Text, Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            End If
        Catch ex As Exception
            MsgBox("(Select)حدث خطأ أثناء محاولة تحميل قاعدة البيانات أو كلمة سر خاطئة" & vbCrLf & ex.Message & ex.StackTrace, 0 Or 48 Or MsgBoxStyle.MsgBoxRight)
            Main.Show()
            Close()
            Exit Sub
        End Try
        If ConnStr.Fields("Question").Value.ToString.Contains(",") Then
            Dim Q() As String = ConnStr.Fields("Question").Value.ToString.Split(",")
            QLabel.Text = Q(0).ToString()
            Try
                QLabel.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                Picture.ImageLocation = Q(3)
            Catch ex As IndexOutOfRangeException
            End Try
        Else
            Picture.ImageLocation = ""
            QLabel.Text = ConnStr.Fields("Question").Value.ToString
        End If
        A1Label.Text = ConnStr.Fields("Answer 1").Value.ToString
        A2Label.Text = ConnStr.Fields("Answer 2").Value.ToString
        A3Label.Text = ConnStr.Fields("Answer 3").Value.ToString
        A4Label.Text = ConnStr.Fields("Answer 4").Value.ToString
        RALabel.Text = ConnStr.Fields("RAnswer").Value.ToString
        DL.Value = ConnStr.Fields("Degree").Value.ToString
        If Databasesselecter.Timer.Checked = True Then
            Sec.Value = Databasesselecter.Sec.Value.ToString
            Min.Value = Databasesselecter.Min.Value.ToString
            Hou.Value = Databasesselecter.Hou.Value.ToString
            Label4.Text = Sec.Value
            Label5.Text = Min.Value
            Label6.Text = Hou.Value
        Else
            Timer.Enabled = False
        End If
        Do While Not (ConnStr.EOF)
            Final_update(ConnStr.Fields("Degree").Value)
            ConnStr.MoveNext()
        Loop
        ConnStr.MoveFirst()
        If ConnStr.EOF Then
            Degree_Update(FMark.Value, 1, 0)
            If Databasesselecter.CompleteC.Checked = False And Databasesselecter.JoinC.Checked = False Then
                Result.Show()
            ElseIf Databasesselecter.CompleteC.Checked = False Then
                JoinQ.Show()
            Else
                CompleteQ.Show()
            End If
            Hide()
            Timer.Enabled = False
            Exit Sub
        ElseIf ConnStr.BOF Then
            Exit Sub
        End If
        If ConnStr.Fields("Question").Value.ToString.Contains(",") Then
            Dim Q() As String = ConnStr.Fields("Question").Value.ToString.Split(",")
            QLabel.Text = Q(0).ToString()
            Try
                QLabel.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                Picture.ImageLocation = Q(3)
            Catch ex As IndexOutOfRangeException
            End Try
        Else
            Picture.ImageLocation = ""
            QLabel.Text = ConnStr.Fields("Question").Value.ToString
        End If
        A1Label.Text = ConnStr.Fields("Answer 1").Value.ToString
        A2Label.Text = ConnStr.Fields("Answer 2").Value.ToString
        A3Label.Text = ConnStr.Fields("Answer 3").Value.ToString
        A4Label.Text = ConnStr.Fields("Answer 4").Value.ToString
        RALabel.Text = ConnStr.Fields("RAnswer").Value.ToString
        DL.Value = ConnStr.Fields("Degree").Value.ToString
    End Sub
    Dim AA As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = True
        If NP = 0 Then
            ConnStr2.MoveNext()
            ConnStr2.AddNew()
        Else
            NP -= 1
        End If
        ConnStr2.Fields("Q").Value = QLabel.Text
        ConnStr2.Update()
        If A1Label.Checked = True Then
            AA = A1Label.Text
        ElseIf A2Label.Checked = True Then
            AA = A2Label.Text
        ElseIf A3Label.Checked = True Then
            AA = A3Label.Text
        ElseIf A4Label.Checked = True Then
            AA = A4Label.Text
        End If
        If A1Label.Checked = True And A1Label.Text = RALabel.Text _
            Or A2Label.Checked = True And A2Label.Text = RALabel.Text _
            Or A3Label.Checked = True And A3Label.Text = RALabel.Text _
            Or A4Label.Checked = True And A4Label.Text = RALabel.Text Then
            FMark.Value += DL.Value
            ConnStr2.Fields("TF").Value = "True"
            ConnStr2.Fields("A").Value = AA
            ConnStr2.Update()
        Else
            If ConnStr2.Fields("TF").Value.ToString = "True" Then
                FMark.Value -= DL.Value
            End If
            ConnStr2.Fields("TF").Value = "False"
            ConnStr2.Fields("A").Value = AA
            ConnStr2.Update()
        End If
        ConnStr2.Fields("D").Value = DL.Value.ToString
        ConnStr2.Update()
        If Not (ConnStr.EOF) Then
            ConnStr.MoveNext()
            If ConnStr.EOF Then
                Degree_Update(FMark.Value, 1, 0, CStr(Hou.Value & ":" & Min.Value & ":" & Sec.Value))
                If Databasesselecter.CompleteC.Checked = False And Databasesselecter.JoinC.Checked = False Then
                    Result.Show()
                ElseIf Databasesselecter.CompleteC.Checked = False Then
                    JoinQ.Show()
                Else
                    CompleteQ.Show()
                End If
                Hide()
                Timer.Enabled = False
                Exit Sub
            ElseIf ConnStr.BOF Then
                Exit Sub
            End If
            If ConnStr.Fields("Question").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Question").Value.ToString.Split(",")
                QLabel.Text = Q(0).ToString()
                Try
                    QLabel.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    Picture.ImageLocation = Q(3)
                Catch
                End Try
            Else
                Picture.ImageLocation = ""
                QLabel.Text = ConnStr.Fields("Question").Value.ToString
            End If
            A1Label.Text = ConnStr.Fields("Answer 1").Value.ToString
            A2Label.Text = ConnStr.Fields("Answer 2").Value.ToString
            A3Label.Text = ConnStr.Fields("Answer 3").Value.ToString
            A4Label.Text = ConnStr.Fields("Answer 4").Value.ToString
            RALabel.Text = ConnStr.Fields("RAnswer").Value.ToString
            DL.Value = ConnStr.Fields("Degree").Value.ToString
            If NP > 0 Then
                If Not (ConnStr2.Fields("Q").Value.ToString = "Select:") Then
                    ConnStr2.MoveFirst()
                    Do While QLabel.Text <> ConnStr2.Fields("Q").Value.ToString.Split(",").ElementAt(0)
                        ConnStr2.MoveNext()
                    Loop
                    If ConnStr2.Fields("A").Value.ToString = A1Label.Text.ToString Then
                        A1Label.Checked = True
                    ElseIf ConnStr2.Fields("A").Value.ToString = A2Label.Text.ToString Then
                        A2Label.Checked = True
                    ElseIf ConnStr2.Fields("A").Value.ToString = A3Label.Text.ToString Then
                        A3Label.Checked = True
                    ElseIf ConnStr2.Fields("A").Value.ToString = A4Label.Text.ToString Then
                        A4Label.Checked = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If Databasesselecter.Timer.Checked = True And Me.Visible = True Then
            If Sec.Value = 0 Then
                Sec.Value = 60
                Label4.Text = Sec.Value
                If Min.Value = 0 Then
                    Min.Value = 59
                    Label5.Text = Min.Value
                    If (Not Hou.Value = 0) Then
                        Hou.Value -= 1
                        Label6.Text = Hou.Value
                    Else
                        MsgBox("إنتهي الوقت!", MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.Exclamation)
                        Hou.Value = 0
                        Min.Value = 0
                        Sec.Value = 0
                        Label4.Text = Label5.Text = Label6.Text = "0"
                        ProgressBar.Value = 0
                        Timer.Enabled = False
                        If Databasesselecter.CompleteC.Checked = True Then
                            CompleteQ.timer_up()
                        End If
                        If Databasesselecter.JoinC.Checked = True Then
                            JoinQ.timer_up()
                        End If

                        Degree_Update(FMark.Value, 1, 0, "00:00:00")
                        Hide()
                        Exit Sub
                    End If
                Else
                    Min.Value -= 1
                    Label5.Text = Min.Value
                End If
            End If
            Sec.Value -= 1
            Label4.Text = Sec.Value
            Degree_Update(FMark.Value, 4, 0, Hou.Value & ":" & Min.Value & ":" & Sec.Value)
            Try
                ProgressBar.Value = ((((Hou.Value * 60) * 60) + (Min.Value * 60) + Sec.Value))
            Catch ex As System.ArgumentOutOfRangeException
            End Try
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
                ConnStr2.Fields("Q").Value = "Select:"
                ConnStr2.Update()
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
                ConnStr2.Fields("Q").Value = "Select:"
                ConnStr2.Update()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not (ConnStr2.BOF Or ConnStr.BOF Or ConnStr2.Fields("Q").Value = "Select:") Then
            ConnStr.MovePrevious()
            If ConnStr.BOF Then
                ConnStr.MoveNext()
                sender.enabled = False
                Exit Sub
            End If
            If ConnStr.Fields("Question").Value.ToString.Contains(",") Then
                Dim Q() As String = ConnStr.Fields("Question").Value.ToString.Split(",")
                QLabel.Text = Q(0).ToString()
                Try
                    QLabel.Font = New Font(Q(1), CDec(Q(2)), FontStyle.Bold)
                    Picture.ImageLocation = Q(3)
                Catch ex As IndexOutOfRangeException
                End Try
            Else
                Picture.ImageLocation = ""
                QLabel.Text = ConnStr.Fields("Question").Value.ToString
            End If
            A1Label.Text = ConnStr.Fields("Answer 1").Value.ToString
            A2Label.Text = ConnStr.Fields("Answer 2").Value.ToString
            A3Label.Text = ConnStr.Fields("Answer 3").Value.ToString
            A4Label.Text = ConnStr.Fields("Answer 4").Value.ToString
            RALabel.Text = ConnStr.Fields("RAnswer").Value.ToString
            DL.Value = ConnStr.Fields("Degree").Value.ToString
            NP += 1
            If Not (ConnStr2.Fields("Q").Value.ToString = "Select:") Then
                ConnStr2.MoveFirst()
                Do While QLabel.Text <> ConnStr2.Fields("Q").Value.ToString.Split(",").ElementAt(0)
                    ConnStr2.MoveNext()
                Loop
                If ConnStr2.Fields("A").Value.ToString = A1Label.Text.ToString Then
                    A1Label.Checked = True
                ElseIf ConnStr2.Fields("A").Value.ToString = A2Label.Text.ToString Then
                    A2Label.Checked = True
                ElseIf ConnStr2.Fields("A").Value.ToString = A3Label.Text.ToString Then
                    A3Label.Checked = True
                ElseIf ConnStr2.Fields("A").Value.ToString = A4Label.Text.ToString Then
                    A4Label.Checked = True
                End If
            Else
                sender.enabled = False
            End If
        Else
            sender.enabled = False
        End If
    End Sub
End Class