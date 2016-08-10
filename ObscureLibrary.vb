Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class ObscureLibrary
End Class

Public Class ReadFromFile
    Private Function ReadLineFromFile(FileLocation As String, LineToRead As Integer)
        Dim FileContent As List(Of String) = New List(Of String)
        FileContent = File.ReadAllLines(FileLocation).ToList()

        Return ReadLine(LineToRead, FileContent)
    End Function
    Private Function ReadLine(WantedLine As Integer, LineList As List(Of String))
        Return LineList(WantedLine - 1)
    End Function
End Class

Public Class RegistryEditor
    'Do _NOT_ be evil with this.

    Public Sub New()
    End Sub

    Public Sub HKEY_CURRENT_USER_CreateKey(ByVal KeyName As String, ByVal KeyValueName As String, ByVal KeyValue As String)
        My.Computer.Registry.CurrentUser.CreateSubKey(KeyName)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" & KeyName, KeyValueName, KeyValue)
    End Sub
    Public Function HKEY_CURRENT_USER_ReadKey(ByVal KeyName As String, ByVal KeyValueName As String) As String
        Try
            Return My.Computer.Registry.GetValue("HKEY_CURRENT_USER\" & KeyName, KeyValueName, Nothing)
            Exit Function
        Catch ex As Exception
            MessageBox.Show("Cannot read the registry key." & vbCrLf & ex.ToString)
        End Try
        Return "Could not read key."
    End Function
    Public Sub HKEY_CURRENT_USER_ChangeKeyValue(ByVal KeyName As String, ByVal KeyValueName As String, ByVal KeyValue As String)
        'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\" & KeyName, KeyValueName, KeyValue)
        
    End Sub
    Public Sub HKEY_CURRENT_USER_DeleteKey(ByVal KeyName As String)
        My.Computer.Registry.CurrentUser.DeleteSubKey(KeyName)
    End Sub
    Public Sub HKEY_CURRENT_USER_DeleteKeyValue(ByVal KeyName As String)
        My.Computer.Registry.CurrentUser.DeleteValue(KeyName)
    End Sub
End Class

Public Class ErrorLogger
    Public Sub New()
    End Sub

    Public Sub LogError(ByVal Message As String, ByVal StackTrace As String, ByVal ErrorAt As String)

        If Not File.Exists(Application.StartupPath & "/error.log") Then
            File.Create(Application.StartupPath & "/error.log").Dispose()
        End If

        Dim FiSt As FileStream = New FileStream(Application.StartupPath & "/error.log", FileMode.Append, FileAccess.Write)
        Dim StWr = New StreamWriter(FiSt)
        StWr.Write("Error Message: " & Message & vbCrLf & vbCrLf)
        StWr.Write("Error At: " & ErrorAt & vbCrLf)
        StWr.Write("Stack Trace: " & StackTrace & vbCrLf)
        StWr.Write("Time of Error: " & DateTime.Now.ToString())
        StWr.Close()
        FiSt.Close()

    End Sub

End Class
