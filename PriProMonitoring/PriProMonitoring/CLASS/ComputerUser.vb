Public Class ComputerUser

    Private fillData As String = "sysworkgroup"
    Private mySql As String = String.Empty

#Region "Properties"
    Private _CODE As String
    Public Property CODE() As String
        Get
            Return _CODE
        End Get
        Set(ByVal value As String)
            _CODE = value
        End Set
    End Property

    Private _NAME As String
    Public Property NAME() As String
        Get
            Return _NAME
        End Get
        Set(ByVal value As String)
            _NAME = value
        End Set
    End Property

    Private _USERID As String
    Public Property USERID() As String
        Get
            Return _USERID
        End Get
        Set(ByVal value As String)
            _USERID = value
        End Set

    End Property

    Private _password As String
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Private _GRPType As String
    Public Property GRPType() As String
        Get
            Return _GRPType
        End Get
        Set(ByVal value As String)
            _GRPType = value
        End Set
    End Property

#End Region

#Region "Procedures and Functions"

    Public Sub LoadUserByRow(ByVal dr As DataRow)
        'On Error Resume Next

        With dr
            _CODE = .Item("Code")
            _NAME = .Item("NAME")
            _USERID = .Item("USERID")
            _password = .Item("PASSWD")
            _GRPType = .Item("GRPTYPE")
        End With
    End Sub


    Public Sub LoadUser(ByVal CODE As String)
        mySql = "SELECT * FROM " & fillData & " WHERE CODE = " & CODE
        Dim ds As DataSet = LoadSQLPOS(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub


        LoadUserByRow(ds.Tables(0).Rows(0))
        Console.WriteLine(String.Format("[ComputerUser] UserID {0} - {1} Loaded", _CODE, _USERID))
    End Sub

    Public Function LoginUser(ByVal user As String, ByVal password As String) As Boolean
        mySql = "SELECT  * FROM " & fillData
        mySql &= vbCrLf & String.Format(" WHERE UPPER(CODE) = UPPER('{0}') AND UPPER(PasswD) = UPPER('{1}')", user, password)
        Dim ds As DataSet

        ds = LoadSQLPOS(mySql, fillData)
        If ds.Tables(0).Rows.Count = 0 Then Return False
        For Each dr As DataRow In ds.Tables(0).Rows
            LoadUserByRow(dr)
        Next
        CurrentUser = _NAME
        Return True
    End Function

    Public Function lOGINUSERNAME(ByVal USERID As String)
        mySql = "SELECT * FROM " & fillData
        mySql &= vbCrLf & String.Format(" WHERE LOWER(USERID) ='" & USERID & "'")
        Dim ds As DataSet

        ds = LoadSQLPOS(mySql)
        If ds.Tables(0).Rows.Count < 1 Then
            Return "Nothing"
        End If

        Return ds.Tables(0).Rows(0).Item(1)
    End Function

    Public Function Loadcodename(ByVal USERID As String)
        mySql = "SELECT * FROM " & fillData
        mySql &= vbCrLf & String.Format(" WHERE LOWER(USERID) ='" & USERID & "'")
        Dim ds As DataSet

        ds = LoadSQLPOS(mySql)
        If ds.Tables(0).Rows.Count <= 0 Then
            Return "Nothing"
        End If

        Return ds.Tables(0).Rows(0).Item(0)
    End Function


    'Public Function CheckUserType(ByVal Fname As String) As Boolean
    '    Dim mysql As String = "SELECT * FROM " & fillData & " WHERE NAME = '" & Fname & "'"
    '    Dim ds As 
    'End Function
#End Region
End Class
