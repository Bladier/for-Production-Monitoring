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
        Me.lvPaproll = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSet = New System.Windows.Forms.Button()
        Me.txtserial = New PriProMonitoring.watermark()
        Me.SuspendLayout()
        '
        'btnsearch
        '
        Me.btnsearch.Location = New System.Drawing.Point(338, 6)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 32)
        Me.btnsearch.TabIndex = 1
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'lvPaproll
        '
        Me.lvPaproll.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvPaproll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPaproll.FullRowSelect = True
        Me.lvPaproll.GridLines = True
        Me.lvPaproll.Location = New System.Drawing.Point(8, 39)
        Me.lvPaproll.Name = "lvPaproll"
        Me.lvPaproll.Size = New System.Drawing.Size(324, 90)
        Me.lvPaproll.TabIndex = 2
        Me.lvPaproll.UseCompatibleStateImageBehavior = False
        Me.lvPaproll.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Mag_ID"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Chamber"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Description"
        Me.ColumnHeader3.Width = 220
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Paper Roll"
        Me.ColumnHeader4.Width = 98
        '
        'btnSet
        '
        Me.btnSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSet.Location = New System.Drawing.Point(338, 100)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(75, 29)
        Me.btnSet.TabIndex = 3
        Me.btnSet.Text = "&Set"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'txtserial
        '
        Me.txtserial.Location = New System.Drawing.Point(8, 13)
        Me.txtserial.Name = "txtserial"
        Me.txtserial.Size = New System.Drawing.Size(324, 20)
        Me.txtserial.TabIndex = 0
        Me.txtserial.WatermarkColor = System.Drawing.Color.Gray
        Me.txtserial.WatermarkText = "Enter paper roll serial "
        '
        'frmLoadMagazine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(423, 135)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.lvPaproll)
        Me.Controls.Add(Me.txtserial)
        Me.Controls.Add(Me.btnsearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmLoadMagazine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load Paper Roll"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents txtserial As PriProMonitoring.watermark
    Friend WithEvents lvPaproll As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
End Class
