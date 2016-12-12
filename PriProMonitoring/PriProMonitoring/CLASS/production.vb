Public Class production
    Dim filldata As String = "tblproduction"

#Region "Properties"
    Private _ID As Integer
    Public Overridable Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _MagID As Integer
    Public Overridable Property MagID() As Integer
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

    Private _itemcode As String
    Public Property itemcode() As String
        Get
            Return _itemcode
        End Get
        Set(ByVal value As String)
            _itemcode = value
        End Set
    End Property

    Private _DESCRIPTION As String
    Public Property DESCRIPTION() As String
        Get
            Return _DESCRIPTION
        End Get
        Set(ByVal value As String)
            _DESCRIPTION = value
        End Set
    End Property

    Private _QTY As Integer
    Public Property QTY() As Integer
        Get
            Return _QTY
        End Get
        Set(ByVal value As Integer)
            _QTY = value
        End Set
    End Property

    Private _Papercut As Double
    Public Property Papercut() As Double
        Get
            Return _Papercut
        End Get
        Set(ByVal value As Double)
            _Papercut = value
        End Set
    End Property

    Private _PapercutDesc As String
    Public Property PapercutDesc() As String
        Get
            Return _PapercutDesc
        End Get
        Set(ByVal value As String)
            _PapercutDesc = value
        End Set
    End Property

    Private _Subtotal_lngth As Double
    Public Property Subtotal_lngth() As Double
        Get
            Return _Subtotal_lngth
        End Get
        Set(ByVal value As Double)
            _Subtotal_lngth = value
        End Set
    End Property

    Private _Created_at As Date
    Public Property Created_at() As Date
        Get
            Return _Created_at
        End Get
        Set(ByVal value As Date)
            _Created_at = value
        End Set
    End Property

    Private _status As Integer
    Public Property status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property

    Private _papcut_itemcode As String
    Public Property papcut_Itemcode() As String
        Get
            Return _papcut_itemcode
        End Get
        Set(ByVal value As String)
            _papcut_itemcode = value
        End Set
    End Property

    Private _SALES_id As String
    Public Property SALES_id() As String
        Get
            Return _SALES_id
        End Get
        Set(ByVal value As String)
            _SALES_id = value
        End Set
    End Property

#End Region

#Region "Fuctions"
    Private Sub loadPRoduction(ByVal id As Integer)
        Dim mysql As String = "SELECT * FROM TBL"



    End Sub

    Friend Sub saveProduction()
        Dim mysql As String = "SELECT * FROM TBLPRODUCTION where sales_ID = '" & _SALES_id & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tblProduction")

        If ds.Tables(0).Rows.Count = 1 Then
            With ds.Tables(0).Rows(0)
                .Item("ItemCode") = _itemcode
                .Item("Description") = _DESCRIPTION
                .Item("Quantity") = _QTY
                .Item("created_at") = Now
                .Item("status") = 0
                .Item("papcut_itemcode") = _papcut_itemcode
            End With
            database.SaveEntry(ds, False)

        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("ItemCode") = _itemcode
                .Item("Description") = _DESCRIPTION
                .Item("Quantity") = _QTY
                .Item("created_at") = Now
                .Item("status") = 0
                .Item("papcut_itemcode") = _papcut_itemcode
                .Item("Sales_ID") = _SALES_id
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        End If
        
    End Sub
#End Region

End Class
