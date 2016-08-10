<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.lblVideoURL = New System.Windows.Forms.Label()
        Me.gbDownloadAs = New System.Windows.Forms.GroupBox()
        Me.LinkHelp = New System.Windows.Forms.LinkLabel()
        Me.rbCustom = New System.Windows.Forms.RadioButton()
        Me.rbAudio = New System.Windows.Forms.RadioButton()
        Me.rbVideo = New System.Windows.Forms.RadioButton()
        Me.lblAudioQuality = New System.Windows.Forms.Label()
        Me.lblCustomArgs = New System.Windows.Forms.Label()
        Me.txtArgs = New System.Windows.Forms.TextBox()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.cbQuality = New System.Windows.Forms.ComboBox()
        Me.lblAudioFormat = New System.Windows.Forms.Label()
        Me.cbFormat = New System.Windows.Forms.ComboBox()
        Me.ProgramInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.MainTabs = New System.Windows.Forms.TabControl()
        Me.tabDownload = New System.Windows.Forms.TabPage()
        Me.TestButton = New System.Windows.Forms.Button()
        Me.tabConvert = New System.Windows.Forms.TabPage()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.lblConvertAudioFormat = New System.Windows.Forms.Label()
        Me.cbConvFormat = New System.Windows.Forms.ComboBox()
        Me.cbConvQuality = New System.Windows.Forms.ComboBox()
        Me.lblConvertAudioQuality = New System.Windows.Forms.Label()
        Me.btnBrowseConvSaveFile = New System.Windows.Forms.Button()
        Me.btnBrowseConvFile = New System.Windows.Forms.Button()
        Me.txtConvFile = New System.Windows.Forms.TextBox()
        Me.lblFileToConvert = New System.Windows.Forms.Label()
        Me.txtConvSave = New System.Windows.Forms.TextBox()
        Me.lblSaveAs = New System.Windows.Forms.Label()
        Me.chkSaveToMaster = New System.Windows.Forms.CheckBox()
        Me.tabAbout = New System.Windows.Forms.TabPage()
        Me.btnOptions = New System.Windows.Forms.Button()
        Me.Truth = New System.Windows.Forms.Label()
        Me.lblAbout = New System.Windows.Forms.Label()
        Me.GithubLink = New System.Windows.Forms.LinkLabel()
        Me.vers = New System.Windows.Forms.Label()
        Me.gbDownloadAs.SuspendLayout()
        Me.MainTabs.SuspendLayout()
        Me.tabDownload.SuspendLayout()
        Me.tabConvert.SuspendLayout()
        Me.tabAbout.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblVideoURL
        '
        Me.lblVideoURL.AutoSize = True
        Me.lblVideoURL.Location = New System.Drawing.Point(8, 6)
        Me.lblVideoURL.Name = "lblVideoURL"
        Me.lblVideoURL.Size = New System.Drawing.Size(155, 13)
        Me.lblVideoURL.TabIndex = 0
        Me.lblVideoURL.Text = "Video / Playlist / Channel URL:"
        '
        'gbDownloadAs
        '
        Me.gbDownloadAs.Controls.Add(Me.LinkHelp)
        Me.gbDownloadAs.Controls.Add(Me.rbCustom)
        Me.gbDownloadAs.Controls.Add(Me.rbAudio)
        Me.gbDownloadAs.Controls.Add(Me.rbVideo)
        Me.gbDownloadAs.Location = New System.Drawing.Point(7, 47)
        Me.gbDownloadAs.Name = "gbDownloadAs"
        Me.gbDownloadAs.Size = New System.Drawing.Size(226, 47)
        Me.gbDownloadAs.TabIndex = 2
        Me.gbDownloadAs.TabStop = False
        Me.gbDownloadAs.Text = "Download as"
        '
        'LinkHelp
        '
        Me.LinkHelp.AutoSize = True
        Me.LinkHelp.Location = New System.Drawing.Point(191, 21)
        Me.LinkHelp.Name = "LinkHelp"
        Me.LinkHelp.Size = New System.Drawing.Size(13, 13)
        Me.LinkHelp.TabIndex = 3
        Me.LinkHelp.TabStop = True
        Me.LinkHelp.Text = "?"
        Me.ProgramInfo.SetToolTip(Me.LinkHelp, "No arguments have been pre-made, you must enter them all in yourself." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click this" & _
        " question mark to go to the readme of youtube-dl to read about the arguments.")
        '
        'rbCustom
        '
        Me.rbCustom.AutoSize = True
        Me.rbCustom.Location = New System.Drawing.Point(137, 19)
        Me.rbCustom.Name = "rbCustom"
        Me.rbCustom.Size = New System.Drawing.Size(59, 17)
        Me.rbCustom.TabIndex = 2
        Me.rbCustom.Text = "Custom"
        Me.rbCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbCustom.UseVisualStyleBackColor = True
        '
        'rbAudio
        '
        Me.rbAudio.AutoSize = True
        Me.rbAudio.Location = New System.Drawing.Point(80, 19)
        Me.rbAudio.Name = "rbAudio"
        Me.rbAudio.Size = New System.Drawing.Size(51, 17)
        Me.rbAudio.TabIndex = 1
        Me.rbAudio.Text = "Audio"
        Me.rbAudio.UseVisualStyleBackColor = True
        '
        'rbVideo
        '
        Me.rbVideo.AutoSize = True
        Me.rbVideo.Checked = True
        Me.rbVideo.Location = New System.Drawing.Point(23, 19)
        Me.rbVideo.Name = "rbVideo"
        Me.rbVideo.Size = New System.Drawing.Size(51, 17)
        Me.rbVideo.TabIndex = 0
        Me.rbVideo.TabStop = True
        Me.rbVideo.Text = "Video"
        Me.rbVideo.UseVisualStyleBackColor = True
        '
        'lblAudioQuality
        '
        Me.lblAudioQuality.AutoSize = True
        Me.lblAudioQuality.Location = New System.Drawing.Point(53, 105)
        Me.lblAudioQuality.Name = "lblAudioQuality"
        Me.lblAudioQuality.Size = New System.Drawing.Size(69, 13)
        Me.lblAudioQuality.TabIndex = 4
        Me.lblAudioQuality.Text = "Audio Quality"
        '
        'lblCustomArgs
        '
        Me.lblCustomArgs.AutoSize = True
        Me.lblCustomArgs.Location = New System.Drawing.Point(8, 156)
        Me.lblCustomArgs.Name = "lblCustomArgs"
        Me.lblCustomArgs.Size = New System.Drawing.Size(69, 13)
        Me.lblCustomArgs.TabIndex = 5
        Me.lblCustomArgs.Text = "Custom Args:"
        '
        'txtArgs
        '
        Me.txtArgs.Location = New System.Drawing.Point(8, 175)
        Me.txtArgs.Name = "txtArgs"
        Me.txtArgs.ReadOnly = True
        Me.txtArgs.Size = New System.Drawing.Size(226, 20)
        Me.txtArgs.TabIndex = 6
        Me.txtArgs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(6, 199)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(228, 23)
        Me.btnDownload.TabIndex = 7
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(8, 22)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(226, 20)
        Me.txtURL.TabIndex = 8
        Me.txtURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbQuality
        '
        Me.cbQuality.Enabled = False
        Me.cbQuality.FormattingEnabled = True
        Me.cbQuality.Items.AddRange(New Object() {"8K", "16K", "24K", "32K", "40K", "48K", "56K", "64K", "80K", "96K", "112K", "128K", "144K", "160K", "192K", "224K", "256K", "320K"})
        Me.cbQuality.Location = New System.Drawing.Point(128, 102)
        Me.cbQuality.Name = "cbQuality"
        Me.cbQuality.Size = New System.Drawing.Size(59, 21)
        Me.cbQuality.TabIndex = 3
        '
        'lblAudioFormat
        '
        Me.lblAudioFormat.AutoSize = True
        Me.lblAudioFormat.Location = New System.Drawing.Point(53, 132)
        Me.lblAudioFormat.Name = "lblAudioFormat"
        Me.lblAudioFormat.Size = New System.Drawing.Size(69, 13)
        Me.lblAudioFormat.TabIndex = 13
        Me.lblAudioFormat.Text = "Audio Format"
        '
        'cbFormat
        '
        Me.cbFormat.Enabled = False
        Me.cbFormat.FormattingEnabled = True
        Me.cbFormat.Items.AddRange(New Object() {"best", "aac", "vorbis", "mp3", "m4a", "opus", "wav"})
        Me.cbFormat.Location = New System.Drawing.Point(128, 129)
        Me.cbFormat.Name = "cbFormat"
        Me.cbFormat.Size = New System.Drawing.Size(59, 21)
        Me.cbFormat.TabIndex = 12
        '
        'ProgramInfo
        '
        Me.ProgramInfo.AutoPopDelay = 10000
        Me.ProgramInfo.InitialDelay = 250
        Me.ProgramInfo.ReshowDelay = 100
        '
        'MainTabs
        '
        Me.MainTabs.Controls.Add(Me.tabDownload)
        Me.MainTabs.Controls.Add(Me.tabConvert)
        Me.MainTabs.Controls.Add(Me.tabAbout)
        Me.MainTabs.Location = New System.Drawing.Point(0, 0)
        Me.MainTabs.Name = "MainTabs"
        Me.MainTabs.SelectedIndex = 0
        Me.MainTabs.Size = New System.Drawing.Size(249, 253)
        Me.MainTabs.TabIndex = 14
        '
        'tabDownload
        '
        Me.tabDownload.Controls.Add(Me.TestButton)
        Me.tabDownload.Controls.Add(Me.lblVideoURL)
        Me.tabDownload.Controls.Add(Me.lblAudioFormat)
        Me.tabDownload.Controls.Add(Me.gbDownloadAs)
        Me.tabDownload.Controls.Add(Me.cbFormat)
        Me.tabDownload.Controls.Add(Me.cbQuality)
        Me.tabDownload.Controls.Add(Me.lblAudioQuality)
        Me.tabDownload.Controls.Add(Me.lblCustomArgs)
        Me.tabDownload.Controls.Add(Me.txtArgs)
        Me.tabDownload.Controls.Add(Me.txtURL)
        Me.tabDownload.Controls.Add(Me.btnDownload)
        Me.tabDownload.Location = New System.Drawing.Point(4, 22)
        Me.tabDownload.Name = "tabDownload"
        Me.tabDownload.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDownload.Size = New System.Drawing.Size(241, 227)
        Me.tabDownload.TabIndex = 0
        Me.tabDownload.Text = "Download"
        Me.tabDownload.UseVisualStyleBackColor = True
        '
        'TestButton
        '
        Me.TestButton.Location = New System.Drawing.Point(160, 199)
        Me.TestButton.Name = "TestButton"
        Me.TestButton.Size = New System.Drawing.Size(75, 23)
        Me.TestButton.TabIndex = 14
        Me.TestButton.Text = "Test Button"
        Me.TestButton.UseVisualStyleBackColor = True
        Me.TestButton.Visible = False
        '
        'tabConvert
        '
        Me.tabConvert.Controls.Add(Me.btnConvert)
        Me.tabConvert.Controls.Add(Me.lblConvertAudioFormat)
        Me.tabConvert.Controls.Add(Me.cbConvFormat)
        Me.tabConvert.Controls.Add(Me.cbConvQuality)
        Me.tabConvert.Controls.Add(Me.lblConvertAudioQuality)
        Me.tabConvert.Controls.Add(Me.btnBrowseConvSaveFile)
        Me.tabConvert.Controls.Add(Me.btnBrowseConvFile)
        Me.tabConvert.Controls.Add(Me.txtConvFile)
        Me.tabConvert.Controls.Add(Me.lblFileToConvert)
        Me.tabConvert.Controls.Add(Me.txtConvSave)
        Me.tabConvert.Controls.Add(Me.lblSaveAs)
        Me.tabConvert.Controls.Add(Me.chkSaveToMaster)
        Me.tabConvert.Location = New System.Drawing.Point(4, 22)
        Me.tabConvert.Name = "tabConvert"
        Me.tabConvert.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConvert.Size = New System.Drawing.Size(241, 227)
        Me.tabConvert.TabIndex = 1
        Me.tabConvert.Text = "Convert Audio"
        Me.tabConvert.UseVisualStyleBackColor = True
        '
        'btnConvert
        '
        Me.btnConvert.Enabled = False
        Me.btnConvert.Location = New System.Drawing.Point(83, 186)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(75, 23)
        Me.btnConvert.TabIndex = 18
        Me.btnConvert.Text = "Convert"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'lblConvertAudioFormat
        '
        Me.lblConvertAudioFormat.AutoSize = True
        Me.lblConvertAudioFormat.Location = New System.Drawing.Point(53, 157)
        Me.lblConvertAudioFormat.Name = "lblConvertAudioFormat"
        Me.lblConvertAudioFormat.Size = New System.Drawing.Size(69, 13)
        Me.lblConvertAudioFormat.TabIndex = 17
        Me.lblConvertAudioFormat.Text = "Audio Format"
        '
        'cbConvFormat
        '
        Me.cbConvFormat.FormattingEnabled = True
        Me.cbConvFormat.Items.AddRange(New Object() {"best", "aac", "vorbis", "mp3", "m4a", "opus", "wav"})
        Me.cbConvFormat.Location = New System.Drawing.Point(128, 154)
        Me.cbConvFormat.Name = "cbConvFormat"
        Me.cbConvFormat.Size = New System.Drawing.Size(59, 21)
        Me.cbConvFormat.TabIndex = 16
        Me.cbConvFormat.Text = "mp3"
        '
        'cbConvQuality
        '
        Me.cbConvQuality.FormattingEnabled = True
        Me.cbConvQuality.Items.AddRange(New Object() {"8K", "16K", "24K", "32K", "40K", "48K", "56K", "64K", "80K", "96K", "112K", "128K", "144K", "160K", "192K", "224K", "256K", "320K"})
        Me.cbConvQuality.Location = New System.Drawing.Point(128, 127)
        Me.cbConvQuality.Name = "cbConvQuality"
        Me.cbConvQuality.Size = New System.Drawing.Size(59, 21)
        Me.cbConvQuality.TabIndex = 14
        Me.cbConvQuality.Text = "192K"
        '
        'lblConvertAudioQuality
        '
        Me.lblConvertAudioQuality.AutoSize = True
        Me.lblConvertAudioQuality.Location = New System.Drawing.Point(53, 130)
        Me.lblConvertAudioQuality.Name = "lblConvertAudioQuality"
        Me.lblConvertAudioQuality.Size = New System.Drawing.Size(69, 13)
        Me.lblConvertAudioQuality.TabIndex = 15
        Me.lblConvertAudioQuality.Text = "Audio Quality"
        '
        'btnBrowseConvSaveFile
        '
        Me.btnBrowseConvSaveFile.Enabled = False
        Me.btnBrowseConvSaveFile.Location = New System.Drawing.Point(205, 95)
        Me.btnBrowseConvSaveFile.Name = "btnBrowseConvSaveFile"
        Me.btnBrowseConvSaveFile.Size = New System.Drawing.Size(28, 23)
        Me.btnBrowseConvSaveFile.TabIndex = 6
        Me.btnBrowseConvSaveFile.Text = "..."
        Me.btnBrowseConvSaveFile.UseVisualStyleBackColor = True
        '
        'btnBrowseConvFile
        '
        Me.btnBrowseConvFile.Location = New System.Drawing.Point(205, 31)
        Me.btnBrowseConvFile.Name = "btnBrowseConvFile"
        Me.btnBrowseConvFile.Size = New System.Drawing.Size(28, 23)
        Me.btnBrowseConvFile.TabIndex = 5
        Me.btnBrowseConvFile.Text = "..."
        Me.btnBrowseConvFile.UseVisualStyleBackColor = True
        '
        'txtConvFile
        '
        Me.txtConvFile.Location = New System.Drawing.Point(10, 33)
        Me.txtConvFile.Name = "txtConvFile"
        Me.txtConvFile.ReadOnly = True
        Me.txtConvFile.Size = New System.Drawing.Size(189, 20)
        Me.txtConvFile.TabIndex = 4
        Me.txtConvFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFileToConvert
        '
        Me.lblFileToConvert.AutoSize = True
        Me.lblFileToConvert.Location = New System.Drawing.Point(7, 14)
        Me.lblFileToConvert.Name = "lblFileToConvert"
        Me.lblFileToConvert.Size = New System.Drawing.Size(77, 13)
        Me.lblFileToConvert.TabIndex = 3
        Me.lblFileToConvert.Text = "File to convert:"
        '
        'txtConvSave
        '
        Me.txtConvSave.Enabled = False
        Me.txtConvSave.Location = New System.Drawing.Point(10, 97)
        Me.txtConvSave.Name = "txtConvSave"
        Me.txtConvSave.ReadOnly = True
        Me.txtConvSave.Size = New System.Drawing.Size(189, 20)
        Me.txtConvSave.TabIndex = 2
        '
        'lblSaveAs
        '
        Me.lblSaveAs.AutoSize = True
        Me.lblSaveAs.Location = New System.Drawing.Point(7, 78)
        Me.lblSaveAs.Name = "lblSaveAs"
        Me.lblSaveAs.Size = New System.Drawing.Size(46, 13)
        Me.lblSaveAs.TabIndex = 1
        Me.lblSaveAs.Text = "Save as"
        '
        'chkSaveToMaster
        '
        Me.chkSaveToMaster.AutoSize = True
        Me.chkSaveToMaster.Checked = True
        Me.chkSaveToMaster.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSaveToMaster.Location = New System.Drawing.Point(39, 59)
        Me.chkSaveToMaster.Name = "chkSaveToMaster"
        Me.chkSaveToMaster.Size = New System.Drawing.Size(162, 17)
        Me.chkSaveToMaster.TabIndex = 0
        Me.chkSaveToMaster.Text = "Save to same path as master"
        Me.chkSaveToMaster.UseVisualStyleBackColor = True
        '
        'tabAbout
        '
        Me.tabAbout.Controls.Add(Me.btnOptions)
        Me.tabAbout.Controls.Add(Me.Truth)
        Me.tabAbout.Controls.Add(Me.lblAbout)
        Me.tabAbout.Location = New System.Drawing.Point(4, 22)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAbout.Size = New System.Drawing.Size(241, 227)
        Me.tabAbout.TabIndex = 2
        Me.tabAbout.Text = "About"
        Me.tabAbout.UseVisualStyleBackColor = True
        '
        'btnOptions
        '
        Me.btnOptions.Location = New System.Drawing.Point(86, 128)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(69, 23)
        Me.btnOptions.TabIndex = 10
        Me.btnOptions.Text = "Options"
        Me.btnOptions.UseVisualStyleBackColor = True
        '
        'Truth
        '
        Me.Truth.AutoSize = True
        Me.Truth.Location = New System.Drawing.Point(61, 180)
        Me.Truth.Name = "Truth"
        Me.Truth.Size = New System.Drawing.Size(118, 39)
        Me.Truth.TabIndex = 1
        Me.Truth.Text = "lucario is best pokemon" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "try to prove me wrong" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ">protip you cant"
        Me.Truth.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Truth.Visible = False
        '
        'lblAbout
        '
        Me.lblAbout.AutoSize = True
        Me.lblAbout.Location = New System.Drawing.Point(15, 84)
        Me.lblAbout.Name = "lblAbout"
        Me.lblAbout.Size = New System.Drawing.Size(211, 39)
        Me.lblAbout.TabIndex = 0
        Me.lblAbout.Text = "youtue-dl GUI made by Obscure" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "youtube-dl made by rg3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Inifile support by Someone" & _
    " from the Internet"
        Me.lblAbout.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GithubLink
        '
        Me.GithubLink.AutoSize = True
        Me.GithubLink.Location = New System.Drawing.Point(207, 255)
        Me.GithubLink.Name = "GithubLink"
        Me.GithubLink.Size = New System.Drawing.Size(38, 13)
        Me.GithubLink.TabIndex = 2
        Me.GithubLink.TabStop = True
        Me.GithubLink.Text = "Github"
        '
        'vers
        '
        Me.vers.AutoSize = True
        Me.vers.Location = New System.Drawing.Point(2, 255)
        Me.vers.Name = "vers"
        Me.vers.Size = New System.Drawing.Size(27, 13)
        Me.vers.TabIndex = 2
        Me.vers.Text = "vers"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(248, 269)
        Me.Controls.Add(Me.vers)
        Me.Controls.Add(Me.GithubLink)
        Me.Controls.Add(Me.MainTabs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "youtube-dl GUI"
        Me.gbDownloadAs.ResumeLayout(False)
        Me.gbDownloadAs.PerformLayout()
        Me.MainTabs.ResumeLayout(False)
        Me.tabDownload.ResumeLayout(False)
        Me.tabDownload.PerformLayout()
        Me.tabConvert.ResumeLayout(False)
        Me.tabConvert.PerformLayout()
        Me.tabAbout.ResumeLayout(False)
        Me.tabAbout.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVideoURL As System.Windows.Forms.Label
    Friend WithEvents gbDownloadAs As System.Windows.Forms.GroupBox
    Friend WithEvents LinkHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents rbCustom As System.Windows.Forms.RadioButton
    Friend WithEvents rbAudio As System.Windows.Forms.RadioButton
    Friend WithEvents rbVideo As System.Windows.Forms.RadioButton
    Friend WithEvents lblAudioQuality As System.Windows.Forms.Label
    Friend WithEvents lblCustomArgs As System.Windows.Forms.Label
    Friend WithEvents txtArgs As System.Windows.Forms.TextBox
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents cbQuality As System.Windows.Forms.ComboBox
    Friend WithEvents lblAudioFormat As System.Windows.Forms.Label
    Friend WithEvents cbFormat As System.Windows.Forms.ComboBox
    Friend WithEvents ProgramInfo As System.Windows.Forms.ToolTip
    Friend WithEvents MainTabs As System.Windows.Forms.TabControl
    Friend WithEvents tabDownload As System.Windows.Forms.TabPage
    Friend WithEvents tabConvert As System.Windows.Forms.TabPage
    Friend WithEvents btnBrowseConvSaveFile As System.Windows.Forms.Button
    Friend WithEvents btnBrowseConvFile As System.Windows.Forms.Button
    Friend WithEvents txtConvFile As System.Windows.Forms.TextBox
    Friend WithEvents lblFileToConvert As System.Windows.Forms.Label
    Friend WithEvents txtConvSave As System.Windows.Forms.TextBox
    Friend WithEvents lblSaveAs As System.Windows.Forms.Label
    Friend WithEvents chkSaveToMaster As System.Windows.Forms.CheckBox
    Friend WithEvents lblConvertAudioFormat As System.Windows.Forms.Label
    Friend WithEvents cbConvFormat As System.Windows.Forms.ComboBox
    Friend WithEvents cbConvQuality As System.Windows.Forms.ComboBox
    Friend WithEvents lblConvertAudioQuality As System.Windows.Forms.Label
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents TestButton As System.Windows.Forms.Button
    Friend WithEvents tabAbout As System.Windows.Forms.TabPage
    Friend WithEvents lblAbout As System.Windows.Forms.Label
    Friend WithEvents Truth As System.Windows.Forms.Label
    Friend WithEvents GithubLink As System.Windows.Forms.LinkLabel
    Friend WithEvents vers As System.Windows.Forms.Label
    Friend WithEvents btnOptions As System.Windows.Forms.Button

End Class
