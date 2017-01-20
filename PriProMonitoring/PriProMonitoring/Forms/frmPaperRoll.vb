Public Class frmPaperRoll
    Const pie As Double = 3.1416
    Const value As Integer = 1000
    Const value1 As Integer = 40
    Dim mag As Hashtable


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        SavePapRoll()
    End Sub

    Private Sub SavePapRoll()
        If Not isValid() Then Exit Sub

        Dim mysql As String = "SELECT * FROM TBLPAPERROLL WHERE PAPROLL_SERIAL = '" & txtSerial.Text & "'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERROLL")
        If ds.Tables(0).Rows.Count >= 1 Then MsgBox("Paper Roll Serial Already Existed", MsgBoxStyle.Exclamation) : Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this paper roll?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim PaprollSave As New PaperRoll
        With PaprollSave
            .MagID = GetMagID(CboMagazine.Text)
            .PaperRollSErial = txtSerial.Text
            .OuterDiameter = txtOuterDiameter.Text
            .Thickness = txtPaperThickness.Text
            .SpoolDiameter = txtSpoolDiameter.Text
            .TotalLength = CalcuteTotalength(txtOuterDiameter.Text, txtPaperThickness.Text, txtSpoolDiameter.Text)
            .Remaining = CalcuteTotalength(txtOuterDiameter.Text, txtPaperThickness.Text, txtSpoolDiameter.Text)
        End With

        PaprollSave.SaveRoll()

        MsgBox("Paper Roll Saved", MsgBoxStyle.Information)
        clearFields()

    End Sub

    Private Sub clearFields()
        CboMagazine.SelectedItem = Nothing
        txtOuterDiameter.Text = ""
        txtPaperThickness.Text = ""
        txtSerial.Text = ""
        txtSpoolDiameter.Text = ""
    End Sub

    Private Function isValid() As Boolean
        If CboMagazine.Text = "" Then CboMagazine.Focus() : Return False
        If txtSerial.Text = "" Then txtSerial.Focus() : Return False
        If txtOuterDiameter.Text = "" Then txtOuterDiameter.Focus() : Return False
        If txtPaperThickness.Text = "" Then txtPaperThickness.Focus() : Return False
        If txtSpoolDiameter.Text = "" Then txtSpoolDiameter.Focus() : Return False
        Return True
    End Function

    Private Sub frmPaperRoll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMagazine()

    End Sub

    Private Sub LoadMagazine()
        Dim mySql As String = "SELECT * FROM tblmagazine"
        Dim ds As DataSet = LoadSQL(mySql)

        mag = New Hashtable
        CboMagazine.Items.Clear()
        Dim tmpName As String, tmpID As Integer

        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                tmpID = .Item("mag_ID")
                tmpName = .Item("Magdescription")
            End With
            mag.Add(tmpID, tmpName)
            CboMagazine.Items.Add(tmpName)
        Next

    End Sub

    Private Function GetMagByID(ByVal id As Integer) As String
        For Each el As DictionaryEntry In mag
            If el.Key = id Then
                Return el.Value
            End If
        Next

        Return "N/A"
    End Function

    Private Function GetMagID(ByVal name As String) As Integer
        For Each el As DictionaryEntry In mag
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

    Private Sub txtSerial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerial.KeyPress
        DigitOnly(e)
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
End Class