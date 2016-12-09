Public Class frmMagAndPapRollList

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        loadPapRollBYSEARCH()
    End Sub

    Private Sub frmMagAndPapRollList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        Else
            loadPapRoll()
        End If
    End Sub

    Private Sub loadPapRoll(Optional ByVal mysql As String = "SELECT PAPROLL_ID,MAG_IDS,PAPROLL_SERIAL, MAGDESCRIPTION" & _
                             " FROM TBLPAPERROLL P INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDS")
        Dim DS As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        LVPAPROLL.Items.Clear()
        For Each dr As DataRow In DS.Tables(0).Rows
            Dim lv As ListViewItem = LVPAPROLL.Items.Add(dr(0))
            lv.SubItems.Add(dr(1))
            lv.SubItems.Add(dr(2))
            lv.SubItems.Add(dr(3))
        Next

    End Sub

    Private Sub loadPapRollBYSEARCH()
        Dim mysql As String = "SELECT PAPROLL_ID,MAG_IDS,PAPROLL_SERIAL, MAGDESCRIPTION" & _
                                     " FROM TBLPAPERROLL P INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDS" _
                                    & " WHERE PAPROLL_SERIAL = '" & txtSearch.Text & "'"
        Dim DS As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        LVPAPROLL.Items.Clear()
        Console.WriteLine("SQL: " & mysql)
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count

        LVPAPROLL.Items.Clear()

        If MaxRow <= 0 Then
            Console.WriteLine("No paper roll List Found")
            txtSearch.SelectAll()
            LVPAPROLL.Items.Clear()
            Exit Sub
        End If

        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Item")
        For Each dr As DataRow In ds.Tables(0).Rows

            Dim lv As ListViewItem = LVPAPROLL.Items.Add(dr(0))
            lv.SubItems.Add(dr(1))
            lv.SubItems.Add(dr(2))
            lv.SubItems.Add(dr(3))
        Next
    End Sub

    Private Sub saveRollLog(ByVal rollID As Integer, ByVal loadedby As String)
        Dim mysql As String = "SELEC * FROM TBLPAPERLOAD_LOAD"
        Dim DS As DataSet = LoadSQL(mysql, "TBLPAPERLOAD_LOAD")

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

    End Sub
End Class