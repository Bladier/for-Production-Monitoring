<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnallocatedPapercut
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
        Me.LVUnallocatedPapCut = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnCLose = New System.Windows.Forms.Button()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'LVUnallocatedPapCut
        '
        Me.LVUnallocatedPapCut.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader5, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LVUnallocatedPapCut.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LVUnallocatedPapCut.FullRowSelect = True
        Me.LVUnallocatedPapCut.GridLines = True
        Me.LVUnallocatedPapCut.Location = New System.Drawing.Point(12, 25)
        Me.LVUnallocatedPapCut.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LVUnallocatedPapCut.Name = "LVUnallocatedPapCut"
        Me.LVUnallocatedPapCut.Size = New System.Drawing.Size(588, 378)
        Me.LVUnallocatedPapCut.TabIndex = 0
        Me.LVUnallocatedPapCut.UseCompatibleStateImageBehavior = False
        Me.LVUnallocatedPapCut.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 37
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Paper Cut Code"
        Me.ColumnHeader2.Width = 143
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Description"
        Me.ColumnHeader3.Width = 123
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Paper Roll"
        Me.ColumnHeader4.Width = 401
        '
        'btnPost
        '
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPost.Location = New System.Drawing.Point(392, 411)
        Me.btnPost.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(127, 28)
        Me.btnPost.TabIndex = 1
        Me.btnPost.Text = "&Post Adjustment"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnCLose
        '
        Me.btnCLose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCLose.Location = New System.Drawing.Point(525, 411)
        Me.btnCLose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCLose.Name = "btnCLose"
        Me.btnCLose.Size = New System.Drawing.Size(74, 28)
        Me.btnCLose.TabIndex = 2
        Me.btnCLose.Text = "&Close"
        Me.btnCLose.UseVisualStyleBackColor = True
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "PapIDMain"
        Me.ColumnHeader5.Width = 0
        '
        'frmUnallocatedPapercut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(616, 446)
        Me.Controls.Add(Me.btnCLose)
        Me.Controls.Add(Me.btnPost)
        Me.Controls.Add(Me.LVUnallocatedPapCut)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmUnallocatedPapercut"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjust Unallocated Paper cut"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LVUnallocatedPapCut As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnCLose As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
End Class
