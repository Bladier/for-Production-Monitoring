Public Class Sales

    Dim mysql As String = ""
    Dim filldata As String = "tblpro"


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

    Private _SalesID As String
    Public Property SalesID() As String
        Get
            Return _SalesID
        End Get
        Set(ByVal value As String)
            _SalesID = value
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

    Private _QTY As Integer
    Public Property QTY() As Integer
        Get
            Return _QTY
        End Get
        Set(ByVal value As Integer)
            _QTY = value
        End Set
    End Property

#End Region

#Region "procedures and functions"
    Friend Sub lOad_Pro(ByVal ID As String)
        mysql = "SELECT * FROM " & filldata & " WHERE SALESID = '" & ID & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Unable to load sales", MsgBoxStyle.Information)
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
            _ID = .Item("Production_ID")
            _ItemCode = .Item("ItemCode")
            _Description = .Item("Description")
            _SalesID = .Item("SalesID")
            _status = .Item("status")
            _QTY = .Item("QTY")

        End With
    End Sub

    Friend Sub SaveSales()

        mysql = "SELECT * FROM " & filldata & " where SalesID = '" & _SalesID & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)


        If ds.Tables(filldata).Rows.Count = 1 Then
            With ds.Tables(filldata).Rows(0)
                .Item("Itemcode") = _ItemCode
                .Item("Description") = _Description
                .Item("SalesID") = _SalesID
                .Item("QTY") = _QTY
            End With
            database.SaveEntry(ds, False)

        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(filldata).NewRow
            With dsNewRow
                .Item("Itemcode") = _ItemCode
                .Item("Description") = _Description
                .Item("SalesID") = _SalesID
                .Item("Status") = 0
                .Item("QTY") = _QTY
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)

        End If
    End Sub

    Public Sub update()

        mysql = "SELECT * FROM " & filldata & " where SalesID = '" & _SalesID & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)
        If ds.Tables(filldata).Rows.Count = 1 Then
            With ds.Tables(filldata).Rows(0)

                .Item("Status") = 1
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub
#End Region

End Class
