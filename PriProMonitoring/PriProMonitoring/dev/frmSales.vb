Public Class frmSales
    Private LastSaleID As String

    Dim tmplastSalesID As String
    Dim tmpdate As String


    Private Sub btnSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSales.Click
        SalesLoad()
    End Sub

    Friend Sub SalesLoad()
        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        LastSaleID = GetOption("LastSalesID")

        ' If LastSaleID <> "" Then GoTo NextLineToDo

        If CheckSalesIFNull() Then ' if new install POS
            GoTo nextToExit
        Else
            LastSaleID = GetOption("LastSalesID")

            If LastSaleID = "" Then
                tmplastSalesID = GetLastSaledID(0)
                tmpdate = GetLastSaledID(1)

                Dim updatemainTainance As New GetSalesID

                With updatemainTainance
                    .OPTVALUES = tmplastSalesID
                    .REMARKS = tmpdate
                End With
                updatemainTainance.UPDATE_MAINTAINANCE("LastSalesID ")

                MsgBox("Production has been set.", MsgBoxStyle.Information, "Production")
                Exit Sub
            End If
        End If
        '            Else
        '                GoTo NextLineToDo
        '            End If

        'NextLineToDo:
        '            Dim tmpRemarks As String = GetRemarks("LastSalesID")

        '            tmpRemarks = tmpRemarks.Remove(tmpRemarks.Length - 2)

        '            tmplastSalesID = GetLastEntry(0)
        '            tmpdate = GetLastEntry(1)

        '            If tmplastSalesID = "" Then _
        '                MsgBox("No new row data in sales", MsgBoxStyle.Information, "Sales") : Exit Sub

        '            Dim SaveSales As New Sales
        '            With SaveSales
        '                Dim POSsales As String = "SELECT I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,E.TRANSDATE," & _
        '                                         "I.QTY,E.DATESTAMP FROM POSITEM I " & _
        '                                        "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
        '                                        "INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO " & _
        '                                        "where E.DATESTAMP > '" & tmpRemarks & "'" & _
        '                                         "ORDER BY E.DATESTAMP ASC "

        '                Dim ds As DataSet = LoadSQLPOS(POSsales, "POSITEM")
        '                If ds.Tables(0).Rows.Count <= 0 Then Exit Sub

        '                Console.WriteLine("Count: " & ds.Tables(0).Rows.Count)

        '                For Each dr As DataRow In ds.Tables(0).Rows

        '                    .ItemCode = dr.Item("ItemNo")
        '                    .Descrition = dr.Item("Description")
        '                    .SalesID = dr.Item("ID")
        '                    .QTY = dr.Item("QTY")
        '                    .SaveSales()
        '                Next

        '                UpdateOptionSales("LastSalesID", tmplastSalesID, tmpdate)
        '            End With

        '            MsgBox("Sales Updated.", MsgBoxStyle.Information, "Sales")
        '        End If
nextToExit:
    End Sub

  

    ''' <summary>
    ''' Get Last ID and Transdate Initialization
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
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


        If ds Is Nothing Then
            ID = {"", ""}
            Return ID
        End If


        Dim tmpdate As Date = ds.Tables(0).Rows(0).Item("DATESTAMP")

        Console.WriteLine(ds.Tables(0).Rows(0).Item("ID"))

        ID = {ds.Tables(0).Rows(0).Item("ID"), tmpdate}

        Return ID
    End Function


    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class