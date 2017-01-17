Public Class FrmMain
    Private locked As Boolean
    Private MagazineStatus As Boolean
    Dim CheckLastID As String = ""

    Dim tmplastSalesID As String
    Dim tmpdate As String

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        locked = IIf(GetOption("Locked") = "YES", True, False)

        'file
        AdjustmentToolStripMenuItem.Enabled = Not st

        If Not locked Then
            SetUpDatabaseToolStripMenuItem.Enabled = st
            LoadIMDToolStripMenuItem1.Enabled = st
        Else
            SetUpDatabaseToolStripMenuItem.Enabled = Not st
            LoadIMDToolStripMenuItem1.Enabled = Not st
        End If

        LoadMagazineToolStripMenuItem.Enabled = Not st

        AddMagazineToolStripMenuItem.Enabled = Not st
        AddPaperRollToolStripMenuItem.Enabled = Not st
        TransactionToolStripMenuItem.Enabled = Not st
        AddItemToolStripMenuItem.Enabled = Not st

        LoadSalesToolStripMenuItem.Enabled = Not st

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

    Private Sub SetupDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetUpDatabaseToolStripMenuItem.Click
        Dim child As New frmSetupDatabase
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub TmpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmpTimer.Tick
        If menuLogin.Text = "&Login" Then
            statusDateandTime.Text = "Date not set"
        Else
            statusDateandTime.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
        End If
    End Sub

    Private Sub AddMagazineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMagazineToolStripMenuItem.Click
        frmMagazine.Show()
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

    Private Sub LoadIMDToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadIMDToolStripMenuItem1.Click
        frmImportIMDD.Show()
    End Sub

 
    Private Sub AdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdjustmentToolStripMenuItem.Click
        frmAdjustment.Show()
    End Sub

    Private Sub LoadSalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadSalesToolStripMenuItem.Click
        frmSales.Show()
    End Sub

    Private Sub SalesWatcher_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesWatcher.Tick
        If ToolStripSplitButton1.Enabled = False Then
            SalesWatcher.Stop()
            Exit Sub
        End If

        ToolStripSplitButton1.PerformButtonClick()
    End Sub

    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
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

                If GetOption("LastSalesID") = tmplastSalesID Then _
                    MsgBox("No new row data in sales", MsgBoxStyle.Information, "Sales") : Exit Sub

                UpdateOptionSales("LastSalesID", tmplastSalesID, tmpdate)

                Dim SaveSales As New Sales
                With SaveSales
                    Dim POSsales As String = "SELECT I.ID,I.ITEMNO,M.ITEMNAME AS DESCRIPTION,E.TRANSDATE," & _
                                             "I.QTY,E.DATESTAMP FROM POSITEM I " & _
                                            "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                            "INNER JOIN ITEMMASTER M ON I.ITEMNO = M.ITEMNO " & _
                                            "where E.DATESTAMP > '" & tmpRemarks & "'" & _
                                             "ORDER BY E.DATESTAMP ASC "

                    Dim ds As DataSet = LoadSQLPOS(POSsales, "POSITEM")
                    If ds.Tables(0).Rows.Count <= 0 Then Exit Sub

                    Console.WriteLine("Count: " & ds.Tables(0).Rows.Count)
                    Dim max As Integer = ds.Tables(0).Rows.Count

                    Count.Text = max

                    For Each dr As DataRow In ds.Tables(0).Rows
                        .ItemCode = dr.Item("ItemNo")
                        .Descrition = dr.Item("Description")
                        .SalesID = dr.Item("ID")
                        .QTY = dr.Item("QTY")
                        .SaveSales()

                        ToolStripPBar.Maximum = max
                        ToolStripPBar.Value = ToolStripPBar.Value + 1
                        Application.DoEvents()
                        lblToolStripStatus.Text = String.Format("{0}%", ((ToolStripPBar.Value / ToolStripPBar.Maximum) * 100).ToString("F2"))
                    Next

                    If MsgBox("Sales Updated.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
        "Sales...") = MsgBoxResult.Ok Then ToolStripPBar.Minimum = 0 : ToolStripPBar.Value = 0 : lblToolStripStatus.Text = "0.00%"


                End With
            End If
        End If
    End Sub
  
    Private Sub ToolStripSplitButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.Click
        ToolStripSplitButton1.Enabled = False
        bgWorker.RunWorkerAsync()
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        ToolStripSplitButton1.Enabled = True
    End Sub

  
End Class