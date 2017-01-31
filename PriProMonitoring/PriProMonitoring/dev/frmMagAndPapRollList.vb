Public Class frmMagAndPapRollList
    Private MagazineStatus As Boolean = IIf(GetOption("Magazine") = "YES", True, False)
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        loadPapRollBYSEARCH()
    End Sub

    Private Sub frmMagAndPapRollList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        Else
            loadPapRoll()
        End If
    End Sub

    Private Sub loadPapRoll(Optional ByVal mysql As String = "SELECT PAPROLL_ID,MAG_IDS,PAPROLL_SERIAL, MAGDESCRIPTION" & _
                             " FROM TBLPAPERROLL P INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDS")
        Dim DS As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        LVPAPROLL.Items.Clear()
        For Each dr As DataRow In DS.Tables(0).Rows
            Dim lv As ListViewItem = LVPAPROLL.Items.Add(dr(0))
            lv.SubItems.Add(dr(1))
            lv.SubItems.Add(dr(2))
            lv.SubItems.Add(dr(3))
        Next

    End Sub

    Private Sub loadPapRollBYSEARCH()
        Dim mysql As String = "SELECT PAPROLL_ID,MAG_IDS,PAPROLL_SERIAL, MAGDESCRIPTION" & _
                                     " FROM TBLPAPERROLL P INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDS"
        mysql &= String.Format(" WHERE (UPPER (PAPROLL_SERIAL) = '{0}' OR UPPER (MAGDESCRIPTION) LIKE UPPER('%{0}%')) ", txtSearch.Text)
        mysql &= "ORDER BY PAPROLL_ID ASC"
        Dim DS As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        LVPAPROLL.Items.Clear()
        Console.WriteLine("SQL: " & mysql)
        Dim MaxRow As Integer = DS.Tables(0).Rows.Count

        LVPAPROLL.Items.Clear()

        If MaxRow <= 0 Then
            Console.WriteLine("No paper roll List Found")
            txtSearch.SelectAll()
            LVPAPROLL.Items.Clear()
            Exit Sub
        End If

        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search paper roll")
        For Each dr As DataRow In DS.Tables(0).Rows

            Dim lv As ListViewItem = LVPAPROLL.Items.Add(dr(0))
            lv.SubItems.Add(dr(1))
            lv.SubItems.Add(dr(2))
            lv.SubItems.Add(dr(3))
        Next
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        If LVPAPROLL.Items.Count <= 0 Then Exit Sub

        If LVPAPROLL.SelectedItems.Count = 0 Then
            LVPAPROLL.Items(0).Focused = True
            Exit Sub
        End If
        Dim PAPSERIAL As String = LVPAPROLL.SelectedItems(0).SubItems(2).Text

        If Not MagazineStatus Then
            UpdateOptions("Magazine", "YES") 'Set magazine load
            UpdateRollstatus(PAPSERIAL, "1") ' Initialized magazine
            MsgBox("Magazine has been initialized", MsgBoxStyle.Information, "Magazine")
            Me.Close()
        Else

            RollstatInactive(LoadActiveRoll, 0) 'update last load to 0
            UpdateRollstatus(PAPSERIAL, 1) ' update new load to 1

            frmProductionMonitoring.txtpaperRoll1.Text = LVPAPROLL.SelectedItems(0).SubItems(3).Text

            savePapLog(LVPAPROLL.SelectedItems(0).SubItems(0).Text) 'save paper log


            frmProductionMonitoring.Show()
            Me.Close()
        End If
    End Sub

    Private Sub savePapLog(ByVal PaperRollID As Integer)
        Dim savelog As New PaperLoadLog
        savelog.PaprollID = PaperRollID
        savelog.loaded_by = FrmMain.statusUser.Text
        savelog.SaveRoll()
    End Sub

    Friend Sub RollstatInactive(ByVal serial As String, ByVal status As Integer)
        Dim mySql1 As String = "SELECT * FROM TBLPAPERROLL WHERE paproll_serial = '" & serial & "'"
        Dim fillData As String = "TBLPAPERROLL"
        Dim ds As DataSet = LoadSQL(mySql1, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("status") = status
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

    Friend Sub UpdateRollstatus(ByVal serial As String, ByVal status As Integer)
        Dim mySql As String = "SELECT * FROM TBLPAPERROLL WHERE paproll_serial = '" & serial & "'"
        Dim fillData As String = "TBLPAPERROLL"
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("status") = status
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

    Private Function LoadActiveRoll()
        Dim mysql As String = "SELECT * FROM TBLPAPERROLL WHERE STATUS <> 0"
        Dim DS As DataSet = LoadSQL(mysql, "TBLPAPERROLL")

        Return DS.Tables(0).Rows(0).Item("PapRoll_serial")
    End Function

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub LVPAPROLL_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVPAPROLL.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub LVPAPROLL_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LVPAPROLL.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSelect.PerformClick()
        End If
    End Sub
End Class