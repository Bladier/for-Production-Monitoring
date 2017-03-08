Friend Module PrintProduction

    Dim tmpPapcut As New PaperCut
    Dim SaveSL As New SalesLine
    Dim SelectedPaPRoll As PaperRoll
    Dim mysql As String = String.Empty

    Public Sub Production()
        Dim mysql As String = "SELECT * FROM TBLPRO WHERE STATUS = '0'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPRO")
        
        Dim COUNTMAX As Integer = ds.Tables(0).Rows.Count

        If COUNTMAX = 0 Then GoTo nextlineTodo


        For Each dr As DataRow In ds.Tables(0).Rows
            mysql = "SELECT * FROM ITEM WHERE ITEMCODE  = '" & dr.Item("ITEMCODE") & "'"
            Dim dsItem As DataSet = LoadSQL(mysql, "ITEM")
            Console.WriteLine("Item: " & dsItem.Tables(0).Rows.Count)

            mysql = "select * from tblitem_line where ITEM_ID = '" & dsItem.Tables(0).Rows(0).Item("ITEM_ID") & "'"
            Dim dsITLine As DataSet = LoadSQL(mysql, "tblitem_line")
            Console.WriteLine("Itemline:" & dsITLine.Tables(0).Rows.Count)

            For Each drITline As DataRow In dsITLine.Tables(0).Rows

                tmpPapcut.Load_PaperCUts(drITline.Item("PAPERCUT_ID"))
                SelectedPaPRoll = New PaperRoll

                With SaveSL
                    .ProductionID = dr.Item("Production_ID")
                    .Paproll_serial = ""
                    .Quantity = dr.Item("QTY") * drITline.Item("QTY")
                    .Papercuts = tmpPapcut.papcut
                    .papcut_Desc = tmpPapcut.papcutDescription
                    .SubTotal_Length = .Quantity * tmpPapcut.papcut
                    .Papcut_Code = tmpPapcut.PapCutcode

                    .SaveSalesLine()
                End With
            Next


            Dim mysql1 As String = "SELECT * FROM TBLPRO WHERE PRODUCTION_ID = '" & dr.Item("PRODUCTION_ID") & "'"
            Dim ds1 As DataSet = LoadSQL(mysql1, "TBLPRO")

            ds1.Tables(0).Rows(0).Item("Status") = 1

            database.SaveEntry(ds1, False)

        Next

nextlineTodo:

        mysql = "select * from tbl_Proline where status <> 1"
        Dim dsPLine As DataSet = LoadSQL(mysql, "tbl_Proline")

        For Each dr As DataRow In dsPLine.Tables(0).Rows
            Dim subtotal As Double = dr.Item("SubTotal_Length")

            mysql = "SELECT PR.PROLL_ID,PR.PCUT_ID,P.PAPERCUT,P.PAPCUT_CODE " & _
                    " FROM TBLPROLLANDPCUTS PR " & _
                    "INNER JOIN TBLPAPERCUT P ON P.PAPERCUT_ID = PR.PCUT_ID " & _
                   " WHERE PAPCUT_CODE = '" & dr.Item("PAPCUT_CODE") & "'"

            Dim ds1 As DataSet = LoadSQL(mysql, "TBLPROLLANDPCUTS")
           
            If ds1.Tables(0).Rows.Count > 1 Then

                For Each drPC As DataRow In ds1.Tables(0).Rows
                    Dim mysqlProll As String = "SELECT * FROM TBLPAPERROLL WHERE PAPIDS ='" & drPC.Item("Proll_ID") & "' " & _
                           "and status  = '1'"
                    Dim dsProll As DataSet = LoadSQL(mysqlProll, "TBLPAPERROLL")


                    If dsProll.Tables(0).Rows.Count = 0 Then
                        With dr
                            .Item("PapID") = 0
                            .Item("Paproll_SERIAL") = "Unallocated"
                            database.SaveEntry(dsPLine, False)
                            On Error Resume Next
                        End With
                    Else
                        With dr
                            .Item("PapID") = dsProll.Tables(0).Rows(0).Item("PAPROLL_ID")
                            .Item("Paproll_SERIAL") = dsProll.Tables(0).Rows(0).Item("PAPROLL_SERIAL")
                            .Item("Status") = 1 ' 
                            database.SaveEntry(dsPLine, False)

                            SelectedPaPRoll = New PaperRoll
                            SelectedPaPRoll.PaperRollSErial = dsProll.Tables(0).Rows(0).Item("PAPROLL_SERIAL")
                            SelectedPaPRoll.Remaining = subtotal * Meter ' Deduct by meter to paper roll
                            SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll
                            Exit For
                        End With
                    End If
                Next
            Else

                Dim mysqlProll As String = "SELECT * FROM TBLPAPERROLL WHERE PAPIDS ='" & ds1.Tables(0).Rows(0).Item("Proll_ID") & "' " & _
                          "and status  = '1'"
                Dim dsProll As DataSet = LoadSQL(mysqlProll, "TBLPAPERROLL")

                If dsProll.Tables(0).Rows.Count = 0 Then
                    On Error Resume Next
                Else
                    With dr
                        .Item("PapID") = dsProll.Tables(0).Rows(0).Item("PAPROLL_ID") 'paper roll main ID
                        .Item("Paproll_SERIAL") = dsProll.Tables(0).Rows(0).Item("Paproll_SERIAL")
                        .Item("Status") = 1 ' Update Sales Line status to 1 it means this paper cut already deducted to paper roll

                        database.SaveEntry(dsPLine, False)

                        SelectedPaPRoll = New PaperRoll
                        SelectedPaPRoll.PaperRollSErial = .Item("Paproll_SERIAL")
                        SelectedPaPRoll.Remaining = subtotal * Meter ' Deduct by meter to paper roll
                        SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll
                    End With
                End If
            End If
        Next

    End Sub
End Module
