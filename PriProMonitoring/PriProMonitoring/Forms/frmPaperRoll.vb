Public Class frmPaperRoll
    Const pie As Double = 3.1416
    Const value As Integer = 1000
    Const value1 As Integer = 40
    Dim PAP As Hashtable

    Dim selected_paper As PaperRoll

    Friend Sub LoadPaper_Roll(ByVal pap As PaperRoll)
        If pap.PaperRollSErial = "" Then Exit Sub

        selected_paper = pap

        CboPaperRoll.Text = GetpapByID(pap.PAPID)
        txtSerial.Text = pap.PaperRollSErial
        txtOuterDiameter.Text = pap.OuterDiameter
        txtSpoolDiameter.Text = pap.SpoolDiameter
        txtPaperThickness.Text = pap.Thickness

        disable(false)
    End Sub


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If btnsave.Text = "&Save" Then
            SavePapRoll()
        Else
            UpdateS()
        End If

    End Sub

    Private Sub SavePapRoll()
        If Not isValid() Then Exit Sub


        Dim mysql As String = "SELECT * FROM TBLPAPERROLL WHERE PAPROLL_SERIAL = '" & txtSerial.Text & "'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        If ds.Tables(0).Rows.Count >= 1 Then MsgBox("Paper Roll Serial Already Existed", MsgBoxStyle.Critical) : Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this paper roll?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim PaprollSave As New PaperRoll
        With PaprollSave
            .PAPID = gETPAPID(CboPaperRoll.Text)
            .PaperRollSErial = txtSerial.Text
            .OuterDiameter = txtOuterDiameter.Text
            .Thickness = txtPaperThickness.Text
            .SpoolDiameter = txtSpoolDiameter.Text
            .TotalLength = CalcuteTotalength(txtOuterDiameter.Text, txtPaperThickness.Text, txtSpoolDiameter.Text)
            .Remaining = CalcuteTotalength(txtOuterDiameter.Text, txtPaperThickness.Text, txtSpoolDiameter.Text)
        End With

        PaprollSave.SaveRoll()

        MsgBox("Paper Roll Saved", MsgBoxStyle.Information, "Save")
        clearFields()

    End Sub

    Private Sub UpdateS()
        If Not isValid() Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to update this paper roll?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim Paproll_Update As New PaperRoll
        With Paproll_Update
            .PAPID = gETPAPID(CboPaperRoll.Text)
            .PaperRollSErial = txtSerial.Text
            .OuterDiameter = txtOuterDiameter.Text
            .Thickness = txtPaperThickness.Text
            .SpoolDiameter = txtSpoolDiameter.Text
            .TotalLength = CalcuteTotalength(txtOuterDiameter.Text, txtPaperThickness.Text, txtSpoolDiameter.Text)
            .Remaining = CalcuteTotalength(txtOuterDiameter.Text, txtPaperThickness.Text, txtSpoolDiameter.Text)
        End With

        Paproll_Update.Update_roll()

        MsgBox("Paper Roll updated", MsgBoxStyle.Information, "Update")
        clearFields()
        disable()
    End Sub

    Private Sub clearFields()
        CboPaperRoll.SelectedItem = Nothing
        txtOuterDiameter.Text = ""
        txtPaperThickness.Text = ""
        txtSerial.Text = ""
        txtSpoolDiameter.Text = ""
    End Sub

    Private Function isValid() As Boolean
        If CboPaperRoll.Text = "" Then CboPaperRoll.Focus() : Return False
        If txtSerial.Text = "" Then txtSerial.Focus() : Return False
        If txtOuterDiameter.Text = "" Then txtOuterDiameter.Focus() : Return False
        If txtPaperThickness.Text = "" Then txtPaperThickness.Focus() : Return False
        If txtSpoolDiameter.Text = "" Then txtSpoolDiameter.Focus() : Return False
        Return True
    End Function

    Private Sub frmPaperRoll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearch.Focus()
        lOADPAPROLL()

    End Sub


    Private Sub disable(Optional ByVal dis As Boolean = True)
        CboPaperRoll.Enabled = dis
        txtSerial.Enabled = dis
        txtOuterDiameter.Enabled = dis
        txtSpoolDiameter.Enabled = dis

        If dis Then
            txtPaperThickness.Enabled = Not dis
        Else
            txtPaperThickness.Enabled = dis
        End If
    End Sub


    Private Sub lOADPAPROLL()
        Dim mySql As String = "SELECT * FROM TBLPAPROLL_MAIN"
        Dim ds As DataSet = LoadSQL(mySql)

        PAP = New Hashtable
        CboPaperRoll.Items.Clear()
        Dim tmpName As String, tmpID As Integer

        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                tmpID = .Item("PAPID")
                tmpName = .Item("PAPCODE")
            End With
            PAP.Add(tmpID, tmpName)
            CboPaperRoll.Items.Add(tmpName)
        Next

    End Sub

    Private Function GetpapByID(ByVal id As Integer) As String
        For Each el As DictionaryEntry In PAP
            If el.Key = id Then
                Return el.Value
            End If
        Next

        Return "N/A"
    End Function

    Private Function gETPAPID(ByVal name As String) As Integer
        For Each el As DictionaryEntry In PAP
            If el.Value = name Then
                Return el.Key
            End If
        Next

        Return 0
    End Function

    Private Function CalcuteTotalength(ByVal outerDiam As Double, ByVal thckness As Double, ByVal spoolDiam As Double)
        Dim val As Double
        Dim OD As Double = outerDiam ^ 2
        Dim SD As Double = spoolDiam ^ 2

        Dim ODSD As Double = OD - SD
        Dim Val1 As Double = value * pie

        Dim ODSDPIE As Double = Val1 * ODSD
        Dim thck As Double = thckness * value1

        val = value * pie * (OD - SD) / (thckness * value1)
        '  1000*3.1416*(C4^2-C5^2)/(C6*40)
        Return val * 0.001
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtOuterDiameter_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOuterDiameter.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtSpoolDiameter_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSpoolDiameter.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtPaperThickness_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaperThickness.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtPaperThickness_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPaperThickness.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsave.PerformClick()
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
            Case Else

        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnsave.Text = "&Save" Then
            btnsave.Text = "&Update"
            btnEdit.Text = "&Cancel"

            disable(False)
            txtPaperThickness.Enabled = True
        Else
            Dim ans As DialogResult = MsgBox("Do you want Cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            btnEdit.Text = "&Edit"
            btnsave.Enabled = False
            btnsave.Text = "&Save"
            disable()
            clearFields()
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ModName = "Paper roll Edit"

        frmPaperRoll_List_Chamber.txtsearch1.Text = txtSearch.Text
        frmPaperRoll_List_Chamber.Show()


    End Sub

    Private Sub frmPaperRoll_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ModName = ""
    End Sub


    Private Function Get_Prints_To_Deduct(ByVal ser As String) As Double
        Dim mysql As String = "SELECT * FROM TBL_PROLINE WHERE "
    End Function
End Class