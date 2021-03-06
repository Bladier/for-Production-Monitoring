﻿Public Class frmItemLookUp
    Dim itemLine As Hashtable
    Dim fromOtherForm As Boolean = False
    Private frmOrig As formSwitch.FormName
    Dim tmpitem As item

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

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvItemLookUp.SelectedItems.Count <= 0 Then Exit Sub

        If lvItemLookUp.SelectedItems.Count = 0 Then
            lvItemLookUp.Items(0).Focused = True
        End If
      
        Dim itmID As Integer
        itmID = lvItemLookUp.FocusedItem.Text
        Console.WriteLine("ItemID: " & itmID)

        tmpitem = New item
        tmpitem.lOadItem(itmID)

        Label1.Text = tmpitem.ID

        frmItem.Loaditm(tmpitem)
        frmItem.Show()
        Me.Hide()
    End Sub



    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub


    Private Sub lvItemLookUp_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItemLookUp.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub lvItemLookUp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvItemLookUp.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSelect.PerformClick()
        End If
    End Sub
End Class