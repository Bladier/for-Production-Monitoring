Friend Module PrintProduction

    Dim tmpPapcut As New PaperCut
    Dim SaveSL As New SalesLine
    Dim SelectedPaPRoll As PaperRoll

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

        Dim mysqlPCUTViews As String = "SELECT * FROM papercut order by PAPID"
        Dim dsPCUTviews As DataSet = LoadSQL(mysqlPCUTViews, "papercut")

        For Each drPCUTviews As DataRow In dsPCUTviews.Tables(0).Rows
            With drPCUTviews
                mysql = "select * from tbl_Proline where status <> 1 and PapCut_Code ='" & .Item("PapCut_Code") & "'"
                Dim dsPLine As DataSet = LoadSQL(mysql, "tbl_Proline")

                For Each drP As DataRow In dsPLine.Tables(0).Rows
                    Dim SubTotal As Double = drP.Item("SUBTOTAL_LENGTH")

                    tmpPapcut.PapCutcode = .Item("PapCut_Code")
                    tmpPapcut.Load_pcuts() 'Load Paper selected Paper cuts

                    mysql = "select * from tblProllandPcuts where Pcut_ID = '" & tmpPapcut.PapcutID & "'"
                    Dim dsPROllCuts As DataSet = LoadSQL(mysql, "tblProllandPcuts")
                    Console.WriteLine("Paper cuts count:" & dsPROllCuts.Tables(0).Rows.Count) 'Check Paper cut if has many paper roll 

                    If dsPROllCuts.Tables(0).Rows.Count > 1 Then
                        For Each drProll As DataRow In dsPROllCuts.Tables(0).Rows

                            Dim mysqlProll As String = "SELECT * FROM TBLPAPERROLL WHERE PAPIDS ='" & drProll.Item("Proll_ID") & "' " & _
                             "and status  = '1'"
                            Dim dsProll As DataSet = LoadSQL(mysqlProll, "TBLPAPERROLL")

                            If dsProll.Tables(0).Rows.Count = 0 Then
                                drP("PapID") = 0
                                drP("Paproll_SERIAL") = "Unallocated"
                                database.SaveEntry(dsPLine, False)
                                On Error Resume Next
                            Else
                                drP("PapID") = dsProll.Tables(0).Rows(0).Item("PAPIDS")
                                drP("Paproll_SERIAL") = dsProll.Tables(0).Rows(0).Item("PAPROLL_SERIAL")
                                drP("Status") = 1 ' 
                                database.SaveEntry(dsPLine, False)

                                SelectedPaPRoll = New PaperRoll
                                SelectedPaPRoll.PaperRollSErial = dsProll.Tables(0).Rows(0).Item("PAPROLL_SERIAL")
                                SelectedPaPRoll.Remaining = SubTotal * Meter ' Deduct by meter to paper roll
                                SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll
                                Exit For
                            End If
                        Next

                    Else
                        drP("PapID") = .Item("PAPID") 'paper roll main ID
                        drP("Paproll_SERIAL") = .Item("Paproll_SERIAL")
                        drP("Status") = 1 ' Update Sales Line status to 1 it means this paper cut already deducted to paper roll

                        database.SaveEntry(dsPLine, False)

                        SelectedPaPRoll = New PaperRoll
                        SelectedPaPRoll.PaperRollSErial = .Item("Paproll_SERIAL")
                        SelectedPaPRoll.Remaining = SubTotal * Meter ' Deduct by meter to paper roll
                        SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll
                    End If
                Next
            End With
        Next

    End Sub
End Module
