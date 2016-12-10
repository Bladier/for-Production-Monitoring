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

    Private _MagID As Integer
    Public Property MagID() As Integer
        Get
            Return _MagID
        End Get
        Set(ByVal value As Integer)
            _MagID = value
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
    Public Sub LoadItem(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM tblPaperRoll WHERE Paproll_ID = {0}", id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Failed to load Item", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _PaprollID = .Item("Paproll_ID")
            _MagID = .Item("MAG_ID")
            _PaperRollSErial = .Item("papRoll_Serial")
            _OuterDiameter = .Item("Outer_diameter")
            _Thickness = .Item("Thickness")
            _SpoolDiameter = .Item("Spool_diameter")
            _TotalLength = .Item("Total_length")
            Created_at = .Item("Created_at")
            _Updated_at = .Item("Update_at")
            _status = .Item("Status")
        End With
    
    End Sub

    Public Sub SaveRoll()
        Dim mySql As String = String.Format("SELECT * FROM tblpaperRoll WHERE Paproll_serial = '{0}'", _PaperRollSErial)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        'If ds.Tables(0).Rows.Count = 1 Then
        '    MsgBox("Class already existed", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("Mag_IDS") = _MagID
            .Item("paproll_serial") = _PaperRollSErial
            .Item("Outer_diameter") = _OuterDiameter
            .Item("thickness") = _Thickness
            .Item("spool_diameter") = _SpoolDiameter
            .Item("Total_Length") = _TotalLength
            .Item("Addedby") = FrmMain.statusUser.Text
            .Item("Created_at") = Now
            .Item("status") = 0
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)

        With dr

            _PaprollID = .Item("Paproll_ID")
            _MagID = .Item("Mag_IDS")
            _OuterDiameter = .Item("Outer_Diameter")
            _Thickness = .Item("Thickness")
            _SpoolDiameter = .Item("Spool_Diameter")
            _TotalLength = .Item("Total_Length")
            _Addedby = .Item("Addedby")
            _Created_at = .Item("Created_AT")
            _Updated_at = .Item("Updated_At")
            _status = .Item("Status")
        End With

    End Sub

    Public Sub Updatepaper()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE status <> {1}", MainTable, _status)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim TotLength As Double = ds.Tables(0).Rows(0).Item("Total_Length")

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            .Item("Total_Length") = TotLength - _TotalLength
            .Item("Updated_at") = Now
        End With
        database.SaveEntry(ds, False)
    End Sub

#End Region
End Class
