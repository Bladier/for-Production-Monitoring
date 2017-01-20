Public Class frmDeclaration

    Private Sub txtEmulsion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmulsion.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtAdvance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdvance.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub Watermark2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlastout.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim tmppaperRoll As New PaperRoll
        tmppaperRoll.loadSerial(cboPaperRollSerial.Text)

        Dim SavepapEmp As New PaperListEmpty
        With SavepapEmp
            .PAPROLLID = tmppaperRoll.PaprollID
            .EMULSION = txtEmulsion.Text * 12
            .ADVANCE = txtAdvance.Text
            .LASTOUT = txtlastout.Text
            .UOM = "Inch"
            .cREATEDAT = Now
            .SavePAPEmPTY()
        End With

        MsgBox("Posted.", MsgBoxStyle.Information, "Posted")
        txtEmulsion.Text = ""
        txtAdvance.Text = ""
        txtlastout.Text = ""
        cboPaperRollSerial.SelectedItem = Nothing
        frmDeclaration_Load(sender, e)
    End Sub

  
    

    Private Sub frmDeclaration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tmplist As New PaperListEmpty
        For Each serial In tmplist.PopulateSerial()
            cboPaperRollSerial.Items.Add(serial)
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtlastout_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtlastout.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnPost.PerformClick()
        End If
    End Sub
End Class