Public Class Chamber
    Dim maintable As String = "tblmachine"

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _ChamberName As String
    Public Property ChamberName() As String
        Get
            Return _ChamberName
        End Get
        Set(ByVal value As String)
            _ChamberName = value
        End Set
    End Property

    Private _Tag As String
    Public Property Tag() As String
        Get
            Return _Tag
        End Get
        Set(ByVal value As String)
            _Tag = value
        End Set
    End Property

    Public Sub SaveChamber()
        Dim mysql As String = "SELECT * FROM " & maintable
        Dim ds As DataSet = LoadSQL(mysql, maintable)

        Dim dsnewrow As DataRow
        dsnewrow = ds.Tables(0).NewRow
        With dsnewrow
            .Item("Chamber_desc") = _ChamberName
            .Item("Chamber_tag") = _Tag
        End With
        ds.Tables(0).Rows.Add(dsnewrow)
        database.SaveEntry(ds)
    End Sub


    Private Chamber() As String = {"Chamber 1", "Chamber 2"}
    Private Tags() As String = {"B", "C"}
  

    Sub PoputlateChamber()
        For i As Integer = 0 To Chamber.Count - 1
            With Chamber
                ChamberName = Chamber(i)
                Tag = Tags(i)
                SaveChamber
            End With
        Next
    End Sub

    Private ChamberOnly1() As String = {"Chamber 1"}
    Private TagsOnly1() As String = {"B"}


    Sub PoputlateChamberOnlyOne()
        For i As Integer = 0 To ChamberOnly1.Count - 1
            With Chamber
                ChamberName = ChamberOnly1(i)
                Tag = TagsOnly1(i)
                SaveChamber()
            End With
        Next
    End Sub

End Class
