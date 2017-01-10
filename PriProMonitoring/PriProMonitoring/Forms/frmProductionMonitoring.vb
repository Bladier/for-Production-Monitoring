﻿Public Class frmProductionMonitoring
    Const meter As Double = 0.0254 '1 inch = 0.0254 meter
    Dim ds As New DataSet
    Dim SelectedPaPRoll As PaperRoll
    Dim saveSales As production


    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If lvpapercuts.Items.Count <= 0 Then Exit Sub
        databasePOS.dbNamePOS = GetOption("DatabasePOS")

        If Not CompareSalesRowToPRoduction() Then
            MsgBox("No new data in sales", MsgBoxStyle.Exclamation, "Production")
            Exit Sub
        End If

        For Each item As ListViewItem In lvpapercuts.Items

            Dim MYSQLSALES As String = "SELECT  FIRST 50 I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,I.QTY,I.PAPCUT_ITEMCODE,E.TRANSDATE FROM POSITEM I " & _
                                        " INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                        " INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO WHERE PAPCUT_ITEMCODE ='" & item.SubItems(6).Text & "' "
            Dim DSSLES As DataSet = LoadSQLPOS(MYSQLSALES, "TBLPOSITEM")

            For Each drSales As DataRow In DSSLES.Tables(0).Rows
                If drSales.Item("ID") = "" Then Exit For

                saveSales = New production
                With saveSales
                    .itemcode = drSales.Item("ITEMNO")
                    .DESCRIPTION = drSales.Item("DESCRIPTION")
                    .QTY = drSales.Item("QTY")
                    .papcut_Itemcode = drSales.Item("PAPCUT_ITEMCODE")
                    .SALES_id = drSales.Item("ID")
                End With
                saveSales.saveProduction()
            Next


            Dim mysql As String = "SELECT * FROM TBLPRODUCTION WHERE papcut_itemcode = '" & item.SubItems(6).Text & "'" & _
                                    " and status <> 1"
            ds = LoadSQL(mysql, "tblProduction")

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim SubTotal As Double = (ds.Tables(0).Rows(0).Item(5) * item.SubItems(5).Text)

                dr.Item("MAG_ID") = item.SubItems(1).Text
                dr("Paproll_SERIAL") = item.SubItems(2).Text
                dr.Item("Papercut") = item.SubItems(5).Text
                dr.Item("Papcut_Description") = item.SubItems(7).Text
                dr.Item("status") = 1
                dr.Item("SubTotal_Length") = SubTotal
                database.SaveEntry(ds, False)

                SelectedPaPRoll = New PaperRoll
                SelectedPaPRoll.TotalLength = SubTotal * meter
                SelectedPaPRoll.Updatepaper()
            Next

            tpProgressBar.Value = tpProgressBar.Value + 1
            Application.DoEvents()
            Label1.Text = String.Format("{0}%", ((tpProgressBar.Value / tpProgressBar.Maximum) * 100).ToString("F2"))
        Next

        If MsgBox("Sales loaded. . .", MsgBoxStyle.Information, "Production" & _
            "Migrating...") = MsgBoxResult.Ok Then tpProgressBar.Minimum = 0 : tpProgressBar.Value = 0 : Label1.Text = "0.00%"
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

    ''' <summary>
    ''' 
    ''' </summary>Compare Row in Sales table to Production table
    ''' <returns>Return false if No new Data in sales</returns>
    ''' <remarks></remarks>
    Private Function CompareSalesRowToPRoduction() As Boolean
        Dim MaxRowSales As Integer = 0
        Dim MaxRowPRo As Integer = 0
        For Each itm As ListViewItem In lvpapercuts.Items
            Dim MYSQLSALES As String = "SELECT  FIRST 20 I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,I.QTY,I.PAPCUT_ITEMCODE,E.TRANSDATE FROM POSITEM I " & _
                                     " INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                     " INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO WHERE PAPCUT_ITEMCODE ='" & itm.SubItems(6).Text & "' "
            Dim DSSLES As DataSet = LoadSQLPOS(MYSQLSALES, "TBLPOSITEM")
            MaxRowSales = DSSLES.Tables(0).Rows.Count


            Dim mysql As String = "SELECT * FROM TBLPRODUCTION WHERE papcut_itemcode = '" & itm.SubItems(6).Text & "'" & _
                                    " and status =1"
            ds = LoadSQL(mysql, "tblProduction")
            MaxRowPRo = ds.Tables(0).Rows.Count


            If MaxRowSales > MaxRowPRo Then
                Return True
            End If

            Console.WriteLine("MaxSales: " & MaxRowSales)
            Console.WriteLine("MaxSales: " & MaxRowPRo)
        Next

        Return False
    End Function

    Private Sub tpProgressBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpProgressBar.Click

    End Sub



    Private Sub btnLoadALLsales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadALLsales.Click
        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        If Not CheckNewRowSales() Then _
            MsgBox("There is no new sales to load", MsgBoxStyle.Information, "Sales") : Exit Sub

        Dim SaveSales As New Sales
        With SaveSales
            Dim POSsales As String = "SELECT  I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION," & _
                                    "I.QTY FROM POSITEM I " & _
                                    "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                    "INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO "

            Dim ds As DataSet = LoadSQLPOS(POSsales, "POSITEM")

            For Each dr As DataRow In ds.Tables(0).Rows
                .ItemCode = dr.Item("ItemNo")
                .Descrition = dr.Item("Description")
                .SalesID = dr.Item("ID")
                .QTY = dr.Item("QTY")
                .SaveSales()
            Next
        End With

        MsgBox("Success!!!")

    End Sub

    Private Function CheckNewRowSales() As Boolean
        Dim mysqlSales As String = "SELECT  I.ID FROM POSITEM I "
        Dim ds As DataSet = LoadSQLPOS(mysqlSales, "POSITEM")

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim mysql As String = "SELECT SALESID FROM TBLPRO" & _
                                " WHERE SALESID = '" & dr.Item("ID") & "'"
            Dim dsPro As DataSet = LoadSQL(mysql, "TBLPRO")
            If dsPro.Tables(0).Rows.Count >= 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnDev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDev.Click
        Dim mysql As String = "SELECT * FROM TBLPRO WHERE STATUS = '0'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPRO")
        Console.WriteLine("TBLPRO count: " & ds.Tables(0).Rows.Count)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim mysqlitem As String = "SELECT * FROM ITEM WHERE ITEMCODE = '" & dr.Item("ITEMCODE") & "'"
            Dim dsnew As DataSet = LoadSQL(mysqlitem, "ITEM")
            Dim tmpID As Integer = dsnew.Tables(0).Rows(0).Item("ITEM_ID")

            Dim mysqlitmLine As String = "SELECT * FROM TBLITEM_LINE where ITEM_ID = ' " & tmpID & "'"
            Dim dsline As DataSet = LoadSQL(mysqlitmLine, "TBL_ITEMLINE")


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
    End Sub
End Class