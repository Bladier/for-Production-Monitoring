Imports System.Data.Odbc
Public Class frmMonitoring
    Dim PAPROLLS As New PaperRoll
    Dim papRollmain As New PAPERROLLMAIN

    Private selectedmain As PAPERROLLMAIN
    Private ParCuts_ALL_ht As Hashtable

    Dim TotalPrints As Integer = 0
    Dim subTotal As Integer = 0

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lvListEmptyRoll.Items.Clear()

        Dim formNames As New List(Of String)
        For Each Form In My.Application.OpenForms
            If Form.Name <> "FrmMain" Or Not Form.name <> "frmEmptyPaperRollList" Then
                formNames.Add(Form.Name)
            End If
        Next
        For Each currentFormName As String In formNames
            Application.OpenForms(currentFormName).Close()
        Next

        frmEmptyPaperRollList.TopLevel = False
        FrmMain.Panel1.Controls.Add(frmEmptyPaperRollList)
        frmEmptyPaperRollList.Show()


        frmEmptyPaperRollList.Show()
    End Sub

    ''' <summary>
    ''' THis function populate the total prints of every paper roll and its paper cuts
    ''' </summary>
    ''' <param name="str"></param>
    ''' <remarks></remarks>
    Friend Sub PopulateCount(ByVal str As String)
        Dim mysql As String = "	SELECT P.PAPCODE,R.PAPROLL_SERIAL,PR.PAPCUT_DESC,PR.PAPCUT_CODE,	"
        mysql &= vbCrLf & "	PR.PAPERCUT,SUM(PR.QUANTITY)AS TOTAL FROM TBL_PROLINE PR	"
        mysql &= vbCrLf & "	INNER JOIN TBLPAPERROLL R ON R.PAPROLL_SERIAL = PR.PAPROLL_SERIAL	"
        mysql &= vbCrLf & "	INNER JOIN TBLPAPROLL_MAIN P ON P.PAPID=R.PAPIDS	"
        mysql &= vbCrLf & "	WHERE R.PAPROLL_SERIAL = '" & str & "' "
        mysql &= vbCrLf & "	GROUP BY P.PAPCODE,R.PAPROLL_SERIAL,PR.PAPCUT_DESC,PR.PAPCUT_CODE,PR.PAPERCUT	"

        Dim ds As DataSet = LoadSQL(mysql, "tblPAPROLL_MAIN")

        Dim TMPPAPDESC As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("PAPCUT_DESC")), "", ds.Tables(0).Rows(0).Item("PAPCUT_DESC"))

        If TMPPAPDESC = "" Then Exit Sub

        lvListEmptyRoll.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr

                Dim MYSQL1 As String = " SELECT  A.PAPROLL_SERIAL,AL.PAPCUT_CODE,SUM(AL.QUANTITY) AS QTY, " & _
                                       " AL.ADJUSTMENT_TYPE FROM TBLADJUSTMENT A INNER JOIN TBLADJUSTMENT_LINE AL " & _
                                       String.Format("ON A.ADJUSTMENTID = AL.ADJUSTMENT_ID WHERE A.PAPROLL_SERIAL = '{0}' " & _
                                       "AND PAPCUT_CODE = '{1}'", .Item("PAPROLL_SERIAL"), .Item("PAPCUT_CODE")) & _
                                       " GROUP BY A.PAPROLL_SERIAL,AL.PAPCUT_CODE,AL.QUANTITY,AL.ADJUSTMENT_TYPE " & _
                                       "ORDER BY AL.ADJUSTMENT_TYPE ASC"

                Dim dsad As DataSet = LoadSQL(MYSQL1, "TBLADJUSTMENT")

                If dsad.Tables(0).Rows.Count = 0 Then
                    Dim lv As ListViewItem = lvListEmptyRoll.Items.Add(.Item("PAPCODE"))
                    lv.SubItems.Add(.Item("PAPROLL_SERIAL"))
                    lv.SubItems.Add(.Item("PAPCUT_DESC"))
                    lv.SubItems.Add(.Item("PAPCUT_CODE"))
                    lv.SubItems.Add(.Item("PAPERCUT"))
                    lv.SubItems.Add(dr.Item("TOTAL"))

                Else
                    Dim max As Integer = dsad.Tables(0).Rows.Count

                    If max = 1 Then
                        For Each dr_Admnt As DataRow In dsad.Tables(0).Rows
                            With dr_Admnt
                                If dr_Admnt.Item("ADJUSTMENT_TYPE") = "Deduct" Then

                                    TotalPrints += dr_Admnt.Item("QTY")
                                    max -= 1
                                    If max = 0 Then
                                        TotalPrints = dr.Item("Total") - TotalPrints
                                    End If

                                Else

                                    TotalPrints += dr_Admnt.Item("QTY")
                                    max -= 1
                                    If max = 0 Then
                                        TotalPrints = dr.Item("Total") + TotalPrints
                                    End If

                                End If
                            End With
                        Next

                        Dim lv As ListViewItem = lvListEmptyRoll.Items.Add(.Item("PAPCODE"))
                        lv.SubItems.Add(.Item("PAPROLL_SERIAL"))
                        lv.SubItems.Add(.Item("PAPCUT_DESC"))
                        lv.SubItems.Add(.Item("PAPCUT_CODE"))
                        lv.SubItems.Add(.Item("PAPERCUT"))

                        If dsad.Tables(0).Rows.Count = 0 Then
                            lv.SubItems.Add(dr.Item("TOTAL"))
                        Else
                            lv.SubItems.Add(TotalPrints)
                            TotalPrints = 0
                        End If

                    Else
                        For Each dr_Admnt As DataRow In dsad.Tables(0).Rows
                            With dr_Admnt
                                If dr_Admnt.Item("ADJUSTMENT_TYPE") = "Deduct" Then

                                    TotalPrints = dr_Admnt.Item("QTY")

                                    TotalPrints = subTotal - TotalPrints
                                Else

                                    TotalPrints = dr_Admnt.Item("QTY")
                                    TotalPrints = dr.Item("Total") + TotalPrints

                                    subTotal = TotalPrints
                                    TotalPrints = 0

                                End If
                            End With
                        Next

                        Dim lv1 As ListViewItem = lvListEmptyRoll.Items.Add(.Item("PAPCODE"))
                        lv1.SubItems.Add(.Item("PAPROLL_SERIAL"))
                        lv1.SubItems.Add(.Item("PAPCUT_DESC"))
                        lv1.SubItems.Add(.Item("PAPCUT_CODE"))
                        lv1.SubItems.Add(.Item("PAPERCUT"))

                        If dsad.Tables(0).Rows.Count = 0 Then
                            lv1.SubItems.Add(dr.Item("TOTAL"))
                        Else
                            lv1.SubItems.Add(TotalPrints)
                            TotalPrints = 0
                        End If
                    End If

                End If

            End With
        Next

        getRemaining()
    End Sub


    ''' <summary>
    ''' calculate the remaining # of prints to be print
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getRemaining()


        Dim Totallength As Double = 0.0
        Dim dblTemp As Double = 0.0


        For Each itm As ListViewItem In lvListEmptyRoll.Items

            PAPROLLS.loadSerial(itm.SubItems(1).Text) 'Load Paper roll

            For Each lvItm As ListViewItem In lvListEmptyRoll.Items

                dblTemp += lvItm.SubItems(4).Text * lvItm.SubItems(5).Text
            Next

            Totallength = PAPROLLS.TotalLength * OneMeter
            Dim P_cut As Double = (Totallength - dblTemp) / itm.SubItems(4).Text


            itm.SubItems.Add(Math.Round(P_cut, 2))
            dblTemp = 0.0
        Next
    End Sub


    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
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