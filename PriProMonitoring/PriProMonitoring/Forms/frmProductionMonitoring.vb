Public Class frmProductionMonitoring

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmMagAndPapRollList.txtSearch.Text = txtSEarch.Text
        frmMagAndPapRollList.Show()
    End Sub
End Class