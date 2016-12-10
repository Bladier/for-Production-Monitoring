<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuInitialization = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadMagazineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadIMDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MagazineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddMagazineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddPaperRollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusDateandTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TmpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ProductionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.menuInitialization, Me.MagazineToolStripMenuItem, Me.ProductionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1003, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuLogin})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'menuLogin
        '
        Me.menuLogin.Name = "menuLogin"
        Me.menuLogin.Size = New System.Drawing.Size(104, 22)
        Me.menuLogin.Text = "&Login"
        '
        'menuInitialization
        '
        Me.menuInitialization.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadMagazineToolStripMenuItem, Me.LoadIMDToolStripMenuItem})
        Me.menuInitialization.Name = "menuInitialization"
        Me.menuInitialization.Size = New System.Drawing.Size(83, 20)
        Me.menuInitialization.Text = "Initialization"
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
        Me.LoadIMDToolStripMenuItem.Text = "Load &IMD"
        '
        'MagazineToolStripMenuItem
        '
        Me.MagazineToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMagazineToolStripMenuItem, Me.AddPaperRollToolStripMenuItem})
        Me.MagazineToolStripMenuItem.Name = "MagazineToolStripMenuItem"
        Me.MagazineToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.MagazineToolStripMenuItem.Text = "Magazine"
        '
        'AddMagazineToolStripMenuItem
        '
        Me.AddMagazineToolStripMenuItem.Name = "AddMagazineToolStripMenuItem"
        Me.AddMagazineToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddMagazineToolStripMenuItem.Text = "A&dd Magazine"
        '
        'AddPaperRollToolStripMenuItem
        '
        Me.AddPaperRollToolStripMenuItem.Name = "AddPaperRollToolStripMenuItem"
        Me.AddPaperRollToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddPaperRollToolStripMenuItem.Text = "Add &Paper Roll"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusDateandTime, Me.statusUser})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 554)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1003, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusDateandTime
        '
        Me.statusDateandTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.statusDateandTime.Name = "statusDateandTime"
        Me.statusDateandTime.Size = New System.Drawing.Size(73, 17)
        Me.statusDateandTime.Text = "Date Not Set"
        '
        'statusUser
        '
        Me.statusUser.BackColor = System.Drawing.Color.OrangeRed
        Me.statusUser.Name = "statusUser"
        Me.statusUser.Size = New System.Drawing.Size(30, 17)
        Me.statusUser.Text = "User"
        '
        'TmpTimer
        '
        Me.TmpTimer.Enabled = True
        '
        'ProductionToolStripMenuItem
        '
        Me.ProductionToolStripMenuItem.Name = "ProductionToolStripMenuItem"
        Me.ProductionToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.ProductionToolStripMenuItem.Text = "Production"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1003, 576)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.Text = "FrmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusDateandTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents menuInitialization As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadMagazineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadIMDToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TmpTimer As System.Windows.Forms.Timer
    Friend WithEvents MagazineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddMagazineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddPaperRollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
