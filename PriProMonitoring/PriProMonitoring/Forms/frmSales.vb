﻿Public Class frmSales
    Private LastSaleID As String

    Dim tmplastSalesID As String
    Dim tmpdate As String

    Private Sub btnSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSales.Click
        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        LastSaleID = GetOption("LastSalesID").ToString

        If LastSaleID <> "" Then GoTo NextLineToDo

        If LastSaleID = "" Then
            tmplastSalesID = GetLastSaledID(0)
            tmpdate = GetLastSaledID(1)
            UpdateOptionSales("LastSalesID ", tmplastSalesID, tmpdate)
            MsgBox("Sales has been loaded.", MsgBoxStyle.Information, "Sales")
            Exit Sub
        End If

NextLineToDo:
        Dim tmpRemarks As Date = GetRemarks("LastSalesID") 'Remarks here is date 

        tmplastSalesID = GetLastSaledID(0)
        tmpdate = GetLastSaledID(1)

        If GetOption("LastSalesID").ToString = tmplastSalesID Then _
            MsgBox("No new row data in sales", MsgBoxStyle.Information, "Sales") : Exit Sub

        Dim SaveSales As New Sales
        With SaveSales
            Dim POSsales As String = "SELECT I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,E.TRANSDATE," & _
                                     "I.QTY FROM POSITEM I " & _
                                    "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                    "INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO " & _
                                    "where E.TRANSDATE between '" & tmpRemarks & "' and '" & DateTime.Now.ToString("MM/dd/yyyy") & "' " & _
                                     "ORDER BY E.DATESTAMP ASC "

            Dim ds As DataSet = LoadSQLPOS(POSsales, "POSITEM")

            Console.WriteLine("Count: " & ds.Tables(0).Rows.Count)

            For Each dr As DataRow In ds.Tables(0).Rows

                .ItemCode = dr.Item("ItemNo")
                .Descrition = dr.Item("Description")
                .SalesID = dr.Item("ID")
                .QTY = dr.Item("QTY")
                .SaveSales()
            Next

            UpdateOptionSales("LastSalesID", tmplastSalesID, tmpdate)
        End With

        MsgBox("Sales Updated.", MsgBoxStyle.Information, "Sales")
    End Sub

    Private Function GetLastSaledID() As String()
        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        Dim mysql As String = "select I.ID,I.itemno,E.TRANSDATE from POSITEM I " & _
                                "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                "where E.TRANSDATE between '8/12/2016' and '" & DateTime.Now.ToString("MM/dd/yyyy") & "' " & _
                                 "ORDER BY E.DATESTAMP DESC rows 1"

        Dim ds As DataSet = LoadSQLPOS(mysql, "POSITEM")

        Console.WriteLine(ds.Tables(0).Rows(0).Item("ID"))
        Dim ID As String() = {ds.Tables(0).Rows(0).Item("ID"), ds.Tables(0).Rows(0).Item("Transdate")}
        
        Return ID
    End Function
End Class