Public Class frmProductionMonitoring
    Const meter As Double = 0.0254 '1 inch = 0.0254 meter
    Dim ds As New DataSet
    Dim SelectedPaPRoll As PaperRoll
    Dim saveSales As production

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

    Private Sub tpProgressBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpProgressBar.Click

    End Sub


    Private Sub btnProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProduction.Click
        Dim mysql As String = "SELECT * FROM TBLPRO WHERE STATUS = '0'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPRO")
        Console.WriteLine("TBLPRO count: " & ds.Tables(0).Rows.Count)

        If ds.Tables(0).Rows.Count = 0 Then GoTo ExitIfNoNewData

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim mysqlitem As String = "SELECT * FROM ITEM WHERE ITEMCODE = '" & dr.Item("ITEMCODE") & "'"
            Dim dsnew As DataSet = LoadSQL(mysqlitem, "ITEM")
            Dim tmpID As Integer = dsnew.Tables(0).Rows(0).Item("ITEM_ID")

            Dim mysqlitmLine As String = "SELECT * FROM TBLITEM_LINE where ITEM_ID = ' " & tmpID & "'"
            Dim dsline As DataSet = LoadSQL(mysqlitmLine, "TBL_ITEMLINE")

            If dsline.Tables(0).Rows.Count = 0 Then _
                MsgBox("Please Update ItemLines", MsgBoxStyle.Critical) : GoTo ExitIfNoNewData

            Console.WriteLine("TBLITEM_LINE count: " & dsline.Tables(0).Rows.Count)
            Console.WriteLine("PApcutID: " & dsline.Tables(0).Rows(0).Item("PAPERCUT_ID"))


            For Each dr1 As DataRow In dsline.Tables(0).Rows
                Dim tmpPapcut As New PaperCut
                tmpPapcut.Load_PaperCUts(dr1.Item("PAPERCUT_ID"))


                Dim SaveSL As New SalesLine
                With SaveSL
                    .ProductionID = dr.Item("Production_ID")
                    .MagID = tmpPapcut.mag_IDP
                    .Paproll_serial = ""
                    .Quantity = dr.Item("QTY") * dsline.Tables(0).Rows(0).Item("QTY")
                    .Papercuts = tmpPapcut.papcut
                    .papcut_Desc = tmpPapcut.papcutDescription
                    .SubTotal_Length = (dr.Item("QTY") * dsline.Tables(0).Rows(0).Item("QTY")) * tmpPapcut.papcut
                    .Papcut_Code = tmpPapcut.PapCutITemcode

                    .SaveSalesLine()
                End With
            Next


            Dim mysql1 As String = "SELECT * FROM TBLPRO WHERE PRODUCTION_ID = '" & dr.Item("PRODUCTION_ID") & "'"
            Dim ds1 As DataSet = LoadSQL(mysql1, "TBLPRO")

            ds1.Tables(0).Rows(0).Item("Status") = 1

            database.SaveEntry(ds1, False)
        Next


        If lvpapercuts.Items.Count <= 0 Then Exit Sub

        For Each itm As ListViewItem In lvpapercuts.Items
            Dim newMysqlSalesLines As String = "SELECT * FROM TBL_PROLINE " & _
                "WHERE PAPCUT_CODE = '" & itm.SubItems(6).Text & "' AND STATUS <> 1"
            Dim MysqlSalesLines As DataSet = LoadSQL(newMysqlSalesLines, "TBL_PROLINE")

            For Each dr As DataRow In MysqlSalesLines.Tables(0).Rows
                Dim SubTotal As Double = (MysqlSalesLines.Tables(0).Rows(0).Item(5) * itm.SubItems(5).Text)

                dr("Paproll_SERIAL") = itm.SubItems(2).Text
                dr("Status") = 1

                database.SaveEntry(MysqlSalesLines, False)

                SelectedPaPRoll = New PaperRoll
                SelectedPaPRoll.TotalLength = SubTotal * meter
                SelectedPaPRoll.Updatepaper()
            Next

        Next

        MsgBox("Updated New Sales", MsgBoxStyle.Information, "Production")
ExitIfNoNewData:
        Exit Sub

    End Sub

  
End Class