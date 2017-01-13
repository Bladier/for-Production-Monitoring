Public Class frmAdjustment
    Dim saveAdj As adjustment
    Dim saveAdjLine As adjustmentLine


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub

        Dim MYSQL As String = "SELECT P.PAPERCUT_ID,P.MAG_IDP,R.PAPROLL_SERIAL,STATUS,R.TOTAL_LENGTH," & _
          "P.PAPERCUT,P.PAPCUT_ITEMCODE,P.PAPCUT_DESCRIPTION " & _
          "FROM TBLPAPERCUT P INNER JOIN TBLPAPERROLL R ON P.MAG_IDP = R.MAG_IDS " & _
          "INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDP " & _
        String.Format("WHERE PAPROLL_SERIAL = {0} ORDER BY PAPERCUT_ID ASC ", txtSearch.Text)
        Dim ds As DataSet = LoadSQL(MYSQL, "PAPERCUT")

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("This paper roll doesn't existed" & vbCrLf & _
                                                    "Please check the serial.", MsgBoxStyle.Critical, "Adjustment") : Exit Sub

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
            lv.SubItems.Add("")
        Next

        For Each itm As ListViewItem In lvpapercuts.Items
            Me.Text = "Adjustment | " & LoadCurMag(itm.SubItems(1).Text)
        Next
    End Sub

    Private Sub lvpapercuts_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvpapercuts.DoubleClick
        InputPapCut()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub lvpapercuts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvpapercuts.KeyPress
        If isEnter(e) Then
            InputPapCut()
        End If
    End Sub

    Private Sub InputPapCut()
        If lvpapercuts.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = CInt(lvpapercuts.FocusedItem.Text)

        Dim tmpPapcut As New PaperCut
        tmpPapcut.Load_PaperCUts(idx)

        Dim value As String
        value = InputBox("Enter Quantity", "Quantity of " & tmpPapcut.papcutDescription)
        lvpapercuts.SelectedItems(0).SubItems(8).Text = value
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If lvpapercuts.Items.Count <= 0 Then MsgBox("No data to adjust", MsgBoxStyle.Information, "Adjustment")
        If txtRemarks.Text = "" Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this adjustment?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim ColAdjLine As New adjustmentCollection
        Dim tmppapSerial As New PaperRoll
        tmppapSerial.loadSerial(txtSearch.Text)

        saveAdj = New adjustment

        With saveAdj
            .PaprollID = tmppapSerial.PaprollID
            .PaprollSserial = tmppapSerial.PaperRollSErial
            .Remarks = txtRemarks.Text
            .CreatedAT = Now
            ' .SaveAdjustment()
        End With

        For Each itm As ListViewItem In lvpapercuts.Items
            saveAdjLine = New adjustmentLine
            With saveAdjLine

                If itm.SubItems(8).Text = "" Then On Error Resume Next

                .PaperCut_ID = itm.SubItems(0).Text
                .PapcutCode = itm.SubItems(6).Text
                .QTY = itm.SubItems(8).Text



            End With
            ColAdjLine.Add(saveAdjLine)

        Next

        saveAdj.AdjustmentLines = ColAdjLine
        saveAdj.SaveAdjustment()

        MsgBox("Success")
    End Sub


    Private Function LoadCurMag(ByVal ID As Integer) As String
        Dim filldata As String = "TBLMAGAZINE"
        Dim mysql As String = "SELECT * FROM " & filldata & " WHERE MAG_ID =" & ID
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        Return ds.Tables(0).Rows(0).Item("MagDescription")
    End Function

End Class