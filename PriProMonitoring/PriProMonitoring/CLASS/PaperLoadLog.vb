Public Class PaperLoadLog
    Private MainTable As String = "tblpaperload_log"

#Region "Properties"
    Private _LogID As Integer
    Public Overridable Property LogID() As Integer
        Get
            Return _LogID
        End Get
        Set(ByVal value As Integer)
            _LogID = value
        End Set
    End Property

    Private _PaprollID As Integer
    Public Property PaprollID() As Integer
        Get
            Return _PaprollID
        End Get
        Set(ByVal value As Integer)
            _PaprollID = value
        End Set
    End Property

    Private _loaded_by As String
    Public Property loaded_by() As String
        Get
            Return _loaded_by
        End Get
        Set(ByVal value As String)
            _loaded_by = value
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

    Private _Remaining As Double
    Public Property Remaining() As Double
        Get
            Return _Remaining
        End Get
        Set(ByVal value As Double)
            _Remaining = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"
    Public Sub LoadLog(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM " & MainTable & " WHERE Log_ID = {0}", id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Failed to Log", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _LogID = .Item("Log_ID")
            _PaprollID = .Item("Paproll_ID")
            _loaded_by = .Item("USER")
            _Created_at = .Item("Loaded_at")
            _Remaining = .Item("Remaining")
        End With

    End Sub

    Public Sub SaveRoll()
        Dim mySql As String = "SELECT * FROM " & MainTable
        Dim ds As DataSet = LoadSQL(mySql, MainTable)


        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("Paproll_ID") = _PaprollID
            .Item("USER") = _loaded_by
            .Item("Loaded_at") = Now
            .Item("Remaining") = _Remaining
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        With dr
            _LogID = .Item("Log_ID")
            _PaprollID = .Item("Paproll_ID")
            _loaded_by = .Item("USER")
            _Created_at = .Item("Loaded_at")
            _Remaining = .Item("Remaining")
        End With

    End Sub
#End Region
End Class
