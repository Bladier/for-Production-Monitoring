Public Class frmMagazine
    Private SelectedPaperuct As PaperCut

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Save" Then
            SaveItems()
        Else
            '  ModifyItems()
        End If

    End Sub

    Private Sub SaveItems()
        If Not isValid() Then Exit Sub

        Dim mysql As String = "SELECT * FROM TBLMAGAZINE WHERE MAGITEMCODE= '" & txtItemCode.Text & "'"
        Dim DS As DataSet = LoadSQL(mysql, "TBLMAGAZINE")
        If DS.Tables(0).Rows.Count = 1 Then
            MsgBox("Magazine already existed", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to save this magazine?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim MagazineSave As New magazine
        Dim Colpapcutss As New CollectionPaperCut
        With MagazineSave
            .MagItemcode = txtItemCode.Text
            .MagDescription = txtDescription.Text
        End With

        Dim savePapcut As New PaperCut
        For Each row As DataGridViewRow In dgPCCUT.Rows
            With savePapcut
                .PapCutITemcode = row.Cells(1).Value
                .papcutDescription = row.Cells(2).Value
                .papcut = row.Cells(3).Value

            End With
            Colpapcutss.Add(savePapcut)
        Next
        MagazineSave.PaperCuts = Colpapcutss
        MagazineSave.Save_Magazine()

        MsgBox("Magazine saved", MsgBoxStyle.Information)
        txtItemCode.Focus()
        clearfields()
    End Sub

    'Private Sub ModifyItems()
    '    If Not isValid() Then Exit Sub

    '    ReadOnlyFalse()
    '    txtItemCode.Enabled = False

    '    Dim ans As DialogResult = MsgBox("Do you want to Update Magazine?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
    '    If ans = Windows.Forms.DialogResult.No Then Exit Sub

    '    Dim Colpapercut As New CollectionPaperCut
    '    Dim Magazinemodify As New Magazine
    '    With Magazinemodify
    '        .magitemcode = txtClassification.Text
    '        .Category = txtCategory.Text
    '        .Description = txtDescription.Text
    '        .ID = SelectedItem.ID
    '    End With

    '    Dim PapercutModify As New PaperCut
    '    For Each row As DataGridViewRow In dgPCCUT.Rows

    '        With PapercutModify
    '            .SpecID = row.Cells(0).Value
    '            .ShortCode = row.Cells(1).Value
    '            .SpecName = row.Cells(2).Value
    '            .SpecType = row.Cells(3).Value
    '            .SpecLayout = row.Cells(4).Value
    '            .UnitOfMeasure = row.Cells(5).Value
    '            .isRequired = row.Cells(6).Value

    '        End With
    '        PapercutModify.mag_IDP = SelectedPaperuct.PapcutID
    '        SpecModify.UpdateSpecs()
    '    Next
    '    Magazinemodify.UpdateMagazine()

    '    MsgBox("Magazine Updated", MsgBoxStyle.Information)

    '    btnSave.Enabled = True
    '    btnUpdate.Text = "&Edit"
    '    btnSave.Text = "&Save"
    'End Sub

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
            ReadOnlyTrue()
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

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSEarch.Text
        secured_str = DreadKnight(secured_str)
        ' frmMagazineList.SearchSelect(secured_str, FormName.frmPawningV2_SpecsValue)
        'frmMagazineList.Show()
    End Sub


    Friend Sub LoadMagazine(ByVal mg As Magazine)
        If mg.MagItemcode = "" Then Exit Sub

        txtItemCode.Text = mg.MagItemcode
        txtDescription.Text = mg.MagDescription

        ReadOnlyTrue()
        btnSave.Enabled = False
        btnUpdate.Enabled = True
        txtItemCode.Enabled = False
    End Sub
End Class