Imports System.IO

'TODO eliminar LFD (el coso que carga, no va mas ese)
Public Class frmExportacion
    Private _rutaArchivo As String
    Private _delimitadorCampo As Char
    Private _listaPartidos As ListaPartidos
    Private _filtroActual As FiltrosActivados
    'TODO cambiar el nombre de esta variable por otro, cecchi lo llama de otra forma
    'TODO es necesaria esta variable? o ListView ya implementa una variable para esta informacion?
    Private _elementosListView As Integer
    'TODO crear un condicional que me permita evaluar si es la primera vez que se ejecuta el programa
    ' para no tener que volver a configurar todo nuevamente
    'Private _seHanAplicadoConfIniciales As Boolean

    Private Enum FiltrosActivados
        Estado_Invalido
        Sin_Filtros
        Filtrar_Equipos_Local
        Filtrar_Equipos_Visitante
    End Enum

    Private Sub frmExportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ubicacion del archivo desde el cual se cargaran los partidos
        _rutaArchivo = "Partidos.txt"
        _delimitadorCampo = ";"
        _listaPartidos = New ListaPartidos()
        _elementosListView = 0
        ImportarPartidos()

        'posiciona el formulario en el centro de la pantalla
        Me.CenterToScreen()

        'El usuario no puede tipear equipos personalizados en los combobox
        cmbEquipoFiltrado.DropDownStyle = ComboBoxStyle.DropDownList
        CargarEquiposComboBox()

        'por defecto el checkbox "Todos" está marcado y el groupbox "Filtro" deshabilitado
        'al habilitar el chechbox "Todos" se cargan los datos en la list view
        chkTodos.Checked = True

        'configuracion de la lista
        lsvEquipos.View = View.Details
        lsvEquipos.FullRowSelect = True

    End Sub

    Private Sub ImportarPartidos()
        If File.Exists(_rutaArchivo) Then
            Dim archivo As FileStream = New FileStream(_rutaArchivo, FileMode.Open)
            Dim lector As StreamReader = New StreamReader(archivo)

            While Not lector.EndOfStream
                Dim partido As PartidoFutbol = New PartidoFutbol()
                partido.Parse(lector.ReadLine, _delimitadorCampo)

                _listaPartidos.Anexar(partido)
            End While

            lector.Close()
            archivo.Close()
        End If
    End Sub

    Private Sub LimpiarListaPartidos()
        _elementosListView = 0

        lsvEquipos.Clear()
        lsvEquipos.Columns.Add("Fecha", 80, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Local", 110, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Visitante", 110, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Goles L.", 60, HorizontalAlignment.Center)
        lsvEquipos.Columns.Add("Goles V.", 60, HorizontalAlignment.Center)
        lsvEquipos.Columns.Add("Finalizacion", 120, HorizontalAlignment.Center)
    End Sub

    Private Sub RefrescarListaPartidos()
        Dim cantidadPartidos As Integer = _listaPartidos.Contar()
        Dim partido As PartidoFutbol

        Select Case _filtroActual

            Case FiltrosActivados.Sin_Filtros
                For i = 0 To cantidadPartidos - 1
                    partido = _listaPartidos.Acceder(i)
                    CargarPartidoEnLista(partido)
                Next

            Case FiltrosActivados.Filtrar_Equipos_Local
                For i = 0 To cantidadPartidos - 1
                    partido = _listaPartidos.Acceder(i)

                    If partido.GetEquipoLocal() = cmbEquipoFiltrado.Text Then
                        CargarPartidoEnLista(partido)
                    End If
                Next

            Case FiltrosActivados.Filtrar_Equipos_Visitante
                For i = 0 To cantidadPartidos - 1
                    partido = _listaPartidos.Acceder(i)

                    If partido.GetEquipoVisitante() = cmbEquipoFiltrado.Text Then
                        CargarPartidoEnLista(partido)
                    End If
                Next
        End Select
    End Sub

    Private Sub CargarPartidoEnLista(partido As PartidoFutbol)
        lsvEquipos.Items.Add(partido.GetFechaPartido().ToShortDateString())
        lsvEquipos.Items(_elementosListView).SubItems.Add(partido.GetEquipoLocal())
        lsvEquipos.Items(_elementosListView).SubItems.Add(partido.GetEquipoVisitante())
        lsvEquipos.Items(_elementosListView).SubItems.Add(partido.GetGolesLocal().ToString())
        lsvEquipos.Items(_elementosListView).SubItems.Add(partido.GetGolesVisitante().ToString())
        lsvEquipos.Items(_elementosListView).SubItems.Add(partido.GetFinalizacion())

        _elementosListView += 1
    End Sub

    Private Sub ExportarPartidos()
        'la siguiente linea agrega automaticamente la extension
        SFD.AddExtension = True
        'la siguiente linea define la extension por default
        SFD.DefaultExt = "*.txt"
        'la siguiente linea define los tipos de archivos que el usuario podra seleccionar,
        'en este ejemplo solo podra seleccionar un unico tipo
        SFD.Filter = "Archivo de Texto (.txt)|*.txt"
        'la siguiente linea define el directorio que se presentara por default
        SFD.InitialDirectory = Application.StartupPath
        'la siguiente linea define si al momento de seleccionar un archivo existente
        'se le debera advertir al usuario que sera sobreescrito
        SFD.OverwritePrompt = False
        'la siguiente linea vacia el contenido del campo
        SFD.FileName = String.Empty

        If SFD.ShowDialog() = DialogResult Then
            'la siguiente linea instancia un objeto de la clase FileStream donde se define
            'el archivo sobre el cual trabajar y el modo de apertura
            Dim archivoAGrabar As FileStream = New FileStream(SFD.FileName, FileMode.Append)
            Dim grabador As StreamWriter = New StreamWriter(archivoAGrabar)

            Dim archivoALeer As FileStream = New FileStream(_rutaArchivo, FileMode.Open)
            Dim lector As StreamReader = New StreamReader(archivoALeer)
            Dim partido As PartidoFutbol = New PartidoFutbol()
            grabador.Close()
            archivoAGrabar.Close()
        End If
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked Then
            grpFiltro.Enabled = False
            _filtroActual = FiltrosActivados.Sin_Filtros
            LimpiarListaPartidos()
            RefrescarListaPartidos()
        Else
            grpFiltro.Enabled = True
            _filtroActual = FiltrosActivados.Filtrar_Equipos_Local
            rbLocal.Checked = True
            cmbEquipoFiltrado.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        LimpiarListaPartidos()
        RefrescarListaPartidos()
    End Sub

    'TODO cuando se ejecute este boton, se debera exportar los elementos de la listview
    ' en un archivo de texto
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarPartidos()
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

    Private Sub CargarEquiposComboBox()
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
    End Sub
End Class