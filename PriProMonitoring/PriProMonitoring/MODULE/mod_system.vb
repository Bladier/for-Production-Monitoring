Imports Microsoft.Office.Interop
Module mod_system
  
    Public SysTitle As String = "Printer Production Monitoring System"
    Public DEV_MODE As Boolean = False
    Public PROTOTYPE As Boolean = False
    Friend DBVERSION As String = ""

    Public CurrentDate As Date = Now
    Public POSuser As New ComputerUser
    Public CurrentUser As String = POSuser.NAME
    Public Meter As Double = 0.0254 ' 1 inch = 0.0254
    Public OneMeter As Double = 39.3701 ' 1 meter

    Public ModName As String = ""
    Public Remaining_Per_Papercut As Double = 0.0

    Friend Function DigitOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal isWhole As Boolean = False)
        Console.WriteLine("char: " & e.KeyChar & " -" & Char.IsDigit(e.KeyChar))
        If e.KeyChar <> ControlChars.Back Then
            If isWhole Then
                e.Handled = Not (Char.IsDigit(e.KeyChar))
            Else
                e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
            End If

        End If
        Return Not (Char.IsDigit(e.KeyChar))
    End Function
   
    Friend Function checkNumeric(ByVal txt As TextBox) As Boolean
        If IsNumeric(txt.Text) Then
            Return True
        End If

        Return False
    End Function

    Friend Function DreadKnight(ByVal str As String, Optional ByVal special As String = Nothing) As String
        str = str.Replace("'", "''")
        str = str.Replace("""", """""")

        If special <> Nothing Then
            str = str.Replace(special, "")
        End If

        Return str
    End Function

    Friend Function ReplaceAMPM(ByVal str As String) As String
        If str = "AM" Then

        End If
        str = str.Substring(Math.Max(0, str.Length - 2))

        str = str.Replace("AM", "")
        str = str.Replace("PM", "")

        Return str
    End Function

    Friend Function isEnter(ByVal e As KeyPressEventArgs) As Boolean
        If Asc(e.KeyChar) = 13 Then
            Return True
        End If
        Return False
    End Function

    Friend Function GetCurrentAge(ByVal dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    Friend Function isMoney(ByVal txtBox As TextBox) As Boolean
        Dim isGood As Boolean = False

        If Double.TryParse(txtBox.Text, 0.0) Then
            isGood = True
        End If

        Return isGood
    End Function

    Friend Function GetFirstDate(ByVal curDate As Date) As Date
        Dim firstDay = DateSerial(curDate.Year, curDate.Month, 1)
        Return firstDay
    End Function

    Friend Function GetLastDate(ByVal curDate As Date) As Date
        Dim original As DateTime = curDate  ' The date you want to get the last day of the month for
        Dim lastOfMonth As DateTime = original.Date.AddDays(-(original.Day - 1)).AddMonths(1).AddDays(-1)

        Return lastOfMonth
    End Function

    Friend Function ConfiguringDB() As Boolean
        If Not System.IO.File.Exists(dbName) Then
            dbName = "PRIPRO.FDB"
        End If

        Try
            Dim mySql As String = "SELECT * FROM TBLMAINTENANCE"
            Dim ds As DataSet = LoadSQL(mySql)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Connection Problem")
            Return False
        End Try

        Return True
    End Function

    Public Sub CloseForms(ByVal frm As String)

        Dim formNames As New List(Of String)
        For Each Form In My.Application.OpenForms
            If Form.Name <> "FrmMain" Or Not Form.name <> frm Then
                formNames.Add(Form.Name)
            End If
        Next
        For Each currentFormName As String In formNames
            Application.OpenForms(currentFormName).Close()
        Next
    End Sub
   

#Region "Log Module"
    Const LOG_FILE As String = "syslog.txt"
    Private Sub CreateLog()
        Dim fsEsk As New System.IO.FileStream(LOG_FILE, IO.FileMode.CreateNew)
        fsEsk.Close()
    End Sub

    Friend Sub Log_Report(ByVal str As String)
        If Not System.IO.File.Exists(LOG_FILE) Then CreateLog()

        Dim recorded_log As String = _
            String.Format("[{0}] " & str, Now.ToString("MM/dd/yyyy HH:mm:ss"))

        Dim fs As New System.IO.FileStream(LOG_FILE, IO.FileMode.Append, IO.FileAccess.Write)
        Dim fw As New System.IO.StreamWriter(fs)
        fw.WriteLine(recorded_log)
        fw.Close()
        fs.Close()
        Console.WriteLine("Recorded")
    End Sub
#End Region
End Module
