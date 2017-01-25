Public Class frmPaperRolls
    Dim Chamber As Hashtable
    Private MagStatus As Boolean = IIf(GetOption("Magazine") = "YES", True, False)

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If LvPaperRollList.Items.Count = 0 Then Exit Sub
        If LvPaperRollList.SelectedItems.Count = 0 Then Exit Sub

        If ModName = "Empty paper roll" Then
            frmDeclaration.txtSearch.Text = LvPaperRollList.SelectedItems(0).SubItems(3).Text
            frmDeclaration.txtSearch.Focus()
            frmDeclaration.Show()
            Me.Close()
            Exit Sub
        End If

        If CboChamber.Text = "" Then Exit Sub
        If Not MagStatus Then

            'Dim ChamberCount As Integer = GetOption("")
            Dim count As Integer = frmLoadMagazine.lvPaproll.Items.Count
            If count = 2 Then GoTo nextlineTodo

            For Each it As ListViewItem In frmLoadMagazine.lvPaproll.Items
                Dim tmpChamTag As String = GetchamberTag(CboChamber.Text)

                If it.SubItems(3).Text = LvPaperRollList.SelectedItems(0).SubItems(2).Text _
                    Or it.SubItems(4).Text = LvPaperRollList.SelectedItems(0).SubItems(3).Text Or _
                    it.SubItems(2).Text = tmpChamTag Then Exit Sub
            Next

            Dim row As ListViewItem = frmLoadMagazine.lvPaproll.Items.Add(LvPaperRollList.Items(0).Text)

            row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(1).Text)
            row.SubItems.Add(GetchamberTag(CboChamber.Text))
            row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(2).Text)
            row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(3).Text)

