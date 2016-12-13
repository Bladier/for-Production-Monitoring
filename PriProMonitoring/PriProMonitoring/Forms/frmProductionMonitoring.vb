Public Class frmProductionMonitoring
    Const meter As Double = 0.0254 '1 inch = 0.0254 meter
    Dim ds As New DataSet
    Dim SelectedPaPRoll As PaperRoll
    Dim saveSales As production


    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If lvpapercuts.Items.Count <= 0 Then Exit Sub
        databasePOS.dbNamePOS = GetOption("DatabasePOS")

        If Not CompareSalesRowToPRoduction() Then
            MsgBox("No new data in sales", MsgBoxStyle.Information, "Production")
            Exit Sub
        End If

        For Each item As ListViewItem In lvpapercuts.Items

            Dim MYSQLSALES As String = "SELECT  FIRST 20 I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,I.QTY,I.PAPCUT_ITEMCODE,E.TRANSDATE FROM POSITEM I " & _
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
        Next

        MsgBox("Sales loaded. . .", MsgBoxStyle.Information, "Production")
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
End Class