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
        Me.AdjustmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaperEmptyDeclarationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InitializePaperRollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductionToolstrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusDateandTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusCounter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblToolStripStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripPBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusSalesMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Count = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TmpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SalesWatcher = New System.Windows.Forms.Timer(Me.components)
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.Counter = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLogin = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripActiveUser = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripChangePaperRoll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripAddpaperroll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripAdjusment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMonitor = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ItemToolStripMenuItem, Me.ReportsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1003, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdjustmentToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.PaperEmptyDeclarationToolStripMenuItem, Me.InitializePaperRollToolStripMenuItem, Me.UserManagementToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AdjustmentToolStripMenuItem
        '
        Me.AdjustmentToolStripMenuItem.Name = "AdjustmentToolStripMenuItem"
        Me.AdjustmentToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.AdjustmentToolStripMenuItem.Text = "&Adjustment"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'PaperEmptyDeclarationToolStripMenuItem
        '
        Me.PaperEmptyDeclarationToolStripMenuItem.Name = "PaperEmptyDeclarationToolStripMenuItem"
        Me.PaperEmptyDeclarationToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.PaperEmptyDeclarationToolStripMenuItem.Text = "Paper &Empty Declaration"
        '
        'InitializePaperRollToolStripMenuItem
        '
        Me.InitializePaperRollToolStripMenuItem.Name = "InitializePaperRollToolStripMenuItem"
        Me.InitializePaperRollToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.InitializePaperRollToolStripMenuItem.Text = "&Initialize paper roll"
        '
        'UserManagementToolStripMenuItem
        '
        Me.UserManagementToolStripMenuItem.Name = "UserManagementToolStripMenuItem"
        Me.UserManagementToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.UserManagementToolStripMenuItem.Text = "&User Management"
        '
        'ItemToolStripMenuItem
        '
        Me.ItemToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddItemToolStripMenuItem})
        Me.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem"
        Me.ItemToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.ItemToolStripMenuItem.Text = "Add Item"
        '
        'AddItemToolStripMenuItem
        '
        Me.AddItemToolStripMenuItem.Name = "AddItemToolStripMenuItem"
        Me.AddItemToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.AddItemToolStripMenuItem.Text = "Add &Item"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductionToolstrip})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportsToolStripMenuItem.Text = "&Reports"
        '
        'ProductionToolstrip
        '
        Me.ProductionToolstrip.Name = "ProductionToolstrip"
        Me.ProductionToolstrip.Size = New System.Drawing.Size(138, 22)
        Me.ProductionToolstrip.Text = "&Production"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = CType(resources.GetObject("StatusStrip1.BackgroundImage"), System.Drawing.Image)
        Me.StatusStrip1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusDateandTime, Me.statusUser, Me.StatusCounter, Me.lblToolStripStatus, Me.ToolStripPBar, Me.ToolStripStatusSalesMessage, Me.Count})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 550)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1003, 26)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusDateandTime
        '
        Me.statusDateandTime.AutoToolTip = True
        Me.statusDateandTime.BackColor = System.Drawing.SystemColors.ControlLight
        Me.statusDateandTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.statusDateandTime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.statusDateandTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.statusDateandTime.Image = CType(resources.GetObject("statusDateandTime.Image"), System.Drawing.Image)
        Me.statusDateandTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.statusDateandTime.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.statusDateandTime.Name = "statusDateandTime"
        Me.statusDateandTime.Size = New System.Drawing.Size(103, 24)
        Me.statusDateandTime.Text = "Date Not Set"
        '
        'statusUser
        '
        Me.statusUser.AutoToolTip = True
        Me.statusUser.BackColor = System.Drawing.Color.Gainsboro
        Me.statusUser.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.statusUser.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.statusUser.Image = CType(resources.GetObject("statusUser.Image"), System.Drawing.Image)
        Me.statusUser.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.statusUser.Name = "statusUser"
        Me.statusUser.Size = New System.Drawing.Size(55, 24)
        Me.statusUser.Text = "User"
        '
        'StatusCounter
        '
        Me.StatusCounter.AutoToolTip = True
        Me.StatusCounter.BackColor = System.Drawing.SystemColors.Control
        Me.StatusCounter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusCounter.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.StatusCounter.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
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
        Me.lblToolStripStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblToolStripStatus.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.lblToolStripStatus.Name = "lblToolStripStatus"
        Me.lblToolStripStatus.Size = New System.Drawing.Size(49, 24)
        Me.lblToolStripStatus.Text = "0.00%"
        '
        'ToolStripPBar
        '
        Me.ToolStripPBar.AutoToolTip = True
        Me.ToolStripPBar.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.ToolStripPBar.Name = "ToolStripPBar"
        Me.ToolStripPBar.Size = New System.Drawing.Size(117, 25)
        Me.ToolStripPBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ToolStripStatusSalesMessage
        '
        Me.ToolStripStatusSalesMessage.AutoToolTip = True
        Me.ToolStripStatusSalesMessage.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripStatusSalesMessage.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusSalesMessage.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusSalesMessage.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripStatusSalesMessage.Name = "ToolStripStatusSalesMessage"
        Me.ToolStripStatusSalesMessage.Size = New System.Drawing.Size(45, 26)
        Me.ToolStripStatusSalesMessage.Text = "Sales"
        '
        'Count
        '
        Me.Count.AutoToolTip = True
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.AutoSize = False
        Me.ToolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripButton1.Checked = True
        Me.ToolStripButton1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(40, 50)
        Me.ToolStripButton1.Text = "&Login"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(2, 10, 10, 10)
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLogin, Me.ToolStripSeparator1, Me.ToolStripActiveUser, Me.ToolStripChangePaperRoll, Me.ToolStripSeparator2, Me.ToolStripAddpaperroll, Me.ToolStripSeparator4, Me.ToolStripAdjusment, Me.ToolStripSeparator3, Me.ToolStripMonitor})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1003, 50)
        Me.ToolStrip1.TabIndex = 1
        '
        'ToolStripLogin
        '
        Me.ToolStripLogin.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLogin.AutoSize = False
        Me.ToolStripLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripLogin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLogin.Image = CType(resources.GetObject("ToolStripLogin.Image"), System.Drawing.Image)
        Me.ToolStripLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripLogin.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStripLogin.Name = "ToolStripLogin"
        Me.ToolStripLogin.Padding = New System.Windows.Forms.Padding(2)
        Me.ToolStripLogin.Size = New System.Drawing.Size(70, 60)
        Me.ToolStripLogin.Text = "&Login"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 50)
        '
        'ToolStripActiveUser
        '
        Me.ToolStripActiveUser.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripActiveUser.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripActiveUser.Name = "ToolStripActiveUser"
        Me.ToolStripActiveUser.Size = New System.Drawing.Size(35, 47)
        Me.ToolStripActiveUser.Text = "User"
        '
        'ToolStripChangePaperRoll
        '
        Me.ToolStripChangePaperRoll.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripChangePaperRoll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStripChangePaperRoll.Image = CType(resources.GetObject("ToolStripChangePaperRoll.Image"), System.Drawing.Image)
        Me.ToolStripChangePaperRoll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripChangePaperRoll.Name = "ToolStripChangePaperRoll"
        Me.ToolStripChangePaperRoll.Size = New System.Drawing.Size(135, 47)
        Me.ToolStripChangePaperRoll.Text = "Change Paper roll"
        Me.ToolStripChangePaperRoll.ToolTipText = "F6 Short cut key"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripAddpaperroll
        '
        Me.ToolStripAddpaperroll.Image = CType(resources.GetObject("ToolStripAddpaperroll.Image"), System.Drawing.Image)
        Me.ToolStripAddpaperroll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAddpaperroll.Name = "ToolStripAddpaperroll"
        Me.ToolStripAddpaperroll.Size = New System.Drawing.Size(119, 47)
        Me.ToolStripAddpaperroll.Text = "Add Paper Roll"
        Me.ToolStripAddpaperroll.ToolTipText = "F7 ""Short cut key"""
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripAdjusment
        '
        Me.ToolStripAdjusment.Image = CType(resources.GetObject("ToolStripAdjusment.Image"), System.Drawing.Image)
        Me.ToolStripAdjusment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAdjusment.Name = "ToolStripAdjusment"
        Me.ToolStripAdjusment.Size = New System.Drawing.Size(203, 47)
        Me.ToolStripAdjusment.Text = "Adjust UnAllocated Paper cut"
        Me.ToolStripAdjusment.ToolTipText = "Adjustment"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripMonitor
        '
        Me.ToolStripMonitor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMonitor.Image = CType(resources.GetObject("ToolStripMonitor.Image"), System.Drawing.Image)
        Me.ToolStripMonitor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripMonitor.Name = "ToolStripMonitor"
        Me.ToolStripMonitor.Size = New System.Drawing.Size(68, 47)
        Me.ToolStripMonitor.Text = "Summary"
        Me.ToolStripMonitor.ToolTipText = "Monitoring"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1003, 476)
        Me.Panel1.TabIndex = 2
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1003, 576)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Monitoring System"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusDateandTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TmpTimer As System.Windows.Forms.Timer
    Friend WithEvents ItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLogin As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripActiveUser As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripChangePaperRoll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripAddpaperroll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InitializePaperRollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusSalesMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripAdjusment As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMonitor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductionToolstrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
