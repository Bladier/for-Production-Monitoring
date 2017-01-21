Imports System.Data.Odbc
Public Class frmMagazine
    Private SelectedMAG As Magazine
    Private SAVEPAPERCUT As PaperCut
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Save" Then
            SaveItems()
        Else
            ModifyItems()
        End If

    End Sub

    Private Sub SaveItems()
        If Not isValid() Then Exit Sub

        Dim mysql As String = "SELECT * FROM TBLMAGAZINE WHERE MAGCODE= '" & txtItemCode.Text & "'"
        Dim DS As DataSet = LoadSQL(mysql, "TBLMAGAZINE")
        If DS.Tables(0).Rows.Count = 1 Then
            MsgBox("Magazine already existed", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to save this magazine?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim MAGAZINESAVE As New Magazine
        Dim ColIPAPERCUT As New CollectionPaperCut

        With MAGAZINESAVE
            .MagItemcode = txtItemCode.Text
            .MagDescription = txtDescription.Text
        End With

        For Each row As DataGridViewRow In dgPCCUT.Rows
            SAVEPAPERCUT = New PaperCut
            With SAVEPAPERCUT
                .PapCutITemcode = row.Cells(1).Value
                .papcutDescription = row.Cells(2).Value
                .papcut = row.Cells(3).Value

                If row.Cells(1).Value = "" And row.Cells(2).Value = "" Then
                    Exit For
                End If
            End With
            ColIPAPERCUT.Add(SAVEPAPERCUT)
        Next
        MAGAZINESAVE.PaperCuts = ColIPAPERCUT
        MAGAZINESAVE.Save_Magazine()

        MsgBox("Magazine saved", MsgBoxStyle.Information)
        txtItemCode.Focus()
        clearfields()
        ReadOnlyFalse()
    End Sub

    Private Sub ModifyItems()
        If Not isValid() Then Exit Sub

        ReadOnlyFalse()
        txtItemCode.Enabled = False

        Dim ans As DialogResult = MsgBox("Do you want to Update Magazine?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim Colpapercut As New CollectionPaperCut
        Dim Magazinemodify As New Magazine

        With Magazinemodify
            .MagItemcode = txtItemCode.Text
            .MagDescription = txtDescription.Text
            .MagID = frmMagazineList.LBLID.Text
        End With

        Dim PapercutModify As New PaperCut
        For Each row As DataGridViewRow In dgPCCUT.Rows

            With PapercutModify
                .PapcutID = row.Cells(0).Value
                .PapCutITemcode = row.Cells(1).Value
                .papcutDescription = row.Cells(2).Value
                .papcut = row.Cells(3).Value

                If row.Cells(1).Value = "" And row.Cells(2).Value = "" Then
                    Exit For
                End If

            End With
            PapercutModify.mag_IDP = frmMagazineList.LBLID.Text
            PapercutModify.Update()
        Next
        Magazinemodify.UpdateMagazine()

        MsgBox("Magazine Updated", MsgBoxStyle.Information)

        btnSave.Enabled = True
        btnUpdate.Text = "&Edit"
        btnSave.Text = "&Save"
        clearfields()
        ReadOnlyFalse()
        txtItemCode.Enabled = True
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If btnUpdate.Text = "&Edit" Then
            btnUpdate.Text = "&Cancel"
            btnSave.Enabled = True
            btnSave.Text = "&Update"

            ReadOnlyFalse()
            txtItemCode.Enabled = False
        Else
            Dim ans As DialogResult = MsgBox("Do you want Cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            btnUpdate.Text = "&Edit"
            btnSave.Enabled = False
            btnSave.Text = "&Save"
            ReadOnlyFalse()
            txtItemCode.Enabled = True
            clearfields()
        End If
    End Sub


    Private Sub ReadOnlyTrue()
        txtDescription.ReadOnly = True
        For a As Integer = 0 To dgPCCUT.Rows.Count - 1
            dgPCCUT.Rows(a).ReadOnly = True
        Next
    End Sub

    Friend Sub ReadOnlyFalse()
        txtDescription.ReadOnly = False
        txtItemCode.ReadOnly = False
        For a As Integer = 0 To dgPCCUT.Rows.Count - 1
            dgPCCUT.Rows(a).ReadOnly = False
        Next

    End Sub
    Private Function isValid() As Boolean

        If txtItemCode.Text = "" Then txtItemCode.Focus() : Return False
        If txtDescription.Text = "" Then txtDescription.Focus() : Return False

        If dgPCCUT.CurrentCell.Value Is Nothing Then dgPCCUT.Focus() : Return False
        Return True
    End Function

    Private Sub frmMagazine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearfields()
    End Sub


    Friend Sub clearfields()
        txtDescription.Text = ""
        txtItemCode.Text = ""
        txtSEarch.Text = ""
        dgPCCUT.Rows.Clear()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSEarch.Text
        secured_str = DreadKnight(secured_str)
        frmMagazineList.SearchSelect(secured_str, FormName.frmmagazine)
        frmMagazineList.Show()
    End Sub


    Friend Sub LoadMagazine(ByVal mg As Magazine)
        If mg.MagItemcode = "" Then Exit Sub

        txtItemCode.Text = mg.MagItemcode
        txtDescription.Text = mg.MagDescription

        LoadPAPCUT(mg.MagID)
        ReadOnlyTrue()
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        txtItemCode.Enabled = False

    End Sub

    Friend Sub LoadPAPCUT(ByVal ID As Integer)
        Dim da As New OdbcDataAdapter
        Dim mySql As String = "SELECT * FROM TBLPAPERCUT WHERE MAG_IDP = '" & ID & "'"
        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim dr As DataRow

        dgPCCUT.Rows.Clear()
        For Each dr In ds.Tables(0).Rows
            AddItemPAPCUT(dr)
        Next
        ReadOnlyTrue()
        For a As Integer = 0 To dgPCCUT.Rows.Count - 1
            dgPCCUT.Rows(a).ReadOnly = True
        Next
        btnSave.Enabled = False
    End Sub

    Private Sub AddItemPAPCUT(ByVal PAP As DataRow)
        Dim TMPPAPER As New PaperCut
        TMPPAPER.lOAD_PaperCut_row(PAP)
        dgPCCUT.Rows.Add(TMPPAPER.PapcutID, TMPPAPER.PapCutITemcode, TMPPAPER.papcutDescription, TMPPAPER.papcut)
    End Sub

    Private Sub txtSEarch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSEarch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
   
  
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim row As ListViewItem = lvMag.Items.Add(txtItemCode.Text)
        row.SubItems.Add(txtDescription.Text)
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvMag.SelectedItems.Count = 0 Then Exit Sub
        lvMag.SelectedItems(0).Remove()
    End Sub

End Class