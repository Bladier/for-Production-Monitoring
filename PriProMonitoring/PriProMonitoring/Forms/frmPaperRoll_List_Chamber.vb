Public Class frmPaperRoll_List_Chamber
    Private PapStatus As Boolean = IIf(GetOption("Magazine") = "YES", True, False)
    Dim mysql As String = String.Empty
    Dim ds As New DataSet

    Dim CHAMBER As String

    Private Sub frmPaperRoll_List_Chamber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If txtsearch1.Text <> "" Then
            btnSearch1.PerformClick()
            Exit Sub
        End If
        loadPaperRoll()
    End Sub

    Private Sub loadPaperRollByChamber()
        If rbChamberB.Checked = True Then
            CHAMBER = rbChamberB.Text
        Else
            CHAMBER = rbChamberC.Text
        End If

        Dim mysql As String = "SELECT P.PAPROLL_ID,P.PAPIDS,M.PAPDESC,P.PAPROLL_SERIAL,P.Chamber FROM TBLPAPERROLL P " & _
                              "INNER JOIN TBLPAPROLL_MAIN M ON M.PAPID = P.PAPIDS where P.STATUS <> '2' " & _
                              "AND M.CHAMBERDESC = '" & CHAMBER & "'"

        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")

        LvPaperRollList.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpID As Integer = dr.Item("Paproll_ID")
            Dim lv As ListViewItem = LvPaperRollList.Items.Add(tmpID)
            lv.SubItems.Add(dr.Item("PAPIDS"))
            lv.SubItems.Add(dr.Item("PAPDESC"))
            lv.SubItems.Add(dr.Item("PAPROLL_SERIAL"))
        Next

        CurrentLyUsed()
    End Sub


    Private Sub loadPaperRoll()
        Dim mysql As String = "SELECT P.PAPROLL_ID,P.PAPIDS,M.PAPDESC,P.PAPROLL_SERIAL,P.Chamber FROM TBLPAPERROLL P " & _
                              "INNER JOIN TBLPAPROLL_MAIN M ON M.PAPID = P.PAPIDS where P.STATUS <> '2'"

        Dim ds As DataSet = LoadSQL(mysql, "TBL")
        Dim count As Integer = ds.Tables(0).Rows.Count

        LvPaperRollList.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpID As Integer = dr.Item("Paproll_ID")
            Dim lv As ListViewItem = LvPaperRollList.Items.Add(tmpID)
            lv.SubItems.Add(dr.Item("PAPIDS"))
            lv.SubItems.Add(dr.Item("PAPDESC"))
            lv.SubItems.Add(dr.Item("PAPROLL_SERIAL"))
        Next

        CurrentLyUsed()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If LvPaperRollList.SelectedItems.Count = 0 Then Exit Sub

        If rbChamberB.Checked = False And rbChamberC.Checked = False Then Exit Sub

        'Initialization
        If Not PapStatus Then

            If Not Chamber_check(LvPaperRollList.SelectedItems(0).SubItems(1).Text) Then Exit Sub

            Dim lv As ListViewItem = frmLoadingPaper.lvpapList.Items.Add(LvPaperRollList.SelectedItems(0).SubItems(0).Text)
            lv.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(2).Text)
            lv.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(3).Text)
            lv.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(1).Text)

            Exit Sub
            Me.Close()
        End If

        ' Change paper roll
        If Not Chamber_check1(LvPaperRollList.SelectedItems(0).SubItems(1).Text) Then

            RollstatInactive(0) 'update last load to 0

            UpdateRollstatus(LvPaperRollList.SelectedItems(0).SubItems(3).Text, 1) ' update new load to 1
            savePapLog(LvPaperRollList.SelectedItems(0).SubItems(0).Text) 'save paper log

        End If
        CLEARFIELDS()

        frmPaperRoll_List_Chamber_Load(sender, e)

    End Sub

 
    Private Sub RollstatInactive(ByVal status As Integer)
        Dim fillData As String = "TBLPAPERROLL"
        Dim SUBTABLE As String = "TBLPAPROLL_MAIN"

        If rbChamberB.Checked = True Then
            CHAMBER = rbChamberB.Text
        Else
            CHAMBER = rbChamberC.Text
        End If

        Dim mySql1 As String = "SELECT * FROM " & fillData & " P INNER JOIN " & SUBTABLE & " PM " & _
                               "ON P.PAPIDS =PM.PAPID WHERE PM.CHAMBERDESC = '" & CHAMBER & "' " & _
                               "AND STATUS = 1"

        Dim ds As DataSet = LoadSQL(mySql1, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = CurrentUser
                .Item("status") = status
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

    Private Sub UpdateRollstatus(ByVal serial As String, ByVal status As Integer)
        Dim fillData As String = "TBLPAPERROLL"
        Dim mySql As String = "SELECT * FROM " & fillData & " WHERE paproll_serial = '" & serial & "'"

        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = CurrentUser
                .Item("status") = status
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub


    Private Function Chamber_check(ByVal id As Integer) As Boolean
        If frmLoadingPaper.lvpapList.Items.Count = 0 Then Return True

        mysql = "SELECT * FROM TBLPAPERROLL P INNER JOIN TBLPAPROLL_MAIN PM " & _
               "ON P.PAPIDS =PM.PAPID WHERE PM.PAPID ='" & id & "'"
        ds = LoadSQL(mysql, "TBLPAPERROLL")
        Dim selected_chamber As String = ds.Tables(0).Rows(0).Item("ChamberDesc")

        For Each itm As ListViewItem In frmLoadingPaper.lvpapList.Items
            Dim mysql1 As String = "SELECT * FROM TBLPAPROLL_MAIN WHERE PAPID = '" & itm.SubItems(3).Text & "'"
            ds = LoadSQL(mysql1, "TBLPAPROLL_MAIN")

            If ds.Tables(0).Rows.Count = 0 Then
                Exit For
            End If
        Next

        Try
            If selected_chamber = ds.Tables(0).Rows(0).Item("ChamberDesc") Then
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
        Return True
    End Function


    Private Function Chamber_check1(ByVal id As Integer) As Boolean

        mysql = "SELECT * FROM TBLPAPERROLL P INNER JOIN TBLPAPROLL_MAIN PM " & _
               "ON P.PAPIDS =PM.PAPID WHERE PM.PAPID ='" & id & "' AND STATUS = '1'"
        ds = LoadSQL(mysql, "TBLPAPERROLL")


        If ds.Tables(0).Rows.Count > 0 Then
            MsgBox("This paper roll currently loaded.", MsgBoxStyle.Information, "Load")
            Return True
        End If


        Dim mysql1 As String = "SELECT * FROM TBLPAPROLL_MAIN PM INNER JOIN TBLPAPERROLL P ON P.PAPIDS = PM.PAPID " & _
                                "WHERE PAPID = '" & id & "' " & _
                               "AND PAPDESC = '" & LvPaperRollList.SelectedItems(0).SubItems(2).Text & "' " & _
                               "AND P.STATUS = 1"
        ds = LoadSQL(mysql1, "TBLPAPROLL_MAIN")

        Try
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
        Return True
    End Function

    Private Sub savePapLog(ByVal PaperRollID As Integer)
        Dim savelog As New PaperLoadLog
        savelog.PaprollID = PaperRollID
        savelog.loaded_by = CurrentUser
        savelog.Remaining = GetRemaining()
        savelog.Modname = "Load Paper Roll"
        savelog.SaveRoll()
    End Sub

    Private Function GetRemaining() As Double
        Dim value As Double
        Dim mysql As String = "SELECT * FROM TBLPAPERROLL " & _
            "WHERE PAPROLL_SERIAL = '" & LvPaperRollList.SelectedItems(0).SubItems(3).Text & " '"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")

        value = ds.Tables(0).Rows(0).Item("Remaining")

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If

        Return value
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

  
    Private Sub rbChamberB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbChamberB.CheckedChanged
        If txtsearch1.Text = "" Then
            loadPaperRollByChamber()
        Else
            loadPaperRollSearch(txtsearch1.Text)
        End If

    End Sub

    Private Sub rbChamberC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbChamberC.CheckedChanged
        If txtsearch1.Text = "" Then
            loadPaperRollByChamber()
        Else
            loadPaperRollSearch(txtsearch1.Text)
        End If

    End Sub

    Private Sub btnSearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch1.Click
        loadPaperRollSearch(txtsearch1.Text)
    End Sub

    Private Sub loadPaperRollSearch(ByVal papSerial As String)
        Dim mysql As String = "SELECT P.PAPROLL_ID,P.PAPIDS,M.PAPDESC,P.PAPROLL_SERIAL,M.CHAMBERDESC FROM TBLPAPERROLL P " & _
                              "INNER JOIN TBLPAPROLL_MAIN M ON M.PAPID = P.PAPIDS " & _
                              "WHERE UPPER(P.PAPROLL_SERIAL) = UPPER('" & papSerial & "') OR UPPER(M.PAPDESC) = UPPER('" & papSerial & "')" & _
                              "and status <> '2'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        Dim count As Integer = ds.Tables(0).Rows.Count

        If ds.Tables(0).Rows.Count = 0 Then _
        MsgBox(count & " paper roll found.", MsgBoxStyle.Information) : txtsearch1.Text = "" : LvPaperRollList.Items.Clear() : Exit Sub

        LvPaperRollList.Items.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows

            Dim tmpID As Integer = dr.Item("Paproll_ID")
            Dim lv As ListViewItem = LvPaperRollList.Items.Add(tmpID)
            lv.SubItems.Add(dr.Item("PAPIDS"))
            lv.SubItems.Add(dr.Item("PAPDESC"))
            lv.SubItems.Add(dr.Item("PAPROLL_SERIAL"))

            If dr.Item("CHAMBERDESC") = "Chamber B" Then
                rbChamberB.Checked = True
            Else
                rbChamberC.Checked = True
            End If
        Next


        CurrentLyUsed()
        Console.WriteLine(count & "paper roll found.")
    End Sub

    Private Sub CurrentLyUsed()

        For Each itm As ListViewItem In LvPaperRollList.Items

            Dim mysql As String = "SELECT paproll_ID,paproll_serial,chamber,PAPIDS,M.PAPDESC,M.CHAMBERDESC " & _
                           "FROM TBLPAPERROLL INNER JOIN TBLPAPROLL_MAIN M ON M.PAPID =TBLPAPERROLL.PAPIDS " & _
                           "WHERE paproll_serial='" & itm.SubItems(3).Text & "' AND STATUS='1'"

            Dim ds As DataSet = LoadSQL(mysql, "tblpaperroll")

            If ds.Tables(0).Rows.Count = 1 Then
                itm.BackColor = Color.Red
            Else
                itm.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub CLEARFIELDS()
        rbChamberB.Checked = False
        rbChamberC.Checked = False
        txtsearch1.Text = ""
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class