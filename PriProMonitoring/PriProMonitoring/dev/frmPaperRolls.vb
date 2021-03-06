﻿Public Class frmPaperRolls
    Dim Chamber As Hashtable
    Private PapStatus As Boolean = IIf(GetOption("Magazine") = "YES", True, False)
    Private NumChamber As Integer = GetOption("Number Chamber")

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If LvPaperRollList.Items.Count = 0 Then Exit Sub
        If LvPaperRollList.SelectedItems.Count = 0 Then Exit Sub

        'Initialization 
        If CboChamber.Text = "" Then Exit Sub
        If Not PapStatus Then

            Dim count As Integer = frmInitializePaper.lvPaproll.Items.Count
            If count = 2 Then GoTo nextlineTodo

            For Each it As ListViewItem In frmInitializePaper.lvPaproll.Items
                Dim tmpChamTag As String = GetchamberTag(CboChamber.Text)

                If it.SubItems(3).Text = LvPaperRollList.SelectedItems(0).SubItems(2).Text _
                    Or it.SubItems(4).Text = LvPaperRollList.SelectedItems(0).SubItems(3).Text Or _
                    it.SubItems(2).Text = tmpChamTag Then Exit Sub
            Next

            Dim row As ListViewItem = frmInitializePaper.lvPaproll.Items.Add(LvPaperRollList.SelectedItems(0).SubItems(0).Text)

            row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(1).Text)
            row.SubItems.Add(GetchamberTag(CboChamber.Text))
            row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(2).Text)
            row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(3).Text)

nextlineTodo:
            frmInitializePaper.Show()
            Me.Close()


        Else
            'change paper roll
            If Not CHECKMAG_IFALREADYUSED() Then _
                MsgBox("This Paper roll Currently in used", MsgBoxStyle.Critical, "Paper roll") : CboChamber.SelectedItem = Nothing : Exit Sub


            RollstatInactive(LvPaperRollList.SelectedItems(0).SubItems(3).Text, _
                                GetchamberTag(CboChamber.Text), 0) 'update last load to 0

            UpdateRollstatus(LvPaperRollList.SelectedItems(0).SubItems(3).Text, 1) ' update new load to 1
            savePapLog(LvPaperRollList.SelectedItems(0).SubItems(0).Text) 'save paper log

            frmPaperRolls_Load(sender, e)
        End If

    End Sub

    Private Sub savePapLog(ByVal PaperRollID As Integer)
        Dim savelog As New PaperLoadLog
        savelog.PaprollID = PaperRollID
        savelog.loaded_by = CurrentUser
        savelog.Remaining = GetRemaining()
        savelog.Modname = "Load Paper Roll"
        savelog.SaveRoll()
    End Sub


    
    Private Sub frmPaperRolls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        LoadChamber()
        If txtsearch1.Text <> "" Then
            btnSearch1.PerformClick()
            Exit Sub
        End If
        loadPaperRoll()
        CurrentLyUsed()

        If NumChamber = 2 Then
            If Not PapStatus Then
                For Each itm As ListViewItem In frmInitializePaper.lvPaproll.Items
                    If itm.SubItems(2).Text = "B" Then
                        CboChamber.Items.Remove("Chamber 1")
                    Else
                        CboChamber.Items.Remove("Chamber 2")
                    End If
                Next
            End If
        End If


    End Sub

    Private Sub loadPaperRollSearch(ByVal papSerial As String, Optional ByVal pap As String = "")
        Dim mysql As String = "SELECT P.PAPROLL_ID,P.PAPIDS,M.PAPDESC,P.PAPROLL_SERIAL,P.Chamber FROM TBLPAPERROLL P " & _
                              "INNER JOIN TBLPAPROLL_MAIN M ON M.PAPID = P.PAPIDS " & _
                              "WHERE UPPER(P.PAPROLL_SERIAL) = UPPER('" & papSerial & "') OR UPPER(M.PAPDESC) = UPPER('" & pap & "')" & _
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
            If IsDBNull(dr.Item("Chamber")) Or dr.Item("Chamber") Is Nothing Then
                On Error Resume Next
            Else
                lv.SubItems.Add(dr.Item("Chamber"))
            End If
        Next

        MsgBox(count & "paper roll found.", MsgBoxStyle.Information)
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
            If IsDBNull(dr.Item("Chamber")) Or dr.Item("Chamber") Is Nothing Then

                On Error Resume Next
            Else
                lv.SubItems.Add(dr.Item("Chamber"))
            End If
        Next

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

    Private Function GetchamberByTag(ByVal TAG As String) As String
        For Each el As DictionaryEntry In Chamber
            If el.Key = TAG Then
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
        Dim mysql As String = "SELECT paproll_ID,paproll_serial,chamber,M.PAPID,M.PAPDESC " & _
                              "FROM TBLPAPERROLL INNER JOIN TBLPAPROLL_MAIN M ON M.PAPID =TBLPAPERROLL.PAPIDS " & _
                              "WHERE paproll_serial = '" & LvPaperRollList.SelectedItems(0).SubItems(3).Text & "' " & _
                              "AND STATUS ='1' " & _
                              "group by PAPID,paproll_ID,paproll_serial,chamber,M.PAPDESC"
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

    Private Sub CurrentLyUsed()
        For Each itm As ListViewItem In LvPaperRollList.Items

            Dim mysql As String = "SELECT paproll_ID,paproll_serial,chamber,PAPIDS,M.PAPDESC " & _
                           "FROM TBLPAPERROLL INNER JOIN TBLPAPROLL_MAIN M ON M.PAPID =TBLPAPERROLL.PAPIDS " & _
                           "WHERE paproll_serial = '" & itm.SubItems(3).Text & "' " & _
                           "AND STATUS ='1' " & _
                           "group by PAPIDS,paproll_ID,paproll_serial,chamber,M.PAPDESC"
            Dim ds As DataSet = LoadSQL(mysql, "tblpaperroll")

            If ds.Tables(0).Rows.Count = 1 Then
                itm.BackColor = Color.Red
            Else
                itm.BackColor = Color.White
            End If
        Next
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

    Private Sub CboChamber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboChamber.KeyPress
        If isEnter(e) Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmPaperRoll.Show()
        Me.Hide()
    End Sub

    Private Sub LvPaperRollList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LvPaperRollList.Click
       
    End Sub

    Private Sub txtsearch1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch1.KeyPress
        If isEnter(e) Then btnSearch1.PerformClick()
    End Sub

  
    Private Sub btnSearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch1.Click
        loadPaperRollSearch(txtsearch1.Text, txtsearch1.Text)

        CurrentLyUsed()
    End Sub

    Private Sub LvPaperRollList_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LvPaperRollList.MouseClick
        If GetActiveChamber() = "" Then CboChamber.SelectedItem = Nothing : Exit Sub

        CboChamber.Text = GetchamberByTag(GetActiveChamber)
    End Sub

    Private Function GetActiveChamber() As String
        Dim mysql As String = "SELECT * FROM TBLPAPERROLL P INNER JOIN TBLMACHINE M ON P.CHAMBER = M.CHAMBER_TAG " & _
            "WHERE PAPROLL_SERIAL = '" & LvPaperRollList.SelectedItems(0).SubItems(3).Text & " '"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")

        Dim count As Integer = ds.Tables(0).Rows.Count

        If count = 0 Then
            Return ""
        End If

        Console.WriteLine(ds.Tables(0).Rows.Count)

        Return ds.Tables(0).Rows(0).Item("Chamber")
    End Function

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