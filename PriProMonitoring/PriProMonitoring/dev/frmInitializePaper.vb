﻿Imports System.Threading
Public Class frmInitializePaper
    Private MagazineStatus As Boolean = IIf(GetOption("Magazine") = "YES", True, False)

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        frmPaperRolls.txtsearch1.Text = txtserial.Text

        frmPaperRolls.Show()
    End Sub

    Private Sub frmLoadMagazine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not MagazineStatus Then
            Me.Enabled = True
        Else
            Disabled()
            GetActivePAPERROLL()
        End If
    End Sub

    Private Sub Disabled()
        ' txtserial.Enabled = False
        lvPaproll.Enabled = False
        'btnsearch.Enabled = False
        'btnSet.Enabled = False
    End Sub

    Private Sub GetActivePAPERROLL()
        Dim mysql As String = "SELECT P.PAPROLL_ID,P.PAPIDS,P.CHAMBER,M.PAPDESC,P.PAPROLL_SERIAL FROM TBLPAPERROLL P " & _
                             "INNER JOIN TBLPAPROLL_MAIN M ON M.PAPID = P.PAPIDS " & _
                             " WHERE P.CHAMBER ='B' OR P.CHAMBER ='C'"

        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        If ds.Tables(0).Rows.Count <= 0 Then
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim row As ListViewItem = lvPaproll.Items.Add(dr.Item("PAPROLL_ID"))

            row.SubItems.Add(dr.Item("PAPIDS"))
            row.SubItems.Add(dr.Item("CHAMBER"))
            row.SubItems.Add(dr.Item("PAPDESC"))
            row.SubItems.Add(dr.Item("PAPROLL_SERIAL"))
        Next

    End Sub


    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        If lvPaproll.Items.Count = 0 Then Exit Sub

        Dim getchamber As Integer = GetOption("Number Chamber")
        If getchamber = 1 Then
            If lvPaproll.Items.Count <> 1 Then MsgBox("This branch used only one chamber." _
                & vbCrLf & "Just remove one PAPER ROLL.", MsgBoxStyle.Critical, "PAPER ROLL setup") : Exit Sub
            For Each itm As ListViewItem In lvPaproll.Items
                UpdateRollstatus(itm.SubItems(4).Text, "1", itm.SubItems(2).Text)
            Next
        End If

        If getchamber = 2 Then
            If lvPaproll.Items.Count <> 2 Then MsgBox("This branch has two chamber." _
                & vbCrLf & "Add one more PAPER ROLL.", MsgBoxStyle.Critical, "PAPER ROLL setup") : Exit Sub
            For Each itm As ListViewItem In lvPaproll.Items
                UpdateRollstatus(itm.SubItems(4).Text, "1", itm.SubItems(2).Text)
                savePapLog(itm.SubItems(0).Text)
            Next
        End If

        UpdateOptions("Magazine", "YES") 'Set magazine load

        MsgBox("PAPER ROLL has been initialized", MsgBoxStyle.Information, "PAPER ROLL")
        Me.Close()
    End Sub


    Friend Sub UpdateRollstatus(ByVal serial As String, ByVal status As Integer, ByVal chamTag As String)
        Dim mySql As String = "SELECT * FROM TBLPAPERROLL WHERE paproll_serial = '" & serial & "'"
        Dim fillData As String = "TBLPAPERROLL"
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("status") = status
                .Item("Chamber") = chamTag
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

    Private Sub txtserial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtserial.KeyPress
        If isEnter(e) Then btnsearch.PerformClick()
    End Sub

    Private Sub savePapLog(ByVal PaperRollID As Integer)
        Dim getremaining As New PaperRoll
        getremaining.LoadProll(PaperRollID)

        Dim savelog As New PaperLoadLog
        savelog.PaprollID = PaperRollID
        savelog.loaded_by = CurrentUser
        savelog.Remaining = getremaining.Remaining
        savelog.Modname = "Paper roll Initialization"
        savelog.SaveRoll()
    End Sub
 
End Class