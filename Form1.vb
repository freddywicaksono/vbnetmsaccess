Public Class Form1
    Private Sub TampilFakultas()
        txtkode_fakultas.Text = ofakultas.kode_fakultas
        txtnama_fakultas.Text = ofakultas.nama_fakultas
    End Sub

    Private Sub SimpanDataFakultas()
        ofakultas.kode_fakultas = txtkode_fakultas.Text
        ofakultas.nama_fakultas = txtnama_fakultas.Text
        ofakultas.Simpan()
        Reload()
        If (ofakultas.InsertState = True) Then
            MessageBox.Show("Data Berhasil Disimpan")
        ElseIf (ofakultas.UpdateState = True) Then
            MessageBox.Show("Data berhasil diubah")
        Else
            MessageBox.Show("Data gagal disimpan")
        End If
    End Sub

    Private Sub ClearEntry()
        txtkode_fakultas.Clear()
        txtnama_fakultas.Clear()
        txtkode_fakultas.Focus()
    End Sub

   

    Private Sub Hapus()
        If (fakultas_baru = False And txtkode_fakultas.Text <> "") Then
            ofakultas.Hapus(txtkode_fakultas.Text)
            ClearEntry()
            Reload()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Reload()
    End Sub

    Private Sub Reload()
        ofakultas.GetAllData(DataGridView1)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (txtkode_fakultas.Text <> "" And txtnama_fakultas.Text <> "") Then
            SimpanDataFakultas()
            ClearEntry()
            Reload()

        Else
            MessageBox.Show("Kode Fakultas dan Nama Fakultas tidak boleh kosong!")
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearEntry()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim jawab As Integer
        jawab = MessageBox.Show("Apakah Data akan dihapus", "Confirm", MessageBoxButtons.YesNo)
        If (jawab = vbYes) Then
            Hapus()
        Else
            MessageBox.Show("Data batal dihapus")
        End If
    End Sub

    Private Sub txtkode_fakultas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtkode_fakultas.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ofakultas.CariFakultas(txtkode_fakultas.Text)
            If (fakultas_baru = False) Then
                TampilFakultas()
            Else
                MessageBox.Show("Data tidak ditemukan")
            End If
        End If
    End Sub

    
    
End Class
