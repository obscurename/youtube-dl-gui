Public Class Updater

    Dim YoutubeDLGUIPresent As Boolean = False
    Dim DLCustomName As Boolean = False
    Dim URL As String
    Dim DownloadedHTML As New RichTextBox
    Dim CurrentVersion As String
    Dim UpdatedVersion As String
    Dim DownloadURL As String

    Dim ChangeLogSize As New Size(275, 253)
    Dim OriginalSize As New Size(275, 90)

    Private Sub Updater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(Application.StartupPath & "/youtube-dl-gui.exe") Then
            YoutubeDLGUIPresent = True
        Else
            YoutubeDLGUIPresent = False
        End If

        If My.Computer.Network.IsAvailable = False Then
            Select Case MessageBox.Show("The internet is not available on this machine. Continue anyways?", "Disconnected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case Windows.Forms.DialogResult.No
                    Application.Exit()
            End Select
        End If

        If YoutubeDLGUIPresent = True Then
            Try
                GetUpdateInformation()
                CheckVersion()

                CurrentVersion = System.Reflection.AssemblyName.GetAssemblyName(Application.StartupPath & "\youtube-dl-gui.exe").Version.ToString

                If CurrentVersion = UpdatedVersion Then
                    MessageBox.Show("youtube-dl-gui is currently up to date.", "Up to date.", MessageBoxButtons.OK)
                    Application.Exit()
                End If

                lblVersion.Text = "The following version will be installed: " & UpdatedVersion
            Catch ex As Exception
                MessageBox.Show("An error occured. Please send the next dialogue to the developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.ToString)
            End Try
        Else
            lblVersion.Text = "Youtube-dl-gui will be downloaded to this directory."
        End If
    End Sub
    Private Sub Updater_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If YoutubeDLGUIPresent = True Then
            Me.Size = ChangeLogSize
        Else
            Me.Size = OriginalSize
        End If
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If My.Computer.Network.IsAvailable = False Then
            Select Case MessageBox.Show("The internet is not available on this machine. Continue anyways?", "Disconnected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If

        UpdateApp()
    End Sub

    Private Sub CheckVersion()
        If DLCustomName = False Then
            CurrentVersion = System.Reflection.AssemblyName.GetAssemblyName(Application.StartupPath & "\youtube-dl-gui.exe").Version.ToString

            If CurrentVersion = UpdatedVersion Then
                MessageBox.Show("youtube-dl-gui is currently up to date.", "Up to date", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.Exit()
            Else
                MessageBox.Show("An update is available.", "Update available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                rtbChangeLog.Text = New Net.WebClient().DownloadString("https://raw.githubusercontent.com/obscurename/youtube-dl-gui/master/CurrentVersionChangelog")
            End If
        End If
    End Sub
    Private Sub UpdateApp()
        Try
            Dim WC As System.Net.WebClient = New Net.WebClient
            If System.IO.File.Exists(Application.StartupPath & "/youtube-dl-gui.exe") Then
                System.IO.File.Delete(Application.StartupPath & "/youtube-dl-gui.exe")
            End If
            WC.DownloadFile(DownloadURL, Application.StartupPath & "/youtube-dl-gui.exe")
            If YoutubeDLGUIPresent = False Then
                MessageBox.Show("youtube-dl-gui successfully downloaded. Now closing.", "Download finished.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("youtube-dl-gui successfully updated. Now closing.", "Update finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show("An error occured. Please send the next dialogue to the developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub GetUpdateInformation()
        URL = "https://raw.githubusercontent.com/obscurename/youtube-dl-gui/master/UpdaterInformation"
        DownloadedHTML.Text = New Net.WebClient().DownloadString(URL)
        UpdatedVersion = ReadLine(1, DownloadedHTML.Lines.ToList())
        DownloadURL = ReadLine(2, DownloadedHTML.Lines.ToList())
    End Sub
    Private Function ReadLine(WantedLine As Integer, LineList As List(Of String))
        Return LineList(WantedLine - 1)
    End Function


End Class
