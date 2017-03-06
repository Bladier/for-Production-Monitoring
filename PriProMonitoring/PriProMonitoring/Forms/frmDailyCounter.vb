Public Class frmDailyCounter
    Dim mysql As String = String.Empty

    Private Sub frmDailyCounter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DailyTotal = "Daily" Then
            DT_Load_PC() 'Daily Total
            DailyTotal = ""
            txtTotal.Text = Daily_Total()
        Else
            Visible_fields()
            GT_Load_PC() 'Grand Total
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

        Try
            Console.WriteLine("Paper Cut Total count:" & ds.Tables(0).Rows.Count)
            lvDailyCount.Items.Clear()
            For Each dr As DataRow In ds.Tables(0).Rows

                mysql = "SELECT SUM(PL.QUANTITY) AS COUNTER FROM TBL_PROLINE PL " & _
                        "WHERE PAPCUT_CODE  = '" & dr.Item("Papcut_code") & "' AND PL.CREATED_AT ='" & DateTimePicker1.Text & "' " & _
                        "AND PAPID <> '0'"
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
        Catch ex As Exception
            Console.WriteLine("No prints in this paper cut.")
        End Try
        
    End Sub

    ''' <summary>
    ''' This shows Grand Total
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GT_Load_PC()
        mysql = "SELECT * FROM TBLPAPERCUT ORDER BY PAPERCUT_ID"
        Dim ds As DataSet = LoadSQL(mysql, "tblpapercut")

        Try
            Console.WriteLine("Paper Cut Total count:" & ds.Tables(0).Rows.Count)
            lvDailyCount.Items.Clear()
            For Each dr As DataRow In ds.Tables(0).Rows

                mysql = "SELECT SUM(PL.QUANTITY) AS COUNTER FROM TBL_PROLINE PL " & _
                        "WHERE PAPCUT_CODE  = '" & dr.Item("Papcut_code") & "' " & _
                        "AND PAPID <> '0'"
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
        Catch ex As Exception
            Console.WriteLine("No prints in this paper cut.")
        End Try
       
    End Sub

    Private Sub Visible_fields()
        DateTimePicker1.Visible = False
        Label1.Visible = False
        lvDailyCount.Dock = DockStyle.Fill
        Label2.Visible = False
        txtTotal.Visible = False
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

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        DT_Load_PC()
        txtTotal.Text = Daily_Total()
    End Sub

    ''' <summary>
    ''' This Function Calculate Daily Total ALL prints in the machine
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Daily_Total() As Integer
        Dim Count As Double = 0.0
        Dim Total As Integer
        For Each lv As ListViewItem In lvDailyCount.Items
            Count = Val(lv.SubItems(2).Text)
            Total += Count
        Next

        Return Total
    End Function
End Class