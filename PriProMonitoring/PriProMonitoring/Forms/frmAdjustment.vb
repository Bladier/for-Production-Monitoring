Public Class frmAdjustment
    Dim saveAdj As adjustment
    Dim saveAdjLine As adjustmentLine
    Const Meter As Double = 0.0254 ' 1 inch = 0.0254 m

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
            lv.SubItems.Add(dr(7))
            lv.SubItems.Add(dr(6))
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

        Dim TotalAdj As Double = 0.0
        saveAdj = New adjustment

        With saveAdj
            .PaprollID = tmppapSerial.PaprollID
            .PaprollSserial = tmppapSerial.PaperRollSErial
            .Remarks = txtRemarks.Text
            .CreatedAT = Now

            For Each itms As ListViewItem In lvpapercuts.Items
                If itms.SubItems(8).Text = "" Then
                    On Error Resume Next
                Else
                    TotalAdj = itms.SubItems(5).Text * CDbl(itms.SubItems(8).Text)
                    saveAdj.TotalAdjustment += CDbl(TotalAdj)
                End If
            Next

            .TotalAdjustment = TotalAdj
        End With

        For Each itm As ListViewItem In lvpapercuts.Items
            saveAdjLine = New adjustmentLine
            With saveAdjLine

                If itm.SubItems(8).Text = "" Then On Error Resume Next

                .PaperCut_ID = itm.SubItems(0).Text
                .PapcutCode = itm.SubItems(6).Text
                .QTY = itm.SubItems(8).Text

                If rbAdd.Checked = True Then
                    .adjustType = rbAdd.Text
                Else
                    .adjustType = rbDeduct.Text
                End If

            End With
            ColAdjLine.Add(saveAdjLine)

        Next

        saveAdj.AdjustmentLines = ColAdjLine
        saveAdj.SaveAdjustment()

        If rbAdd.Checked = True Then
            AddToPaperRoll(tmppapSerial.PaprollID, TotalAdj)
        Else
            DeductToPaperRoll(tmppapSerial.PaprollID, TotalAdj)
        End If


        MsgBox("Successfully saved.", MsgBoxStyle.Information, "Adjustment")
        clearFields()
    End Sub

    Private Sub clearFields()
        txtSearch.Text = ""
        lvpapercuts.Items.Clear()
        txtRemarks.Text = ""
    End Sub

    Private Function LoadCurMag(ByVal ID As Integer) As String
        Dim filldata As String = "TBLMAGAZINE"
        Dim mysql As String = "SELECT * FROM " & filldata & " WHERE MAG_ID =" & ID
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        Return ds.Tables(0).Rows(0).Item("MagDescription")
    End Function

    Private Sub AddToPaperRoll(ByVal papRollID As Integer, ByVal TotalLength As Double)
        Dim fillData As String = "TBLPAPERROLL"
        Dim mySql1 As String = "SELECT * FROM " & fillData & " WHERE PapRoll_ID = '" & papRollID & "'"
        Dim ds As DataSet = LoadSQL(mySql1, fillData)

        Dim OldLength As Double = ds.Tables(0).Rows(0).Item("TOTAL_LENGTH")
        Dim LengthP As Double = TotalLength * Meter

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables(fillData).Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("TOTAL_LENGTH") = OldLength + LengthP
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

    Private Sub DeductToPaperRoll(ByVal papRollID As Integer, ByVal TotalLength As Double)
        Dim fillData As String = "TBLPAPERROLL"
        Dim mySql1 As String = "SELECT * FROM " & fillData & " WHERE PapRoll_ID = '" & papRollID & "'"
        Dim ds As DataSet = LoadSQL(mySql1, fillData)

        Dim OldLength As Double = ds.Tables(0).Rows(0).Item("TOTAL_LENGTH")
        Dim LengthP As Double = TotalLength * Meter

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables(fillData).Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("TOTAL_LENGTH") = OldLength - LengthP
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

    'Private Function CalcTOtal(Optional ByVal emulsion As Integer = 0, Optional ByVal advance As Integer = 0 _
    '                           , Optional ByVal lastout As Double = 0.0) As Double
    '    Dim tmpTotal As Double = 0.0 'papercuts
    '    Dim tmpTotal1 As Double = 0.0 'emulsion, advance, lastout
    '    saveAdj = New adjustment

    '    For Each itms As ListViewItem In lvpapercuts.Items
    '        If itms.SubItems(8).Text = "" Then
    '            On Error Resume Next
    '        Else
    '            tmpTotal = itms.SubItems(5).Text * CDbl(itms.SubItems(8).Text)
    '            saveAdj.TotalAdjustment += CDbl(tmpTotal)
    '        End If
    '    Next

    '    tmpTotal1 = CDbl(emulsion * EmuLsionP) + CDbl(advance * advanceP) + lastout

    '    Return CDbl(saveAdj.TotalAdjustment + tmpTotal1)
    'End Function

    'Private Sub txtEmulsion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmulsion.Leave
    '    If txtEmulsion.Text = "" Then txtEmulsion.Text = 0
    'End Sub

    'Private Sub txtLastout_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLastout.Leave
    '    If txtLastout.Text = "" Then txtLastout.Text = 0
    'End Sub

    'Private Sub txtAdvance_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdvance.Leave
    '    If txtAdvance.Text = "" Then txtAdvance.Text = 0
    'End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

    End Sub
End Class