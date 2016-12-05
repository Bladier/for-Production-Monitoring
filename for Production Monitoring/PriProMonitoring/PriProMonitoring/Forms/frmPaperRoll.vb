Public Class frmPaperRoll

    Const value As Double = 1000
    Const PIE As Double = 3.1416
    Const value1 As Double = 40

    Private magazine As Hashtable
    Private Selectedmagazine As Magazine

    Private Function isValid() As Boolean
        If cboMagazine.SelectedItem Is Nothing Then cboMagazine.Focus() : Return False
        If txtSerial.Text = "" Then txtSerial.Focus() : Return False
        If txtoutDiameter.Text = "" Then txtoutDiameter.Focus() : Return False
        If txtThickness.Text = "" Then txtThickness.Focus() : Return False
        If txtSpoolDiameter.Text = "" Then txtSpoolDiameter.Focus() : Return False
        Return True
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        savePaperRoll()
    End Sub

    Private Sub savePaperRoll()
        If Not isValid() Then Exit Sub
        If CDbl(txtoutDiameter.Text) < CDbl(txtSpoolDiameter.Text) Then MsgBox("Outer Diameter must be bigger than Spool Diameter!", MsgBoxStyle.Critical) : Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to save this Paper Roll?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim mySql As String = String.Format("SELECT * FROM tblpaperroll WHERE Paproll_Serial = '{0}'", txtSerial.Text)
        Dim ds As DataSet = LoadSQL(mySql, "tblpaperroll")

        If ds.Tables(0).Rows.Count = 1 Then
            MsgBox("Paper Roll already existed", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim PapRoll As New PaperRoll

        With PapRoll
            .MagID = GetMagID(cboMagazine.Text)
            .PapRollSerial = txtSerial.Text
            .OuterDiameter = txtoutDiameter.Text
            .Thickness = txtThickness.Text
            .SpoolDiameter = txtSpoolDiameter.Text
            .TotalLength = TotalLength(txtoutDiameter.Text, txtThickness.Text, txtSpoolDiameter.Text)
        End With

        PapRoll.SavePaperRoll()

        MsgBox("Paper Roll saved.", MsgBoxStyle.Information)
        clearFields()
    End Sub

    Private Sub clearFields()
        cboMagazine.SelectedItem = Nothing
        txtSerial.Text = ""
        txtoutDiameter.Text = ""
        txtThickness.Text = ""
        'txtSpoolDiameter.Text = ""
    End Sub

    Private Function TotalLength(ByVal OuterDiameter As Double, ByVal thickness As Double, ByVal spoolDiameter As Double) As Double
        Dim Total As Double

        Dim outerD As Double = OuterDiameter ^ 2
        Dim Spool As Double = spoolDiameter ^ 2
        Dim OUterSUBspool As Double = outerD - Spool
        Dim Thickn As Double = thickness * value * value1

        Total = value * PIE * OUterSUBspool / Thickn
            If OuterDiameter < spoolDiameter Then
                Return 0
        End If

        Return Total
    End Function

    Private Sub frmPaperRoll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMagazine()
    End Sub

    Private Sub LoadMagazine()
        Dim mySql As String = "SELECT * FROM tblmagazine"
        Dim ds As DataSet = LoadSQL(mySql)

        magazine = New Hashtable
        cboMagazine.Items.Clear()
        Dim tmpmagazine As String, tmpID As Integer

        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                tmpID = .Item("Mag_ID")
                tmpmagazine = .Item("MagDescription")
            End With
            magazine.Add(tmpID, tmpmagazine)
            cboMagazine.Items.Add(tmpmagazine)
        Next
    End Sub

    Private Function GetMagbyID(ByVal id As Integer) As String
        For Each el As DictionaryEntry In magazine
            If el.Key = id Then
                Return el.Value
            End If
        Next

        Return "N/A"
    End Function

    Private Function GetMagID(ByVal name As String) As Integer
        For Each el As DictionaryEntry In magazine
            If el.Value = name Then
                Return el.Key
            End If
        Next
        Return 0
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class