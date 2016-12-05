Public Class frmLogin

   
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsername.Focus.ToString()
    End Sub

    Private Sub btnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Static wrongLogin As Integer

        Dim user As String = DreadKnight(txtUsername.Text)

        Dim pass As String = txtpassword.Text

        Dim loginUser As New ComputerUser
        If Not loginUser.LoginUser(user, pass) Then
            wrongLogin += 1
            If wrongLogin >= 3 Then
                MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                End
            End If
            MsgBox("Invalid Username and password", MsgBoxStyle.Critical)
            txtpassword.Text = ""
            txtUsername.Text = "" : txtUsername.Focus()
            Exit Sub
        End If

       
        loginUser.LoadUser1(user)

        Dim SysUser As String = loginUser.Fullename

        MsgBox("Welcome " & SysUser)
        FrmMain.txtUser.Text = loginUser.Fullename
        FrmMain.Show()
        FrmMain.NotYetLogin(False)
        Me.Close()
    End Sub

    Private Sub txtpassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

  
    Private Sub txtUsername_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then txtpassword.Focus()
    End Sub
End Class