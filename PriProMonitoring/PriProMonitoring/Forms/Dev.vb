Public Class Dev
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MYSQL As String = "SELECT * FROM TBLPRO"
        Dim ds As DataSet = LoadSQL(MYSQL, "TBLPRO")

        For Each dr As DataRow In ds.Tables(0).Rows
            If dr.Item(0) = 0 Then Exit Sub
            Dim mysqlITEM As String = "SELECT * FROM ITEM WHERE ITEMCODE = '" & dr.Item("ItemCode") & "'"
            Dim dsITEM As DataSet = LoadSQL(mysqlITEM, "ITEM")


            Dim mysqlITMLine As String = "SELECT * FROM TBLITEM_LINE WHERE ITEM_ID = '" & dsITEM.Tables(0).Rows(0).Item("ITEM_ID") & "'"
            Console.WriteLine("Item ID:" & dsITEM.Tables(0).Rows(0).Item("ITEM_ID"))
            Dim dsITMLine As DataSet = LoadSQL(mysqlITMLine, "TBLITEM_LINE")

            For Each dr1 As DataRow In dsITMLine.Tables(0).Rows


                Dim mysqlPROLine As String = "SELECT * FROM TBL_PROLINE where PRODUCTION_ID  = '" & dr.Item("PRODUCTION_ID") & "'"
                Dim dsPROLine As DataSet = LoadSQL(mysqlPROLine, "TBL_PROLINE")
                Dim dsNewRow As DataRow
                dsNewRow = dsPROLine.Tables(0).NewRow

                With dsNewRow
                    Dim mysqlPapCut As String = "SELECT * FROM TBLPAPERCUT WHERE PAPERCUT_ID  = '" & dr1.Item("PAPERCUT_ID") & "'"
                    Dim dsPapcut As DataSet = LoadSQL(mysqlPapCut, "TBLPAPERCUT")
                    Dim QTY As Integer = dr.Item("QUANTITY") * dr1.Item("QTY")
                    Dim CUT As Double = dsPapcut.Tables(0).Rows(0).Item("pAPERCUT")

                    .Item("PRODUCTION_ID") = dr.Item("PRODUCTION_ID")
                    '.Item("Mag_ID") = _Description
                    ' .Item("PapRoll_Serial") = _remarks
                    .Item("Quantity") = QTY
                    .Item("PaperCut") = CUT
                    .Item("Papcut_Desc") = dsPapcut.Tables(0).Rows(0).Item("papcut_description")
                    .Item("SubTotal_Length") = QTY * CUT
                    .Item("Papcut_Itemcode") = dsPapcut.Tables(0).Rows(0).Item("papcut_Itemcode")
                End With
                dsPROLine.Tables(0).Rows.Add(dsNewRow)
                database.SaveEntry(dsPROLine)
            Next
        Next

        MsgBox("Successfully loaded")
    End Sub
End Class