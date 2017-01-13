Public Class adjustment
    Dim mysql As String = ""
    Dim filldata As String = "tbladjustment"
    Dim subtable As String = "tblitem_line"

#Region "Variables and Properties"
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _PaprollID As Integer
    Public Property PaprollID() As Integer
        Get
            Return _PaprollID
        End Get
        Set(ByVal value As Integer)
            _PaprollID = value
        End Set
    End Property

    Private _PaprollSserial As String
    Public Property PaprollSserial() As String
        Get
            Return _PaprollSserial
        End Get
        Set(ByVal value As String)
            _PaprollSserial = value
        End Set
    End Property

    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

    Private _adjustedBy As String
    Public Property adjustedBy() As String
        Get
            Return _adjustedBy
        End Get
        Set(ByVal value As String)
            _adjustedBy = value
        End Set
    End Property

    Private _CreatedAT As Date
    Public Property CreatedAT() As Date
        Get
            Return _CreatedAT
        End Get
        Set(ByVal value As Date)
            _CreatedAT = value
        End Set
    End Property

    Private _UpdatedAT As Date
    Public Property UpdatedAT() As Date
        Get
            Return _UpdatedAT
        End Get
        Set(ByVal value As Date)
            _UpdatedAT = value
        End Set
    End Property

    Private _TotalAdjustment As Double
    Public Property TotalAdjustment() As Double
        Get
            Return _TotalAdjustment
        End Get
        Set(ByVal value As Double)
            _TotalAdjustment = value
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

    Private _AdjustmentLine As adjustmentCollection
    Public Property AdjustmentLines() As adjustmentCollection
        Get
            Return _AdjustmentLine
        End Get
        Set(ByVal value As adjustmentCollection)
            _AdjustmentLine = value
        End Set
    End Property
#End Region

#Region "procedures and functions"
    Friend Sub lOadAdjustment(ByVal ID As Integer)
        mysql = "SELECT * FROM " & filldata & " WHERE ITEM_ID =" & ID
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Unable to load adjustment", MsgBoxStyle.Information)
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            lOadAdjustmentByrow(dr)
        Next

    End Sub

    Private Sub lOadAdjustmentByrow(ByVal dr As DataRow)
        LoadAdjustsByRow(dr)
    End Sub

    Private Sub LoadAdjustsByRow(ByVal dr As DataRow)
        With dr
            _ID = .Item("AdjustmentID")
            _PaprollID = .Item("Paproll_ID")
            _PaprollSserial = .Item("PapRoll_serial")
            _remarks = IIf(IsDBNull(.Item("Remarks")), "", .Item("Remarks"))
            _adjustedBy = .Item("Adjusted_By")
            _CreatedAT = .Item("Created_at")
            _UpdatedAT = .Item("Updated_at")
            _TotalAdjustment = .Item("Total_Adjustment")
            _Emulsion = .Item("Emulsion")
            _Advance = .Item("Advance")
            _Lastout = .Item("lastout")
        End With
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        Dim mySql As String, ds As New DataSet
        With dr
            _ID = .Item("AdjustmentID")
            _PaprollID = .Item("Paproll_ID")
            _PaprollSserial = .Item("PapRoll_serial")
            _remarks = IIf(IsDBNull(.Item("Remarks")), "", .Item("Remarks"))
            _adjustedBy = .Item("Adjusted_By")
            _CreatedAT = .Item("Created_at")
            _UpdatedAT = .Item("Updated_at")
            _TotalAdjustment = .Item("Total_Adjustment")
            _Emulsion = .Item("Emulsion")
            _Advance = .Item("Advance")
            _Lastout = .Item("lastout")
        End With
        ' Load adjustment line
        mySql = String.Format("SELECT * FROM {0} WHERE Adjustment_ID = {1} ORDER BY ID", subtable, _ID)
        ds.Clear()
        ds = LoadSQL(mySql, subtable)

        _AdjustmentLine = New adjustmentCollection
        For Each dr In ds.Tables(subtable).Rows
            Console.WriteLine(dr.Item("ID"))
            Dim AdjLine As New adjustmentLine
            AdjLine.Load(dr)

            ' Load adjustment line
            _AdjustmentLine.Add(AdjLine)
        Next
    End Sub

    Friend Sub SaveAdjustment()
        Dim NextLine As Boolean
        Dim mySql As String = String.Format("SELECT * FROM " & filldata & " WHERE AdjustmentID = '{0}'", _ID)
        Dim ds As DataSet = LoadSQL(mySql, filldata)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("PapRoll_ID") = _PaprollID
            .Item("Paproll_serial") = _PaprollSserial
            .Item("Remarks") = _remarks
            .Item("Adjusted_By") = FrmMain.statusUser.Text
            .Item("Created_at") = _CreatedAT
            .Item("Total_adjustment") = _TotalAdjustment
            .Item("Emulsion") = _Emulsion
            .Item("Advance") = _Advance
            .Item("lastout") = _Lastout
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

        mySql = "SELECT * FROM " & filldata & " ORDER BY AdjustmentID DESC ROWS 1"
        ds = LoadSQL(mySql, filldata)
        _ID = ds.Tables(filldata).Rows(0).Item("AdjustmentID")


        For Each tmpAdjstmentLne As adjustmentLine In AdjustmentLines
            tmpAdjstmentLne.AdjustmentID = _ID

            If tmpAdjstmentLne.QTY = 0 Then
                On Error Resume Next
            Else
                tmpAdjstmentLne.Save_AdjLine()
            End If
        Next

    End Sub



    'Public Sub UpdateITEM()
    '    Dim mySql As String = String.Format("SELECT * FROM {0} WHERE IteM_ID = {1}", filldata, _ItemID)
    '    Dim ds As DataSet = LoadSQL(mySql, filldata)

    '    If ds.Tables(0).Rows.Count <> 1 Then
    '        MsgBox("Unable to update record", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If

    '    With ds.Tables(filldata).Rows(0)
    '        .Item("ITemcode") = _ItemCode
    '        .Item("Description") = _Description
    '        .Item("Remarks") = _remarks
    '    End With
    '    database.SaveEntry(ds, False)
    'End Sub

#End Region
End Class
