Public Class Feedback
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sender.enabled = False
        SendFeedback.RunWorkerAsync()
    End Sub

    Private Sub ShowP_MouseDown(sender As Object, e As MouseEventArgs) Handles ShowP.MouseDown
        TextBox2.PasswordChar = ""
    End Sub

    Private Sub ShowP_MouseUp(sender As Object, e As MouseEventArgs) Handles ShowP.MouseUp
        TextBox2.PasswordChar = "⚫"
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If sender.checked = True Then
            TextBox4.Enabled = True
        Else
            TextBox4.Enabled = False
        End If
    End Sub

    Private Sub SendFeedback_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles SendFeedback.DoWork
        If TextBox1.Text = "" Then
            MsgBox("يجب تسجيل الدخول بحساب مايكروسوفت", MsgBoxStyle.Information)
            Exit Sub
            Button1.Enabled = True
        ElseIf TextBox2.Text = "" Then
            MsgBox("يجب كتابة كلمة سر الحساب", MsgBoxStyle.Information)
            Exit Sub
            Button1.Enabled = True
        ElseIf TextBox3.Text = "" Then
            MsgBox("ييلزم كتابة جسم الرسالة", MsgBoxStyle.Information)
            Exit Sub
            Button1.Enabled = True
        ElseIf TextBox4.Text = "" And CheckBox1.Checked = True Then
            MsgBox("يجب كتابة الموضوع (إقتراح - خطأ - ملاحظة - ...)", MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxRight)
            Exit Sub
            Button1.Enabled = True
        End If
        Try
            Dim Smtp_Server As New Net.Mail.SmtpClient
            Dim e_mail As New Net.Mail.MailMessage()
            Smtp_Server.UseDefaultCredentials = True
            Smtp_Server.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.live.com"
            e_mail = New Net.Mail.MailMessage()
            e_mail.From = New Net.Mail.MailAddress(TextBox1.Text)
            e_mail.To.Add("Andrewbekhiet@gmail.com")
            If CheckBox1.Checked = False Then
                e_mail.Subject = "Feedback"
            Else
                e_mail.Subject = TextBox4.Text
            End If
            e_mail.IsBodyHtml = False
            e_mail.Body = TextBox3.Text
            Smtp_Server.Send(e_mail)
            e_mail.Dispose()
            MsgBox("تم الإرسال بنجاح", MsgBoxStyle.MsgBoxRight Or 0 Or MsgBoxStyle.Information)
        Catch ex As Exception
            If ex.Message = "The specified string is not in the form required for an e-mail address." Then
                MsgBox("الحساب غير موجود" & vbCrLf & "يرجى استخدام حساب صحيح.",, MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxRight)
            ElseIf ex.Message = "Mailbox unavailable. The server response was: 5.7.3 Requested action aborted; user not authenticated" Then
                MsgBox("الحساب أو كلمة سر خاطئ " & vbCrLf & "يرجى استخدام حساب مايكروسوفت أو كتابة كلمة سر صحيحة", MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxRight)
            ElseIf ex.Message = "Failure sending mail." Then
                MsgBox("حدث خطأ أثناء الإرسال." & vbCrLf & "يرجى التحقق من الاتصال بالانترنت.", MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.Exclamation)
            ElseIf Databasesselecter.dev Then
                MsgBox(ex.Message)
            End If
        End Try
        Button1.Enabled = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://goo.gl/forms/S1KawgNzqIpmLdQv2")
    End Sub

    Private Sub Feedback_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        If e.KeyValue = 27 Then
            Close()
        End If
    End Sub
End Class