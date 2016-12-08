<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InitializationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadMagazineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadIMDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MagazineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddMagazineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewPaperRollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.InitializationToolStripMenuItem, Me.MagazineToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(905, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoginToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LoginToolStripMenuItem.Text = "&Login"
        '
        'InitializationToolStripMenuItem
        '
        Me.InitializationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadMagazineToolStripMenuItem, Me.LoadIMDToolStripMenuItem})
        Me.InitializationToolStripMenuItem.Name = "InitializationToolStripMenuItem"
        Me.InitializationToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.InitializationToolStripMenuItem.Text = "Initialization"
        '
        'LoadMagazineToolStripMenuItem
        '
        Me.LoadMagazineToolStripMenuItem.Name = "LoadMagazineToolStripMenuItem"
        Me.LoadMagazineToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.LoadMagazineToolStripMenuItem.Text = "&Load Magazine"
        '
        'LoadIMDToolStripMenuItem
        '
        Me.LoadIMDToolStripMenuItem.Name = "LoadIMDToolStripMenuItem"
        Me.LoadIMDToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.LoadIMDToolStripMenuItem.Text = "Lo&ad IMD"
        '
        'MagazineToolStripMenuItem
        '
        Me.MagazineToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMagazineToolStripMenuItem, Me.AddNewPaperRollToolStripMenuItem})
        Me.MagazineToolStripMenuItem.Name = "MagazineToolStripMenuItem"
        Me.MagazineToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.MagazineToolStripMenuItem.Text = "Magazine"
        '
        'AddMagazineToolStripMenuItem
        '
        Me.AddMagazineToolStripMenuItem.Name = "AddMagazineToolStripMenuItem"
        Me.AddMagazineToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AddMagazineToolStripMenuItem.Text = "Ad&d Magazine"
        '
        'AddNewPaperRollToolStripMenuItem
        '
        Me.AddNewPaperRollToolStripMenuItem.Name = "AddNewPaperRollToolStripMenuItem"
        Me.AddNewPaperRollToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AddNewPaperRollToolStripMenuItem.Text = "Add &New Paper Roll"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(905, 571)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InitializationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadMagazineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadIMDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MagazineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddMagazineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewPaperRollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
