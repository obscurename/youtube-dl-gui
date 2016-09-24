Public Class Settings
    Dim Registry As RegistryEditor
    Dim INI As New IniFile(Application.StartupPath & "\Settings.ini")
    Dim IniReadOnly As Boolean

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

        Select Case MessageBox.Show("Unable to get setting for ""HoverURL"". Would you like to enable HoverURL? Cancel = Default (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNoCancel)
            Case Windows.Forms.DialogResult.Yes
                INI.WriteString("Settings", "HoverURL", "True")
                chkHoverURL.Checked = True
            Case Windows.Forms.DialogResult.No
                INI.WriteString("Settings", "HoverURL", "False")
                chkHoverURL.Checked = False
            Case Windows.Forms.DialogResult.Cancel
                INI.WriteString("Settings", "HoverURL", "True")
                chkHoverURL.Checked = True
        End Select

        If HoverURL = "True" Then
            chkHoverURL.Checked = True
        ElseIf HoverURL = "False" Then
            chkHoverURL.Checked = False
        Else
            'MessageBox.Show("Unable to get HoverURL setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            'INI.WriteString("Settings", "HoverURL", "True")
            'chkHoverURL.Checked = True
            Select Case MessageBox.Show("Unable to get setting for ""HoverURL"". Would you like to enable HoverURL? Cancel = Default (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNoCancel)
                Case Windows.Forms.DialogResult.Yes
                    INI.WriteString("Settings", "HoverURL", "True")
                    chkHoverURL.Checked = True
                Case Windows.Forms.DialogResult.No
                    INI.WriteString("Settings", "HoverURL", "False")
                    chkHoverURL.Checked = False
                Case Windows.Forms.DialogResult.Cancel
                    INI.WriteString("Settings", "HoverURL", "True")
                    chkHoverURL.Checked = True
            End Select
        End If

        If AutoClearURL = "True" Then
            chkAutoClearURL.Checked = True
        ElseIf AutoClearURL = "False" Then
            chkAutoClearURL.Checked = False
        Else
            'MessageBox.Show("Unable to get AutoClearURL setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            'INI.WriteString("Settings", "AutoClearURL", "True")
            'chkHoverURL.Checked = True
            Select Case MessageBox.Show("Unable to get setting for ""AutoClearURL"". Would you like to enable AutoClearURL? Cancel = Default (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNoCancel)
                Case Windows.Forms.DialogResult.Yes
                    INI.WriteString("Settings", "AutoClearURL", "True")
                    chkAutoClearURL.Checked = True
                Case Windows.Forms.DialogResult.No
                    INI.WriteString("Settings", "AutoClearURL", "False")
                    chkAutoClearURL.Checked = False
                Case Windows.Forms.DialogResult.Cancel
                    INI.WriteString("Settings", "AutoClearURL", "True")
                    chkAutoClearURL.Checked = True
            End Select
        End If

        If DeleteExecutable = "True" Then
            chkDeleteExecutable.Checked = True
        ElseIf DeleteExecutable = "False" Then
            chkDeleteExecutable.Checked = False
        Else
            'MessageBox.Show("Unable to get DeleteExecutable setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            'INI.WriteString("Settings", "DeleteExecutable", "False")
            'chkDeleteExecutable.Checked = False
            Select Case MessageBox.Show("Unable to get setting for ""DeleteExecutable"". Would you like to enable DeleteExecutable? Cancel = Default (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNoCancel)
                Case Windows.Forms.DialogResult.Yes
                    INI.WriteString("Settings", "DeleteExecutable", "True")
                    chkDeleteExecutable.Checked = True
                Case Windows.Forms.DialogResult.No
                    INI.WriteString("Settings", "DeleteExecutable", "False")
                    chkDeleteExecutable.Checked = False
                Case Windows.Forms.DialogResult.Cancel
                    INI.WriteString("Settings", "DeleteExecutable", "False")
                    chkDeleteExecutable.Checked = False
            End Select
        End If

        If Not DownloadPath = Nothing Then
            txtDownloadLocation.Text = DownloadPath
        Else
            'MessageBox.Show("Unable to get DownloadPath setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            'INI.WriteString("Settings", "DownloadPath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")
            'chkDeleteExecutable.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads"
            Select Case MessageBox.Show("Unable to get setting for ""DownloadPath"". Would you like to configure a custom download path? If not, the default will be used. (Your choice here will overwrite the setting within the settings file!)", "youtube-dl GUI", MessageBoxButtons.YesNo)
                Case Windows.Forms.DialogResult.Yes
                    Dim FBD As New FolderBrowserDialog With {.Description = "Saving downloaded files to...", .RootFolder = Environment.SpecialFolder.UserProfile}
                    Select Case FBD.ShowDialog
                        Case Windows.Forms.DialogResult.OK
                            INI.WriteString("Settings", "DownloadPath", FBD.SelectedPath)
                            txtDownloadLocation.Text = FBD.SelectedPath
                    End Select
                Case Windows.Forms.DialogResult.No
                    INI.WriteString("Settings", "DownloadPath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")
                    chkDeleteExecutable.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads"
            End Select
        End If
    End Sub
    Private Function IniCheckForReadOnly()
        If GetAttr(INI.FileName) And vbReadOnly Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Settings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadIni()
    End Sub

    Private Sub btnBrws_Click(sender As Object, e As EventArgs) Handles btnBrws.Click
Retry:
        If IniReadOnly = True Then
            Select Case MessageBox.Show("Cannot change the setting while the IniFile is ReadOnly.", "youtube-dl GUI", MessageBoxButtons.RetryCancel)
                Case Windows.Forms.DialogResult.Retry
                    GoTo Retry
            End Select
            Exit Sub
        End If

        Dim FBD As New FolderBrowserDialog With {.Description = "Saving downloaded files to...", .RootFolder = Environment.SpecialFolder.UserProfile}
        Select Case FBD.ShowDialog
            Case Windows.Forms.DialogResult.OK
                txtDownloadLocation.Text = FBD.SelectedPath
                'Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui", "downloadlocation", FBD.SelectedPath)
                INI.WriteString("Settings", "DownloadPath", FBD.SelectedPath)
        End Select
    End Sub
    Private Sub chkHoverURL_CheckedChanged(sender As Object, e As EventArgs) Handles chkHoverURL.CheckedChanged
Retry:
        If IniReadOnly = True Then
            Select Case MessageBox.Show("Cannot change the setting while the IniFile is ReadOnly.", "youtube-dl GUI", MessageBoxButtons.RetryCancel)
                Case Windows.Forms.DialogResult.Retry
                    GoTo Retry
            End Select
            Exit Sub
        End If
        'If chkHoverURL.Checked Then
        '    'Registry.HKEY_CURRENT_USER_ChangeKeyValue("Software\youtube-dl-gui", "hoverurl", "True")
        '    Dim RegKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\youtube_dl_gui\", True)
        '    RegKey.SetValue("hoverurl", "True")
        '    RegKey.Close()
        'Else
        '    'Registry.HKEY_CURRENT_USER_ChangeKeyValue("Software\youtube-dl-gui", "hoverurl", "False")
        'End If
        If chkHoverURL.Checked Then
            INI.WriteString("Settings", "HoverURL", "True")
        Else
            INI.WriteString("Settings", "HoverURL", "False")
        End If
    End Sub
    Private Sub chkAutoClearURL_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoClearURL.CheckedChanged
Retry:
        If IniReadOnly = True Then
            Select Case MessageBox.Show("Cannot change the setting while the IniFile is ReadOnly.", "youtube-dl GUI", MessageBoxButtons.RetryCancel)
                Case Windows.Forms.DialogResult.Retry
                    GoTo Retry
            End Select
            Exit Sub
        End If
        If chkAutoClearURL.Checked Then
            INI.WriteString("Settings", "AutoClearURL", "True")
        Else
            INI.WriteString("Settings", "AutoClearURL", "False")
        End If
    End Sub
    Private Sub chkDeleteExecutable_CheckedChanged(sender As Object, e As EventArgs) Handles chkDeleteExecutable.CheckedChanged
Retry:
        If IniReadOnly = True Then
            Select Case MessageBox.Show("Cannot change the setting while the IniFile is ReadOnly.", "youtube-dl GUI", MessageBoxButtons.RetryCancel)
                Case Windows.Forms.DialogResult.Retry
                    GoTo Retry
            End Select
            Exit Sub
        End If
        'If chkDeleteExecutable.Checked Then
        '    Registry.HKEY_CURRENT_USER_ChangeKeyValue("Software\youtube-dl-gui", "deleteexecutable", "True")
        'Else
        '    Registry.HKEY_CURRENT_USER_ChangeKeyValue("Software\youtube-dl-gui", "deleteexecutable", "False")
        'End If
        If chkDeleteExecutable.Checked Then
            INI.WriteString("Settings", "DeleteExecutable", "True")
        Else
            INI.WriteString("Settings", "DeleteExecutable", "False")
        End If
    End Sub
End Class