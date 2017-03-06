Public Class frmPaperRoll_EmptyList

    Private Sub frmPaperRoll_EmptyList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Proll()
    End Sub

    Private Sub Load_Proll()
        Dim ds As DataSet

        If txtSearch.Text = "" Then
            Dim mysql As String = "SELECT FIRST 100 PAPROLL_ID,PAPROLL_SERIAL FROM TBLPAPERROLL where STATUS = '2'"
            ds = LoadSQL(mysql, "TBLPAPERROLL")
        Else
            Dim mysql As String = "SELECT PAPROLL_ID,PAPROLL_SERIAL FROM TBLPAPERROLL where STATUS = '2' " & _
                                   "AND UPPER(PAPROLL_SERIAL) LIKE UPPER('%" & txtSearch.Text & "%')"
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
        If txtSearch.Text = "" Then MsgBox("Do selected paper roll" & vbCrLf & "Please select one in the list.", _
                                            MsgBoxStyle.Information, "Information") : Exit Sub
        If lvPapList.Items.Count = 0 Then Exit Sub

        production_report_End_paper_roll()
    End Sub

    Private Sub production_report_End_paper_roll()

        Dim fillData As String, rptSQL As New Dictionary(Of String, String)
        Dim mysql As String, subReportSQL As New Dictionary(Of String, String)

        fillData = "dsEmptyPapRoll"
        mySql = "SELECT P.PAPROLL_ID,P.PAPROLL_SERIAL,PL.PAPCUT_DESC, "
        mySql &= "SUM(PL.QUANTITY), P.TOTAL_LENGTH,P.REMAINING,"
        mySql &= "  P.REMAINING / P.TOTAL_LENGTH as remainings,Updated_at "
        mySql &= "FROM TBLPAPERROLL P INNER JOIN TBL_PROLINE PL	"
        mySql &= "ON PL.PAPROLL_SERIAL = P.PAPROLL_SERIAL "
        mySql &= " WHERE P.STATUS='2' AND UPPER(P.PAPROLL_SERIAL) = UPPER('" & txtSearch.Text & "')"
        mySql &= " GROUP BY P.PAPROLL_ID,P.PAPROLL_SERIAL,PL.PAPCUT_DESC, "
        mySql &= "P.TOTAL_LENGTH,Remaining,P.Updated_at "
        rptSQL.Add(fillData, mySql)

        fillData = "dsE_A_L"
        mysql = "SELECT P.PAPROLL_SERIAL,PLE.EMULSION,PLE.ADVANCE,PLE.LASTOUT,"
        mySql &= " PLE.UOM,PLE.CREATED_AT,PLE.DECLAREDBY"
        mySql &= " FROM TBLPAPERROLL P"
        mySql &= " INNER JOIN TBLPAPER_LISTEMPTY PLE ON PLE.PAPROLL_ID = P.PAPROLL_ID"
        mySql &= String.Format(" WHERE P.PAPROLL_SERIAL = '{0}'", txtSearch.Text)
        rptSQL.Add(fillData, mySql)

        'Sub Report
        fillData = "dsAdj"
        mySql = "SELECT AD.PAPROLL_SERIAL,AD.REMARKS,AD.ADJUSTED_BY,AD.CREATED_AT,"
        mysql &= " AD.TOTAL_ADJUSTMENT as T_ADJUSTMENT,AD.LENGTH_EXPOSE,PC.PAPCUT_DESCRIPTION,"
        mySql &= " ADL.QUANTITY as QTY,ADL.ADJUSTMENT_TYPE"
        mySql &= " FROM TBLADJUSTMENT AD"
        mySql &= " INNER JOIN TBLADJUSTMENT_LINE ADL ON ADL.ADJUSTMENT_ID = AD.ADJUSTMENTID"
        mySql &= " INNER JOIN TBLPAPERCUT PC ON PC.PAPERCUT_ID = ADL.PAPERCUT_ID"
        mySql &= " WHERE UPPER(AD.PAPROLL_SERIAL) = UPPER('" & txtSearch.Text & "')"
        mySql &= " ORDER BY CREATED_AT ASC"
        subReportSQL.Add(fillData, mySql)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("BranchName", BranchCode)
        rptPara.Add("txtUsername", CurrentUser)

        frmReport.MultiDbSetReport(rptSQL, "Reports\EmptyPaperRoll.rdlc", rptPara, 1, subReportSQL)
        frmReport.Show()

    End Sub

    Private Sub lvPapList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPapList.Click
        txtSearch.Text = lvPapList.SelectedItems(0).SubItems(1).Text
    End Sub
  
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub
End Class