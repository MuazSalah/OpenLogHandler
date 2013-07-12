<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFindAndReplace
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
        Me.CmdReplace = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.TxtFind = New System.Windows.Forms.TextBox()
        Me.TxtReplace = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CmdReplace
        '
        Me.CmdReplace.Location = New System.Drawing.Point(225, 12)
        Me.CmdReplace.Name = "CmdReplace"
        Me.CmdReplace.Size = New System.Drawing.Size(69, 46)
        Me.CmdReplace.TabIndex = 1
        Me.CmdReplace.Text = "Replace"
        Me.CmdReplace.UseVisualStyleBackColor = True
        '
        'CmdCancel
        '
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Location = New System.Drawing.Point(12, 64)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(282, 23)
        Me.CmdCancel.TabIndex = 2
        Me.CmdCancel.Text = "Close"
        Me.CmdCancel.UseVisualStyleBackColor = True
        '
        'TxtFind
        '
        Me.TxtFind.Location = New System.Drawing.Point(93, 12)
        Me.TxtFind.Name = "TxtFind"
        Me.TxtFind.Size = New System.Drawing.Size(126, 20)
        Me.TxtFind.TabIndex = 4
        '
        'TxtReplace
        '
        Me.TxtReplace.Location = New System.Drawing.Point(93, 38)
        Me.TxtReplace.Name = "TxtReplace"
        Me.TxtReplace.Size = New System.Drawing.Size(126, 20)
        Me.TxtReplace.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Find:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Replace With:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 39)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "The following special Characters are supported" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\r: New Line" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\t: Tab"
        '
        'FrmFindAndReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CmdCancel
        Me.ClientSize = New System.Drawing.Size(301, 146)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtReplace)
        Me.Controls.Add(Me.TxtFind)
        Me.Controls.Add(Me.CmdCancel)
        Me.Controls.Add(Me.CmdReplace)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmFindAndReplace"
        Me.Text = "Text Formatter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdReplace As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents TxtFind As System.Windows.Forms.TextBox
    Friend WithEvents TxtReplace As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
