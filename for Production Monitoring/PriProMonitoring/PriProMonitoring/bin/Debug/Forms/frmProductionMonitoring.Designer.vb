<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductionMonitoring
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
        Me.cboMagazine = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboMagazine
        '
        Me.cboMagazine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMagazine.FormattingEnabled = True
        Me.cboMagazine.Location = New System.Drawing.Point(22, 116)
        Me.cboMagazine.Name = "cboMagazine"
        Me.cboMagazine.Size = New System.Drawing.Size(286, 23)
        Me.cboMagazine.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(22, 67)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(286, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Load Sales"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmProductionMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(927, 601)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboMagazine)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmProductionMonitoring"
        Me.Text = "Production Monitoring"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboMagazine As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
