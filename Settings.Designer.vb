<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.chkHoverURL = New System.Windows.Forms.CheckBox()
        Me.chkDeleteExecutable = New System.Windows.Forms.CheckBox()
        Me.chkUpdate = New System.Windows.Forms.CheckBox()
        Me.numUpdateDays = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDownloadLocation = New System.Windows.Forms.TextBox()
        Me.btnBrws = New System.Windows.Forms.Button()
        CType(Me.numUpdateDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkHoverURL
        '
        Me.chkHoverURL.AutoSize = True
        Me.chkHoverURL.Checked = True
        Me.chkHoverURL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHoverURL.Location = New System.Drawing.Point(12, 12)
        Me.chkHoverURL.Name = "chkHoverURL"
        Me.chkHoverURL.Size = New System.Drawing.Size(247, 17)
        Me.chkHoverURL.TabIndex = 0
        Me.chkHoverURL.Text = "Hover over URL textbox to paste clipboard text"
        Me.chkHoverURL.UseVisualStyleBackColor = True
        '
        'chkDeleteExecutable
        '
        Me.chkDeleteExecutable.AutoSize = True
        Me.chkDeleteExecutable.Location = New System.Drawing.Point(12, 35)
        Me.chkDeleteExecutable.Name = "chkDeleteExecutable"
        Me.chkDeleteExecutable.Size = New System.Drawing.Size(259, 17)
        Me.chkDeleteExecutable.TabIndex = 1
        Me.chkDeleteExecutable.Text = "Automatically delete youtube-dl.exe during closing"
        Me.chkDeleteExecutable.UseVisualStyleBackColor = True
        '
        'chkUpdate
        '
        Me.chkUpdate.AutoSize = True
        Me.chkUpdate.Enabled = False
        Me.chkUpdate.Location = New System.Drawing.Point(12, 58)
        Me.chkUpdate.Name = "chkUpdate"
        Me.chkUpdate.Size = New System.Drawing.Size(251, 17)
        Me.chkUpdate.TabIndex = 2
        Me.chkUpdate.Text = "Update youtube-dl.exe every   xxxxxxx      day(s)"
        Me.chkUpdate.UseVisualStyleBackColor = True
        '
        'numUpdateDays
        '
        Me.numUpdateDays.Enabled = False
        Me.numUpdateDays.Location = New System.Drawing.Point(172, 57)
        Me.numUpdateDays.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numUpdateDays.Name = "numUpdateDays"
        Me.numUpdateDays.Size = New System.Drawing.Size(49, 20)
        Me.numUpdateDays.TabIndex = 3
        Me.numUpdateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numUpdateDays.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Download videos to:"
        '
        'txtDownloadLocation
        '
        Me.txtDownloadLocation.Location = New System.Drawing.Point(12, 99)
        Me.txtDownloadLocation.Name = "txtDownloadLocation"
        Me.txtDownloadLocation.ReadOnly = True
        Me.txtDownloadLocation.Size = New System.Drawing.Size(233, 20)
        Me.txtDownloadLocation.TabIndex = 5
        '
        'btnBrws
        '
        Me.btnBrws.Location = New System.Drawing.Point(251, 97)
        Me.btnBrws.Name = "btnBrws"
        Me.btnBrws.Size = New System.Drawing.Size(29, 23)
        Me.btnBrws.TabIndex = 6
        Me.btnBrws.Text = "..."
        Me.btnBrws.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(292, 126)
        Me.Controls.Add(Me.btnBrws)
        Me.Controls.Add(Me.txtDownloadLocation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numUpdateDays)
        Me.Controls.Add(Me.chkUpdate)
        Me.Controls.Add(Me.chkDeleteExecutable)
        Me.Controls.Add(Me.chkHoverURL)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Settings"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.TopMost = True
        CType(Me.numUpdateDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkHoverURL As System.Windows.Forms.CheckBox
    Friend WithEvents chkDeleteExecutable As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents numUpdateDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDownloadLocation As System.Windows.Forms.TextBox
    Friend WithEvents btnBrws As System.Windows.Forms.Button
End Class
