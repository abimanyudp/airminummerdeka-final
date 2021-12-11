Public Class LoginDistributor
    Dim a As New FormMenuUtama
    Dim b As New WelcomeMenu
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Call koneksiDB()
        Dim cek As String
        Dim a As New FormMenuUtama

        cek = "Select * From Karyawan Where Dept = '" & UsernameTextBox.Text & "'and IDkaryawan = '" & PasswordTextBox.Text & "'"

        CMD = New OleDb.OleDbCommand(cek, Conn)
        CMD.ExecuteNonQuery()
        DM = CMD.ExecuteReader
        DM.Read()
        If DM.HasRows = True Then
            If DM("Dept").ToString = "Admin" Then
                a.Show()
                Me.Hide()
            Else
                a.Show()
                a.Button1.Enabled = False
                Me.Hide()
            End If
            PasswordTextBox.Text = ""
            'UsernameTextBox.Focus()
        Else
            MessageBox.Show(" Maaf Username atau Password Anda Salah ")
            Me.Show()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        b.Show()
    End Sub

    'save nama akun buat muncul di textbox di menu utama
    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged
        savenama = UsernameTextBox.Text
    End Sub
End Class
