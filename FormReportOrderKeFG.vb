Imports CrystalDecisions.CrystalReports.Engine
Public Class FormReportOrderKeFG
    Private Sub FormReportOrderKeFG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Dim cryrpt As New ReportDocument
        OpenFileDialog1.Filter = "Report Order ke FG|ReportOrderkeFG.rpt|Rpt Files|*.rpt|All Files|*.*"
        Try
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                cryrpt.Load(Me.OpenFileDialog1.FileName)
                CrystalReportViewer1.ReportSource = cryrpt
                CrystalReportViewer1.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MsgBox("File Report tidak ada. Silahkan cari kembali")
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                cryrpt.Load(Me.OpenFileDialog1.FileName)
                CrystalReportViewer1.ReportSource = cryrpt
                CrystalReportViewer1.Refresh()
            End If
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New FormMarketing
        Me.Close()
        a.Show()
    End Sub
End Class