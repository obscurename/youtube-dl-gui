Imports System.Runtime.InteropServices
Imports System.Reflection

Public Class Main

    Dim LogError As New ErrorLogger
    Dim Registry As New RegistryEditor
    Dim INI As New IniFile(Application.StartupPath & "\Settings.ini")
    Dim IniReadOnly As Boolean
    Dim ConvertFileName As String
    Dim ConvertFilePath As String

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Private Sub TestButton_Click(sender As Object, e As EventArgs) Handles TestButton.Click
        MsgBox(Application.ExecutablePath)
        MessageBox.Show(AssemblyName.GetAssemblyName(Application.ExecutablePath).Version.ToString)
        MsgBox("-i " & "File" & " -ab " & cbConvQuality.Text & " " & ConvertFileName & "." & cbConvFormat.Text)
        MsgBox("-i """ & "File" & """ -ab " & cbConvQuality.Text & " " & txtConvSave.Text & "\" & ConvertFileName & "." & cbConvFormat.Text)
    End Sub

#Region "Registry Settings"
    Private Sub InitializeSettings()
        If Not Registry.HKEY_CURRENT_USER_ReadKey("Software\youtube-dl-gui\settingsinit", "True") Then
            CreateSettings()
        Else
            LoadSettings()
        End If
    End Sub
    Private Sub CreateSettings()
        Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "hoverurl", "True")
        Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "deleteexecutable", "False")
        Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "downloadlocation", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")
        Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "settingsinit", "True")
    End Sub
    Private Sub LoadSettings()
        Dim urlhovering As String = Registry.HKEY_CURRENT_USER_ReadKey("Software\youtube-dl-gui\", "hoverurl")
        Dim deleteyoutubedl As String = Registry.HKEY_CURRENT_USER_ReadKey("Software\youtube-dl-gui\", "deleteexecutable")
        Dim downloadlocation As String = Registry.HKEY_CURRENT_USER_ReadKey("Software\youtube-dl-gui\", "downloadpath")

        If urlhovering = "True" Then
            Settings.chkHoverURL.Checked = True
        ElseIf urlhovering = "False" Then
            Settings.chkHoverURL.Checked = False
        Else
            MessageBox.Show("Unable to read HoverURL settings from registry. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "hoverurl", "True")
            Settings.chkHoverURL.Checked = True
        End If

        If deleteyoutubedl = "True" Then
            Settings.chkDeleteExecutable.Checked = True
        ElseIf deleteyoutubedl = "False" Then
            Settings.chkDeleteExecutable.Checked = False
        Else
            MessageBox.Show("Unable to read DeleteExecutable settings from registry. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "deleteexecutable", "True")
            Settings.chkDeleteExecutable.Checked = True
        End If

        If Not downloadlocation = Nothing Then
            Settings.txtDownloadLocation.Text = downloadlocation
        Else
            MessageBox.Show("Unable to read DownloadLocation settings from registry. Reverting to default (" & Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads" & ").")
            Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "downloadpath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")
            Settings.txtDownloadLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads"
        End If
    End Sub
    Private Sub SaveSettings()
        If Settings.chkHoverURL.Checked Then
            Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "hoverurl", "True")
        Else
            Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "hoverurl", "False")
        End If

        If Settings.chkDeleteExecutable.Checked Then
            Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "deleteexecutable", "True")
        Else
            Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "deleteexecutable", "False")
        End If

        If Not Settings.txtDownloadLocation.Text = Nothing Then
            Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui\", "downloadlocation", Settings.txtDownloadLocation.Text)
        End If
    End Sub
#End Region
#Region "Ini File Settings"
    Private Sub InitIni()
        If Not System.IO.File.Exists(Application.StartupPath & "\Settings.ini") Then
            System.IO.File.Create(Application.StartupPath & "\Settings.ini").Dispose()
            CreateIniSettings()
            Settings.txtDownloadLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads"
        Else
            LoadIni()
        End If
    End Sub
    Private Sub CreateIniSettings()
        INI.WriteString("Settings", "HoverURL", "True")
        INI.WriteString("Settings", "AutoClearURL", "True")
        INI.WriteString("Settings", "DeleteExecutable", "False")
        INI.WriteString("Settings", "EnableAppUpdate", "False")
        INI.WriteInteger("Settings", "AppUpdateInterval", 1)
        INI.WriteString("Settings", "DownloadPath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")
    End Sub
    Private Sub LoadIni()
        If IniCheckForReadOnly() = True Then
            MessageBox.Show("The settings file is ReadOnly! I'm not able to change any settings within the program. The settings will not be changable until the file is not Read Only.", "youtube-dl GUI", MessageBoxButtons.OK, MessageBoxIcon.Error)
            IniReadOnly = True
        Else
            IniReadOnly = False
        End If

        Dim HoverURL As String = INI.GetString("Settings", "HoverURL", "True")
        Dim AutoClearURL As String = INI.GetString("Settings", "AutoClearURL", "True")
        Dim DeleteExecutable As String = INI.GetString("Settings", "DeleteExecutable", "False")
        Dim EnableAppUpdate As String = INI.GetString("Settings", "EnableAppUpdate", "False")
        Dim AppUpdateInterval As Integer = INI.GetInteger("Settings", "AppUpdateInterval", 1)
        Dim DownloadPath As String = INI.GetString("Settings", "DownloadPath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")

        If HoverURL = "True" Then
            Settings.chkHoverURL.Checked = True
        ElseIf HoverURL = "False" Then
            Settings.chkHoverURL.Checked = False
        Else
            'MessageBox.Show("Unable to get HoverURL setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            'INI.WriteString("Settings", "HoverURL", "True")
            'Settings.chkHoverURL.Checked = True
            If Not IniReadOnly = True Then
                Select Case MessageBox.Show("Unable to get setting for ""HoverURL"". Would you like to enable HoverURL? Cancel = Default (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNoCancel)
                    Case Windows.Forms.DialogResult.Yes
                        INI.WriteString("Settings", "HoverURL", "True")
                        Settings.chkHoverURL.Checked = True
                    Case Windows.Forms.DialogResult.No
                        INI.WriteString("Settings", "HoverURL", "False")
                        Settings.chkHoverURL.Checked = False
                    Case Windows.Forms.DialogResult.Cancel
                        INI.WriteString("Settings", "HoverURL", "True")
                        Settings.chkHoverURL.Checked = True
                End Select
            Else
                Settings.chkHoverURL.Checked = True
            End If
        End If

        If AutoClearURL = "True" Then
            Settings.chkAutoClearURL.Checked = True
        ElseIf AutoClearURL = "False" Then
            Settings.chkAutoClearURL.Checked = False
        Else
            'MessageBox.Show("Unable to get AutoClearURL setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            'INI.WriteString("Settings", "AutoClearURL", "True")
            'Settings.chkHoverURL.Checked = True
            If Not IniReadOnly = True Then
                Select Case MessageBox.Show("Unable to get setting for ""AutoClearURL"". Would you like to enable AutoClearURL? Cancel = Default (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNoCancel)
                    Case Windows.Forms.DialogResult.Yes
                        INI.WriteString("Settings", "AutoClearURL", "True")
                        Settings.chkAutoClearURL.Checked = True
                    Case Windows.Forms.DialogResult.No
                        INI.WriteString("Settings", "AutoClearURL", "False")
                        Settings.chkAutoClearURL.Checked = False
                    Case Windows.Forms.DialogResult.Cancel
                        INI.WriteString("Settings", "AutoClearURL", "True")
                        Settings.chkAutoClearURL.Checked = True
                End Select
            Else
                Settings.chkAutoClearURL.Checked = True
            End If
        End If

        If DeleteExecutable = "True" Then
            Settings.chkDeleteExecutable.Checked = True
        ElseIf DeleteExecutable = "False" Then
            Settings.chkDeleteExecutable.Checked = False
        Else
            'MessageBox.Show("Unable to get DeleteExecutable setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            'INI.WriteString("Settings", "DeleteExecutable", "False")
            'Settings.chkDeleteExecutable.Checked = False
            If Not IniReadOnly = True Then
                Select Case MessageBox.Show("Unable to get setting for ""DeleteExecutable"". Would you like to enable DeleteExecutable? Cancel = Default (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNoCancel)
                    Case Windows.Forms.DialogResult.Yes
                        INI.WriteString("Settings", "DeleteExecutable", "True")
                        Settings.chkDeleteExecutable.Checked = True
                    Case Windows.Forms.DialogResult.No
                        INI.WriteString("Settings", "DeleteExecutable", "False")
                        Settings.chkDeleteExecutable.Checked = False
                    Case Windows.Forms.DialogResult.Cancel
                        INI.WriteString("Settings", "DeleteExecutable", "False")
                        Settings.chkDeleteExecutable.Checked = False
                End Select
            Else
                Settings.chkDeleteExecutable.Checked = False
            End If
        End If

        If Not DownloadPath = Nothing Then
            Settings.txtDownloadLocation.Text = DownloadPath
        Else
            'MessageBox.Show("Unable to get DownloadPath setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            'INI.WriteString("Settings", "DownloadPath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")
            'Settings.chkDeleteExecutable.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads"
            If Not IniReadOnly = True Then
                Select Case MessageBox.Show("Unable to get setting for ""DownloadPath"". Would you like to configure a custom download path? If not, the default will be used. (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNo)
                    Case Windows.Forms.DialogResult.Yes
                        Dim FBD As New FolderBrowserDialog With {.Description = "Saving downloaded files to...", .RootFolder = Environment.SpecialFolder.UserProfile}
                        Select Case FBD.ShowDialog
                            Case Windows.Forms.DialogResult.OK
                                INI.WriteString("Settings", "DownloadPath", FBD.SelectedPath)
                                Settings.txtDownloadLocation.Text = FBD.SelectedPath
                        End Select
                    Case Windows.Forms.DialogResult.No
                        INI.WriteString("Settings", "DownloadPath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")
                        Settings.chkDeleteExecutable.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads"
                End Select
            Else
                Settings.chkDeleteExecutable.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads"
            End If
        End If
    End Sub
    Private Sub SaveIni()
        If Settings.chkHoverURL.Checked Then
            INI.WriteString("Settings", "HoverURL", "True")
        Else
            INI.WriteString("Settings", "HoverURL", "False")
        End If

        If Settings.chkDeleteExecutable.Checked Then
            INI.WriteString("Settings", "DeleteExecutable", "True")
        Else
            INI.WriteString("Settings", "DeleteExecutable", "False")
        End If

        If Not Settings.txtDownloadLocation.Text = Nothing Then
            INI.WriteString("Settings", "DownloadPath", Settings.txtDownloadLocation.Text)
        End If
    End Sub
    Private Function IniCheckForReadOnly()
        If GetAttr(INI.FileName) And vbReadOnly Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'InitializeSettings()
        InitIni()
        If Not My.Computer.Network.IsAvailable Then
            Select Case MessageBox.Show("youtube-dl may not work. Continue?", "No internet connection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case Windows.Forms.DialogResult.No
                    Application.Exit()
                    Exit Sub
            End Select
        End If
        If Not System.IO.File.Exists(Application.StartupPath & "/youtube-dl.exe") Then
            Try
                Dim YDVersion As String = GetVersionFromHTML()
                Dim YDUrl As String = "https://yt-dl.org/downloads/" & YDVersion & "/youtube-dl.exe"
                'My.Computer.Network.DownloadFile(YDUrl, Application.StartupPath & "/youtube-dl.exe")
                Dim WC As System.Net.WebClient = New Net.WebClient
                WC.DownloadFile(YDUrl, Application.StartupPath & "/youtube-dl.exe")

            Catch ex As Exception
                LogError.LogError(ex.ToString, ex.StackTrace, "Downloading youtube-dl binary file")
                Select Case MessageBox.Show("An error has occured. Log ""Error.log"" has been created/edited. Do you want to view the error?", "An error occured", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                    Case Windows.Forms.DialogResult.Yes
                        MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                End Select
                Application.Exit()
            End Try
        End If

        SendMessage(Me.txtURL.Handle, &H1501, 0, "URL goes here")
    End Sub
    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnDownload.Focus()
            StartDownload(txtURL.Text, txtArgs.Text)
        End If
    End Sub
    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim GetAppVers As String = My.Application.Info.Version.ToString.Replace(".0", "")
        vers.Text = "v" & GetAppVers

        btnDownload.Focus()
    End Sub
    Private Sub ArgChecker()
        For Each arg As String In My.Application.CommandLineArgs
            Select Case LTrim(LCase(arg))
                Case Not ""
                    Try
                        StartDownload(LTrim(LCase(arg)), Nothing)
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
            End Select
        Next
    End Sub
    Private Function GetVersionFromHTML() As String
        Dim URL As String = "https://rg3.github.io/youtube-dl/download.html"
        Dim DownloadedHTML As New RichTextBox With {.Text = New Net.WebClient().DownloadString(URL)}
        Dim SourceTrim As String = ReadLine(19, DownloadedHTML.Lines.ToList())
        'MsgBox(SourceTrim)
        Dim ExtractVersion As String = SourceTrim.Substring(41, SourceTrim.Length - 147)
        'MsgBox(ExtractVersion)
        Return ExtractVersion
    End Function
    Private Function ReadLine(WantedLine As Integer, LineList As List(Of String))
        Return LineList(WantedLine - 1)
    End Function

#Region "Downloader"
    Private Sub txtURL_MouseEnter(sender As Object, e As EventArgs) Handles txtURL.MouseEnter
        If Settings.chkHoverURL.Checked Then
            If Clipboard.ContainsText Then
                If Not Clipboard.GetText = Nothing Then
                    If Not Clipboard.GetText = txtURL.Text Then
                        txtURL.Clear()
                        txtURL.Text = Clipboard.GetText
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.TextChanged
        If Not txtURL.Text.Contains("youtube.com/watch?v=") Then
            gbDownloadAs.Enabled = False
            rbVideo.Checked = True
        Else
            gbDownloadAs.Enabled = True
        End If
    End Sub
    Public Sub StartDownload(ByVal URL As String, ByVal Args As String)

        Dim OutputFolder As String = "-o " & Settings.txtDownloadLocation.Text & "/%(title)s-%(id)s.%(ext)s "

        If txtURL.Text = Nothing Then
            MessageBox.Show("Please enter a URL before attempting to download a video.", "Cannot download nothing.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim Downloader As New Process
        Downloader.StartInfo.FileName = Application.StartupPath & "/youtube-dl.exe"

        If rbVideo.Checked Then
            Downloader.StartInfo.Arguments = OutputFolder & """" & URL & """"
        ElseIf rbAudio.Checked Then
            Downloader.StartInfo.Arguments = OutputFolder & "-x --audio-format " & cbFormat.SelectedItem & " --audio-quality " & cbQuality.SelectedItem & " " & """" & URL & """"
        ElseIf rbCustom.Checked Then
            Downloader.StartInfo.Arguments = Args & " """ & URL & """"
        End If

        Downloader.StartInfo.UseShellExecute = False
        'Downloader.StartInfo.RedirectStandardOutput = True
        Downloader.StartInfo.CreateNoWindow = False
        Downloader.Start()

        'Dim DownloaderOutput As String = Downloader.StandardOutput.ReadToEnd
        'Output.RichTextBox1.Text = DownloaderOutput
        'Output.Show()

        'Downloader.Dispose()

    End Sub

    Private Sub rbVideo_CheckedChanged(sender As Object, e As EventArgs) Handles rbVideo.CheckedChanged
        If Not rbCustom.Checked Then
            txtArgs.ReadOnly = True
            cbQuality.Enabled = False
            cbFormat.Enabled = False
            cbQuality.Text = ""
            cbFormat.Text = ""
        End If
    End Sub
    Private Sub rbAudio_CheckedChanged(sender As Object, e As EventArgs) Handles rbAudio.CheckedChanged
        If Not rbCustom.Checked Then
            txtArgs.ReadOnly = True
            cbQuality.Enabled = True
            cbFormat.Enabled = True
            cbQuality.Text = "256K"
            cbFormat.Text = "mp3"
        End If
    End Sub
    Private Sub rbCustom_CheckedChanged(sender As Object, e As EventArgs) Handles rbCustom.CheckedChanged
        If rbCustom.Checked Then
            txtArgs.ReadOnly = False
            cbQuality.Enabled = False
            cbFormat.Enabled = False
            cbQuality.Text = ""
            cbFormat.Text = ""
        End If
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        StartDownload(txtURL.Text, txtArgs.Text)
        txtURL.Text = Nothing
        gbDownloadAs.Enabled = False
    End Sub
    Private Sub LinkHelp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkHelp.LinkClicked
        Process.Start("https://github.com/rg3/youtube-dl/blob/master/README.md")
    End Sub
#End Region
#Region "Converter"
    Private Sub ConvertFile(ByVal FileInput As String)
        Dim Converter As New Process
        Converter.StartInfo.FileName = "ffmpeg.exe"
        If chkSaveToMaster.Checked Then
            Converter.StartInfo.Arguments = "-i """ & FileInput & """ -ab " & cbConvQuality.Text & " """ & ConvertFilePath & "\" & ConvertFileName & "." & cbConvFormat.Text & """"
        Else
            Converter.StartInfo.Arguments = "-i """ & FileInput & """ -ab " & cbConvQuality.Text & " """ & txtConvSave.Text & "\" & ConvertFileName & "." & cbConvFormat.Text & """"
        End If
        Converter.StartInfo.UseShellExecute = False
        Converter.StartInfo.CreateNoWindow = False
        Converter.Start()

        If chkSaveToMaster.Checked Then
            'Process.Start("ffmpeg.exe", "-b " & cbConvQuality.Text & " -i " & FileInput & " " & ConvertFileName & "." & cbConvFormat.Text)
            'Process.Start("ffmpeg.exe", "-i " & FileInput & " -ab " & cbConvQuality.Text & " " & ConvertFileName & "." & cbConvFormat.Text)
        Else
            'Process.Start("ffmpeg.exe", "-b " & cbConvQuality.Text & " -i " & FileInput & " " & txtConvSave.Text & "\" & ConvertFileName & "." & cbConvFormat.Text)
            'Process.Start("ffmpeg.exe", "-i """ & FileInput & """ -ab " & cbConvQuality.Text & " " & txtConvSave.Text & "\" & ConvertFileName & "." & cbConvFormat.Text)
        End If
    End Sub
    Private Sub chkSaveToMaster_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaveToMaster.CheckedChanged
        If chkSaveToMaster.Checked Then
            btnBrowseConvSaveFile.Enabled = False
            txtConvSave.Enabled = False
        Else
            btnBrowseConvSaveFile.Enabled = True
            txtConvSave.Enabled = True
        End If
    End Sub
    Private Sub btnBrowseConvFile_Click(sender As Object, e As EventArgs) Handles btnBrowseConvFile.Click
        Dim OFD As New OpenFileDialog With {.Title = "Select file to convert", .Filter = "Video Files (*.mp4, *.avi, *.flv, *.mkv, *.webm)|*.mp4;*.avi;*.flv;*.mkv;*.webm|Audio Files (*.mp3, *.m4a, *.wav, *.oog, *.flac)|*.mp3;*.m4a;*.wav;*.oog;*.flac"}
        Select Case OFD.ShowDialog
            Case Windows.Forms.DialogResult.OK
                txtConvFile.Text = OFD.FileName
                ConvertFileName = System.IO.Path.GetFileNameWithoutExtension(OFD.FileName)
                Dim FileInfo As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(OFD.FileName)
                If chkSaveToMaster.Checked Then
                    ConvertFilePath = FileInfo.DirectoryName
                Else
                    txtConvSave.Text = FileInfo.DirectoryName 'Temporary!
                End If
                btnConvert.Enabled = True
        End Select
    End Sub
    Private Sub btnBrowseConvSaveFile_Click(sender As Object, e As EventArgs) Handles btnBrowseConvSaveFile.Click
        Dim FBD As New FolderBrowserDialog With {.Description = "Select a folder to save conversions at"}
        Select Case FBD.ShowDialog
            Case Windows.Forms.DialogResult.OK
                txtConvSave.Text = FBD.SelectedPath
        End Select
    End Sub
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        If txtConvFile.Text = Nothing Then
            MessageBox.Show("You need to select a file to convert.", "youtube-dl GUI", MessageBoxButtons.OK)
            Exit Sub
        End If
        ConvertFile(txtConvFile.Text)
    End Sub
#End Region
#Region "About"
    Private Sub lblAbout_MouseEnter(sender As Object, e As EventArgs) Handles lblAbout.MouseEnter
        Truth.Show()
    End Sub
    Private Sub lblAbout_MouseLeave(sender As Object, e As EventArgs) Handles lblAbout.MouseLeave
        Truth.Hide()
    End Sub
    Private Sub GithubLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GithubLink.LinkClicked
        Process.Start("https://github.com/obscurename/youtube-dl-gui")
    End Sub
    Private Sub btnOptions_Click(sender As Object, e As EventArgs) Handles btnOptions.Click
Retry:
        If IniReadOnly = True Then
            Select Case MessageBox.Show("You cannot edit the settings while the file is ReadOnly.", "youtube-dl GUI", MessageBoxButtons.RetryCancel)
                Case Windows.Forms.DialogResult.Retry
                    GoTo Retry
            End Select
        Else

        End If
    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.IO.File.Delete(Application.StartupPath & "/youtube-dl.exe")

        Try
            Dim YDVersion As String = GetVersionFromHTML()
            Dim YDUrl As String = "https://yt-dl.org/downloads/" & YDVersion & "/youtube-dl.exe"
            'My.Computer.Network.DownloadFile(YDUrl, Application.StartupPath & "/youtube-dl.exe")
            Dim WC As System.Net.WebClient = New Net.WebClient
            WC.DownloadFile(YDUrl, Application.StartupPath & "/youtube-dl.exe")

        Catch ex As Exception
            LogError.LogError(ex.ToString, ex.StackTrace, "Downloading youtube-dl binary file")
            Select Case MessageBox.Show("An error has occured. Log ""Error.log"" has been created/edited. Do you want to view the error?", "An error occured", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                Case Windows.Forms.DialogResult.Yes
                    MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            End Select
            Application.Exit()
        End Try
    End Sub
End Class
