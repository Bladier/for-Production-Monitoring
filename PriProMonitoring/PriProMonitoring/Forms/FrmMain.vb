Public Class FrmMain
    Private locked As Boolean
    Private MagazineStatus As Boolean
    Dim CheckLastID As String = ""

    Dim tmplastSalesID As String
    Dim tmpdate As String

    Dim timerCounter As Integer = 30

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        locked = IIf(GetOption("Locked") = "YES", True, False)

        'file
        AdjustmentToolStripMenuItem.Enabled = Not st
        PaperEmptyDeclarationToolStripMenuItem.Enabled = Not st

        If Not locked Then
            SettingsToolStripMenuItem.Enabled = st
        Else
            SettingsToolStripMenuItem.Enabled = Not st
        End If

        'Initialization
        LoadMagazineToolStripMenuItem.Enabled = Not st


        'Magazine
        AddPaperRollToolStripMenuItem.Enabled = Not st
        AddItemToolStripMenuItem.Enabled = Not st

        'Transaction
        TransactionToolStripMenuItem.Enabled = Not st

        If Not st Then
            menuLogin.Text = "&Log Out"
        Else
            menuLogin.Text = "&Login"
        End If
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLogin.Click
        If menuLogin.Text = "&Login" Then
            Login.Show()
        Else
            Dim ans As DialogResult = MsgBox("Do you want to LOGOUT?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Logout")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub

            Dim formNames As New List(Of String)
            For Each Form In My.Application.OpenForms
                If Form.Name <> "FrmMain" Or Not Form.name <> "Login" Then
                    formNames.Add(Form.Name)
                End If
            Next
            For Each currentFormName As String In formNames
                Application.OpenForms(currentFormName).Close()
            Next

            MsgBox("Thank you!", MsgBoxStyle.Information)
            locked = IIf(GetOption("Locked") = "YES", True, False)
            NotYetLogin()
            Login.Show()
            statusUser.Text = "User"
        End If
    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False


        'AddHandler TmpTimer.Tick, AddressOf SalesWatcher_Tick
        SalesWatcher.Start()

        NotYetLogin()
    End Sub


    Private Sub TmpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmpTimer.Tick
        If menuLogin.Text = "&Login" Then
            statusDateandTime.Text = "Date not set"
        Else
            statusDateandTime.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
        End If
    End Sub


    Private Sub AddPaperRollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPaperRollToolStripMenuItem.Click
        frmPaperRoll.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub TransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionToolStripMenuItem.Click
        MagazineStatus = IIf(GetOption("Magazine") = "YES", True, False)
        If Not MagazineStatus Then
            MsgBox("You need to initialize magazine before to begin.", MsgBoxStyle.Exclamation, "Production")
            Me.Refresh()
            Exit Sub
        End If

       frmProductionMonitoring.Show()
    End Sub

    Private Sub LoadMagazineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadMagazineToolStripMenuItem.Click
        frmLoadMagazine.Show()
    End Sub

    Private Sub AddItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemToolStripMenuItem.Click
        frmItem.Show()
    End Sub

 
    Private Sub AdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentToolStripMenuItem.Click
        frmAdjustment.Show()
    End Sub

    Private Sub SalesWatcher_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesWatcher.Tick
        SalesWatcher.Stop()
        bgWorker.RunWorkerAsync()
    End Sub

    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        Counter.Stop()
        timerCounter = 0
        StatusCounter.Text = timerCounter
        NewSalesLoad()
    End Sub

    Private Sub bgWorker_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        ToolStripPBar.Value = e.ProgressPercentage
    End Sub

    Private Sub NewSalesLoad()

        Dim CheckLastID As String = GetOption("LastSalesID")
        If CheckLastID = "" Then Exit Sub

        If GetRemarks("LastSalesID") = frmSales.GetLastEntry(0) Then
            Exit Sub
        Else
            If CheckLastID <> "" Then
                Dim tmpRemarks As String = GetRemarks("LastSalesID")

                tmpRemarks = tmpRemarks.Remove(tmpRemarks.Length - 2)

                tmplastSalesID = frmSales.GetLastEntry(0)
                tmpdate = frmSales.GetLastEntry(1)

                If tmplastSalesID = "" Then Exit Sub

                If GetOption("LastSalesID") = tmplastSalesID Then _
                    MsgBox("No new row data in sales", MsgBoxStyle.Information, "Sales") : Exit Sub

                Dim SaveSales As New Sales
                With SaveSales
                    Dim POSsales As String = "SELECT I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,E.TRANSDATE," & _
                                             "I.QTY,E.DATESTAMP FROM POSITEM I " & _
                                            "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                            "INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO " & _
                                            "where E.DATESTAMP > '" & tmpRemarks & "' AND I.QTY <> '0' " & _
                                             "ORDER BY E.DATESTAMP ASC "

                    Dim ds As DataSet = LoadSQLPOS(POSsales, "POSITEM")
                    If ds.Tables(0).Rows.Count <= 0 Then Exit Sub

                    Console.WriteLine("Count: " & ds.Tables(0).Rows.Count)
                    Dim max As Integer = ds.Tables(0).Rows.Count

                    Count.Text = max

                    For Each dr As DataRow In ds.Tables(0).Rows

                        Dim tmpItemLine As New ItemLine

                        Dim mysqlITem As String = "SELECT * FROM ITEM WHERE ITEMCODE = '" & dr.Item("ITEMNO") & "'"
                        Dim dsITEM As DataSet = LoadSQL(mysqlITem, "ITEM")

                        If dsITEM.Tables(0).Rows.Count = 0 Then
                            On Error Resume Next
                        Else
                            tmpItemLine.LoadExistItemLine(dsITEM.Tables(0).Rows(0).Item("ITEM_ID"))

                            If tmpItemLine.itemLineID = 0 Then
                                On Error Resume Next
                            Else

                                .ItemCode = dr.Item("ItemNo")
                                .Descrition = dr.Item("Description")
                                .SalesID = dr.Item("ID")
                                .QTY = dr.Item("QTY")
                                .SaveSales()
                            End If
                        End If

                        ToolStripPBar.Maximum = max
                        ToolStripPBar.Value = ToolStripPBar.Value + 1
                        Application.DoEvents()
                        lblToolStripStatus.Text = String.Format("{0}%", ((ToolStripPBar.Value / ToolStripPBar.Maximum) * 100).ToString("F2"))
                    Next

                    Dim updatemainTainance As New GetSalesID

                    With updatemainTainance
                        .OPTVALUES = tmplastSalesID
                        .REMARKS = tmpdate
                    End With
                    updatemainTainance.UPDATE_MAINTAINANCE("LastSalesID ")

                    If MsgBox("Sales Updated.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
        "Sales...") = MsgBoxResult.Ok Then ToolStripPBar.Minimum = 0 : ToolStripPBar.Value = 0 : lblToolStripStatus.Text = "0.00%"


                End With
            End If
        End If
    End Sub
  

    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        SalesWatcher.Start()
        Counter.Start()
        timerCounter = 30
    End Sub

  
    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.Show()
    End Sub

    Private Sub PaperEmptyDeclarationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaperEmptyDeclarationToolStripMenuItem.Click
        frmDeclaration.Show()
    End Sub

    Private Sub FrmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If MessageBox.Show("Do you want to closed?", Me.Text, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Counter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Counter.Tick
        StatusCounter.Text = timerCounter.ToString
        If timerCounter = 0 Then
            timerCounter = 30
        Else
            timerCounter -= 1
        End If
    End Sub

   
    Private Sub MINIMIZE()
        Me.MaximumSize = New Size(200, 10)
        Me.MinimumSize = Me.MaximumSize
        Me.Location = New Point(10, 690)
    End Sub

    Public Sub New()
        MyBase.New()
        MINIMIZE()
        InitializeComponent()
        Me.MaximumSize = New Size(700, 500)
        'Me.StartPosition = FormStartPosition.CenterScreen
        Me.CenterToScreen()
    End Sub

End Class