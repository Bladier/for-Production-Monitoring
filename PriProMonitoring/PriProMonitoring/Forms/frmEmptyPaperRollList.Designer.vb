<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmptyPaperRollList
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
        Me.Lvlist = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Lvlist
        '
        Me.Lvlist.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid
        Me.Lvlist.BackColor = System.Drawing.SystemColors.Window
        Me.Lvlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lvlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.Lvlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lvlist.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lvlist.FullRowSelect = True
        Me.Lvlist.GridLines = True
        Me.Lvlist.Location = New System.Drawing.Point(0, 0)
        Me.Lvlist.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Lvlist.Name = "Lvlist"
        Me.Lvlist.ShowItemToolTips = True
        Me.Lvlist.Size = New System.Drawing.Size(723, 386)
        Me.Lvlist.TabIndex = 2
        Me.Lvlist.UseCompatibleStateImageBehavior = False
        Me.Lvlist.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Paper Roll Code"
        Me.ColumnHeader5.Width = 259
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Description"
        Me.ColumnHeader6.Width = 237
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Serial"
        Me.ColumnHeader7.Width = 223
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 34
        '
        'frmEmptyPaperRollList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(723, 386)
        Me.Controls.Add(Me.Lvlist)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmEmptyPaperRollList"
        Me.Text = "List of Declared Empty Paper Roll"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Lvlist As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
End Class
