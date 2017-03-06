Public Class frmDeclaration
    Dim tmppaperRoll As New PaperRoll
    Dim tmpTotal As Double = 0.0
    Dim getChamberNum As Integer = GetOption("Number Chamber")

    Dim SavepapEmp As New PaperListEmpty

    Private Sub txtEmulsion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub txtAdvance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub Watermark2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If lvPaperRoll.Items.Count = 0 Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to Post?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Declare")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub



        Dim tmpParRoll As New PaperRoll

        For Each itm As ListViewItem In lvPaperRoll.Items

            tmppaperRoll.loadSerial(itm.SubItems(0).Text)

            With SavepapEmp

                .PAPROLLID = tmppaperRoll.PaprollID

                If itm.SubItems(1).Text = "" Then
                    .EMULSION = 0.0
                Else
                    .EMULSION = itm.SubItems(1).Text * 12
                End If

                If itm.SubItems(2).Text = "" Then
                    .ADVANCE = 0.0
                Else
                    .ADVANCE = itm.SubItems(2).Text
                End If

                If itm.SubItems(3).Text = "" Then
                    .LASTOUT = 0.0
                Else
                    .LASTOUT = itm.SubItems(3).Text
                End If

                .UOM = "Inch"
                .cREATEDAT = Now
                .Declaredby = FrmMain.statusUser.Text
                .SavePAPEmPTY()

                SavepapEmp.EmpRoll(itm.SubItems(0).Text, "2") 'Status will become 2 it means paper roll is empty

                tmpTotal = .EMULSION + .ADVANCE + .LASTOUT

                DeductToPaperRoll(itm.SubItems(0).Text, tmpTotal) ' Deduct to paper roll
            End With
            savePapLog("Paper roll Empty", itm.SubItems(0).Text)
        Next

        MsgBox("Posted.", MsgBoxStyle.Information, "Post")
        lvPaperRoll.Items.Clear()
        cboPaperRollSerial.Items.Clear()
        frmDeclaration_Load(sender, e)
        clearFields()
    End Sub


    Private Sub savePapLog(ByVal mod_name As String, ByVal pap_roll As String)
        Dim savelog As New PaperLoadLog
        Dim seletect_paperRoll As New PaperRoll
        seletect_paperRoll.loadSerial(pap_roll)

        savelog.PaprollID = seletect_paperRoll.PaprollID
        savelog.loaded_by = CurrentUser
        savelog.Remaining = GetRemaining(pap_roll)
        savelog.Modname = mod_name
        savelog.SaveRoll()
    End Sub

    Private Function GetRemaining(ByVal pap_roll As String) As Double
        Dim value As Double
        Dim mysql As String = "SELECT * FROM TBLPAPERROLL " & _
            "WHERE PAPROLL_SERIAL = '" & pap_roll & " '"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")

        value = ds.Tables(0).Rows(0).Item("Remaining")

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If

        Return value
    End Function

    Private Sub clearFields()
        ModName = ""
        txtEmulsion.Text = ""
        txtAdvance.Text = ""
        txtlastout.Text = ""
        cboPaperRollSerial.SelectedItem = Nothing
    End Sub

    Private Sub Disabled()
        Me.MaximumSize = New Size(554, 436)
        Me.MinimumSize = Me.MaximumSize
    End Sub

    Private Sub frmDeclaration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Disabled()

        Dim tmplist As New PaperListEmpty
        For Each serial In tmplist.PopulateSerial()
            cboPaperRollSerial.Items.Add(serial)
        Next

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtlastout_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnPost.PerformClick()
        End If
    End Sub

    Private Function Check_if_loaded(ByVal serial As String) As Boolean
        Dim mysql As String = "SELECT * FROM TBLPAPERROLL WHERE PAPROLL_SERIAL = '" & serial & "' " & _
                              "and status = '1'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")

        Try
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            End If
        Catch ex As Exception
            Return True
        End Try
       
        Return True
    End Function


    Private Function CheckChamber() As Boolean
        Dim ret As Boolean = True

        Dim mysql As String = "SELECT * FROM TBLPAPERROLL WHERE STATUS <> 2 and chamber = 'B'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")

        Try
            If ds.Tables(0).Rows.Count = 0 Then
                Return Not ret
            End If
        Catch ex As Exception

            Return ret
        End Try

        SavepapEmp.EmpRoll(ds.Tables(0).Rows(0).Item("PAPROLL_SERIAL"), 0)

        Return True
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If cboPaperRollSerial.Text = "" Then cboPaperRollSerial.Focus() : Exit Sub
        If txtAdvance.Text = "" And txtEmulsion.Text = "" And txtlastout.Text = "" Then txtEmulsion.Focus() : Exit Sub


        If btnAdd.Text = "Update" Then
            lvPaperRoll.SelectedItems(0).SubItems(0).Text = cboPaperRollSerial.Text
            lvPaperRoll.SelectedItems(0).SubItems(1).Text = txtEmulsion.Text
            lvPaperRoll.SelectedItems(0).SubItems(2).Text = txtAdvance.Text
            lvPaperRoll.SelectedItems(0).SubItems(3).Text = txtlastout.Text
            btnAdd.Text = "Add"
            btnRemove.Enabled = True
            clearFields()
            Exit Sub
        End If

        For Each itm1 As ListViewItem In lvPaperRoll.Items
            If itm1.SubItems(0).Text = cboPaperRollSerial.Text Then Exit Sub
        Next

        Dim itm As ListViewItem = lvPaperRoll.Items.Add(cboPaperRollSerial.Text)
        itm.SubItems.Add(txtEmulsion.Text)
        itm.SubItems.Add(txtAdvance.Text)
        itm.SubItems.Add(txtlastout.Text)
        clearFields()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvPaperRoll.SelectedItems.Count = 0 Then Exit Sub
        lvPaperRoll.SelectedItems(0).Remove()
    End Sub

    Private Sub lvPaperRoll_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaperRoll.DoubleClick
        cboPaperRollSerial.Text = lvPaperRoll.SelectedItems(0).SubItems(0).Text
        txtEmulsion.Text = lvPaperRoll.SelectedItems(0).SubItems(1).Text
        txtAdvance.Text = lvPaperRoll.SelectedItems(0).SubItems(2).Text
        txtlastout.Text = lvPaperRoll.SelectedItems(0).SubItems(3).Text

        btnAdd.Text = "Update"
        btnRemove.Enabled = False
    End Sub

    Private Sub DeductToPaperRoll(ByVal PaperSerial As String, ByVal TotalLength As Double)
        Dim fillData As String = "TBLPAPERROLL"
        Dim mySql1 As String = "SELECT * FROM " & fillData & " WHERE Paproll_serial = '" & PaperSerial & "'"
        Dim ds As DataSet = LoadSQL(mySql1, fillData)

        Dim OldLength As Double = ds.Tables(0).Rows(0).Item("Remaining")
        Dim LengthP As Double = TotalLength * Meter

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables(fillData).Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("Remaining") = OldLength - LengthP
            End With

            database.SaveEntry(ds, False)
        End If
    End Sub

    Private Sub txtEmulsion_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmulsion.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtAdvance_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdvance.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtlastout_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlastout.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub lvPaperRoll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPaperRoll.KeyPress
        If isEnter(e) Then btnPost.PerformClick()
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                btnClose.PerformClick()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class