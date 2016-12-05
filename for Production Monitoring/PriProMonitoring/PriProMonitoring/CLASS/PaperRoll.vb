
Public Class PaperRoll
    Private MainTable As String = "tblPaperRoll"


#Region "Properties"
    Private _PaperRollID As Integer
    Public Overridable Property PaperRollID() As Integer
        Get
            Return _PaperRollID
        End Get
        Set(ByVal value As Integer)
            _PaperRollID = value
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


    Private _PapRollSerial As String
    Public Property PapRollSerial() As String
        Get
            Return _PapRollSerial
        End Get
        Set(ByVal value As String)
            _PapRollSerial = value
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
    Public Property TotalLength As Double
        Get
            Return _TotalLength
        End Get
        Set(ByVal value As Double)
            _TotalLength = value
        End Set
    End Property

    Private _Addedby As Integer
    Public Property Addedby As Integer
        Get
            Return _Addedby
        End Get
        Set(ByVal value As Integer)
            _Addedby = value
        End Set
    End Property

    Private _created As Date
    Public Overridable Property created_at() As Date
        Get
            Return _created
        End Get
        Set(ByVal value As Date)
            _created = value
        End Set
    End Property

    Private _updated As Date
    Public Overridable Property updated_at() As Date
        Get
            Return _updated
        End Get
        Set(ByVal value As Date)
            _updated = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"
    'Public Sub LoadMagazine(ByVal id As Integer)
    '    Dim mySql As String = String.Format("SELECT * FROM tblpaperRoll WHERE PapRoll_ID = {0}", id)
    '    Dim ds As DataSet = LoadSQL(mySql, MainTable)

    '    If ds.Tables(0).Rows.Count <> 1 Then
    '        MsgBox("Failed to load magazine", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If

    '    With ds.Tables(0).Rows(0)
    '        _magID = .Item("Mag_ID")
    '        _magItemCode = .Item("magItemCode")
    '        _magDescription = .Item("MagDescription")
    '    End With

    '    ' Load paper cut
    '    mySql = String.Format("SELECT * FROM {0} WHERE mag_ID = {1} ORDER BY PaperCut_ID", SubTable, _magID)
    '    ds.Clear()
    '    ds = LoadSQL(mySql, SubTable)

    '    _PaperCut = New CollectionPaperCut
    '    For Each dr As DataRow In ds.Tables(SubTable).Rows
    '        Console.WriteLine(dr.Item("PapCut_Description"))
    '        Dim tmppaperCut As New PaperCut
    '        tmppaperCut.LoadIPaperCUT(dr)

    '        'Load Paper Cut

    '        _PaperCut.Add(tmppaperCut)
    '    Next
    'End Sub

    Public Sub SavePaperRoll()
        Dim mySql As String = String.Format("SELECT * FROM tblPaperRoll WHERE PapRoll_serial = '{0}'", _PapRollSerial)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("Mag_ID") = _MagID
            .Item("PapRoll_Serial") = _PapRollSerial
            .Item("Outer_Diameter") = _OuterDiameter
            .Item("Thickness") = _Thickness
            .Item("Spool_Diameter") = _SpoolDiameter
            .Item("Total_Length") = _TotalLength
            ' .Item("Addedby") = _magDescription
            .Item("Created_at") = Now

        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)

        With dr

            _PaperRollID = .Item("PapRoll_ID")
            _MagID = .Item("Mag_ID")
            _PapRollSerial = .Item("Paproll_serial")
            _OuterDiameter = .Item("OUter_Diameter")
            _Thickness = .Item("_Thickness")
            _SpoolDiameter = .Item("Spool_Diameter")
            _TotalLength = .Item("Total_Length")
            '_Addedby = .Item("Addedby")
            _created = .Item("Created_At")
            _updated = .Item("Updated_at")
        End With

    End Sub

    'Public Sub Update()
    '    Dim mySql As String = String.Format("SELECT * FROM {0} WHERE Mag_ID = {1}", MainTable, _magID)
    '    Dim ds As DataSet = LoadSQL(mySql, MainTable)

    '    If ds.Tables(0).Rows.Count <> 1 Then
    '        MsgBox("Unable to update record", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If

    '    With ds.Tables(MainTable).Rows(0)
    '        .Item("MagItemcode") = _magItemCode
    '        .Item("magDescription") = _magDescription
    '    End With
    '    database.SaveEntry(ds, False)
    'End Sub
#End Region

End Class
