Imports System.Data.Odbc
Public Class frmMonitoring
    Dim PAPROLLS As New PaperRoll
    Dim papRollmain As New PAPERROLLMAIN

    Private selectedmain As PAPERROLLMAIN
    Private ParCuts_ALL_ht As Hashtable

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmEmptyPaperRollList.Show()
    End Sub

    Friend Sub PopulateCount(ByVal str As String)
        Dim mysql As String = "	SELECT P.PAPCODE,R.PAPROLL_SERIAL,PR.PAPCUT_DESC,	"
        mysql &= vbCrLf & "	SUM(PR.QUANTITY)AS TOTAL FROM tblPAPROLL_MAIN P	"
        mysql &= vbCrLf & "	INNER JOIN TBLPAPERROLL R ON R.PAPIDS = P.PAPID	"
        mysql &= vbCrLf & "	LEFT JOIN TBL_PROLINE PR	"
        mysql &= vbCrLf & "	ON PR.PAPROLL_SERIAL = R.PAPROLL_SERIAL 	"
        mysql &= vbCrLf & "	WHERE R.PAPROLL_SERIAL = '" & str & "'"
        mysql &= vbCrLf & "	GROUP BY PR.PAPCUT_DESC,P.PAPCODE,R.PAPROLL_SERIAL	"

        Dim ds As DataSet = LoadSQL(mysql, "tblPAPROLL_MAIN")

        Dim TMPPAPDESC As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PAPCUT_DESC")), "", ds.Tables(0).Rows(0).Item("PAPCUT_DESC"))

        If TMPPAPDESC = "" Then Exit Sub

        lvListEmptyRoll.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                Dim lv As ListViewItem = lvListEmptyRoll.Items.Add(.Item("PAPCODE"))
                lv.SubItems.Add(.Item("PAPROLL_SERIAL"))
                lv.SubItems.Add(.Item("PAPCUT_DESC"))
                lv.SubItems.Add(.Item("TOTAL"))
            End With
        Next

        getRemaining()
    End Sub


    Private Sub getRemaining()
        Dim p_cuts As New PaperCut
        Dim P_roll As New PaperRoll

        Dim TotalPrints As Double = 0.0

        For Each itm As ListViewItem In lvListEmptyRoll.Items
            p_cuts.papcutDescription = itm.SubItems(2).Text
            p_cuts.Load_pDesc() 'Load Paper Cut

            P_roll.loadSerial(itm.SubItems(1).Text) 'Load Paper roll

            Dim dblTotal As Double = 0
            Dim dblTemp As Double

            For Each lvItem As ListViewItem In lvListEmptyRoll.Items
                If Double.TryParse(lvItem.SubItems(3).Text, dblTemp) Then
                    dblTotal += dblTemp
                End If
            Next

            Dim PCUT_Remaining As Integer = ((P_roll.TotalLength * OneMeter) - dblTotal) / p_cuts.papcut

            itm.SubItems.Add(String.Format("{0}", Math.Round(PCUT_Remaining / p_cuts.papcut, 2)))
        Next
    End Sub

End Class