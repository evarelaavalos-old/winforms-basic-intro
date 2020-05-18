Imports System.IO

Public Class frmExportacion
    Private _rutaArchivo As String
    Private _delimitadorCampo As Char

    Private Sub frmExportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ubicacion del archivo desde el cual se cargaran los partidos
        _rutaArchivo = "Partidos.txt"
        _delimitadorCampo = ";"

        'posiciona el formulario en el centro de la pantalla
        Me.CenterToScreen()

        'El usuario no puede tipear equipos personalizados en los combobox
        cmbEquipoFiltrado.DropDownStyle = ComboBoxStyle.DropDownList
        CargarEquiposComboBox()

        'por defecto el checkbox "Todos" está marcado y el groupbox "Filtro" deshabilitado
        'al habilitar el chechbox "Todos" se cargan los datos en la list view
        chkTodos.Checked = True
        grpFiltro.Enabled = False

        'opciones por default del filtro
        cmbEquipoFiltrado.SelectedIndex = 0
        rbLocal.Checked = True

        'configuracion de la lista
        lsvEquipos.View = View.Details
        lsvEquipos.FullRowSelect = True

    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        If chkTodos.Checked Then
            grpFiltro.Enabled = False
            ReiniciarLista()
            Cargar()
        Else
            grpFiltro.Enabled = True
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        ReiniciarLista()
        Cargar()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
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

        'el siguiente condicional ejecutara las lineas contenidas, solo si el usuario
        'acepto registrar en el archivo
        If SFD.ShowDialog = DialogResult.OK Then
            'la siguiente linea instancia un objeto de la clase FileStream donde se define
            'el archivo sobre el cual trabajar y el modo de apertura
            Dim archivoAGrabar As FileStream = New FileStream(SFD.FileName, FileMode.Append)
            Dim grabador As StreamWriter = New StreamWriter(archivoAGrabar)

            Dim archivoALeer As FileStream = New FileStream(_rutaArchivo, FileMode.Open)
            Dim lector As StreamReader = New StreamReader(archivoALeer)
            Dim partido As PartidoFutbol = New PartidoFutbol()

            If File.Exists(_rutaArchivo) Then
                While Not lector.EndOfStream
                    partido.Parse(lector.ReadLine(), _delimitadorCampo)

                    If chkTodos.Checked Then
                        grabador.WriteLine(partido.EnUnaLineaSeparadoPor(_delimitadorCampo))

                    ElseIf rbLocal.Checked And cmbEquipoFiltrado.Text = partido.GetEquipoLocal() Then
                        grabador.WriteLine(partido.EnUnaLineaSeparadoPor(_delimitadorCampo))

                    ElseIf rbVisitante.Checked And cmbEquipoFiltrado.Text = partido.GetEquipoVisitante() Then
                        grabador.WriteLine(partido.EnUnaLineaSeparadoPor(_delimitadorCampo))
                    End If
                End While
            End If

            grabador.Close()
            lector.Close()
            archivoAGrabar.Close()
            archivoALeer.Close()
        End If
    End Sub

    Private Sub Cargar()
        If File.Exists(_rutaArchivo) Then
            Dim archivo As FileStream = New FileStream(_rutaArchivo, FileMode.Open)
            Dim lector As StreamReader = New StreamReader(archivo)
            Dim partido As PartidoFutbol = New PartidoFutbol()
            Dim nroPartidosCargados As Integer = lsvEquipos.Items.Count '<- deberia ser 0

            While Not lector.EndOfStream
                partido.Parse(lector.ReadLine(), _delimitadorCampo)

                If chkTodos.Checked Then
                    CargarPartido(partido, nroPartidosCargados)
                    nroPartidosCargados += 1

                ElseIf rbLocal.Checked And cmbEquipoFiltrado.Text = partido.GetEquipoLocal() Then
                    CargarPartido(partido, nroPartidosCargados)
                    nroPartidosCargados += 1

                ElseIf rbVisitante.Checked And cmbEquipoFiltrado.Text = partido.GetEquipoVisitante() Then
                    CargarPartido(partido, nroPartidosCargados)
                    nroPartidosCargados += 1
                End If
            End While

            lector.Close()
            archivo.Close()
        End If
    End Sub

    Private Sub CargarPartido(partido As PartidoFutbol, ubicacion As Integer)
        lsvEquipos.Items.Add(partido.GetFechaPartido().ToShortDateString())
        lsvEquipos.Items(ubicacion).SubItems.Add(partido.GetEquipoLocal())
        lsvEquipos.Items(ubicacion).SubItems.Add(partido.GetEquipoVisitante())
        lsvEquipos.Items(ubicacion).SubItems.Add(partido.GetGolesLocal().ToString())
        lsvEquipos.Items(ubicacion).SubItems.Add(partido.GetGolesVisitante().ToString())
        lsvEquipos.Items(ubicacion).SubItems.Add(partido.GetFinalizacion())
    End Sub

    Private Sub ReiniciarLista()
        lsvEquipos.Clear()
        lsvEquipos.Columns.Add("Fecha", 80, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Local", 110, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Visitante", 110, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Goles L.", 60, HorizontalAlignment.Center)
        lsvEquipos.Columns.Add("Goles V.", 60, HorizontalAlignment.Center)
        lsvEquipos.Columns.Add("Finalizacion", 120, HorizontalAlignment.Center)
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