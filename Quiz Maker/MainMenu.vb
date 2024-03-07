Imports Microsoft.Win32
Imports System.Net
Imports Quiz_Maker.Databasesselecter
Public Class Main
    Dim MBR As String
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Not (Databasesselecter.Visible = True) Then
            CloseC()
            Me.Close()
        Else
            If MsgBox("الخروج بهذا الشكل يؤدي إلى فقدان البيانات." & vbCrLf & "هل تريد المتابعة؟", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo Or MsgBoxStyle.MsgBoxRight, "خروج غير آمن") = 6 Then
                CloseC()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Nam.Show()
        Hide()
    End Sub

    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If System.IO.File.Exists("C:\Windows\Temp\Savings.mdb") Or IO.File.Exists(My.Application.Info.DirectoryPath & "\Savings.mdb") Then
            If Password.ShowDialog() = DialogResult.Yes Then
                Databasesselecter.Show()
            End If
        Else
            Databasesselecter.Show()
        End If
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Databasesselecter.Show()
        Databasesselecter.Hide()
        If System.IO.File.Exists("C:\Windows\Temp\Savings.mdb") Or IO.File.Exists(My.Application.Info.DirectoryPath & "\Savings.mdb") Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        About.Show()
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        CloseC()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (System.IO.File.Exists("C:\Windows\Temp\Savings.mdb") Or IO.File.Exists(My.Application.Info.DirectoryPath & "\Savings.mdb")) And Databasesselecter.FeedC.Checked = True Then
            If Password.ShowDialog() = DialogResult.Yes Then
                Feedback.Show()
            End If
        Else
            Feedback.Show()
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        sender.enabled = False
        CheckUpdates.RunWorkerAsync()
    End Sub

    Private Sub Main_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        With Databasesselecter
            If (((((.TextBox1.Enabled = True Or .TextBox1.Text <> "" Or .SelectT.Text <> "" Or ((.SelectP.Text <> "" Or .SelectP.Enabled = True) Or .SelectPC.Checked = False)) Or .TextBox1.Enabled = False)) _
            Or (((.TextBox2.Enabled = True Or .TextBox2.Text <> "" Or .CompleteT.Text <> "" Or ((.CompleteP.Text <> "" Or .CompleteP.Enabled = True) Or .CompletePC.Checked = False)) Or .TextBox2.Enabled = False)) _
            Or (((.TextBox3.Enabled = True Or .TextBox3.Text <> "" Or .JoinT.Text <> "" Or ((.JoinP.Text <> "" Or .JoinP.Enabled = True) Or .JoinPC.Checked = False)) Or .TextBox3.Enabled = False))) _
            Or (((.TextBox5.Enabled = True Or .TextBox5.Text <> "" Or .Savings2T.Text <> "" Or ((.Savings2P.Text <> "" Or .Savings2P.Enabled = True) Or .Savings2PC.Checked = False)) Or .TextBox5.Enabled = False)) _
            Or (((.ASST.Enabled = True Or .ASST.Text <> "") Or .ASSC.Checked = False)) _
            Or (.TextBox6.Text <> "") _
            Or ((((.Hou.Enabled = True Or .Hou.Value <> 0) Or (.Min.Enabled = True Or .Min.Value <> 0) Or (.Sec.Enabled = True Or .Sec.Value <> 0) Or .Timer.Checked = True) Or .Hou.Value = 1 Or .Timer.Checked = True) Or .Timer.Checked = False)) Then
                If (((((.TextBox1.Enabled = True And .TextBox1.Text <> "" And .SelectT.Text <> "" And ((.SelectP.Text <> "" And .SelectP.Enabled = True) And .SelectPC.Checked = False)) And .TextBox1.Enabled = False)) _
            And (((.TextBox2.Enabled = True And .TextBox2.Text <> "" And .CompleteT.Text <> "" And ((.CompleteP.Text <> "" And .CompleteP.Enabled = True) And .CompletePC.Checked = False)) And .TextBox2.Enabled = False)) _
            And (((.TextBox3.Enabled = True And .TextBox3.Text <> "" And .JoinT.Text <> "" And ((.JoinP.Text <> "" And .JoinP.Enabled = True) And .JoinPC.Checked = False)) And .TextBox3.Enabled = False))) _
            And (((.TextBox5.Enabled = True And .TextBox5.Text <> "" And .Savings2T.Text <> "" And ((.Savings2P.Text <> "" And .Savings2P.Enabled = True) And .Savings2PC.Checked = False)) And .TextBox5.Enabled = False)) _
            And (((.ASST.Enabled = True And .ASST.Text <> "") And .ASSC.Checked = False)) _
            And (.TextBox6.Text <> "") _
            And ((((.Hou.Enabled = True And .Hou.Value <> 0) And (.Min.Enabled = True And .Min.Value <> 0) And (.Sec.Enabled = True And .Sec.Value <> 0) And .Timer.Checked = True) And .Hou.Value = 1 And .Timer.Checked = True) And .Timer.Checked = False)) Then
                    Button2.Image = My.Resources.Resources.images2
                Else
                    Button2.Image = Quiz_Maker.My.Resources.Resources.eror2
                End If
            Else
                Button2.Image = My.Resources.Resources.errorr
            End If
        End With
    End Sub
    Private Sub CheckUpdates_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CheckUpdates.DoWork
        Try
            Dim request As System.Net.HttpWebRequest = DirectCast(System.Net.HttpWebRequest.Create("https://pastebin.com/raw/8Ew16ZaF"), Net.HttpWebRequest)
            Dim response As System.Net.HttpWebResponse = DirectCast(request.GetResponse(), Net.HttpWebResponse)
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadLine()
            Dim currentversion As String = Application.ProductVersion
            If newestversion = currentversion Then
                MsgBox("مبروك!لديك أخر إصدار!", MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.MsgBoxRtlReading Or MsgBoxStyle.Information)
            Else
                If MsgBox("يوجد إصدار جديد!" & vbCrLf & "هل تريد تنزيله؟" & vbCrLf & "الحالي: " & currentversion & vbCrLf & "الجديد: " & newestversion & vbCrLf, MsgBoxStyle.MsgBoxRtlReading Or MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If IO.File.Exists(My.Application.Info.DirectoryPath & "\Setup.rar") Then
                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Setup.rar")
                    End If
                    My.Computer.Network.DownloadFile("https://doc-0o-3s-docs.googleusercontent.com/docs/securesc/ha0ro937gcuc7l7deffksulhg5h7mbp1/6ebhlpric3j28kc7d7naca7v00re7taj/1505836800000/02146829044407215563/*/0B0P3OvPJuzyKcFRyVk5XYlZxdG8?e=download", My.Application.Info.DirectoryPath & "\Setup.rar")
                    MsgBox("تم تنزيل التحديث بنجاح!", MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.MsgBoxRtlReading)
                    MsgBox("برجاء فك الضغط عن التحديث لتثبيته", MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.MsgBoxRtlReading Or MsgBoxStyle.Information)
                    Process.Start(Directory & "\Setup.rar")
                End If
            End If
        Catch ex As System.Net.WebException
            MsgBox("حدث خطأ أثناء المحاولة." & vbCrLf & "يرجى التحقق من الإتصال بالإنترنت.", MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.MsgBoxRtlReading)
        End Try
    End Sub
End Class
