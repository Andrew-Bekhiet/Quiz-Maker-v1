Module Subs
    Public Directory As String = My.Application.Info.DirectoryPath
    Public calcd As Boolean = True
    Public Final As Single = 0
    Public Sub Redraw(ByRef sender As Object)
        sender.close()
        sender.show()
    End Sub
    Public Sub CloseC()
        Try
            If Databasesselecter.ConnStr.State = 1 Then
                Databasesselecter.ConnStr.UpdateBatch()
                Databasesselecter.ConnStr.Close()
                Databasesselecter.Conn.Close()
            End If
            If Databasesselecter.ConnStr2.State = 1 Then
                Databasesselecter.ConnStr2.UpdateBatch()
                Databasesselecter.ConnStr2.Close()
                Databasesselecter.Conn2.Close()
            End If
        Catch
        End Try
    End Sub
    Public Sub Final_update(ByVal Final2 As Single)
        Final += Final2
    End Sub
    Public Sub Degree_Update(ByVal I As Single, ByVal Tim As Integer, Optional ByVal Mark As Single = 0, Optional ByVal Timer As String = "__")
        Select Case Tim
            Case Is = 1
                If Databasesselecter.Savings2C.Checked = True Or True Then
                    Databasesselecter.ConnStr2.Fields("Value1").Value = I
                    Databasesselecter.ConnStr2.Update()
                End If
                Result.Q1.Text = I
                Result.Nam.Text = Databasesselecter.Nam2.Text
                If (Not (Databasesselecter.JoinC.Checked) And Not (Databasesselecter.CompleteC.Checked)) Or (Timer = "00:00:00") Then
                    GoTo MarkedS
                End If
            Case Is = 2
                Databasesselecter.ConnStr2.Fields("Value2").Value = I
                Databasesselecter.ConnStr2.Update()
                Result.Q2.Text = I
                Result.Nam.Text = Databasesselecter.Nam2.Text
                Debug.WriteLine(CompleteQ.Sec.Value)
                If (Not (Databasesselecter.JoinC.Checked)) Or (Databasesselecter.Timer.Checked = True And CompleteQ.Hou.Value = 0 And CompleteQ.Min.Value = 0 And CompleteQ.Sec.Value = 0) Then
                    GoTo MarkedS
                End If
            Case Is = 3
                Debug.WriteLine(Result.TimerL.Text)
                Databasesselecter.ConnStr2.Fields("Value3").Value = I
                Result.Q3.Text = I
                Result.Nam.Text = Databasesselecter.Nam2.Text
MarkedS:
                Debug.WriteLine(Result.TimerL.Text)
                With Databasesselecter.ConnStr2
                    .Fields("Total").Value = Databasesselecter.ConnStr2.Fields("Value3").Value + Databasesselecter.ConnStr2.Fields("Value2").Value + Databasesselecter.ConnStr2.Fields("Value1").Value
                    Result.Sum.Text = .Fields("Total").Value.ToString
                    .Fields("Final").Value = Final
                    Result.Final.Text = Final
                    Result.Percent.Text = ((.Fields("Total").Value / .Fields("Final").Value) * 100) & "%"
                    .Fields("Percent").Value = (.Fields("Total").Value / .Fields("Final").Value) * 100
                    Result.SFinal.Text = Final / 2
                    Databasesselecter.ConnStr2.Fields("Timer").Value = Timer
                    Result.TimerL.Text = Timer
                    If .Fields("Percent").Value > 85 Then
                        .Fields("Valuation").Value = "ممتاز"
                        Result.Valuation.Text = "ممتاز"
                        .Fields("Success").Value = True
                        Result.Success.Text = "ناجح"
                    ElseIf .Fields("Percent").Value > 75 Then
                        .Fields("Valuation").Value = "جيد جدًا"
                        Result.Valuation.Text = "جيد جدًا"
                        .Fields("Success").Value = True
                        Result.Success.Text = "ناجح"
                    ElseIf .Fields("Percent").Value > 65 Then
                        .Fields("Valuation").Value = "جيد"
                        Result.Valuation.Text = "جيد"
                        .Fields("Success").Value = True
                        Result.Success.Text = "ناجح"
                    ElseIf .Fields("Percent").Value >= 50 Then
                        .Fields("Valuation").Value = "مقبول"
                        Result.Valuation.Text = "مقبول"
                        .Fields("Success").Value = True
                        Result.Success.Text = "ناجح"
                    Else
                        .Fields("Valuation").Value = "راسب"
                        Result.Valuation.Text = "فاشل"
                        .Fields("Success").Value = False
                        Result.Success.Text = "فاشل"
                    End If
                    .Update()
                    Final = 0
                    Result.Show()
                    SelectQ.Close()
                    CompleteQ.Close()
                    JoinQ.Close()
                End With
            Case Is = 4
                If Databasesselecter.Savings2C.Checked = True Then
                    Databasesselecter.ConnStr2.Fields("Timer").Value = Timer
                End If
                Result.TimerL.Text = Timer
        End Select

    End Sub
End Module
