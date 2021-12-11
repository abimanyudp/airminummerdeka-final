Public Class LoginQC
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim form = New FormQC
        form.Show()
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Dim a = New FormMenuUtama
        Me.Close()
        a.Show()
    End Sub

End Class
