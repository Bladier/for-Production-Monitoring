<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustment
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
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New PriProMonitoring.watermark()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lvpapercuts = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEmulsion = New PriProMonitoring.watermark()
        Me.txtAdvance = New PriProMonitoring.watermark()
        Me.txtLastout = New PriProMonitoring.watermark()
        Me.txtRemarks = New PriProMonitoring.watermark()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(226, 9)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(99, 27)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(55, 11)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(170, 21)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.WatermarkColor = System.Drawing.Color.DimGray
        Me.txtSearch.WatermarkText = "Search paper roll serial . . ."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 38)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lvpapercuts
        '
        Me.lvpapercuts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvpapercuts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader9, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader8})
        Me.lvpapercuts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvpapercuts.FullRowSelect = True
        Me.lvpapercuts.GridLines = True
        Me.lvpapercuts.HoverSelection = True
        Me.lvpapercuts.Location = New System.Drawing.Point(5, 17)
        Me.lvpapercuts.Name = "lvpapercuts"
        Me.lvpapercuts.Size = New System.Drawing.Size(317, 122)
        Me.lvpapercuts.TabIndex = 0
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
        Me.ColumnHeader4.Text = "ItemCode"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Description"
        Me.ColumnHeader5.Width = 211
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Enter Quantity"
        Me.ColumnHeader8.Width = 101
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lvpapercuts)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox2.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(326, 141)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Paper Cuts"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnClose)
        Me.GroupBox3.Controls.Add(Me.btnPost)
        Me.GroupBox3.Location = New System.Drawing.Point(340, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(210, 38)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(108, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(99, 27)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPost
        '
        Me.btnPost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPost.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(3, 9)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(99, 27)
        Me.btnPost.TabIndex = 0
        Me.btnPost.Text = "&Post"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Enter # of Emulsion"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtRemarks)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txtLastout)
        Me.GroupBox4.Controls.Add(Me.txtAdvance)
        Me.GroupBox4.Controls.Add(Me.txtEmulsion)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox4.Location = New System.Drawing.Point(14, 198)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(326, 168)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Other adjustment"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Enter # of Advance"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Lastout......................"
        '
        'txtEmulsion
        '
        Me.txtEmulsion.Location = New System.Drawing.Point(118, 11)
        Me.txtEmulsion.Name = "txtEmulsion"
        Me.txtEmulsion.Size = New System.Drawing.Size(203, 21)
        Me.txtEmulsion.TabIndex = 0
        Me.txtEmulsion.WatermarkColor = System.Drawing.Color.Gray
        Me.txtEmulsion.WatermarkText = "Emulsion"
        '
        'txtAdvance
        '
        Me.txtAdvance.Location = New System.Drawing.Point(118, 35)
        Me.txtAdvance.Name = "txtAdvance"
        Me.txtAdvance.Size = New System.Drawing.Size(203, 21)
        Me.txtAdvance.TabIndex = 1
        Me.txtAdvance.WatermarkColor = System.Drawing.Color.Gray
        Me.txtAdvance.WatermarkText = "Advance"
        '
        'txtLastout
        '
        Me.txtLastout.Location = New System.Drawing.Point(118, 60)
        Me.txtLastout.Name = "txtLastout"
        Me.txtLastout.Size = New System.Drawing.Size(203, 21)
        Me.txtLastout.TabIndex = 2
        Me.txtLastout.WatermarkColor = System.Drawing.Color.Gray
        Me.txtLastout.WatermarkText = "Lastout"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(117, 83)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(203, 79)
        Me.txtRemarks.TabIndex = 6
        Me.txtRemarks.WatermarkColor = System.Drawing.Color.Gray
        Me.txtRemarks.WatermarkText = "Remarks"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Remarks.................."
        '
        'frmAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(555, 370)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmAdjustment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjustment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As PriProMonitoring.watermark
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvpapercuts As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLastout As PriProMonitoring.watermark
    Friend WithEvents txtAdvance As PriProMonitoring.watermark
    Friend WithEvents txtEmulsion As PriProMonitoring.watermark
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As PriProMonitoring.watermark
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
