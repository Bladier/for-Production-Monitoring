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
        Me.StatusCounter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblToolStripStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripPBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Count = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TmpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SalesWatcher = New System.Windows.Forms.Timer(Me.components)
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.Counter = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'menuLogin
        '
        Me.menuLogin.Name = "menuLogin"
        Me.menuLogin.Size = New System.Drawing.Size(219, 22)
        Me.menuLogin.Text = "&Login"
        '
        'AdjustmentToolStripMenuItem
        '
        Me.AdjustmentToolStripMenuItem.Name = "AdjustmentToolStripMenuItem"
        Me.AdjustmentToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.AdjustmentToolStripMenuItem.Text = "&Adjustment"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'PaperEmptyDeclarationToolStripMenuItem
        '
        Me.PaperEmptyDeclarationToolStripMenuItem.Name = "PaperEmptyDeclarationToolStripMenuItem"
        Me.PaperEmptyDeclarationToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.PaperEmptyDeclarationToolStripMenuItem.Text = "Paper empty &Declaration"
        '
        'menuInitialization
        '
        Me.menuInitialization.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadMagazineToolStripMenuItem})
        Me.menuInitialization.Name = "menuInitialization"
        Me.menuInitialization.Size = New System.Drawing.Size(88, 20)
        Me.menuInitialization.Text = "Initialization"
        '
        'LoadMagazineToolStripMenuItem
        '
        Me.LoadMagazineToolStripMenuItem.Name = "LoadMagazineToolStripMenuItem"
        Me.LoadMagazineToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.LoadMagazineToolStripMenuItem.Text = "&Load Magazine"
        '
        'MagazineToolStripMenuItem
        '
        Me.MagazineToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddPaperRollToolStripMenuItem, Me.AddItemToolStripMenuItem})
        Me.MagazineToolStripMenuItem.Name = "MagazineToolStripMenuItem"
        Me.MagazineToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.MagazineToolStripMenuItem.Text = "Magazine"
        '
        'AddPaperRollToolStripMenuItem
        '
        Me.AddPaperRollToolStripMenuItem.Name = "AddPaperRollToolStripMenuItem"
        Me.AddPaperRollToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.AddPaperRollToolStripMenuItem.Text = "Add &Paper Roll"
        '
        'AddItemToolStripMenuItem
        '
        Me.AddItemToolStripMenuItem.Name = "AddItemToolStripMenuItem"
        Me.AddItemToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.AddItemToolStripMenuItem.Text = "Add &Item"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.TransactionToolStripMenuItem.Text = "Transaction"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = CType(resources.GetObject("StatusStrip1.BackgroundImage"), System.Drawing.Image)
        Me.StatusStrip1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusDateandTime, Me.statusUser, Me.StatusCounter, Me.lblToolStripStatus, Me.ToolStripPBar, Me.Count})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 550)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1003, 26)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusDateandTime
        '
        Me.statusDateandTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.statusDateandTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.statusDateandTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.statusDateandTime.Image = CType(resources.GetObject("statusDateandTime.Image"), System.Drawing.Image)
        Me.statusDateandTime.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.statusDateandTime.Name = "statusDateandTime"
        Me.statusDateandTime.Size = New System.Drawing.Size(103, 24)
        Me.statusDateandTime.Text = "Date Not Set"
        '
        'statusUser
        '
        Me.statusUser.BackColor = System.Drawing.Color.Gainsboro
        Me.statusUser.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.statusUser.Image = CType(resources.GetObject("statusUser.Image"), System.Drawing.Image)
        Me.statusUser.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.statusUser.Name = "statusUser"
        Me.statusUser.Size = New System.Drawing.Size(55, 24)
        Me.statusUser.Text = "User"
        '
        'StatusCounter
        '
        Me.StatusCounter.BackColor = System.Drawing.SystemColors.Control
        Me.StatusCounter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusCounter.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StatusCounter.Image = CType(resources.GetObject("StatusCounter.Image"), System.Drawing.Image)
        Me.StatusCounter.Margin = New System.Windows.Forms.Padding(0)
        Me.StatusCounter.Name = "StatusCounter"
        Me.StatusCounter.Size = New System.Drawing.Size(42, 26)
        Me.StatusCounter.Text = "30"
        '
        'lblToolStripStatus
        '
        Me.lblToolStripStatus.BackColor = System.Drawing.Color.White
        Me.lblToolStripStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblToolStripStatus.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.lblToolStripStatus.Name = "lblToolStripStatus"
        Me.lblToolStripStatus.Size = New System.Drawing.Size(49, 24)
        Me.lblToolStripStatus.Text = "0.00%"
        '
        'ToolStripPBar
        '
        Me.ToolStripPBar.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ToolStripPBar.Name = "ToolStripPBar"
        Me.ToolStripPBar.Size = New System.Drawing.Size(117, 25)
        Me.ToolStripPBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'Count
        '
        Me.Count.BackColor = System.Drawing.SystemColors.Control
        Me.Count.ForeColor = System.Drawing.Color.Silver
        Me.Count.Name = "Count"
        Me.Count.Size = New System.Drawing.Size(15, 21)
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
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1003, 576)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
