Public Class PaperCut
    Public Class Magazine

        Public Class ItemClass
            Private MainTable As String = "tblPaperCUT"

#Region "Properties"
            Private _PapcutID As Integer
            Public Overridable Property _PapcutID() As Integer
                Get
                    Return _PapcutID
                End Get
                Set(ByVal value As Integer)
                    _PapcutID = value
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
                    _MagItemcode = .Item("MagItemcode")
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
                    tmpPapCut.LoadItemSpecs_row(dr)

                    'Load Item Specification

                    _PaperCuts.Add(tmpPapCut)
                Next
            End Sub

            Public Sub Save_ItemClass()
                Dim mySql As String = String.Format("SELECT * FROM tblItem WHERE ItemClass = '{0}'", _itemClassName)
                Dim ds As DataSet = LoadSQL(mySql, MainTable)

                If ds.Tables(0).Rows.Count = 1 Then
                    MsgBox("Class already existed", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(0).NewRow
                With dsNewRow
                    .Item("ItemClass") = _itemClassName
                    .Item("ItemCategory") = _category
                    .Item("Description") = _desc
                    .Item("isRenew") = IIf(_isRenew, 1, 0)
                    .Item("onHold") = IIf(_onHold, 1, 0)
                    .Item("Print_Layout") = _printLayout
                    .Item("Renewal_Cnt") = _Count
                    .Item("Created_At") = Now

                    .Item("Scheme_ID") = _interestScheme.SchemeID

                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                database.SaveEntry(ds)


                mySql = "SELECT * FROM tblItem ORDER BY ItemID DESC ROWS 1"
                ds = LoadSQL(mySql, MainTable)
                _itemID = ds.Tables(MainTable).Rows(0).Item("ItemID")

                For Each ItemSpec As ItemSpecs In ItemSpecifications
                    ItemSpec.ItemID = _itemID
                    ItemSpec.SaveSpecs()
                Next
            End Sub

            Public Sub LoadByRow(ByVal dr As DataRow)
                Dim mySql As String, ds As New DataSet
                With dr

                    _itemID = .Item("ItemID")
                    _itemClassName = .Item("ItemClass")
                    _category = .Item("ItemCategory")
                    If Not IsDBNull(.Item("Description")) Then _desc = .Item("Description")
                    _category = .Item("itemcategory")
                    _isRenew = .Item("isrenew")
                    _printLayout = .Item("print_layout")
                    _isRenew = If(.Item("isRenew") = 1, True, False)
                    _onHold = If(.Item("onHold") = 1, True, False)
                    _printLayout = .Item("Print_Layout")
                    _Count = .Item("Renewal_Cnt")
                    _created = .Item("Created_At")
                    _updated = .Item("Updated_At")
                    _interestScheme.LoadScheme(.Item("Scheme_ID"))
                End With
                ' Load Item Specification
                mySql = String.Format("SELECT * FROM {0} WHERE ItemID = {1} ORDER BY SpecsID", SubTable, _itemID)
                ds.Clear()
                ds = LoadSQL(mySql, SubTable)

                _itemSpecs = New CollectionItemSpecs
                For Each dr In ds.Tables(SubTable).Rows
                    Console.WriteLine(dr.Item("SpecsName"))
                    Dim tmpSpecs As New ItemSpecs
                    tmpSpecs.LoadItemSpecs_row(dr)

                    'Load Item Specification
                    _itemSpecs.Add(tmpSpecs)
                Next
            End Sub

            Public Sub Update()
                Dim mySql As String = String.Format("SELECT * FROM {0} WHERE ItemID = {1}", MainTable, _itemID)
                Dim ds As DataSet = LoadSQL(mySql, MainTable)

                If ds.Tables(0).Rows.Count <> 1 Then
                    MsgBox("Unable to update record", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                With ds.Tables(MainTable).Rows(0)
                    '.Item("ItemClass") = _itemClassName
                    .Item("ItemCategory") = _category
                    .Item("Description") = _desc
                    .Item("isRenew") = If(_isRenew, 1, 0)
                    .Item("onHold") = If(_onHold, 1, 0)
                    .Item("Print_Layout") = _printLayout
                    .Item("Renewal_Cnt") = _Count
                    .Item("Updated_At") = Now

                    .Item("Scheme_ID") = _interestScheme.SchemeID

                End With
                database.SaveEntry(ds, False)
            End Sub

            Public Function LASTITEMID() As Single
                Dim mySql As String = "SELECT * FROM TBLItem ORDER BY ItemID DESC"
                Dim ds As DataSet = LoadSQL(mySql)

                If ds.Tables(0).Rows.Count = 0 Then
                    Return 0
                End If
                Return ds.Tables(0).Rows(0).Item("ItemID")
            End Function
#End Region

        End Class

    End Class

End Class
