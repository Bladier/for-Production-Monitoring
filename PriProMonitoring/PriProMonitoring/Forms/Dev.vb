Public Class Dev


    Dim tmplastSalesID As String
    Dim tmpdate As String

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

                    UpdateOptionSales("LastSalesID", tmplastSalesID, tmpdate)
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
End Class