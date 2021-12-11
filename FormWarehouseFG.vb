Imports System.Data.OleDb
Imports ClosedXML.Excel
Imports excel = Microsoft.Office.Interop.Excel
Public Class FormWarehouseFG
    Friend idorderOOSstring As String
    Friend idDOstring As String
    Friend idFGstring As String
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
                TextBox1.Text = dt.Rows(0).Item("id_produk").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Keluar ke Menu Utama
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim result As DialogResult = MessageBox.Show("Apakah anda ingin ke Menu Utama ?", "KELUAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim a = New FormMenuUtama
            Me.Close()
            a.Show()
        ElseIf result = DialogResult.No Then
        End If
    End Sub
    Sub produk()
        Dim cmd = New OleDbCommand("SELECT * FROM data_produk", Conn)
        Dim rd = cmd.executereader
        ComboBox1.Items.Clear()
        Do While rd.read = True
            ComboBox1.Items.Add(rd.item("nama_produk"))
        Loop
    End Sub
    Sub produk_oos()
        Dim cmd = New OleDbCommand("SELECT * FROM data_produk", Conn)
        Dim rd = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While rd.Read = True
            ComboBox2.Items.Add(rd.Item("nama_produk"))
        Loop
    End Sub

    'load
    Private Sub FormWarehouseFG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksiDB()
        tampilkanData("SELECT * FROM marketing_inputOrder", DataGridView2)
        tampilkanData("SELECT * FROM FG_inventori", DataGridView1)
        tampilkanData("SELECT * FROM FG_outofstock", DataGridView3)
        tampilkanData("SELECT * FROM marketing_invoice", DataGridView4)
        tampilkanData("SELECT * FROM FG_pengiriman", DataGridView5)

        'combobox muncul produk buat menu stok produk
        Call produk()
        Call produk_oos()

        Dim rnORDEROOS As New Random
        Dim tanggalan As DateTime = Now
        Dim formattanggalan As String = "yyyy"
        Dim oos As String = "OOS"
        Dim ubahtanggalanjadistring As String
        ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
        Dim randomidOOS As Double
        randomidOOS = rnORDEROOS.Next(9999, 99999)
        idorderOOSstring = Convert.ToString(oos & randomidOOS & ubahtanggalanjadistring)
        TextBox2.Text = idorderOOSstring


        Dim rnORDERDO As New Random
        Dim tanggalanDO As DateTime = Now
        Dim formattanggalanDO As String = "yyyy"
        Dim deliveryorder As String = "DO"
        Dim ubahtanggalanjadistringDO As String
        ubahtanggalanjadistringDO = tanggalanDO.ToString(formattanggalanDO)
        Dim randomidDO As Double
        randomidDO = rnORDERDO.Next(9999, 99999)
        idDOstring = Convert.ToString(deliveryorder & randomidDO & ubahtanggalanjadistringDO)
        TextBox14.Text = idDOstring

        Dim rnKODEFG As New Random
        Dim tanggalanFG As DateTime = Now
        Dim formattanggalanFG As String = "yyyy"
        Dim FG As String = "FG"
        Dim ubahtanggalanjadistringFG As String
        ubahtanggalanjadistringFG = tanggalanFG.ToString(formattanggalanFG)
        Dim randomidFG As Double
        randomidFG = rnKODEFG.Next(9999, 99999)
        idFGstring = Convert.ToString(FG & randomidFG & ubahtanggalanjadistringFG)
        TextBox4.Text = idFGstring

    End Sub

    'PESANAN DARI MARKETING BUAT PERBANDINGAN
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        'ambil dari tabel marketing_inputOrder
        Try
            TextBox6.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value 'nama_produk
            TextBox7.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value 'jlhproduk
            TextBox21.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value 'no invoice
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'STOK GUDANG FG
    'INPUT STOK DATA

    'refresh data stok
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Call produk()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (checkEmpty(TextBox4, TextBox1, TextBox3) = True) Or (checkEmpty2(ComboBox1) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("FG_inventori", "kode_FG", TextBox1.Text)
            Dim cekidproduk As Boolean = checkDuplicate("FG_inventori", "id_produk", TextBox1.Text)
            If winny = True Or cekidproduk = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("FG_inventori", TextBox4.Text, TextBox1.Text, ComboBox1.Text, TextBox3.Text)
                tampilkanData("SELECT * FROM FG_inventori", DataGridView1)

                Dim rnKODEFG As New Random
                Dim tanggalanFG As DateTime = Now
                Dim formattanggalanFG As String = "yyyy"
                Dim FG As String = "FG"
                Dim ubahtanggalanjadistringFG As String
                ubahtanggalanjadistringFG = tanggalanFG.ToString(formattanggalanFG)
                Dim randomidFG As Double
                randomidFG = rnKODEFG.Next(9999, 99999)
                idFGstring = Convert.ToString(FG & randomidFG & ubahtanggalanjadistringFG)
                TextBox4.Text = idFGstring

                'clear textbox
                TextBox1.Clear()
                TextBox3.Clear()
            End If
        End If
    End Sub

    'edit data stok
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (checkEmpty(TextBox4, TextBox1, TextBox3) = True) Or (checkEmpty2(ComboBox1) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("FG_inventori", "kode_FG", TextBox4.Text, "id_produk", TextBox1.Text, "nama_produk", ComboBox1.Text, "jlh_FG", TextBox3.Text)
            tampilkanData("SELECT * FROM FG_inventori", DataGridView1)
            Button1.Enabled = True

            Dim rnKODEFG As New Random
            Dim tanggalanFG As DateTime = Now
            Dim formattanggalanFG As String = "yyyy"
            Dim FG As String = "FG"
            Dim ubahtanggalanjadistringFG As String
            ubahtanggalanjadistringFG = tanggalanFG.ToString(formattanggalanFG)
            Dim randomidFG As Double
            randomidFG = rnKODEFG.Next(9999, 99999)
            idFGstring = Convert.ToString(FG & randomidFG & ubahtanggalanjadistringFG)
            TextBox4.Text = idFGstring

            'clear textbox
            TextBox1.Clear()
            TextBox3.Clear()
            TextBox9.Clear()
            TextBox8.Clear()
        End If

    End Sub
    'delete data stok
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cek As Boolean = checkDuplicate("FG_inventori", "kode_FG", TextBox4.Text)
        If TextBox4.Text = "" Or cek = False Then
            MessageBox.Show("tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("FG_inventori", "kode_FG", TextBox4.Text)
                tampilkanData("SELECT * FROM FG_inventori", DataGridView1)

                Button1.Enabled = True

                Dim rnKODEFG As New Random
                Dim tanggalanFG As DateTime = Now
                Dim formattanggalanFG As String = "yyyy"
                Dim FG As String = "FG"
                Dim ubahtanggalanjadistringFG As String
                ubahtanggalanjadistringFG = tanggalanFG.ToString(formattanggalanFG)
                Dim randomidFG As Double
                randomidFG = rnKODEFG.Next(9999, 99999)
                idFGstring = Convert.ToString(FG & randomidFG & ubahtanggalanjadistringFG)
                TextBox4.Text = idFGstring

                'clear textbox
                TextBox1.Clear()
                TextBox3.Clear()
                TextBox9.Clear()
                TextBox8.Clear()
            End If
        End If
    End Sub

    'klik cell
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value 'kodeFG
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value 'id_produk
            ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value 'nama_produk
            TextBox9.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value 'nama_produk buat perbandingan stok
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value 'Jumlah FG
            TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value ' Jumlah FG buat perbandingan stok
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'calculator stok
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox9.Text = TextBox6.Text Then
            TextBox10.Text = Val(TextBox8.Text) - Val(TextBox7.Text)
            If Val(TextBox10.Text) < 0 Then
                TextBox11.Text = "OUT OF STOCK"
                TextBox12.Text = TextBox1.Text
                ComboBox2.Text = ComboBox1.Text
                TextBox5.Text = Math.Abs(Val(TextBox10.Text))
            Else
                If Val(TextBox10.Text) > 0 Then
                    TextBox11.Text = "OK"
                End If
            End If
                Else
            MessageBox.Show("Nama produk harus sama")
        End If
    End Sub


    'DATA OOS
    'pilih produk

    'refresh data produk
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Call produk_oos()
    End Sub
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
                TextBox12.Text = dt.Rows(0).Item("id_produk").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'input oos
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (checkEmpty(TextBox2, TextBox12, TextBox5) = True) Or (checkEmpty2(ComboBox2) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("FG_outofstock", "ID_oos", TextBox2.Text)
            If winny = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("FG_outofstock", TextBox2.Text, DateTimePicker3.Text, TextBox12.Text, ComboBox2.Text, TextBox5.Text)
                tampilkanData("SELECT * FROM FG_outofstock", DataGridView3)

                Dim rnORDEROOS As New Random
                Dim tanggalan As DateTime = Now
                Dim formattanggalan As String = "yyyy"
                Dim oos As String = "OOS"
                Dim ubahtanggalanjadistring As String
                ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
                Dim randomidOOS As Double
                randomidOOS = rnORDEROOS.Next(9999, 99999)
                idorderOOSstring = Convert.ToString(oos & randomidOOS & ubahtanggalanjadistring)
                TextBox2.Text = idorderOOSstring

                'clear textbox
                TextBox12.Clear()
                TextBox5.Clear()
            End If
        End If
    End Sub

    'edit oos
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (checkEmpty(TextBox2, TextBox12, TextBox5) = True) Or (checkEmpty2(ComboBox2) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("FG_outofstock", "ID_oos", TextBox2.Text, "tgloos", DateTimePicker3.Text, "id_produk", TextBox12.Text, "nama_produk", ComboBox2.Text, "kurang_stok", TextBox5.Text)
            tampilkanData("SELECT * FROM FG_outofstock", DataGridView3)

            Dim rnORDEROOS As New Random
            Dim tanggalan As DateTime = Now
            Dim formattanggalan As String = "yyyy"
            Dim oos As String = "OOS"
            Dim ubahtanggalanjadistring As String
            ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
            Dim randomidOOS As Double
            randomidOOS = rnORDEROOS.Next(9999, 99999)
            idorderOOSstring = Convert.ToString(oos & randomidOOS & ubahtanggalanjadistring)
            TextBox2.Text = idorderOOSstring

            'clear textbox
            TextBox12.Clear()
            TextBox5.Clear()
        End If
    End Sub

    'delete oos
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim cek As Boolean = checkDuplicate("FG_outofstock", "ID_oos", TextBox2.Text)
        If TextBox2.Text = "" Or cek = False Then
            MessageBox.Show("tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("FG_outofstock", "ID_oos", TextBox2.Text)
                tampilkanData("SELECT * FROM FG_outofstock", DataGridView3)

                Dim rnORDEROOS As New Random
                Dim tanggalan As DateTime = Now
                Dim formattanggalan As String = "yyyy"
                Dim oos As String = "OOS"
                Dim ubahtanggalanjadistring As String
                ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
                Dim randomidOOS As Double
                randomidOOS = rnORDEROOS.Next(9999, 99999)
                idorderOOSstring = Convert.ToString(oos & randomidOOS & ubahtanggalanjadistring)
                TextBox2.Text = idorderOOSstring

                'clear textbox
                TextBox12.Clear()
                TextBox5.Clear()
            End If
        End If
    End Sub

    'klik cell
    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        Try
            TextBox2.Text = DataGridView3.Rows(e.RowIndex).Cells(0).Value 'ID_oos
            DateTimePicker3.Text = DataGridView3.Rows(e.RowIndex).Cells(1).Value 'tgloos
            TextBox12.Text = DataGridView3.Rows(e.RowIndex).Cells(2).Value 'id_produk
            ComboBox2.Text = DataGridView3.Rows(e.RowIndex).Cells(3).Value 'nama_produk
            TextBox5.Text = DataGridView3.Rows(e.RowIndex).Cells(4).Value 'kurang_stok
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    'Delivery Order
    'klik cell
    Private Sub DataGridView4_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellClick
        Try
            TextBox15.Text = DataGridView4.Rows(e.RowIndex).Cells(0).Value 'noinvoice
            TextBox16.Text = DataGridView4.Rows(e.RowIndex).Cells(1).Value 'namapelanggan
            TextBox17.Text = DataGridView4.Rows(e.RowIndex).Cells(2).Value 'alamat pelanggan
            TextBox18.Text = DataGridView4.Rows(e.RowIndex).Cells(3).Value 'tglpesan
            TextBox13.Text = DataGridView4.Rows(e.RowIndex).Cells(4).Value 'id_produk
            TextBox19.Text = DataGridView4.Rows(e.RowIndex).Cells(5).Value 'nama_produk
            TextBox20.Text = DataGridView4.Rows(e.RowIndex).Cells(6).Value 'jlhproduk
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'kilk cell dari data DO
    Private Sub DataGridView5_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellClick
        Try
            TextBox14.Text = DataGridView5.Rows(e.RowIndex).Cells(0).Value 'IDkirimFG
            TextBox15.Text = DataGridView5.Rows(e.RowIndex).Cells(1).Value 'noinvoice
            TextBox16.Text = DataGridView5.Rows(e.RowIndex).Cells(2).Value 'namapelanggan
            TextBox17.Text = DataGridView5.Rows(e.RowIndex).Cells(3).Value 'alamatpelanggan
            TextBox13.Text = DataGridView5.Rows(e.RowIndex).Cells(4).Value 'id_produk
            TextBox19.Text = DataGridView5.Rows(e.RowIndex).Cells(5).Value 'nama_produk
            TextBox20.Text = DataGridView5.Rows(e.RowIndex).Cells(6).Value 'jlhproduk
            TextBox18.Text = DataGridView5.Rows(e.RowIndex).Cells(7).Value 'tglpesan
            DateTimePicker4.Text = DataGridView5.Rows(e.RowIndex).Cells(8).Value 'tglkirim
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'insert DO
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (checkEmpty(TextBox14, TextBox15, TextBox16, TextBox17, TextBox13, TextBox19, TextBox20, TextBox18) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("FG_pengiriman", "IDkirimFG", TextBox14.Text)
            Dim cekinvoice As Boolean = checkDuplicate("FG_pengiriman", "noinvoice", TextBox14.Text)
            If winny = True Or cekinvoice = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("FG_pengiriman", TextBox14.Text, TextBox15.Text, TextBox16.Text, TextBox17.Text, TextBox13.Text, TextBox19.Text, TextBox20.Text, TextBox18.Text, DateTimePicker4.Text)
                tampilkanData("SELECT * FROM FG_pengiriman", DataGridView5)

                Dim rnORDERDO As New Random
                Dim tanggalanDO As DateTime = Now
                Dim formattanggalanDO As String = "yyyy"
                Dim deliveryorder As String = "DO"
                Dim ubahtanggalanjadistringDO As String
                ubahtanggalanjadistringDO = tanggalanDO.ToString(formattanggalanDO)
                Dim randomidDO As Double
                randomidDO = rnORDERDO.Next(9999, 99999)
                idDOstring = Convert.ToString(deliveryorder & randomidDO & ubahtanggalanjadistringDO)
                TextBox14.Text = idDOstring

                'clear textboxxx
                TextBox15.Clear()
                TextBox16.Clear()
                TextBox17.Clear()
                TextBox18.Clear()
                TextBox13.Clear()
                TextBox19.Clear()
                TextBox20.Clear()
            End If
        End If
    End Sub
    'edit DO
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (checkEmpty(TextBox14, TextBox15, TextBox16, TextBox17, TextBox13, TextBox19, TextBox20, TextBox18) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("FG_pengiriman", "IDkirimFG", TextBox14.Text, "noinvoice", TextBox15.Text, "namapelanggan", TextBox16.Text, "alamatpelanggan", TextBox17.Text, "id_produk", TextBox13.Text, "nama_produk", TextBox19.Text, "jlhproduk", TextBox20.Text, "tglpesan", TextBox18.Text, "tglkirim", DateTimePicker4.Text)
            tampilkanData("SELECT * FROM FG_pengiriman", DataGridView5)

            Dim rnORDERDO As New Random
            Dim tanggalanDO As DateTime = Now
            Dim formattanggalanDO As String = "yyyy"
            Dim deliveryorder As String = "DO"
            Dim ubahtanggalanjadistringDO As String
            ubahtanggalanjadistringDO = tanggalanDO.ToString(formattanggalanDO)
            Dim randomidDO As Double
            randomidDO = rnORDERDO.Next(9999, 99999)
            idDOstring = Convert.ToString(deliveryorder & randomidDO & ubahtanggalanjadistringDO)
            TextBox14.Text = idDOstring


            'clear textboxxx
            TextBox15.Clear()
            TextBox16.Clear()
            TextBox17.Clear()
            TextBox18.Clear()
            TextBox13.Clear()
            TextBox19.Clear()
            TextBox20.Clear()
        End If
    End Sub
    'Delete DO
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim cek As Boolean = checkDuplicate("FG_pengiriman", "IDkirimFG", TextBox14.Text)
        If TextBox14.Text = "" Or cek = False Then
            MessageBox.Show("tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("FG_pengiriman", "IDkirimFG", TextBox14.Text)
                tampilkanData("SELECT * FROM FG_pengiriman", DataGridView5)

                Dim rnORDERDO As New Random
                Dim tanggalanDO As DateTime = Now
                Dim formattanggalanDO As String = "yyyy"
                Dim deliveryorder As String = "DO"
                Dim ubahtanggalanjadistringDO As String
                ubahtanggalanjadistringDO = tanggalanDO.ToString(formattanggalanDO)
                Dim randomidDO As Double
                randomidDO = rnORDERDO.Next(9999, 99999)
                idDOstring = Convert.ToString(deliveryorder & randomidDO & ubahtanggalanjadistringDO)
                TextBox14.Text = idDOstring

                'clear textboxxx
                TextBox15.Clear()
                TextBox16.Clear()
                TextBox17.Clear()
                TextBox18.Clear()
                TextBox13.Clear()
                TextBox19.Clear()
                TextBox20.Clear()
            End If
        End If
    End Sub

    'CRYSTAL REPORT
    'REPORT INVENTORI FG
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim a As New FormReportInventoriFG
        Me.Hide()
        a.Show()
    End Sub

    'REPORT OOS FG
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim a As New FormReportOOSFG
        Me.Hide()
        a.Show()
    End Sub
    'REPORT DO FG
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim a As New FormReportDOFG
        Me.Hide()
        a.Show()
    End Sub





    'EXPORT KE EXCELL
    'REPORT INVENTORI FG
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
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
            For i = 0 To DataGridView1.RowCount - 2
                For j = 0 To DataGridView1.ColumnCount - 1
                    For k As Integer = 1 To DataGridView1.Columns.Count
                        xlworksheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                        xlworksheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString



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

    'REPORT OOS FG
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
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

    'REPORT DO FG
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
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
            For i = 0 To DataGridView5.RowCount - 2
                For j = 0 To DataGridView5.ColumnCount - 1
                    For k As Integer = 1 To DataGridView5.Columns.Count
                        xlworksheet.Cells(1, k) = DataGridView5.Columns(k - 1).HeaderText
                        xlworksheet.Cells(i + 2, j + 1) = DataGridView5(j, i).Value.ToString



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