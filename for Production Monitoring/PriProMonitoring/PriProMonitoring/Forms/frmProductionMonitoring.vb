Public Class frmProductionMonitoring
    Dim magazine As Hashtable
  
    Private Sub frmProductionMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadMagazine()
    End Sub

    Private Sub LoadMagazine()
        Dim mySql As String = "SELECT * FROM tblmagazine"
        Dim ds As DataSet = LoadSQL(mySql)

        magazine = New Hashtable
        cboMagazine.Items.Clear()
        Dim tmpmagazine As String, tmpID As Integer

        '  cboMagazine.Items.Add("Select Magazine")
        cboMagazine.SelectedText = ("Select Magazine")
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                tmpID = .Item("Mag_ID")
                tmpmagazine = .Item("MagDescription")
            End With
            magazine.Add(tmpID, tmpmagazine)
            cboMagazine.Items.Add(tmpmagazine)
        Next

    End Sub
End Class