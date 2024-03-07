Public Class Result
    Private Sub Result_Load(sender As Object, e As EventArgs) Handles Me.Load
        Main.Show()
        If TimerL.Text = "24:60:60" Then
            TimerL.Text = "__"
        End If
    End Sub

    Private Sub Result_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        If e.KeyValue = 27 Then
            Close()
        End If
    End Sub
End Class