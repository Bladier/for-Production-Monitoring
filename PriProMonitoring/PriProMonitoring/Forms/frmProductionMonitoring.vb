Public Class frmProductionMonitoring
    Const meter As Double = 0.0254
    Dim ds As New DataSet
    Dim SelectedPaPRoll As PaperRoll
    Dim saveSales As production

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If lvpapercuts.Items.Count <= 0 Then Exit Sub
        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        For Each item As ListViewItem In lvpapercuts.Items

            Dim MYSQLSALES As String = "SELECT * FROM POSITEM WHERE PAPCUT_ITEMCODE '" & item.SubItems(5).Text & "' """
            Dim DSSLES As DataSet = LoadSQLPOS(MYSQLSALES, "TBLPOSITEM")
            For Each drSales As DataRow In DSSLES.Tables(0).Rows
                saveSales = New production
                With saveSales

                End With
            Next

            Dim mysql As String = "SELECT * FROM TBLPRODUCTION WHERE ITEMCODE = '" & item.SubItems(6).Text & "'"
            ds = LoadSQL(mysql, "tblProduction")

            Dim SubTotal As Double = (ds.Tables(0).Rows(0).Item(5) * item.SubItems(5).Text)

            For Each dr As DataRow In ds.Tables(0).Rows

                dr.Item("MAG_ID") = item.SubItems(1).Text
                dr("Paproll_SERIAL") = item.SubItems(2).Text
                dr.Item("Papercut") = item.SubItems(5).Text
                dr.Item("Papcut_Description") = item.SubItems(7).Text
                dr.Item("SubTotal_Length") = SubTotal
                database.SaveEntry(ds, False)


                SelectedPaPRoll = New PaperRoll
                SelectedPaPRoll.TotalLength = SubTotal * meter
                SelectedPaPRoll.Updatepaper()
            Next
        Next
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmMagAndPapRollList.txtSearch.Text = txtSEarch.Text
        frmMagAndPapRollList.Show()
        Me.Close()
    End Sub

    Private Sub txtSEarch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSEarch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtmagazine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmagazine.TextChanged
        LOADACTIVEMAGAZINE()
    End Sub

    Private Sub LOADACTIVEMAGAZINE()
        Dim mysql As String = "SELECT * FROM papercut"

        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERCUT")

        lvpapercuts.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvpapercuts.Items.Add(dr(0))
            lv.SubItems.Add(dr(1))
            lv.SubItems.Add(dr(2))
            lv.SubItems.Add(dr(3))
            lv.SubItems.Add(dr(4))
            lv.SubItems.Add(dr(5))
            lv.SubItems.Add(dr(6))
            lv.SubItems.Add(dr(7))
        Next

        Dim TOTAL_LENGTH As Double = ds.Tables(0).Rows(0).Item("TOTAL_LENGTH")
        Dim SERIAL As String = ds.Tables(0).Rows(0).Item("PAPROLL_SERIAL")

        ToolRemaining.Text = SERIAL & " : " & TOTAL_LENGTH
    End Sub

    Private Sub frmProductionMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtmagazine.Text = GetMag()

    End Sub

    Private Function GetMag() As String
        Dim mysql As String = " SELECT * FROM TBLMAGAZINE M INNER JOIN TBLPAPERROLL P ON M.MAG_ID=P.MAG_IDS" _
                              & " WHERE STATUS <> 0 "
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERCUT")
        Return ds.Tables(0).Rows(0).Item("MAGDESCRIPTION")
    End Function

End Class