Public Class Fakultas
    Dim strsql As String
    Dim info As String
    Private _idfk As Integer
    Private _kode_fakultas As String
    Private _nama_fakultas As String
    Public InsertState As Boolean = False
    Public UpdateState As Boolean = False
    Public DeleteState As Boolean = False

    Public Property kode_fakultas()
        Get
            Return _kode_fakultas
        End Get
        Set(ByVal value)
            _kode_fakultas = value
        End Set
    End Property

    Public Property nama_fakultas()
        Get
            Return _nama_fakultas
        End Get
        Set(ByVal value)
            _nama_fakultas = value
        End Set
    End Property

    Public Sub Simpan()
        DBConnect()
        If (fakultas_baru = True) Then
            strsql = "insert into fakultas(kode_fakultas,nama_fakultas) values ('" & _kode_fakultas & "','" & _nama_fakultas & "')"
            info = "INSERT"
        Else
            strsql = "update fakultas set kode_fakultas='" & _kode_fakultas & "', nama_fakultas='" & _nama_fakultas & "' where kode_fakultas='" & _kode_fakultas & "'"
            info = "UPDATE"
        End If
        mycommand.Connection = conn
        mycommand.CommandText = strsql

        Try
            mycommand.ExecuteNonQuery()
        Catch ex As Exception
            If (info = "INSERT") Then
                InsertState = False
            ElseIf (info = "UPDATE") Then
                UpdateState = False
            Else

            End If
        Finally
            If (info = "INSERT") Then
                InsertState = True
            ElseIf (info = "UPDATE") Then
                UpdateState = True
            Else

            End If
        End Try
        DBDisconnect()
    End Sub

    Public Sub CariFakultas(ByVal skode_fakultas As String)
        DBConnect()
        strsql = "select * from fakultas where kode_fakultas='" & skode_fakultas & "'"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        Try
            DR = mycommand.ExecuteReader
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        If (DR.HasRows = True) Then
            fakultas_baru = False
            DR.Read()
            kode_fakultas = Convert.ToString((DR("kode_fakultas")))
            nama_fakultas = Convert.ToString((DR("nama_fakultas")))
        Else
            fakultas_baru = True
        End If
        DBDisconnect()
    End Sub

    Public Sub Hapus(ByVal skode_fakultas As String)
        DBConnect()
        strsql = "delete from fakultas where kode_fakultas='" & skode_fakultas & "'"
        info = "DELETE"
        mycommand.Connection = conn
        mycommand.CommandText = strsql
        Try
            mycommand.ExecuteNonQuery()
            DeleteState = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
        DBDisconnect()
    End Sub

    Public Sub GetAllData(ByVal dg As DataGridView)
        Try
            DBConnect()
            strsql = "select * from fakultas"
            mycommand.Connection = conn
            mycommand.CommandText = strsql
            mydata.Clear()
            myadapter.SelectCommand = mycommand
            myadapter.Fill(mydata)
            With dg
                .DataSource = mydata
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            DBDisconnect()
        End Try
    End Sub


End Class
