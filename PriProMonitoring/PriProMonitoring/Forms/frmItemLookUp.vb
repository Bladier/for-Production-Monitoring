Public Class frmItemLookUp
    Dim itemLine As Hashtable

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        Dim mySql As String = "SELECT * FROM ITEM WHERE "
        mySql &= String.Format("(UPPER (itemcode) LIKE UPPER('%{0}%') OR UPPER (description) LIKE UPPER('%{0}%')) ", secured_str)
        mySql &= "ORDER BY ITEM_ID ASC"

        LoadItem(mySql)
        MsgBox(String.Format("{0} item found.", lvItemLookUp.Items.Count), MsgBoxStyle.Information)
    End Sub


    Private Sub LoadItem(Optional ByVal mySql As String = "SELECT * FROM ITEM")

        Dim ds As DataSet = LoadSQL(mySql)

        itemLine = New Hashtable
        lvItemLookUp.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim itm As New item
            itm.LoadByRow(dr)
            AddItem(itm)

            itemLine.Add(itm.ID, itm)
        Next

    End Sub


    Private Sub AddItem(ByVal itm As item)
        Dim lv As ListViewItem = lvItemLookUp.Items.Add(itm.ID)
        lv.SubItems.Add(itm.ItemCode)
        lv.SubItems.Add(itm.Descrition)
        lv.SubItems.Add(itm.Remarks)
    End Sub

    Private Sub frmItemLookUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        Else
            LoadItem()
        End If

    End Sub
End Class