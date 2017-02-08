Public Class Dev

    Dim timercount As Integer = 30

    Dim tmplastSalesID As String
    Dim tmpdate As String
    Dim mysql As String = String.Empty


    Dim tmpPapcut As New PaperCut
    Dim SaveSL As New SalesLine
    Dim SelectedPaPRoll As PaperRoll

    Dim countLoop As Integer = 2

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

    Private Sub Dev_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.Enabled = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim CheckLastID As String = GetOption("LastSalesID")
        If CheckLastID = "" Then Exit Sub

        If GetRemarks("LastSalesID") = frmSales.GetLastEntry(1) Then
            Exit Sub
        Else
            If CheckLastID <> "" Then
                Dim tmpRemarks As String = GetRemarks("LastSalesID")

                tmpRemarks = tmpRemarks.Remove(tmpRemarks.Length - 2)

                tmplastSalesID = frmSales.GetLastEntry(0)
                tmpdate = frmSales.GetLastEntry(1)

                If GetOption("LastSalesID") = tmplastSalesID Then _
                    MsgBox("No new row data in sales", MsgBoxStyle.Information, "Sales") : Exit Sub

                Dim SaveSales As New Sales
                With SaveSales
                    Dim POSsales As String = "SELECT I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,E.TRANSDATE," & _
                                             "I.QTY,E.DATESTAMP FROM POSITEM I " & _
                                            "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                            "INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO " & _
                                            "where E.DATESTAMP > '" & tmpRemarks & "'" & _
                                             "ORDER BY E.DATESTAMP ASC "

                    Dim ds As DataSet = LoadSQLPOS(POSsales, "POSITEM")
                    If ds.Tables(0).Rows.Count <= 0 Then Exit Sub

                    Console.WriteLine("Count: " & ds.Tables(0).Rows.Count)
                    Dim max As Integer = ds.Tables(0).Rows.Count

                    For Each dr As DataRow In ds.Tables(0).Rows
                        .ItemCode = dr.Item("ItemNo")
                        .Descrition = dr.Item("Description")
                        .SalesID = dr.Item("ID")
                        .QTY = dr.Item("QTY")
                        .SaveSales()

                        ProgressBar1.Maximum = max
                        ProgressBar1.Value = ProgressBar1.Value + 1
                        Application.DoEvents()
                        Label1.Text = String.Format("{0}%", ((ProgressBar1.Value / ProgressBar1.Maximum) * 100).ToString("F2"))
                    Next
                    If MsgBox("Sales Updated.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
        "Sales...") = MsgBoxResult.Ok Then ProgressBar1.Minimum = 0 : ProgressBar1.Value = 0 : Label1.Text = "0.00%"

                    Dim updatemainTainance As New GetSalesID

                    With updatemainTainance
                        .OPTVALUES = tmplastSalesID
                        .REMARKS = tmpdate
                    End With
                    updatemainTainance.UPDATE_MAINTAINANCE("LastSalesID ")

                End With
            End If
        End If

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    'Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
    '    MsgBox("Done")
    '    Button2.Enabled = True
    'End Sub

    Private Sub btnDeduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeduct.Click
        Updatepaper()
    End Sub

    Private Sub Updatepaper()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE mag_IDS = {1}", "tblpaperroll", 2)
        Dim ds As DataSet = LoadSQL(mySql, "tblpaperroll")

        Dim TotLength As Double = ds.Tables(0).Rows(0).Item("Total_Length")

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables("tblpaperroll").Rows(0)
            .Item("Total_Length") = TotLength - 183.084
            .Item("Updated_at") = Now
        End With
        database.SaveEntry(ds, False)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Timer1.Interval = 1000 'The number of miliseconds in a second
        Timer1.Enabled = True 'Start the timer
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Label2.Text = timercount.ToString() 'show the countdown in the label
        If timercount = 0 Then 'Check to see if it has reached 0, if yes then stop timer and display done
            timercount = 30
            Button3.PerformClick()
        Else 'If timercount is higher then 0 then subtract one from it
            timercount -= 1
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        PrintProduction.Production()
        'NewSalesLoad()
    End Sub


    Private Sub NewSalesLoad()
        Dim CheckLastID As String = GetOption("LastSalesID")
        If CheckLastID = "" Then Exit Sub

        If GetRemarks("LastSalesID") = frmSales.GetLastEntry(0) Then
            Exit Sub
        Else
            If CheckLastID <> "" Then
                Dim tmpRemarks As String = GetRemarks("LastSalesID")

                tmpRemarks = tmpRemarks.Remove(tmpRemarks.Length - 2)

                tmplastSalesID = frmSales.GetLastEntry(0)
                tmpdate = frmSales.GetLastEntry(1)

                If tmplastSalesID = "" Then Exit Sub

                If GetOption("LastSalesID") = tmplastSalesID Then _
                   GoTo nextLineTODO
                ' MsgBox("No new row data in sales", MsgBoxStyle.Information, "Sales") : Exit Sub

                Dim SaveSales As New Sales
                With SaveSales
                    Dim POSsales As String = "SELECT I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,E.TRANSDATE," & _
                                             "I.QTY,E.DATESTAMP FROM POSITEM I " & _
                                            "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                            "INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO " & _
                                            "where E.DATESTAMP > '" & tmpRemarks & "' AND I.QTY <> '0' " & _
                                             "ORDER BY E.DATESTAMP ASC "

                    Dim ds As DataSet = LoadSQLPOS(POSsales, "POSITEM")
                    If ds.Tables(0).Rows.Count <= 0 Then Exit Sub

                    Console.WriteLine("Count: " & ds.Tables(0).Rows.Count)
                    Dim max As Integer = ds.Tables(0).Rows.Count

                    For Each dr As DataRow In ds.Tables(0).Rows

                        Dim tmpItemLine As New ItemLine

                        Dim mysqlITem As String = "SELECT * FROM ITEM WHERE ITEMCODE = '" & dr.Item("ITEMNO") & "'"
                        Dim dsITEM As DataSet = LoadSQL(mysqlITem, "ITEM")
                        'Dim ItemID As Integer = dsITEM.Tables(0).Rows(0).Item("ITEM_ID")

                        If dsITEM.Tables(0).Rows.Count = 0 Then
                            On Error Resume Next
                        Else
                            tmpItemLine.LoadExistItemLine(dsITEM.Tables(0).Rows(0).Item("ITEM_ID"))

                            If tmpItemLine.itemLineID = 0 Then
                                On Error Resume Next
                            Else

                                .ItemCode = dr.Item("ItemNo")
                                .Descrition = dr.Item("Description")
                                .SalesID = dr.Item("ID")
                                .QTY = dr.Item("QTY")
                                .SaveSales()
                            End If
                        End If

                    Next

                    Dim updatemainTainance As New GetSalesID

                    With updatemainTainance
                        .OPTVALUES = tmplastSalesID
                        .REMARKS = tmpdate
                    End With
                    updatemainTainance.UPDATE_MAINTAINANCE("LastSalesID ")

                End With
            End If
        End If

