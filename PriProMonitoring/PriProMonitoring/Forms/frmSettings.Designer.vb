<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtVersion = New System.Windows.Forms.TextBox()
        Me.txtAreaname = New System.Windows.Forms.TextBox()
        Me.txtAreacode = New System.Windows.Forms.TextBox()
        Me.txtBranchname = New System.Windows.Forms.TextBox()
        Me.txtBranchCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtpath = New System.Windows.Forms.TextBox()
        Me.btnbrowse = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnBrowseMagazine = New System.Windows.Forms.Button()
        Me.txtMagazine = New System.Windows.Forms.TextBox()
        Me.ofdIMD = New System.Windows.Forms.OpenFileDialog()
        Me.OFDPapercut = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnBrowsepapecut = New System.Windows.Forms.Button()
        Me.txtPapercut = New System.Windows.Forms.TextBox()
        Me.OFDMagazine = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtChamber = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtVersion)
        Me.GroupBox1.Controls.Add(Me.txtAreaname)
        Me.GroupBox1.Controls.Add(Me.txtAreacode)
        Me.GroupBox1.Controls.Add(Me.txtBranchname)
        Me.GroupBox1.Controls.Add(Me.txtBranchCode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(367, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 162)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Branch"
        '
        'txtVersion
        '
        Me.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVersion.Location = New System.Drawing.Point(90, 134)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.ReadOnly = True
        Me.txtVersion.Size = New System.Drawing.Size(208, 21)
        Me.txtVersion.TabIndex = 4
        '
        'txtAreaname
        '
        Me.txtAreaname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAreaname.Location = New System.Drawing.Point(90, 104)
        Me.txtAreaname.Name = "txtAreaname"
        Me.txtAreaname.ReadOnly = True
        Me.txtAreaname.Size = New System.Drawing.Size(208, 21)
        Me.txtAreaname.TabIndex = 3
        '
        'txtAreacode
        '
        Me.txtAreacode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAreacode.Location = New System.Drawing.Point(90, 75)
        Me.txtAreacode.Name = "txtAreacode"
        Me.txtAreacode.ReadOnly = True
        Me.txtAreacode.Size = New System.Drawing.Size(208, 21)
        Me.txtAreacode.TabIndex = 2
        '
        'txtBranchname
        '
        Me.txtBranchname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchname.Location = New System.Drawing.Point(90, 45)
        Me.txtBranchname.Name = "txtBranchname"
        Me.txtBranchname.ReadOnly = True
        Me.txtBranchname.Size = New System.Drawing.Size(208, 21)
        Me.txtBranchname.TabIndex = 1
        '
        'txtBranchCode
        '
        Me.txtBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchCode.Location = New System.Drawing.Point(90, 13)
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.ReadOnly = True
        Me.txtBranchCode.Size = New System.Drawing.Size(208, 21)
        Me.txtBranchCode.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(8, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Version"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(8, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Area Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(8, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Area Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Branch Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Branch Code"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Control
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(504, 203)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 28)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(586, 203)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(79, 28)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtpath
        '
        Me.txtpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpath.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpath.Location = New System.Drawing.Point(12, 18)
        Me.txtpath.Name = "txtpath"
        Me.txtpath.ReadOnly = True
        Me.txtpath.Size = New System.Drawing.Size(287, 21)
        Me.txtpath.TabIndex = 0
        '
        'btnbrowse
        '
        Me.btnbrowse.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbrowse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnbrowse.Location = New System.Drawing.Point(305, 12)
        Me.btnbrowse.Name = "btnbrowse"
        Me.btnbrowse.Size = New System.Drawing.Size(38, 32)
        Me.btnbrowse.TabIndex = 1
        Me.btnbrowse.Text = ". . ."
        Me.btnbrowse.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnbrowse)
        Me.GroupBox2.Controls.Add(Me.txtpath)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(349, 50)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Database path"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnBrowseMagazine)
        Me.GroupBox3.Controls.Add(Me.txtMagazine)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox3.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(349, 50)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Magazine"
        '
        'btnBrowseMagazine
        '
        Me.btnBrowseMagazine.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseMagazine.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnBrowseMagazine.Location = New System.Drawing.Point(305, 12)
        Me.btnBrowseMagazine.Name = "btnBrowseMagazine"
        Me.btnBrowseMagazine.Size = New System.Drawing.Size(38, 32)
        Me.btnBrowseMagazine.TabIndex = 1
        Me.btnBrowseMagazine.Text = ". . ."
        Me.btnBrowseMagazine.UseVisualStyleBackColor = True
        '
        'txtMagazine
        '
        Me.txtMagazine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMagazine.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMagazine.Location = New System.Drawing.Point(12, 18)
        Me.txtMagazine.Name = "txtMagazine"
        Me.txtMagazine.ReadOnly = True
        Me.txtMagazine.Size = New System.Drawing.Size(287, 21)
        Me.txtMagazine.TabIndex = 0
        '
        'OFDPapercut
        '
        Me.OFDPapercut.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnBrowsepapecut)
        Me.GroupBox4.Controls.Add(Me.txtPapercut)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox4.Location = New System.Drawing.Point(12, 124)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(349, 50)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Papercut Path"
        '
        'btnBrowsepapecut
        '
        Me.btnBrowsepapecut.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowsepapecut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnBrowsepapecut.Location = New System.Drawing.Point(305, 12)
        Me.btnBrowsepapecut.Name = "btnBrowsepapecut"
        Me.btnBrowsepapecut.Size = New System.Drawing.Size(38, 32)
        Me.btnBrowsepapecut.TabIndex = 1
        Me.btnBrowsepapecut.Text = ". . ."
        Me.btnBrowsepapecut.UseVisualStyleBackColor = True
        '
        'txtPapercut
        '
        Me.txtPapercut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPapercut.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPapercut.Location = New System.Drawing.Point(12, 18)
        Me.txtPapercut.Name = "txtPapercut"
        Me.txtPapercut.ReadOnly = True
        Me.txtPapercut.Size = New System.Drawing.Size(287, 21)
        Me.txtPapercut.TabIndex = 0
        '
        'OFDMagazine
        '
        Me.OFDMagazine.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txtChamber)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox5.Location = New System.Drawing.Point(12, 180)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(349, 50)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Chamber"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(11, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Number of Chamber"
        '
        'txtChamber
        '
        Me.txtChamber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChamber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChamber.Location = New System.Drawing.Point(140, 19)
        Me.txtChamber.Name = "txtChamber"
        Me.txtChamber.Size = New System.Drawing.Size(203, 21)
        Me.txtChamber.TabIndex = 1
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(683, 243)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtpath As System.Windows.Forms.TextBox
    Friend WithEvents btnbrowse As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowseMagazine As System.Windows.Forms.Button
    Friend WithEvents txtMagazine As System.Windows.Forms.TextBox
    Friend WithEvents ofdIMD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OFDPapercut As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowsepapecut As System.Windows.Forms.Button
    Friend WithEvents txtPapercut As System.Windows.Forms.TextBox
    Friend WithEvents OFDMagazine As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtAreaname As System.Windows.Forms.TextBox
    Friend WithEvents txtAreacode As System.Windows.Forms.TextBox
    Friend WithEvents txtBranchname As System.Windows.Forms.TextBox
    Friend WithEvents txtBranchCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtChamber As System.Windows.Forms.TextBox
End Class
