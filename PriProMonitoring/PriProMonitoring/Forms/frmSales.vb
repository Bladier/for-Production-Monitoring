Public Class frmSales

    Private Sub btnSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSales.Click

        databasePOS.dbNamePOS = GetOption("DatabasePOS")

        If Not CheckNewSaless() Then _
            MsgBox("There is no new sales to load ", MsgBoxStyle.Information, "Production") _
          : Exit Sub

        Label1.Text = "Wait while sales is loading . . ."
        Dim SaveSales As New Sales
        With SaveSales
            Dim POSsales As String = "SELECT FIRST 10 I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,E.TRANSDATE," & _
                                    "I.QTY FROM POSITEM I " & _
                                    "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                    "INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO"

            Dim ds As DataSet = LoadSQLPOS(POSsales, "POSITEM")

            Console.WriteLine("Count: " & ds.Tables(0).Rows.Count)

            For Each dr As DataRow In ds.Tables(0).Rows

                .ItemCode = dr.Item("ItemNo")
                .Descrition = dr.Item("Description")
                .SalesID = dr.Item("ID")
                .QTY = dr.Item("QTY")
                .SaveSales()
            Next

        End With

        MsgBox("Success!!!")
        Label1.Text = "Status"
    End Sub


    Private Function CheckNewSaless() As Boolean
        Dim tmpPOSSales As String
        Dim tmpProSales As String

        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        Dim mysql As String = "SELECT I.ID FROM POSITEM I " & _
                                "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID" & _
                                " ORDER BY E.TRANSDATE DESC rows 1"

        Dim ds As DataSet = LoadSQLPOS(mysql, "POSITEM")
        tmpPOSSales = ds.Tables(0).Rows(0).Item("ID")
        Console.WriteLine("Count Sales ID:" & ds.Tables(0).Rows(0).Item("ID"))


        Dim mysqlPRo As String = "SELECT SALESID FROM TBLPRO " & _
                                 "ORDER BY PRODUCTION_ID DESC ROWS 1"

        Dim dsPro As DataSet = LoadSQL(mysqlPRo, "TBLPRO")
        tmpProSales = dsPro.Tables(0).Rows(0).Item("SALESID")
        Console.WriteLine("Count Sales ID:" & dsPro.Tables(0).Rows(0).Item("SALESID"))

        If tmpPOSSales = tmpProSales Then
            Return False
        End If
        Return True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        chec()
    End Sub


    Private Function chec() As Boolean
        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        Dim mysql As String = "select first 2 skip 573262 I.ID,I.itemno from POSITEM I" & _
                                "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                " ORDER BY E.TRANSDATE DESC rows 1"
        Dim ds As DataSet = LoadSQLPOS(mysql, "POSITEM")
        MsgBox("" & ds.Tables(0).Rows.Count)
        ' Return
    End Function
End Class