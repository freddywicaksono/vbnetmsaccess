Imports System.Data.OleDb
Public Class Connection
    Private _filepath As String
    Private _connected As Boolean = False

    Public Property DataSource()
        Get
            Return _filepath
        End Get
        Set(ByVal value)
            _filepath = value
        End Set
    End Property


    ''' <summary>
    ''' Proses menyambungkan koneksi 
    ''' </summary>
    Public Sub Connect()
        Try
            conn.Close()
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0" & _
                           ";Data Source=" & _filepath & ";" & _
                           "Persist Security Info=False;"

            conn.Open()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            If (conn.State = True) Then
                _connected = True
            Else
                _connected = False
            End If
        End Try
    End Sub

    ''' <summary>
    ''' Proses memutuskan koneksi
    ''' </summary>
    Public Sub Disconnect()
        If (conn.State = True) Then
            conn.Close()
            conn.Dispose()
            _connected = False
        End If
    End Sub

End Class
