Imports System.Data.OleDb
Imports ClosedXML.Excel
Imports excel = Microsoft.Office.Interop.Excel
Public Class FormMarketing
    Friend idorderFGstring As String
    Friend hargaproduk As Double

    Private Sub FormMarketing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksiDB()
        'combobox muncul produk buat menu pilih produk
        Call produk()
        Call idinvoice()
        'ID random buat order distributor
        Dim rn As New Random
        Dim dist As String = "DIST"
        Dim x As Double
        Dim y As DateTime = Now
        Dim z As String
        Dim formatdatetime As String = "yyyyMMdd"
        Dim id As String
        z = y.ToString(formatdatetime)
        x = rn.Next(9999, 99999)
        id = Convert.ToString(dist & z & x)
        TextBox1.Text = id

        'ID random buat order FG
        Dim rnORDERFG As New Random
        Dim tanggalan As DateTime = Now
        Dim formattanggalan As String = "yyyy"
        Dim ofg As String = "OFG"
        Dim ubahtanggalanjadistring As String
        ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
        Dim randomidFG As Double
        randomidFG = rnORDERFG.Next(9999, 99999)
        idorderFGstring = Convert.ToString(ofg & randomidFG & ubahtanggalanjadistring)
        TextBox7.Text = idorderFGstring

        tampilkanData("SELECT * FROM marketing_invoice", DataGridView1)
        tampilkanData("SELECT * FROM marketing_inputOrder", DataGridView2)
        Button2.Enabled = False
        Button3.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
    End Sub
    Sub produk()
        Dim cmd = New OleDbCommand("SELECT * FROM data_produk", Conn)
        cmd.Connection = Conn
        Dim rd = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While rd.Read = True
            ComboBox1.Items.Add(rd.Item("nama_produk"))
        Loop
    End Sub
    Sub idinvoice()
        Dim cmd = New OleDbCommand("SELECT * FROM marketing_invoice", Conn)
        cmd.Connection = Conn
        Dim rd = cmd.ExecuteReader
        ComboBox2.Items.Clear()
        Do While rd.Read = True
            ComboBox2.Items.Add(rd.Item("noinvoice"))
        Loop
    End Sub

    'pilih barang langsung generate id product dan harga produk ! WOW !
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
                TextBox6.Text = dt.Rows(0).Item("id_produk").ToString
                hargaproduk = dt.Rows(0).Item("harga_produk").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'input id orderFG diambil dari id invoice secara otomatis
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim sql As String
        Dim cmd = New OleDbCommand
        Dim dt = New DataTable
        Dim da = New OleDbDataAdapter
        Try
            sql = "SELECT * FROM marketing_invoice WHERE noinvoice = '" & ComboBox2.Text & "'"
            cmd.Connection = Conn
            cmd.CommandText = sql
            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TextBox9.Text = dt.Rows(0).Item("id_produk").ToString
                TextBox8.Text = dt.Rows(0).Item("nama_produk").ToString
                TextBox11.Text = dt.Rows(0).Item("jlhproduk").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Keluar ke Menu Utama
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim result As DialogResult = MessageBox.Show("Apakah anda ingin ke Menu Utama ?", "KELUAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim a = New FormMenuUtama
            Me.Close()
            a.Show()
        ElseIf result = DialogResult.No Then
        End If
    End Sub

    'menu order distributor

    'calculator produk
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox4.Text = hargaproduk * Val(TextBox3.Text)
    End Sub

    'input
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (checkEmpty(TextBox1, TextBox2, TextBox10, TextBox6, TextBox4) = True) Or (checkEmpty2(ComboBox1) = True) Or (checkEmpty3(DateTimePicker1) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("marketing_invoice", "noinvoice", TextBox1.Text)
            If winny = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("marketing_invoice", TextBox1.Text, TextBox2.Text, TextBox10.Text, DateTimePicker1.Text, TextBox6.Text, ComboBox1.Text, TextBox3.Text, TextBox4.Text)
                tampilkanData("SELECT * FROM marketing_invoice", DataGridView1)

                'clear textboxxx
                TextBox2.Clear()
                TextBox10.Clear()
                TextBox6.Clear()
                TextBox3.Clear()
                TextBox4.Clear()

                'acak lagi id no invoice
                Dim rn As New Random
                Dim dist As String = "DIST"
                Dim x As Double
                Dim y As DateTime = Now
                Dim z As String
                Dim formatdatetime As String = "yyyyMMdd"
                Dim id As String
                z = y.ToString(formatdatetime)
                x = rn.Next(9999, 99999)
                id = Convert.ToString(dist & z & x)
                TextBox1.Text = id
            End If
        End If
    End Sub

    'klik cell
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value 'noinvoice
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value 'namapelanggan
            TextBox10.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value 'alamatpelanggan
            DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value 'tglpesan
            TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value 'id_produk
            ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value 'nama_produk
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value 'jlhproduk
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value 'jlhbayar

            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'edit data
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (checkEmpty(TextBox1, TextBox2, TextBox10, TextBox6, TextBox4) = True) Or (checkEmpty2(ComboBox1) = True) Or (checkEmpty3(DateTimePicker1) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("marketing_invoice", "noinvoice", TextBox1.Text, "namapelanggan", TextBox2.Text, "alamatpelanggan", TextBox10.Text, "tglpesan", DateTimePicker1.Text, "id_produk", TextBox6.Text, "nama_produk", ComboBox1.Text, "jlhproduk", TextBox3.Text, "jlhbayar", TextBox4.Text)
            tampilkanData("SELECT * FROM marketing_invoice", DataGridView1)

            'clear textboxxx
            TextBox2.Clear()
            TextBox10.Clear()
            TextBox6.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            Button1.Enabled = True

            'acak lagi id no invoice
            Dim rn As New Random
            Dim dist As String = "DIST"
            Dim x As Double
            Dim y As DateTime = Now
            Dim z As String
            Dim formatdatetime As String = "yyyyMMdd"
            Dim id As String
            z = y.ToString(formatdatetime)
            x = rn.Next(9999, 99999)
            id = Convert.ToString(dist & z & x)
            TextBox1.Text = id
        End If
    End Sub
    'delete data
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cek As Boolean = checkDuplicate("marketing_invoice", "noinvoice", TextBox1.Text)
        If TextBox1.Text = "" Or cek = False Then
            MessageBox.Show("Tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("marketing_invoice", "noinvoice", TextBox1.Text)
                tampilkanData("SELECT * FROM marketing_invoice", DataGridView1)

                'clear textboxxx
                TextBox2.Clear()
                TextBox10.Clear()
                TextBox6.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                Button1.Enabled = True

                'acak lagi id no invoice
                Dim rn As New Random
                Dim dist As String = "DIST"
                Dim x As Double
                Dim y As DateTime = Now
                Dim z As String
                Dim formatdatetime As String = "yyyyMMdd"
                Dim id As String
                z = y.ToString(formatdatetime)
                x = rn.Next(9999, 99999)
                id = Convert.ToString(dist & z & x)
                TextBox1.Text = id
            End If
        End If
    End Sub
    'refresh ID apabila ditemukan duplikat ID
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim rn As New Random
        Dim dist As String = "DIST"
        Dim x As Double
        Dim y As DateTime = Now
        Dim z As String
        Dim formatdatetime As String = "yyyyMMdd"
        Dim id As String
        z = y.ToString(formatdatetime)
        x = rn.Next(9999, 99999)
        id = Convert.ToString(dist & z & x)
        TextBox1.Text = id
    End Sub



    'menu order ke FG

    'input
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If (checkEmpty(TextBox7, TextBox9, TextBox8, TextBox11) = True) Or (checkEmpty2(ComboBox2) = True) Or (checkEmpty3(DateTimePicker2) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            Dim winny As Boolean = checkDuplicate("marketing_inputOrder", "kodeOrder", TextBox7.Text)
            Dim cekinvoice As Boolean = checkDuplicate("marketing_inputOrder", "noinvoice", ComboBox2.Text)
            If winny = True Or cekinvoice = True Then
                MessageBox.Show("Data jangan duplikat")
            Else
                simpanData("marketing_inputOrder", TextBox7.Text, ComboBox2.Text, DateTimePicker2.Text, TextBox9.Text, TextBox8.Text, TextBox11.Text)
                tampilkanData("SELECT * FROM marketing_inputOrder", DataGridView2)

                'clear textboxxx
                TextBox9.Clear()
                TextBox8.Clear()
                TextBox11.Clear()
                'acak order fg id
                Dim rnORDERFG As New Random
                Dim tanggalan As DateTime = Now
                Dim formattanggalan As String = "yyyy"
                Dim ofg As String = "OFG"
                Dim ubahtanggalanjadistring As String
                ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
                Dim randomidFG As Double
                randomidFG = rnORDERFG.Next(9999, 99999)
                idorderFGstring = Convert.ToString(ofg & randomidFG & ubahtanggalanjadistring)
                TextBox7.Text = idorderFGstring
            End If
        End If
    End Sub

    'klik cell
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        'showtoBox2(e.RowIndex, DataGridView1, TextBox1, TextBox7, TextBox2, TextBox10, DateTimePicker1, ComboBox1, TextBox3, TextBox4)
        Try
            TextBox7.Text = DataGridView2.Rows(e.RowIndex).Cells(0).Value 'kodeOrder
            ComboBox2.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value 'noinvoice
            DateTimePicker2.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value 'tglpesanFG
            TextBox9.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value 'id_produk
            TextBox8.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value 'nama_produk
            TextBox11.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value 'jlhproduk

            Button9.Enabled = False
            Button10.Enabled = True
            Button11.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'edit data
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (checkEmpty(TextBox7, TextBox9, TextBox8, TextBox11) = True) Or (checkEmpty2(ComboBox2) = True) Or (checkEmpty3(DateTimePicker2) = True) Then
            MessageBox.Show("Data masih kosong")
        Else
            updateData("marketing_inputOrder", "kodeOrder", TextBox7.Text, "noinvoice", ComboBox2.Text, "tglpesanFG", DateTimePicker2.Text, "id_produk", TextBox9.Text, "nama_produk", TextBox8.Text, "jlhproduk", TextBox11.Text)
            tampilkanData("SELECT * FROM marketing_inputOrder", DataGridView2)

            'clear textboxxx
            TextBox9.Clear()
            TextBox8.Clear()
            TextBox11.Clear()
            Button9.Enabled = True
            'acak order fg id
            Dim rnORDERFG As New Random
            Dim tanggalan As DateTime = Now
            Dim formattanggalan As String = "yyyy"
            Dim ofg As String = "OFG"
            Dim ubahtanggalanjadistring As String
            ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
            Dim randomidFG As Double
            randomidFG = rnORDERFG.Next(9999, 99999)
            idorderFGstring = Convert.ToString(ofg & randomidFG & ubahtanggalanjadistring)
            TextBox7.Text = idorderFGstring
        End If
    End Sub
    'delete data
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim cek As Boolean = checkDuplicate("marketing_inputOrder", "kodeOrder", TextBox7.Text)
        If TextBox7.Text = "" Or cek = False Then
            MessageBox.Show("tidak ada data yang dipilih")
        Else
            If MessageBox.Show("Apakah anda ingin hapus data ?", "HAPUS DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                hapusData("marketing_inputOrder", "kodeOrder", TextBox7.Text)
                tampilkanData("SELECT * FROM marketing_inputOrder", DataGridView2)

                'clear textboxxx
                TextBox9.Clear()
                TextBox8.Clear()
                TextBox11.Clear()
                Button9.Enabled = True
                'acak order fg id
                Dim rnORDERFG As New Random
                Dim tanggalan As DateTime = Now
                Dim formattanggalan As String = "yyyy"
                Dim ofg As String = "OFG"
                Dim ubahtanggalanjadistring As String
                ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
                Dim randomidFG As Double
                randomidFG = rnORDERFG.Next(9999, 99999)
                idorderFGstring = Convert.ToString(ofg & randomidFG & ubahtanggalanjadistring)
                TextBox7.Text = idorderFGstring
            End If
        End If
    End Sub

    'refresh ID apabila ditemukan duplikat ID
    Private Sub Button14_Click(sender As Object, e As EventArgs)
        Dim rnORDERFG As New Random
        Dim tanggalan As DateTime = Now
        Dim formattanggalan As String = "yyyy"
        Dim ofg As String = "OFG"
        Dim ubahtanggalanjadistring As String
        ubahtanggalanjadistring = tanggalan.ToString(formattanggalan)
        Dim randomidFG As Double
        randomidFG = rnORDERFG.Next(9999, 99999)
        idorderFGstring = Convert.ToString(ofg & randomidFG & ubahtanggalanjadistring)
        TextBox7.Text = idorderFGstring
    End Sub

    'refresh id invoice
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call idinvoice()
    End Sub

    'BUAT BUKA CRYSTAL REPORT INVOICE DISTRIBUTORRR
    'Invoice Distributor
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim a As New FormReportInvoiceDistributor
        Me.Hide()
        a.Show()
    End Sub
    'Report Order ke FG
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim a As New FormReportOrderKeFG
        Me.Hide()
        a.Show()
    End Sub
    'EXPORT KE EXCEL
    'Excel Invoice
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
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

    'Excel Order ke FG
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
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
            For i = 0 To DataGridView2.RowCount - 2
                For j = 0 To DataGridView2.ColumnCount - 1
                    For k As Integer = 1 To DataGridView2.Columns.Count
                        xlworksheet.Cells(1, k) = DataGridView2.Columns(k - 1).HeaderText
                        xlworksheet.Cells(i + 2, j + 1) = DataGridView2(j, i).Value.ToString



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