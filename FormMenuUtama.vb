Public Class FormMenuUtama

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim a = New FormPurchasing
        Me.Hide()
        a.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim b = New FormMarketing
        Me.Hide()
        b.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim c = New FormWarehouseFG
        Me.Hide()
        c.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim d = New FormProduksi
        Me.Hide()
        d.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f = New FormPurchasing
        Me.Hide()
        f.Show()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim g = New FormWarehouseRM
        Me.Hide()
        g.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim h = New FormQC
        Me.Hide()
        h.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim i = New LoginSupplier
        Me.Hide()
        i.Show()
    End Sub

    'Sub misal()
    'Dim loginawal As New LoginDistributor
    '   TextBox1.Text = loginawal.UsernameTextBox.Text
    'End Sub
    Private Sub FormMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Call misal()
        ' Dim loginawal As New LoginDistributor
        ' TextBox1.Text = loginawal.UsernameTextBox.Text
        'If TextBox1.Text = " Admin " Then
        'enableButton(Button2, Button3, Button4, Button5, Button6, Button7, Button8)
        ' Else
        'disableButton(Button2, Button3, Button4, Button5, Button6, Button7, Button8)
        ' End If
        TextBox1.Text = "Selamat Datang, " + savenama.ToString + " !"
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim masuk As New FormKaryawan
        masuk.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim go As New FormDataBarang
        Me.Hide()
        go.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim result As DialogResult = MessageBox.Show("Apakah anda ingin keluar ?", "LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Dim a = New WelcomeMenu
            Me.Close()
            a.Show()
        ElseIf result = DialogResult.No Then
        End If
    End Sub
End Class