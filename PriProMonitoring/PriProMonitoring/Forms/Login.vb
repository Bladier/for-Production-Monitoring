Public Class Login
    Private locked As Boolean = IIf(GetOption("Locked") = "YES", True, False)
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Not locked Then MsgBox("Database not set.", MsgBoxStyle.Exclamation) : Exit Sub
        databasePOS.dbNamePOS = GetOption("DatabasePOS")

        Static wrongLogin As Integer

        Dim user As String = DreadKnight(txtusername.Text)
        Dim pass As String = DreadKnight(txtpassword.Text)

        Dim loginUser As New Users
        If Not loginUser.LoginUser(user, pass) Then
            wrongLogin += 1
            If wrongLogin >= 3 Then
                MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                End
            End If
            MsgBox("Invalid Username and password", MsgBoxStyle.Critical, Me.Text)
            txtusername.Text = ""
            txtpassword.Text = ""
            txtusername.Focus()
            Exit Sub
        End If

        ' Success!

        FrmMain.statusUser.Text = loginUser.Fname
        FrmMain.ToolStripActiveUser.Text = "Welcome, " & loginUser.username
        MsgBox("Welcome " & loginUser.username, MsgBoxStyle.Information, "Login")

        FrmMain.Show()
        FrmMain.NotYetLogin(False)
        Me.Close()

    End Sub

   
    Private Sub txtusername_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtusername.KeyPress
        If isEnter(e) Then
            txtpassword.Focus()
        End If
    End Sub

    Private Sub txtpassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpassword.KeyPress
        If isEnter(e) Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If btnExit.Text = "&Close" Then
            FrmMain.Show() : Me.Close()
        Else
            End
        End If

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not locked Then
            btnExit.Text = "&Close"
        Else
            btnExit.Text = "&Exit"
        End If
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
