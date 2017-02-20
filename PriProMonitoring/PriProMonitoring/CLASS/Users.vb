Public Class Users
    Private filldata As String = "tbluser"
    Dim mysql As String = String.Empty

#Region "Property and Variables"

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _username As String
    Public Property username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property


    Private _passwd As String
    Public Property passwd As String
        Get
            Return _passwd
        End Get
        Set(ByVal value As String)
            _passwd = value
        End Set
    End Property


    Private _Fname As String
    Public Property Fname As String
        Get
            Return _Fname
        End Get
        Set(ByVal value As String)
            _Fname = value
        End Set
    End Property

    Private _userType As String
    Public Property userType As String
        Get
            Return _userType
        End Get
        Set(ByVal value As String)
            _userType = value
        End Set
    End Property

    Private _systeminfo As Date
    Public Property systeminfo As Date
        Get
            Return _systeminfo
        End Get
        Set(ByVal value As Date)
            _systeminfo = value
        End Set
    End Property

    Private _status As Integer
    Public Property status As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property
#End Region

#Region "procedures and functions"
    Public Sub load_system_user(ByVal id As Integer)
        mysql = "SELECT * FROM " & filldata & " WHERE ID ='" & id & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("Unable to load users", MsgBoxStyle.Critical, "user")
            Exit Sub
        End If

        loaduserByRows(ds.Tables(0).Rows(0))
    End Sub

    Friend Sub loaduserByRows(ByVal dr As DataRow)
        loadUser_byrow(dr)
    End Sub

    Friend Sub loadUser_byrow(ByVal dr As DataRow)
        With dr
            _ID = .Item("ID")
            _username = .Item("User_name")
            _passwd = IIf(IsDBNull(.Item("passwrd")), "", DecryptString(.Item("passwrd")))
            _Fname = .Item("Fullname")
            _userType = .Item("Usertype")
            _systeminfo = .Item("Systeminfo")
            _status = .Item("Status")
        End With
    End Sub

    Friend Sub saveUser()
        mysql = "SELECT * FROM " & filldata & " WHERE User_name ='" & _username & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then
            Dim dsnewrow As DataRow
            dsnewrow = ds.Tables(0).NewRow

            With dsnewrow
                .Item("User_name") = _username
                .Item("passwrd") = EncryptString(_passwd)
                .Item("FUllname") = _Fname
                .Item("Usertype") = _userType
                .Item("SystemInfo") = Now
                .Item("Status") = _status
            End With
            ds.Tables(0).Rows.Add(dsnewrow)
            database.SaveEntry(ds)

        Else
            With ds.Tables(0).Rows(0)
                .Item("User_name") = _username
                .Item("passwrd") = EncryptString(_passwd)
                .Item("FUllname") = _Fname
                .Item("Usertype") = _userType
                .Item("SystemInfo") = Now
                .Item("Status") = _status
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub


    Friend Sub Modify_User()
        mysql = "SELECT * FROM " & filldata & " WHERE User_name ='" & _username & "' and ID = '" & _ID & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)
        With ds.Tables(0).Rows(0)
            .Item("User_name") = _username
            .Item("passwrd") = EncryptString(_passwd)
            .Item("FUllname") = _Fname
            .Item("Usertype") = _userType
            .Item("SystemInfo") = Now
            .Item("Status") = _status
        End With
        database.SaveEntry(ds, False)
    End Sub


    Public Function LoginUser(ByVal user As String, ByVal password As String) As Boolean
        Dim ds As DataSet

        If IsRequiered_pass(user) Then
            mysql = "SELECT  * FROM " & filldata
            mysql &= vbCrLf & String.Format(" WHERE UPPER(USER_NAME) = UPPER('{0}') AND UPPER(PasswRD) = UPPER('{1}')", user, EncryptString(password))
        Else
            mySql = "SELECT  * FROM " & fillData
            mysql &= vbCrLf & String.Format(" WHERE UPPER(USER_NAME) = UPPER('{0}') OR UPPER(PasswRD) = UPPER('{1}')", user, EncryptString(password))

        End If
        ds = LoadSQL(mysql, filldata)
        If ds.Tables(0).Rows.Count = 0 Then Return False
        For Each dr As DataRow In ds.Tables(0).Rows
            loadUser_byrow(dr)
        Next
        CurrentUser = _Fname
        Return True
    End Function

    Public Function IsRequiered_pass(ByVal Code As String) As Boolean
        mysql = "SELECT UPPER(USER_NAME),passwrd FROM " & filldata
        mysql &= vbCrLf & String.Format(" WHERE UPPER(USER_NAME) =UPPER('" & Code & "')")
        Dim ds As DataSet

        ds = LoadSQL(mysql, filldata)
        If IsDBNull(ds.Tables(0).Rows(0).Item("passwRd")) Then
            Return False
        End If

        Return True
    End Function

#End Region
End Class
