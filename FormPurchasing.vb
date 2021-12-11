Public Class FormPurchasing

    'Load FORM
    Private Sub FormPurchasing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim login As New LoginPurchasing
        txtpemesan.Text = login.UsernameTextBox.Text
        disableButton(btndeletePO, btneditPO, btncancelPO)
        matiForm(txtalamat, txtnoPO, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)
        tampilkanData("SELECT * FROM Purchasing_PO", dgvPO)
        tglPO.Enabled = False
        DateTimePicker2.Enabled = False
        cmbTOP.Enabled = False

        nomorPO.Text = txtnoPO.Text
        Call kondisiawal()
        Call POKODE()
    End Sub

    ' cancel
    Private Sub btncancelPO_Click(sender As Object, e As EventArgs)
        clearForm(txtalamat, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)

        matiForm(txtalamat, txtnoPO, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)
        tglPO.Enabled = False
        DateTimePicker2.Enabled = False
        cmbTOP.Enabled = False
    End Sub

    'exit
    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Dim a As New FormMenuUtama
        Me.Close()
        a.Show()
    End Sub

    'KLIK DGV
    'Private Sub dgvPO_MouseClick(sender As Object, e As DataGridViewCellEventArgs)


    'cancel
    Private Sub btncancelPO_Click_1(sender As Object, e As EventArgs) Handles btncancelPO.Click
        clearForm(txtalamat, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)
        matiForm(txtalamat, txtnoPO, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)
        enableButton(btninputPO, btnexit, btncekkebutuhan, btncetakPO)
    End Sub

    'nomor faktur
    Sub POKODE()
        Call koneksiDB()
        CMD = New OleDb.OleDbCommand("select * from Purchasing_PO where No_PO in (select max(No_PO) from Purchasing_PO)", Conn)
        DM = CMD.ExecuteReader
        DM.Read()
        Dim urutankode As String
        Dim hitung As Long
        If Not DM.HasRows Then
            urutankode = "PO" + Format(Now, "yyMMdd") + "001"
        Else
            hitung = Microsoft.VisualBasic.Right(DM.GetString(0), 9) + 1
            urutankode = "PO" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        txtnoPO.Text = urutankode
    End Sub

    'kondisi awal
    Sub kondisiawal()

        tglPO.Text = Today
    End Sub

    Private Sub btncekkebutuhan_Click_1(sender As Object, e As EventArgs) Handles btncekkebutuhan.Click
        tampilkanData("SELECT * FROM RM_inputRequirement", dgvReqRM)
    End Sub

    'input
    Private Sub btninputPO_Click_1(sender As Object, e As EventArgs) Handles btninputPO.Click
        Call POKODE()
        nyalainForm(txtalamat, txtnoPO, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)
        clearForm(txtalamat, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)
        enableButton(btnsavePO, btneditPO, btnexit, btninputPO, btncetakPO, btndeletePO, btncancelPO)
        tglPO.Enabled = True
        DateTimePicker2.Enabled = True
        cmbTOP.Enabled = True
        RichTextBox1.Text = " "
    End Sub

    'EDIT NYA MASIH SYNTAX ERROR    
    Private Sub btneditPO_Click(sender As Object, e As EventArgs) Handles btneditPO.Click
        If (checkEmpty(txtalamat, txtnoPO, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM) = True) Then
            MessageBox.Show("Lengkapi Dulu")
            Exit Sub
        Else
            Call koneksiDB()
            CMD = New OleDb.OleDbCommand(" update Purchasing_PO set Tgl_PO = '" & tglPO.Value.Date.ToShortDateString & "',  Pemasok = '" & txtsupplier.Text & "', Alamat_Kirim = '" & txtalamat.Text & "', Nama_Pemesan = '" & txtpemesan.Text & "', Tgl_Kirim = '" & DateTimePicker2.Value.Date.ToShortDateString & "', TOP = '" & cmbTOP.Text & "', Keterangan = '" & RichTextBox1.Text & "', kode_RM = '" & kodeRM.Text & "', nama_RM = '" & namaRM.Text & "', jlh_RM = '" & jlhRM.Text & "', satuan_RM = '" & satuan.Text & "', harga_RM = '" & hargaRM.Text & "' where No_PO = '" & txtnoPO.Text & "'", Conn)
            DM = CMD.ExecuteReader
            MessageBox.Show("Yatta! berhasil")
            clearForm(txtalamat, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)
            tampilkanData("SELECT * FROM Purchasing_PO", dgvPO)
        End If
    End Sub

    Private Sub btndeletePO_Click_1(sender As Object, e As EventArgs) Handles btndeletePO.Click
        If (checkEmpty(txtalamat, txtnoPO, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM) = True) Then
            MessageBox.Show("Jangan kosong")
        Else
            hapusData("Purchasing_PO", "No_PO", txtnoPO.Text)
            tampilkanData("SELECT * FROM Purchasing_PO", dgvPO)
        End If

        enableButton(btnsavePO, btneditPO, btnexit, btninputPO, btncetakPO, btndeletePO, btncancelPO)
    End Sub

    Private Sub btnsavePO_Click_1(sender As Object, e As EventArgs) Handles btnsavePO.Click
        If (checkEmpty(txtalamat, txtnoPO, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM) = True) Then
            MessageBox.Show("Jangan kosong")
        Else
            Dim winny As Boolean = checkDuplicate("Purchasing_PO", "No_PO", txtnoPO.Text)
            If winny = True Then
                MessageBox.Show("KODE Duplikat")
            Else
                'txtKelaminPeg.Text = Cbxkelamin.SelectedItem.ToString
                'txtJabatanPeg.Text = cbxjabatan.SelectedItem.ToString
                simpanData("Purchasing_PO", txtnoPO.Text, tglPO.Value.ToString, txtsupplier.Text, txtalamat.Text, txtpemesan.Text, DateTimePicker2.Value.ToString, cmbTOP.SelectedItem.ToString, RichTextBox1.Text, kodeRM.Text, namaRM.Text, jlhRM.Text, satuan.Text, hargaRM.Text)
                MessageBox.Show("Data Tersimpan")
                tampilkanData("SELECT * FROM Purchasing_PO", dgvPO)
                clearForm(txtalamat, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)

            End If
        End If
    End Sub


    'Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
    Private Sub dgvPO_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPO.CellMouseClick
        On Error Resume Next
        txtnoPO.Text = dgvPO.Rows(e.RowIndex).Cells(0).Value
        tglPO.Text = dgvPO.Rows(e.RowIndex).Cells(1).Value
        txtsupplier.Text = dgvPO.Rows(e.RowIndex).Cells(2).Value
        txtalamat.Text = dgvPO.Rows(e.RowIndex).Cells(3).Value
        txtpemesan.Text = dgvPO.Rows(e.RowIndex).Cells(4).Value
        DateTimePicker2.Text = dgvPO.Rows(e.RowIndex).Cells(5).Value
        cmbTOP.Text = dgvPO.Rows(e.RowIndex).Cells(6).Value
        RichTextBox1.Text = dgvPO.Rows(e.RowIndex).Cells(7).Value
        kodeRM.Text = dgvPO.Rows(e.RowIndex).Cells(8).Value
        namaRM.Text = dgvPO.Rows(e.RowIndex).Cells(9).Value
        jlhRM.Text = dgvPO.Rows(e.RowIndex).Cells(10).Value
        satuan.Text = dgvPO.Rows(e.RowIndex).Cells(11).Value
        hargaRM.Text = dgvPO.Rows(e.RowIndex).Cells(12).Value

        nyalainForm(txtalamat, txtnoPO, txtpemesan, txtsupplier, namaRM, kodeRM, satuan, hargaRM, jlhRM)
        tglPO.Enabled = True
        DateTimePicker2.Enabled = True
        cmbTOP.Enabled = True
        enableButton(btnsavePO, btneditPO, btnexit, btninputPO, btncetakPO, btndeletePO, btncancelPO, btncekkebutuhan)
    End Sub

    'keypress
    Private Sub kodeRM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles kodeRM.KeyPress
        If e.KeyChar = Chr(13) Then
            'Chr(13) itu Tombol ENTER
            Call koneksiDB()
            CMD = New OleDb.OleDbCommand("Select * from RM_inventori where kode_RM ='" & kodeRM.Text & "'", Conn)
            DM = CMD.ExecuteReader
            DM.Read()
            If Not DM.HasRows Then
                MessageBox.Show("Kode Barang Tidak Ada")
            Else
                kodeRM.Text = DM.Item("kode_RM")
                namaRM.Text = DM.Item("nama_RM")
                hargaRM.Text = DM.Item("harga")
                satuan.Text = DM.Item("satuan_RM")
                jlhRM.Enabled = True
                jlhRM.Focus()

            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nyalainForm(nomorInv, pengirim, totalbiaya, poto)
        clearForm(nomorInv, pengirim, totalbiaya, poto)
        ' Dim kei As String
        'kei = txtnamapotokasir.Text
        'PictureBox1.Image = New Bitmap(kei)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        matiForm(nomorInv, pengirim, totalbiaya, poto)
        clearForm(nomorInv, pengirim, totalbiaya, poto)
    End Sub

    Private Sub btnsavedetailbayar_Click(sender As Object, e As EventArgs) Handles btnsavedetailbayar.Click
        If (checkEmpty(nomorPO, nomorInv, pengirim, totalbiaya, tglkirim) = True) Then
            MessageBox.Show("Jangan kosong")
        Else
            Dim winny As Boolean = checkDuplicate("Purchasing_Penerimaan", "No_PO", txtnoPO.Text)
            If winny = True Then
                MessageBox.Show("KODE Duplikat")
            Else
                'txtKelaminPeg.Text = Cbxkelamin.SelectedItem.ToString
                'txtJabatanPeg.Text = cbxjabatan.SelectedItem.ToString
                simpanData("Purchasing_Penerimaan", nomorPO.Text, nomorInv.Text, pengirim.Text, totalbiaya.Text, tglkirim.Text, tglterima.Value.Date.ToShortDateString, poto.Text)
                'MessageBox.Show("Data Tersimpan")
                'tampilkanData("SELECT * FROM Purchasing_Penerimaan", d)
                clearForm(nomorInv, pengirim, totalbiaya, tglkirim)

            End If
        End If
    End Sub

    Private Sub btnuploadbukti_Click(sender As Object, e As EventArgs) Handles btnuploadbukti.Click
        Try
            OpenFileDialog1.Filter = " Image File(*.jpeg;*jpg;*.png;*.bmp;*.gif)| *.jpeg;*jpg;*.png;*.bmp;*.gif"
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                PictureBox1.Image = New Bitmap(OpenFileDialog1.FileName)
                poto.Text = OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            Throw New ApplicationException("Gambar Gagal Masuk")
        End Try
    End Sub
End Class