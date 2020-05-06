Public Class frmPartidos

    Private Sub frmPartidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Configuracion de la lista
        lsvPartidosJugados.View = View.Details
        lsvPartidosJugados.FullRowSelect = True

        'Columnas de la lista
        lsvPartidosJugados.Columns.Add("Fecha", 60, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Local", 90, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Visitante", 90, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Goles L.", 60, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Goles V.", 60, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Finalizacion", 80, HorizontalAlignment.Left)
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

    End Sub
End Class
