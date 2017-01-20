Public Class frmSeed

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtpath.Text = "" Then Exit Sub

        database.dbName = txtpath.Text
        SalesSeed.Populate()
        MsgBox("Sales Loaded . . .", MsgBoxStyle.Information)
    End Sub

    Private Sub frmSeed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        database.dbName = txtpath.Text
        If txtpath.Text = "" Then Exit Sub
        SalesSeed.AddpaperRolls()
        MsgBox("Paper roll added . . .", MsgBoxStyle.Information)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpenFileDialog1.ShowDialog()
        txtpath.Text = OpenFileDialog1.FileName
    End Sub
End Class