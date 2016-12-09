Public Class FrmMain
    Friend dateSet As Boolean = False

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        menuInitialization.Enabled = Not st
        If Not st Then
            menuLogin.Text = "&Log Out"
        Else
            menuLogin.Text = "&Login"
        End If
    End Sub



    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLogin.Click
        If menuLogin.Text = "&Login" Then
            Login.Show()
        Else
            Dim ans As DialogResult = MsgBox("Do you want to LOGOUT?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Logout")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            MsgBox("Thank you!", MsgBoxStyle.Information)
            NotYetLogin()
            Login.Show()
        End If
    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub LoadIMDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadIMDToolStripMenuItem.Click
        Dim child As New frmLoadIMD
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub TmpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmpTimer.Tick
        If menuLogin.Text = "&Login" Then
            statusDateandTime.Text = "Date not set"
        Else
            statusDateandTime.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
        End If
    End Sub
End Class