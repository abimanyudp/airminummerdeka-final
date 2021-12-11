<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormKaryawan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtjeniskelamin = New System.Windows.Forms.ComboBox()
        Me.txtumurkasir = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbstatus = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rtbalamat = New System.Windows.Forms.RichTextBox()
        Me.txtnohp = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btncari = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txttemplar = New System.Windows.Forms.TextBox()
        Me.txtnamakasir = New System.Windows.Forms.TextBox()
        Me.txtkodekasir = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btntelusuri = New System.Windows.Forms.Button()
        Me.btnsimpan = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtnamapotokasir = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btninputkasir = New System.Windows.Forms.Button()
        Me.btncaridgv = New System.Windows.Forms.Button()
        Me.txtcaridgv = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btneditkasir = New System.Windows.Forms.Button()
        Me.btncancelkasir = New System.Windows.Forms.Button()
        Me.btnexitkasir = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtjeniskelamin)
        Me.GroupBox1.Controls.Add(Me.txtumurkasir)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbstatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.rtbalamat)
        Me.GroupBox1.Controls.Add(Me.txtnohp)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btncari)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txttemplar)
        Me.GroupBox1.Controls.Add(Me.txtnamakasir)
        Me.GroupBox1.Controls.Add(Me.txtkodekasir)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 424)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input Data Kasir"
        '
        'txtjeniskelamin
        '
        Me.txtjeniskelamin.FormattingEnabled = True
        Me.txtjeniskelamin.Items.AddRange(New Object() {"Laki-Laki", "Perempuan"})
        Me.txtjeniskelamin.Location = New System.Drawing.Point(156, 202)
        Me.txtjeniskelamin.Name = "txtjeniskelamin"
        Me.txtjeniskelamin.Size = New System.Drawing.Size(179, 21)
        Me.txtjeniskelamin.TabIndex = 22
        Me.txtjeniskelamin.Text = "Pilih"
        '
        'txtumurkasir
        '
        Me.txtumurkasir.Location = New System.Drawing.Point(156, 382)
        Me.txtumurkasir.Name = "txtumurkasir"
        Me.txtumurkasir.Size = New System.Drawing.Size(179, 20)
        Me.txtumurkasir.TabIndex = 19
        Me.txtumurkasir.Text = " "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(35, 382)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Umur"
        '
        'cmbstatus
        '
        Me.cmbstatus.FormattingEnabled = True
        Me.cmbstatus.Items.AddRange(New Object() {"Admin", "Produksi", "QC", "Purchasing", "Marketing", "Warehouse RM", "Warehouse FG"})
        Me.cmbstatus.Location = New System.Drawing.Point(156, 340)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(179, 21)
        Me.cmbstatus.TabIndex = 16
        Me.cmbstatus.Text = "Pilih"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Departmen"
        '
        'rtbalamat
        '
        Me.rtbalamat.Location = New System.Drawing.Point(156, 278)
        Me.rtbalamat.Name = "rtbalamat"
        Me.rtbalamat.Size = New System.Drawing.Size(179, 56)
        Me.rtbalamat.TabIndex = 14
        Me.rtbalamat.Text = ""
        '
        'txtnohp
        '
        Me.txtnohp.Location = New System.Drawing.Point(156, 238)
        Me.txtnohp.Name = "txtnohp"
        Me.txtnohp.Size = New System.Drawing.Size(179, 20)
        Me.txtnohp.TabIndex = 13
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(156, 166)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(179, 20)
        Me.DateTimePicker1.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Alamat"
        '
        'btncari
        '
        Me.btncari.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btncari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btncari.Location = New System.Drawing.Point(260, 6)
        Me.btncari.Name = "btncari"
        Me.btncari.Size = New System.Drawing.Size(75, 23)
        Me.btncari.TabIndex = 1
        Me.btncari.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 241)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "No. Telepon"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Jenis Kelamin"
        '
        'txttemplar
        '
        Me.txttemplar.Location = New System.Drawing.Point(156, 126)
        Me.txttemplar.Name = "txttemplar"
        Me.txttemplar.Size = New System.Drawing.Size(179, 20)
        Me.txttemplar.TabIndex = 6
        '
        'txtnamakasir
        '
        Me.txtnamakasir.Location = New System.Drawing.Point(156, 83)
        Me.txtnamakasir.Name = "txtnamakasir"
        Me.txtnamakasir.Size = New System.Drawing.Size(179, 20)
        Me.txtnamakasir.TabIndex = 5
        '
        'txtkodekasir
        '
        Me.txtkodekasir.Location = New System.Drawing.Point(156, 47)
        Me.txtkodekasir.Name = "txtkodekasir"
        Me.txtkodekasir.Size = New System.Drawing.Size(179, 20)
        Me.txtkodekasir.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tanggal Lahir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tempat lahir"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Kasir"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Kasir"
        '
        'btntelusuri
        '
        Me.btntelusuri.Location = New System.Drawing.Point(747, 214)
        Me.btntelusuri.Name = "btntelusuri"
        Me.btntelusuri.Size = New System.Drawing.Size(75, 23)
        Me.btntelusuri.TabIndex = 2
        Me.btntelusuri.Text = "Telusuri File"
        Me.btntelusuri.UseVisualStyleBackColor = True
        '
        'btnsimpan
        '
        Me.btnsimpan.Location = New System.Drawing.Point(628, 309)
        Me.btnsimpan.Name = "btnsimpan"
        Me.btnsimpan.Size = New System.Drawing.Size(75, 23)
        Me.btnsimpan.TabIndex = 3
        Me.btnsimpan.Text = "Save"
        Me.btnsimpan.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(628, 279)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(75, 23)
        Me.btndelete.TabIndex = 4
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(412, 61)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(414, 133)
        Me.DataGridView1.TabIndex = 5
        '
        'txtnamapotokasir
        '
        Me.txtnamapotokasir.Location = New System.Drawing.Point(628, 214)
        Me.txtnamapotokasir.Name = "txtnamapotokasir"
        Me.txtnamapotokasir.Size = New System.Drawing.Size(97, 20)
        Me.txtnamapotokasir.TabIndex = 17
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btninputkasir
        '
        Me.btninputkasir.Location = New System.Drawing.Point(628, 250)
        Me.btninputkasir.Name = "btninputkasir"
        Me.btninputkasir.Size = New System.Drawing.Size(75, 23)
        Me.btninputkasir.TabIndex = 18
        Me.btninputkasir.Text = "Input"
        Me.btninputkasir.UseVisualStyleBackColor = True
        '
        'btncaridgv
        '
        Me.btncaridgv.Location = New System.Drawing.Point(757, 367)
        Me.btncaridgv.Name = "btncaridgv"
        Me.btncaridgv.Size = New System.Drawing.Size(75, 23)
        Me.btncaridgv.TabIndex = 19
        Me.btncaridgv.Text = "Cari"
        Me.btncaridgv.UseVisualStyleBackColor = True
        '
        'txtcaridgv
        '
        Me.txtcaridgv.Location = New System.Drawing.Point(628, 369)
        Me.txtcaridgv.Name = "txtcaridgv"
        Me.txtcaridgv.Size = New System.Drawing.Size(123, 20)
        Me.txtcaridgv.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(188, 223)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(412, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 248)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Foto Diri"
        '
        'btneditkasir
        '
        Me.btneditkasir.Location = New System.Drawing.Point(747, 250)
        Me.btneditkasir.Name = "btneditkasir"
        Me.btneditkasir.Size = New System.Drawing.Size(75, 23)
        Me.btneditkasir.TabIndex = 22
        Me.btneditkasir.Text = "Edit"
        Me.btneditkasir.UseVisualStyleBackColor = True
        '
        'btncancelkasir
        '
        Me.btncancelkasir.Location = New System.Drawing.Point(747, 279)
        Me.btncancelkasir.Name = "btncancelkasir"
        Me.btncancelkasir.Size = New System.Drawing.Size(75, 23)
        Me.btncancelkasir.TabIndex = 23
        Me.btncancelkasir.Text = "Cancel"
        Me.btncancelkasir.UseVisualStyleBackColor = True
        '
        'btnexitkasir
        '
        Me.btnexitkasir.Location = New System.Drawing.Point(725, 12)
        Me.btnexitkasir.Name = "btnexitkasir"
        Me.btnexitkasir.Size = New System.Drawing.Size(101, 23)
        Me.btnexitkasir.TabIndex = 24
        Me.btnexitkasir.Text = "Menu Utama"
        Me.btnexitkasir.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(26, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 20)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Selamat Datang!"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Bahnschrift", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(178, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 23)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = ":)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(718, 341)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 20)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "CETAK ID CARD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 499)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnexitkasir)
        Me.Controls.Add(Me.btncancelkasir)
        Me.Controls.Add(Me.btneditkasir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtcaridgv)
        Me.Controls.Add(Me.btncaridgv)
        Me.Controls.Add(Me.btninputkasir)
        Me.Controls.Add(Me.txtnamapotokasir)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnsimpan)
        Me.Controls.Add(Me.btntelusuri)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormKaryawan"
        Me.Text = "Form Karyawan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents rtbalamat As RichTextBox
    Friend WithEvents txtnohp As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txttemplar As TextBox
    Friend WithEvents txtnamakasir As TextBox
    Friend WithEvents txtkodekasir As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btncari As Button
    Friend WithEvents btntelusuri As Button
    Friend WithEvents btnsimpan As Button
    Friend WithEvents btndelete As Button
    Friend WithEvents cmbstatus As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtnamapotokasir As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btninputkasir As Button
    Friend WithEvents btncaridgv As Button
    Friend WithEvents txtcaridgv As TextBox
    Friend WithEvents txtumurkasir As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btneditkasir As Button
    Friend WithEvents btncancelkasir As Button
    Friend WithEvents btnexitkasir As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtjeniskelamin As ComboBox
    Friend WithEvents Button1 As Button
End Class
