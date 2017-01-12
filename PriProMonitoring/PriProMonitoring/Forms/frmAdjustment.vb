Public Class frmAdjustment

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub

        Dim MYSQL As String = "SELECT * FROM PAPERCUT " & _
                    String.Format("WHERE PAPROLL_SERIAL = {0}", txtSearch.Text)
        Dim ds As DataSet = LoadSQL(MYSQL, "PAPERCUT")

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("This paper roll doesn't existed" & vbCrLf & _
                                                    "Please check the serial.", MsgBoxStyle.Critical, "Adjustment") : Exit Sub

        lvpapercuts.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvpapercuts.Items.Add(dr(0))
            lv.SubItems.Add(dr(1))
            lv.SubItems.Add(dr(2))
            lv.SubItems.Add(dr(3))
            lv.SubItems.Add(dr(4))
            lv.SubItems.Add(dr(5))
            lv.SubItems.Add(dr(6))
            lv.SubItems.Add(dr(7))
            lv.SubItems.Add("")
        Next


    End Sub

    Private Sub lvpapercuts_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvpapercuts.DoubleClick
        InputPapCut()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub lvpapercuts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvpapercuts.KeyPress
        If isEnter(e) Then
            InputPapCut()
        End If
    End Sub

    Private Sub InputPapCut()
        If lvpapercuts.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = CInt(lvpapercuts.FocusedItem.Text)

        Dim tmpPapcut As New PaperCut
        tmpPapcut.Load_PaperCUts(idx)

        Dim value As String
        value = InputBox("Enter Quantity", "Quantity of " & tmpPapcut.papcutDescription)
        lvpapercuts.SelectedItems(0).SubItems(8).Text = value
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click

    End Sub
End Class