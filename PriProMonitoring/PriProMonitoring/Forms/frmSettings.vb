Public Class frmSettings
    Private locked As Boolean = IIf(GetOption("Locked") = "YES", True, False)

    Private LastSaleID As String

    Dim tmplastSalesID As String
    Dim tmpdate As String

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        databasePOS.dbNamePOS = GetOption("DatabasePOS")

        txtBranchCode.Text = GetOptionpPOS("Branch Code")
        txtBranchname.Text = GetOptionpPOS("Branch Name")
        txtAreacode.Text = GetOptionpPOS("Area Code")
        txtAreaname.Text = GetOptionpPOS("Area Name")
        txtVersion.Text = GetOptionpPOS("Version")

    End Sub

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        UpdateOptions("Branch Code", txtBranchCode.Text)
        UpdateOptions("Branch Name", txtBranchname.Text)
        UpdateOptions("Area Code", txtAreacode.Text)
        UpdateOptions("Area Name", txtAreaname.Text)
        UpdateOptions("Version", txtVersion.Text)

        GetLastSales() 'Setup sales

        MsgBox("New branch has been setup", MsgBoxStyle.Information, "Setup")
        Me.Close()
    End Sub

    Friend Sub GetLastSales()
        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        LastSaleID = GetOption("LastSalesID")

        If CheckSalesIFNull() Then Exit Sub

        LastSaleID = GetOption("LastSalesID")

        If LastSaleID = "" Then
            tmplastSalesID = GetLastSaledID(0)
            tmpdate = GetLastSaledID(1)
            UpdateOptionSales("LastSalesID ", tmplastSalesID, tmpdate)
        End If

    End Sub

    Friend Function GetLastSaledID() As String()

        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        Dim mysql As String = "select I.ID,I.itemno,E.TRANSDATE,E.DATESTAMP from POSITEM I " & _
                                "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                 "ORDER BY E.DATESTAMP DESC rows 1"

        Dim ds As DataSet = LoadSQLPOS(mysql, "POSITEM")

        Dim tmpdate As Date = ds.Tables(0).Rows(0).Item("DATESTAMP")

        Console.WriteLine(ds.Tables(0).Rows(0).Item("ID"))
        Dim ID As String() = {ds.Tables(0).Rows(0).Item("ID"), tmpdate}

        Return ID
    End Function

    Friend Function GetLastEntry() As String()
        Dim LastTimeStamp As String = GetRemarks("LastSalesID")
        If LastTimeStamp = "" Then Return Nothing
        Dim ID As String()

        LastTimeStamp = LastTimeStamp.Remove(LastTimeStamp.Length - 2)

        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        Dim mysql As String = "select I.ID,I.itemno,E.TRANSDATE,E.DATESTAMP from POSITEM I " & _
                                "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                 "where E.DATESTAMP > '" & LastTimeStamp & "' " & _
                                 "ORDER BY E.DATESTAMP DESC rows 1"

        Dim ds As DataSet = LoadSQLPOS(mysql, "POSITEM")


        If ds.Tables(0).Rows.Count = 0 Then
            ID = {"", ""}
            Return ID
        End If

        Dim tmpdate As Date = ds.Tables(0).Rows(0).Item("DATESTAMP")

        Console.WriteLine(ds.Tables(0).Rows(0).Item("ID"))

        ID = {ds.Tables(0).Rows(0).Item("ID"), tmpdate}

        Return ID
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class