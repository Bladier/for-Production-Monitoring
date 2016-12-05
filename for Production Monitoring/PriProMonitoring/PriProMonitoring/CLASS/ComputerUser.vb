Imports DeathCodez.Security

Public Class ComputerUser

    Private fillData As String = "sysWorkGroup"
    Private mySql As String, ds As DataSet
   
#Region "Properties"
    Private _Code As String
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal value As String)
            _Code = value
        End Set
    End Property

    Private _Fullename As String
    Public Property Fullename() As String
        Get
            Return _Fullename
        End Get
        Set(ByVal value As String)
            _Fullename = value
        End Set
    End Property

    Private _Username As String
    Public Property Username() As String
        Get
            Return _Username
        End Get
        Set(ByVal value As String)
            _Username = value
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
 
    Public Sub LoadUser1(ByVal user As String)
        mySql = "SELECT * FROM " & fillData & " WHERE userid = '" & user & "'"
        ds = LoadSQLPOS(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            loadByRow(dr)
        Next
    End Sub

    Private Sub loadByRow(ByVal dr As DataRow)
        With dr
            _Code = .Item("Code")
            _Fullename = .Item("Name")
            _Username = .Item("UserID")
            _password = .Item("passwd")
            _GRPType = .Item("GRPType")
        End With
    End Sub

    Public Sub LoadDollarByRow(ByVal dr As DataRow)
        loadByRow(dr)
    End Sub

    Public Sub LoadUser(ByVal name As String)
        mySql = "SELECT * FROM " & fillData & " WHERE name = " & name
        Dim ds As DataSet = LoadSQLPOS(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub


        loadByRow(ds.Tables(0).Rows(0))
        Console.WriteLine(String.Format("[ComputerUser] UserID {0} - {1} Loaded", _Code, _Username))
    End Sub

    Public Function LoginUser(ByVal user As String, ByVal password As String) As Boolean
        mySql = "SELECT Name, LOWER(userId),passwd FROM " & fillData
        mySql &= vbCrLf & String.Format(" WHERE LOWER(userID) = LOWER('{0}') AND passwd = '{1}'", user, password)
        Dim ds As DataSet

        ds = LoadSQLPOS(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False


        'LoadUser(ds.Tables(0).Rows(0).Item("name"))
        Return True
    End Function
#End Region

End Class
