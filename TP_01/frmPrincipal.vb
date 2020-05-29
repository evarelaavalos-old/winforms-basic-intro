Public Class frmPrincipal
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub mnuAlta_Click(sender As Object, e As EventArgs) Handles mnuAlta.Click
        frmAlta.ShowDialog()
    End Sub

    Private Sub mnuExportar_Click(sender As Object, e As EventArgs) Handles mnuExportar.Click
        frmExportacion.ShowDialog()
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Application.Exit()
    End Sub
End Class