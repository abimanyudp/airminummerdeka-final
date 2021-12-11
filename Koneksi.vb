Imports System.Data.OleDb
Imports excel = Microsoft.Office.Interop.Excel
Module Koneksi
    Public Conn As OleDbConnection
    Public DA As OleDbDataAdapter
    Public DS As DataSet
    Public CMD As OleDbCommand
    Public DM As OleDbDataReader
    Sub koneksiDB()
        Try
            Conn = New OleDbConnection("provider=microsoft.ace.oledb.12.0; data source =Air Minum 1.accdb")
            Conn.Open()
            'MessageBox.Show("Koneksi OKE")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub matiForm(ParamArray var() As TextBox)
        For i As Integer = 0 To UBound(var, 1)
            var(i).Enabled = False
        Next i
    End Sub
    Sub nyalainForm(ParamArray var() As TextBox)
        For i As Integer = 0 To UBound(var, 1)
            var(i).Enabled = True
        Next
    End Sub

    'fungsi untuk clear textbox, kita cukup masukan textboxnya sebagai argumen.
    'Menggunakan paramarray jadi jumlah tak terbatas
    'Jika tidak menggunakan MetroUI, ganti TextBox menjadi TextBox
    Sub clearForm(ParamArray var() As TextBox)
        For i As Integer = 0 To UBound(var, 1)
            var(i).Clear()
        Next
    End Sub

    Sub enableButton(ParamArray winny() As Button)
        For i As Integer = 0 To UBound(winny, 1)
            winny(i).Enabled = True
        Next
    End Sub

    Sub disableButton(ParamArray winny() As Button)
        For i As Integer = 0 To UBound(winny, 1)
            winny(i).Enabled = False
        Next
    End Sub

    'Sub simpanData(namatabel As String, ParamArray var() As TextBox)
    'Dim sql As String = "insert into " + namatabel + " values("
    'For i As Integer = 0 To UBound(var, 1)
    'If i <> UBound(var, 1) Then
    '           sql = sql + "'" + var(i).Text + "',"
    'Else
    '           sql = sql + "'" + var(i).Text + "')"
    'End If
    '
    'Next
    '   CMD = New OleDb.OleDbCommand(sql, Conn)
    '  CMD.ExecuteNonQuery()
    ' MessageBox.Show("BERHAASIL")
    'matiForm(var)
    'clearForm(var)
    'enableButton()

    'End Sub

    Sub simpanData(namatabel As String, ParamArray var() As String)
        Dim sql As String = "insert into " + namatabel + " values("
        For i As Integer = 0 To UBound(var, 1)
            If i <> UBound(var, 1) Then
                sql = sql + "'" + var(i) + "',"
            Else
                sql = sql + "'" + var(i) + "')"
            End If

        Next
        CMD = New OleDb.OleDbCommand(sql, Conn)
        CMD.ExecuteNonQuery()
        MessageBox.Show("save data OKE")
        'matiForm(var)
        'clearForm(var)
        enableButton()

    End Sub
    'fungsi untuk menampilkan data, kita cukup masukan query SQL serta DataGridView yang dituju sebagai argumen.
    Sub tampilkanData(sequel As String, DGV As DataGridView)
        Call koneksiDB()
        DA = New OleDb.OleDbDataAdapter(sequel, Conn)
        DS = New DataSet
        DA.Fill(DS)

        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    'fungsi untuk cek apakah TextBox nya kosong. Menggunakan paramarray jadi jumlah argumen tak terbatas.
    'ubah MetroTextBox menjadi TextBox jika tidak menggunakan MetroUI
    'Akan menghasilkan True jika ada yang kosong, dan False jika terisi semua
    Function checkEmpty(ParamArray var() As TextBox) As Boolean
        Dim nomor As Integer = 0
        For i As Integer = 0 To UBound(var, 1)
            If (var(i).Text = "") Then
                nomor += 1
            End If
        Next
        If (nomor > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function checkEmpty2(ParamArray var() As ComboBox) As Boolean
        Dim nomor As Integer = 0
        For i As Integer = 0 To UBound(var, 1)
            If (var(i).Text = "") Then
                nomor += 1
            End If
        Next
        If (nomor > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Function checkEmpty3(ParamArray var() As DateTimePicker) As Boolean
        Dim nomor As Integer = 0
        For i As Integer = 0 To UBound(var, 1)
            If (var(i).Text = "") Then
                nomor += 1
            End If
        Next
        If (nomor > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    'fungsi untuk cek duplikat d database
    Function checkDuplicate(namatabel As String, namaid As String, idkonten As String)
        Dim sequel As String
        sequel = "select * from " + namatabel + " where " + namaid + " = '" + idkonten + "'"
        CMD = New OleDb.OleDbCommand(sequel, Conn)

        DM = CMD.ExecuteReader()
        DM.Read()

        If Not DM.HasRows Then
            Return False
        Else
            Return True
        End If

    End Function


    'fungsi untuk edit(update) data yang sudah tersimpan
    Sub updateData(namatabel As String, namaid As String, id As String, ParamArray var() As String)
        Dim sql As String
        sql = "update " + namatabel + " set "
        For i As Integer = 0 To UBound(var, 1) Step 2
            If i <> (UBound(var, 1) - 1) Then
                sql = sql + var(i) + " ='" + var(i + 1) + "', "

            Else
                sql = sql + var(i) + " ='" + var(i + 1) + "'"
            End If
        Next
        sql = sql + " where " + namaid + " = '" + id + "'"

        CMD = New OleDbCommand(sql, Conn)
        DM = CMD.ExecuteReader
        MessageBox.Show("Update oke")
    End Sub

    Sub showtoBox(row As Integer, DGV As DataGridView, tglproduksi As DateTimePicker, txttipe As ComboBox, tglkontrol As DateTimePicker, ParamArray var() As TextBox)
        On Error Resume Next
        For i As Integer = 0 To UBound(var, 1)

            If (i = (UBound(var, 1))) Then
                var(i).Text = DGV.Rows(row).Cells(i).Value
                tglproduksi.Value = DGV.Rows(row).Cells(5).Value
                tglkontrol.Value = DGV.Rows(row).Cells(7).Value
            Else
                var(i).Text = DGV.Rows(row).Cells(i).Value
                txttipe.SelectedItem = DGV.Rows(row).Cells(3).Value
            End If
        Next
    End Sub

    Sub showtoBox2(row As Integer, DGV As DataGridView, ParamArray var() As TextBox)
        On Error Resume Next
        For i As Integer = 0 To UBound(var, 1)
            var(i).Text = DGV.Rows(row).Cells(i).Value
        Next
    End Sub

    Sub hapusData(namatabel As String, namaid As String, id As String)
        Dim sql As String
        sql = "DELETE FROM " + namatabel + " WHERE " + namaid + " ='" + id + "'"
        CMD = New OleDb.OleDbCommand(sql, Conn)
        DM = CMD.ExecuteReader
        MessageBox.Show("Data terhapus.")
    End Sub

    Sub hapusData(namatabel As String)
        Dim sql As String
        sql = "DELETE FROM " + namatabel
        CMD = New OleDb.OleDbCommand(sql, Conn)
        DM = CMD.ExecuteReader
        MessageBox.Show("Data terhapus.")
    End Sub

    'pilih produk buat di warehouse FG
    Public Sub reload(ByVal sql As String, ByVal DTG As Object)
        Try
            Conn.Open()
            Dim dt = New DataTable
            With CMD
                .Connection = Conn
                .CommandText = sql

            End With
            DA.SelectCommand = CMD
            DA.Fill(dt)
            DTG.datasource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Conn.Close()
            DA.Dispose()
        End Try
    End Sub


    'buat excel
    Public Sub releaseobject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Module
