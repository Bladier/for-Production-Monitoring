Public Class frmAvailablePaperRoll

    Private Sub LvpaperRoll_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LvpaperRoll.DoubleClick
        frmUnallocatedPapercut.LVUnallocatedPapCut.SelectedItems(0).SubItems(1).Text = _
          LvpaperRoll.SelectedItems(0).SubItems(1).Text

        frmUnallocatedPapercut.LVUnallocatedPapCut.SelectedItems(0).SubItems(4).Text = _
            LvpaperRoll.SelectedItems(0).SubItems(3).Text
        Me.Close()
    End Sub

    Private Sub frmAvailablePaperRoll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class