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

    Private _PAPID As Integer
    Public Property PAPID() As Integer
        Get
            Return _PAPID
        End Get
        Set(ByVal value As Integer)
            _PAPID = value
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

    Private _status As Integer
    Public Property status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
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
        mysql = "SELECT * FROM tblItem_line WHERE ID =" & ID
        Dim ds As DataSet = LoadSQL(mysql, "Item")

        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Unable to load sales line.", MsgBoxStyle.Information)
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            lOadItemByrow(dr)
        Next

    End Sub

    Private Sub lOadItemByrow(ByVal dr As DataRow)
        LoadsalesByRow(dr)
    End Sub

    Private Sub LoadsalesByRow(ByVal dr As DataRow)
        With dr
            _ID = .Item("ID")
            _ProductionID = .Item("Production_ID")
            _PAPID = .Item("PAPID")
            _Paproll_serial = .Item("PAPROLL_SERIAL")
            _Quantity = .Item("Quantity")
            _Papercut = .Item("PAPERCUT")
            _papcut_Desc = .Item("PAPCUT_DESC")
            _SubTotal_Length = .Item("SUBTOTAL_LENGTH")
            _Papcut_Code = .Item("PAPCUT_CODE")
            _created_at = .Item("CREATED_AT")
            _status = .Item("Status")
        End With
    End Sub

    Friend Sub SaveSalesLine()

        mysql = "SELECT * FROM " & filldata & " where ID = '" & _ID & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)
        Dim COUNTMAX As Integer = ds.Tables(0).Rows.Count

        If COUNTMAX = 1 Then
            With ds.Tables(0).Rows(0)
                .Item("PRODUCTION_ID") = _ProductionID
                .Item("PAPID") = _PAPID
                .Item("PAPROLL_SERIAL") = _Paproll_serial
                .Item("Quantity") = _Quantity
                .Item("PAPERCUT") = _Papercut
                .Item("PAPCUT_DESC") = _papcut_Desc
                .Item("SUBTOTAL_LENGTH") = _SubTotal_Length
                .Item("PAPCUT_CODE") = _Papcut_Code
                .Item("CREATED_AT") = Now
                .Item("Status") = 0
            End With
            database.SaveEntry(ds, False)

        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(filldata).NewRow
            With dsNewRow
                .Item("PRODUCTION_ID") = _ProductionID
                .Item("PAPID") = _PAPID
                .Item("PAPROLL_SERIAL") = _Paproll_serial
                .Item("Quantity") = _Quantity
                .Item("PAPERCUT") = _Papercut
                .Item("PAPCUT_DESC") = _papcut_Desc
                .Item("SUBTOTAL_LENGTH") = _SubTotal_Length
                .Item("PAPCUT_CODE") = _Papcut_Code
                .Item("CREATED_AT") = Now
                .Item("Status") = 0
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        End If
    End Sub

#End Region

End Class
