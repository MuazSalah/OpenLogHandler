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
        Me.COMSerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripLblOnlineState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripPrgBarSDSpace = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripLblSDSpaceInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CmbCOM = New System.Windows.Forms.ComboBox()
        Me.PrgReadProgress = New System.Windows.Forms.ProgressBar()
        Me.CancelDeletionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MarkForDeletionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LstLogFiles = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TxtLog = New System.Windows.Forms.RichTextBox()
        Me.TmrReadTimeOut = New System.Windows.Forms.Timer(Me.components)
        Me.TxtTerminal = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindAndReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoFindOpenLOGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.CmdReadCOMPorts = New System.Windows.Forms.Button()
        Me.CmdRead = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'COMSerialPort
        '
        Me.COMSerialPort.BaudRate = 57600
        Me.COMSerialPort.PortName = "COM46"
        Me.COMSerialPort.ReadBufferSize = 10000000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripLblOnlineState, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripPrgBarSDSpace, Me.ToolStripLblSDSpaceInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 413)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(562, 22)
        Me.StatusStrip1.TabIndex = 25
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(77, 17)
        Me.ToolStripStatusLabel1.Text = "Data Logger: "
        '
        'ToolStripLblOnlineState
        '
        Me.ToolStripLblOnlineState.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLblOnlineState.ForeColor = System.Drawing.Color.Red
        Me.ToolStripLblOnlineState.Name = "ToolStripLblOnlineState"
        Me.ToolStripLblOnlineState.Size = New System.Drawing.Size(53, 17)
        Me.ToolStripLblOnlineState.Text = "OFFLINE"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel3.Text = "|"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(53, 17)
        Me.ToolStripStatusLabel4.Text = "Storage: "
        '
        'ToolStripPrgBarSDSpace
        '
        Me.ToolStripPrgBarSDSpace.Name = "ToolStripPrgBarSDSpace"
        Me.ToolStripPrgBarSDSpace.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripLblSDSpaceInfo
        '
        Me.ToolStripLblSDSpaceInfo.Name = "ToolStripLblSDSpaceInfo"
        Me.ToolStripLblSDSpaceInfo.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripLblSDSpaceInfo.Text = "..."
        '
        'CmbCOM
        '
        Me.CmbCOM.FormattingEnabled = True
        Me.CmbCOM.Location = New System.Drawing.Point(76, 45)
        Me.CmbCOM.Name = "CmbCOM"
        Me.CmbCOM.Size = New System.Drawing.Size(92, 21)
        Me.CmbCOM.TabIndex = 28
        '
        'PrgReadProgress
        '
        Me.PrgReadProgress.Location = New System.Drawing.Point(264, 36)
        Me.PrgReadProgress.Name = "PrgReadProgress"
        Me.PrgReadProgress.Size = New System.Drawing.Size(288, 37)
        Me.PrgReadProgress.TabIndex = 27
        '
        'CancelDeletionToolStripMenuItem
        '
        Me.CancelDeletionToolStripMenuItem.Enabled = False
        Me.CancelDeletionToolStripMenuItem.Name = "CancelDeletionToolStripMenuItem"
        Me.CancelDeletionToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.CancelDeletionToolStripMenuItem.Text = "Cancel deletion"
        '
        'DeleteFileToolStripMenuItem
        '
        Me.DeleteFileToolStripMenuItem.Enabled = False
        Me.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
        Me.DeleteFileToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.DeleteFileToolStripMenuItem.Text = "Delete File"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "File Name"
        Me.ColumnHeader1.Width = 98
        '
        'MarkForDeletionToolStripMenuItem
        '
        Me.MarkForDeletionToolStripMenuItem.Name = "MarkForDeletionToolStripMenuItem"
        Me.MarkForDeletionToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.MarkForDeletionToolStripMenuItem.Text = "Mark for deletion"
        '
        'LstLogFiles
        '
        Me.LstLogFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.LstLogFiles.FullRowSelect = True
        Me.LstLogFiles.Location = New System.Drawing.Point(12, 80)
        Me.LstLogFiles.Name = "LstLogFiles"
        Me.LstLogFiles.Size = New System.Drawing.Size(176, 225)
        Me.LstLogFiles.TabIndex = 23
        Me.LstLogFiles.UseCompatibleStateImageBehavior = False
        Me.LstLogFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Size (B)"
        Me.ColumnHeader2.Width = 51
        '
        'TxtLog
        '
        Me.TxtLog.Location = New System.Drawing.Point(3, 322)
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ReadOnly = True
        Me.TxtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.TxtLog.Size = New System.Drawing.Size(553, 85)
        Me.TxtLog.TabIndex = 22
        Me.TxtLog.Text = ""
        '
        'TxtTerminal
        '
        Me.TxtTerminal.Location = New System.Drawing.Point(194, 80)
        Me.TxtTerminal.Multiline = True
        Me.TxtTerminal.Name = "TxtTerminal"
        Me.TxtTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtTerminal.Size = New System.Drawing.Size(362, 225)
        Me.TxtTerminal.TabIndex = 21
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(562, 24)
        Me.MenuStrip1.TabIndex = 24
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindAndReplaceToolStripMenuItem, Me.ToolStripSeparator1, Me.MarkForDeletionToolStripMenuItem, Me.DeleteFileToolStripMenuItem, Me.CancelDeletionToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'FindAndReplaceToolStripMenuItem
        '
        Me.FindAndReplaceToolStripMenuItem.Name = "FindAndReplaceToolStripMenuItem"
        Me.FindAndReplaceToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.FindAndReplaceToolStripMenuItem.Text = "Find and Replace"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(162, 6)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationsToolStripMenuItem, Me.AutoFindOpenLOGToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ConfigurationsToolStripMenuItem
        '
        Me.ConfigurationsToolStripMenuItem.Enabled = False
        Me.ConfigurationsToolStripMenuItem.Name = "ConfigurationsToolStripMenuItem"
        Me.ConfigurationsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ConfigurationsToolStripMenuItem.Text = "Configurations"
        '
        'AutoFindOpenLOGToolStripMenuItem
        '
        Me.AutoFindOpenLOGToolStripMenuItem.Checked = True
        Me.AutoFindOpenLOGToolStripMenuItem.CheckOnClick = True
        Me.AutoFindOpenLOGToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoFindOpenLOGToolStripMenuItem.Name = "AutoFindOpenLOGToolStripMenuItem"
        Me.AutoFindOpenLOGToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.AutoFindOpenLOGToolStripMenuItem.Tag = "Will try to Auto find OpenLOG when the Refresh button is pressed"
        Me.AutoFindOpenLOGToolStripMenuItem.Text = "AutoFind OpenLOG"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "COM Port: "
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(562, 435)
        Me.ShapeContainer1.TabIndex = 30
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 1
        Me.LineShape1.X2 = 552
        Me.LineShape1.Y1 = 311
        Me.LineShape1.Y2 = 311
        '
        'CmdReadCOMPorts
        '
        Me.CmdReadCOMPorts.Image = CType(resources.GetObject("CmdReadCOMPorts.Image"), System.Drawing.Image)
        Me.CmdReadCOMPorts.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdReadCOMPorts.Location = New System.Drawing.Point(165, 42)
        Me.CmdReadCOMPorts.Name = "CmdReadCOMPorts"
        Me.CmdReadCOMPorts.Size = New System.Drawing.Size(25, 25)
        Me.CmdReadCOMPorts.TabIndex = 31
        Me.CmdReadCOMPorts.Tag = "Refresh COM Ports"
        Me.CmdReadCOMPorts.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdReadCOMPorts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdReadCOMPorts.UseVisualStyleBackColor = True
        '
        'CmdRead
        '
        Me.CmdRead.Enabled = False
        Me.CmdRead.Image = CType(resources.GetObject("CmdRead.Image"), System.Drawing.Image)
        Me.CmdRead.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdRead.Location = New System.Drawing.Point(194, 36)
        Me.CmdRead.Name = "CmdRead"
        Me.CmdRead.Size = New System.Drawing.Size(64, 37)
        Me.CmdRead.TabIndex = 26
        Me.CmdRead.Text = "Read Files"
        Me.CmdRead.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CmdRead.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 435)
        Me.Controls.Add(Me.CmdReadCOMPorts)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CmbCOM)
        Me.Controls.Add(Me.PrgReadProgress)
        Me.Controls.Add(Me.CmdRead)
        Me.Controls.Add(Me.LstLogFiles)
        Me.Controls.Add(Me.TxtLog)
        Me.Controls.Add(Me.TxtTerminal)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.MinimumSize = New System.Drawing.Size(578, 473)
        Me.Name = "FrmMain"
        Me.Text = "OpenLog"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents COMSerialPort As System.IO.Ports.SerialPort
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLblOnlineState As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripPrgBarSDSpace As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripLblSDSpaceInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CmbCOM As System.Windows.Forms.ComboBox
    Friend WithEvents PrgReadProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents CmdRead As System.Windows.Forms.Button
    Friend WithEvents CancelDeletionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents MarkForDeletionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LstLogFiles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TxtLog As System.Windows.Forms.RichTextBox
    Friend WithEvents TmrReadTimeOut As System.Windows.Forms.Timer
    Friend WithEvents TxtTerminal As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CmdReadCOMPorts As System.Windows.Forms.Button
    Friend WithEvents AutoFindOpenLOGToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindAndReplaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
