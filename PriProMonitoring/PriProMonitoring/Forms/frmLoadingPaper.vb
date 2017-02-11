Public Class frmLoadingPaper
    Private Count_Chamber As Integer = GetOption("Number Chamber")

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmPaperRoll_List_Chamber.txtsearch1.Text = txtSearch.Text
        frmPaperRoll_List_Chamber.Show()
    End Sub

    Private Sub btnsetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetup.Click
        If lvpapList.Items.Count = 0 Then Exit Sub


        If Count_Chamber = 2 Then
            If lvpapList.Items.Count < Count_Chamber Then MsgBox("This branch has two Chamber" & vbCrLf & "Add one paper.", _
                MsgBoxStyle.Critical, "Sepup") : Exit Sub

            For Each itm As ListViewItem In lvpapList.Items
                UpdateRollstatus(itm.SubItems(2).Text, "1")
                savePapLog(itm.SubItems(0).Text)
            Next
        Else
            For Each itm As ListViewItem In lvpapList.Items
                UpdateRollstatus(itm.SubItems(2).Text, "1")
                savePapLog(itm.SubItems(0).Text)
            Next
        End If


        UpdateOptions("Magazine", "YES") 'Set magazine load

        MsgBox("PAPER ROLL has been initialized", MsgBoxStyle.Information, "PAPER ROLL")
        Me.Close()
    End Sub



    Friend Sub UpdateRollstatus(ByVal serial As String, ByVal status As Integer)
        Dim mySql As String = "SELECT * FROM TBLPAPERROLL WHERE paproll_serial = '" & serial & "'"
        Dim fillData As String = "TBLPAPERROLL"
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("status") = status
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub


    Private Sub savePapLog(ByVal PaperRollID As Integer)
        Dim getremaining As New PaperRoll
        getremaining.LoadProll(PaperRollID)

        Dim savelog As New PaperLoadLog
        savelog.PaprollID = PaperRollID
        savelog.loaded_by = CurrentUser
        savelog.Remaining = getremaining.Remaining
        savelog.Modname = "Paper roll Initialization"
        savelog.SaveRoll()
    End Sub

    Private Sub frmLoadingPaper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class