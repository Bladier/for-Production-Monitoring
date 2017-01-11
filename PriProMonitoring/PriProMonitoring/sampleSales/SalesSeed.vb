Module SalesSeed

    Private Itemcode() As String = {"DIP 00001", "DIP 000011", "DIW 00017", "DIW 000111", "DIP 00012"}
    Private Desc() As String = {"COMBO #1", "COMBO #2", "5R", "3R", "4R"}
    Private SalesID() As Integer = {1, 2, 3, 4, 5}
    Private status() As Integer = {0, 0, 0, 0, 0}
    Private QTY() As Integer = {1, 1, 2, 1, 1}

    Sub Populate()
        For i As Integer = 0 To Itemcode.Count - 1

            Dim tmpSales As New Sales
            With tmpSales
                .ItemCode = Itemcode(i)
                .Descrition = Desc(i)
                .SalesID = SalesID(i)
                .QTY = QTY(i)
                .status = status(i)

                .SaveSales()
            End With
        Next
    End Sub
End Module
