Imports System.Data.Odbc
''' <summary>
''' This module declare the connection of the database.
''' 
''' </summary>
''' <remarks></remarks>
Friend Module databasePOS
    Public conPOS As OdbcConnection
    Public ReaderConPOS As OdbcConnection
    Friend dbNamePOS As String = "ANOISIM.FDB" 'Final
    Friend fbUserPOS As String = "SYSDBA"
    Friend fbPassPOS As String = "masterkey"
    Friend fbDataSet As New DataSet
    Friend conStrPOS As String = String.Empty

    Private DBversion As String = "1.0.0.0" 'Database version.
    Private language() As String = _
        {"Connection error failed."} 'verification if the database is connected.
    ''' <summary>
    ''' This method shows the connection string of a database.
    ''' Also here we open the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dbOpenPOS()
        conStrPOS = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUserPOS & ";Password=" & fbPassPOS & ";Database=" & dbNamePOS & ";"

        conPOS = New OdbcConnection(conStrPOS)
        Try
            conPOS.Open()
        Catch ex As Exception
            conPOS.Dispose()
            MsgBox(language(0) + vbCrLf + ex.Message.ToString, vbCritical, "Connecting Error")
            Log_Report(ex.Message.ToString)
            Log_Report(String.Format("User: {0}", fbUser))
            Log_Report(String.Format("Database: {0}", dbName))
            Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' This method is for closing after database was open here is the close.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dbClosePOS()
        conPOS.Close()
    End Sub
    ''' <summary>
    ''' The database is ready to open.
    ''' </summary>
    ''' <returns>return false if the database is not ready.</returns>
    ''' <remarks></remarks>
    Friend Function isReady() As Boolean
        Dim ready As Boolean = False
        Try
            dbOpenPOS()
            ready = True
        Catch ex As Exception
            Console.WriteLine("[ERROR] " & ex.Message.ToString)
            Return False
        End Try

        Return ready
    End Function

    ''' <summary>
    ''' Module 001
    ''' Save the Dataset to the database
    ''' </summary>
    ''' <param name="dsEntry">Database with Table Name as Database Table Name</param>
    ''' <returns>Boolean: Success Result</returns>
    ''' <remarks></remarks>

    Friend Function SaveEntryPOS(ByVal dsEntry As DataSet, Optional ByVal isNew As Boolean = True) As Boolean
        If dsEntry Is Nothing Then
            Return False
        End If

        dbOpenPOS()

        Dim da As OdbcDataAdapter
        Dim ds As New DataSet, mySql As String, fillData As String
        ds = dsEntry

        'Save all tables in the dataset
        For Each dsTable As DataTable In dsEntry.Tables
            fillData = dsTable.TableName
            mySql = "SELECT * FROM " & fillData
            If Not isNew Then
                Dim colName As String = dsTable.Columns(0).ColumnName
                Dim idx As Integer = dsTable.Rows(0).Item(0)
                mySql &= String.Format(" WHERE {0} = {1}", colName, idx)

                Console.WriteLine("ModifySQL: " & mySql)
            End If

            da = New OdbcDataAdapter(mySql, conPOS)
            Dim cb As New OdbcCommandBuilder(da) 'Required in Saving/Update to Database
            da.Update(ds, fillData)
        Next

        dbClosePOS()
        Return True
    End Function

    Friend Sub SQLCommand(ByVal sql As String)
        conStrPOS = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"
        conPOS = New OdbcConnection(conStr)

        Dim cmd As OdbcCommand
        cmd = New OdbcCommand(sql, conPOS)

        Try
            conPOS.Open()
            cmd.ExecuteNonQuery()
            conPOS.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Log_Report(String.Format("[{0}] - ", sql) & ex.ToString)
            con.Dispose()
            Exit Sub
        End Try

        System.Threading.Thread.Sleep(1000)
    End Sub

    ''' <summary>
    '''This function will check the compatibility of database version if it is match.
    ''' </summary>
    ''' <returns>return false if the database version is not match.</returns>
    ''' <remarks></remarks>
    Friend Function DBCompatibilityCheck() As Boolean
        Console.WriteLine("Checking database compatibility...")
        Dim strDB As String = GetOption("DBVersion")

        If DBversion = strDB Then
            Console.WriteLine("Success!")
            Return True
        Else
            Console.WriteLine("Database Version didn't match... " & strDB)
            Return False
        End If
    End Function

    ''' <summary>
    '''This function where the table load to dataset.
    ''' </summary>
    ''' <param name="mySql">mysql where the data pass by.</param>
    ''' <param name="tblName">tblName here is a variable that hold the data.</param>
    ''' <returns>return ds after reading the mysql data.</returns>
    ''' <remarks></remarks>
    Friend Function LoadSQLPOS(ByVal mySql As String, Optional ByVal tblName As String = "QuickSQL") As DataSet
        dbOpenPOS() 'open the database.

        Dim da As OdbcDataAdapter
        Dim ds As New DataSet, fillData As String = tblName
        Try
            da = New OdbcDataAdapter(mySql, conPOS)
            da.Fill(ds, fillData)
        Catch ex As Exception
            Console.WriteLine(">>>>>" & mySql)
            MsgBox(ex.ToString)
            Log_Report("LoadSQL - " & ex.ToString)
            ds = Nothing
        End Try

        dbClosePOS()

        Return ds
    End Function

    ''' <summary>
    ''' This function is the declaration of odbccommand and odbcdatareader.
    ''' </summary>
    ''' <param name="mySql">mysql where the data pass</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function LoadSQL_byDataReader(ByVal mySql As String) As OdbcDataReader
        Dim myCom As OdbcCommand = New OdbcCommand(mySql, ReaderCon)
        Dim reader As OdbcDataReader = myCom.ExecuteReader()

        Return reader
    End Function
    ''' <summary>
    ''' The conStr here a variable that hold the connectionstring of the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dbReaderOpen()
        conStrPOS = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"

        ReaderConPOS = New OdbcConnection(conStr)
        Try
            ReaderConPOS.Open() 'open the database.
        Catch ex As Exception
            ReaderConPOS.Dispose()
            MsgBox(language(0) + vbCrLf + ex.Message.ToString, vbCritical, "Connecting Error")
            Log_Report(ex.Message.ToString)
            Exit Sub
        End Try
    End Sub
    ''' <summary>
    ''' close the database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub dbReaderClose()
        ReaderConPOS.Close()
    End Sub

End Module