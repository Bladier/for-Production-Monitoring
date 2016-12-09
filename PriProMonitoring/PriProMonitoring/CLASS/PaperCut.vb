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
            _papcut = value
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

#Region "Procedures and Functions"
    Public Sub lOAD_PaperCut_row(ByVal dr As DataRow)
        With dr
            _PapcutID = .Item("PAPerCUT_ID")
            _mag_IDP = .Item("MAG_IDP")
            _PapCutITemcode = .Item("papCUt_ITEMCODE")
            _papcutDescription = .Item("PAPCUT_DESCRIPTION")
            _papcut = .Item("PAPERCUT")
        End With
    End Sub

    Public Sub Load_PaperCUts(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE PAPerCUT_ID = {1}", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count <> 1 Then
            MsgBox("Unable to load Paper cuts", MsgBoxStyle.Critical)
            Exit Sub
        End If

        lOAD_PaperCut_row(ds.Tables(MainTable).Rows(0))
    End Sub

    Public Sub Save_Papercut()
        Dim mySql As String = String.Format("SELECT * FROM {0} ROWS 1", MainTable)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(MainTable).NewRow
        With dsNewRow
            .Item("MAG_IDP") = _mag_IDP
            .Item("PAPCUT_ITEMCODE") = _PapCutITemcode
            .Item("PAPCUT_DESCRIPTION") = _papcutDescription
            .Item("PAPERCUT") = _papcut
        End With
        ds.Tables(MainTable).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Public Sub Update()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE {1}= {2} ", MainTable, "PAPerCUT_ID", _PapcutID)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count = 1 Then
            With ds.Tables(MainTable).Rows(0)
                .Item("PAPCUT_ITEMCODE") = _PapCutITemcode
                .Item("PAPCUT_DESCRIPTION") = _papcutDescription
                .Item("PAPerCUT") = _papcut
            End With
            database.SaveEntry(ds, False)
        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("MAG_IDP") = _mag_IDP
                .Item("PAPCUT_ITEMCODE") = _PapCutITemcode
                .Item("PAPCUT_DESCRIPTION") = _papcutDescription
                .Item("PAPerCUT") = _papcut
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        End If
    End Sub
#End Region

End Class
