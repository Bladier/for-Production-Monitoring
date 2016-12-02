Public Class frmLogin

    ''' <summary>
    ''' This method call the createadministrator method from the class.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckUsers()
        Dim newUser As New ComputerUser
        newUser.CreateAdministrator()
    End Sub
   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Static wrongLogin As Integer

        Dim user As String = DreadKnight(txtUsername.Text)
        'Dim user As String = txtUser.Text
        Dim pass As String = txtpassword.Text

        Dim loginUser As New ComputerUser
        If Not loginUser.LoginUser(user, pass) Then
            wrongLogin += 1
            If wrongLogin >= 3 Then
                MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                End
            End If
            MsgBox("Invalid Username and password", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ' Success!
        POSuser = loginUser
        POSuser.UpdateLogin()
        UserID = POSuser.UserID
        MsgBox("Welcome " & POSuser.FullName)

        FrmMain.Show()
        FrmMain.NotYetLogin(False)
        ' FrmMain.CheckStoreStatus()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsername.Focus()
        'CheckUsers()
    End Sub

    Private Sub btnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub
End Class