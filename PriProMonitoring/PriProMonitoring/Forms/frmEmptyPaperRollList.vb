Public Class frmEmptyPaperRollList
    Dim tmplist As PaperRoll
    Dim LoadPap_HT As New Hashtable

    Private Sub frmEmptyPaperRollList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fillData As String = "tblpaperRoll"
        Dim mysql As String = "SELECT * FROM " & fillData & " WHERE STATUS = '2' "
        Dim ds As DataSet = LoadSQL(mysql, fillData)

        LoadPap_HT = New Hashtable
        Lvlist.Items.Clear()

  
        tmplist = New PaperRoll

        For Each dr As DataRow In ds.Tables(0).Rows

            tmplist = New PaperRoll
            tmplist.LoadItem(dr.Item("PAProll_id"))
            AddPAP(tmplist)

            tmplist.LoadByRow(dr)

            LoadPap_HT.Clear()
            LoadPap_HT.Add(tmplist.PAPID, tmplist)
        Next

    End Sub


    Private Sub AddPAP(ByVal pap As PaperRoll)
        Dim papMain As New PAPERROLLMAIN

        Dim lv As ListViewItem = Lvlist.Items.Add(pap.PaprollID)
        lv.SubItems().Add(pap.PaperRollSErial)

        For Each ht As DictionaryEntry In LoadPap_HT
            tmplist = New PaperRoll
            tmplist = ht.Value

            papMain.LoadItem(ht.Key)

            MsgBox(ht.Key)


            lv.SubItems().Add(papMain.PAPERCODE)
            lv.SubItems().Add(papMain.PAPERDESCRIPTION)

        Next

    End Sub
End Class