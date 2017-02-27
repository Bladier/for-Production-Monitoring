Public Class frmMagazineList
    Private fromOtherForm As Boolean = False
    Private frmOrig As formSwitch.FormName
    Dim MAG As Hashtable
    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub frmMagazineList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        Else
            LOADMAGAZINE()
        End If
    End Sub

    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SEARCH()
    End Sub

    Private Sub SEARCH()
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        Dim mySql As String = "SELECT * FROM TBLPAPROLL_MAIN WHERE "
        mySql &= String.Format("(UPPER (PAPCODE) LIKE UPPER('%{0}%') OR UPPER (PAPDESC) LIKE UPPER('%{0}%'))", secured_str)
        mySql &= "ORDER BY PAPID ASC"

        LOADMAGAZINE(mySql)
        MsgBox(String.Format("{0} PAPER ROLL found.", lvmagazine.Items.Count), MsgBoxStyle.Information)

    End Sub

    Private Sub LOADMAGAZINE(Optional ByVal mySql As String = "SELECT * FROM TBLPAPROLL_MAIN WHERE PAPID <> 0")

        Dim ds As DataSet = LoadSQL(mySql)

        MAG = New Hashtable
        lvmagazine.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim PAP As New PAPERROLLMAIN
            PAP.LoadByRow(dr)
            AddItem(PAP)

            MAG.Add(PAP.PAPID, PAP)
        Next

    End Sub

    Private Sub AddItem(ByVal PAP As PAPERROLLMAIN)
        Dim lv As ListViewItem = lvmagazine.Items.Add(PAP.PAPID)
        lv.SubItems.Add(PAP.PAPERCODE)
        lv.SubItems.Add(PAP.PAPERDESCRIPTION)
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvmagazine.Items.Count = 0 Then Exit Sub
        If lvmagazine.SelectedItems.Count = 0 Then
            lvmagazine.Items(0).Focused = True
        End If

        Dim idx As Integer

        idx = CInt(lvmagazine.FocusedItem.Text)
        LBLID.Text = idx
        Dim selected_magazine As New PAPERROLLMAIN
        For Each dt As DictionaryEntry In MAG
            If dt.Key = idx Then

                selected_magazine = dt.Value
                formSwitch.ReloadFormFromSearch(frmOrig, selected_magazine)
                Me.Hide()
                Exit Sub
            End If
        Next

        MsgBox("Error loading hash table", MsgBoxStyle.Critical, "CRITICAL")
    End Sub

    Private Sub lvmagazine_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvmagazine.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub lvmagazine_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvmagazine.KeyPress
        If isEnter(e) Then
            btnSelect.PerformClick()
        End If
    End Sub
End Class