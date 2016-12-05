Public Class PaperCut
    Private MainTable As String = "tblpapercut"

#Region "Properties"
    Private _paperCutID As Integer
    Public Property PaperCutID() As Integer
        Get
            Return _paperCutID
        End Get
        Set(ByVal value As Integer)
            _paperCutID = value
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

    Private _papCut_itemCode As String
    Public Property PapCutItemcode() As String
        Get
            Return _papCut_itemCode
        End Get
        Set(ByVal value As String)
            _papCut_itemCode = value
        End Set
    End Property

    Private _PaperCut As String
    Public Property PaperCut() As String
        Get
            Return _PaperCut
        End Get
        Set(ByVal value As String)
            _PaperCut = value
        End Set
    End Property

    Private _papCut_Description As String
    Public Property PapCutDescription() As String
        Get
            Return _papCut_Description
        End Get
        Set(ByVal value As String)
            _papCut_Description = value
        End Set
    End Property

    Private _created As Date
    Public Property Created_At() As Date
        Get
            Return _created
        End Get
        Set(ByVal value As Date)
            _created = value
        End Set
    End Property

    Private _updated As Date
    Public Property Updated_At() As Date
        Get
            Return _updated
        End Get
        Set(ByVal value As Date)
            _updated = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"

    Public Sub LoadIPaperCUT(ByVal dr As DataRow)
        With dr
            _paperCutID = .Item("PaperCut_ID")
            _MagID = .Item("Mag_ID")
            _papCut_itemCode = .Item("PapCut_ItemCode")
            _papCut_Description = .Item("PapCut_Description")
            _PaperCut = .Item("PaperCut")
        End With
    End Sub

    Friend Sub LoadPapercut(ByVal id As Integer)
        Dim mySql As String = "SELECT * FROM tblpapercut WHERE papercut_ID = " & id
        Dim ds As DataSet
        ds = LoadSQL(mySql, MainTable)

        For Each dr As DataRow In ds.Tables(0).Rows
            LoadIPaperCUT(dr)
        Next

    End Sub

    Public Sub savePaperCut()
        Dim mySql As String = "SELECT * FROM " & MainTable
        '& " ROWS 1"
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("Mag_ID") = _MagID
            .Item("PapCut_ItemCode") = _papCut_itemCode
            .Item("PapCut_Description") = _papCut_Description
            .Item("PaperCut") = _PaperCut
            ' .Item("Created_At") = Now
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        With dr
            _paperCutID = .Item("PaperCut_ID")
            _MagID = .Item("Mag_ID")
            _papCut_itemCode = .Item("PapCut_ItemCode")
            _papCut_Description = .Item("PapCut_Description")
            _PaperCut = .Item("PaperCut")

        End With
    End Sub

    Public Sub Updatepapercut()
        Dim mySql As String = "SELECT * FROM " & MainTable & " WHERE PaperCut_ID= " & _paperCutID
        Dim ds As DataSet
        ds = LoadSQL(mySql, MainTable)
        If ds.Tables(0).Rows.Count >= 1 Then
            With ds.Tables(0).Rows(0)
                .Item("PapCut_ItemCode") = _papCut_itemCode
                .Item("PapCut_Description") = _papCut_Description
                .Item("PaperCut") = _PaperCut
                ' .Item("Updated_At") = Now
            End With
            database.SaveEntry(ds, False)
        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("Mag_ID") = _MagID
                .Item("PapCut_ItemCode") = _papCut_itemCode
                .Item("PapCut_Description") = _papCut_Description
                .Item("PaperCut") = _PaperCut
                .Item("Created_At") = Now
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        End If

    End Sub
#End Region

   

End Class