nextLineTODO:

        Production()

    End Sub


  

    Public Sub Production()
        Dim mysql As String = "SELECT * FROM TBLPRO WHERE STATUS = '0'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPRO")

        Dim COUNTMAX As Integer = ds.Tables(0).Rows.Count

        If COUNTMAX = 0 Then GoTo nextlineTodo1


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

nextlineTodo1:

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


                    Dim mysqlProll1 As String = "SELECT * FROM TBLPAPERROLL WHERE PAPIDS ='" & dsPROllCuts.Tables(0).Rows(0).Item("Proll_ID") & "' " & _
                     "and status  = '1'"
                    Dim dsProll1 As DataSet = LoadSQL(mysqlProll1, "TBLPAPERROLL")


                    If dsPROllCuts.Tables(0).Rows.Count > 1 Then
                        For Each drProll As DataRow In dsPROllCuts.Tables(0).Rows

                            Dim mysqlProll As String = "SELECT * FROM TBLPAPERROLL WHERE PAPIDS ='" & drProll.Item("Proll_ID") & "' " & _
                             "and status  = '1'"
                            Dim dsProll As DataSet = LoadSQL(mysqlProll, "TBLPAPERROLL")

                            Dim str As String = drP("Paproll_SERIAL")
                            Dim ID As Integer = drP("PapID")
                            If str = Nothing Then
                                GoTo nextlineTODO
                            ElseIf ID = 0 Then
                                GoTo nextlineTODO
                            Else
                                Exit For
                            End If

