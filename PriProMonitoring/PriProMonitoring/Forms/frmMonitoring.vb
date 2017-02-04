Imports System.Data.Odbc
Public Class frmMonitoring
    Dim PAPROLLS As New PaperRoll
    Dim papRollmain As New PAPERROLLMAIN

    Private selectedmain As PAPERROLLMAIN
    Private ParCuts_ALL_ht As Hashtable

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmEmptyPaperRollList.Show()
    End Sub

    ''' <summary>
    ''' THis function populate the total prints of every paper roll and its paper cuts
    ''' </summary>
    ''' <param name="str"></param>
    ''' <remarks></remarks>
    Friend Sub PopulateCount(ByVal str As String)
        Dim mysql As String = "	SELECT P.PAPCODE,R.PAPROLL_SERIAL,PR.PAPCUT_DESC,PR.PAPERCUT,	"
        mysql &= vbCrLf & "	SUM(PR.QUANTITY)AS TOTAL FROM tblPAPROLL_MAIN P	"
        mysql &= vbCrLf & "	INNER JOIN TBLPAPERROLL R ON R.PAPIDS = P.PAPID	"
        mysql &= vbCrLf & "	LEFT JOIN TBL_PROLINE PR	"
        mysql &= vbCrLf & "	ON PR.PAPROLL_SERIAL = R.PAPROLL_SERIAL 	"
        mysql &= vbCrLf & "	WHERE R.PAPROLL_SERIAL = '" & str & "'"
        mysql &= vbCrLf & "	GROUP BY PR.PAPCUT_DESC,P.PAPCODE,R.PAPROLL_SERIAL,PR.PAPERCUT	"

        Dim ds As DataSet = LoadSQL(mysql, "tblPAPROLL_MAIN")

        Dim TMPPAPDESC As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PAPCUT_DESC")), "", ds.Tables(0).Rows(0).Item("PAPCUT_DESC"))

        If TMPPAPDESC = "" Then Exit Sub

        lvListEmptyRoll.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                Dim lv As ListViewItem = lvListEmptyRoll.Items.Add(.Item("PAPCODE"))
                lv.SubItems.Add(.Item("PAPROLL_SERIAL"))
                lv.SubItems.Add(.Item("PAPCUT_DESC"))
                lv.SubItems.Add(.Item("PAPERCUT"))
                lv.SubItems.Add(.Item("TOTAL"))
            End With
        Next

        getRemaining()
    End Sub

    ''' <summary>
    ''' calculate the remaining # of prints to be print
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getRemaining()
        Dim p_cuts As New PaperCut
        Dim P_roll As New PaperRoll

        Dim Totallength As Double = 0.0
        Dim dblTemp As Double

        For Each itm As ListViewItem In lvListEmptyRoll.Items
            p_cuts.papcutDescription = itm.SubItems(2).Text
            p_cuts.Load_pDesc() 'Load Paper Cut

            P_roll.loadSerial(itm.SubItems(1).Text) 'Load Paper roll

            For Each lvItm As ListViewItem In lvListEmptyRoll.Items

                dblTemp += lvItm.SubItems(3).Text * lvItm.SubItems(4).Text
            Next

            Totallength = P_roll.TotalLength * OneMeter
            Dim P_cut As Double = (Totallength - dblTemp) / itm.SubItems(4).Text


            itm.SubItems.Add(P_cut)

            'Dim dblTotal As Double = 0
            'Dim dblTemp As Double
            'Dim PC_Total As Double

            'Dim mysql As String = "SELECT P.PAPIDS,PC.PAPERCUT FROM TBLPAPERROLL P " & _
            '                        "INNER JOIN TBLPROLLANDPCUTS PRPC ON PRPC.PROLL_ID = P.PAPIDS " & _
            '                        "INNER JOIN TBLPAPERCUT PC ON PC.PAPERCUT_ID = PRPC.PCUT_ID " & _
            '                         "WHERE P.PAPROLL_SERIAL = '" & itm.SubItems(1).Text & "'"
            'Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")

            'Dim Papercut As Double = ds.Tables(0).Rows(0).Item("PAPERCUT")

            'For Each lvItem As ListViewItem In lvListEmptyRoll.Items
            '    For Each dr As DataRow In ds.Tables(0).Rows

            '        If Double.TryParse(lvItem.SubItems(3).Text, dblTemp) Then ' Quantity of every paper cut
            '            dblTotal = dblTemp * Papercut
            '        End If
            '    Next

            '    PC_Total += dblTotal


            '    Dim Total_Length As Double = P_roll.TotalLength * OneMeter ' Total lenght in Inches

            '    Dim subtotal As Double = Total_Length - dblTotal
            '    Dim PCUT_Remaining As Integer = subtotal / p_cuts.papcut

            '    Console.WriteLine(PCUT_Remaining)
            '    Console.WriteLine(Math.Round(PCUT_Remaining / p_cuts.papcut, 2))

            '    itm.SubItems.Add(String.Format("{0}", Math.Round(PCUT_Remaining / p_cuts.papcut, 2))) 'Populate remaining # to be prints
            'Next
        Next
    End Sub

    
End Class