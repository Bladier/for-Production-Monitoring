<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoadMagazine
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
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.txtserial = New PriProMonitoring.watermark()
        Me.SuspendLayout()
        '
        'btnsearch
        '
        Me.btnsearch.Location = New System.Drawing.Point(311, 12)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 23)
        Me.btnsearch.TabIndex = 1
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'txtserial
        '
        Me.txtserial.Location = New System.Drawing.Point(8, 13)
        Me.txtserial.Name = "txtserial"
        Me.txtserial.Size = New System.Drawing.Size(297, 20)
        Me.txtserial.TabIndex = 2
        Me.txtserial.WatermarkColor = System.Drawing.Color.Gray
        Me.txtserial.WatermarkText = "Enter paper roll serial"
        '
        'frmLoadMagazine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(395, 122)
        Me.Controls.Add(Me.txtserial)
        Me.Controls.Add(Me.btnsearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmLoadMagazine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load Magazine"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents txtserial As PriProMonitoring.watermark
End Class
