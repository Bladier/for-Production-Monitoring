Public Class adjustmentLine
    Private MainTable As String = "tblITem_Line"

#Region "Properties"
    Private _ID As Integer
    Public Overridable Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _AdjustmentID As Integer
    Public Property AdjustmentID() As Integer
        Get
            Return _AdjustmentID
        End Get
        Set(ByVal value As Integer)
            _AdjustmentID = value
        End Set
    End Property

    Private _PaperCut_ID As Integer
    Public Property PaperCut_ID() As Integer
        Get
            Return _PaperCut_ID
        End Get
        Set(ByVal value As Integer)
            _PaperCut_ID = value
        End Set
    End Property

    Private _PapcutCode As String
    Public Property PapcutCode() As String
        Get
            Return _PapcutCode
        End Get
        Set(ByVal value As String)
            _PapcutCode = value
        End Set
    End Property

    Private _QTY As Integer
    Public Property QTY() As Integer
        Get
            Return _QTY
        End Get
        Set(ByVal value As Integer)
            _QTY = value
        End Set
    End Property

    Private _adjustType As String
    Public Property adjustType() As String
        Get
            Return _adjustType
        End Get
        Set(ByVal value As String)
            _adjustType = value
        End Set
    End Property

    Private _Emulsion As Integer
    Public Property Emulsion() As Integer
        Get
            Return _Emulsion
        End Get
        Set(ByVal value As Integer)
            _Emulsion = value
        End Set
    End Property

    Private _Advance As Integer
    Public Property Advance() As Integer
        Get
            Return _Advance
        End Get
        Set(ByVal value As Integer)
            _Advance = value
        End Set
    End Property

    Private _Lastout As Double
    Public Property Lastout() As Double
        Get
            Return _Lastout
        End Get
        Set(ByVal value As Double)
            _Lastout = value
        End Set
    End Property


#End Region

#Region "Procedures and Functions"
    Public Sub Load(ByVal dr As DataRow)
        With dr
            _ID = .Item("ID")
            _AdjustmentID = .Item("Adjustment_ID")
            _PaperCut_ID = .Item("Papercut_ID")
            _PapcutCode = .Item("PapCut_code")
            _QTY = .Item("Quantity")
            _adjustType = .Item("Adjustment_Type")
            _Emulsion = .Item("Emulsion")
            _Advance = .Item("Advance")
            _Lastout = .Item("lastout")
        End With
    End Sub

    Friend Sub LoadItemrow(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM " & MainTable & " WHERE ID = {0}", id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Failed to load adjustment Line", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _ID = .Item("ID")
            _AdjustmentID = .Item("Adjustment_ID")
            _PaperCut_ID = .Item("Papercut_ID")
            _PapcutCode = .Item("PapCut_code")
            _QTY = .Item("Quantity")
            _adjustType = .Item("Adjustment_Type")
            _Emulsion = .Item("Emulsion")
            _Advance = .Item("Advance")
            _Lastout = .Item("lastout")
        End With
    End Sub

    Public Sub Save_AdjLine()

        Dim mySql As String = String.Format("SELECT * FROM {0} where {1} ", MainTable, "Adjustment_ID = " & _AdjustmentID)

        Dim ds As DataSet
        ds = New DataSet
        ds = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 0 Then _
            MsgBox("Failed to save this adjustment", MsgBoxStyle.Critical, "Adjustment") : Exit Sub

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(MainTable).NewRow
        With dsNewRow
            .Item("Adjustment_ID") = _AdjustmentID
            .Item("Papercut_ID") = _PaperCut_ID
            .Item("PapCut_code") = _PapcutCode
            .Item("Quantity") = _QTY
            .Item("Adjustment_Type") = _adjustType
            .Item("Emulsion") = _Emulsion
            .Item("Advance") = _Advance
            .Item("lastout") = _Lastout
        End With
        ds.Tables(MainTable).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

    End Sub

    'Public Sub Update_ItemLine()
    '    Dim mySql As String = String.Format("SELECT * FROM {0} WHERE {1}= {2} ", MainTable, "itemLine_ID", _PaperCut_ID)
    '    Dim ds As DataSet = LoadSQL(mySql, MainTable)

    '    If ds.Tables(0).Rows.Count = 1 Then
    '        With ds.Tables(MainTable).Rows(0)
    '            .Item("PaperCut_ID") = _PaperCut_ID
    '            .Item("QTY") = _QTY
    '            .Item("Updated_at") = _Updated_at
    '        End With
    '        database.SaveEntry(ds, False)
    '    Else
    '        Dim dsNewRow As DataRow
    '        dsNewRow = ds.Tables(0).NewRow
    '        With dsNewRow
    '            .Item("Item_ID") = _Item_ID
    '            .Item("PaperCut_ID") = _PaperCut_ID
    '            .Item("QTY") = _QTY
    '            .Item("created_at") = Now
    '        End With
    '        ds.Tables(0).Rows.Add(dsNewRow)
    '        database.SaveEntry(ds)
    '    End If
    'End Sub

#End Region

End Class
