Public Class WelcomeMenu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New LoginDistributor
        a.Show()
        Me.Hide()
    End Sub

    'exit program
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Apakah anda ingin keluar ?", "KELUAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
            Close()
        ElseIf result = DialogResult.No Then
        End If
    End Sub
End Class