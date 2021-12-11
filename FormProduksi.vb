Imports System.Data.OleDb
Public Class FormProduksi
    Friend idRMPstring As String
    Friend idORDERRMstring As String
    Friend batchstring As String
    'kelompok sub
    Sub produk()
        Dim cmd = New OleDbCommand("SELECT * FROM data_produk", Conn)
        Dim rd = cmd.ExecuteReader
        ComboBox2.Items.Clear()
        Do While rd.Read = True
            ComboBox2.Items.Add(rd.Item("nama_produk"))
        Loop
    End Sub
    Sub RMproduk()
        Dim cmd = New OleDbCommand("SELECT * FROM Produksi_RMtiapProduk", Conn)
        Dim rd = cmd.ExecuteReader
        ComboBox3.Items.Clear()
        Do While rd.Read = True
            ComboBox3.Items.Add(rd.Item("nama_rm"))
        Loop
    End Sub

    Sub BatchProduk()
        Dim cmd = New OleDbCommand("SELECT * FROM Produksi_jadwalproduksi", Conn)
        Dim rd = cmd.ExecuteReader
        ComboBox4.Items.Clear()
        Do While rd.Read = True
            ComboBox4.Items.Add(rd.Item("nobatch"))
        Loop
    End Sub


    'load
    Private Sub FormProduksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampilkanData("SELECT * FROM FG_outofstock", DataGridView1)
        tampilkanData("SELECT * FROM RM_inventori", DataGridView2)
        tampilkanData("SELECT * FROM Produksi_jadwalproduksi", DataGridView4)
        tampilkanData("SELECT * FROM Produksi_RMtiapProduk", DataGridView5)
        tampilkanData("SELECT * FROM Produksi_orderRM", DataGridView6)
        tampilkanData("SELECT * FROM Produksi_hasil", DataGridView3)

        Call produk()
        Call RMproduk()
        Call BatchProduk()

        Dim rnRMproduk As New Random
        Dim tanggalan As DateTime = Now
        Dim formattanggalan As String = "yyyy"
        Dim rmp As String = "RMP"
        Dim ubahtanggalanjadistring As String
        ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
        Dim randomidRMP As Double
        randomidRMP = rnRMproduk.Next(9999, 99999)
        idRMPstring = Convert.ToString(rmp & randomidRMP & ubahtanggalanjadistring)
        TextBox5.Text = idRMPstring

        Dim rnORDERRMproduk As New Random
        Dim tanggalanORDERRM As DateTime = Now
        Dim formattanggalanORDERRM As String = "yyyy"
        Dim orm As String = "ORM"
        Dim ubahtanggalanjadistringORDERRM As String
        ubahtanggalanjadistringORDERRM = tanggalanORDERRM.ToString(formattanggalanORDERRM)
        Dim randomidORDERRM As Double
        randomidORDERRM = rnORDERRMproduk.Next(9999, 99999)
        idORDERRMstring = Convert.ToString(orm & randomidORDERRM & ubahtanggalanjadistringORDERRM)
        TextBox20.Text = idORDERRMstring

        Dim rnbatchproduk As New Random
        Dim tanggalanbatch As DateTime = Now
        Dim formattanggalanbatch As String = "yyyy"
        Dim batch As String = "BATCH"
        Dim ubahtanggalanjadistringbatch As String
        ubahtanggalanjadistringbatch = tanggalanbatch.ToString(formattanggalanbatch)
        Dim randomidbatch As Double
        randomidbatch = rnbatchproduk.Next(9999, 99999)
        batchstring = Convert.ToString(batch & ubahtanggalanjadistringbatch & randomidbatch)
        TextBox9.Text = batchstring

    End Sub

    'Keluar ke Menu Utama
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim result As DialogResult = MessageBox.Show("Apakah anda ingin ke Menu Utama ?", "KELUAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim a = New FormMenuUtama
            Me.Close()
            a.Show()
        ElseIf result = DialogResult.No Then
        End If
    End Sub

    'refresh produk
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Call produk()
    End Sub

    'LIST OUT OF STOCK

    'klik cell
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            TextBox23.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value 'ID_oos
            TextBox21.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value 'tgloos
            TextBox13.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value 'id_produk
            TextBox14.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value 'nama_produk
            TextBox16.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value 'kurang_stok
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub















    'Data Kebutuhan RM

    'RM dari data warehouse RM klik cell
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            TextBox1.Text = DataGridView2.Rows(e.RowIndex).Cells(0).Value
            TextBox2.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value
            TextBox3.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
            TextBox4.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    'Spesifikasi Produk
    'Produksi_RMtiapProduk
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'id produk otomatis saat user memilih produk jd gaperlu isi2 lagi yey :3
        Dim sql As String
        Dim cmd = New OleDbCommand
        Dim dt = New DataTable
        Dim da = New OleDbDataAdapter
        Try
            sql = "SELECT * FROM data_produk WHERE nama_produk = '" & ComboBox2.Text & "'"
            cmd.Connection = Conn
            cmd.CommandText = sql
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TextBox7.Text = dt.Rows(0).Item("id_produk").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'input
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If (checkEmpty(TextBox5, TextBox7, TextBox22, TextBox24, TextBox17) = True) Or (checkEmpty2(ComboBox2) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("Produksi_RMtiapProduk", "ID_RMproduk", TextBox5.Text)
            Dim cekidproduk As Boolean = checkDuplicate("Produksi_RMtiapProduk", "id_produk", TextBox7.Text)
            Dim namaRM As Boolean = checkDuplicate("Produksi_RMtiapProduk", "nama_rm", TextBox22.Text)
            If winny = True Or cekidproduk = True Or namaRM = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("Produksi_RMtiapProduk", TextBox5.Text, TextBox7.Text, ComboBox2.Text, TextBox22.Text, TextBox24.Text, TextBox17.Text)
                tampilkanData("SELECT * FROM Produksi_RMtiapProduk", DataGridView5)

                'clear textboxxx
                TextBox7.Clear()
                TextBox22.Clear()
                TextBox24.Clear()
                TextBox17.Clear()

                'acakk id
                Dim rnRMproduk As New Random
                Dim tanggalan As DateTime = Now
                Dim formattanggalan As String = "yyyy"
                Dim rmp As String = "RMP"
                Dim ubahtanggalanjadistring As String
                ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
                Dim randomidRMP As Double
                randomidRMP = rnRMproduk.Next(9999, 99999)
                idRMPstring = Convert.ToString(rmp & randomidRMP & ubahtanggalanjadistring)
                TextBox5.Text = idRMPstring
            End If
        End If

    End Sub

    'klik cell
    Private Sub DataGridView5_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellClick
        Try
            TextBox5.Text = DataGridView5.Rows(e.RowIndex).Cells(0).Value 'ID_RMproduk
            TextBox7.Text = DataGridView5.Rows(e.RowIndex).Cells(1).Value 'id_produk
            ComboBox2.Text = DataGridView5.Rows(e.RowIndex).Cells(2).Value 'nama_produk
            TextBox22.Text = DataGridView5.Rows(e.RowIndex).Cells(3).Value 'nama_rm
            TextBox24.Text = DataGridView5.Rows(e.RowIndex).Cells(4).Value 'jumlah_kebutuhan_rm
            TextBox17.Text = DataGridView5.Rows(e.RowIndex).Cells(5).Value 'satuan_rm
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'edit
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If (checkEmpty(TextBox5, TextBox7, TextBox22, TextBox24, TextBox17) = True) Or (checkEmpty2(ComboBox2) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("Produksi_RMtiapProduk", "ID_RMproduk", TextBox5.Text, "id_produk", TextBox7.Text, "nama_produk", ComboBox2.Text, "nama_rm", TextBox22.Text, "jumlah_kebutuhan_rm", TextBox24.Text, "satuan_rm", TextBox17.Text)
            tampilkanData("SELECT * FROM Produksi_RMtiapProduk", DataGridView5)


            'clear textboxxx
            TextBox7.Clear()
            TextBox22.Clear()
            TextBox24.Clear()
            TextBox17.Clear()

            'acakk id
            Dim rnRMproduk As New Random
            Dim tanggalan As DateTime = Now
            Dim formattanggalan As String = "yyyy"
            Dim rmp As String = "RMP"
            Dim ubahtanggalanjadistring As String
            ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
            Dim randomidRMP As Double
            randomidRMP = rnRMproduk.Next(9999, 99999)
            idRMPstring = Convert.ToString(rmp & randomidRMP & ubahtanggalanjadistring)
            TextBox5.Text = idRMPstring
        End If
    End Sub

    'delete
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim cek As Boolean = checkDuplicate("Produksi_RMtiapProduk", "ID_RMproduk", TextBox5.Text)
        If TextBox5.Text = "" Or cek = False Then
            MessageBox.Show("tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("Produksi_RMtiapProduk", "ID_RMproduk", TextBox5.Text)
                tampilkanData("SELECT * FROM Produksi_RMtiapProduk", DataGridView5)

                'clear textboxxx
                TextBox7.Clear()
                TextBox22.Clear()
                TextBox24.Clear()
                TextBox17.Clear()

                'acakk id
                Dim rnRMproduk As New Random
                Dim tanggalan As DateTime = Now
                Dim formattanggalan As String = "yyyy"
                Dim rmp As String = "RMP"
                Dim ubahtanggalanjadistring As String
                ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
                Dim randomidRMP As Double
                randomidRMP = rnRMproduk.Next(9999, 99999)
                idRMPstring = Convert.ToString(rmp & randomidRMP & ubahtanggalanjadistring)
                TextBox5.Text = idRMPstring
            End If
        End If
    End Sub

    'cek stok RM
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If TextBox22.Text = TextBox2.Text Then
            TextBox19.Text = Val(TextBox3.Text) - Val(TextBox24.Text)
            If Val(TextBox19.Text) < 0 Then
                TextBox8.Text = "OUT OF STOCK"
                TextBox15.Text = TextBox5.Text
                ComboBox3.Text = TextBox22.Text
                TextBox18.Text = Math.Abs(Val(TextBox19.Text))
                TextBox25.Text = TextBox17.Text

                'clear textboxxx
                TextBox7.Clear()
                TextBox22.Clear()
                TextBox24.Clear()
                TextBox17.Clear()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()

                'acak id lagi
                Dim rnRMproduk As New Random
                Dim tanggalan As DateTime = Now
                Dim formattanggalan As String = "yyyy"
                Dim rmp As String = "RMP"
                Dim ubahtanggalanjadistring As String
                ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
                Dim randomidRMP As Double
                randomidRMP = rnRMproduk.Next(9999, 99999)
                idRMPstring = Convert.ToString(rmp & randomidRMP & ubahtanggalanjadistring)
                TextBox5.Text = idRMPstring
            Else
                TextBox8.Text = "OK"
                'clear textboxxx
                TextBox7.Clear()
                TextBox22.Clear()
                TextBox24.Clear()
                TextBox17.Clear()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                'acak id lagi
                Dim rnRMproduk As New Random
                Dim tanggalan As DateTime = Now
                Dim formattanggalan As String = "yyyy"
                Dim rmp As String = "RMP"
                Dim ubahtanggalanjadistring As String
                ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
                Dim randomidRMP As Double
                randomidRMP = rnRMproduk.Next(9999, 99999)
                idRMPstring = Convert.ToString(rmp & randomidRMP & ubahtanggalanjadistring)
                TextBox5.Text = idRMPstring
            End If
        Else
            TextBox19.Text = "RM harus sama"
            TextBox8.Clear()
            'clear textboxxx
            TextBox7.Clear()
            TextBox22.Clear()
            TextBox24.Clear()
            TextBox17.Clear()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            'acak id lagi
            Dim rnRMproduk As New Random
            Dim tanggalan As DateTime = Now
            Dim formattanggalan As String = "yyyy"
            Dim rmp As String = "RMP"
            Dim ubahtanggalanjadistring As String
            ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
            Dim randomidRMP As Double
            randomidRMP = rnRMproduk.Next(9999, 99999)
            idRMPstring = Convert.ToString(rmp & randomidRMP & ubahtanggalanjadistring)
            TextBox5.Text = idRMPstring
        End If
    End Sub



    'Order RM
    'refresh data spek produk
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Call RMproduk()
    End Sub

    'input
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If (checkEmpty(TextBox20, TextBox15, TextBox18, TextBox25) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("Produksi_orderRM", "kode_orderRM", TextBox20.Text)
            If winny = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("Produksi_orderRM", TextBox20.Text, DateTimePicker7.Text, TextBox15.Text, ComboBox3.Text, TextBox18.Text, TextBox25.Text)
                tampilkanData("SELECT * FROM Produksi_orderRM", DataGridView6)

                'clear textboxxx
                TextBox20.Clear()
                TextBox15.Clear()
                TextBox18.Clear()
                TextBox25.Clear()

                Dim rnORDERRMproduk As New Random
                Dim tanggalanORDERRM As DateTime = Now
                Dim formattanggalanORDERRM As String = "yyyy"
                Dim orm As String = "ORM"
                Dim ubahtanggalanjadistringORDERRM As String
                ubahtanggalanjadistringORDERRM = tanggalanORDERRM.ToString(formattanggalanORDERRM)
                Dim randomidORDERRM As Double
                randomidORDERRM = rnORDERRMproduk.Next(9999, 99999)
                idORDERRMstring = Convert.ToString(orm & randomidORDERRM & ubahtanggalanjadistringORDERRM)
                TextBox20.Text = idORDERRMstring

            End If
        End If


    End Sub

    'klik cell
    Private Sub DataGridView6_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellClick
        Try
            TextBox20.Text = DataGridView6.Rows(e.RowIndex).Cells(0).Value 'kode_orderRM
            DateTimePicker7.Text = DataGridView6.Rows(e.RowIndex).Cells(1).Value 'tglorderRM
            TextBox15.Text = DataGridView6.Rows(e.RowIndex).Cells(2).Value 'ID_RMproduk
            ComboBox3.Text = DataGridView6.Rows(e.RowIndex).Cells(3).Value 'nama_rm
            TextBox18.Text = DataGridView6.Rows(e.RowIndex).Cells(4).Value 'jumlah_order_rm
            TextBox25.Text = DataGridView6.Rows(e.RowIndex).Cells(5).Value 'satuan_rm


            Button12.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'edit
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (checkEmpty(TextBox20, TextBox15, TextBox18, TextBox25) = True) Or (checkEmpty2(ComboBox3) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("Produksi_orderRM", "kode_orderRM", TextBox20.Text, "tglorderRM", DateTimePicker7.Text, "ID_RMproduk", TextBox15.Text, "nama_rm", ComboBox3.Text, "jumlah_order_rm", TextBox18.Text, "satuan_rm", TextBox25.Text)
            tampilkanData("SELECT * FROM Produksi_orderRM", DataGridView6)

            'clear textboxxx
            TextBox20.Clear()
            TextBox15.Clear()
            TextBox18.Clear()
            TextBox25.Clear()

            Dim rnORDERRMproduk As New Random
            Dim tanggalanORDERRM As DateTime = Now
            Dim formattanggalanORDERRM As String = "yyyy"
            Dim orm As String = "ORM"
            Dim ubahtanggalanjadistringORDERRM As String
            ubahtanggalanjadistringORDERRM = tanggalanORDERRM.ToString(formattanggalanORDERRM)
            Dim randomidORDERRM As Double
            randomidORDERRM = rnORDERRMproduk.Next(9999, 99999)
            idORDERRMstring = Convert.ToString(orm & randomidORDERRM & ubahtanggalanjadistringORDERRM)
            TextBox20.Text = idORDERRMstring

            Button12.Enabled = True
        End If
    End Sub

    'delete
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim cek As Boolean = checkDuplicate("Produksi_orderRM", "kode_orderRM", TextBox20.Text)
        If TextBox20.Text = "" Or cek = False Then
            MessageBox.Show("tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("Produksi_orderRM", "kode_orderRM", TextBox20.Text)
                tampilkanData("SELECT * FROM Produksi_orderRM", DataGridView6)
                'clear textboxxx
                TextBox20.Clear()
                TextBox15.Clear()
                TextBox18.Clear()
                TextBox25.Clear()

                Dim rnORDERRMproduk As New Random
                Dim tanggalanORDERRM As DateTime = Now
                Dim formattanggalanORDERRM As String = "yyyy"
                Dim orm As String = "ORM"
                Dim ubahtanggalanjadistringORDERRM As String
                ubahtanggalanjadistringORDERRM = tanggalanORDERRM.ToString(formattanggalanORDERRM)
                Dim randomidORDERRM As Double
                randomidORDERRM = rnORDERRMproduk.Next(9999, 99999)
                idORDERRMstring = Convert.ToString(orm & randomidORDERRM & ubahtanggalanjadistringORDERRM)
                TextBox20.Text = idORDERRMstring

                Button12.Enabled = True
            End If
        End If
    End Sub



    'JADWAL PRODUKSI DAN HASIL PRODUKSI
    'Jadwal Produksi

    'refresh PRODUK
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Call produk()
    End Sub

    'pilih produk auto id di textbox
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'id produk otomatis saat user memilih produk jd gaperlu isi2 lagi yey :3
        Dim sql As String
        Dim cmd = New OleDbCommand
        Dim dt = New DataTable
        Dim da = New OleDbDataAdapter
        Try
            sql = "SELECT * FROM data_produk WHERE nama_produk = '" & ComboBox1.Text & "'"
            cmd.Connection = Conn
            cmd.CommandText = sql
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TextBox10.Text = dt.Rows(0).Item("id_produk").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'input
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (checkEmpty(TextBox26, TextBox9, TextBox10, TextBox11, TextBox12) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("Produksi_jadwalproduksi", "nojadwal", TextBox26.Text)
            If winny = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("Produksi_jadwalproduksi", TextBox26.Text, TextBox9.Text, TextBox10.Text, ComboBox1.Text, TextBox11.Text, TextBox12.Text, DateTimePicker2.Text, DateTimePicker3.Text)
                tampilkanData("SELECT * FROM Produksi_jadwalproduksi", DataGridView4)

                'clear textboxxx
                TextBox26.Clear()
                TextBox10.Clear()
                TextBox12.Clear()
                TextBox11.Clear()

                Dim rnbatchproduk As New Random
                Dim tanggalanbatch As DateTime = Now
                Dim formattanggalanbatch As String = "yyyy"
                Dim batch As String = "BATCH"
                Dim ubahtanggalanjadistringbatch As String
                ubahtanggalanjadistringbatch = tanggalanbatch.ToString(formattanggalanbatch)
                Dim randomidbatch As Double
                randomidbatch = rnbatchproduk.Next(9999, 99999)
                batchstring = Convert.ToString(batch & ubahtanggalanjadistringbatch & randomidbatch)
                TextBox9.Text = batchstring

            End If
        End If
    End Sub

    'klik cell
    Private Sub DataGridView4_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellClick
        Try
            TextBox26.Text = DataGridView4.Rows(e.RowIndex).Cells(0).Value 'nojadwal
            TextBox9.Text = DataGridView4.Rows(e.RowIndex).Cells(1).Value 'nobatch
            TextBox10.Text = DataGridView4.Rows(e.RowIndex).Cells(2).Value 'id_produk
            ComboBox1.Text = DataGridView4.Rows(e.RowIndex).Cells(3).Value 'nama_produk
            TextBox11.Text = DataGridView4.Rows(e.RowIndex).Cells(4).Value 'workcenter
            TextBox12.Text = DataGridView4.Rows(e.RowIndex).Cells(5).Value 'qtyproduk
            DateTimePicker2.Text = DataGridView4.Rows(e.RowIndex).Cells(6).Value 'operationstart
            DateTimePicker3.Text = DataGridView4.Rows(e.RowIndex).Cells(7).Value 'duedate

            Button8.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'edit data
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (checkEmpty(TextBox26, TextBox9, TextBox10, TextBox11, TextBox12) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("Produksi_jadwalproduksi", "nojadwal", TextBox26.Text, "nobatch", TextBox9.Text, "id_produk", TextBox10.Text, "nama_produk", ComboBox1.Text, "workcenter", TextBox11.Text, "qtyproduk", TextBox12.Text, "operationstart", DateTimePicker2.Text, "duedate", DateTimePicker3.Text)
            tampilkanData("SELECT * FROM Produksi_jadwalproduksi", DataGridView4)

            'clear textboxxx
            TextBox26.Clear()
            TextBox10.Clear()
            TextBox12.Clear()
            TextBox11.Clear()

            Dim rnbatchproduk As New Random
            Dim tanggalanbatch As DateTime = Now
            Dim formattanggalanbatch As String = "yyyy"
            Dim batch As String = "BATCH"
            Dim ubahtanggalanjadistringbatch As String
            ubahtanggalanjadistringbatch = tanggalanbatch.ToString(formattanggalanbatch)
            Dim randomidbatch As Double
            randomidbatch = rnbatchproduk.Next(9999, 99999)
            batchstring = Convert.ToString(batch & ubahtanggalanjadistringbatch & randomidbatch)
            TextBox9.Text = batchstring

            Button8.Enabled = True
        End If
    End Sub

    'delete
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim cek As Boolean = checkDuplicate("Produksi_jadwalproduksi", "nojadwal", TextBox26.Text)
        If TextBox26.Text = "" Or cek = False Then
            MessageBox.Show("tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("Produksi_jadwalproduksi", "nojadwal", TextBox26.Text)
                tampilkanData("SELECT * FROM Produksi_jadwalproduksi", DataGridView4)

                'clear textboxxx
                TextBox26.Clear()
                TextBox10.Clear()
                TextBox12.Clear()
                TextBox11.Clear()

                Dim rnbatchproduk As New Random
                Dim tanggalanbatch As DateTime = Now
                Dim formattanggalanbatch As String = "yyyy"
                Dim batch As String = "BATCH"
                Dim ubahtanggalanjadistringbatch As String
                ubahtanggalanjadistringbatch = tanggalanbatch.ToString(formattanggalanbatch)
                Dim randomidbatch As Double
                randomidbatch = rnbatchproduk.Next(9999, 99999)
                batchstring = Convert.ToString(batch & ubahtanggalanjadistringbatch & randomidbatch)
                TextBox9.Text = batchstring

                Button8.Enabled = True
            End If
        End If
    End Sub


    'HASIL PRODUKSI

    'refresh data Batch
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Call BatchProduk()
    End Sub

    'pilih batch
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        'id produk otomatis saat user memilih produk jd gaperlu isi2 lagi yey :3
        Dim sql As String
        Dim cmd = New OleDbCommand
        Dim dt = New DataTable
        Dim da = New OleDbDataAdapter
        Try
            sql = "SELECT * FROM Produksi_jadwalproduksi WHERE nobatch = '" & ComboBox4.Text & "'"
            cmd.Connection = Conn
            cmd.CommandText = sql
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TextBox6.Text = dt.Rows(0).Item("id_produk").ToString
                TextBox27.Text = dt.Rows(0).Item("nama_produk").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'input
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (checkEmpty(TextBox6, TextBox27, TextBox28) = True Or checkEmpty2(ComboBox4) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("Produksi_hasil", "nobatch", ComboBox4.Text)
            If winny = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("Produksi_hasil", ComboBox4.Text, DateTimePicker4.Text, TextBox6.Text, TextBox27.Text, TextBox28.Text)
                tampilkanData("SELECT * FROM Produksi_hasil", DataGridView3)

                'clear textboxxx
                TextBox6.Clear()
                TextBox27.Clear()
                TextBox28.Clear()
            End If
        End If
    End Sub

    'klik cell
    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Try
            ComboBox4.Text = DataGridView3.Rows(e.RowIndex).Cells(0).Value 'nobatch
            DateTimePicker4.Text = DataGridView3.Rows(e.RowIndex).Cells(1).Value 'operationend
            TextBox6.Text = DataGridView3.Rows(e.RowIndex).Cells(2).Value 'id_produk
            TextBox27.Text = DataGridView3.Rows(e.RowIndex).Cells(3).Value 'nama_produk
            TextBox28.Text = DataGridView3.Rows(e.RowIndex).Cells(4).Value 'jumlah_produksiFG

            Button1.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'edit data
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (checkEmpty(TextBox6, TextBox27, TextBox28) = True Or checkEmpty2(ComboBox4) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("Produksi_hasil", "nobatch", ComboBox4.Text, "operationend", DateTimePicker4.Text, "id_produk", TextBox6.Text, "nama_produk", TextBox27.Text, "jumlah_produksiFG", TextBox28.Text)
            tampilkanData("SELECT * FROM Produksi_hasil", DataGridView3)

            'clear textboxxx
            TextBox6.Clear()
            TextBox27.Clear()
            TextBox28.Clear()
        End If
    End Sub

    'delete
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cek As Boolean = checkDuplicate("Produksi_jadwalproduksi", "nobatch", ComboBox4.Text)
        If ComboBox4.Text = "" Or cek = False Then
            MessageBox.Show("tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("Produksi_hasil", "nobatch", ComboBox4.Text)
                tampilkanData("SELECT * FROM Produksi_hasil", DataGridView3)

                'clear textboxxx
                TextBox26.Clear()
                TextBox10.Clear()
                TextBox12.Clear()
                TextBox11.Clear()
            End If
        End If
    End Sub

    'edit data RM utk pengurangan stok
    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If (checkEmpty(TextBox3) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("RM_inventori", "kode_RM", TextBox1.Text, "nama_RM", TextBox2.Text, "jlh_RM", TextBox3.Text, "satuan_RM", TextBox4.Text)
            tampilkanData("SELECT * FROM RM_inventori", DataGridView2)

            'clear textboxxx
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
        End If
    End Sub


    'CRYSTAL REPORT
    'DATA KEBUTUHAN RM/ORDER RM
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim a As New FormReportOrderRM
        Me.Hide()
        a.Show()
    End Sub

    'JADWAL PRODUKSI
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim a As New FormReportJadwalProduksi
        Me.Hide()
        a.Show()
    End Sub

    'HASIL PRODUKSI
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim a As New FormReportHasilProduksi
        Me.Hide()
        a.Show()
    End Sub


    'EXPORT KE EXCEL
    'DATA KEBUTUHAN RM/ORDER RM
    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        'format
        SaveFileDialog1.Filter = "Excel Files(*.xlsx)|*.xlsx"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xlapp As Microsoft.Office.Interop.Excel.Application
            Dim xlworkbook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlworksheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim missvalue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlapp = New Microsoft.Office.Interop.Excel.Application
            xlworkbook = xlapp.Workbooks.Add(missvalue)
            xlworksheet = xlworkbook.Sheets("sheet1")

            'proses eksport
            'CEK DATAGRIDVIEWNYA ! HARUS SESUAI !
            For i = 0 To DataGridView6.RowCount - 2
                For j = 0 To DataGridView6.ColumnCount - 1
                    For k As Integer = 1 To DataGridView6.Columns.Count
                        xlworksheet.Cells(1, k) = DataGridView6.Columns(k - 1).HeaderText
                        xlworksheet.Cells(i + 2, j + 1) = DataGridView6(j, i).Value.ToString



                    Next
                Next
            Next
            xlworksheet.SaveAs(SaveFileDialog1.FileName)
            xlworkbook.Close()
            xlapp.Quit()

            releaseobject(xlapp)
            releaseobject(xlworkbook)
            releaseobject(xlworksheet)

            MessageBox.Show("Proses export berhasil", "Sukses", MessageBoxButtons.OK)
        End If
    End Sub

    'JADWAL PRODUKSI
    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        'format
        SaveFileDialog1.Filter = "Excel Files(*.xlsx)|*.xlsx"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xlapp As Microsoft.Office.Interop.Excel.Application
            Dim xlworkbook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlworksheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim missvalue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlapp = New Microsoft.Office.Interop.Excel.Application
            xlworkbook = xlapp.Workbooks.Add(missvalue)
            xlworksheet = xlworkbook.Sheets("sheet1")

            'proses eksport
            'CEK DATAGRIDVIEWNYA ! HARUS SESUAI !
            For i = 0 To DataGridView4.RowCount - 2
                For j = 0 To DataGridView4.ColumnCount - 1
                    For k As Integer = 1 To DataGridView4.Columns.Count
                        xlworksheet.Cells(1, k) = DataGridView4.Columns(k - 1).HeaderText
                        xlworksheet.Cells(i + 2, j + 1) = DataGridView4(j, i).Value.ToString



                    Next
                Next
            Next
            xlworksheet.SaveAs(SaveFileDialog1.FileName)
            xlworkbook.Close()
            xlapp.Quit()

            releaseobject(xlapp)
            releaseobject(xlworkbook)
            releaseobject(xlworksheet)

            MessageBox.Show("Proses export berhasil", "Sukses", MessageBoxButtons.OK)
        End If
    End Sub

    'HASIL PRODUKSI
    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        'format
        SaveFileDialog1.Filter = "Excel Files(*.xlsx)|*.xlsx"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xlapp As Microsoft.Office.Interop.Excel.Application
            Dim xlworkbook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlworksheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim missvalue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlapp = New Microsoft.Office.Interop.Excel.Application
            xlworkbook = xlapp.Workbooks.Add(missvalue)
            xlworksheet = xlworkbook.Sheets("sheet1")

            'proses eksport
            'CEK DATAGRIDVIEWNYA ! HARUS SESUAI !
            For i = 0 To DataGridView3.RowCount - 2
                For j = 0 To DataGridView3.ColumnCount - 1
                    For k As Integer = 1 To DataGridView3.Columns.Count
                        xlworksheet.Cells(1, k) = DataGridView3.Columns(k - 1).HeaderText
                        xlworksheet.Cells(i + 2, j + 1) = DataGridView3(j, i).Value.ToString



                    Next
                Next
            Next
            xlworksheet.SaveAs(SaveFileDialog1.FileName)
            xlworkbook.Close()
            xlapp.Quit()

            releaseobject(xlapp)
            releaseobject(xlworkbook)
            releaseobject(xlworksheet)

            MessageBox.Show("Proses export berhasil", "Sukses", MessageBoxButtons.OK)
        End If
    End Sub
End Class