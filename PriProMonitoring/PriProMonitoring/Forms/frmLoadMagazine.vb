Public Class frmLoadMagazine
    Private MagazineStatus As Boolean = IIf(GetOption("Magazine") = "YES", True, False)

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        frmMagAndPapRollList.txtSearch.Text = txtserial.Text
        frmMagAndPapRollList.Show()
        Me.Close()
    End Sub

    Private Sub frmLoadMagazine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MagazineStatus Then
            txtserial.Enabled = False : btnsearch.Enabled = False

            txtserial.Text = GetActivePAPERROLL()
            btnsearch.Text = "ACTIVE"
            Me.Text = "Load Magazine" & " | " & GetMagazine(GetActivePAPERROLL)
        Else
            btnsearch.Text = "Search"
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

End Class