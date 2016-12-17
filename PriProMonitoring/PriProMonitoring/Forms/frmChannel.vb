Public Class frmChannel
    Dim papcuts As Hashtable
    Dim selectedPap As PaperCut
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        loadPapercut()
    End Sub

    Private Sub loadPapercut()
        Dim mysql As String = " SELECT * FROM TBLPAPERCUT P INNER JOIN TBLMAGAZINE M " & _
                             "ON P.MAG_IDP = M.MAG_ID "
        mysql &= String.Format("WHERE (UPPER (PAPCUT_ITEMCODE) LIKE UPPER('%{0}%') OR UPPER (PAPCUT_DESCRIPTION) LIKE UPPER('%{0}%'))", txtSearch.Text)

        Dim ds As DataSet = LoadSQL(mysql, "tblpapercut")


        Loadpapercutss(mysql)
        MsgBox(String.Format("{0} Paper cuts found.", LVPapercut.Items.Count), MsgBoxStyle.Information)
    End Sub



    Private Sub Loadpapercutss(Optional ByVal mySql As String = "SELECT * FROM tblpapercut")

        Dim ds As DataSet = LoadSQL(mySql)

        papcuts = New Hashtable
        LVPapercut.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim pap As New PaperCut
            pap.lOAD_PaperCut_row(dr)
            AddItem(pap)

            papcuts.Add(pap.PapcutID, papcuts)
        Next

    End Sub

    Private Sub AddItem(ByVal papss As PaperCut)
        Dim lv As ListViewItem = LVPapercut.Items.Add(papss.PapcutID)
        lv.SubItems.Add(papss.PapCutITemcode)
        lv.SubItems.Add(papss.papcutDescription)
    End Sub

    Private Sub frmChannel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        Else
            Loadpapercutss()
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        If LVPapercut.Items.Count <= 0 Then Exit Sub

        If LVPapercut.SelectedItems.Count = 0 Then
            LVPapercut.Items(0).Focused = True
            Exit Sub
        End If

        selectedPap = New PaperCut
        selectedPap.Load_PaperCUts(LVPapercut.SelectedItems(0).Text)

        frmItem.dgPapercuts.Rows.Add(selectedPap.PapcutID, selectedPap.PapCutITemcode, selectedPap.papcutDescription)

        frmItem.Show()
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub LVPapercut_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVPapercut.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub LVPapercut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LVPapercut.KeyPress
        If isEnter(e) Then
            btnSelect.PerformClick()
        End If
    End Sub
End Class