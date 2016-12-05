Public Class frmMagazineList
    Private fromOtherForm As Boolean = False
    Private frmOrig As formSwitch.FormName
    Dim ds As New DataSet
    Private Magazine_ht As Hashtable
    Dim tmpMagazine As Magazine



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    Private Sub clearFields()
        lvPaperCut.Items.Clear()
    End Sub

    Private Sub frmMagazineList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getMagID.Visible = False
        If Not fromOtherForm Then clearFields() : txtSearch.Focus()
        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        Else
            LoadActive_Magazine()
        End If
    End Sub


    Private Sub LoadActive_Magazine(Optional ByVal mySql As String = "SELECT * FROM tblmagazine WHERE mag_ID <> 0")

        Dim ds As DataSet = LoadSQL(mySql)

        Magazine_ht = New Hashtable
        lvPaperCut.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim magazine As New Magazine
            magazine.LoadByRow(dr)
            AddItem(magazine)

            Magazine_ht.Add(magazine.ID, magazine)
        Next
    End Sub

    Private Sub AddItem(ByVal mag As Magazine)
        Dim lv As ListViewItem = lvPaperCut.Items.Add(mag.ID)
        lv.SubItems.Add(mag.MagItemCode)
        lv.SubItems.Add(mag.MagDescription)
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvPaperCut.Items.Count = 0 Then Exit Sub
        If lvPaperCut.SelectedItems.Count = 0 Then
            lvPaperCut.Items(0).Focused = True
        End If

        Dim idx As Integer
        idx = CInt(lvPaperCut.FocusedItem.Text)
        getMagID.Text = idx

        Dim SelectedMagazine As New Magazine
        For Each dt As DictionaryEntry In Magazine_ht
            If dt.Key = idx Then

                SelectedMagazine = dt.Value
                formSwitch.ReloadFormFromSearch(frmOrig, SelectedMagazine)
                Me.Hide()
                Exit Sub
            End If
        Next

        MsgBox("Error loading hash table", MsgBoxStyle.Critical, "CRITICAL")
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lvPaperCut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaperCut.SelectedIndexChanged

    End Sub

  
    Private Sub btnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        Dim mySql As String = "SELECT * FROM tblmagazine WHERE "
        mySql &= String.Format("(UPPER (magItemcode) LIKE UPPER('%{0}%') OR UPPER (magDescription) LIKE UPPER('%{0}%')) ", secured_str)
        mySql &= "ORDER BY mag_ID ASC"

        LoadActive_Magazine(mySql)
        MsgBox(String.Format("{0} Magazine found.", lvPaperCut.Items.Count), MsgBoxStyle.Information)
    End Sub

    Private Sub lvPaperCut_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPaperCut.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub lvPaperCut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPaperCut.KeyPress
        Console.WriteLine("ENTER!")
        If isEnter(e) Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub lvPaperCut_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvPaperCut.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not fromOtherForm Then
                btnSelect.PerformClick()
            End If
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class