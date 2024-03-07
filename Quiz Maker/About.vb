Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = My.Application.Info.AssemblyName
        Label4.Text = My.Application.Info.CompanyName
        Label3.Text = My.Application.Info.Copyright
        Label2.Text = My.Application.Info.Version.ToString
    End Sub
End Class