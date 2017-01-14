Public Class Magazine
    Private MainTable As String = "tblMagazine"
    Private SubTable As String = "tblPaperCut"

#Region "Properties"
    Private _MagID As Integer
    Public Overridable Property MagID() As Integer
        Get
            Return _MagID
        End Get
        Set(ByVal value As Integer)
            _MagID = value
        End Set
    End Property

    Private _MagItemcode As String
    Public Property MagItemcode() As String
        Get
            Return _MagItemcode
        End Get
        Set(ByVal value As String)
            _MagItemcode = value
        End Set
    End Property

    Private _MagDescription As String
    Public Property MagDescription() As String
        Get
            Return _MagDescription
        End Get
        Set(ByVal value As String)
            _MagDescription = value
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
    Public Sub LoadItem(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM tblItem WHERE MagID = {0}", id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Failed to load Item", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _MagID = .Item("MAG_ID")
            _MagItemcode = .Item("Magcode")
            _MagDescription = .Item("MagDescription")

        End With

        ' Load Item Specification
        mySql = String.Format("SELECT * FROM {0} WHERE PaperCut_ID = {1} ORDER BY PaperCut_ID", SubTable, _MagID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        _PaperCuts = New CollectionPaperCut
        For Each dr As DataRow In ds.Tables(SubTable).Rows
            Console.WriteLine(dr.Item("SpecsName"))
            Dim tmpPapCut As New PaperCut
            tmpPapCut.lOAD_PaperCut_row(dr)

            'Load Item Specification

            _PaperCuts.Add(tmpPapCut)
        Next
    End Sub

    Public Sub Save_Magazine()
        Dim mySql As String = String.Format("SELECT * FROM " & MainTable & " WHERE magcode = '{0}'", _MagItemcode)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("Magcode") = _MagItemcode
            .Item("MagDescription") = _MagDescription

        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)


        mySql = "SELECT * FROM " & MainTable & " ORDER BY Mag_ID DESC ROWS 1"
        ds = LoadSQL(mySql, MainTable)
        _MagID = ds.Tables(MainTable).Rows(0).Item("Mag_ID")

        For Each paPcutS As PaperCut In PaperCuts
            paPcutS.mag_IDP = _MagID
            paPcutS.Save_Papercut()
        Next
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        Dim mySql As String, ds As New DataSet
        With dr

            _MagID = .Item("mag_ID")
            _MagItemcode = .Item("Magcode")
            _MagDescription = .Item("MagDescription")

        End With
        ' Load paperuct
        mySql = String.Format("SELECT * FROM {0} WHERE mag_IDP = {1} ORDER BY papercut_ID", SubTable, _MagID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        _PaperCuts = New CollectionPaperCut
        For Each dr In ds.Tables(SubTable).Rows
            Console.WriteLine(dr.Item("papcut_description"))
            Dim tmppapcut As New PaperCut
            tmppapcut.lOAD_PaperCut_row(dr)

            'Load paperuct
            _PaperCuts.Add(tmppapcut)
        Next
    End Sub

    Public Sub UpdateMagazine()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE Mag_ID = {1}", MainTable, _MagID)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            .Item("Magcode") = _MagItemcode
            .Item("Magdescription") = _MagDescription
        End With
        database.SaveEntry(ds, False)
    End Sub
#End Region

End Class


