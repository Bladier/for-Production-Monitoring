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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSEarch = New PriProMonitoring.watermark()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Watermark1 = New PriProMonitoring.watermark()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lvItem = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSEarch)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(475, 49)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(381, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 27)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSEarch
        '
        Me.txtSEarch.Location = New System.Drawing.Point(72, 15)
        Me.txtSEarch.Name = "txtSEarch"
        Me.txtSEarch.Size = New System.Drawing.Size(303, 20)
        Me.txtSEarch.TabIndex = 0
        Me.txtSEarch.WatermarkColor = System.Drawing.Color.Gray
        Me.txtSEarch.WatermarkText = "Search . . ."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Location = New System.Drawing.Point(7, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Search"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lvItem)
        Me.GroupBox2.Controls.Add(Me.btnLoad)
        Me.GroupBox2.Controls.Add(Me.Watermark1)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(12, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(475, 279)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Magazine"
        '
        'Watermark1
        '
        Me.Watermark1.Location = New System.Drawing.Point(10, 17)
        Me.Watermark1.Name = "Watermark1"
        Me.Watermark1.Size = New System.Drawing.Size(459, 20)
        Me.Watermark1.TabIndex = 0
        Me.Watermark1.WatermarkColor = System.Drawing.Color.Gray
        Me.Watermark1.WatermarkText = "Search . . ."
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLoad.Location = New System.Drawing.Point(157, 246)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(182, 27)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Text = "Load Sales"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'lvItem
        '
        Me.lvItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader6, Me.ColumnHeader9})
        Me.lvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvItem.FullRowSelect = True
        Me.lvItem.GridLines = True
        Me.lvItem.Location = New System.Drawing.Point(11, 43)
        Me.lvItem.Name = "lvItem"
        Me.lvItem.Size = New System.Drawing.Size(456, 197)
        Me.lvItem.TabIndex = 6
        Me.lvItem.UseCompatibleStateImageBehavior = False
        Me.lvItem.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ItemCode"
        Me.ColumnHeader6.Width = 173
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Description"
        Me.ColumnHeader9.Width = 278
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Paper Cut"
        Me.ColumnHeader2.Width = 0
        '
        'frmProductionMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(494, 358)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmProductionMonitoring"
        Me.Text = "Production Monitoring"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSEarch As PriProMonitoring.watermark
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents Watermark1 As PriProMonitoring.watermark
    Friend WithEvents lvItem As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class
