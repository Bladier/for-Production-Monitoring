Module newSetup

    Friend Function ConfiguringDB() As Boolean
        If Not System.IO.File.Exists(dbName) Then
            dbName = "W3W1LH4CKU.FDB"
        End If

        Try
            Dim mySql As String = "SELECT * FROM sysWorkgroup"
            Dim ds As DataSet = LoadSQLPOS(mySql)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Connection Problem")
            Return False
        End Try

        Return True
    End Function
End Module
