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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtPapercut = New PriProMonitoring.watermark()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtQuantity = New PriProMonitoring.watermark()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRemarks = New PriProMonitoring.watermark()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIncheslastout = New PriProMonitoring.watermark()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Watermark1 = New PriProMonitoring.watermark()
        Me.cboMagazine = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Watermark2 = New PriProMonitoring.watermark()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Watermark3 = New PriProMonitoring.watermark()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Watermark4 = New PriProMonitoring.watermark()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Watermark5 = New PriProMonitoring.watermark()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox1.Controls.Add(Me.Watermark5)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtRemarks)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtQuantity)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPapercut)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(668, 320)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(8, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Paper Cut" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(345, 87)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(61, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtPapercut
        '
        Me.txtPapercut.Location = New System.Drawing.Point(76, 89)
        Me.txtPapercut.Name = "txtPapercut"
        Me.txtPapercut.Size = New System.Drawing.Size(263, 21)
        Me.txtPapercut.TabIndex = 4
        Me.txtPapercut.WatermarkColor = System.Drawing.Color.Gray
        Me.txtPapercut.WatermarkText = "Paper Cut Description"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(479, 402)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(113, 28)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "&Save Adjustment"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(76, 126)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(76, 21)
        Me.txtQuantity.TabIndex = 8
        Me.txtQuantity.WatermarkColor = System.Drawing.Color.Gray
        Me.txtQuantity.WatermarkText = "Quantity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(19, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Quantity"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(76, 164)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(263, 76)
        Me.txtRemarks.TabIndex = 10
        Me.txtRemarks.WatermarkColor = System.Drawing.Color.Gray
        Me.txtRemarks.WatermarkText = "Remarks"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(20, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Remarks"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(598, 401)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 28)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(672, 354)
        Me.TabControl1.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(664, 326)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Subtract Adjustment"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox2.Location = New System.Drawing.Point(-2, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(668, 320)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(8, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 7
        '
        'txtIncheslastout
        '
        Me.txtIncheslastout.Location = New System.Drawing.Point(102, 71)
        Me.txtIncheslastout.Name = "txtIncheslastout"
        Me.txtIncheslastout.Size = New System.Drawing.Size(76, 20)
        Me.txtIncheslastout.TabIndex = 8
        Me.txtIncheslastout.WatermarkColor = System.Drawing.Color.Gray
        Me.txtIncheslastout.WatermarkText = "By Inches"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(8, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 9
        '
        'Watermark1
        '
        Me.Watermark1.Location = New System.Drawing.Point(64, 109)
        Me.Watermark1.Multiline = True
        Me.Watermark1.Name = "Watermark1"
        Me.Watermark1.Size = New System.Drawing.Size(263, 76)
        Me.Watermark1.TabIndex = 10
        Me.Watermark1.WatermarkColor = System.Drawing.Color.Gray
        Me.Watermark1.WatermarkText = "Remarks"
        '
        'cboMagazine
        '
        Me.cboMagazine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMagazine.FormattingEnabled = True
        Me.cboMagazine.Location = New System.Drawing.Point(76, 26)
        Me.cboMagazine.Name = "cboMagazine"
        Me.cboMagazine.Size = New System.Drawing.Size(251, 21)
        Me.cboMagazine.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(8, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 15)
        Me.Label6.TabIndex = 12
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(664, 326)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "LastOut Adjustment"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(664, 326)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Add Adjustment"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox3.Controls.Add(Me.Watermark2)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Watermark3)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Watermark4)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(-2, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(668, 320)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'Watermark2
        '
        Me.Watermark2.Location = New System.Drawing.Point(76, 164)
        Me.Watermark2.Multiline = True
        Me.Watermark2.Name = "Watermark2"
        Me.Watermark2.Size = New System.Drawing.Size(263, 76)
        Me.Watermark2.TabIndex = 10
        Me.Watermark2.WatermarkColor = System.Drawing.Color.Gray
        Me.Watermark2.WatermarkText = "Remarks"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(20, 164)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Remarks"
        '
        'Watermark3
        '
        Me.Watermark3.Location = New System.Drawing.Point(76, 126)
        Me.Watermark3.Name = "Watermark3"
        Me.Watermark3.Size = New System.Drawing.Size(76, 21)
        Me.Watermark3.TabIndex = 8
        Me.Watermark3.WatermarkColor = System.Drawing.Color.Gray
        Me.Watermark3.WatermarkText = "Quantity"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label8.Location = New System.Drawing.Point(20, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Quantity"
        '
        'Watermark4
        '
        Me.Watermark4.Location = New System.Drawing.Point(76, 89)
        Me.Watermark4.Name = "Watermark4"
        Me.Watermark4.Size = New System.Drawing.Size(263, 21)
        Me.Watermark4.TabIndex = 4
        Me.Watermark4.WatermarkColor = System.Drawing.Color.Gray
        Me.Watermark4.WatermarkText = "Paper Cut"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(345, 87)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label9.Location = New System.Drawing.Point(9, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Paper Cut"
        '
        'Watermark5
        '
        Me.Watermark5.Location = New System.Drawing.Point(76, 50)
        Me.Watermark5.Name = "Watermark5"
        Me.Watermark5.Size = New System.Drawing.Size(263, 21)
        Me.Watermark5.TabIndex = 12
        Me.Watermark5.WatermarkColor = System.Drawing.Color.Gray
        Me.Watermark5.WatermarkText = "Paper Cut Description"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label10.Location = New System.Drawing.Point(8, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 30)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Paper Cut" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
        '
        'frmAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(696, 442)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmAdjustment"
        Me.Text = "Adjustment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As PriProMonitoring.watermark
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As PriProMonitoring.watermark
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPapercut As PriProMonitoring.watermark
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Watermark5 As PriProMonitoring.watermark
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Watermark2 As PriProMonitoring.watermark
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Watermark3 As PriProMonitoring.watermark
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Watermark4 As PriProMonitoring.watermark
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtIncheslastout As PriProMonitoring.watermark
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Watermark1 As PriProMonitoring.watermark
    Friend WithEvents cboMagazine As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
