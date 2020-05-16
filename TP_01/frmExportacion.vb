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

        'opciones por default del filtro
        'TODO seleccionar el primer equipo para el filtro
        'TODO seleccionar la opcion local como default del filtro

        'configuracion de la lista
        lsvEquipos.View = View.Details
        lsvEquipos.FullRowSelect = True
        CargarListaDesdeArchivo()

        'columnas de la listview
        lsvEquipos.Columns.Add("Fecha", 80, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Local", 110, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Visitante", 110, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Goles L.", 60, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Goles V.", 60, HorizontalAlignment.Left)
        lsvEquipos.Columns.Add("Finalizacion", 120, HorizontalAlignment.Left)
        'TODO centrar la columna de los goles de local
        'TODO centrar la columna de los goles de visitante
        'TODO centrar la columna de finalizacion
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        'TODO por defecto el chkbox Filtro está habilitado
        'TODO si el chkbox Filtro está habilitado
        '       groupbox está deshabilitado
        'en cambio si está deshabilitado
        '       groupbox está habilitado

        'TODO si marcas el checkbox
        '   deshabilitar el groupbox
        '   mostrar todos las entradas del archivos
        '       CargarDatosLista()
        'si desmarcas el chechbox
        '   habilitar el groupbox


    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        'TODO se ejecutara automaticamente la funcion CARGAR
        'LimpiarListView()
        'CargarListaConDatosFiltrados()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        '
    End Sub

    Private Sub CargarListaDesdeArchivo()
        If File.Exists(_rutaArchivo) Then
            Dim Archivo As FileStream = New FileStream(_rutaArchivo, FileMode.Open)
            Dim Lector As StreamReader = New StreamReader(Archivo)

            Dim Linea As String
            Dim Campos(5) As String
            Dim NroFilaLista As Integer = lsvEquipos.Items.Count '<- deberia ser 0
            While Not Lector.EndOfStream
                Linea = Lector.ReadLine
                Campos = Linea.Split(_delimitadorCampo)

                lsvEquipos.Items.Add(Campos(0))
                lsvEquipos.Items(NroFilaLista).SubItems.Add(Campos(1))
                lsvEquipos.Items(NroFilaLista).SubItems.Add(Campos(2))
                lsvEquipos.Items(NroFilaLista).SubItems.Add(Campos(3))
                lsvEquipos.Items(NroFilaLista).SubItems.Add(Campos(4))
                lsvEquipos.Items(NroFilaLista).SubItems.Add(Campos(5))

                NroFilaLista += 1
            End While

            Lector.Close()
            Archivo.Close()
        End If
    End Sub

    Private Sub CargarEquiposComboBox()
        'equipos de local
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