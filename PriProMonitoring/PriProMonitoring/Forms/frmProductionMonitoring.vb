Public Class frmProductionMonitoring

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        MsgBox(LOADMAGID(txtmagazine.Text))
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmMagAndPapRollList.txtSearch.Text = txtSEarch.Text
        frmMagAndPapRollList.Show()
    End Sub

    Private Sub txtSEarch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSEarch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtmagazine_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmagazine.TextChanged
        Dim mysql As String = "SELECT P.PAPERCUT_ID,P.MAG_IDP,P.PAPERCUT,P.PAPCUT_ITEMCODE,P.PAPCUT_DESCRIPTION " _
                              & " FROM TBLPAPERCUT P INNER JOIN TBLMAGAZINE M ON M.MAG_ID = P.MAG_IDP" _
                              & " WHERE MAG_IDP ='" & LOADMAGID(txtmagazine.Text) & "'"
        Dim ds As DataSet = LoadSQL(mysql, "TBLPAPERCUT")

        lvpapercuts.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvpapercuts.Items.Add(dr(0))
            lv.SubItems.Add(dr(1))
            lv.SubItems.Add(dr(2))
            lv.SubItems.Add(dr(3))
            lv.SubItems.Add(dr(4))
        Next
    End Sub

    Private Function LOADMAGID(ByVal MAGDESC As String) As Integer
        Dim mysql As String = "SELECT * FROM TBLMAGAZINE WHERE MAGDESCRIPTION = '" & MAGDESC & "'"
        Dim DS As DataSet = LoadSQL(mysql, "TBLMAGAZINE")
        Return DS.Tables(0).Rows(0).Item("mAG_id")
    End Function

    Private Sub frmProductionMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If FrmMain.statusDateandTime.Text = "Date Not Set" Then
        '    Me.Enabled = False
        'Else
        '    Me.Enabled = True
        'End If
    End Sub
End Class