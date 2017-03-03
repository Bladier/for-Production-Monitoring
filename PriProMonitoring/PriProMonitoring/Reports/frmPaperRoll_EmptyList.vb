Public Class frmPaperRoll_EmptyList

    Private Sub frmPaperRoll_EmptyList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Proll()
    End Sub

    Private Sub Load_Proll()
        Dim ds As DataSet

        If txtSearch.Text = "" Then
            Dim mysql As String = "SELECT PAPROLL_ID,PAPROLL_SERIAL FROM TBLPAPERROLL where STATUS = '2'"
            ds = LoadSQL(mysql, "TBLPAPERROLL")
        Else
            Dim mysql As String = "SELECT PAPROLL_ID,PAPROLL_SERIAL FROM TBLPAPERROLL where STATUS = '2' " & _
                                   "AND PAPROLL_SERIAL = '" & txtSearch.Text & "'"
            ds = LoadSQL(mysql, "TBLPAPERROLL")
        End If

        If ds.Tables(0).Rows.Count = 0 Then lvPapList.Items.Clear() : Exit Sub

        lvPapList.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvPapList.Items.Add(dr.Item("PAPROLL_ID"))
            lv.SubItems.Add(dr.Item("PAPROLL_SERIAL"))
        Next

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Load_Proll()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        production_report_End_paper_roll()
    End Sub

    Private Sub production_report_End_paper_roll()

        Dim mySql As String

        Dim fillData As String, rptSQL As New Dictionary(Of String, String)
        Dim subReportSQL As New Dictionary(Of String, String)

        fillData = "dsEmptyPapRoll"

        mySql = "SELECT P.PAPROLL_ID,P.PAPROLL_SERIAL,PL.PAPCUT_DESC, "
        mySql &= "SUM(PL.QUANTITY), P.TOTAL_LENGTH,P.REMAINING,"
        mySql &= "  P.REMAINING / P.TOTAL_LENGTH as remainings,Updated_at,PLE.EMULSION, "
        mySql &= " PLE.ADVANCE,PLE.LASTOUT "
        mySql &= "FROM TBLPAPERROLL P INNER JOIN TBL_PROLINE PL	"
        mySql &= "ON PL.PAPROLL_SERIAL = P.PAPROLL_SERIAL "
        mySql &= "INNER JOIN TBLPAPER_LISTEMPTY PLE ON PLE.PAPROLL_ID = P.PAPROLL_ID "
        mySql &= " WHERE P.STATUS='2' AND UPPER(P.PAPROLL_SERIAL) = UPPER('" & txtSearch.Text & "')"
        mySql &= "GROUP BY P.PAPROLL_ID,P.PAPROLL_SERIAL,PL.PAPCUT_DESC, "
        mySql &= "P.TOTAL_LENGTH,Remaining,P.Updated_at,PLE.EMULSION,PLE.ADVANCE,PLE.LASTOUT "
        rptSQL.Add(fillData, mySql)

        fillData = "dsAdj"
        mySql = " SELECT AD.PAPROLL_SERIAL,AD.REMARKS,AD.ADJUSTED_BY, AD.CREATED_AT,"
        mySql &= vbCrLf & " (AD.TOTAL_ADJUSTMENT)* 39.3701 AS T_ADJUSTMENT,"
        mySql &= vbCrLf & " AD.LENGTH_EXPOSE,PC.PAPCUT_DESCRIPTION,"
        mySql &= vbCrLf & " SUM(ADL.QUANTITY) AS QTY,ADL.ADJUSTMENT_TYPE"
        mySql &= vbCrLf & "  FROM TBLADJUSTMENT AD"
        mySql &= vbCrLf & " INNER JOIN TBLADJUSTMENT_LINE ADL ON ADL.ADJUSTMENT_ID = AD.ADJUSTMENTID"
        mySql &= vbCrLf & " INNER JOIN TBLPAPERCUT PC ON PC.PAPERCUT_ID = ADL.PAPERCUT_ID"
        mySql &= vbCrLf & "  WHERE UPPER(AD.PAPROLL_SERIAL) = UPPER('" & txtSearch.Text & "')"
        mySql &= vbCrLf & "  GROUP BY AD.PAPROLL_SERIAL,AD.REMARKS,AD.ADJUSTED_BY, AD.CREATED_AT,T_ADJUSTMENT,"
        mySql &= vbCrLf & "  AD.LENGTH_EXPOSE,PC.PAPCUT_DESCRIPTION,ADL.ADJUSTMENT_TYPE"
        ' rptSQL.Add(fillData, mySql)
        subReportSQL.Add(fillData, mySql)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("BranchName", BranchCode)
        rptPara.Add("txtUsername", CurrentUser)

        frmReport.MultiDbSetReport(rptSQL, "Reports\EmptyPaperRoll.rdlc", rptPara, 1, subReportSQL)
        frmReport.Show()


    End Sub
End Class