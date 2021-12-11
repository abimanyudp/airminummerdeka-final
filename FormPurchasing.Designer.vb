<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurchasing
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvReqRM = New System.Windows.Forms.DataGridView()
        Me.btncekkebutuhan = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btncancelPO = New System.Windows.Forms.Button()
        Me.btncetakPO = New System.Windows.Forms.Button()
        Me.btninputPO = New System.Windows.Forms.Button()
        Me.dgvPO = New System.Windows.Forms.DataGridView()
        Me.btnsavePO = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.satuan = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.hargaRM = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.jlhRM = New System.Windows.Forms.TextBox()
        Me.namaRM = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.kodeRM = New System.Windows.Forms.TextBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.btndeletePO = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btneditPO = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.txtpemesan = New System.Windows.Forms.TextBox()
        Me.txtalamat = New System.Windows.Forms.TextBox()
        Me.txtsupplier = New System.Windows.Forms.TextBox()
        Me.tglPO = New System.Windows.Forms.DateTimePicker()
        Me.txtnoPO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTOP = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtnamapotokasir = New System.Windows.Forms.TextBox()
        Me.btntelusuri = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.nomorPO = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tglkirim = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.totalbiaya = New System.Windows.Forms.TextBox()
        Me.pengirim = New System.Windows.Forms.TextBox()
        Me.nomorInv = New System.Windows.Forms.TextBox()
        Me.poto = New System.Windows.Forms.TextBox()
        Me.btnsavedetailbayar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnuploadbukti = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tglterima = New System.Windows.Forms.DateTimePicker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvReqRM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnexit
        '
        Me.btnexit.Location = New System.Drawing.Point(645, 436)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnexit.Size = New System.Drawing.Size(87, 39)
        Me.btnexit.TabIndex = 56
        Me.btnexit.Text = "EXIT"
        Me.btnexit.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(796, 672)
        Me.TabControl1.TabIndex = 57
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvReqRM)
        Me.TabPage1.Controls.Add(Me.btncekkebutuhan)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(788, 644)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Buat Pesanan"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvReqRM
        '
        Me.dgvReqRM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReqRM.Location = New System.Drawing.Point(171, 8)
        Me.dgvReqRM.Name = "dgvReqRM"
        Me.dgvReqRM.RowTemplate.Height = 25
        Me.dgvReqRM.Size = New System.Drawing.Size(599, 97)
        Me.dgvReqRM.TabIndex = 34
        '
        'btncekkebutuhan
        '
        Me.btncekkebutuhan.Location = New System.Drawing.Point(12, 45)
        Me.btncekkebutuhan.Name = "btncekkebutuhan"
        Me.btncekkebutuhan.Size = New System.Drawing.Size(153, 23)
        Me.btncekkebutuhan.TabIndex = 33
        Me.btncekkebutuhan.Text = "Cek Kebutuhan"
        Me.btncekkebutuhan.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btncancelPO)
        Me.GroupBox1.Controls.Add(Me.btnexit)
        Me.GroupBox1.Controls.Add(Me.btncetakPO)
        Me.GroupBox1.Controls.Add(Me.btninputPO)
        Me.GroupBox1.Controls.Add(Me.dgvPO)
        Me.GroupBox1.Controls.Add(Me.btnsavePO)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.btndeletePO)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btneditPO)
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Controls.Add(Me.txtpemesan)
        Me.GroupBox1.Controls.Add(Me.txtalamat)
        Me.GroupBox1.Controls.Add(Me.txtsupplier)
        Me.GroupBox1.Controls.Add(Me.tglPO)
        Me.GroupBox1.Controls.Add(Me.txtnoPO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbTOP)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 111)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(758, 502)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input PO"
        '
        'btncancelPO
        '
        Me.btncancelPO.Location = New System.Drawing.Point(28, 436)
        Me.btncancelPO.Name = "btncancelPO"
        Me.btncancelPO.Size = New System.Drawing.Size(87, 39)
        Me.btncancelPO.TabIndex = 52
        Me.btncancelPO.Text = "Cancel"
        Me.btncancelPO.UseVisualStyleBackColor = True
        '
        'btncetakPO
        '
        Me.btncetakPO.Location = New System.Drawing.Point(497, 436)
        Me.btncetakPO.Name = "btncetakPO"
        Me.btncetakPO.Size = New System.Drawing.Size(87, 39)
        Me.btncetakPO.TabIndex = 51
        Me.btncetakPO.Text = "CETAK PO"
        Me.btncetakPO.UseVisualStyleBackColor = True
        '
        'btninputPO
        '
        Me.btninputPO.Location = New System.Drawing.Point(125, 436)
        Me.btninputPO.Name = "btninputPO"
        Me.btninputPO.Size = New System.Drawing.Size(87, 39)
        Me.btninputPO.TabIndex = 46
        Me.btninputPO.Text = "Input"
        Me.btninputPO.UseVisualStyleBackColor = True
        '
        'dgvPO
        '
        Me.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPO.Location = New System.Drawing.Point(333, 173)
        Me.dgvPO.Name = "dgvPO"
        Me.dgvPO.RowTemplate.Height = 25
        Me.dgvPO.Size = New System.Drawing.Size(410, 238)
        Me.dgvPO.TabIndex = 30
        '
        'btnsavePO
        '
        Me.btnsavePO.Location = New System.Drawing.Point(404, 436)
        Me.btnsavePO.Name = "btnsavePO"
        Me.btnsavePO.Size = New System.Drawing.Size(87, 39)
        Me.btnsavePO.TabIndex = 50
        Me.btnsavePO.Text = "SAVE"
        Me.btnsavePO.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.satuan)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.hargaRM)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.jlhRM)
        Me.GroupBox2.Controls.Add(Me.namaRM)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.kodeRM)
        Me.GroupBox2.Location = New System.Drawing.Point(62, 173)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(238, 238)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail Bahan Baku"
        '
        'satuan
        '
        Me.satuan.Location = New System.Drawing.Point(115, 151)
        Me.satuan.Name = "satuan"
        Me.satuan.Size = New System.Drawing.Size(94, 23)
        Me.satuan.TabIndex = 35
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 159)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 15)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Satuan"
        '
        'hargaRM
        '
        Me.hargaRM.Location = New System.Drawing.Point(115, 194)
        Me.hargaRM.Name = "hargaRM"
        Me.hargaRM.Size = New System.Drawing.Size(94, 23)
        Me.hargaRM.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 202)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 15)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Harga Barang"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 15)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Jumlah Barang"
        '
        'jlhRM
        '
        Me.jlhRM.Location = New System.Drawing.Point(115, 113)
        Me.jlhRM.Name = "jlhRM"
        Me.jlhRM.Size = New System.Drawing.Size(94, 23)
        Me.jlhRM.TabIndex = 30
        '
        'namaRM
        '
        Me.namaRM.Location = New System.Drawing.Point(115, 75)
        Me.namaRM.Name = "namaRM"
        Me.namaRM.Size = New System.Drawing.Size(94, 23)
        Me.namaRM.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Nama Barang"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 15)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Kode Barang"
        '
        'kodeRM
        '
        Me.kodeRM.Location = New System.Drawing.Point(115, 34)
        Me.kodeRM.Name = "kodeRM"
        Me.kodeRM.Size = New System.Drawing.Size(94, 23)
        Me.kodeRM.TabIndex = 23
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(516, 16)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(194, 23)
        Me.DateTimePicker2.TabIndex = 27
        '
        'btndeletePO
        '
        Me.btndeletePO.Location = New System.Drawing.Point(311, 436)
        Me.btndeletePO.Name = "btndeletePO"
        Me.btndeletePO.Size = New System.Drawing.Size(87, 39)
        Me.btndeletePO.TabIndex = 48
        Me.btndeletePO.Text = "Delete"
        Me.btndeletePO.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(412, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 15)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Tanggal Kirim"
        '
        'btneditPO
        '
        Me.btneditPO.Location = New System.Drawing.Point(218, 436)
        Me.btneditPO.Name = "btneditPO"
        Me.btneditPO.Size = New System.Drawing.Size(87, 39)
        Me.btneditPO.TabIndex = 47
        Me.btneditPO.Text = "Edit"
        Me.btneditPO.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(516, 77)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(194, 79)
        Me.RichTextBox1.TabIndex = 25
        Me.RichTextBox1.Text = ""
        '
        'txtpemesan
        '
        Me.txtpemesan.Location = New System.Drawing.Point(177, 133)
        Me.txtpemesan.Name = "txtpemesan"
        Me.txtpemesan.Size = New System.Drawing.Size(153, 23)
        Me.txtpemesan.TabIndex = 22
        '
        'txtalamat
        '
        Me.txtalamat.Location = New System.Drawing.Point(177, 103)
        Me.txtalamat.Name = "txtalamat"
        Me.txtalamat.Size = New System.Drawing.Size(153, 23)
        Me.txtalamat.TabIndex = 21
        '
        'txtsupplier
        '
        Me.txtsupplier.Location = New System.Drawing.Point(177, 74)
        Me.txtsupplier.Name = "txtsupplier"
        Me.txtsupplier.Size = New System.Drawing.Size(153, 23)
        Me.txtsupplier.TabIndex = 20
        '
        'tglPO
        '
        Me.tglPO.Location = New System.Drawing.Point(177, 45)
        Me.tglPO.Name = "tglPO"
        Me.tglPO.Size = New System.Drawing.Size(153, 23)
        Me.tglPO.TabIndex = 19
        '
        'txtnoPO
        '
        Me.txtnoPO.Location = New System.Drawing.Point(177, 16)
        Me.txtnoPO.Name = "txtnoPO"
        Me.txtnoPO.Size = New System.Drawing.Size(153, 23)
        Me.txtnoPO.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(412, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Keterangan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(412, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Term of Payment"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(73, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Nama Pemesan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Alamat Kirim"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Pemasok"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Tanggal PO"
        '
        'cmbTOP
        '
        Me.cmbTOP.FormattingEnabled = True
        Me.cmbTOP.Items.AddRange(New Object() {"Net d Days", "Net EOM", "In Advance"})
        Me.cmbTOP.Location = New System.Drawing.Point(516, 48)
        Me.cmbTOP.Name = "cmbTOP"
        Me.cmbTOP.Size = New System.Drawing.Size(194, 23)
        Me.cmbTOP.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(76, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "No.PO"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtnamapotokasir)
        Me.TabPage2.Controls.Add(Me.btntelusuri)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(788, 644)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Transaksi"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtnamapotokasir
        '
        Me.txtnamapotokasir.Location = New System.Drawing.Point(1111, 313)
        Me.txtnamapotokasir.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtnamapotokasir.Name = "txtnamapotokasir"
        Me.txtnamapotokasir.Size = New System.Drawing.Size(112, 23)
        Me.txtnamapotokasir.TabIndex = 20
        '
        'btntelusuri
        '
        Me.btntelusuri.Location = New System.Drawing.Point(1250, 313)
        Me.btntelusuri.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btntelusuri.Name = "btntelusuri"
        Me.btntelusuri.Size = New System.Drawing.Size(88, 27)
        Me.btntelusuri.TabIndex = 18
        Me.btntelusuri.Text = "Telusuri File"
        Me.btntelusuri.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.tglterima)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.nomorPO)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.tglkirim)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.totalbiaya)
        Me.GroupBox4.Controls.Add(Me.pengirim)
        Me.GroupBox4.Controls.Add(Me.nomorInv)
        Me.GroupBox4.Controls.Add(Me.poto)
        Me.GroupBox4.Controls.Add(Me.btnsavedetailbayar)
        Me.GroupBox4.Controls.Add(Me.PictureBox1)
        Me.GroupBox4.Controls.Add(Me.btnuploadbukti)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(717, 374)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detail Pembayaran"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(153, 293)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 39)
        Me.Button1.TabIndex = 68
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(257, 293)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 39)
        Me.Button2.TabIndex = 67
        Me.Button2.Text = "CETAK"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(152, 248)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 39)
        Me.Button3.TabIndex = 66
        Me.Button3.Text = "Input"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'nomorPO
        '
        Me.nomorPO.Location = New System.Drawing.Point(153, 19)
        Me.nomorPO.Name = "nomorPO"
        Me.nomorPO.Size = New System.Drawing.Size(176, 23)
        Me.nomorPO.TabIndex = 65
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(34, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 15)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "Nomor PO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(34, 204)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 15)
        Me.Label18.TabIndex = 62
        Me.Label18.Text = "Tanggal Diterima"
        '
        'tglkirim
        '
        Me.tglkirim.Location = New System.Drawing.Point(153, 161)
        Me.tglkirim.Name = "tglkirim"
        Me.tglkirim.Size = New System.Drawing.Size(176, 23)
        Me.tglkirim.TabIndex = 61
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(34, 164)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 15)
        Me.Label17.TabIndex = 60
        Me.Label17.Text = "Tanggal Kirim"
        '
        'totalbiaya
        '
        Me.totalbiaya.Location = New System.Drawing.Point(153, 125)
        Me.totalbiaya.Name = "totalbiaya"
        Me.totalbiaya.Size = New System.Drawing.Size(176, 23)
        Me.totalbiaya.TabIndex = 59
        '
        'pengirim
        '
        Me.pengirim.Location = New System.Drawing.Point(153, 92)
        Me.pengirim.Name = "pengirim"
        Me.pengirim.Size = New System.Drawing.Size(176, 23)
        Me.pengirim.TabIndex = 58
        '
        'nomorInv
        '
        Me.nomorInv.Location = New System.Drawing.Point(153, 58)
        Me.nomorInv.Name = "nomorInv"
        Me.nomorInv.Size = New System.Drawing.Size(176, 23)
        Me.nomorInv.TabIndex = 57
        '
        'poto
        '
        Me.poto.Location = New System.Drawing.Point(553, 29)
        Me.poto.Name = "poto"
        Me.poto.Size = New System.Drawing.Size(146, 23)
        Me.poto.TabIndex = 56
        '
        'btnsavedetailbayar
        '
        Me.btnsavedetailbayar.Location = New System.Drawing.Point(257, 248)
        Me.btnsavedetailbayar.Name = "btnsavedetailbayar"
        Me.btnsavedetailbayar.Size = New System.Drawing.Size(87, 39)
        Me.btnsavedetailbayar.TabIndex = 55
        Me.btnsavedetailbayar.Text = "SAVE"
        Me.btnsavedetailbayar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(379, 58)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(320, 215)
        Me.PictureBox1.TabIndex = 54
        Me.PictureBox1.TabStop = False
        '
        'btnuploadbukti
        '
        Me.btnuploadbukti.Location = New System.Drawing.Point(379, 29)
        Me.btnuploadbukti.Name = "btnuploadbukti"
        Me.btnuploadbukti.Size = New System.Drawing.Size(87, 23)
        Me.btnuploadbukti.TabIndex = 49
        Me.btnuploadbukti.Text = "Telusuri"
        Me.btnuploadbukti.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(34, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 15)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Nomor Invoice"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(34, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 15)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Nama Pengirim"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(34, 128)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 15)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Total Biaya"
        '
        'tglterima
        '
        Me.tglterima.Location = New System.Drawing.Point(153, 198)
        Me.tglterima.Name = "tglterima"
        Me.tglterima.Size = New System.Drawing.Size(176, 23)
        Me.tglterima.TabIndex = 69
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FormPurchasing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 685)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormPurchasing"
        Me.Text = "FormPurchasing"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvReqRM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnexit As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvReqRM As DataGridView
    Friend WithEvents btncekkebutuhan As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btncancelPO As Button
    Friend WithEvents btncetakPO As Button
    Friend WithEvents btninputPO As Button
    Friend WithEvents dgvPO As DataGridView
    Friend WithEvents btnsavePO As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents satuan As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents hargaRM As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents jlhRM As TextBox
    Friend WithEvents namaRM As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents kodeRM As TextBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents btndeletePO As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents btneditPO As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents txtpemesan As TextBox
    Friend WithEvents txtalamat As TextBox
    Friend WithEvents txtsupplier As TextBox
    Friend WithEvents tglPO As DateTimePicker
    Friend WithEvents txtnoPO As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTOP As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnsavedetailbayar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnuploadbukti As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtnamapotokasir As TextBox
    Friend WithEvents btntelusuri As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents totalbiaya As TextBox
    Friend WithEvents pengirim As TextBox
    Friend WithEvents nomorInv As TextBox
    Friend WithEvents poto As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents nomorPO As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents tglkirim As TextBox
    Friend WithEvents tglterima As DateTimePicker
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
