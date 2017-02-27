Imports Microsoft.Office.Interop
Public Class frmImportIMDD
    Private DbnAmePos As String

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadIMD.Click
        databasePOS.dbNamePOS = GetOption("DatabasePOS")

        If databasePOS.dbNamePOS = "ANOISIM.FDB" Or databasePOS.dbNamePOS = "" Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to load IMD data?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Me.Enabled = False
        Dim mysql As String = "SELECT ITEMNO,ITEMNAME FROM IMD"
        Dim ds As DataSet = LoadSQLPOS(mysql, "ItemMaster")
        Dim maxEntries As String = ds.Tables(0).Rows.Count

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim itmsave As New item
            itmsave.ItemCode = dr.Item("ITEMNO")
            itmsave.Load_ItemCode()

            With itmsave
                .ItemCode = dr.Item("ITEMNO")
                .Descrition = dr.Item("ITEMNAME")
                .SaveItem()
            End With

            pbProgressBar.Value = pbProgressBar.Value + 1
            maxEntries = pbProgressBar.Maximum
            Application.DoEvents()
            Label1.Text = String.Format("{0}%", ((pbProgressBar.Value / pbProgressBar.Maximum) * 100).ToString("F2"))
        Next

        If MsgBox("IMD Successfully loaded", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
            "Loading...") = MsgBoxResult.Ok Then pbProgressBar.Minimum = 0 : pbProgressBar.Value = 0 : Label1.Text = "0.00%"
        Me.Enabled = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim fileName As String = ofdIMD.FileName
        Dim isDone As Boolean = False

        If fileName = "" Then Exit Sub
        txtPath.Text = fileName


        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(fileName)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row


        Me.Enabled = False
        For cnt = 2 To MaxEntries
            Dim ImportedItem As New item

            If Not ImportedItem.CHeckIMD Then GoTo NextToExit

            With ImportedItem
                .ItemCode = oSheet.Cells(cnt, 1).Value
                ImportedItem.Load_ItemCode()

                Dim itmLineSave As New ItemLine
                Dim tmpPaperCut As New PaperCut

                tmpPaperCut.papcutDescription = oSheet.Cells(cnt, 2).Value
                tmpPaperCut.Load_pcuts()
                'itmLineSave.Load_Itmline()

                itmLineSave.Item_ID = .ID
                itmLineSave.PaperCut_ID = tmpPaperCut.PapcutID
                itmLineSave.QTY = oSheet.Cells(cnt, 3).Value

                itmLineSave.Save_itemLine()
            End With

        Next
        Me.Enabled = True
        isDone = True


unloadObj:

        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        fileName = ""
        If isDone Then MsgBox("Item Loaded", MsgBoxStyle.Information, "Import") : Exit Sub

NextToExit: MsgBox("Please load IMD First!", MsgBoxStyle.Critical, "Import")
    End Sub

    Private Sub btnBrowse_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdIMD.ShowDialog()
        txtPath.Text = ofdIMD.FileName
    End Sub
End Class