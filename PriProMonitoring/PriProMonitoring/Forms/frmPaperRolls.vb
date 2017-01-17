Public Class frmPaperRolls
    Dim Chamber As Hashtable
  
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If LvPaperRollList.Items.Count = 0 Then Exit Sub
        If CboChamber.Text = "" Then Exit Sub
        If LvPaperRollList.SelectedItems.Count = 0 Then Exit Sub

        Dim count As Integer = frmLoadMagazine.lvPaproll.Items.Count

        If count = 2 Then GoTo nextlineTodo

        For Each it As ListViewItem In frmLoadMagazine.lvPaproll.Items
            Dim tmpChamTag As String = GetchamberTag(CboChamber.Text)

            If it.SubItems(3).Text = LvPaperRollList.SelectedItems(0).SubItems(2).Text _
                Or it.SubItems(4).Text = LvPaperRollList.SelectedItems(0).SubItems(3).Text Or _
                it.SubItems(2).Text = tmpChamTag Then Exit Sub
        Next

        Dim row As ListViewItem = frmLoadMagazine.lvPaproll.Items.Add(LvPaperRollList.Items(0).Text)

        row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(1).Text)
        row.SubItems.Add(GetchamberTag(CboChamber.Text))
        row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(2).Text)
        row.SubItems.Add(LvPaperRollList.SelectedItems(0).SubItems(3).Text)

nextlineTodo:
        frmLoadMagazine.Show()
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        loadPaperRollSearch(txtSearch.Text, txtSearch.Text)
    End Sub

    Private Sub frmPaperRolls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadChamber()
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
            Exit Sub
        End If
        loadPaperRoll()
    End Sub

    Private Sub loadPaperRollSearch(ByVal papSerial As String, Optional ByVal mag As String = "")
        Dim mysql As String = "SELECT P.PAPROLL_ID,P.MAG_IDS,M.MAGDESCRIPTION,P.PAPROLL_SERIAL FROM TBLPAPERROLL P " & _
                              "INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDS " & _
                              "WHERE P.PAPROLL_SERIAL = '" & papSerial & "' OR M.MAGDESCRIPTION = '" & mag & "'" & _
                              "and status <> '2'"
        Dim ds As DataSet = LoadSQL(mysql, "TBL")

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim count As Integer = ds.Tables(0).Rows.Count

        If ds.Tables(0).Rows.Count = 0 Then MsgBox(count & "paper roll found.", MsgBoxStyle.Information) : Exit Sub

        LvPaperRollList.Items.Clear()

        Dim tmpID As Integer = ds.Tables(0).Rows(0).Item("Paproll_ID")
        Dim lv As ListViewItem = LvPaperRollList.Items.Add(tmpID)
        lv.SubItems.Add(ds.Tables(0).Rows(0).Item("MAG_IDS"))
        lv.SubItems.Add(ds.Tables(0).Rows(0).Item("MAGDESCRIPTION"))
        lv.SubItems.Add(ds.Tables(0).Rows(0).Item("PAPROLL_SERIAL"))

        MsgBox(count & " paper roll found.", MsgBoxStyle.Information)
    End Sub


    Private Sub loadPaperRoll()
        Dim mysql As String = "SELECT P.PAPROLL_ID,P.MAG_IDS,M.MAGDESCRIPTION,P.PAPROLL_SERIAL FROM TBLPAPERROLL P " & _
                              "INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDS where P.STATUS <> '2'"

        Dim ds As DataSet = LoadSQL(mysql, "TBL")
        Dim count As Integer = ds.Tables(0).Rows.Count


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpID As Integer = dr.Item("Paproll_ID")
            Dim lv As ListViewItem = LvPaperRollList.Items.Add(tmpID)
            lv.SubItems.Add(dr.Item("MAG_IDS"))
            lv.SubItems.Add(dr.Item("MAGDESCRIPTION"))
            lv.SubItems.Add(dr.Item("PAPROLL_SERIAL"))
        Next

        MsgBox(count & " paper roll found.", MsgBoxStyle.Information)
    End Sub

    Private Sub LoadChamber()
        Dim mySql As String = "SELECT * FROM tblMachine"
        Dim ds As DataSet = LoadSQL(mySql)

        Chamber = New Hashtable
        CboChamber.Items.Clear()
        Dim tmpName As String, tmpTag As String

        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                tmpTag = .Item("Chamber_tag")
                tmpName = .Item("Chamber_Desc")
            End With
            Chamber.Add(tmpTag, tmpName)
            CboChamber.Items.Add(tmpName)
        Next

    End Sub

    Private Function GetchamberByTag(ByVal id As Integer) As String
        For Each el As DictionaryEntry In Chamber
            If el.Key = id Then
                Return el.Value
            End If
        Next

        Return "N/A"
    End Function

    Private Function GetchamberTag(ByVal name As String) As String
        For Each el As DictionaryEntry In Chamber
            If el.Value = name Then
                Return el.Key
            End If
        Next

        Return 0
    End Function

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub LvPaperRollList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LvPaperRollList.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub LvPaperRollList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LvPaperRollList.KeyPress
        If isEnter(e) Then btnSelect.PerformClick()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class