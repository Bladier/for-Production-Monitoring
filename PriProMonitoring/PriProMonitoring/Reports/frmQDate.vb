Public Class frmQDate

    Enum ReportType As Integer
        Adjustment = 0
        Production = 1
    End Enum

    Friend RPTType As ReportType = ReportType.Adjustment

    Private Sub Generate()
        Select Case RPTType
            Case ReportType.Adjustment
                Adjustment_report()
            Case ReportType.Production
                production_report()
        End Select
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If cboReportType.Text = "" And cboReportType.Visible Then Exit Sub

        If cboReportType.Visible Then
            Select Case cboReportType.Text
                Case "Adjustment Report"
                    RPTType = ReportType.Adjustment
            End Select
        End If

        Generate()
    End Sub

    Private Sub production_report()
        Dim fillData As String = "dsProduction1"
        Dim mySql As String = "SELECT P.PAPROLL_SERIAL,SUM(PR.QUANTITY)AS P_total,PR.PAPCUT_DESC, "
        mySql &= "PR.CREATED_AT FROM TBL_PROLINE PR"
        mySql &= "  LEFT JOIN TBLPAPERROLL P ON P.PAPROLL_ID = PR.PAPID "
        mySql &= String.Format("WHERE PR.CREATED_AT = '{0}' ", MonCal.SelectionStart.ToShortDateString)
        mySql &= "AND P.PAPROLL_SERIAL <> '' "
        mySql &= " GROUP BY P.PAPROLL_SERIAL,PR.PAPCUT_DESC,PR.CREATED_AT "

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "Date: " & MonCal.SelectionStart.ToLongDateString)
        rptPara.Add("BranchName", BranchCode)
        rptPara.Add("txtUsername", CurrentUser)

        frmReport.ReportInit(mySql, fillData, "Reports\prtProduction.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub Adjustment_report()
        Dim start_Date As Date = GetFirstDate(MonCal.SelectionStart)
        Dim End_Date As Date = GetLastDate(MonCal.SelectionStart)
        Dim fillData As String = "dsAdjustment"

        Dim mySql As String = "SELECT AD.PAPROLL_SERIAL,SUM(AD.TOTAL_ADJUSTMENT)* 39.3701 AS T_ADJUSTMENT, AD.CREATED_AT, "
        mySql &= "AD.REMARKS,AD.ADJUSTED_BY,AD.UOM,AD.LENGTH_EXPOSE,PC.PAPCUT_DESCRIPTION,ADL.PAPCUT_CODE, "
        mySql &= "SUM(ADL.QUANTITY) AS QTY,ADL.ADJUSTMENT_TYPE "
        mySql &= "FROM TBLADJUSTMENT AD "
        mySql &= "INNER JOIN TBLADJUSTMENT_LINE ADL ON ADL.ADJUSTMENT_ID = AD.ADJUSTMENTID "
        mySql &= "INNER JOIN TBLPAPERCUT PC ON PC.PAPERCUT_ID = ADL.PAPERCUT_ID "
        mySql &= String.Format("WHERE AD.CREATED_AT BETWEEN '{0}' AND '{1}'", start_Date.ToShortDateString, End_Date.ToShortDateString)
        mySql &= "GROUP BY AD.PAPROLL_SERIAL, AD.CREATED_AT,AD.REMARKS,AD.ADJUSTED_BY,"
        mySql &= "AD.UOM,AD.LENGTH_EXPOSE,ADL.PAPERCUT_ID,PC.PAPCUT_DESCRIPTION,ADL.PAPCUT_CODE,ADL.ADJUSTMENT_TYPE "
        mySql &= "ORDER BY CREATED_AT ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "Date: " & MonCal.SelectionStart.ToLongDateString)
        rptPara.Add("BranchName", BranchCode)
        rptPara.Add("txtUsername", CurrentUser)

        frmReport.ReportInit(mySql, fillData, "Reports\rptAdjustment.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub production_report_End_paper_roll()
        Dim fillData As String = "dsProduction1"
        Dim mySql As String = "SELECT P.PAPROLL_SERIAL,SUM(PR.QUANTITY)AS P_total,PR.PAPCUT_DESC, "
        mySql &= "PR.CREATED_AT FROM TBL_PROLINE PR"
        mySql &= "  LEFT JOIN TBLPAPERROLL P ON P.PAPROLL_ID = PR.PAPID "
        mySql &= String.Format("WHERE PR.CREATED_AT = '{0}' ", MonCal.SelectionStart.ToShortDateString)
        mySql &= "AND P.PAPROLL_SERIAL <> '' "
        mySql &= " GROUP BY P.PAPROLL_SERIAL,PR.PAPCUT_DESC,PR.CREATED_AT "

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "Date: " & MonCal.SelectionStart.ToLongDateString)
        rptPara.Add("BranchName", BranchCode)
        rptPara.Add("txtUsername", CurrentUser)

        frmReport.ReportInit(mySql, fillData, "Reports\prtAdjustment.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Function NoFilter() As Boolean
        Select Case RPTType
            Case ReportType.Production
                Return True
        End Select

        Return False
    End Function

    Private Sub frmQDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If NoFilter() Then
            cboReportType.Visible = False
        Else
            cboReportType.Visible = True
        End If
    End Sub
End Class