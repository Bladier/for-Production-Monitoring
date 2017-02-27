Public Class frmDailyCounter
    Dim mysql As String = String.Empty

    Private Sub frmDailyCounter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DailyTotal = "Daily" Then
            DT_Load_PC()
            DailyTotal = ""
        Else
            GT_Load_PC()
            Me.Text = "Grand Total|Count"
        End If
    End Sub

    ''' <summary>
    ''' This shows daily total prints
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DT_Load_PC()
        mysql = "SELECT * FROM TBLPAPERCUT ORDER BY PAPERCUT_ID"
        Dim ds As DataSet = LoadSQL(mysql, "tblpapercut")

        Console.WriteLine("Paper Cut Total count:" & ds.Tables(0).Rows.Count)

        For Each dr As DataRow In ds.Tables(0).Rows

            mysql = "SELECT SUM(PL.QUANTITY) AS COUNTER FROM TBL_PROLINE PL " & _
                    "WHERE PAPCUT_CODE  = '" & dr.Item("Papcut_code") & "' AND PL.CREATED_AT ='" & Now.ToShortDateString & "'"
            Dim ds1 As DataSet = LoadSQL(mysql, "tbl_proline")
            Dim counter As String


            If IsDBNull(ds1.Tables(0).Rows(0).Item("Counter")) Then
                counter = ""
            Else
                counter = ds1.Tables(0).Rows(0).Item("Counter")
            End If

            Dim lv As ListViewItem = lvDailyCount.Items.Add(dr.Item("Papercut_ID"))
            lv.SubItems.Add(dr.Item("Papcut_description"))
            lv.SubItems.Add(counter)
        Next
    End Sub

    ''' <summary>
    ''' This shows Grand Total
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GT_Load_PC()
        mysql = "SELECT * FROM TBLPAPERCUT ORDER BY PAPERCUT_ID"
        Dim ds As DataSet = LoadSQL(mysql, "tblpapercut")

        Console.WriteLine("Paper Cut Total count:" & ds.Tables(0).Rows.Count)

        For Each dr As DataRow In ds.Tables(0).Rows

            mysql = "SELECT SUM(PL.QUANTITY) AS COUNTER FROM TBL_PROLINE PL " & _
                    "WHERE PAPCUT_CODE  = '" & dr.Item("Papcut_code") & "'"
            Dim ds1 As DataSet = LoadSQL(mysql, "tbl_proline")
            Dim counter As String


            mysql = "SELECT SUM(AL.QUANTITY) AS QTY FROM TBLADJUSTMENT_LINE AL WHERE PAPCUT_CODE = '" & dr.Item("Papcut_code") & "'"
            Dim ds2 As DataSet = LoadSQL(mysql, "TBLADJUSTMENT_LINE")

            Dim Adj_quantity As Integer

            If IsDBNull(ds2.Tables(0).Rows(0).Item("QTY")) Then
                Adj_quantity = 0
            Else
                Adj_quantity = ds2.Tables(0).Rows(0).Item("QTY")
            End If

            If IsDBNull(ds1.Tables(0).Rows(0).Item("Counter")) Then
                counter = ""
            Else
                counter = ds1.Tables(0).Rows(0).Item("Counter") - Adj_quantity
            End If

            Dim lv As ListViewItem = lvDailyCount.Items.Add(dr.Item("Papercut_ID"))
            lv.SubItems.Add(dr.Item("Papcut_description"))
            lv.SubItems.Add(counter)
        Next
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
End Class