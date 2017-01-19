Public Class frmSetupDatabase
    Dim frmmain As New FrmMain
    Private locked As Boolean = IIf(GetOption("Locked") = "YES", True, False)

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        OFD.ShowDialog()
    End Sub

    Private Sub OFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OFD.FileOk
        txtpath.Text = OFD.FileName
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim str As String
        str = txtpath.Text
        If str.Contains(".FDB") = True Then
            If Not locked Then
                UpdateSetting()
            End If
        Else
            MsgBox("The file type is not valid" & vbCrLf & "Please try again!", MsgBoxStyle.Critical)
            Exit Sub
        End If

    End Sub


    Friend Sub UpdateSetting()
        'First
        If Not locked Then
            UpdateOptions("DatabasePOS", txtpath.Text)
            UpdateOptions("Locked", "YES")
        End If

        If Not locked Then
            MsgBox("Database has been setup", MsgBoxStyle.Information)
        Else
            MsgBox("Setup updated", MsgBoxStyle.Information)
        End If
        frmmain.NotYetLogin(False)
        Me.Close()
    End Sub


    Private Sub frmLoadIMD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Import IMD | Active Form"
    End Sub

   
End Class