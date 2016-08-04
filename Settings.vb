Public Class Settings
    Dim Registry As RegistryEditor
    Dim INI As New IniFile(Application.StartupPath & "\Settings.ini")

    Private Sub LoadIni()
        Dim HoverURL As String = INI.GetString("Settings", "HoverURL", "True")
        Dim DeleteExecutable As String = INI.GetString("Settings", "DeleteExecutable", "False")
        Dim EnableAppUpdate As String = INI.GetString("Settings", "EnableAppUpdate", "False")
        Dim AppUpdateInterval As Integer = INI.GetInteger("Settings", "AppUpdateInterval", 1)
        Dim DownloadPath As String = INI.GetString("Settings", "DownloadPath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")

        If HoverURL = "True" Then
            chkHoverURL.Checked = True
        ElseIf HoverURL = "False" Then
            chkHoverURL.Checked = False
        Else
            MessageBox.Show("Unable to get HoverURL setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            INI.WriteString("Settings", "HoverURL", "True")
            chkHoverURL.Checked = True
        End If

        If DeleteExecutable = "True" Then
            chkDeleteExecutable.Checked = True
        ElseIf DeleteExecutable = "False" Then
            chkDeleteExecutable.Checked = False
        Else
            MessageBox.Show("Unable to get DeleteExecutable setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            INI.WriteString("Settings", "DeleteExecutable", "True")
            chkDeleteExecutable.Checked = False
        End If

        If Not DownloadPath = Nothing Then
            txtDownloadLocation.Text = DownloadPath
        Else
            MessageBox.Show("Unable to get DownloadPath setting. Reverting to default.", "youtube-dl GUI", MessageBoxButtons.OK)
            INI.WriteString("Settings", "DownloadPath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads")
            chkDeleteExecutable.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Downloads"
        End If
    End Sub

    Private Sub btnBrws_Click(sender As Object, e As EventArgs) Handles btnBrws.Click
        Dim FBD As New FolderBrowserDialog With {.Description = "Saving downloaded files to...", .RootFolder = Environment.SpecialFolder.UserProfile}
        Select Case FBD.ShowDialog
            Case Windows.Forms.DialogResult.OK
                txtDownloadLocation.Text = FBD.SelectedPath
                'Registry.HKEY_CURRENT_USER_CreateKey("Software\youtube-dl-gui", "downloadlocation", FBD.SelectedPath)
                INI.WriteString("Settings", "DownloadPath", FBD.SelectedPath)
        End Select
    End Sub
    Private Sub chkHoverURL_CheckedChanged(sender As Object, e As EventArgs) Handles chkHoverURL.CheckedChanged
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
    Private Sub chkDeleteExecutable_CheckedChanged(sender As Object, e As EventArgs) Handles chkDeleteExecutable.CheckedChanged
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
    Private Sub Settings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadIni()
    End Sub
End Class