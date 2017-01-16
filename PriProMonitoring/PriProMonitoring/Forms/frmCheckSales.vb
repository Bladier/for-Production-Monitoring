Public Class frmCheckSales

    Dim CheckLastID As String = ""
    Private Sub btnCheckSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckSales.Click


        'CheckLastID = GetOption("LastSalesID")
        'If CheckLastID = "" Then Exit Sub


        'If frmSales.GetLastEntry(1) = "" Or frmSales.GetLastEntry(0) = "" Then Exit Sub

        'If GetRemarks("LastSalesID") = frmSales.GetLastEntry(1) Then
        '    Exit Sub
        'Else
        '    If CheckLastID <> "" Then
        '        frmSales.SalesLoad()
        '    End If
        'End If
    End Sub

    Private Sub frmCheckSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class