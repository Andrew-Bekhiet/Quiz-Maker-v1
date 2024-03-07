Public Class closeopen
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim hou As Integer = JoinQ.Hou.Value
        Dim min As Integer = JoinQ.Min.Value
        Dim sec As Integer = JoinQ.Sec.Value
        Dim pro As Integer = JoinQ.ProgressBar.Value
        JoinQ.deleteall = True
        calcd = False
        JoinQ.Close()
        JoinQ.Show()
        JoinQ.Hou.Value = hou
        JoinQ.Min.Value = min
        JoinQ.Sec.Value = sec
        JoinQ.ProgressBar.Value = pro
    End Sub
End Class
