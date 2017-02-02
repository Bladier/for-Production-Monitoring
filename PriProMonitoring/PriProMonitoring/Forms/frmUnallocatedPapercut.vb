Public Class frmUnallocatedPapercut
    Dim mysql As String = String.Empty
    Dim SelectedPaPRoll As PaperRoll

    Private Sub frmUnallocatedPapercut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadUnAllocatedsalesLine()
    End Sub

    Private Sub LoadUnAllocatedsalesLine()
        mysql = "SELECT * FROM TBL_PROLINE WHERE PAPROLL_SERIAL = 'Unallocated'"

        Dim ds As DataSet = LoadSQL(mysql, "tbl_proline")

        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                Dim lv As ListViewItem = LVUnallocatedPapCut.Items.Add(.Item("ID"))
                lv.SubItems.Add("")
                lv.SubItems.Add(.Item("PAPCUT_CODE"))
                lv.SubItems.Add(.Item("PAPCUT_DESC"))
                lv.SubItems.Add("")
            End With
        Next
    End Sub

    Private Sub LVUnallocatedPapCut_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVUnallocatedPapCut.DoubleClick
        Dim selectedPaperCut As New PaperCut

        selectedPaperCut.PapCutcode = LVUnallocatedPapCut.SelectedItems(0).SubItems(2).Text 'load papercut

        selectedPaperCut.Load_pcuts()

        Console.WriteLine(selectedPaperCut.PapcutID)

        mysql = "SELECT P.PRPC_ID,PM.PAPID ,P.PROLL_ID,PM.PAPCODE,R.PAPROLL_SERIAL " & _
            "FROM TBLPROLLANDPCUTS P  " & _
            "INNER JOIN TBLPAPROLL_MAIN PM ON P.PROLL_ID = PM.PAPID " & _
            "LEFT JOIN TBLPAPERROLL R ON R.PAPIDS = P.PROLL_ID " & _
            "WHERE PCUT_ID = '" & selectedPaperCut.PapcutID & "'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPROLLANDPCUTS")

        frmAvailablePaperRoll.LvpaperRoll.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = frmAvailablePaperRoll.LvpaperRoll.Items.Add(dr.Item("PROLL_ID"))
            lv.SubItems.Add(dr.Item("PAPID"))
            lv.SubItems.Add(dr.Item("PAPCODE"))
            lv.SubItems.Add(dr.Item("PAPROLL_SERIAL"))
        Next

        frmAvailablePaperRoll.Show()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If LVUnallocatedPapCut.Items.Count = 0 Then Exit Sub

        Dim saveAjustment As New SalesLine
        With saveAjustment
            For Each itm As ListViewItem In LVUnallocatedPapCut.Items
                If itm.SubItems(4).Text = "" Then
                    On Error Resume Next
                Else
                    mysql = "select * from tbl_proline where papcut_code = '" & itm.SubItems(2).Text & "' " & _
                    "AND ID = '" & itm.SubItems(0).Text & "'"
                    Dim ds As DataSet = LoadSQL(mysql, "tbl_proline")

                    Dim SubTotal As Double = ds.Tables(0).Rows(0).Item("SUBTOTAL_LENGTH")

                    Console.WriteLine("COUNT:" & ds.Tables(0).Rows.Count)

                    With ds.Tables(0).Rows(0)
                        .Item("PAPID") = itm.SubItems(1).Text
                        .Item("PAPROLL_SERIAL") = itm.SubItems(4).Text
                        .Item("status") = 1
                    End With
                    database.SaveEntry(ds, False)


                    SelectedPaPRoll = New PaperRoll
                    SelectedPaPRoll.PaperRollSErial = itm.SubItems(4).Text
                    SelectedPaPRoll.Remaining = SubTotal * Meter ' Deduct by meter to paper roll
                    SelectedPaPRoll.Updatepaper() ' Deduct Paper Roll
                End If
            Next
        End With


        MsgBox("Posted.", MsgBoxStyle.Information, "Post")
        LVUnallocatedPapCut.Items.Clear()
        frmUnallocatedPapercut_Load(sender, e)
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

    Private Sub btnCLose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLose.Click
        Me.Close()
    End Sub
End Class