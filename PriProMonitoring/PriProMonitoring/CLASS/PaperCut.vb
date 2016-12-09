Public Class PaperCut

    Private MainTable As String = "tblPaperCUT"

#Region "Properties"
    Private _PapcutID As Integer
    Public Overridable Property PapcutID() As Integer
        Get
            Return _PapcutID
        End Get
        Set(ByVal value As Integer)
            _PapcutID = value
        End Set
    End Property

    Private _mag_IDP As Integer
    Public Property mag_IDP() As Integer
        Get
            Return _mag_IDP
        End Get
        Set(ByVal value As Integer)
            _mag_IDP = value
        End Set
    End Property

    Private _papcutDescription As String
    Public Property papcutDescription() As String
        Get
            Return _papcutDescription
        End Get
        Set(ByVal value As String)
            _papcutDescription = value
        End Set
    End Property

    Private _PapCutITemcode As String
    Public Property PapCutITemcode() As String
        Get
            Return _PapCutITemcode
        End Get
        Set(ByVal value As String)
            _PapCutITemcode = value
        End Set
    End Property

    Private _papcut As Double
    Public Property papcut() As Double
        Get
            Return _papcut
        End Get
        Set(ByVal value As Double)
            _PapCutITemcode = value
        End Set
    End Property

    Private _PaperCuts As CollectionPaperCut
    Public Property PaperCuts() As CollectionPaperCut
        Get
            Return _PaperCuts
        End Get
        Set(ByVal value As CollectionPaperCut)
            _PaperCuts = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"
    Public Sub LoadPapcutbyrow(ByVal dr As DataRow)
        With dr
            _PapcutID = .Item("Papcut_ID")
            _mag_IDP = .Item("MAG_IDP")
            _PapCutITemcode = .Item("papcut_itemcode")
            _papcutDescription = .Item("Papcut_description")
            _papcut = .Item("papercut")
        End With
    End Sub

    Friend Sub LoadPapcuts(ByVal id As Integer)
        Dim mySql As String = "SELECT * FROM tblpapercut WHERE Papcut_ID = " & id
        Dim ds As DataSet
        ds = LoadSQL(mySql, MainTable)

        For Each dr As DataRow In ds.Tables(0).Rows
            LoadPapcutbyrow(dr)
        Next

    End Sub
    Public Sub Save_papercut()
        Dim mySql As String = "SELECT * FROM " & MainTable
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("Mag_IDP") = _mag_IDP
            .Item("PAPCUT_ITEMCODE") = _PapCutITemcode
            .Item("PAPCUT_DESCRIPTION") = _papcutDescription
            .Item("PAPERCUT") = _papcut

        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Public Sub Update()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE Mag_IDP = {1}", MainTable, _mag_IDP)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            '.Item("Mag_IDP") = _mag_IDP
            .Item("Papcut_itemcode") = _PapCutITemcode
            .Item("papcut_Description") = _papcutDescription
            .Item("papercut") = _papcut
        End With
        database.SaveEntry(ds, False)
    End Sub


#End Region

End Class
