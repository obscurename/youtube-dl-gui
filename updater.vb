Public Class Updater
    Dim YoutubeDLGUIPresent As Boolean = False
    Dim URL As String
    Dim DownloadedHTML As New RichTextBox
    Dim UpdatedVersion As String
    Dim DownloadURL As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(Application.StartupPath & "/youtube-dl-gui.exe") Then
            YoutubeDLGUIPresent = True
        End If

        If Not My.Computer.Network.IsAvailable = False Then
            Select Case MessageBox.Show("The internet is not available on this machine. Continue anyways?", "Disconnected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If

        Try
            If YoutubeDLGUIPresent = True Then
                lblVersion.Text = "The following version will be installed: " & GetVersionFromHTML()
            Else
                lblVersion.Text = "Youtube-dl-gui will be downloaded to this directory."
            End If
        Catch ex As Exception
            MessageBox.Show("An error occured. Please send the next dialogue to the developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        If Not My.Computer.Network.IsAvailable = False Then
            Select Case MessageBox.Show("The internet is not available on this machine. Continue anyways?", "Disconnected", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If

        Try
            Dim WC As System.Net.WebClient = New Net.WebClient
            WC.DownloadFile(DownloadURL, Application.StartupPath & "/youtube-dl-gui.exe")
            MessageBox.Show("youtube-dl-gui successfully updated. Now closing.", "Update finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show("An error occured. Please send the next dialogue to the developer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function GetVersionFromHTML() As String
        URL = "https://raw.githubusercontent.com/obscurename/youtube-dl-gui/master/UpdaterInformation"
        DownloadedHTML.Text = New Net.WebClient().DownloadString(URL)
        UpdatedVersion = ReadLine(1, DownloadedHTML.Lines.ToList())
        DownloadURL = ReadLine(2, DownloadedHTML.Lines.ToList())
        Return UpdatedVersion
    End Function
    Private Function ReadLine(WantedLine As Integer, LineList As List(Of String))
        Return LineList(WantedLine - 1)
    End Function
End Class
