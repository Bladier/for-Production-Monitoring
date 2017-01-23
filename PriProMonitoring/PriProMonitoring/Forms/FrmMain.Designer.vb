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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdjustmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaperEmptyDeclarationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuInitialization = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadMagazineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MagazineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddPaperRollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusDateandTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblToolStripStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripPBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Count = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TmpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SalesWatcher = New System.Windows.Forms.Timer(Me.components)
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.StatusCounter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Counter = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.menuInitialization, Me.MagazineToolStripMenuItem, Me.TransactionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1003, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuLogin, Me.AdjustmentToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.PaperEmptyDeclarationToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'menuLogin
        '
        Me.menuLogin.Name = "menuLogin"
        Me.menuLogin.Size = New System.Drawing.Size(204, 22)
        Me.menuLogin.Text = "&Login"
        '
        'AdjustmentToolStripMenuItem
        '
        Me.AdjustmentToolStripMenuItem.Name = "AdjustmentToolStripMenuItem"
        Me.AdjustmentToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.AdjustmentToolStripMenuItem.Text = "&Adjustment"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'PaperEmptyDeclarationToolStripMenuItem
        '
        Me.PaperEmptyDeclarationToolStripMenuItem.Name = "PaperEmptyDeclarationToolStripMenuItem"
        Me.PaperEmptyDeclarationToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PaperEmptyDeclarationToolStripMenuItem.Text = "Paper empty &Declaration"
        '
        'menuInitialization
        '
        Me.menuInitialization.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadMagazineToolStripMenuItem})
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
        'MagazineToolStripMenuItem
        '
        Me.MagazineToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddPaperRollToolStripMenuItem, Me.AddItemToolStripMenuItem})
        Me.MagazineToolStripMenuItem.Name = "MagazineToolStripMenuItem"
        Me.MagazineToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.MagazineToolStripMenuItem.Text = "Magazine"
        '
        'AddPaperRollToolStripMenuItem
        '
        Me.AddPaperRollToolStripMenuItem.Name = "AddPaperRollToolStripMenuItem"
        Me.AddPaperRollToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddPaperRollToolStripMenuItem.Text = "Add &Paper Roll"
        '
        'AddItemToolStripMenuItem
        '
        Me.AddItemToolStripMenuItem.Name = "AddItemToolStripMenuItem"
        Me.AddItemToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddItemToolStripMenuItem.Text = "Add &Item"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.TransactionToolStripMenuItem.Text = "Transaction"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusDateandTime, Me.statusUser, Me.lblToolStripStatus, Me.ToolStripPBar, Me.StatusCounter, Me.Count})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 551)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1003, 25)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusDateandTime
        '
        Me.statusDateandTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.statusDateandTime.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.statusDateandTime.Name = "statusDateandTime"
        Me.statusDateandTime.Size = New System.Drawing.Size(73, 23)
        Me.statusDateandTime.Text = "Date Not Set"
        '
        'statusUser
        '
        Me.statusUser.BackColor = System.Drawing.Color.OrangeRed
        Me.statusUser.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.statusUser.Name = "statusUser"
        Me.statusUser.Size = New System.Drawing.Size(30, 23)
        Me.statusUser.Text = "User"
        '
        'lblToolStripStatus
        '
        Me.lblToolStripStatus.BackColor = System.Drawing.Color.White
        Me.lblToolStripStatus.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.lblToolStripStatus.Name = "lblToolStripStatus"
        Me.lblToolStripStatus.Size = New System.Drawing.Size(38, 23)
        Me.lblToolStripStatus.Text = "0.00%"
        '
        'ToolStripPBar
        '
        Me.ToolStripPBar.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripPBar.Name = "ToolStripPBar"
        Me.ToolStripPBar.Size = New System.Drawing.Size(117, 25)
        Me.ToolStripPBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'Count
        '
        Me.Count.BackColor = System.Drawing.SystemColors.Control
        Me.Count.ForeColor = System.Drawing.SystemColors.Control
        Me.Count.Name = "Count"
        Me.Count.Size = New System.Drawing.Size(13, 20)
        Me.Count.Text = "1"
        '
        'TmpTimer
        '
        Me.TmpTimer.Enabled = True
        '
        'SalesWatcher
        '
        Me.SalesWatcher.Enabled = True
        Me.SalesWatcher.Interval = 30000
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        '
        'StatusCounter
        '
        Me.StatusCounter.BackColor = System.Drawing.SystemColors.Control
        Me.StatusCounter.Name = "StatusCounter"
        Me.StatusCounter.Size = New System.Drawing.Size(50, 20)
        Me.StatusCounter.Text = "Counter"
        '
        'Counter
        '
        Me.Counter.Enabled = True
        Me.Counter.Interval = 1000
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(1003, 576)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.Text = "Monitoring System"
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
    Friend WithEvents TmpTimer As System.Windows.Forms.Timer
    Friend WithEvents MagazineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddPaperRollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdjustmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalesWatcher As System.Windows.Forms.Timer
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripPBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Count As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaperEmptyDeclarationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusCounter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Counter As System.Windows.Forms.Timer
End Class
