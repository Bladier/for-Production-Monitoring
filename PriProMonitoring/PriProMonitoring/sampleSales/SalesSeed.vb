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


    Private PAPIDS() As Integer = {"1", "2", "3", "4", "5"}
    Private Serial() As String = {"5RSilk_0001", "8RSilk_0001", "5RGL_0001", "4RGL0001", "12x18Silk_0001"}
    Private Diameter() As Double = {23.55, 20.35, 23.65, 21.25, 20.25}
    Private thickness() As Double = {0.2, 0.2, 0.2, 0.2, 0.2}
    Private spool() As Double = {8.6, 8.6, 8.5, 8.6, 8.5}
    Private totalLength() As Double = {192.55, 130.25, 185.25, 150.256, 150.25}
    Private addedby() As String = {CurrentUser, CurrentUser, CurrentUser, CurrentUser, CurrentUser}
    Private created_at() As Date = {Now, Now, Now, Now, Now}
    Private updated_at() As Date = {Now, Now, Now, Now, Now}
    Private status1() As String = {0, 0, 0, 0, 0}
    Private chamber() As String = {"", "", "", "", ""}
    Private remaining1() As Double = {192.55, 130.25, 185.25, 150.256, 150.25}

    Sub AddpaperRolls()
        CurrentUser = "Ellie Misiona"

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


    Private Itemcode_master() As String = {"DIW 00128", "DIW 00784", "DIW 00120", "DIW 00122", "DIS 00028", _
                                            "DIS 00027", "DIS 00026", "DIS 00025", "DIW 00131", "DIW 00785", "DIW 00126", _
                                           "DIW 00129", "DIP 00071", "DIP 00067", "DIP 00062", "DIS 00063", "DIS 00062", "DIS 00061", _
                                           "DIP 00065"}
    Private ItemName() As String = {"4R DIGITAL WALK-IN", "CUTE SIZE DIGITAL WALK-IN", "8X12 DIGITAL WALK-IN", "8X10 DIGITAL WALK-IN", "DIGITAL STUDIO ID COMBO 4  2PC", _
                                    "DIGITAL STUDIO ID COMBO 3  4PC", "DIGITAL STUDIO ID COMBO 2  6PC", "DIGITAL STUDIO ID COMBO 1 4PCS", _
                                    "2UPS DIGITAL WALK-IN", "WALLET SIZE DIGITAL WALK-IN", "5R DIGITAL WALK-IN", "3R DIGITAL WALK-IN", _
                                    "2UPS DIGITAL PHOTOGRAPHER", "3R DIGITAL PHOTOGRAPHER", "5R DIGITAL PHOTOGRAPHER", "PORTRAIT PERFECT 3", _
                                    "PORTRAIT PERFECT 2", "PORTRAIT PERFECT 1", "4R DIGITAL PHOTOGRAPHER"}
   

    Sub Populate_IMD()

        For i As Integer = 0 To Itemcode_master.Count - 1

            Dim tmpSales As New item
            With tmpSales
                .ItemCode = Itemcode_master(i)
                .Descrition = ItemName(i)
                .Initial_item()
            End With
        Next
    End Sub
End Module
