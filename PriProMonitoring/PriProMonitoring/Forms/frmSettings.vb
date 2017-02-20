Imports Microsoft.Office.Interop
Public Class frmSettings
    Private locked As Boolean = IIf(GetOption("Locked") = "YES", True, False)
    Dim checkBranchCode As String
    Private LastSaleID As String

    Dim tmplastSalesID As String
    Dim tmpdate As String

    Dim tmpchamber As New Chamber
    Dim save_all_user As New ComputerUser

    Private Sub Disabled()
        Me.MaximumSize = New Size(689, 271)
        Me.MinimumSize = Me.MaximumSize
    End Sub

    Private Function IsValid() As Boolean
        If txtChamber.Text = "" Then txtChamber.Focus() : Return False
        If txtpath.Text = "" Then txtpath.Focus() : Return False
        If txtPapercut.Text = "" Then txtPapercut.Focus() : Return False
        If txtPAPERROLL.Text = "" Then txtPAPERROLL.Focus() : Return False
        Return True
    End Function

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Disabled()
        If locked Then
            txtChamber.Text = GetOption("Number Chamber")
            txtBranchCode.Text = GetOptionpPOS("Branch Code")
            txtBranchname.Text = GetOptionpPOS("Branch Name")
            txtAreacode.Text = GetOptionpPOS("Area Code")
            txtAreaname.Text = GetOptionpPOS("Area Name")
            txtVersion.Text = GetOptionpPOS("Version")
            txtpath.Text = GetOption("DatabasePOS")
        End If

        checkBranchCode = GetOption("Branch Code")
        If checkBranchCode <> "" Then
            btnSave.Text = "&Update"
        End If

    End Sub

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not IsValid() Then Exit Sub

        If btnSave.Text = "&Save" Then
            Me.Enabled = False
            SaveDatabasePath() 'save database path

            databasePOS.dbNamePOS = GetOption("DatabasePOS")

            txtBranchCode.Text = GetOptionpPOS("Branch Code")
            txtBranchname.Text = GetOptionpPOS("Branch Name")
            txtAreacode.Text = GetOptionpPOS("Area Code")
            txtAreaname.Text = GetOptionpPOS("Area Name")
            txtVersion.Text = GetOptionpPOS("Version")

            LoadIMD() ' lOADING IMD
            ImportPaperRoll() 'Paper roll
            ImportPapercut() 'ImportPapercut
            GetLastSales() 'Setup sales

            UpdateOptions("Branch Code", txtBranchCode.Text)
            UpdateOptions("Branch Name", txtBranchname.Text)
            UpdateOptions("Area Code", txtAreacode.Text)
            UpdateOptions("Area Name", txtAreaname.Text)
            UpdateOptions("Version", txtVersion.Text)
            UpdateOptions("Number Chamber", txtChamber.Text)


            If txtChamber.Text = 1 Then
                tmpchamber.PoputlateChamberOnlyOne()
            Else
                tmpchamber.PoputlateChamber()
            End If

            MsgBox("New branch has been setup", MsgBoxStyle.Information, "Setup")
            FrmMain.Enabled = True
            FrmMain.NotYetLogin()
            Me.Enabled = True
            Me.Close()

        Else

            Me.Enabled = False
            LoadIMD()
            UpdatePaperRoll()
            ImportPapercut()

            MsgBox("Data updated", MsgBoxStyle.Information, "Settings")
            FrmMain.Enabled = True
            Me.Enabled = True
            Me.Close()
        End If

    End Sub

    Private Sub SaveDatabasePath()
        Dim str As String
        str = txtpath.Text
        If str.Contains(".FDB") = True Then
            If Not locked Then
                UpdateSetting()
            End If
        Else
            MsgBox("The file type is not valid" & vbCrLf & "Please try again!", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Friend Sub UpdateSetting()
        'First
        If Not locked Then
            UpdateOptions("DatabasePOS", txtpath.Text)
            UpdateOptions("Locked", "YES")
        End If
    End Sub

    Private Sub LoadIMD()
        databasePOS.dbNamePOS = GetOption("DatabasePOS")

        'If databasePOS.dbNamePOS = "ANOISIM.FDB" Or databasePOS.dbNamePOS = "" Then Exit Sub

        'Dim ans As DialogResult = MsgBox("Do you want to load IMD data?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        'If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim mysql As String = "SELECT ITEMNO,ITEMNAME FROM IMD"
        Dim ds As DataSet = LoadSQLPOS(mysql, "ItemMaster")

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim itmsave As New item
            itmsave.ItemCode = dr.Item("ITEMNO")
            itmsave.Load_ItemCode()

            With itmsave
                .ItemCode = dr.Item("ITEMNO")
                .Descrition = dr.Item("ITEMNAME")
                .SaveItem()
            End With

        Next
    End Sub

    Friend Sub GetLastSales()
        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        LastSaleID = GetOption("LastSalesID")

        If CheckSalesIFNull() Then Exit Sub

        LastSaleID = GetOption("LastSalesID")

        If LastSaleID = "" Then
            tmplastSalesID = GetLastSaledID(0)
            tmpdate = GetLastSaledID(1)

            Dim updatemainTainance As New GetSalesID

            With updatemainTainance
                .OPTVALUES = tmplastSalesID
                .REMARKS = tmpdate
            End With
            updatemainTainance.UPDATE_MAINTAINANCE("LastSalesID ")
        End If

    End Sub

    Private Function GetLastSaledID() As String()

        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        Dim mysql As String = "select I.ID,I.itemno,E.TRANSDATE,E.DATESTAMP from POSITEM I " & _
                                "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                 "ORDER BY E.DATESTAMP DESC rows 1"

        Dim ds As DataSet = LoadSQLPOS(mysql, "POSITEM")

        Dim tmpdate As Date = ds.Tables(0).Rows(0).Item("DATESTAMP")

        Console.WriteLine(ds.Tables(0).Rows(0).Item("ID"))
        Dim ID As String() = {ds.Tables(0).Rows(0).Item("ID"), tmpdate}

        Return ID
    End Function

    Private Function GetLastEntry() As String()
        Dim LastTimeStamp As String = GetRemarks("LastSalesID")
        If LastTimeStamp = "" Then Return Nothing
        Dim ID As String()

        LastTimeStamp = LastTimeStamp.Remove(LastTimeStamp.Length - 2)

        databasePOS.dbNamePOS = GetOption("DatabasePOS")
        Dim mysql As String = "select I.ID,I.itemno,E.TRANSDATE,E.DATESTAMP from POSITEM I " & _
                                "INNER JOIN POSENTRY E ON I.POSENTRYID = E.ID " & _
                                 "where E.DATESTAMP > '" & LastTimeStamp & "' " & _
                                 "ORDER BY E.DATESTAMP DESC rows 1"

        Dim ds As DataSet = LoadSQLPOS(mysql, "POSITEM")


        If ds.Tables(0).Rows.Count = 0 Then
            ID = {"", ""}
            Return ID
        End If

        Dim tmpdate As Date = ds.Tables(0).Rows(0).Item("DATESTAMP")

        Console.WriteLine(ds.Tables(0).Rows(0).Item("ID"))

        ID = {ds.Tables(0).Rows(0).Item("ID"), tmpdate}

        Return ID
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        ofdIMD.ShowDialog()
        txtpath.Text = ofdIMD.FileName
    End Sub

    Private Sub btnBrowseMagazine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseMagazine.Click
        OFDMagazine.ShowDialog()
        txtPAPERROLL.Text = OFDMagazine.FileName
    End Sub

    Private Sub btnBrowsepapecut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsepapecut.Click
        OFDPapercut.ShowDialog()
        txtPapercut.Text = OFDPapercut.FileName
    End Sub

    Private Sub ImportPapercut()
        Dim fileName As String = txtPapercut.Text
        Dim isDone As Boolean = False

        If fileName = "" Then Exit Sub

        'Load PAPER CUT
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(fileName)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        For cnt = 2 To MaxEntries
            Dim ImportedItem As New item

            If Not ImportedItem.CHeckIMD Then GoTo NextToExit

            With ImportedItem
                .ItemCode = oSheet.Cells(cnt, 1).Value
                ImportedItem.Load_ItemCode()

                Dim itmLineSave As New ItemLine
                Dim tmpPaperCut As New PaperCut

                ' tmpPaperCut.papcutDescription = oSheet.Cells(cnt, 2).Value
                tmpPaperCut.PapCutcode = oSheet.Cells(cnt, 2).Value
                tmpPaperCut.Load_pcuts()
                'itmLineSave.Load_Itmline()

                itmLineSave.Item_ID = .ID
                itmLineSave.PaperCut_ID = tmpPaperCut.PapcutID
                itmLineSave.QTY = oSheet.Cells(cnt, 4).Value

                itmLineSave.Save_itemLine()
            End With
        Next

        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing
        Exit Sub


NextToExit: MsgBox("Please load IMD First!", MsgBoxStyle.Critical, "Import")
    End Sub

    Private Sub ImportPaperRoll()
        Dim fileName As String = OFDMagazine.FileName
        Dim isDone As Boolean = False

        If fileName = "" Then Exit Sub


        'Load PAPER ROLL
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(fileName)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row


        Me.Enabled = False
        For cnt = 2 To MaxEntries

            Dim paproll As New PAPERROLLMAIN

            With paproll
                .PAPERCODE = oSheet.Cells(cnt, 1).Value
                .PAPERDESCRIPTION = oSheet.Cells(cnt, 2).Value
                If txtChamber.Text = 1 Then
                    .ChamberDesc = "Chamber B"
                Else
                    .ChamberDesc = oSheet.Cells(cnt, 3).Value
                End If
            End With
            paproll.Save_Magazine()

            Dim SAVEPAPERCUT As New PaperCut
            With SAVEPAPERCUT

                .PapCutcode = oSheet.Cells(cnt, 4).Value
                .papcutDescription = oSheet.Cells(cnt, 5).Value
                .papcut = oSheet.Cells(cnt, 6).Value

            End With
            SAVEPAPERCUT.SavepapCut()

            SAVEPAPERCUT.PapCutcode = oSheet.Cells(cnt, 4).Value
            SAVEPAPERCUT.Load_pcuts()

            Dim saveProllandPcuts As New PapRollAndPapCut
            With saveProllandPcuts
                .PapRollID = paproll.gETPAPID(paproll.PAPERCODE) ' return paper roll ID
                .PapcutID = SAVEPAPERCUT.PapcutID
                .Save()
            End With
        Next

        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

    End Sub


    Private Sub UpdatePaperRoll()
        Dim fileName As String = OFDMagazine.FileName
        Dim isDone As Boolean = False

        If fileName = "" Then Exit Sub

        'Load Paper roll
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(fileName)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row


        Me.Enabled = False
        For cnt = 2 To MaxEntries

            Dim paproll As New PAPERROLLMAIN

            With paproll
                .PAPERCODE = oSheet.Cells(cnt, 1).Value
                .PAPERDESCRIPTION = oSheet.Cells(cnt, 2).Value
                If txtChamber.Text = 1 Then
                    .ChamberDesc = "Chamber B"
                Else
                    .ChamberDesc = oSheet.Cells(cnt, 3).Value
                End If
            End With
            paproll.Save_Magazine()

            Dim SAVEPAPERCUT As New PaperCut

            With SAVEPAPERCUT
                .PapCutcode = oSheet.Cells(cnt, 4).Value
                .papcutDescription = oSheet.Cells(cnt, 5).Value
                .papcut = oSheet.Cells(cnt, 6).Value
            End With
            SAVEPAPERCUT.SavepapCut()

            Dim saveProllandPcuts As New PapRollAndPapCut
            paproll.gETPAPID(oSheet.Cells(cnt, 1).Value)

            SAVEPAPERCUT.PapCutcode = oSheet.Cells(cnt, 4).Value
            SAVEPAPERCUT.Load_pcuts()

            saveProllandPcuts.GetID(paproll.PAPID, SAVEPAPERCUT.PapcutID)

            With saveProllandPcuts
                .PapRollID = paproll.PAPID
                .PapcutID = SAVEPAPERCUT.PapcutID
                .update()
            End With
        Next

        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

    End Sub

    Private Sub txtChamber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChamber.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub frmSettings_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        FrmMain.Enabled = True
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.Close()
            Case Else
                Return False
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class