nextlineTodo:
            frmLoadMagazine.Show()
            Me.Close()
        Else
            If Not CHECKMAG_IFALREADYUSED() Then _
                MsgBox("This magazine Currently in used", MsgBoxStyle.Critical, "Magazine") : CboChamber.SelectedItem = Nothing : Exit Sub


            RollstatInactive(LvPaperRollList.SelectedItems(0).SubItems(3).Text, _
                                GetchamberTag(CboChamber.Text), 0) 'update last load to 0

            UpdateRollstatus(LvPaperRollList.SelectedItems(0).SubItems(3).Text, 1) ' update new load to 1
            savePapLog(LvPaperRollList.SelectedItems(0).SubItems(0).Text) 'save paper log

            frmProductionMonitoring.txtMagazine1.Text = LvPaperRollList.SelectedItems(0).SubItems(3).Text

            frmProductionMonitoring.Show()
            Me.Close()

        End If

    End Sub

    Private Sub savePapLog(ByVal PaperRollID As Integer)
        Dim savelog As New PaperLoadLog
        savelog.PaprollID = PaperRollID
        savelog.loaded_by = FrmMain.statusUser.Text
        savelog.Remaining = GetRemaining()
        savelog.SaveRoll()
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        loadPaperRollSearch(txtSearch.Text, txtSearch.Text)
    End Sub

    Private Sub frmPaperRolls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ModName = "Empty paper roll" Then btnAdd.Visible = True

        LoadChamber()
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
            Exit Sub
        End If
        loadPaperRoll()
    End Sub

    Private Sub loadPaperRollSearch(ByVal papSerial As String, Optional ByVal mag As String = "")
        Dim mysql As String = "SELECT P.PAPROLL_ID,P.MAG_IDS,M.MAGDESCRIPTION,P.PAPROLL_SERIAL FROM TBLPAPERROLL P " & _
                              "INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDS " & _
                              "WHERE UPPER(P.PAPROLL_SERIAL) = UPPER('" & papSerial & "') OR UPPER(M.MAGDESCRIPTION) = UPPER('" & mag & "')" & _
                              "and status <> '2'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        Dim count As Integer = ds.Tables(0).Rows.Count

        If ds.Tables(0).Rows.Count = 0 Then _
        MsgBox(count & " paper roll found.", MsgBoxStyle.Information) : txtSearch.Text = "" : Exit Sub

        LvPaperRollList.Items.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows

            Dim tmpID As Integer = dr.Item("Paproll_ID")
            Dim lv As ListViewItem = LvPaperRollList.Items.Add(tmpID)
            lv.SubItems.Add(dr.Item("MAG_IDS"))
            lv.SubItems.Add(dr.Item("MAGDESCRIPTION"))
            lv.SubItems.Add(dr.Item("PAPROLL_SERIAL"))
        Next
      
        MsgBox(count & "paper roll found.", MsgBoxStyle.Information)
    End Sub


    Private Sub loadPaperRoll()
        Dim mysql As String = "SELECT P.PAPROLL_ID,P.MAG_IDS,M.MAGDESCRIPTION,P.PAPROLL_SERIAL FROM TBLPAPERROLL P " & _
                              "INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDS where P.STATUS <> '2'"

        Dim ds As DataSet = LoadSQL(mysql, "TBL")
        Dim count As Integer = ds.Tables(0).Rows.Count


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpID As Integer = dr.Item("Paproll_ID")
            Dim lv As ListViewItem = LvPaperRollList.Items.Add(tmpID)
            lv.SubItems.Add(dr.Item("MAG_IDS"))
            lv.SubItems.Add(dr.Item("MAGDESCRIPTION"))
            lv.SubItems.Add(dr.Item("PAPROLL_SERIAL"))
        Next

        MsgBox(count & " paper roll found.", MsgBoxStyle.Information)
    End Sub

    Private Sub LoadChamber()
        Dim mySql As String = "SELECT * FROM tblMachine"
        Dim ds As DataSet = LoadSQL(mySql)

        Chamber = New Hashtable
        CboChamber.Items.Clear()
        Dim tmpName As String, tmpTag As String

        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                tmpTag = .Item("Chamber_tag")
                tmpName = .Item("Chamber_Desc")
            End With
            Chamber.Add(tmpTag, tmpName)
            CboChamber.Items.Add(tmpName)
        Next

    End Sub

    Private Function GetchamberByTag(ByVal id As Integer) As String
        For Each el As DictionaryEntry In Chamber
            If el.Key = id Then
                Return el.Value
            End If
        Next

        Return "N/A"
    End Function

    Private Function GetchamberTag(ByVal name As String) As String
        For Each el As DictionaryEntry In Chamber
            If el.Value = name Then
                Return el.Key
            End If
        Next

        Return 0
    End Function


    Private Sub RollstatInactive(ByVal serial As String, ByVal Chamber As String, ByVal status As Integer)
        Dim mySql1 As String = "SELECT * FROM TBLPAPERROLL WHERE " & _
                                "Chamber = '" & Chamber & "'"
        Dim fillData As String = "TBLPAPERROLL"
        Dim ds As DataSet = LoadSQL(mySql1, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("status") = status
                .Item("Chamber") = ""
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

    Private Sub UpdateRollstatus(ByVal serial As String, ByVal status As Integer)
        Dim mySql As String = "SELECT * FROM TBLPAPERROLL WHERE paproll_serial = '" & serial & "'"
        Dim fillData As String = "TBLPAPERROLL"
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("status") = status
                .Item("Chamber") = GetchamberTag(CboChamber.Text)
            End With
            database.SaveEntry(ds, False)
        End If

    End Sub

    Private Function CHECKMAG_IFALREADYUSED() As Boolean
        Dim mysql As String = "SELECT paproll_ID,paproll_serial,chamber,mag_IDS,M.MAGDESCRIPTION " & _
                              "FROM TBLPAPERROLL INNER JOIN TBLMAGAZINE M ON M.MAG_ID =TBLPAPERROLL.MAG_IDS " & _
                              "WHERE MAG_IDS = '" & LvPaperRollList.SelectedItems(0).SubItems(1).Text & "' " & _
                              "AND STATUS ='1' " & _
                              "group by MAG_IDS,paproll_ID,paproll_serial,chamber,MAGDESCRIPTION"
        Try
            Dim ds As DataSet = LoadSQL(mysql, "tblpaperroll")
            If ds.Tables(0).Rows.Count = 1 Then
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
        Return True
    End Function

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

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub CboChamber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboChamber.KeyPress
        If isEnter(e) Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmPaperRoll.Show()
        Me.Hide()
    End Sub
End Class