Imports System.Data.Odbc
Imports System.IO
Imports System.Text
Public Class frmMagazine
    Private Papercut As PaperCut
    Private Selectedmagazine As Magazine

    Friend Sub LoadMagazine(ByVal Mag As Magazine)
        Selectedmagazine = Mag
        txtItemcode.Text = Mag.MagItemCode
        txtDescription.Text = Mag.MagDescription

        LoadPaperCut(Mag.ID)
        btnEdit.Enabled = True
    End Sub

    Friend Sub LoadPaperCut(ByVal ID As Integer)
        Dim da As New OdbcDataAdapter
        Dim mySql As String = "SELECT * FROM tblPaperCut WHERE mag_ID = '" & ID & "'"
        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim dr As DataRow

        dgPaperCut.Rows.Clear()
        For Each dr In ds.Tables(0).Rows
            addPaperCut(dr)
        Next
        ReadOnlyTrue()
        For a As Integer = 0 To dgPaperCut.Rows.Count - 1
            dgPaperCut.Rows(a).ReadOnly = True
        Next
        btnSave.Enabled = False
    End Sub

    Private Sub addPaperCut(ByVal PaperCut As DataRow)
        Dim tmpPaperCut As New PaperCut
        tmpPaperCut.LoadIPaperCUT(PaperCut)
        dgPaperCut.Rows.Add(tmpPaperCut.PaperCutID, tmpPaperCut.PapCutItemcode, tmpPaperCut.PapCutDescription, tmpPaperCut.PaperCut.ToString)
    End Sub

    Private Sub clearFields()
        txtItemcode.Text = ""
        txtDescription.Text = ""
        dgPaperCut.Rows.Clear()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Save" Then
            SaveMAGAZINE()
        Else
            MODIFYMAGAZINE()
            btnSave.Text = "&Save"
            btnEdit.Text = "&Edit"
        End If
    End Sub

    Private Function isValid() As Boolean
        If txtItemcode.Text = "" Then txtItemcode.Focus() : Return False
        If txtDescription.Text = "" Then txtDescription.Focus() : Return False
        If dgPaperCut.CurrentCell.Value Is Nothing Then dgPaperCut.Focus() : Return False
        Return True
    End Function

    Private Sub SaveMAGAZINE()
        If Not isValid() Then Exit Sub
        Dim ans As DialogResult = MsgBox("Do you want to save this Item magazine?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim mySql As String = String.Format("SELECT * FROM tblmagazine WHERE magitemcode = '{0}'", txtItemcode.Text)
        Dim ds As DataSet = LoadSQL(mySql, "tblmagazine")

        If ds.Tables(0).Rows.Count = 1 Then
            MsgBox("magazine already existed", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim magazineSave As New Magazine
        Dim ColPaperCut As New CollectionPaperCut
        With magazineSave
            .MagItemCode = txtItemcode.Text
            .MagDescription = txtDescription.Text
        End With

        For Each row As DataGridViewRow In dgPaperCut.Rows
            Papercut = New PaperCut
            With Papercut
                .PapCutItemcode = row.Cells(1).Value
                .PapCutDescription = row.Cells(2).Value
                .PaperCut = row.Cells(3).Value

                If .PapCutItemcode Is Nothing Or .PapCutDescription Is Nothing _
                Then
                    Exit For
                End If
            End With
            ColPaperCut.Add(Papercut)
        Next

        magazineSave.paperCutDetails = ColPaperCut
        magazineSave.Save_Magazine()

        MsgBox("Magazine saved.", MsgBoxStyle.Information)
        clearFields()
    End Sub

    Private Sub MODIFYMAGAZINE()
        If Not isValid() Then Exit Sub

        txtItemcode.Enabled = False
        Dim ans As DialogResult = MsgBox("Do you want to Update this magazine?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim magazineModify As New Magazine

        Dim ColPaperCut As New CollectionPaperCut
        With magazineModify
            .MagItemCode = txtItemcode.Text
            .MagDescription = txtDescription.Text
            .ID = frmMagazineList.getMagID.Text
            .created_at = CurrentDate
        End With

        For Each row As DataGridViewRow In dgPaperCut.Rows
            Papercut = New PaperCut
            With Papercut
                .PaperCutID = row.Cells(0).Value
                .PapCutItemcode = row.Cells(1).Value
                .PapCutDescription = row.Cells(2).Value
                .PaperCut = row.Cells(3).Value

                If .PapCutItemcode Is Nothing Or .PapCutDescription Is Nothing _
                Then
                    Exit For
                End If
            End With
            Papercut.MagID = Selectedmagazine.ID
            Papercut.Updatepapercut()
        Next
        magazineModify.Update()

        MsgBox("Magazine updated.", MsgBoxStyle.Information)

        btnSave.Enabled = True
        clearFields()
    End Sub

    Friend Sub ReadOnlyFalse()
        txtItemcode.ReadOnly = False
        txtDescription.ReadOnly = False
        For a As Integer = 0 To dgPaperCut.Rows.Count - 1
            dgPaperCut.Rows(a).ReadOnly = False
        Next
    End Sub

    Private Sub ReadOnlyTrue()
        txtItemcode.ReadOnly = True
        txtDescription.ReadOnly = True

        For a As Integer = 0 To dgPaperCut.Rows.Count - 1
            dgPaperCut.Rows(a).ReadOnly = True
        Next
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "&Edit" Then
            btnEdit.Text = "&Cancel"
            btnSave.Enabled = True
            btnSave.Text = "&Update"

            ReadOnlyFalse()
            txtItemcode.Enabled = False
        Else
            Dim ans As DialogResult = MsgBox("Do you want Cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            btnEdit.Text = "&Edit"
            btnSave.Enabled = False
            btnSave.Text = "&Save"
            ReadOnlyTrue()
        End If
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtsearch.Text
        secured_str = DreadKnight(secured_str)
        frmMagazineList.SearchSelect(secured_str, FormName.frmMagazine)
        frmMagazineList.Show()
    End Sub

    Private Sub frmMagazine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearFields()
        btnEdit.Enabled=false
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class