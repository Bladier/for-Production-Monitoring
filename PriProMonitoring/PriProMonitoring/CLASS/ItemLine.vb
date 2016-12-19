Public Class ItemLine
    Private MainTable As String = "tblITem_Line"

#Region "Properties"
    Private _itemLineID As Integer
    Public Overridable Property itemLineID() As Integer
        Get
            Return _itemLineID
        End Get
        Set(ByVal value As Integer)
            _itemLineID = value
        End Set
    End Property

    Private _Item_ID As Integer
    Public Property Item_ID() As Integer
        Get
            Return _Item_ID
        End Get
        Set(ByVal value As Integer)
            _Item_ID = value
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

    Private _QTY As Integer
    Public Property QTY() As Integer
        Get
            Return _QTY
        End Get
        Set(ByVal value As Integer)
            _QTY = value
        End Set
    End Property

    Private _Created_at As Date
    Public Property Created_at() As Date
        Get
            Return _Created_at
        End Get
        Set(ByVal value As Date)
            _Created_at = value
        End Set
    End Property

    Private _Updated_at As Date
    Public Property Updated_at() As Date
        Get
            Return _Updated_at
        End Get
        Set(ByVal value As Date)
            _Updated_at = value
        End Set
    End Property


#End Region

#Region "Procedures and Functions"
    Public Sub Load(ByVal dr As DataRow)
        With dr
            _itemLineID = .Item("ItemLine_ID")
            _Item_ID = .Item("Item_ID")
            _PaperCut_ID = .Item("PaperCut_ID")
            _QTY = .Item("QTY")
            _Created_at = .Item("Created_at")
            _Updated_at = .Item("Updated_at")
        End With
    End Sub

    Friend Sub LoadItemrow(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM tblitem_line WHERE itemLine_ID = {0}", id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        'If ds.Tables(0).Rows.Count <= 0 Then
        '    MsgBox("Failed to load Item", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        With ds.Tables(0).Rows(0)
            _itemLineID = .Item("ITemLine_ID")
            _Item_ID = .Item("Item_ID")
            _PaperCut_ID = .Item("PaperCut_ID")
            _QTY = .Item("QTY")
            _Created_at = .Item("Created_at")
            _Updated_at = .Item("Updated_at")
        End With
    End Sub

    Public Sub Save_itemLine()
        Dim isNew As Boolean = False

        Dim mySql As String = String.Format("SELECT * FROM {0} where {1} ", MainTable, "item_ID = " & _Item_ID)
        mySql &= "and papercuT_ID = '" & PaperCut_ID & "'"

        Dim ds As DataSet
        ds = New DataSet
        ds = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <= 0 Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(MainTable).NewRow
            With dsNewRow
                .Item("Item_ID") = _Item_ID
                .Item("PaperCut_ID") = _PaperCut_ID
                .Item("QTY") = _QTY
                .Item("created_at") = Now
            End With
            ds.Tables(MainTable).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
            isNew = True
        Else
            With ds.Tables(MainTable).Rows(0)
                .Item("PaperCut_ID") = _PaperCut_ID
                .Item("QTY") = _QTY
                .Item("Updated_at") = Now
            End With
            database.SaveEntry(ds, False)
        End If

    End Sub

    Public Sub Update_ItemLine()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE {1}= {2} ", MainTable, "itemLine_ID", _PaperCut_ID)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count = 1 Then
            With ds.Tables(MainTable).Rows(0)
                .Item("PaperCut_ID") = _PaperCut_ID
                .Item("QTY") = _QTY
                .Item("Updated_at") = _Updated_at
            End With
            database.SaveEntry(ds, False)
        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("Item_ID") = _Item_ID
                .Item("PaperCut_ID") = _PaperCut_ID
                .Item("QTY") = _QTY
                .Item("created_at") = Now
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        End If
    End Sub

    Public Sub Load_Itmline(ByVal Desc As String)
        Dim mysql = String.Format("SELECT * FROM tblItemLine WHERE papcut_Description = '{0}'", Desc)
        Dim ds As DataSet = New DataSet
        ds = LoadSQL(mysql)

        If ds.Tables(0).Rows.Count <> 1 Then
            'MsgBox("Failed to load ItemCode", MsgBoxStyle.Critical)
            Console.WriteLine("Failed to load paper cut description " & Desc)
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            Load(dr)
        Next
    End Sub

#End Region

End Class
