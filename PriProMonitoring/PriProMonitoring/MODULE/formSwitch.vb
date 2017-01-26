Module formSwitch
    
    Friend Enum FormName As Integer
        devForm = 0
        frmmagazine = 1
        frmitem = 2
    End Enum

    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal mg As PAPERROLLMAIN)
        Select Case gotoForm
            Case FormName.frmmagazine
                frmMagazine.LoadMagazine(mg)
        End Select
    End Sub

    Friend Sub ReloadFormFromItemList(ByVal gotoForm As FormName, ByVal selectedItm As item)
        Select Case gotoForm
            Case FormName.frmitem
                frmItem.Loaditm(selectedItm)
        End Select
    End Sub

End Module