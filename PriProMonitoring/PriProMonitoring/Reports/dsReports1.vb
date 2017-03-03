Partial Class dsReports1
    Partial Class AdjustmentsDataTable

        Private Sub AdjustmentsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.PAPROLL_SERIALColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

   

End Class
