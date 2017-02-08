Imports System.Data.Odbc
Public Class frmMonitoring
    Dim PAPROLLS As New PaperRoll
    Dim papRollmain As New PAPERROLLMAIN

    Private selectedmain As PAPERROLLMAIN
    Private ParCuts_ALL_ht As Hashtable

    Dim TotalPrints As Integer = 0

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lvListEmptyRoll.Items.Clear()
        frmEmptyPaperRollList.Show()
    End Sub

    ''' <summary>
    ''' THis function populate the total prints of every paper roll and its paper cuts
    ''' </summary>
    ''' <param name="str"></param>
    ''' <remarks></remarks>
    Friend Sub PopulateCount(ByVal str As String)
        Dim mysql As String = "	SELECT P.PAPCODE,R.PAPROLL_SERIAL,PR.PAPCUT_DESC,PR.PAPCUT_CODE,PR.PAPERCUT,	"
        mysql &= vbCrLf & "	SUM(PR.QUANTITY)AS TOTAL FROM tblPAPROLL_MAIN P	"
        mysql &= vbCrLf & "	INNER JOIN TBLPAPERROLL R ON R.PAPIDS = P.PAPID	"
        mysql &= vbCrLf & "	LEFT JOIN TBL_PROLINE PR	"
        mysql &= vbCrLf & "	ON PR.PAPROLL_SERIAL = R.PAPROLL_SERIAL 	"
        mysql &= vbCrLf & "	WHERE R.PAPROLL_SERIAL = '" & str & "'"
        mysql &= vbCrLf & "	GROUP BY PR.PAPCUT_DESC,P.PAPCODE,R.PAPROLL_SERIAL,PR.PAPERCUT,PR.PAPCUT_CODE	"

        Dim ds As DataSet = LoadSQL(mysql, "tblPAPROLL_MAIN")

        Dim TMPPAPDESC As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PAPCUT_DESC")), "", ds.Tables(0).Rows(0).Item("PAPCUT_DESC"))

        If TMPPAPDESC = "" Then Exit Sub

        lvListEmptyRoll.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr

                Dim MYSQL1 As String = "SELECT  A.PAPROLL_SERIAL,AL.PAPCUT_CODE,AL.QUANTITY, " & _
                               " AL.ADJUSTMENT_TYPE FROM TBLADJUSTMENT A INNER JOIN TBLADJUSTMENT_LINE AL " & _
                               String.Format("ON A.ADJUSTMENTID = AL.ADJUSTMENT_ID WHERE A.PAPROLL_SERIAL = '{0}' " & _
                                             "AND PAPCUT_CODE = '{1}'", .Item("PAPROLL_SERIAL"), .Item("PAPCUT_CODE"))
                Dim dsad As DataSet = LoadSQL(MYSQL1, "TBLADJUSTMENT")

                If dsad.Tables(0).Rows.Count = 0 Then
                    On Error Resume Next
                Else
                    With dsad.Tables(0).Rows(0)
                        If .Item("ADJUSTMENT_TYPE") = "Deduct" Then
                            TotalPrints = dr.Item("TOTAL") - .Item("QUANTITY")
                        Else
                            TotalPrints = dr.Item("TOTAL") + .Item("QUANTITY")
                        End If

                    End With
                End If


                Dim lv As ListViewItem = lvListEmptyRoll.Items.Add(.Item("PAPCODE"))
                lv.SubItems.Add(.Item("PAPROLL_SERIAL"))
                lv.SubItems.Add(.Item("PAPCUT_DESC"))
                lv.SubItems.Add(.Item("PAPCUT_CODE"))
                lv.SubItems.Add(.Item("PAPERCUT"))

                If dsad.Tables(0).Rows.Count = 0 Then
                    lv.SubItems.Add(.Item("TOTAL"))
                Else
                    lv.SubItems.Add(TotalPrints)
                End If
            End With
        Next

        getRemaining()
    End Sub

    ''' <summary>
    ''' calculate the remaining # of prints to be print
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getRemaining()


        Dim Totallength As Double = 0.0
        Dim dblTemp As Double = 0.0


        For Each itm As ListViewItem In lvListEmptyRoll.Items

            PAPROLLS.loadSerial(itm.SubItems(1).Text) 'Load Paper roll

            For Each lvItm As ListViewItem In lvListEmptyRoll.Items

                dblTemp += lvItm.SubItems(4).Text * lvItm.SubItems(5).Text
            Next

            Totallength = PAPROLLS.TotalLength * OneMeter
            Dim P_cut As Double = (Totallength - dblTemp) / itm.SubItems(4).Text


            itm.SubItems.Add(Math.Round(P_cut, 0))
            dblTemp = 0.0
        Next
    End Sub

End Class