Public Class frmSeed

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SalesSeed.Populate()
        MsgBox("Sales Loaded . . .", MsgBoxStyle.Information)
    End Sub

    Private Sub frmSeed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class