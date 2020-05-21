Imports System.IO

Public Class frmExportacion
    Private _rutaArchivo As String
    Private _delimitadorCampo As Char
    Private _listaPartidos As ListaPartidos
    Private _filtroActual As FiltrosActivados

    Private Enum FiltrosActivados
        Estado_Invalido
        Sin_Filtros
        Filtrar_Equipos_Local
        Filtrar_Equipos_Visitante
    End Enum

    Private Sub frmExportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'configuracion inicial
        _rutaArchivo = "Partidos.txt"
        _delimitadorCampo = ";"
        _listaPartidos = New ListaPartidos()
        _listaPartidos.Importar(_rutaArchivo, _delimitadorCampo)

        'el chequeo "Todos" está marcado por defecto (por consecuente, se carga la grilla)
        chkTodos.Checked = True

        'ajustes del formulario: centrado en la pantalla
        Me.CenterToScreen()

        'ajustes del combo: se cargan los equipos y no se le permite al usuario tipear
        cmbEquipoFiltrado.DropDownStyle = ComboBoxStyle.DropDownList
        cmbEquipoFiltrado.Items.Clear()
        cmbEquipoFiltrado.Items.Add("Aldosivi")
        cmbEquipoFiltrado.Items.Add("Argentinos")
        cmbEquipoFiltrado.Items.Add("Arsenal")
        cmbEquipoFiltrado.Items.Add("Atletico Tucuman")
        cmbEquipoFiltrado.Items.Add("Banfield")
        cmbEquipoFiltrado.Items.Add("Boca Juniors")
        cmbEquipoFiltrado.Items.Add("Central Cordoba")
        cmbEquipoFiltrado.Items.Add("Colon")
        cmbEquipoFiltrado.Items.Add("Defensa y Justicia")
        cmbEquipoFiltrado.Items.Add("Estudiantes")
        cmbEquipoFiltrado.Items.Add("Gimnasia y Esgrima")
        cmbEquipoFiltrado.Items.Add("Godoy Cruz")
        cmbEquipoFiltrado.Items.Add("Huracán")
        cmbEquipoFiltrado.Items.Add("Independiente")
        cmbEquipoFiltrado.Items.Add("Lanus")
        cmbEquipoFiltrado.Items.Add("Newell's Old Boys")
        cmbEquipoFiltrado.Items.Add("Patronato")
        cmbEquipoFiltrado.Items.Add("Racing")
        cmbEquipoFiltrado.Items.Add("River Plate")
        cmbEquipoFiltrado.Items.Add("Rosario Central")
        cmbEquipoFiltrado.Items.Add("San Lorenzo")
        cmbEquipoFiltrado.Items.Add("Talleres")
        cmbEquipoFiltrado.Items.Add("Union de Santa Fe")
        cmbEquipoFiltrado.Items.Add("Velez Sarsfield")
        cmbEquipoFiltrado.SelectedIndex = 0

        'ajustes de la grilla
        lsvEquipos.View = View.Details
        lsvEquipos.FullRowSelect = True

        'ajustes del cuadro de dialogo para guardar archivos
        SFD.AddExtension = True
        SFD.DefaultExt = "*.txt"
        SFD.Filter = "Archivo de Texto (.txt)|*.txt"
        SFD.InitialDirectory = Application.StartupPath
        SFD.OverwritePrompt = True
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked Then
            grpFiltro.Enabled = False
            _filtroActual = FiltrosActivados.Sin_Filtros
            Cargar()
        Else
            grpFiltro.Enabled = True
            _filtroActual = FiltrosActivados.Filtrar_Equipos_Local
            rbLocal.Checked = True
        End If
    End Sub

    Private Sub rbLocal_CheckedChanged(sender As Object, e As EventArgs) Handles rbLocal.CheckedChanged
        If rbLocal.Enabled Then
            _filtroActual = FiltrosActivados.Filtrar_Equipos_Local
        End If
    End Sub

    Private Sub rbVisitante_CheckedChanged(sender As Object, e As EventArgs) Handles rbVisitante.CheckedChanged
        If rbVisitante.Enabled Then
            _filtroActual = FiltrosActivados.Filtrar_Equipos_Visitante
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Cargar()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        SFD.FileName = String.Empty

        If SFD.ShowDialog() = DialogResult.OK Then
            Dim archivo As FileStream = New FileStream(SFD.FileName, FileMode.Append)
            Dim grabador As StreamWriter = New StreamWriter(archivo)
            Dim partidosJugados = lsvEquipos.Items.Count - 1
            Dim partido As String = String.Empty

            For i = 0 To partidosJugados
                partido = LeerFilaEnGrilla(i)
                grabador.WriteLine(partido)
            Next

            grabador.Close()
            archivo.Close()
        End If
    End Sub

    Private Sub Cargar()
        'limpia los partidos cargados en la grilla
        lsvEquipos.Clear()
        lsvEquipos.Columns.Add("Fecha", 80, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Local", 110, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Visitante", 110, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Goles L.", 60, HorizontalAlignment.Center)
        lsvEquipos.Columns.Add("Goles V.", 60, HorizontalAlignment.Center)
        lsvEquipos.Columns.Add("Finalizacion", 120, HorizontalAlignment.Center)

        'vuelve a cargar los partidos de acuerdo a que filtros estan activados (si los hay)
        Dim partidosJugados As Integer = _listaPartidos.Contar() - 1
        Dim partido As PartidoFutbol

        Select Case _filtroActual

            Case FiltrosActivados.Sin_Filtros
                For i = 0 To partidosJugados
                    partido = _listaPartidos.Acceder(i)
                    CargarEnGrilla(partido)
                Next

            Case FiltrosActivados.Filtrar_Equipos_Local
                For i = 0 To partidosJugados
                    partido = _listaPartidos.Acceder(i)

                    If partido.GetEquipoLocal() = cmbEquipoFiltrado.Text Then
                        CargarEnGrilla(partido)
                    End If
                Next

            Case FiltrosActivados.Filtrar_Equipos_Visitante
                For i = 0 To partidosJugados
                    partido = _listaPartidos.Acceder(i)

                    If partido.GetEquipoVisitante() = cmbEquipoFiltrado.Text Then
                        CargarEnGrilla(partido)
                    End If
                Next
        End Select
    End Sub

    Private Sub CargarEnGrilla(partido As PartidoFutbol)
        Dim indiceUltimoPartido = lsvEquipos.Items.Count

        lsvEquipos.Items.Add(partido.GetFechaPartido().ToShortDateString())
        lsvEquipos.Items(indiceUltimoPartido).SubItems.Add(partido.GetEquipoLocal())
        lsvEquipos.Items(indiceUltimoPartido).SubItems.Add(partido.GetEquipoVisitante())
        lsvEquipos.Items(indiceUltimoPartido).SubItems.Add(partido.GetGolesLocal().ToString())
        lsvEquipos.Items(indiceUltimoPartido).SubItems.Add(partido.GetGolesVisitante().ToString())
        lsvEquipos.Items(indiceUltimoPartido).SubItems.Add(partido.GetFinalizacion())
    End Sub

    Private Function LeerFilaEnGrilla(indice As Integer) As String
        Dim indiceUltimoPartido = lsvEquipos.Items.Count

        If (indice < indiceUltimoPartido) Then
            Return lsvEquipos.Items(indice).SubItems(0).Text & _delimitadorCampo _
            & lsvEquipos.Items(indice).SubItems(1).Text & _delimitadorCampo _
            & lsvEquipos.Items(indice).SubItems(2).Text & _delimitadorCampo _
            & lsvEquipos.Items(indice).SubItems(3).Text & _delimitadorCampo _
            & lsvEquipos.Items(indice).SubItems(4).Text & _delimitadorCampo _
            & lsvEquipos.Items(indice).SubItems(5).Text
        Else
            Return Nothing
        End If
    End Function
End Class