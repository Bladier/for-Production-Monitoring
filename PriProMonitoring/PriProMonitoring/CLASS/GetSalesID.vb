Public Class GetSalesID
    Dim maintable As String = "tblmaintenance"

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _OPTKEYS As String
    Public Property OPTKEYS() As String
        Get
            Return _OPTKEYS
        End Get
        Set(ByVal value As String)
            _OPTKEYS = value
        End Set
    End Property

    Private _OPTVALUES As String
    Public Property OPTVALUES() As String
        Get
            Return _OPTVALUES
        End Get
        Set(ByVal value As String)
            _OPTVALUES = value
        End Set
    End Property

    Private _REMARKS As String
    Public Property REMARKS() As String
        Get
            Return _REMARKS
        End Get
        Set(ByVal value As String)
            _REMARKS = value
        End Set
    End Property

    Friend Sub UPDATE_MAINTAINANCE(ByVal str As String)
        Dim mysql As String = "SELECT * FROM " & maintable & " WHERE OPT_KEYS = '" & str & "'"
        Dim ds As DataSet = LoadSQL(mysql, maintable)

        With ds.Tables(maintable).Rows(0)
            .Item("OPT_VALUES") = _OPTVALUES
            .Item("REMARKS") = _REMARKS
        End With
        database.SaveEntry(ds, False)
    End Sub
End Class
