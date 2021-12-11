Public Class FormKaryawan
    Dim chia As String
    'Dim Conn As OleDbConnection
    'Dim DA As OleDbDataAdapter
    'Dim DS As DataSet
    Dim lokasiDB As String
    'Dim CMD As OleDbCommand
    'Dim DM As OleDbDataReader
    'Public InputBox As 
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As String
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max).ToString
    End Function

    Sub kosongkanform()
        txtkodekasir.Text = ""
        txtnamakasir.Text = ""
        txttemplar.Text = ""
        DateTimePicker1.Text = ""
        txtnohp.Text = ""
        txtnamapotokasir.Text = " "
        txtjeniskelamin.Text = ""
        cmbstatus.Text = ""
        txtumurkasir.Text = ""
        txtkodekasir.Focus()
        rtbalamat.Text = ""
        txtcaridgv.Text = " "
    End Sub

    Sub matikanform()
        txtkodekasir.Enabled = False
        txtnamakasir.Enabled = False
        txttemplar.Enabled = False
        DateTimePicker1.Enabled = False
        txtnohp.Enabled = False
        txtnamapotokasir.Enabled = False
        txtjeniskelamin.Enabled = False
        cmbstatus.Enabled = False
        txtumurkasir.Enabled = False
        rtbalamat.Enabled = False
        'txtcaridgv.Enabled = False
    End Sub

    Sub hidupkanform()
        txtkodekasir.Enabled = True
        txtnamakasir.Enabled = True
        txttemplar.Enabled = True
        DateTimePicker1.Enabled = True
        txtnohp.Enabled = True
        txtnamapotokasir.Enabled = True
        txtjeniskelamin.Enabled = True
        cmbstatus.Enabled = True
        txtumurkasir.Enabled = True
        rtbalamat.Enabled = True
    End Sub


    Sub tampilkandata()
        Call koneksiDB()
        DA = New OleDb.OleDbDataAdapter("select * from Karyawan", Conn)
        DS = New DataSet
        DA.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub btninputkasir_Click(sender As Object, e As EventArgs) Handles btninputkasir.Click
        Call hidupkanform()
        Call kosongkanform()
        Call tampilkandata()
    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        On Error Resume Next
        txtkodekasir.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        txtnamakasir.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        txttemplar.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        txtjeniskelamin.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        txtnohp.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        rtbalamat.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        cmbstatus.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        txtumurkasir.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        txtnamapotokasir.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value

        Dim kei As String
        kei = txtnamapotokasir.Text
        PictureBox1.Image = New Bitmap(kei)
        Call hidupkanform()
    End Sub

    Sub foto1()
        PictureBox1.ImageLocation = " "
    End Sub

    Sub foto2()
        PictureBox1.ImageLocation = True
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click

        chia = "D:\airminummerdeka"
        chia = chia + txtkodekasir.Text + ".jpg"
        PictureBox1.Image.Save(chia)

        If txtkodekasir.Text = " " Or txtnamakasir.Text = " " Or txttemplar.Text = " " Or DateTimePicker1.Text = " " Or txtjeniskelamin.Text = " " Or txtnohp.Text = " " Or rtbalamat.Text = "" Or cmbstatus.Text = "" Or txtumurkasir.Text = " " Or txtnamapotokasir.Text = " " Then
            MessageBox.Show("Data Belum Lengkap")
            Exit Sub
        Else
            Call koneksiDB()
            CMD = New OleDb.OleDbCommand("select * from Karyawan where IDkaryawan = '" & txtkodekasir.Text & "'", Conn)
            DM = CMD.ExecuteReader
            DM.Read()

            If Not DM.HasRows Then
                Call koneksiDB()
                Dim simpan As String
                simpan = "insert into Karyawan values ('" & txtkodekasir.Text & "','" & txtnamakasir.Text & "','" & txttemplar.Text & "','" & DateTimePicker1.Value.Date.ToShortDateString & "','" & txtjeniskelamin.Text & "','" & txtnohp.Text & "','" & rtbalamat.Text & "','" & cmbstatus.Text & "','" & txtumurkasir.Text & "','" & txtnamapotokasir.Text & "','" & chia & "')"
                CMD = New OleDb.OleDbCommand(simpan, Conn)
                CMD.ExecuteNonQuery()

                MessageBox.Show("Input Data Berhasil")
                Call foto1()
                Call foto2()
            Else
                MessageBox.Show("Data Sudah ada")
            End If

            Call matikanform()
            Call kosongkanform()
            Call tampilkandata()
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If txtkodekasir.Text = "" Then
            MessageBox.Show("Tidak ada data yang dipilih")
            Exit Sub
        Else
            If MessageBox.Show("Are you sure to delete this data ? ", "Konfirmasi", MessageBoxButtons.YesNoCancel) = Windows.Forms.DialogResult.Yes Then
                Call koneksiDB()
                CMD = New OleDb.OleDbCommand(" delete from Karyawan where IDkaryawan ='" & txtkodekasir.Text & "'", Conn)
                DM = CMD.ExecuteReader
                MessageBox.Show("Hapus Data Berhasil")
                Call matikanform()
                Call kosongkanform()
                Call tampilkandata()
            Else
                Call kosongkanform()
                Call tampilkandata()
            End If
        End If
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        Call hidupkanform()
        Dim kasir = MessageBox.Show("Silahkan Masukkan ID Karyawan")
        Try
            DS.Tables(0).PrimaryKey = New DataColumn() {(DS.Tables(0).Columns("IDkaryawan"))}

            Dim row As DataRow
            row = DS.Tables(0).Rows.Find(kasir)
            txtkodekasir.Text = row("IDkaryawan")
            txtnamakasir.Text = row("nama")
            txttemplar.Text = row("tempat_lahir")
            DateTimePicker1.Text = row("tanggal_lahir")
            txtnohp.Text = row("no_hp")
            rtbalamat.Text = row("alamat")
            txtjeniskelamin.Text = row("jenis_kelamin")
            cmbstatus.Text = row("Dept")
            txtumurkasir.Text = row("umur")
            txtnamapotokasir.Text = row("potokasir")

            Refresh()

            MessageBox.Show("Pencarian Berhasil")

            Refresh()

        Catch ex As Exception
            MessageBox.Show("Anda Salah memaskkan Kode Kasir / Kode Kasir belum terdaftar!")
        End Try
    End Sub

    Private Sub btncaridgv_Click(sender As Object, e As EventArgs) Handles btncaridgv.Click
        Call koneksiDB()
        DA = New OleDb.OleDbDataAdapter("SELECT * from Karyawan where IDkaryawan like '% " & txtcaridgv.Text.Replace("'", "''") & "%' or nama like '%" & txtcaridgv.Text.Replace("'", "''") & "%' or alamat like '%" & txtcaridgv.Text.Replace("'", "''") & "%' ", Conn)
        DS = New DataSet
        Dim srt As New DataTable
        srt.Clear()
        DA.Fill(srt)
        DataGridView1.DataSource = srt
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim umur, bulan, hari, TL, TS, lamakerja As Integer
        TL = Year(DateTimePicker1.Value)
        TS = Year(Now)
        umur = TS - TL
        bulan = DateDiff(DateInterval.Month, CDate(DateTimePicker1.Value), CDate(Now))
        hari = DateDiff(DateInterval.Day, CDate(DateTimePicker1.Value), CDate(Now))
        lamakerja = DateDiff(DateInterval.Month, CDate(DateTimePicker1.Value), CDate(Now))

        ' Select Case lamakerja kerja
        'Case < 3 : txt
        txtumurkasir.Text = (umur)
    End Sub

    Private Sub btncancelkasir_Click(sender As Object, e As EventArgs) Handles btncancelkasir.Click
        Call matikanform()
        Call kosongkanform()

    End Sub

    Private Sub btneditkasir_Click(sender As Object, e As EventArgs) Handles btneditkasir.Click
        If txtjeniskelamin.Text = " " Or txtkodekasir.Text = " " Or txtnamakasir.Text = " " Or cmbstatus.Text = " " Or txtnohp.Text = " " Or txtjeniskelamin.Text = " " Or rtbalamat.Text = " " Or txttemplar.Text = " " Or txtumurkasir.Text = " " Then
            MessageBox.Show("Data Belum Lengkap")
            Exit Sub
        Else
            Call koneksiDB()
            CMD = New OleDb.OleDbCommand(" update Karyawan set nama = '" & txtnamakasir.Text & "', tempat_lahir = '" & txttemplar.Text & "', tanggal_lahir = '" & DateTimePicker1.Value.Date.ToShortDateString & "', jenis_kelamin = '" & txtjeniskelamin.Text & "', no_hp = '" & txtnohp.Text & "', alamat = '" & rtbalamat.Text & "', Dept = '" & cmbstatus.Text & "' where IDkaryawan = '" & txtkodekasir.Text & "'", Conn)
            DM = CMD.ExecuteReader
            MessageBox.Show("Update Data Berhasil")
        End If

        Call kosongkanform()
        Call matikanform()
        Call tampilkandata()
    End Sub

    Private Sub btnexitkasir_Click(sender As Object, e As EventArgs) Handles btnexitkasir.Click
        Dim result As DialogResult = MessageBox.Show("Apakah anda ingin ke Menu Utama ?", "KELUAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim a = New FormMenuUtama
            Me.Close()
            a.Show()
        ElseIf result = DialogResult.No Then
        End If
    End Sub

    Private Sub btntelusuri_Click(sender As Object, e As EventArgs) Handles btntelusuri.Click
        Try
            OpenFileDialog1.Filter = " Image File(*.jpeg;*jpg;*.png;*.bmp;*.gif)| *.jpeg;*jpg;*.png;*.bmp;*.gif"
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PictureBox1.Image = New Bitmap(OpenFileDialog1.FileName)
                txtnamapotokasir.Text = OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            Throw New ApplicationException("Gambar Gagal Masuk")
        End Try
    End Sub

    Private Sub FormKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call tampilkandata()
    End Sub

    ' Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    generatecard.Show()
    ' End Sub

End Class