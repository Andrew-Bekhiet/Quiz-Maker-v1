Public Class Password
    Dim c As Integer = 0
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not (TextBox1.Text = Databasesselecter.TextBox6.Text) Then
            MsgBox("كلمة السر خاطئة!", MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.Critical)
            Button1.DialogResult = DialogResult.No
        End If
        TextBox1.Text = ""
    End Sub

    Private Sub ShowP_MouseDown(sender As Object, e As MouseEventArgs) Handles ShowP.MouseDown
        TextBox1.PasswordChar = ""
    End Sub

    Private Sub ShowP_MouseUp(sender As Object, e As MouseEventArgs) Handles ShowP.MouseUp
        TextBox1.PasswordChar = "⚫"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = Databasesselecter.TextBox6.Text Then
            Button1.DialogResult = DialogResult.Yes
        Else
            Button1.DialogResult = DialogResult.No
        End If
    End Sub

    Private Sub Password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.UseSystemPasswordChar = True
    End Sub
End Class