Imports System.Threading
Public Class frmLoadMagazine
    Private MagazineStatus As Boolean = IIf(GetOption("Magazine") = "YES", True, False)

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        frmPaperRolls.txtSearch.Text = txtserial.Text
        frmPaperRolls.Show()
    End Sub

    Private Sub frmLoadMagazine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not MagazineStatus Then
            Me.Enabled = True
        Else
            Me.Enabled = False
        End If
    End Sub


    Private Function GetActivePAPERROLL() As String
        Dim mysql As String = " SELECT * FROM TBLPAPERROLL " _
                              & " WHERE STATUS <> 0 "
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERCUT")
        If ds.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If
        Return ds.Tables(0).Rows(0).Item("PAPROLL_SERIAL")
    End Function


    Private Function GetMagazine(ByVal mag As String) As String
        Dim mysql As String = " SELECT * FROM tblmagazine m inner join tblpaperroll p " _
                              & "on m.mag_ID = p.mag_ids" _
                              & String.Format(" WHERE paproll_serial = '{0}'", mag)
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERCUT")
        If ds.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If
        Return ds.Tables(0).Rows(0).Item("Magdescription")
    End Function

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        If lvPaproll.Items.Count < 2 Then Exit Sub

        For Each itm As ListViewItem In lvPaproll.Items
            UpdateRollstatus(itm.SubItems(4).Text, "1", itm.SubItems(2).Text)
        Next

        UpdateOptions("Magazine", "YES") 'Set magazine load

        MsgBox("Magazine has been initialized", MsgBoxStyle.Information, "Magazine")
        Me.Close()
    End Sub


    Friend Sub UpdateRollstatus(ByVal serial As String, ByVal status As Integer, ByVal chamTag As String)
        Dim mySql As String = "SELECT * FROM TBLPAPERROLL WHERE paproll_serial = '" & serial & "'"
        Dim fillData As String = "TBLPAPERROLL"
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count = 1 Then
            With ds.Tables("TBLPAPERROLL").Rows(0)
                .Item("Updated_at") = Now
                .Item("AddedBy") = FrmMain.statusUser.Text
                .Item("status") = status
                .Item("Chamber") = chamTag
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

    Private Sub txtserial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtserial.KeyPress
        If isEnter(e) Then btnsearch.PerformClick()
    End Sub
End Class