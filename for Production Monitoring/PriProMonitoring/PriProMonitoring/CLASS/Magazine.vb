
Public Class Magazine
    Private MainTable As String = "tblmagazine"
    Private SubTable As String = "tblpapercut"

#Region "Properties"
    Private _magID As Integer
    Public Overridable Property ID() As Integer
        Get
            Return _magID
        End Get
        Set(ByVal value As Integer)
            _magID = value
        End Set
    End Property

    Private _magItemCode As String
    Public Property MagItemCode() As String
        Get
            Return _magItemCode
        End Get
        Set(ByVal value As String)
            _magItemCode = value
        End Set
    End Property


    Private _magDescription As String
    Public Property MagDescription() As String
        Get
            Return _magDescription
        End Get
        Set(ByVal value As String)
            _magDescription = value
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

    Private _PaperCut As CollectionPaperCut
    Public Property paperCutDetails() As CollectionPaperCut
        Get
            Return _PaperCut
        End Get
        Set(ByVal value As CollectionPaperCut)
            _PaperCut = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"
    Public Sub LoadMagazine(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM tblmagazine WHERE mag_ID = {0}", id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Failed to load magazine", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _magID = .Item("Mag_ID")
            _magItemCode = .Item("magItemCode")
            _magDescription = .Item("MagDescription")
        End With

        ' Load paper cut
        mySql = String.Format("SELECT * FROM {0} WHERE mag_ID = {1} ORDER BY PaperCut_ID", SubTable, _magID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        _PaperCut = New CollectionPaperCut
        For Each dr As DataRow In ds.Tables(SubTable).Rows
            Console.WriteLine(dr.Item("PapCut_Description"))
            Dim tmppaperCut As New PaperCut
            tmppaperCut.LoadIPaperCUT(dr)

            'Load Paper Cut

            _PaperCut.Add(tmppaperCut)
        Next
    End Sub

    Public Sub Save_Magazine()
        Dim mySql As String = String.Format("SELECT * FROM tblMagazine WHERE magItemCode = '{0}'", _magItemCode)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("Magitemcode") = _magItemCode
            .Item("MagDescription") = _magDescription
            '.Item("Created-At") = Now
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)


        ds.Clear()
        mySql = "SELECT * FROM tblmagazine ORDER BY mag_ID DESC ROWS 1"
        ds = LoadSQL(mySql, MainTable)
        _magID = ds.Tables(MainTable).Rows(0).Item("Mag_ID")

        For Each PaperCUT As PaperCut In paperCutDetails
            PaperCUT.MagID = _magID
            PaperCUT.savePaperCut()
        Next
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        Dim mySql As String, ds As New DataSet
        With dr

            _magID = .Item("Mag_ID")
            _magItemCode = .Item("MagItemcode")
            _magDescription = .Item("magDescription")
          
        End With
        'load paper cut
        mySql = String.Format("SELECT * FROM {0} WHERE mag_ID = {1} ORDER BY papercut_ID", SubTable, _magID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        _PaperCut = New CollectionPaperCut
        For Each dr In ds.Tables(SubTable).Rows
            Console.WriteLine(dr.Item("PaperCut"))
            Dim tmpPaperCut As New PaperCut
            tmpPaperCut.LoadIPaperCUT(dr)

            'Load Paper Cut
            _PaperCut.Add(tmpPaperCut)
        Next
    End Sub

    Public Sub Update()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE Mag_ID = {1}", MainTable, _magID)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            .Item("MagItemcode") = _magItemCode
            .Item("magDescription") = _magDescription
        End With
        database.SaveEntry(ds, False)
    End Sub
#End Region

End Class
