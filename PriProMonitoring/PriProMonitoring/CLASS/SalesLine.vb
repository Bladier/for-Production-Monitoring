Public Class SalesLine

    Dim mysql As String = ""
    Dim filldata As String = "tbl_Proline"


#Region "Variables and Properties"
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _ProductionID As Integer
    Public Property ProductionID() As Integer
        Get
            Return _ProductionID
        End Get
        Set(ByVal value As Integer)
            _ProductionID = value
        End Set
    End Property

    Private _MagID As Integer
    Public Property MagID() As Integer
        Get
            Return _MagID
        End Get
        Set(ByVal value As Integer)
            _MagID = value
        End Set

    End Property
    Private _Paproll_serial As String
    Public Property Paproll_serial() As String
        Get
            Return _Paproll_serial
        End Get
        Set(ByVal value As String)
            _Paproll_serial = value
        End Set
    End Property

    Private _Quantity As Integer
    Public Property Quantity() As Integer
        Get
            Return _Quantity
        End Get
        Set(ByVal value As Integer)
            _Quantity = value
        End Set
    End Property

    Private _Papercut As Double
    Public Property Papercuts() As Double
        Get
            Return _Papercut
        End Get
        Set(ByVal value As Double)
            _Papercut = value
        End Set
    End Property

    Private _papcut_Desc As String
    Public Property papcut_Desc() As String
        Get
            Return _papcut_Desc
        End Get
        Set(ByVal value As String)
            _papcut_Desc = value
        End Set
    End Property

    Private _SubTotal_Length As Double
    Public Property SubTotal_Length() As Double
        Get
            Return _SubTotal_Length
        End Get
        Set(ByVal value As Double)
            _SubTotal_Length = value
        End Set
    End Property

    Private _Papcut_Code As String
    Public Property Papcut_Code() As String
        Get
            Return _Papcut_Code
        End Get
        Set(ByVal value As String)
            _Papcut_Code = value
        End Set
    End Property

    Private _created_at As Date
    Public Property created_at() As Date
        Get
            Return _created_at
        End Get
        Set(ByVal value As Date)
            _created_at = value
        End Set
    End Property
#End Region

#Region "procedures and functions"
    Friend Sub lOadItem(ByVal ID As Integer)
        mysql = "SELECT * FROM ITEM WHERE ITEM_ID =" & ID
        Dim ds As DataSet = LoadSQL(mysql, "Item")

        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Unable to load item", MsgBoxStyle.Information)
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            ' lOadItemByrow(dr)
        Next

    End Sub

    'Private Sub lOadItemByrow(ByVal dr As DataRow)
    '    LoaditemsByRow(dr)
    'End Sub

    'Private Sub LoaditemsByRow(ByVal dr As DataRow)
    '    With dr
    '        _ID = .Item("Production_ID")
    '        _ItemCode = .Item("ItemCode")
    '        _Description = .Item("Description")
    '        _SalesID = .Item("SalesID")
    '        _status = .Item("status")
    '        _QTY = .Item("Quantity")

    '    End With
    'End Sub
    Friend Sub SaveSalesLine()

        mysql = "SELECT * FROM " & filldata & " where ID = '" & _ID & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(filldata).NewRow
        With dsNewRow
            .Item("PRODUCTION_ID") = _ProductionID
            .Item("MAG_ID") = _MagID
            .Item("PAPROLL_SERIAL") = _Paproll_serial
            .Item("Quantity") = _Quantity
            .Item("PAPERCUT") = _Papercut
            .Item("PAPCUT_DESC") = _papcut_Desc
            .Item("SUBTOTAL_LENGTH") = _SubTotal_Length
            .Item("PAPCUT_ITEMCODE") = _Papcut_Code
            .Item("CREATED_AT") = Now
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub


#End Region

End Class
