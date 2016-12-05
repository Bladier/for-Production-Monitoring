Public Class FrmMain

    Friend dateSet As Boolean = False

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)

        LoadMagazineToolStripMenuItem.Enabled = Not st

        If Not st Then
            menuLogin.Text = "&Log Out"
        Else
            menuLogin.Text = "&Login"
        End If

        If st Then
            txtUser.Text = "No User yet"
        End If

        If st Then
            tmrCurrentDate.Stop()
        Else
            tmrCurrentDate.Start()
        End If
    End Sub



    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLogin.Click
        If menuLogin.Text = "&Login" Then
            Dim child As New frmLogin
            child.MdiParent = Me
            child.Show()
        Else
            Dim ans As DialogResult = MsgBox("Do you want to LOGOUT?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Logout")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            MsgBox("Thank you!", MsgBoxStyle.Information)
            NotYetLogin()
            Dim child As New frmLogin
            child.MdiParent = Me
            child.Show()
        End If

       
    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Not ConfiguringDB() Then MsgBox("DATABASE CONNECTION PROBLEM", MsgBoxStyle.Critical) : Exit Sub
        NotYetLogin()
    End Sub

    Private Sub LoadMagazineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadMagazineToolStripMenuItem.Click
        Dim child As New frmPaperRoll
        child.MdiParent = Me
        child.Show()

    End Sub

    Private Sub tmrCurrentDate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrentDate.Tick
        If Not dateSet Then
            txtDate.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
        Else
            txtDate.Text = "Date not set"
        End If
    End Sub

 
    Private Sub AddMagazineToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMagazineToolStripMenuItem1.Click
        Dim child As New frmMagazine
        child.MdiParent = Me
        child.Show()
    End Sub
End Class