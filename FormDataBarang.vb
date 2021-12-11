Public Class FormDataBarang
    Private Sub FormDataBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksiDB()
        tampilkanData("SELECT * FROM data_produk", DataGridView1)
    End Sub
    'add
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (checkEmpty(TextBox1, TextBox2, TextBox3) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("data_produk", "id_produk", TextBox1.Text)
            If winny = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("data_produk", TextBox1.Text, TextBox2.Text, TextBox3.Text)
                tampilkanData("SELECT * FROM data_produk", DataGridView1)
            End If
        End If
    End Sub

    'edit data
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (checkEmpty(TextBox1, TextBox2, TextBox3) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("data_produk", "id_produk", TextBox1.Text, "nama_produk", TextBox2.Text, "harga_produk", TextBox3.Text)
            tampilkanData("SELECT * FROM data_produk", DataGridView1)

            'clear textboxxx
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            Button1.Enabled = True
        End If
    End Sub

    'delete
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cek As Boolean = checkDuplicate("data_produk", "id_produk", TextBox1.Text)
        If TextBox1.Text = "" Or cek = False Then
            MessageBox.Show("Tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("data_produk", "id_produk", TextBox1.Text)
                tampilkanData("SELECT * FROM data_produk", DataGridView1)

                'clear textboxxx
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                Button1.Enabled = True
            End If
        End If


    End Sub

    'klik cell
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value 'id_produk
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value 'nama_produk
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value 'harga_produk
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim keluar As New FormMenuUtama
        Me.Close()
        keluar.Show()
    End Sub
End Class