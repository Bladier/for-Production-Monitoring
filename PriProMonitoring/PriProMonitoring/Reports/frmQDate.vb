Public Class frmQDate

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        production_report()
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



    'Private Sub production_report()
    '    Dim fillData As String = "dsProduction1"

    '    Dim mySql As String = "SELECT P.PAPROLL_SERIAL,SUM(PR.QUANTITY)AS P_total,PR.PAPCUT_DESC, "
    '    mySql &= "PR.CREATED_AT FROM TBL_PROLINE PR"
    '    mySql &= " INNER JOIN TBLPROLLANDPCUTS PRC ON PRC.PROLL_ID = PR.PAPID "
    '    mySql &= " LEFT JOIN TBLPAPERROLL P ON P.PAPROLL_ID = PRC.PROLL_ID "
    '    mySql &= " LEFT JOIN TBLPAPERCUT PC ON PC.PAPERCUT_ID = PRC.PCUT_ID "
    '    mySql &= String.Format("WHERE PR.CREATED_AT = '{0}' ", MonCal.SelectionStart.ToShortDateString)
    '    mySql &= "AND P.PAPROLL_SERIAL <> '' AND PR.PAPCUT_DESC = PC.PAPCUT_DESCRIPTION "
    '    mySql &= " GROUP BY P.PAPROLL_SERIAL,PR.PAPCUT_DESC,PR.CREATED_AT "

    '    Dim ds As DataSet = LoadSQL(mySql, "TBL_PROLINE")

    '    For Each dr As DataRow In ds.Tables(0).Rows
    '        Dim mysql1 As String = "SELECT * FROM TBLPAPERCUT WHERE PAPCUT_DESCRIPTION = '" & dr.Item("PAPCUT_DESC") & "'"
    '        Dim ds1 As DataSet = LoadSQL(mysql1, "TBLPAPERCUT")


    '    Next

    '    Dim rptPara As New Dictionary(Of String, String)
    '    rptPara.Add("txtMonthOf", "Date: " & MonCal.SelectionStart.ToLongDateString)
    '    rptPara.Add("BranchName", BranchCode)
    '    rptPara.Add("txtUsername", CurrentUser)

    '    frmReport.ReportInit(mySql, fillData, "Reports\prtProduction.rdlc", rptPara)
    '    frmReport.Show()
    'End Sub


    
End Class