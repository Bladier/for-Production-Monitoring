Public Class PaperListEmpty
    Dim mysql As String = ""
    Dim filldata As String = "tblpaper_listempty"


#Region "Variables and Properties"
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _PAPROLLID As Integer
    Public Property PAPROLLID() As Integer
        Get
            Return _PAPROLLID
        End Get
        Set(ByVal value As Integer)
            _PAPROLLID = value
        End Set
    End Property

    Private _EMULSION As Double
    Public Property EMULSION() As Double
        Get
            Return _EMULSION
        End Get
        Set(ByVal value As Double)
            _EMULSION = value
        End Set
    End Property

    Private _ADVANCE As Double
    Public Property ADVANCE() As Double
        Get
            Return _ADVANCE
        End Get
        Set(ByVal value As Double)
            _ADVANCE = value
        End Set
    End Property

    Private _LASTOUT As Double
    Public Property LASTOUT() As Double
        Get
            Return _LASTOUT
        End Get
        Set(ByVal value As Double)
            _LASTOUT = value
        End Set
    End Property

    Private _UOM As String
    Public Property UOM() As String
        Get
            Return _UOM
        End Get
        Set(ByVal value As String)
            _UOM = value
        End Set
    End Property

    Private _cREATEDAT As Date
    Public Property cREATEDAT() As Date
        Get
            Return _cREATEDAT
        End Get
        Set(ByVal value As Date)
            _cREATEDAT = value
        End Set
    End Property

    Private _Declaredby As String
    Public Property Declaredby() As String
        Get
            Return _Declaredby
        End Get
        Set(ByVal value As String)
            _Declaredby = value
        End Set
    End Property
#End Region

#Region "procedures and functions"
    Friend Sub LOADPAPER_EMP(ByVal ID As Integer)
        mysql = "SELECT * FROM " & filldata & " WHERE ID =" & ID
        Dim ds As DataSet = LoadSQL(mysql, "Item")

        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Unable to PAPER LIST", MsgBoxStyle.Information)
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            lOadPAPByrow(dr)
        Next

    End Sub

    Private Sub lOadPAPByrow(ByVal dr As DataRow)
        LoaDPAPERByRow(dr)
    End Sub

    Private Sub LoaDPAPERByRow(ByVal dr As DataRow)

        With dr
            _ID = .Item("ID")
            _PAPROLLID = .Item("PAPROLL_ID")
            _EMULSION = If(IsDBNull(.Item("EMULSION")), "", .Item("EMULSION"))
            _ADVANCE = IIf(IsDBNull(.Item("ADVANCE")), "", .Item("ADVANCE"))
            _LASTOUT = IIf(IsDBNull(.Item("LASTOUT")), "", .Item("LASTOUT"))
            _UOM = .Item("UOM")
            _cREATEDAT = .Item("CREATED_AT")
            _Declaredby = .Item("Declaredby")
        End With
    End Sub

    Friend Sub SavePAPEmPTY()
        mysql = "SELECT * FROM " & filldata
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("PAPROLL_ID") = _PAPROLLID
            .Item("EMULSION") = _EMULSION
            .Item("ADVANCE") = _ADVANCE
            .Item("LASTOUT") = _LASTOUT
            .Item("UOM") = _UOM
            .Item("CREATED_AT") = _cREATEDAT
            .Item("Declaredby") = _Declaredby
        End With

        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

    End Sub


    Friend Sub EmpRoll(ByVal serial As String, ByVal status As Integer, Optional ByVal tmpchamber As String = "")
        Dim mySql As String = "SELECT * FROM TBLPAPERROLL WHERE paproll_serial = '" & serial & "'"
        Dim fillData As String = "TBLPAPERROLL"
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("status") = status
                .Item("Chamber") = tmpchamber
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub


    Public Function PopulateSerial() As List(Of String)

        Dim serial As New List(Of String)()
        Dim mysql As String = "SELECT * FROM TBLPAPERROLL WHERE STATUS <> 2 ORDER BY PAPROLL_ID "
        Dim ds As DataSet = LoadSQL(mysql, "tblpaperroll")

        For Each dr As DataRow In ds.Tables(0).Rows
            serial.Add(dr.Item("PapRoll_serial"))
        Next

        Return serial
    End Function
#End Region
End Class
