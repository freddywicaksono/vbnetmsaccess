Imports System.Data.OleDb
Module MyMod
    Public mycommand As New System.Data.OleDb.OleDbCommand
    Public myadapter As New System.Data.OleDb.OleDbDataAdapter
    Public mydata As New DataTable
    Public DR As System.Data.OleDb.OleDbDataReader
    Public SQL As String
    Public conn As New OleDbConnection
    Public cn As New Connection

    'Tabel Fakultas
    '-------------------------------
    Public fakultas_baru As Boolean
    Public ofakultas As New Fakultas
    '--------------------------------

    Public Sub DBConnect()
        cn.DataSource = "C:\Users\UMC-LN-03\Documents\umc.accdb"

        cn.Connect()
    End Sub

    Public Sub DBDisconnect()
        cn.Disconnect()
    End Sub
End Module
