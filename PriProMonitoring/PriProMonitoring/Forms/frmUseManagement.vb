Public Class frmUseManagement
    Dim mysql As String = String.Empty
    Dim selected_user As Users

    Private Sub frmUseManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_all_users()
    End Sub

    Private Sub load_all_users()
        mysql = "SELECT * FROM TBLUSER WHERE STATUS='1'"
        Dim ds As DataSet = LoadSQL(mysql, "tbluser")

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvUsers.Items.Add(dr.Item("ID"))
            lv.SubItems.Add(dr.Item("Fullname"))
        Next
    End Sub

    Private Sub CHKshowpassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKshowpassword.CheckedChanged
        If CHKshowpassword.Checked = True Then
            txtpassword1.UseSystemPasswordChar = False
            txtpassword2.UseSystemPasswordChar = False
        Else
            txtpassword1.UseSystemPasswordChar = True
            txtpassword2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lvUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvUsers.DoubleClick
        selected_user = New Users
        selected_user.load_system_user(lvUsers.FocusedItem.Text)

        load_Selected_User(selected_user)
    End Sub

    Private Sub load_Selected_User(ByVal usr As Users)
        If usr.username = "" Then Exit Sub

        selected_user = usr
        txtusername.Text = usr.username
        txtFullname.Text = usr.Fname
        txtpassword1.Text = usr.passwd
        txtpassword2.Text = usr.passwd
        CBoUSerType.Text = usr.userType

        If usr.status = 1 Then
            cboStatus.Text = "Active"
        End If

        disabled_Fields(False)
    End Sub

    Private Sub disabled_Fields(Optional ByVal ds_F As Boolean = True)

        txtusername.Enabled = ds_F
        txtFullname.Enabled = ds_F
        txtpassword1.Enabled = ds_F
        txtpassword2.Enabled = ds_F
        CBoUSerType.Enabled = ds_F
        cboStatus.Enabled = ds_F
        CHKshowpassword.Enabled = ds_F
        ' GroupBox1.Enabled = ds_F
    End Sub

    Private Sub Clearfields_Fields(Optional ByVal cls_F As String = "")

        txtusername.Text = cls_F
        txtFullname.Text = cls_F
        txtpassword1.Text = cls_F
        txtpassword2.Text = cls_F
        CBoUSerType.SelectedItem = Nothing
        cboStatus.SelectedItem = Nothing
        CHKshowpassword.Enabled = True

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "&Save" Then
            Save_userAccount()
        Else
            Modify_userAccount()
        End If
    End Sub

    Private Sub Save_userAccount()
        If Not Isvalid() Then Exit Sub
        If txtpassword1.Text <> txtpassword2.Text Then MsgBox("Password Not Matched", MsgBoxStyle.Critical, "Error") : Exit Sub

        Dim mysql As String = "SELECT * FROM TBLUSER WHERE PASSWRD ='" & EncryptString(txtpassword1.Text) & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tbluser")
        If ds.Tables(0).Rows.Count >= 1 Then MsgBox("Password ALready taken" & vbCrLf & _
                                                    "make it unique.", MsgBoxStyle.Critical, "Registration") : Exit Sub


        Dim ans As DialogResult = MsgBox("Do you want to save?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "save")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        selected_user = New Users

        With selected_user
            .username = txtusername.Text
            .passwd = txtpassword1.Text
            .Fname = txtFullname.Text
            .userType = CBoUSerType.Text
            If cboStatus.Text = "Active" Then
                .status = 1
            End If
            .saveUser()
        End With

        MsgBox("Successfully registered", MsgBoxStyle.Information, "Account Registration")
        Clearfields_Fields()
    End Sub

    Private Sub Modify_userAccount()
        If Not Isvalid() Then Exit Sub
        If txtpassword1.Text <> txtpassword2.Text Then MsgBox("Password Not Matched", MsgBoxStyle.Critical, "Error") : Exit Sub

        Dim mysql As String = "SELECT * FROM TBLUSER WHERE PASSWRD ='" & EncryptString(txtpassword1.Text) & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tbluser")
        If ds.Tables(0).Rows.Count >= 1 Then MsgBox("Password ALready taken" & vbCrLf & _
                                                    "make it unique.", MsgBoxStyle.Critical, "Registration") : Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to update?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Update")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        selected_user = New Users

        With selected_user
            .ID = lvUsers.FocusedItem.Text
            .username = txtusername.Text
            .passwd = txtpassword1.Text
            .Fname = txtFullname.Text
            .userType = CBoUSerType.Text
            If cboStatus.Text = "Active" Then
                .status = 1
            Else
                .status = 0
            End If
            .Modify_User()
        End With

        MsgBox("Successfully updated", MsgBoxStyle.Information, "Account update")
        Clearfields_Fields()
    End Sub

    Private Function Isvalid() As Boolean
        If txtusername.Text = "" Then txtusername.Focus() : Return False
        If txtFullname.Text = "" Then txtFullname.Focus() : Return False
        If txtpassword1.Text = "" Then txtpassword1.Focus() : Return False
        If txtpassword2.Text = "" Then txtpassword2.Focus() : Return False
        If CBoUSerType.Text = Nothing Then CBoUSerType.Focus() : Return False
        If cboStatus.Text = Nothing Then cboStatus.Focus() : Return False

        Return True
    End Function

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnSave.Text = "&Save" Then
            disabled_Fields(True)
            CHKshowpassword.Enabled = True
            btnSave.Text = "&Update"
            btnEdit.Text = "&Cancel"
        Else
            Dim ans As DialogResult = MsgBox("Do you want to cancel?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "cancel")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
            Clearfields_Fields()
            btnSave.Text = "&Save"
            btnEdit.Text = "&Edit"
        End If

    End Sub
End Class