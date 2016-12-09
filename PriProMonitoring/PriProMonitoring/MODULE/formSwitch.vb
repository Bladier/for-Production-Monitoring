Module formSwitch
    
    Friend Enum FormName As Integer
        devForm = 0
        frmmagazine = 1

    End Enum

    Friend Sub ReloadFormFromSearch1(ByVal gotoForm As FormName, ByVal mg As Magazine)
        Select Case gotoForm
            Case FormName.frmmagazine
                ' frmMagazine.LoadCurrencyall(mg)
        End Select
    End Sub

  

End Module