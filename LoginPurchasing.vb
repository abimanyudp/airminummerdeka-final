Public Class LoginPurchasing

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
        Dim b As New FormPurchasing
        cek = "select * from Karyawan where nama = '" & UsernameTextBox.Text & " ' and IDkaryawan = '" & PasswordTextBox.Text & "'"
        CMD = New OleDb.OleDbCommand(cek, Conn)
        CMD.ExecuteNonQuery()
        DM = CMD.ExecuteReader

        If DM.HasRows = True Then
            DM.Read()
            b.Show()
            Me.Hide()
        Else
            MessageBox.Show("Username atau Password Salah")
        End If
    End Sub

    'camcel
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Dim a = New FormMenuUtama
        Me.Close()
        a.Show()
    End Sub

End Class
