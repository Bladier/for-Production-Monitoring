Module formSwitch
    
    Friend Enum FormName As Integer
        devForm = 0
        frmMagazine = 1
    End Enum

 
    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal mag As Magazine)
        Select Case gotoForm
            Case FormName.frmMagazine
                frmMagazine.LoadMagazine(mag)
        End Select
    End Sub
End Module