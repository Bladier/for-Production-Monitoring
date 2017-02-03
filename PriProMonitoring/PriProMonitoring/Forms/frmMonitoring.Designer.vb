<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitoring
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
        Me.lvListEmptyRoll = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(605, 16)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(108, 37)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lvListEmptyRoll
        '
        Me.lvListEmptyRoll.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid
        Me.lvListEmptyRoll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvListEmptyRoll.BackColor = System.Drawing.SystemColors.Window
        Me.lvListEmptyRoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvListEmptyRoll.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvListEmptyRoll.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvListEmptyRoll.FullRowSelect = True
        Me.lvListEmptyRoll.GridLines = True
        Me.lvListEmptyRoll.Location = New System.Drawing.Point(27, 62)
        Me.lvListEmptyRoll.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lvListEmptyRoll.Name = "lvListEmptyRoll"
        Me.lvListEmptyRoll.ShowItemToolTips = True
        Me.lvListEmptyRoll.Size = New System.Drawing.Size(687, 338)
        Me.lvListEmptyRoll.TabIndex = 1
        Me.lvListEmptyRoll.UseCompatibleStateImageBehavior = False
        Me.lvListEmptyRoll.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Paper Roll ItemCode"
        Me.ColumnHeader1.Width = 159
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Paper Roll Serial"
        Me.ColumnHeader2.Width = 157
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Paper Cut Description"
        Me.ColumnHeader5.Width = 160
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "# of Prints"
        Me.ColumnHeader3.Width = 78
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Remaining Prints"
        Me.ColumnHeader4.Width = 253
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Location = New System.Drawing.Point(107, 23)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(490, 22)
        Me.txtSearch.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(42, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Search"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(735, 418)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.lvListEmptyRoll)
        Me.Controls.Add(Me.btnSearch)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMonitoring"
        Me.Text = "Monitoring"
        Me.TransparencyKey = System.Drawing.SystemColors.ActiveCaption
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lvListEmptyRoll As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
End Class
