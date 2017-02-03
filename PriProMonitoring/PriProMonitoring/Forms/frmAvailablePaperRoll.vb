Public Class frmAvailablePaperRoll

    Private Sub LvpaperRoll_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LvpaperRoll.DoubleClick
        frmUnallocatedPapercut.LVUnallocatedPapCut.SelectedItems(0).SubItems(1).Text = _
          LvpaperRoll.SelectedItems(0).SubItems(1).Text

        frmUnallocatedPapercut.LVUnallocatedPapCut.SelectedItems(0).SubItems(4).Text = _
            LvpaperRoll.SelectedItems(0).SubItems(3).Text
        frmUnallocatedPapercut.Enabled = True
        Me.Close()

    End Sub

    Private Sub frmAvailablePaperRoll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        frmUnallocatedPapercut.Enabled = False
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                frmUnallocatedPapercut.Enabled = True
                frmUnallocatedPapercut.Show()
                Me.Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class