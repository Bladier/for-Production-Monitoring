Public Class PAPERROLLMAIN
    Private MainTable As String = "TBLPAPROLL_MAIN"
    Private SubTable As String = "tblPaperCut"

#Region "Properties"
    Private _PAPID As Integer
    Public Overridable Property PAPID() As Integer
        Get
            Return _PAPID
        End Get
        Set(ByVal value As Integer)
            _PAPID = value
        End Set
    End Property

    Private _PAPERCODE As String
    Public Property PAPERCODE() As String
        Get
            Return _PAPERCODE
        End Get
        Set(ByVal value As String)
            _PAPERCODE = value
        End Set
    End Property

    Private _PAPERDESCRIPTION As String
    Public Property PAPERDESCRIPTION() As String
        Get
            Return _PAPERDESCRIPTION
        End Get
        Set(ByVal value As String)
            _PAPERDESCRIPTION = value
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
    Public Sub Loadpap(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM TBLPAPROLL_MAIN WHERE PAPID = {0}", id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Failed to load Item", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _PAPID = .Item("PAPID")
            _PAPERCODE = .Item("PAPCODE")
            _PAPERDESCRIPTION = .Item("PAPDESC")
        End With


        mySql = String.Format("SELECT * FROM {0} WHERE PaperCut_ID = {1} ORDER BY PaperCut_ID", SubTable, _PAPID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        _PaperCuts = New CollectionPaperCut
        For Each dr As DataRow In ds.Tables(SubTable).Rows
            Console.WriteLine(dr.Item("PAPCUT_DESCRIPTION"))
            Dim tmpPapCut As New PaperCut
            tmpPapCut.lOAD_PaperCut_row(dr)


            _PaperCuts.Add(tmpPapCut)
        Next
    End Sub

    Public Sub Save_Magazine()
        Dim mySql As String = String.Format("SELECT * FROM " & MainTable & " WHERE PAPCODE = '{0}'", _PAPERCODE)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count = 1 Then
            With ds.Tables(MainTable).Rows(0)
                .Item("PAPCODE") = _PAPERCODE
                .Item("PAPDESC") = _PAPERDESCRIPTION
            End With
            database.SaveEntry(ds, False)

        Else

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("PAPCODE") = _PAPERCODE
                .Item("PAPDESC") = _PAPERDESCRIPTION
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        End If
    End Sub


    Public Function LoadPAPERID(ByVal PAPDESCR As String) As Integer
        Dim mysql = String.Format("SELECT * FROM " & MainTable & " WHERE PAPDESC = '{0}'", PAPDESCR)
        Dim ds As DataSet = New DataSet
        ds = LoadSQL(mysql)

        If ds.Tables(0).Rows.Count = 0 Then
            Console.WriteLine("Failed to load PAPER ROLL " & PAPDESCR)
            Return 0
        End If

        LoadByRow(ds.Tables(0).Rows(0))

        Return _PAPID
    End Function


    Public Sub LoadByRow(ByVal dr As DataRow)
        Dim mySql As String, ds As New DataSet
        With dr
            _PAPID = .Item("PAPID")
            _PAPERCODE = .Item("PAPCODE")
            _PAPERDESCRIPTION = .Item("PAPDESC")

        End With

    End Sub

    Public Sub UpdateMagazine()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE PAPID = {1}", MainTable, _PAPID)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            .Item("PAPCODE") = _PAPERCODE
            .Item("PAPDESC") = _PAPERDESCRIPTION
        End With
        database.SaveEntry(ds, False)
    End Sub
#End Region

   

End Class


