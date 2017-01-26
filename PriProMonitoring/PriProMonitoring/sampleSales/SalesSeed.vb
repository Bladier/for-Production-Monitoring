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


    Private PAPIDS() As Integer = {"1", "2", "3", "4"}
    Private Serial() As String = {"5RS0001", "8RS0001", "5RG0001", "4RS0001"}
    Private Diameter() As Double = {23.55, 20.35, 23.65, 21.25}
    Private thickness() As Double = {0.2, 0.2, 0.2, 0.2}
    Private spool() As Double = {8.5, 8.5, 8.5, 8.5}
    Private totalLength() As Double = {192.55, 130.25, 185.25, 150.256}
    Private addedby() As String = {"Ellie Misiona", "Ellie Misiona", "Ellie Misiona", "Ellie Misiona"}
    Private created_at() As Date = {Now, Now, Now, Now}
    Private updated_at() As Date = {Now, Now, Now, Now}
    Private status1() As String = {0, 0, 0, 0}
    Private chamber() As String = {"", "", "", ""}
    Private remaining1() As Double = {192.55, 130.25, 185.25, 150.256}

    Sub AddpaperRolls()
        For i As Integer = 0 To PAPIDS.Count - 1

            Dim tmppap As New PaperRoll
            With tmppap
                .PAPID = PAPIDS(i)
                .PaperRollSErial = Serial(i)
                .OuterDiameter = Diameter(i)
                .Thickness = thickness(i)
                .SpoolDiameter = spool(i)
                .TotalLength = totalLength(i)
                .Addedby = addedby(i)
                .Created_at = created_at(i)
                .Updated_at = updated_at(i)
                .status = status1(i)
                .Remaining = remaining1(i)

                .SaveRoll()
            End With
        Next
    End Sub
End Module
