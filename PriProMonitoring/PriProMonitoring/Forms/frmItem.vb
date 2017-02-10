Public Class frmItem
    Dim saveitem As item
    Dim saveitemLine As ItemLine
    Dim selectedItm As item

    Dim selectedPaperCut As New PaperCut

    Dim itm_line As Hashtable

    Friend Sub Loaditm(ByVal itm As item)
        If itm.ItemCode = "" Then Exit Sub

        txtCode.Text = itm.ItemCode
        txtDescription.Text = itm.Descrition
        txtRemarks.Text = itm.Remarks

        selectedItm = itm

        ReadOnlyTrue()
        btnSave.Enabled = False
        btnUpdate.Enabled = True


        Dim mysql As String = "SELECT P.PAPERCUT_ID,P.PAPCUT_CODE,P.PAPCUT_DESCRIPTION,L.QTY,L.ItemLine_ID " & _
                               "FROM TBLITEM_LINE L LEFT JOIN TBLPAPERCUT P ON L.PAPERCUT_ID=P.PAPERCUT_ID " & _
                               " WHERE L.ITEM_ID = '" & itm.ID & "'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLITEM_LINE")

        dgPapercuts.Rows.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                dgPapercuts.Rows.Add(.Item(0), .Item(1), .Item(2), .Item(3), .Item(4))
            End With
        Next

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmChannel.txtSearch.Text = txtSearch.Text
        frmChannel.Show()

        txtSearch.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Save" Then
            SaveItemsssss()
        Else
            ModifyItems()
        End If

    End Sub

    Private Sub SaveItemsssss()
        If Not isValid() Then Exit Sub

        Dim mysql As String = "SELECT * FROM ITEM WHERE ITEMCODE = '" & txtCode.Text & "'"
        Dim ds As DataSet = LoadSQL(mysql, "ITEM")

        If ds.Tables(0).Rows.Count >= 1 Then
            MsgBox("This item already existed", MsgBoxStyle.Critical, "Item")
        End If

        Dim ans As DialogResult = MsgBox("Do you want to save this item?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        saveitem = New item
        Dim CollItemLine As New CollectionItemLine

        With saveitem
            .ItemCode = txtCode.Text
            .Descrition = txtDescription.Text
            .Remarks = txtRemarks.Text
        End With

        For Each row As DataGridViewRow In dgPapercuts.Rows
            saveitemLine = New ItemLine
            With saveitemLine
                .PaperCut_ID = row.Cells(0).Value
                .QTY = row.Cells(3).Value
                .Created_at = Now

                If row.Cells(1).Value = "" _
                    And row.Cells(2).Value = "" And row.Cells(3).Value = "" Then
                    Exit For
                End If
            End With
            CollItemLine.Add(saveitemLine)
        Next
        saveitem.itemLines = CollItemLine
        saveitem.SaveItem()

        MsgBox("Item saved", MsgBoxStyle.Information)
        txtCode.Focus()
        clearfields()
        ReadOnlyFalse()
    End Sub

    Private Sub ModifyItems()
        If Not isValid() Then Exit Sub

        ReadOnlyFalse()
        txtCode.Enabled = False

        Dim ans As DialogResult = MsgBox("Do you want to Update item?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim CollItemLine As New CollectionItemLine
        Dim itemModify As New item

        With itemModify
            .ItemCode = txtCode.Text
            .Descrition = txtDescription.Text
            .Remarks = txtRemarks.Text
            .ID = frmItemLookUp.Label1.Text
        End With

        Dim ItemLineModidy As New ItemLine

        For Each row As DataGridViewRow In dgPapercuts.Rows
            With ItemLineModidy
                .PaperCut_ID = row.Cells(0).Value
                .QTY = row.Cells(3).Value
                .Updated_at = Now

                If row.Cells(1).Value = "" And row.Cells(2).Value = "" Then
                    Exit For
                End If

            End With

            ItemLineModidy.itemLineID = row.Cells(4).Value
            ItemLineModidy.Item_ID = itemModify.ID

            ItemLineModidy.Update_ItemLine()

        Next

        itemModify.UpdateITEM()

        MsgBox("Item Updated", MsgBoxStyle.Information)

        btnSave.Enabled = True
        btnUpdate.Text = "&Update"
        btnSave.Text = "&Save"
        clearfields()
        ReadOnlyFalse()
        txtCode.Enabled = True
        btnUpdate.Enabled = False
    End Sub


    Private Sub ReadOnlyTrue()
        txtDescription.ReadOnly = True
        For a As Integer = 0 To dgPapercuts.Rows.Count - 1
            dgPapercuts.Rows(a).ReadOnly = True
        Next
    End Sub

    Friend Sub ReadOnlyFalse()
        txtDescription.ReadOnly = False
        txtCode.ReadOnly = False
        For a As Integer = 0 To dgPapercuts.Rows.Count - 1
            dgPapercuts.Rows(a).ReadOnly = False
        Next

    End Sub

    Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCode.Text = ""
        txtDescription.Text = ""
        btnUpdate.Enabled = False
    End Sub

    Private Function isValid() As Boolean
        If txtCode.Text = "" Then txtCode.Focus() : Return False
        If txtDescription.Text = "" Then txtDescription.Focus() : Return False
        If dgPapercuts.Rows.Count <= 0 Then dgPapercuts.Focus() : Return False
        Return True
    End Function

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If btnUpdate.Text = "&Update" Then
            btnUpdate.Text = "&Cancel"
            btnSave.Enabled = True
            btnSave.Text = "&Update"

            ReadOnlyFalse()
            txtCode.Enabled = False
        Else
            Dim ans As DialogResult = MsgBox("Do you want Cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            btnUpdate.Text = "&Update"
            btnSave.Enabled = False
            btnSave.Text = "&Save"
            ReadOnlyFalse()
            txtCode.Enabled = True
            clearfields()
        End If
    End Sub


    Private Sub clearfields()
        txtCode.Text = ""
        txtDescription.Text = ""
        txtRemarks.Text = ""
        dgPapercuts.Rows.Clear()
    End Sub

    Private Sub btnSearchIMD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchIMD.Click

        Dim secured_str As String = txtSearchIMD.Text
        secured_str = DreadKnight(secured_str)
        frmItemLookUp.txtSearch.Text = Me.txtSearchIMD.Text.ToString
        frmItemLookUp.btnSearch.PerformClick()

        frmItemLookUp.SearchSelect(secured_str, FormName.frmitem)
        frmItemLookUp.Show()
        txtSearchIMD.Text = ""
    End Sub

    Private Sub txtSearchIMD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchIMD.KeyPress
        If isEnter(e) Then
            btnSearchIMD.PerformClick()
        End If
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub frmItem_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        FrmMain.Enabled = True
    End Sub

  
End Class