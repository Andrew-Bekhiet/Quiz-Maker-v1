Imports System.Data
Public Class Databasesselecter
    Dim SDataSource = "Data Source= "
    Public ConnStr As New ADODB.Recordset()
    Public Conn As New ADODB.Connection()
    Public ConnStr2 As New ADODB.Recordset()
    Public Conn2 As New ADODB.Connection()
    Dim ConnStrI As Integer
    Private c As Boolean = False
    Dim SelectI As Integer = 0
    Dim CompleteI As Integer = 0
    Dim JoinI As Integer = 0
    Dim SaveI As Integer = 0
    Dim TimerI As Integer = 0
    Dim b As Boolean = True
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If OpenCh.ShowDialog = DialogResult.OK Then
            TextBox1.Text = OpenCh.FileName
            SelectQ.TextBox1.Text = "Data Source= " & OpenCh.FileName
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If OpenCo.ShowDialog = DialogResult.OK Then
            TextBox2.Text = OpenCo.FileName
            CompleteQ.TextBox2.Text = "Data Source= " & OpenCo.FileName
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If OpenJ.ShowDialog = DialogResult.OK Then
            TextBox3.Text = OpenJ.FileName
            JoinQ.TextBox1.Text = "Data Source= " & OpenJ.FileName
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If OpenS.ShowDialog = DialogResult.OK Then
            TextBox4.Text = OpenS.FileName
        End If
    End Sub

    Public Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If ((((TextBox1.Enabled = True And TextBox1.Text <> "" And SelectT.Text <> "" And ((SelectP.Text <> "" And SelectP.Enabled = True) Or SelectPC.Checked = False)) Or TextBox1.Enabled = False)) _
            And (((TextBox2.Enabled = True And TextBox2.Text <> "" And CompleteT.Text <> "" And ((CompleteP.Text <> "" And CompleteP.Enabled = True) Or CompletePC.Checked = False)) Or TextBox2.Enabled = False)) _
            And (((TextBox3.Enabled = True And TextBox3.Text <> "" And JoinT.Text <> "" And ((JoinP.Text <> "" And JoinP.Enabled = True) Or JoinPC.Checked = False)) Or TextBox3.Enabled = False))) _
            And (((TextBox5.Enabled = True And TextBox5.Text <> "" And Savings2T.Text <> "" And ((Savings2P.Text <> "" And Savings2P.Enabled = True) Or Savings2PC.Checked = False)) Or TextBox5.Enabled = False)) _
            And (((ASST.Enabled = True And ASST.Text <> "") Or ASSC.Checked = False)) _
            And (TextBox6.Text <> "") _
            And ((((Hou.Enabled = True And Hou.Value <> 0) And (Min.Enabled = True And Min.Value <> 0) And (Sec.Enabled = True And Sec.Value <> 0) And Timer.Checked = True) Or Hou.Value = 1 And Timer.Checked = True) Or Timer.Checked = False) Then
            If TextBox4.Text = "" Then
                If MsgBox("لقد تركت مكان حفظ البيانات فارغًا" & vbCrLf & "هل تريد من البرنامج وضع البيانات التي أدخلتها في قاعدة بيانات جديدة؟", MsgBoxStyle.YesNo Or MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxRight) = MsgBoxResult.Yes Then
                    b = False
                Else
                    b = True
                End If
            End If
            If Conn2.State = 0 And Savings2C.Checked = True Then
                Try
                    If Savings2PC.Checked Then
                        Conn2.Open("Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & TextBox5.Text & ";Jet OLEDB:Database Password = " & Savings2P.Text)
                        ConnStr2.Open(Savings2T.Text, Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    Else
                        Conn2.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & TextBox5.Text)
                        ConnStr2.Open(Savings2T.Text, Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    End If
                Catch
                    MsgBox("حدث خطأ أثناء محاولة تحميل قاعدة البيانات أو كلمة سر خاطئة(Savings2).", 0 Or 48 Or MsgBoxStyle.MsgBoxRight)
                End Try
            ElseIf Conn2.State = 0 And Savings2C.Checked = False Then
                Try
                    If Savings2PC.Checked Then
                        Conn2.Open("Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & My.Application.Info.DirectoryPath & "\Savings2.mdb" & ";Jet OLEDB:Database Password = " & Savings2P.Text)
                        ConnStr2.Open(Savings2T.Text, Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    Else
                        Conn2.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\Savings2.mdb")
                        ConnStr2.Open(Savings2T.Text, Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    End If
                Catch ex As System.Exception
                    MsgBox("حدث خطأ أثناء محاولة تحميل قاعدة البيانات أو كلمة سر خاطئة(Savings2)." & vbCrLf & ex.StackTrace, 0 Or 48 Or MsgBoxStyle.MsgBoxRight)
                End Try
            End If
            If Not (b) Then
                If System.IO.File.Exists("C:\Windows\Temp\Savings.mdb") Then
                    System.IO.File.Delete("C:\Windows\Temp\Savings.mdb")
                End If
                Dim cat As ADOX.Catalog = New ADOX.Catalog()
                Try
                    cat.Create("Provider = Microsoft.Jet.OLEDB.4.0;Data Source = " & My.Application.Info.DirectoryPath & "\Savings.mdb" & ";Jet OLEDB:Engine Type = 5")
                Catch ex As System.Runtime.InteropServices.COMException
                    If MsgBox("يوجد قاعدة بيانات في نفس المجلد." & vbCrLf & "هل تريد المتابعة بحذف قاعدة البيانات القديمة ووضع الجديدة؟", MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ConnStr.UpdateBatch()
                        ConnStr.Close()
                        Conn.Close()
                        System.IO.File.Delete(My.Application.Info.DirectoryPath & "\Savings.mdb")
                        cat.Create("Provider = Microsoft.Jet.OLEDB.4.0;Data Source = " & My.Application.Info.DirectoryPath & "\Savings.mdb" & ";Jet OLEDB:Engine Type = 5")
                    Else
                        Hide()
                        Exit Sub
                    End If
                End Try
                cat = Nothing
                Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\Savings.mdb")
                con.Open()
                Dim dbSchema As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, My.Application.Info.DirectoryPath & "\Savings.mdb", "TABLE"})
                con.Close()
                Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" + "Savings" + "] ([ID] TEXT, [Valu] TEXT, [TableN] TEXT, [Password] TEXT)", con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\Savings.mdb")
                ConnStr.Open("Savings", Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                If Savings2C.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Save"
                    ConnStr.Fields("Valu").Value = TextBox5.Text
                    ConnStr.Fields("TableN").Value = Savings2T.Text
                    If Savings2PC.Checked = True Then
                        ConnStr.Fields("Password").Value = Savings2P.Text.ToString
                    End If
                    Savings2C.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Save"
                    ConnStr.Fields("Valu").Value = "False"
                    Savings2C.Checked = False
                End If
                ConnStr.Update()
                If ASSC.Checked Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "ASS"
                    ConnStr.Fields("Valu").Value = ASST.Text
                    ConnStr.Update()
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "ASS"
                    ConnStr.Fields("Valu").Value = "False"
                    ConnStr.Update()
                End If
                If NameC.Checked Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "NameMax"
                    ConnStr.Fields("Valu").Value = NameMax.Value
                    ConnStr.Update()
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "NameMin"
                    ConnStr.Fields("Valu").Value = NameMin.Value
                    ConnStr.Update()
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "NameMax"
                    ConnStr.Fields("Valu").Value = False
                    ConnStr.Update()
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "NameMin"
                    ConnStr.Fields("Valu").Value = False
                    ConnStr.Update()
                End If
                ConnStr.AddNew()
                ConnStr.Fields("ID").Value = "FeedC"
                ConnStr.Fields("Valu").Value = FeedC.Checked.ToString
                ConnStr.Update()
                ConnStr.AddNew()
                ConnStr.Fields("ID").Value = "Password"
                ConnStr.Fields("Valu").Value = TextBox6.Text
                ConnStr.Update()
                If Timer.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Timer"
                    ConnStr.Fields("Valu").Value = Hou.Value & ":" & Min.Value & ":" & Sec.Value
                    Timer.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Timer"
                    ConnStr.Fields("Valu").Value = "False"
                    Timer.Checked = False
                End If
                ConnStr.Update()
                If SelectC.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Select"
                    ConnStr.Fields("Valu").Value = TextBox1.Text
                    ConnStr.Fields("TableN").Value = SelectT.Text
                    If SelectPC.Checked = True Then
                        ConnStr.Fields("Password").Value = SelectP.Text.ToString
                    End If
                    SelectC.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Select"
                    ConnStr.Fields("Valu").Value = "False"
                    SelectC.Checked = False
                End If
                ConnStr.Update()
                If CompleteC.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Complete"
                    ConnStr.Fields("Valu").Value = TextBox2.Text
                    ConnStr.Fields("TableN").Value = CompleteT.Text
                    If CompletePC.Checked = True Then
                        ConnStr.Fields("Password").Value = CompleteP.Text.ToString
                    End If
                    CompleteC.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Complete"
                    ConnStr.Fields("Valu").Value = "False"
                    CompleteC.Checked = False
                End If
                ConnStr.Update()
                If JoinC.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Join"
                    ConnStr.Fields("Valu").Value = TextBox3.Text
                    ConnStr.Fields("TableN").Value = JoinT.Text
                    If JoinPC.Checked = True Then
                        ConnStr.Fields("Password").Value = JoinP.Text.ToString
                    End If
                    JoinC.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Join"
                    ConnStr.Fields("Valu").Value = "False"
                    JoinC.Checked = False
                End If
                ConnStr.Update()
                ConnStr.UpdateBatch()
                ConnStr.Close()
                Conn.Close()
                TextBox4.Text = My.Application.Info.DirectoryPath & "\Savings.mdb"
                MsgBox("رجاء إعادة تشغيل البرنامج لإجراء التعديلات اللازمة وظهور البيانات الصحيحة", MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.Information)
                End
            End If
            SDataSource = SDataSource & TextBox4.Text
            If Conn.State = 0 Then
                If Not (b) Then
                    Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & TextBox4.Text)
                    ConnStr.Open("Savings", Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                Else
                    Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\Savings.mdb")
                    ConnStr.Open("Savings", Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                End If
                ConnStrI = 1
            End If
            If CheckBox2.Checked Then
                While 3 = 3
                    Try
                        ConnStr.MoveFirst()
                        ConnStr.Delete()
                        ConnStr.Update()
                        ConnStr.MoveNext()
                        ConnStr.Delete()
                        ConnStr.Update()
                    Catch
                        Exit While
                    End Try
                End While
                If Savings2C.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Save"
                    ConnStr.Fields("Valu").Value = TextBox5.Text
                    ConnStr.Fields("TableN").Value = Savings2T.Text
                    If Savings2PC.Checked = True Then
                        ConnStr.Fields("Password").Value = Savings2P.Text.ToString
                    End If
                    Savings2C.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Save"
                    ConnStr.Fields("Valu").Value = "False"
                    Savings2C.Checked = False
                End If
                ConnStr.Update()
                If ASSC.Checked Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "ASS"
                    ConnStr.Fields("Valu").Value = ASST.Text
                    ConnStr.Update()
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "ASS"
                    ConnStr.Fields("Valu").Value = "False"
                    ConnStr.Update()
                End If
                If NameC.Checked Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "NameMax"
                    ConnStr.Fields("Valu").Value = NameMax.Value
                    ConnStr.Update()
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "NameMin"
                    ConnStr.Fields("Valu").Value = NameMin.Value
                    ConnStr.Update()
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "NameMax"
                    ConnStr.Fields("Valu").Value = False.ToString
                    ConnStr.Update()
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "NameMin"
                    ConnStr.Fields("Valu").Value = False.ToString
                    ConnStr.Update()
                End If
                ConnStr.AddNew()
                ConnStr.Fields("ID").Value = "FeedC"
                ConnStr.Fields("Valu").Value = FeedC.Checked.ToString
                ConnStr.Update()
                ConnStr.AddNew()
                ConnStr.Fields("ID").Value = "Password"
                ConnStr.Fields("Valu").Value = TextBox6.Text
                ConnStr.Update()
                If Timer.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Timer"
                    ConnStr.Fields("Valu").Value = Hou.Value & ":" & Min.Value & ":" & Sec.Value
                    Timer.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Timer"
                    ConnStr.Fields("Valu").Value = "False"
                    Timer.Checked = False
                End If
                ConnStr.Update()
                If SelectC.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Select"
                    ConnStr.Fields("Valu").Value = TextBox1.Text
                    ConnStr.Fields("TableN").Value = SelectT.Text
                    If SelectPC.Checked = True Then
                        ConnStr.Fields("Password").Value = SelectP.Text.ToString
                    End If
                    SelectC.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Select"
                    ConnStr.Fields("Valu").Value = "False"
                    SelectC.Checked = False
                End If
                ConnStr.Update()
                If CompleteC.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Complete"
                    ConnStr.Fields("Valu").Value = TextBox2.Text
                    ConnStr.Fields("TableN").Value = CompleteT.Text
                    If CompletePC.Checked = True Then
                        ConnStr.Fields("Password").Value = CompleteP.Text.ToString
                    End If
                    CompleteC.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Complete"
                    ConnStr.Fields("Valu").Value = "False"
                    CompleteC.Checked = False
                End If
                ConnStr.Update()
                If JoinC.Checked = True Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Join"
                    ConnStr.Fields("Valu").Value = TextBox3.Text
                    ConnStr.Fields("TableN").Value = JoinT.Text
                    If JoinPC.Checked = True Then
                        ConnStr.Fields("Password").Value = JoinP.Text.ToString
                    End If
                    JoinC.Checked = True
                Else
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Join"
                    ConnStr.Fields("Valu").Value = "False"
                    JoinC.Checked = False
                End If
                ConnStr.Update()
            Else
                CheckBox2.Checked = True
            End If
            If sender.name = "Button9" Then
                Me.Hide()
            End If
            Dim cc As Integer = 1
            ConnStr.MoveFirst()
            If sender.name = "Button9" Then
                For cc = 1 To 30
                    Try
                        If ConnStr.Fields("ID").Value = "Password" Then
                            ConnStr.Fields("Valu").Value = TextBox6.Text
                            Exit For
                        Else
                            ConnStr.MoveNext()
                            cc += 1
                        End If
                    Catch
                        Exit For
                    End Try
                Next
                If cc = 30 Then
                    ConnStr.AddNew()
                    ConnStr.Fields("ID").Value = "Password"
                    ConnStr.Fields("Valu").Value = TextBox6.Text
                    ConnStr.Update()
                End If
            End If
            ConnStr.MoveFirst()
            If sender.name = "Button9" Then
                For counter = 1 To 30
                    Try
                        If ConnStr.Fields("ID").Value = "Timer" And Timer.Checked = True And Not (ConnStr.Fields("Valu").Value = "False") Then
                            ConnStr.Fields("Valu").Value = Hou.Value & ":" & Min.Value & ":" & Sec.Value
                            ConnStr.Update()
                            Hou.Enabled = True
                            Min.Enabled = True
                            Sec.Enabled = True
                        ElseIf ConnStr.Fields("ID").Value = "Timer" And Timer.Checked = False Then
                            ConnStr.Fields("Valu").Value = "False"
                            Timer.Checked = False
                            Hou.Enabled = False
                            Min.Enabled = False
                            Sec.Enabled = False
                            ConnStr.Update()
                        End If
                        If ConnStr.Fields("ID").Value = "Select" And SelectC.Checked = True And Not (ConnStr.Fields("Valu").Value = "False") Then
                            ConnStr.Fields("ID").Value = "Select"
                            ConnStr.Fields("Valu").Value = TextBox1.Text
                            ConnStr.Fields("TableN").Value = SelectT.Text
                            If SelectPC.Checked = True Then
                                ConnStr.Fields("Password").Value = SelectP.Text.ToString
                            End If
                            SelectC.Checked = True
                            ConnStr.Update()
                        ElseIf ConnStr.Fields("ID").Value = "Select" And SelectC.Checked = False Then
                            ConnStr.Fields("Valu").Value = "False"
                            SelectC.Checked = False
                            ConnStr.Update()
                        End If
                        If ConnStr.Fields("ID").Value = "Complete" And CompleteC.Checked = True And Not (ConnStr.Fields("Valu").Value = "False") Then
                            ConnStr.Fields("ID").Value = "Complete"
                            ConnStr.Fields("Valu").Value = TextBox2.Text
                            ConnStr.Fields("TableN").Value = CompleteT.Text
                            If CompletePC.Checked = True Then
                                ConnStr.Fields("Password").Value = CompleteP.Text.ToString
                            End If
                            CompleteC.Checked = True
                            ConnStr.Update()
                        ElseIf ConnStr.Fields("ID").Value = "Complete" And CompleteC.Checked = False Then
                            ConnStr.Fields("Valu").Value = "False"
                            CompleteC.Checked = False
                            ConnStr.Update()
                        End If
                        If ConnStr.Fields("ID").Value = "Join" And JoinC.Checked = True And Not (ConnStr.Fields("Valu").Value = "False") Then
                            ConnStr.Fields("ID").Value = "Join"
                            ConnStr.Fields("Valu").Value = TextBox3.Text
                            ConnStr.Fields("TableN").Value = JoinT.Text
                            If JoinPC.Checked = True Then
                                ConnStr.Fields("Password").Value = JoinP.Text.ToString
                            End If
                            JoinC.Checked = True
                            ConnStr.Update()
                        ElseIf ConnStr.Fields("ID").Value = "Join" And JoinC.Checked = False Then
                            ConnStr.Fields("Valu").Value = "False"
                            JoinC.Checked = False
                            ConnStr.Update()
                        End If
                        If ConnStr.Fields("ID").Value = "Save" And Not (ConnStr.Fields("Valu").Value = "False") And SaveI = 0 Then
                            ConnStr.Fields("Valu").Value = TextBox5.Text
                            ConnStr.Fields("TableN").Value = Savings2T.Text
                            If Savings2PC.Checked Then
                                ConnStr.Fields("Password").Value = Savings2P.Text
                            End If
                            Savings2C.Checked = True
                            ConnStr.Update()
                        ElseIf ConnStr.Fields("ID").Value = "Save" And Savings2C.Checked = False Then
                            Savings2C.Checked = False
                            ConnStr.Fields("Valu").Value = "False"
                            ConnStr.Update()
                        End If
                        If ConnStr.Fields("ID").Value = "ASS" Then
                            ConnStr.Fields("Valu").Value = ASST.Text
                        End If
                        If ConnStr.Fields("ID").Value = "FeedC" Then
                            ConnStr.Fields("Valu").Value = FeedC.Checked.ToString
                        End If
                        If NameC.Checked And ConnStr.Fields("ID").Value = "NameMax" Then
                            ConnStr.Fields("Valu").Value = NameMax.Value
                            ConnStr.Update()
                        ElseIf ConnStr.Fields("ID").Value = "NameMax" Then
                            ConnStr.Fields("Valu").Value = False
                            ConnStr.Update()
                        End If
                        If NameC.Checked And ConnStr.Fields("ID").Value = "NameMin" Then
                            ConnStr.Fields("Valu").Value = NameMin.Value
                            ConnStr.Update()
                        ElseIf ConnStr.Fields("ID").Value = "NameMin" Then
                            ConnStr.Fields("Valu").Value = False
                            ConnStr.Update()
                        End If
                    Catch ex As Runtime.InteropServices.COMException
                        If ex.Message <> "Either BOF or EOF is True, or the current record has been deleted. Requested operation requires a current record." Then
                            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                        Else
                            Exit For
                        End If
                    End Try
                    ConnStr.MoveNext()
                    counter += 1
                Next
            End If
        ElseIf CheckBox1.Checked And TextBox4.Text <> "" Then
            If Not (IO.File.Exists(TextBox4.Text)) Then
                MsgBox("الملف الذي تم كتابة مكانة غير موجود يرجى لتأجد من وجوده" & vbCrLf & "(Savings)", MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.MsgBoxRtlReading)
                Hide()
                Exit Sub
            Else
                System.IO.File.Copy(TextBox4.Text, "C:\Windows\Temp\savings.mdb")
                IO.File.SetAttributes("C:\Windows\Temp\Savings.mdb", IO.FileAttributes.Hidden)
                MsgBox("رجاء إعادة تشغيل البرنامج لإجراء التعديلات اللازمة وظهور البيانات الصحيحة", MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.Information)
                End
            End If
        Else
            If sender.name = "Button9" Then
                If MsgBox("من فضلك أملاء باقي البيانات", MsgBoxStyle.YesNo Or 0 Or 64 Or MsgBoxStyle.MsgBoxRight) = MsgBoxResult.No Then
                    Me.Hide()
                End If
            End If
        End If
    End Sub

    Private Sub Nam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nam2.TextChanged
        If Savings2C.Checked = True Then
            If ConnStr2.State = 1 Then
                ConnStr2.AddNew()
                ConnStr2.Fields("Nam").Value = Nam2.Text.ToString
                ConnStr2.Update()
            Else
                Try
                    If Savings2PC.Checked Then
                        Conn2.Open("Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & TextBox5.Text & ";Jet OLEDB:Database Password = " & Savings2P.Text)
                        ConnStr2.Open(Savings2T.Text, Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    Else
                        Conn2.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & TextBox5.Text)
                        ConnStr2.Open(Savings2T.Text, Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    End If
                Catch
                    MsgBox("حدث خطأ أثناء محاولة تحميل قاعدة البيانات أو كلمة سر خاطئة(Savings2).", 0 Or 48 Or MsgBoxStyle.MsgBoxRight)
                    Nam.Eror = True
                End Try
            End If
        Else
            If ConnStr2.State = 1 Then
                ConnStr2.AddNew()
                ConnStr2.Fields("Nam").Value = Nam2.Text.ToString
                ConnStr2.Update()
            Else
                Try
                    If Savings2PC.Checked Then
                        Conn2.Open("Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & My.Application.Info.DirectoryPath & "\Savings2.mdb" & ";Jet OLEDB:Database Password = " & Savings2P.Text)
                        ConnStr2.Open(Savings2T.Text, Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    Else
                        Conn2.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\Savings2.mdb")
                        ConnStr2.Open(Savings2T.Text, Conn2, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
                    End If
                Catch
                    MsgBox("حدث خطأ أثناء محاولة تحميل قاعدة البيانات أو كلمة سر خاطئة(Savings2).", 0 Or 48 Or MsgBoxStyle.MsgBoxRight)
                    Nam.Eror = True
                End Try
            End If
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        JoinQ.Show()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If OpenS2.ShowDialog = DialogResult.OK Then
            TextBox5.Text = OpenS2.FileName
        End If
    End Sub
    Dim counter As Integer = 0
    Private Sub Databasesselecter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(My.Application.Info.DirectoryPath & "\Savings.mdb") Then
            Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\Savings.mdb")
            ConnStr.Open("Savings", Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            ConnStrI = 1
            ConnStr.MoveFirst()
            For counter = 1 To 30
                Try
                    If ConnStr.Fields("ID").Value = "Select" And Not (ConnStr.Fields("Valu").Value = "False") And SelectI = 0 Then
                        TextBox1.Text = ConnStr.Fields("Valu").Value.ToString
                        SelectT.Text = ConnStr.Fields("TableN").Value.ToString
                        If Not (ConnStr.Fields("Password").Value.ToString = "") Then
                            SelectP.Text = ConnStr.Fields("Password").Value.ToString
                            SelectPC.Checked = True
                        End If
                        SelectC.Checked = True
                        SelectI = 1
                    ElseIf SelectI = 0 And ConnStr.Fields("ID").Value = "Select" Then
                        SelectC.Checked = False
                        SelectI = 1
                    End If
                    If ConnStr.Fields("ID").Value = "Complete" And Not (ConnStr.Fields("Valu").Value = "False") And CompleteI = 0 Then
                        TextBox2.Text = ConnStr.Fields("Valu").Value.ToString
                        CompleteT.Text = ConnStr.Fields("TableN").Value.ToString
                        If Not (ConnStr.Fields("Password").Value.ToString = "") Then
                            CompleteP.Text = ConnStr.Fields("Password").Value.ToString
                            CompletePC.Checked = True
                        End If
                        CompleteC.Checked = True
                        CompleteI = 1
                    ElseIf CompleteI = 0 And ConnStr.Fields("ID").Value = "Complete" Then
                        CompleteC.Checked = False
                        CompleteI = 1
                    End If
                    If ConnStr.Fields("ID").Value = "Join" And Not (ConnStr.Fields("Valu").Value = "False") And JoinI = 0 Then
                        TextBox3.Text = ConnStr.Fields("Valu").Value.ToString
                        JoinT.Text = ConnStr.Fields("TableN").Value.ToString
                        If Not (ConnStr.Fields("Password").Value.ToString = "") Then
                            JoinP.Text = ConnStr.Fields("Password").Value.ToString
                            JoinPC.Checked = True
                        End If
                        JoinC.Checked = True
                        JoinI = 1
                    ElseIf JoinI = 0 And ConnStr.Fields("ID").Value = "Join" Then
                        JoinC.Checked = False
                        JoinI = 1
                    End If
                    If ConnStr.Fields("ID").Value = "Save" And Not (ConnStr.Fields("Valu").Value = "False") And SaveI = 0 Then
                        TextBox5.Text = ConnStr.Fields("Valu").Value.ToString
                        Savings2T.Text = ConnStr.Fields("TableN").Value.ToString
                        If Not (ConnStr.Fields("Password").Value.ToString = "") Then
                            Savings2P.Text = ConnStr.Fields("Password").Value.ToString
                            Savings2PC.Checked = True
                        End If
                        Savings2C.Checked = True
                        SaveI = 1
                    ElseIf SaveI = 0 And ConnStr.Fields("ID").Value = "Save" Then
                        Savings2C.Checked = False
                        SaveI = 1
                    End If
                    If ConnStr.Fields("ID").Value = "ASS" And ConnStr.Fields("Valu").Value.ToString <> "False" Then
                        ASST.Text = ConnStr.Fields("Valu").Value.ToString
                    Else
                        ASSC.Checked = False
                    End If
                    If ConnStr.Fields("ID").Value = "FeedC" Then
                        FeedC.Checked = CBool(ConnStr.Fields("Valu").Value.ToString)
                    End If
                    If ConnStr.Fields("ID").Value = "NameMax" And Not ((ConnStr.Fields("Valu").Value.ToString) = "False" Or ConnStr.Fields("Valu").Value.ToString = "0") Then
                        NameC.Checked = True
                        NameMax.Value = CDec(ConnStr.Fields("Valu").Value)
                    ElseIf ConnStr.Fields("ID").Value = "NameMax" And (ConnStr.Fields("Valu").Value.ToString = "False" Or ConnStr.Fields("Valu").Value.ToString = "0") Then
                        NameC.Checked = False
                    End If
                    If ConnStr.Fields("ID").Value = "NameMin" And Not ((ConnStr.Fields("Valu").Value.ToString) = "False" Or ConnStr.Fields("Valu").Value.ToString = "0") Then
                        NameC.Checked = True
                        NameMin.Value = CDec(ConnStr.Fields("Valu").Value)
                    ElseIf ConnStr.Fields("ID").Value = "NameMin" And (ConnStr.Fields("Valu").Value.ToString = "False" Or ConnStr.Fields("Valu").Value.ToString = "0") Then
                        NameC.Checked = False
                    End If
                    If ConnStr.Fields("ID").Value = "Password" Then
                        TextBox6.Text = ConnStr.Fields("Valu").Value.ToString
                    End If
                    If ConnStr.Fields("ID").Value = "Timer" And Not (ConnStr.Fields("Valu").Value = "False") And TimerI = 0 Then
                        Dim S() As String = ConnStr.Fields("Valu").Value.ToString.Split(":")
                        Hou.Value = CDec(S(0))
                        Min.Value = CDec(S(1))
                        Sec.Value = CDec(S(2))
                        Timer.Checked = True
                        Hou.Enabled = True
                        Min.Enabled = True
                        Sec.Enabled = True
                        TimerI = 1
                    ElseIf TimerI = 0 And ConnStr.Fields("ID").Value = "Timer" Then
                        Timer.Checked = False
                        TimerI = 1
                    End If
                    ConnStr.MoveNext()
                    counter += 1
                Catch ex As Exception
                    If ex.Message <> "Either BOF or EOF is True, or the current record has been deleted. Requested operation requires a current record." Then
                        MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                    Else
                        Exit For
                    End If
                End Try
            Next
            TextBox4.Text = My.Application.Info.DirectoryPath & "\Savings.mdb"
        ElseIf System.IO.File.Exists("C:\Windows\Temp\Savings.mdb") Then
            Conn.Open("Provider= Microsoft.Jet.OLEDB.4.0;Data Source =" & "C:\Windows\Temp\Savings.mdb")
            ConnStr.Open("Savings", Conn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
            ConnStrI = 1
            ConnStr.MoveFirst()
            For counter = 1 To 30
                Try
                    If ConnStr.Fields("ID").Value = "Select" And Not (ConnStr.Fields("Valu").Value = "False") And SelectI = 0 Then
                        TextBox1.Text = ConnStr.Fields("Valu").Value.ToString
                        SelectT.Text = ConnStr.Fields("TableN").Value.ToString
                        If Not (ConnStr.Fields("Password").Value.ToString = "") Then
                            SelectP.Text = ConnStr.Fields("Password").Value.ToString
                            SelectPC.Checked = True
                        End If
                        SelectC.Checked = True
                        SelectI = 1
                    ElseIf SelectI = 0 And ConnStr.Fields("ID").Value = "Select" Then
                        SelectC.Checked = False
                        SelectI = 1
                    End If
                    If ConnStr.Fields("ID").Value = "Complete" And Not (ConnStr.Fields("Valu").Value = "False") And CompleteI = 0 Then
                        TextBox2.Text = ConnStr.Fields("Valu").Value.ToString
                        CompleteT.Text = ConnStr.Fields("TableN").Value.ToString
                        If Not (ConnStr.Fields("Password").Value.ToString = "") Then
                            CompleteP.Text = ConnStr.Fields("Password").Value.ToString
                            CompletePC.Checked = True
                        End If
                        CompleteC.Checked = True
                        CompleteI = 1
                    ElseIf CompleteI = 0 And ConnStr.Fields("ID").Value = "Complete" Then
                        CompleteC.Checked = False
                        CompleteI = 1
                    End If
                    If ConnStr.Fields("ID").Value = "Join" And Not (ConnStr.Fields("Valu").Value = "False") And JoinI = 0 Then
                        TextBox3.Text = ConnStr.Fields("Valu").Value.ToString
                        JoinT.Text = ConnStr.Fields("TableN").Value.ToString
                        If Not (ConnStr.Fields("Password").Value.ToString = "") Then
                            JoinP.Text = ConnStr.Fields("Password").Value.ToString
                            JoinPC.Checked = True
                        End If
                        JoinC.Checked = True
                        JoinI = 1
                    ElseIf JoinI = 0 And ConnStr.Fields("ID").Value = "Join" Then
                        JoinC.Checked = False
                        JoinI = 1
                    End If
                    If ConnStr.Fields("ID").Value = "Save" And Not (ConnStr.Fields("Valu").Value = "False") And SaveI = 0 Then
                        TextBox5.Text = ConnStr.Fields("Valu").Value.ToString
                        Savings2T.Text = ConnStr.Fields("TableN").Value.ToString
                        If Not (ConnStr.Fields("Password").Value.ToString = "") Then
                            Savings2P.Text = ConnStr.Fields("Password").Value.ToString
                            Savings2PC.Checked = True
                        End If
                        Savings2C.Checked = True
                        SaveI = 1
                    ElseIf SaveI = 0 And ConnStr.Fields("ID").Value = "Save" Then
                        Savings2C.Checked = False
                        SaveI = 1
                    End If
                    If ConnStr.Fields("ID").Value = "ASS" Then
                        ASST.Text = ConnStr.Fields("Valu").Value.ToString
                    End If
                    If ConnStr.Fields("ID").Value = "FeedC" Then
                        FeedC.Checked = CBool(ConnStr.Fields("Valu").Value.ToString)
                    End If
                    If ConnStr.Fields("ID").Value = "NameMax" And Not (ConnStr.Fields("Valu").Value.ToString = "False") Then
                        NameC.Checked = True
                        NameMax.Value = CDec(ConnStr.Fields("Valu").Value)
                    ElseIf ConnStr.Fields("ID").Value = "NameMax" And ConnStr.Fields("Valu").Value.ToString = "False" Then
                        NameC.Checked = False
                    End If
                    If ConnStr.Fields("ID").Value = "NameMin" And Not (ConnStr.Fields("Valu").Value.ToString = "False") Then
                        NameC.Checked = True
                        NameMin.Value = CDec(ConnStr.Fields("Valu").Value)
                    ElseIf ConnStr.Fields("ID").Value = "NameMin" And ConnStr.Fields("Valu").Value.ToString = "False" Then
                        NameC.Checked = False
                    End If
                    If ConnStr.Fields("ID").Value = "Password" Then
                        TextBox6.Text = ConnStr.Fields("Valu").Value.ToString
                    End If
                    If ConnStr.Fields("ID").Value = "Timer" And Not (ConnStr.Fields("Valu").Value = "False") And TimerI = 0 Then
                        Dim S() As String = ConnStr.Fields("Valu").Value.ToString.Split(":")
                        Hou.Value = CDec(S(0))
                        Min.Value = CDec(S(1))
                        Sec.Value = CDec(S(2))
                        Timer.Checked = True
                        Hou.Enabled = True
                        Min.Enabled = True
                        Sec.Enabled = True
                        TimerI = 1
                    ElseIf TimerI = 0 And ConnStr.Fields("ID").Value = "Timer" Then
                        Timer.Checked = False
                        TimerI = 1
                    End If
                    ConnStr.MoveNext()
                    counter += 1
                Catch ex As Exception
                    If ex.Message <> "Either BOF or EOF is True, or the current record has been deleted. Requested operation requires a current record." Then
                        MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                    Else
                        Exit For
                    End If
                End Try
            Next
            TextBox4.Text = "C:\Windows\Temp\Savings.mdb"
        End If

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        SelectQ.TextBox1.Text = "Data Source= " & sender.text
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Leave
        CompleteQ.TextBox2.Text = "Data Source= " & sender.text
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Leave
        JoinQ.TextBox1.Text = "Data Source= " & sender.text
    End Sub

    Private Sub SelectC_CheckedChanged(sender As Object, e As EventArgs) Handles SelectC.CheckedChanged
        If sender.checked Then
            TextBox1.Enabled = True
            SelectT.Enabled = True
            Button5.Enabled = True
            SelectPC.Enabled = True
        Else
            TextBox1.Enabled = False
            SelectT.Enabled = False
            Button5.Enabled = False
            SelectPC.Enabled = False
            SelectP.Enabled = False
        End If
    End Sub

    Private Sub CompleteC_CheckedChanged(sender As Object, e As EventArgs) Handles CompleteC.CheckedChanged
        If sender.checked Then
            TextBox2.Enabled = True
            CompleteT.Enabled = True
            Button6.Enabled = True
            CompletePC.Enabled = True
        Else
            TextBox2.Enabled = False
            CompleteT.Enabled = False
            Button6.Enabled = False
            CompletePC.Enabled = False
            CompleteP.Enabled = False
        End If
    End Sub

    Private Sub joinc_CheckedChanged(sender As Object, e As EventArgs) Handles JoinC.CheckedChanged
        If sender.checked Then
            TextBox3.Enabled = True
            JoinT.Enabled = True
            Button7.Enabled = True
            JoinPC.Enabled = True
        Else
            TextBox3.Enabled = False
            JoinT.Enabled = False
            Button7.Enabled = False
            JoinPC.Enabled = False
            JoinP.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles SelectPC.CheckedChanged, SelectPC.EnabledChanged
        If sender.checked Then
            SelectP.Enabled = True
        Else
            SelectP.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CompletePC.CheckedChanged, CompletePC.EnabledChanged
        If sender.checked Then
            CompleteP.Enabled = True
        Else
            CompleteP.Enabled = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles JoinPC.CheckedChanged, JoinPC.EnabledChanged
        If sender.checked Then
            JoinP.Enabled = True
        Else
            JoinP.Enabled = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles Savings2PC.CheckedChanged
        If sender.checked Then
            Savings2P.Enabled = True
        Else
            Savings2P.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If Not (c) Then
            sender.checked = True
            c = True
        Else
            If MsgBox("سيؤدي عدم تهيئة قاعدة البيانات إلى فقدان بعض البيانات بها وقد تحدث بعض الأخطاء." & vbCrLf & "هل تريد المتابعة؟", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxRight) = MsgBoxResult.Yes Then
                If Password.ShowDialog = DialogResult.Yes Then
                    sender.checked = False
                    c = False
                Else
                    sender.checked = True
                    c = True
                End If
            Else
                sender.checked = True
                c = True
            End If
        End If
    End Sub

    Private Sub ShowP_MouseDown(sender As Object, e As MouseEventArgs) Handles ShowP.MouseDown
        TextBox6.PasswordChar = ""
    End Sub

    Private Sub ShowP_MouseUp(sender As Object, e As MouseEventArgs) Handles ShowP.MouseUp
        TextBox6.PasswordChar = "⚫"
    End Sub

    Private Sub Timer_CheckedChanged(sender As Object, e As EventArgs) Handles Timer.CheckedChanged
        If sender.checked = True Then
            Hou.Enabled = True
            Min.Enabled = True
            Sec.Enabled = True
        Else
            Hou.Enabled = False
            Min.Enabled = False
            Sec.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ASS.ShowDialog = DialogResult.OK Then
            ASST.Text = ASS.SelectedPath
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If sender.checked = False Then
            b = False
            Panel1.Enabled = True
            TextBox4.Enabled = False
            Button8.Enabled = False
            CheckBox2.Enabled = False
        Else
            b = True
            Panel1.Enabled = False
            TextBox4.Enabled = True
            Button8.Enabled = True
            CheckBox2.Enabled = True
        End If
    End Sub
    Public dev As Boolean = False
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        dev = True
    End Sub

    Private Sub Savings2C_CheckedChanged(sender As Object, e As EventArgs) Handles Savings2C.CheckedChanged
        If sender.checked Then
            TextBox5.Enabled = True
            Savings2T.Enabled = True
            Button11.Enabled = True
            Savings2PC.Enabled = True
        Else
            TextBox5.Enabled = False
            Savings2T.Enabled = False
            Button11.Enabled = False
            Savings2PC.Enabled = False
            Savings2P.Enabled = False
        End If
    End Sub

    Private Sub ASSC_CheckedChanged(sender As Object, e As EventArgs) Handles ASSC.CheckedChanged
        If sender.checked Then
            ASST.Enabled = True
            Button1.Enabled = True
        Else
            ASST.Enabled = False
            Button1.Enabled = False
        End If
    End Sub

    Private Sub NameC_CheckedChanged(sender As Object, e As EventArgs) Handles NameC.CheckedChanged
        If sender.checked Then
            NameMax.Enabled = True
            NameMin.Enabled = True
        Else
            NameMax.Enabled = False
            NameMin.Enabled = False
        End If
    End Sub

    Private Sub Min_ValueChanged(sender As Object, e As EventArgs) Handles Min.ValueChanged, Hou.ValueChanged
        If Min.Value = 0 And Hou.Value = 0 Then
            Sec.Minimum = 1
        Else
            Sec.Minimum = 0
        End If
    End Sub

    Private Sub NameMin_ValueChanged(sender As Object, e As EventArgs) Handles NameMin.ValueChanged
        NameMax.Minimum = NameMin.Value + 1
    End Sub

    Private Sub NameMax_ValueChanged(sender As Object, e As EventArgs) Handles NameMax.ValueChanged
        NameMin.Maximum = NameMax.Value - 1
    End Sub
End Class