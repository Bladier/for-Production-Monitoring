Public Class PapRollAndPapCut
    Dim filldata As String = "tblprollANDpcuts"

#Region "Properties and Variables"
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _PapRollID As Integer
    Public Property PapRollID() As Integer
        Get
            Return _PapRollID
        End Get
        Set(ByVal value As Integer)
            _PapRollID = value
        End Set
    End Property

    Private _PapcutID As Integer
    Public Property PapcutID() As Integer
        Get
            Return _PapcutID
        End Get
        Set(ByVal value As Integer)
            _PapcutID = value
        End Set
    End Property
#End Region

    Friend Sub Save()
        Dim mysql As String = "SELECT * FROM " & filldata
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        Dim dsnewRow As DataRow
        dsnewRow = ds.Tables(0).NewRow

        With dsnewRow
            .Item("PROLL_ID") = _PapRollID
            .Item("PCUT_ID") = _PapcutID
        End With

        ds.Tables(0).Rows.Add(dsnewRow)
        database.SaveEntry(ds)

    End Sub

    Friend Sub loadbyrow(ByVal dr As DataRow)
        With dr
            _ID = .Item("PRPC_ID")
            _PapRollID = .Item("PROLL_ID")
            _PapcutID = .Item("PCUT_ID")
        End With
    End Sub

    Friend Sub LoadProllandPCuts(ByVal ID As Integer)
        Dim mysql As String = "SELECT * FROM TBLPROLLANDPCUTS WHERE PCUT_ID = '" & ID & "'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPROLLANDPCUTS")

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        For Each dr As DataRow In ds.Tables(0).Rows
            loadbyrow(dr)
        Next
    End Sub
End Class
