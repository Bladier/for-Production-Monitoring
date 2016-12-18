Imports Microsoft.Office.Interop
Public Class frmImportIMDD
    Dim ht_ImportedItems As New Hashtable
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdIMD.ShowDialog()

        Dim fileName As String = ofdIMD.FileName
        Dim isDone As Boolean = False

        If fileName = "" Then Exit Sub
        lblFilename.Text = fileName
        ClearFields()

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(fileName)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name


        Me.Enabled = False
        For cnt = 2 To MaxEntries
            Dim ImportedItem As New ItemData
            With ImportedItem
                .ItemCode = oSheet.Cells(cnt, 1).Value
                .Load_ItemCode()

                .Description = oSheet.Cells(cnt, 2).Value
                .Barcode = oSheet.Cells(cnt, 3).Value
                .Category = oSheet.Cells(cnt, 4).Value
                .SubCategory = oSheet.Cells(cnt, 5).Value
                .UnitofMeasure = oSheet.Cells(cnt, 6).Value
                .UnitPrice = If(Not IsNumeric(oSheet.Cells(cnt, 7).Value), 0, oSheet.Cells(cnt, 7).Value)
                .SalePrice = If(Not IsNumeric(oSheet.Cells(cnt, 8).Value), 0, oSheet.Cells(cnt, 8).Value)
                

            End With

            'AddItems(ImportedItem)
        Next
        Me.Enabled = True
        isDone = True


unloadObj:
        'Memory Unload
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        fileName = ""
        If isDone Then MsgBox("Item Loaded", MsgBoxStyle.Information)
    End Sub


    Private Sub ClearFields()
        ht_ImportedItems.Clear()
        lvIMD.Items.Clear()
    End Sub
End Class