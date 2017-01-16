<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckSales
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
        Me.btnCheckSales = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCheckSales
        '
        Me.btnCheckSales.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCheckSales.Location = New System.Drawing.Point(0, 2)
        Me.btnCheckSales.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCheckSales.Name = "btnCheckSales"
        Me.btnCheckSales.Size = New System.Drawing.Size(141, 42)
        Me.btnCheckSales.TabIndex = 0
        Me.btnCheckSales.Text = "Check Sales"
        Me.btnCheckSales.UseVisualStyleBackColor = True
        '
        'frmCheckSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(143, 81)
        Me.Controls.Add(Me.btnCheckSales)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(1000, 100)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmCheckSales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmCheckSales"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCheckSales As System.Windows.Forms.Button
End Class
