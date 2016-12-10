<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaperRoll
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CboMagazine = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSerial = New PriProMonitoring.watermark()
        Me.txtOuterDiameter = New PriProMonitoring.watermark()
        Me.txtSpoolDiameter = New PriProMonitoring.watermark()
        Me.txtPaperThickness = New PriProMonitoring.watermark()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CboMagazine
        '
        Me.CboMagazine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMagazine.FormattingEnabled = True
        Me.CboMagazine.Location = New System.Drawing.Point(117, 18)
        Me.CboMagazine.Name = "CboMagazine"
        Me.CboMagazine.Size = New System.Drawing.Size(173, 23)
        Me.CboMagazine.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Serial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(12, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Outer Diameter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(12, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Spool Diameter"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(12, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Paper Thickness"
        '
        'txtSerial
        '
        Me.txtSerial.Location = New System.Drawing.Point(117, 48)
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Size = New System.Drawing.Size(173, 21)
        Me.txtSerial.TabIndex = 1
        Me.txtSerial.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSerial.WatermarkText = "Serial"
        '
        'txtOuterDiameter
        '
        Me.txtOuterDiameter.Location = New System.Drawing.Point(117, 76)
        Me.txtOuterDiameter.Name = "txtOuterDiameter"
        Me.txtOuterDiameter.Size = New System.Drawing.Size(173, 21)
        Me.txtOuterDiameter.TabIndex = 2
        Me.txtOuterDiameter.WatermarkColor = System.Drawing.Color.Gray
        Me.txtOuterDiameter.WatermarkText = "OUter Diameter"
        '
        'txtSpoolDiameter
        '
        Me.txtSpoolDiameter.Location = New System.Drawing.Point(117, 104)
        Me.txtSpoolDiameter.Name = "txtSpoolDiameter"
        Me.txtSpoolDiameter.Size = New System.Drawing.Size(173, 21)
        Me.txtSpoolDiameter.TabIndex = 3
        Me.txtSpoolDiameter.Text = "8.5"
        Me.txtSpoolDiameter.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSpoolDiameter.WatermarkText = "Spool Diameter"
        '
        'txtPaperThickness
        '
        Me.txtPaperThickness.Location = New System.Drawing.Point(117, 133)
        Me.txtPaperThickness.Name = "txtPaperThickness"
        Me.txtPaperThickness.Size = New System.Drawing.Size(173, 21)
        Me.txtPaperThickness.TabIndex = 4
        Me.txtPaperThickness.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPaperThickness.WatermarkText = "Paper Thickness"
        '
        'btnsave
        '
        Me.btnsave.Location = New System.Drawing.Point(164, 169)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 24)
        Me.btnsave.TabIndex = 5
        Me.btnsave.Text = "&Save"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(245, 169)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 24)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(12, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Magazine"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(293, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 18)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "cm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(293, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 18)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "cm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(292, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 18)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "mm"
        '
        'frmPaperRoll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(332, 203)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.txtPaperThickness)
        Me.Controls.Add(Me.txtSpoolDiameter)
        Me.Controls.Add(Me.txtOuterDiameter)
        Me.Controls.Add(Me.txtSerial)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CboMagazine)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPaperRoll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paper Roll"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboMagazine As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerial As PriProMonitoring.watermark
    Friend WithEvents txtOuterDiameter As PriProMonitoring.watermark
    Friend WithEvents txtSpoolDiameter As PriProMonitoring.watermark
    Friend WithEvents txtPaperThickness As PriProMonitoring.watermark
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
