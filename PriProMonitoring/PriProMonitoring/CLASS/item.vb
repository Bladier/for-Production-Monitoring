Public Class item
    Dim mysql As String = ""
    Dim filldata As String = "item"
    Dim subtable As String = "tblitem_line"

#Region "Variables and Properties"
    Private _ItemID As Integer
    Public Property ID() As Integer
        Get
            Return _ItemID
        End Get
        Set(ByVal value As Integer)
            _ItemID = value
        End Set
    End Property

    Private _ItemCode As String
    Public Property ItemCode() As String
        Get
            Return _ItemCode
        End Get
        Set(ByVal value As String)
            _ItemCode = value
        End Set
    End Property

    Private _Description As String
    Public Property Descrition() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property



    Private _itemLines As CollectionItemLine
    Public Property itemLines() As CollectionItemLine
        Get
            Return _itemLines
        End Get
        Set(ByVal value As CollectionItemLine)
            _itemLines = value
        End Set
    End Property
#End Region

#Region "procedures and functions"
    Friend Sub lOadItem(ByVal ID As Integer)
        mysql = "SELECT * FROM ITEM WHERE ITEM_ID =" & ID
        Dim ds As DataSet = LoadSQL(mysql, "Item")

        If ds.Tables(0).Rows.Count Then
            MsgBox("Unable to load item", MsgBoxStyle.Information)
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            lOadItemByrow(dr)
        Next

    End Sub

    Private Sub lOadItemByrow(ByVal dr As DataRow)
        LoaditemsByRow(dr)
    End Sub

    Private Sub LoaditemsByRow(ByVal dr As DataRow)

        With dr
            _ItemID = .Item("Item_ID")
            _ItemCode = .Item("ItemCode")
            _Description = .Item("Description")
            _remarks = .Item("Remarks")
        End With
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        Dim mySql As String, ds As New DataSet
          With dr
            _ItemID = .Item("Item_ID")
            _ItemCode = .Item("ItemCode")
            _Description = .Item("Description")
            _remarks = .Item("Remarks")
        End With
        ' Load Item Specification
        mySql = String.Format("SELECT * FROM {0} WHERE Item_ID = {1} ORDER BY itemLine_ID", subtable, _ItemID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        _itemLines = New CollectionItemLine
        For Each dr In ds.Tables(SubTable).Rows
            Console.WriteLine(dr.Item("Papercut_ID"))
            Dim itmLine As New ItemLine
            itmLine.Load(dr)

            'Load Item Specification
            _itemLines.Add(itmLine)
        Next
    End Sub

    Friend Sub SaveItem()
        mysql = "SELECT * FROM ITEM WHERE Item_ID = " & _ItemID
        Dim ds As DataSet = LoadSQL(mysql, "Item")

        If ds.Tables(0).Rows.Count >= 1 Then
            MsgBox("Unable to save this item", MsgBoxStyle.Critical)
        End If

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("ItemCode") = _ItemCode
            .Item("Description") = _Description
            .Item("Remarks") = _remarks
        End With

        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)



        mysql = "SELECT * FROM " & filldata & " ORDER BY Item_ID DESC ROWS 1"
        ds = LoadSQL(mysql, filldata)
        _ItemID = ds.Tables(filldata).Rows(0).Item("Item_ID")

        For Each ItemLine As ItemLine In _itemLines
            ItemLine.Item_ID = _ItemID
            ItemLine.Save_itemLine()
        Next
    End Sub


    Public Sub UpdateITEM()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE IteM_ID = {1}", filldata, _ItemID)
        Dim ds As DataSet = LoadSQL(mySql, filldata)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(filldata).Rows(0)
            .Item("ITemcode") = _ItemCode
            .Item("Description") = _Description
            .Item("Remarks") = _remarks
        End With
        database.SaveEntry(ds, False)
    End Sub
#End Region
End Class
