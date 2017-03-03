Public Class FrmMain
    Private locked As Boolean
    Private MagazineStatus As Boolean
    Dim CheckLastID As String = ""

    Dim tmplastSalesID As String
    Dim tmpdate As String

    Dim timerCounter As Integer = 30
    Private CheckPStat As Boolean

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        locked = IIf(GetOption("Locked") = "YES", True, False)

        'file menu
        AdjustmentToolStripMenuItem.Enabled = Not st
        PaperEmptyDeclarationToolStripMenuItem.Enabled = Not st
        InitializePaperRollToolStripMenuItem.Enabled = Not st
        UserManagementToolStripMenuItem.Enabled = Not st

        If Not locked Then
            SettingsToolStripMenuItem.Enabled = st
        Else
            SettingsToolStripMenuItem.Enabled = Not st
        End If

        'Item menu
        AddItemToolStripMenuItem.Enabled = Not st

        'TootStripMenus
        ToolStripChangePaperRoll.Enabled = Not st
        ToolStripAddpaperroll.Enabled = Not st
        ToolStripAdjusment.Enabled = Not st
        ToolStripMonitor.Enabled = Not st

        If Not st Then
            ToolStripLogin.Text = "&Log Out"
            ToolStripLogin.ToolTipText = "Logout"
            ToolStripActiveUser.ToolTipText = "Acive user"
        Else
            ToolStripLogin.Text = "&Login"
            ToolStripLogin.ToolTipText = "Login"
            ToolStripActiveUser.ToolTipText = "No Acive user"
        End If

        'reports
        ProductionToolstrip.Enabled = Not st

    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SysTitle & " | Version " & Me.GetType.Assembly.GetName.Version.ToString & IIf(mod_system.DEV_MODE, " <<DEVELOPER MODE>>", "")
        Me.Text &= IIf(mod_system.PROTOTYPE, " !!PROTOTYPE!!", "")

        If Not ConfiguringDB() Then MsgBox("DATABASE CONNECTION PROBLEM", MsgBoxStyle.Critical) : Exit Sub

        Patch_if_Patchable()

        If Not database.DBCompatibilityCheck() Then MsgBox("Please update the database version", MsgBoxStyle.Critical) : End

        Control.CheckForIllegalCrossThreadCalls = False 'THREADING FOR BACKGROUND WORKER

        SalesWatcher.Start()

        NotYetLogin()
    End Sub


    Private Sub TmpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmpTimer.Tick
        If ToolStripLogin.Text = "&Login" Then
            statusDateandTime.Text = "Date not set"
        Else
            statusDateandTime.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
        End If
    End Sub


    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub AddItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemToolStripMenuItem.Click
        Me.Enabled = False
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

        NewSalesLoad() 'Load Sales from POS

        'Production allocate paper cut to it's paper roll
        CheckPStat = IIf(GetOption("Magazine") = "YES", True, False)
        If Not CheckPStat Then
            Exit Sub
        End If
        PrintProduction.Production()
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
                    ToolStripStatusSalesMessage.Text = "No new row data in sales" : Exit Sub
                ' MsgBox("No new row data in sales", MsgBoxStyle.Information, "Sales") : Exit Sub

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

                    ToolStripStatusSalesMessage.Text = "Sales Updated."

                    '            If MsgBox("Sales Updated.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
                    '"Sales...") = MsgBoxResult.Ok Then
                    ToolStripPBar.Minimum = 0 : ToolStripPBar.Value = 0 : lblToolStripStatus.Text = "0.00%"


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
        Me.Enabled = False
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

    Private Sub ToolStripLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLogin.Click
        If ToolStripLogin.Text = "&Login" Then
            Login.Show()
        Else
            Dim ans As DialogResult = MsgBox("Do you want to LOGOUT?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Logout")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub

            CloseForms("Login")

            MsgBox("Thank you!", MsgBoxStyle.Information, "Logout")
            locked = IIf(GetOption("Locked") = "YES", True, False)
            NotYetLogin()
            Login.Show()
            statusUser.Text = "User"
            ToolStripActiveUser.Text = "User"
        End If
    End Sub


    Private Sub ToolStripProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripChangePaperRoll.Click


        MagazineStatus = IIf(GetOption("Magazine") = "YES", True, False)
        If Not MagazineStatus Then
            MsgBox("You need to initialize magazine before to begin.", MsgBoxStyle.Exclamation, "Production")
            Me.Refresh()
            Exit Sub
        End If

        CloseForms("frmPaperRoll_List_Chamber")

        frmPaperRoll_List_Chamber.TopLevel = False
        Panel1.Controls.Add(frmPaperRoll_List_Chamber)
        frmPaperRoll_List_Chamber.Show()
        'frmPaperRolls.MdiParent = Me
        'frmPaperRolls.Show()
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F5
                ToolStripLogin.PerformClick()
            Case Keys.F6
                ToolStripChangePaperRoll.PerformClick()
            Case Keys.F7
                ToolStripAddpaperroll.PerformClick()
            Case Keys.F8
                ToolStripAdjusment.PerformClick()
            Case Keys.F9
                ToolStripMonitor.PerformClick()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Private Sub ToolStripAddpaperroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAddpaperroll.Click
        CloseForms("frmPaperRoll")

        frmPaperRoll.TopLevel = False
        Panel1.Controls.Add(frmPaperRoll)
        frmPaperRoll.Show()
    End Sub

    Private Sub InitializePaperRollToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InitializePaperRollToolStripMenuItem.Click
        CloseForms("frmLoadingPaper")

        frmLoadingPaper.TopLevel = False
        Panel1.Controls.Add(frmLoadingPaper)
        frmLoadingPaper.Show()

    End Sub

 Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.MaximumSize = New Size(850, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

 
    Private Sub ToolStripAdjusment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAdjusment.Click
        CloseForms("frmUnallocatedPapercut")

        frmUnallocatedPapercut.TopLevel = False
        Panel1.Controls.Add(frmUnallocatedPapercut)
        frmUnallocatedPapercut.Show()

    End Sub

    Private Sub ToolStripMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMonitor.Click
        CloseForms("frmMonitoring")

        frmMonitoring.TopLevel = False
        Panel1.Controls.Add(frmMonitoring)
        frmMonitoring.Show()

    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        CloseForms("frmUseManagement")

        frmUseManagement.TopLevel = False
        Panel1.Controls.Add(frmUseManagement)
        frmUseManagement.Show()
    End Sub

    Private Sub DailyTotalToolCount1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyTotalToolCount1.Click
        DailyTotal = "Daily"
        frmDailyCounter.Show()
    End Sub

    Private Sub GrandTotalCountGrandTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrandTotalCountGrandTotal.Click
        frmDailyCounter.Show()
    End Sub

    Private Sub AdjustmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentReportToolStripMenuItem.Click
        frmQDate.RPTType = frmQDate.ReportType.Adjustment
        frmQDate.Show()
    End Sub

    Private Sub ProductionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionToolstrip.Click
        frmQDate.RPTType = frmQDate.ReportType.Production
        frmQDate.Show()
    End Sub

    Private Sub EmptyPaperRollReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyPaperRollReportToolStripMenuItem.Click
        frmQDate.RPTType = frmQDate.ReportType.PaperRollEmpty
        frmQDate.Show()
    End Sub
End Class