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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lvpapercuts = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tpProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolRemaining = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnProduction = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(475, 49)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'btnSearch
        '
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSearch.Location = New System.Drawing.Point(381, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 27)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox2.Location = New System.Drawing.Point(12, 67)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(475, 331)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Magazine"
        '
        'lvpapercuts
        '
        Me.lvpapercuts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader9, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvpapercuts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvpapercuts.FullRowSelect = True
        Me.lvpapercuts.GridLines = True
        Me.lvpapercuts.HoverSelection = True
        Me.lvpapercuts.Location = New System.Drawing.Point(9, 43)
        Me.lvpapercuts.Name = "lvpapercuts"
        Me.lvpapercuts.Size = New System.Drawing.Size(456, 282)
        Me.lvpapercuts.TabIndex = 6
        Me.lvpapercuts.UseCompatibleStateImageBehavior = False
        Me.lvpapercuts.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "MAGID"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ROLLSERIAL"
        Me.ColumnHeader3.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ROLLSTATUS"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Total_length"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "PAPERCUT"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Paper Cut Code"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Description"
        Me.ColumnHeader5.Width = 291
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tpProgressBar, Me.ToolRemaining})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 401)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.Size = New System.Drawing.Size(720, 26)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tpProgressBar
        '
        Me.tpProgressBar.Maximum = 5
        Me.tpProgressBar.Name = "tpProgressBar"
        Me.tpProgressBar.Size = New System.Drawing.Size(100, 20)
        '
        'ToolRemaining
        '
        Me.ToolRemaining.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolRemaining.Name = "ToolRemaining"
        Me.ToolRemaining.Size = New System.Drawing.Size(64, 21)
        Me.ToolRemaining.Text = "Remaining"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(431, 409)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Label1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnProduction)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox3.Location = New System.Drawing.Point(493, 173)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 46)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'btnProduction
        '
        Me.btnProduction.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnProduction.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProduction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnProduction.Location = New System.Drawing.Point(9, 12)
        Me.btnProduction.Name = "btnProduction"
        Me.btnProduction.Size = New System.Drawing.Size(182, 27)
        Me.btnProduction.TabIndex = 8
        Me.btnProduction.Text = "Production"
        Me.btnProduction.UseVisualStyleBackColor = True
        '
        'frmProductionMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(720, 427)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Location = New System.Drawing.Point(600, 150)
        Me.Name = "frmProductionMonitoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Production Monitoring"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSEarch As PriProMonitoring.watermark
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmagazine As PriProMonitoring.watermark
    Friend WithEvents lvpapercuts As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolRemaining As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProduction As System.Windows.Forms.Button
    Friend WithEvents txtMagazine2 As PriProMonitoring.watermark
End Class
