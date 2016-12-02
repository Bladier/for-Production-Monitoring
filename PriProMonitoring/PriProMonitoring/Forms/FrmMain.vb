Public Class FrmMain
    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)

        menuInitialization.Enabled = Not st
        If Not st Then
            menuLogin.Text = "&Log Out"
        Else
            menuLogin.Text = "&Login"
        End If
    End Sub

    

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLogin.Click
        frmLogin.Show()
    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class