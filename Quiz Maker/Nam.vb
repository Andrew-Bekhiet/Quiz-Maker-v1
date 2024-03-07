Public Class Nam
    Public Eror As Boolean = False
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
        Main.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Databasesselecter.SelectC.Checked = False And Databasesselecter.CompleteC.Checked = False And Databasesselecter.JoinC.Checked = False Then
            MsgBox("لا يوجد اختبار لاظهاره!", 0 Or 48 Or MsgBoxStyle.MsgBoxRight)
            Exit Sub
        End If
        If TextBox1.Text = "" Then
            MsgBox("من فضلك ادخل اسمك", 0 Or MsgBoxStyle.MsgBoxRight)
        ElseIf TextBox1.Text.Length <= databasesselecter.NameMin.Value And Databasesselecter.NameC.Checked = True Then
            MsgBox("يرجى كتابة الإسم ثلاثي", 0 Or MsgBoxStyle.MsgBoxRight)
        Else
            Try
                If Not (Eror) Then
                    Databasesselecter.Nam2.Text = TextBox1.Text
                    If Eror Then
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
                If Databasesselecter.ASSC.Checked = True Then
                    Dim cat As ADOX.Catalog = New ADOX.Catalog()
                    cat.Create("Provider = Microsoft.Jet.OLEDB.4.0;Data Source = " & Databasesselecter.ASST.Text & "\" & Databasesselecter.Nam2.Text & ".mdb" & ";Jet OLEDB:Engine Type = 5")
                    cat = Nothing
                    Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & Databasesselecter.ASST.Text & "\" & Databasesselecter.Nam2.Text & ".mdb")
                    con.Open()
                    Dim dbSchema As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Databasesselecter.ASST.Text & "\" & Databasesselecter.Nam2.Text, "TABLE"})
                    con.Close()
                    Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" + "ASS" + "] ([Q] TEXT, [A] TEXT, [D] TEXT, [TF] TEXT)", con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    If con.State = 1 Then
                        con.Close()
                    End If
                Else
                    Dim cat As ADOX.Catalog = New ADOX.Catalog()
                    cat.Create("Provider = Microsoft.Jet.OLEDB.4.0;Data Source = " & My.Application.Info.DirectoryPath & "\" & Databasesselecter.Nam2.Text & ".mdb" & ";Jet OLEDB:Engine Type = 5")
                    cat = Nothing
                    Dim con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source =" & My.Application.Info.DirectoryPath & "\" & Databasesselecter.Nam2.Text & ".mdb")
                    con.Open()
                    Dim dbSchema As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Databasesselecter.ASST.Text & "\" & Databasesselecter.Nam2.Text, "TABLE"})
                    con.Close()
                    Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" + "ASS" + "] ([Q] TEXT, [A] TEXT, [D] TEXT, [TF] TEXT)", con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    If con.State = 1 Then
                        con.Close()
                    End If
                End If
            Catch ex As Exception
                If Databasesselecter.dev Then
                    MsgBox("حدث خطأ أثناء تحمبل الإختبار" & vbCrLf & ex.Message, 16 Or 0 Or MsgBoxStyle.MsgBoxRight)
                Else
                    MsgBox("حدث خطأ أثناء تحمبل الإختبار", 16 Or 0 Or MsgBoxStyle.MsgBoxRight)
                End If
                Exit Sub
            End Try
            Databasesselecter.Nam2.Text = TextBox1.Text
            Close()
            Try
                If Databasesselecter.SelectC.Checked = False And Databasesselecter.CompleteC.Checked = False Then
                    JoinQ.Show()
                ElseIf Databasesselecter.SelectC.Checked = False Then
                    CompleteQ.Show()
                Else
                    SelectQ.Show()
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub Nam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Databasesselecter.NameC.Checked = True Then
            TextBox1.MaxLength = Databasesselecter.NameMax.Value
        End If
    End Sub
End Class