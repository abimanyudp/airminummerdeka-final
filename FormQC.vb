Public Class FormQC
    'INPUT
    Private Sub btninputqc_Click(sender As Object, e As EventArgs) Handles btninputqc.Click
        nyalainForm(txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtkodekontrol, txtkodeproduk, txtnamaSPV, txtnoproduksi)
        clearForm(txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtkodekontrol, txtkodeproduk, txtnamaSPV, txtnoproduksi)
        btninputqc.Enabled = False
        btnsaveqc.Enabled = True
    End Sub

    'EXIT
    Private Sub btnexitqc_Click(sender As Object, e As EventArgs) Handles btnexitqc.Click
        Dim a As New FormMenuUtama
        a.Show()
        Me.Close()

    End Sub

    'CANCEL
    Private Sub btncancelqc_Click(sender As Object, e As EventArgs) Handles btncancelqc.Click
        clearForm(txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtkodekontrol, txtkodeproduk, txtnamaSPV, txtnoproduksi)
        matiForm(txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtkodekontrol, txtkodeproduk, txtnamaSPV, txtnoproduksi)
    End Sub

    'klik datagridview

    Dim DGV As DataGridView
    Private Sub DGV_MouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        DGV = DataGridView1
        'showtoBox(e.RowIndex, DataGridView1, tglproduksi, cmbtipeproduk, tglkontrol, txtkodekontrol, txtnoproduksi, txtkodeproduk, txtjlhproduksi, txtjlhdefect, txtjlhlayak, txtnamaSPV)
        txtkodekontrol.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        txtnoproduksi.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        cmbtipeproduk.Text = DGV.Rows(e.RowIndex).Cells(2).Value
        txtkodeproduk.Text = DGV.Rows(e.RowIndex).Cells(3).Value
        tglproduksi.Text = DGV.Rows(e.RowIndex).Cells(4).Value
        txtjlhproduksi.Text = DGV.Rows(e.RowIndex).Cells(5).Value
        tglkontrol.Text = DGV.Rows(e.RowIndex).Cells(6).Value
        txtjlhdefect.Text = DGV.Rows(e.RowIndex).Cells(7).Value
        txtjlhlayak.Text = DGV.Rows(e.RowIndex).Cells(8).Value
        txtnamaSPV.Text = DGV.Rows(e.RowIndex).Cells(9).Value
        nyalainForm(txtkodekontrol, txtnoproduksi, txtkodeproduk, txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtnamaSPV)
        enableButton(btneditqc, btndeleteqc, btnsaveqc)
        btninputqc.Enabled = True
        'txtkodekontrol.Enabled = False
    End Sub

    'save
    Private Sub btnsaveqc_Click(sender As Object, e As EventArgs) Handles btnsaveqc.Click
        If (checkEmpty(txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtkodekontrol, txtkodeproduk, txtnamaSPV) = True) Then
            MessageBox.Show("Jangan kosong")
        Else
            Dim winny As Boolean = checkDuplicate("QC_datareject", "kode_kontrol", txtkodekontrol.Text)
            If winny = True Then
                MessageBox.Show("KODE Duplikat")
            Else
                'txtKelaminPeg.Text = Cbxkelamin.SelectedItem.ToString
                'txtJabatanPeg.Text = cbxjabatan.SelectedItem.ToString
                simpanData("QC_datareject", txtkodekontrol.Text, txtnoproduksi.Text, cmbtipeproduk.SelectedItem.ToString, txtkodeproduk.Text, tglproduksi.Value.ToString, txtjlhproduksi.Text, tglkontrol.Value.ToString, txtjlhdefect.Text, txtjlhlayak.Text, txtnamaSPV.Text)
                'MessageBox.Show("Data Tersimpan")
                tampilkanData("SELECT * FROM QC_datareject", DataGridView1)
                clearForm(txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtkodekontrol, txtkodeproduk, txtnoproduksi, txtnamaSPV)
            End If
        End If
    End Sub

    'LOAD 
    Private Sub FormQC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        matiForm(txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtkodekontrol, txtkodeproduk, txtnamaSPV, txtnoproduksi)
        tampilkanData("SELECT * FROM QC_datareject", DataGridView1)
        btnsaveqc.Enabled = False
        btneditqc.Enabled = False
        btndeleteqc.Enabled = False

    End Sub

    'EDIT
    Private Sub btneditqc_Click(sender As Object, e As EventArgs) Handles btneditqc.Click
        If (checkEmpty(txtkodekontrol, txtkodeproduk, txtnoproduksi, txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtnamaSPV) = True) Then
            MessageBox.Show("Lengkapi Dulu")
            Exit Sub
        Else
            tglkontrol.Text = tglkontrol.Value.ToString
            tglproduksi.Text = tglproduksi.Value.ToString
            cmbtipeproduk.Text = cmbtipeproduk.SelectedItem.ToString
            updateData("QC_datareject", "kode_kontrol", txtkodekontrol.Text, "no_produksi", txtnoproduksi.Text, "tipe_produk", cmbtipeproduk.Text, "kode_produk", txtkodeproduk.Text, "tgl_produksi", tglproduksi.Text, "jlh_produksiFG", txtjlhproduksi.Text, "tgl_kontrol", tglkontrol.Text, "jlh_defect", txtjlhdefect.Text, "jlh_layak", txtjlhlayak.Text, "nama_spv", txtnamaSPV.Text)
            'Call koneksiDB()
            'CMD = New OleDb.OleDbCommand("UPDATE QC_datareject SET no_produksi='" & txtnoproduksi.Text = "', tipe_produk ='" & cmbtipeproduk.Text & "',kode_produk = '" & txtkodeproduk.Text & "',tgl_produksi = '" & tglproduksi.Text & "',jlh_produksiFG = '" & txtjlhproduksi.Text & "',tgl_kontrol = '" & tglkontrol.Text & "',jlh_defect = '" & txtjlhdefect.Text & "',jlh_layak = '" & txtjlhlayak.Text & "',nama_spv = '" & txtnamaSPV.Text & "' where kode_kontrol ='" & txtkodekontrol.Text & "'", Conn)
            'DM = CMD.ExecuteReader
            'MessageBox.Show("UPDATE oke")

            tampilkanData("SELECT * FROM QC_datareject", DataGridView1)
            clearForm(txtkodekontrol, txtnoproduksi, txtkodeproduk, txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtnamaSPV)

        End If
    End Sub


    'delete
    Private Sub btndeleteqc_Click(sender As Object, e As EventArgs) Handles btndeleteqc.Click
        If (checkEmpty(txtjlhdefect, txtjlhlayak, txtjlhproduksi, txtkodekontrol, txtkodeproduk, txtnamaSPV, txtnoproduksi) = True) Then
            MessageBox.Show("Jangan kosong")
        Else

            hapusData("QC_datareject", "kode_kontrol", txtkodekontrol.Text)
            tampilkanData("SELECT * FROM QC_datareject", DataGridView1)
        End If
        btndeleteqc.Enabled = True
        btneditqc.Enabled = True
        btnsaveqc.Enabled = True
        btninputqc.Enabled = True
    End Sub
End Class