Public Class frmItem

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmMagazineList.SearchSelect(txtSearch.Text, FormName.frmmagazine)
        frmMagazineList.Show()
    End Sub
End Class