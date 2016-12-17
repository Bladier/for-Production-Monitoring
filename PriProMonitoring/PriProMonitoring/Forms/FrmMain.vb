Public Class FrmMain
    Private locked As Boolean = IIf(GetOption("Locked") = "YES", True, False)

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)

        LoadMagazineToolStripMenuItem.Enabled = Not st

        AddMagazineToolStripMenuItem.Enabled = Not st
        AddPaperRollToolStripMenuItem.Enabled = Not st
        TransactionToolStripMenuItem.Enabled = Not st

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
        NotYetLogin()
    End Sub

    Private Sub LoadIMDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadIMDToolStripMenuItem.Click
        Dim child As New frmImportIMD
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

    Private Sub AddMagazineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMagazineToolStripMenuItem.Click
        frmMagazine.Show()
    End Sub

    Private Sub AddPaperRollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPaperRollToolStripMenuItem.Click
        frmPaperRoll.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub TransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionToolStripMenuItem.Click
        Dim MagazineStatus As Boolean = IIf(GetOption("Magazine") = "YES", True, False)
        If Not MagazineStatus Then
            MsgBox("You need to initialize first before to begin.", MsgBoxStyle.Exclamation, "Production")
            Me.Refresh()
            Exit Sub
        End If
        frmProductionMonitoring.Show()
    End Sub

    Private Sub LoadMagazineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadMagazineToolStripMenuItem.Click
        frmLoadMagazine.Show()
    End Sub

End Class