Public Class PaperRoll
    Private MainTable As String = "tblPaperroll"

#Region "Properties"
    Private _PaprollID As Integer
    Public Overridable Property PaprollID() As Integer
        Get
            Return _PaprollID
        End Get
        Set(ByVal value As Integer)
            _PaprollID = value
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

    Private _PaperRollSErial As String
    Public Property PaperRollSErial() As String
        Get
            Return _PaperRollSErial
        End Get
        Set(ByVal value As String)
            _PaperRollSErial = value
        End Set
    End Property


    Private _OuterDiameter As Double
    Public Property OuterDiameter() As Double
        Get
            Return _OuterDiameter
        End Get
        Set(ByVal value As Double)
            _OuterDiameter = value
        End Set
    End Property


    Private _Thickness As Double
    Public Property Thickness() As Double
        Get
            Return _Thickness
        End Get
        Set(ByVal value As Double)
            _Thickness = value
        End Set
    End Property


    Private _SpoolDiameter As Double
    Public Property SpoolDiameter() As Double
        Get
            Return _SpoolDiameter
        End Get
        Set(ByVal value As Double)
            _SpoolDiameter = value
        End Set
    End Property

    Private _TotalLength As Double
    Public Property TotalLength() As Double
        Get
            Return _TotalLength
        End Get
        Set(ByVal value As Double)
            _TotalLength = value
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

    Private _Addedby As String
    Public Property Addedby() As String
        Get
            Return _Addedby
        End Get
        Set(ByVal value As String)
            _Addedby = value
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

    Private _Updated_at As Date
    Public Property Updated_at() As Date
        Get
            Return _Updated_at
        End Get
        Set(ByVal value As Date)
            _Updated_at = value
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


#End Region

#Region "Functions and Procedures"
    Public Sub LoadProll(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM tblPaperRoll WHERE Paproll_ID = {0}", id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Failed to load Item", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _PaprollID = .Item("Paproll_ID")
            _PAPID = .Item("PAPIDS")
            _PaperRollSErial = .Item("papRoll_Serial")
            _OuterDiameter = .Item("Outer_diameter")
            _Thickness = .Item("Thickness")
            _SpoolDiameter = .Item("Spool_diameter")
            _TotalLength = .Item("Total_length")
            Created_at = .Item("Created_at")
            _Updated_at = .Item("Updated_at")
            _status = .Item("Status")
            _Remaining = .Item("Remaining")
        End With

    End Sub

    Public Sub SaveRoll()
        Dim mySql As String = String.Format("SELECT * FROM tblpaperRoll WHERE Paproll_serial = '{0}'", _PaperRollSErial)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("PAPIDS") = _PAPID
            .Item("paproll_serial") = _PaperRollSErial
            .Item("Outer_diameter") = _OuterDiameter
            .Item("thickness") = _Thickness
            .Item("spool_diameter") = _SpoolDiameter
            .Item("Total_Length") = _TotalLength
            .Item("Addedby") = FrmMain.statusUser.Text
            .Item("Created_at") = Now
            .Item("status") = 0
            .Item("Remaining") = _Remaining
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

    End Sub

    Friend Sub loadSerial(ByVal serial As String)
        Dim mysql As String = "SELECT * FROM " & MainTable & " WHERE UPPER(PAPROLL_SERIAL) = UPPER('" & serial & "')"
        Dim ds As DataSet = LoadSQL(mysql, MainTable)

        For Each dr As DataRow In ds.Tables(0).Rows
            LoadByRow(dr)
        Next
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)

        With dr

            _PaprollID = .Item("Paproll_ID")
            _PAPID = .Item("PAPIDS")
            _PaperRollSErial = .Item("Paproll_Serial")
            _OuterDiameter = .Item("Outer_Diameter")
            _Thickness = .Item("Thickness")
            _SpoolDiameter = .Item("Spool_Diameter")
            _TotalLength = .Item("Total_Length")
            _Addedby = .Item("Addedby")
            _Created_at = .Item("Created_AT")
            _Updated_at = .Item("Updated_At")
            _status = .Item("Status")
            _Remaining = .Item("Remaining")
        End With

    End Sub

    Public Sub Updatepaper()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE PAPROLL_SERIAL = '{1}'", MainTable, _PaperRollSErial)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim Remaining As Double = ds.Tables(0).Rows(0).Item("Remaining")

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            .Item("Remaining") = Remaining - _Remaining
            .Item("Updated_at") = Now
        End With
        database.SaveEntry(ds, False)
    End Sub

    Public Function LoadListEmptyPap() As DataRow
        Dim mysql As String = "SELECT * FROM " & MainTable & " WHERE STATUS = '2'"
        Dim ds As DataSet = LoadSQL(mysql, MainTable)
        For Each dr As DataRow In ds.Tables(0).Rows
            LoadByRow(dr)
        Next
        Return ds.Tables(0).Rows(0)
    End Function
#End Region
End Class
