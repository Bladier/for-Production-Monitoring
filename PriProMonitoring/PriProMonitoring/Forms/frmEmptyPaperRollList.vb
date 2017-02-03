Public Class frmEmptyPaperRollList
    Dim tmplist As PaperRoll
    Friend TmpPap As String = frmMonitoring.txtSearch.Text




    Private Sub frmEmptyPaperRollList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim fillData As String = "tblpaperRoll"


        If frmMonitoring.txtSearch.Text = "" Then

            Dim mysql As String = "SELECT P.PAPROLL_ID,R.PAPCODE,R.PAPDESC,P.PAPROLL_SERIAL "
            mysql &= vbCrLf & " FROM " & fillData & " P	"
            mysql &= vbCrLf & " INNER JOIN TBLPAPROLL_MAIN R ON R.PAPID = P.PAPIDS "
            mysql &= vbCrLf & "WHERE STATUS = '2' "
            Dim ds As DataSet = LoadSQL(mysql, fillData)
            If ds.Tables(0).Rows.Count = 0 Then Exit Sub

            Lvlist.Items.Clear()

            For Each dr As DataRow In ds.Tables(0).Rows
                With dr
                    Dim lv As ListViewItem = Lvlist.Items.Add(.Item("PAPROLL_ID"))
                    lv.SubItems().Add(.Item("PAPCODE"))
                    lv.SubItems().Add(.Item("PAPDESC"))
                    lv.SubItems().Add(.Item("PAPROLL_SERIAL"))
                End With
            Next
        Else
            Dim mysql As String = "SELECT P.PAPROLL_ID,R.PAPCODE,R.PAPDESC,P.PAPROLL_SERIAL "
            mysql &= vbCrLf & " FROM TBLPAPERROLL P	"
            mysql &= vbCrLf & " INNER JOIN TBLPAPROLL_MAIN R ON R.PAPID = P.PAPIDS "
            mysql &= vbCrLf & "WHERE STATUS = '2' and UPPER(Paproll_serial) = UPPER('" & TmpPap & "')"
            Dim ds As DataSet = LoadSQL(mysql, fillData)

            If ds.Tables(0).Rows.Count = 0 Then Exit Sub
            Lvlist.Items.Clear()
            For Each dr As DataRow In ds.Tables(0).Rows
                With dr
                    Dim lv As ListViewItem = Lvlist.Items.Add(.Item("PAPROLL_ID"))
                    lv.SubItems().Add(.Item("PAPCODE"))
                    lv.SubItems().Add(.Item("PAPDESC"))
                    lv.SubItems().Add(.Item("PAPROLL_SERIAL"))
                End With
            Next
        End If

    End Sub
   
    Private Sub Lvlist_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Lvlist.MouseClick
        Me.Text = Lvlist.SelectedItems(0).SubItems(3).Text
    End Sub


    Friend Function PapSerial(ByVal str As String) As String
        Return str
    End Function


    Private Sub Lvlist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lvlist.DoubleClick
        If Lvlist.Items.Count = 0 Then Exit Sub
        If Lvlist.SelectedItems.Count = 0 Then
            Lvlist.Items(0).Focused = True
        End If

        Dim serial As String = Lvlist.SelectedItems(0).SubItems(3).Text

        frmMonitoring.PopulateCount(serial)
        frmMonitoring.Show()
        Me.Hide()
    End Sub

    Private Sub Lvlist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Lvlist.KeyPress
        If isEnter(e) Then Lvlist_DoubleClick(sender, e)
    End Sub
End Class