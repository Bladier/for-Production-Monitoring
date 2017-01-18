﻿Public Class frmProductionMonitoring
    Const meter As Double = 0.0254 '1 inch = 0.0254 meter
    Dim ds As New DataSet
    Dim SelectedPaPRoll As PaperRoll
    Dim saveSales As production

    Private Sub frmProductionMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtMagazine1.Text = GetMag(0)
        txtMagazine2.Text = GetMag(1)
    End Sub


    Private Sub LOADACTIVEMAGAZINE()
        Dim mysql As String = "SELECT * FROM papercut order by Mag_IDP"

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

      
        txtActiveMagazine.Text = "Remaining" & " : " & GetLength(0) & "m " & GetMag(0) & _
                                " | " & GetLength(1) & "m " & GetMag(1)

        Production()
    End Sub

    Public Function GetLength() As List(Of Double)
        Dim mysql As String = "SELECT * FROM TBLPAPERROLL P INNER JOIN TBLMAGAZINE M ON M.MAG_ID=P.MAG_IDS " & _
                              " WHERE STATUS <> 0 and P.Chamber = 'B' OR P.Chamber='C' ORDER BY PAPROLL_ID ASC"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        Dim tmplenght As New List(Of Double)()
        For Each dr As DataRow In ds.Tables(0).Rows
            tmplenght.Add(dr.Item("Total_length"))
        Next

        Return tmplenght
    End Function

    Public Function GetMag() As List(Of String)

        Dim output As New List(Of String)()

        Dim mysql As String = " SELECT * FROM TBLMAGAZINE M INNER JOIN TBLPAPERROLL P ON M.MAG_ID=P.MAG_IDS" _
                              & " WHERE STATUS <> 0 and P.Chamber = 'B' OR P.Chamber='C' ORDER BY PAPROLL_ID ASC"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERCUT")

        For Each dr As DataRow In ds.Tables(0).Rows
            output.Add(dr.Item("Magdescription"))
        Next

        Return output

    End Function

    Private Sub Production()
        Dim mysql As String = "SELECT * FROM TBLPRO WHERE STATUS = '0'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPRO")
        Console.WriteLine("TBLPRO count: " & ds.Tables(0).Rows.Count)

        If ds.Tables(0).Rows.Count = 0 Then GoTo nextlineTodo


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim mysqlitem As String = "SELECT * FROM ITEM WHERE ITEMCODE = '" & dr.Item("ITEMCODE") & "'"
            Dim dsnew As DataSet = LoadSQL(mysqlitem, "ITEM")
            Dim tmpID As Integer = dsnew.Tables(0).Rows(0).Item("ITEM_ID")

            Dim mysqlitmLine As String = "SELECT * FROM TBLITEM_LINE where ITEM_ID = ' " & tmpID & "'"
            Dim dsline As DataSet = LoadSQL(mysqlitmLine, "TBL_ITEMLINE")

            If dsline.Tables(0).Rows.Count = 0 Then _
                MsgBox("Please Update ItemLines", MsgBoxStyle.Critical) : Exit Sub

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

nextlineTodo:


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
                SelectedPaPRoll.PaperRollSErial = itm.SubItems(2).Text
                SelectedPaPRoll.TotalLength = SubTotal * meter
                SelectedPaPRoll.Updatepaper()
            Next
        Next

        Console.WriteLine("Production updated")
    End Sub
  

    Private Sub txtMagazine1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMagazine1.TextChanged
        LOADACTIVEMAGAZINE()
    End Sub

    Private Sub Watermark1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub

        frmPaperRolls.txtSearch.Text = txtSearch.Text
        frmPaperRolls.Show()
        Me.Close()

    End Sub
End Class