nextlineTODO:

                            If dsProll.Tables(0).Rows.Count = 0 Then
                                drP("PapID") = 0
                                drP("Paproll_SERIAL") = "Unallocated"
                                database.SaveEntry(dsPLine, False)

                            Else
                                drP("PapID") = dsProll.Tables(0).Rows(0).Item("PAPIDS")
                                drP("Paproll_SERIAL") = dsProll.Tables(0).Rows(0).Item("PAPROLL_SERIAL")
                                drP("Status") = 1 ' 
                                database.SaveEntry(dsPLine, False)

                                SelectedPaPRoll = New PaperRoll
                                SelectedPaPRoll.PaperRollSErial = dsProll.Tables(0).Rows(0).Item("PAPROLL_SERIAL")
                                SelectedPaPRoll.Remaining = SubTotal * Meter ' Deduct by meter to paper roll
                                SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll

                            End If
                        Next

                    Else

                        drP("PapID") = dsProll1.Tables(0).Rows(0).Item("PAPROLL_ID") 'paper roll main ID
                        drP("Paproll_SERIAL") = dsProll1.Tables(0).Rows(0).Item("Paproll_SERIAL")
                        drP("Status") = 1 ' Update Sales Line status to 1 it means this paper cut already deducted to paper roll

                        database.SaveEntry(dsPLine, False)

                        SelectedPaPRoll = New PaperRoll
                        SelectedPaPRoll.PaperRollSErial = dsProll1.Tables(0).Rows(0).Item("Paproll_SERIAL")
                        SelectedPaPRoll.Remaining = SubTotal * Meter ' Deduct by meter to paper roll
                        SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll
                    End If
                Next
            End With
        Next
    End Sub




    '    mysql = "select * from tblitem_line where ITEM_ID = '" & dsITEM.Tables(0).Rows(0).Item("ITEM_ID") & "'"
    '    Dim dsITLine As DataSet = LoadSQL(mysql, "tblitem_line")

    '                        Console.WriteLine("Itemline:" & dsITLine.Tables(0).Rows.Count)

    '                        For Each drITline As DataRow In dsITLine.Tables(0).Rows

    '                            mysql = "select * from tblProllandPcuts where Pcut_ID = '" & drITline.Item("PAPERCUT_ID") & "'"
    '    Dim dsPROllCuts As DataSet = LoadSQL(mysql, "tblProllandPcuts")
    '                            Console.WriteLine("Paper cuts count:" & dsPROllCuts.Tables(0).Rows.Count) 'Check Paper cut if has many paper roll 

    '    Dim mysqlProll As String = "SELECT * FROM TBLPAPERROLL WHERE PAPIDS ='" & dsPROllCuts.Tables(0).Rows(0).Item("Proll_ID") & "' " & _
    '            "and status  = '1'"
    '    Dim dsProll As DataSet = LoadSQL(mysqlProll, "TBLPAPERROLL")

    '                            tmpPapcut.Load_PaperCUts(drITline.Item("PAPERCUT_ID"))
    '                            SelectedPaPRoll = New PaperRoll

    '    Dim load_pro As New Sales
    '                            load_pro.lOad_Pro(.SalesID)

    '                            If dsPROllCuts.Tables(0).Rows.Count > 1 Then
    '                                For Each drProll As DataRow In dsPROllCuts.Tables(0).Rows

    '    Dim mysqlProll1 As String = "SELECT * FROM TBLPAPERROLL WHERE PAPIDS ='" & drProll.Item("Proll_ID") & "' " & _
    '       "and status  = '1'"
    '    Dim dsProll1 As DataSet = LoadSQL(mysqlProll1, "TBLPAPERROLL")

    '                                    If SaveSL.Paproll_serial = Nothing Then
    '                                        GoTo nextlineTODO
    '                                    ElseIf SaveSL.Paproll_serial.Length > 11 Then
    '                                        Exit For
    '                                    Else
    '                                        SaveSL.lOad_LAST_SalesLines()
    '                                        GoTo nextlineTODO
    '                                    End If

    'nextlineTODO:
    '                                    If dsProll1.Tables(0).Rows.Count = 0 Then
    '                                        With SaveSL
    '                                            .ProductionID = load_pro.ID
    '                                            .PAPID = 0
    '                                            .Paproll_serial = "Unallocated"
    '                                            .Quantity = dr.Item("QTY") * drITline.Item("QTY")
    '                                            .Papercuts = tmpPapcut.papcut
    '                                            .papcut_Desc = tmpPapcut.papcutDescription
    '                                            .SubTotal_Length = .Quantity * tmpPapcut.papcut
    '                                            .Papcut_Code = tmpPapcut.PapCutcode

    '                                            .SaveSalesLine()

    '                                        End With
    '                                    Else
    '                                        With SaveSL
    '                                            .ProductionID = load_pro.ID
    '                                            .PAPID = dsProll1.Tables(0).Rows(0).Item("PAPROLL_ID")
    '                                            .Paproll_serial = dsProll1.Tables(0).Rows(0).Item("Paproll_serial")
    '                                            .Quantity = dr.Item("QTY") * drITline.Item("QTY")
    '                                            .Papercuts = tmpPapcut.papcut
    '                                            .papcut_Desc = tmpPapcut.papcutDescription
    '                                            .SubTotal_Length = .Quantity * tmpPapcut.papcut
    '                                            .Papcut_Code = tmpPapcut.PapCutcode

    '                                            .SaveSalesLine()

    '                                            SelectedPaPRoll = New PaperRoll
    '                                            SelectedPaPRoll.PaperRollSErial = dsProll1.Tables(0).Rows(0).Item("Paproll_serial")
    '                                            SelectedPaPRoll.Remaining = .SubTotal_Length * Meter ' Deduct by meter to paper roll
    '                                            SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll

    '                                        End With
    '                                    End If
    '                                Next

    '                            Else

    '                                With SaveSL
    '                                    .ProductionID = load_pro.ID
    '                                    .Paproll_serial = dsProll.Tables(0).Rows(0).Item("Paproll_serial")
    '                                    .Quantity = dr.Item("QTY") * drITline.Item("QTY")
    '                                    .Papercuts = tmpPapcut.papcut
    '                                    .papcut_Desc = tmpPapcut.papcutDescription
    '                                    .SubTotal_Length = .Quantity * tmpPapcut.papcut
    '                                    .Papcut_Code = tmpPapcut.PapCutcode
    '                                    .SaveSalesLine()

    '                                    SelectedPaPRoll = New PaperRoll
    '                                    SelectedPaPRoll.PaperRollSErial = dsProll.Tables(0).Rows(0).Item("Paproll_serial")
    '                                    SelectedPaPRoll.Remaining = .SubTotal_Length * Meter ' Deduct by meter to paper roll
    '                                    SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll
    '                                End With
    '                            End If
    '                            SaveSL.Paproll_serial = nothing
    '                        Next

    '                        .SalesID = .SalesID
    '                        .status = 1
    '                        SaveSales.update()

   
End Class