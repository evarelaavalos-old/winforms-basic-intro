Public Class frmPartidos

    Private Enum EstadoFormulario
        Estado_Invalido
        Goles_Local_Es_Vacio
        Goles_Local_No_Numerico
        Goles_Local_Negativo
        Goles_Visitante_Es_Vacio
        Goles_Visitante_No_Numerico
        Goles_Visitante_Negativo
        No_Selecciono_Finalizacion
        Equipos_Duplicados
        Equipos_Enfrentados_Previamente
        Correcto
    End Enum

    Private EstadoActualFormulario As EstadoFormulario

    Private Sub frmPartidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EstadoActualFormulario = EstadoFormulario.Estado_Invalido

        'carga los nombres de los equipos en los ComboBox
        cmbEquipLocal.Items.Add("Aldosivi")
        cmbEquipLocal.Items.Add("Argentinos")
        cmbEquipLocal.Items.Add("Arsenal")
        cmbEquipLocal.Items.Add("Atletico Tucuman")
        cmbEquipLocal.Items.Add("Banfield")
        cmbEquipLocal.Items.Add("Boca Juniors")
        cmbEquipLocal.Items.Add("Central Cordoba")
        cmbEquipLocal.Items.Add("Colon")
        cmbEquipLocal.Items.Add("Defensa y Justicia")
        cmbEquipLocal.Items.Add("Estudiantes")
        cmbEquipLocal.Items.Add("Gimnasia y Esgrima")
        cmbEquipLocal.Items.Add("Godoy Cruz")
        cmbEquipLocal.Items.Add("Huracán")
        cmbEquipLocal.Items.Add("Independiente")
        cmbEquipLocal.Items.Add("Lanus")
        cmbEquipLocal.Items.Add("Newell's Old Boys")
        cmbEquipLocal.Items.Add("Patronato")
        cmbEquipLocal.Items.Add("Racing")
        cmbEquipLocal.Items.Add("River Plate")
        cmbEquipLocal.Items.Add("Rosario Central")
        cmbEquipLocal.Items.Add("San Lorenzo")
        cmbEquipLocal.Items.Add("Talleres")
        cmbEquipLocal.Items.Add("Union de Santa Fe")
        cmbEquipLocal.Items.Add("Velez Sarsfield")

        cmbEquipVisit.Items.Add("Aldosivi")
        cmbEquipVisit.Items.Add("Argentinos")
        cmbEquipVisit.Items.Add("Arsenal")
        cmbEquipVisit.Items.Add("Atletico Tucuman")
        cmbEquipVisit.Items.Add("Banfield")
        cmbEquipVisit.Items.Add("Boca Juniors")
        cmbEquipVisit.Items.Add("Central Cordoba")
        cmbEquipVisit.Items.Add("Colon")
        cmbEquipVisit.Items.Add("Defensa y Justicia")
        cmbEquipVisit.Items.Add("Estudiantes")
        cmbEquipVisit.Items.Add("Gimnasia y Esgrima")
        cmbEquipVisit.Items.Add("Godoy Cruz")
        cmbEquipVisit.Items.Add("Huracán")
        cmbEquipVisit.Items.Add("Independiente")
        cmbEquipVisit.Items.Add("Lanus")
        cmbEquipVisit.Items.Add("Newell's Old Boys")
        cmbEquipVisit.Items.Add("Patronato")
        cmbEquipVisit.Items.Add("Racing")
        cmbEquipVisit.Items.Add("River Plate")
        cmbEquipVisit.Items.Add("Rosario Central")
        cmbEquipVisit.Items.Add("San Lorenzo")
        cmbEquipVisit.Items.Add("Talleres")
        cmbEquipVisit.Items.Add("Union de Santa Fe")
        cmbEquipVisit.Items.Add("Velez Sarsfield")

        'configuracion de la lista
        lsvPartidosJugados.View = View.Details
        lsvPartidosJugados.FullRowSelect = True

        'columnas de la lista
        lsvPartidosJugados.Columns.Add("Fecha", 60, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Local", 90, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Visitante", 90, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Goles L.", 60, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Goles V.", 60, HorizontalAlignment.Left)
        lsvPartidosJugados.Columns.Add("Finalizacion", 80, HorizontalAlignment.Left)

        'La fecha actual es la maxima fecha a elegir
        dtpFechaPartido.MaxDate = DateTime.Today

        'El usuario no puede tipear equipos personalizados
        cmbEquipLocal.DropDownStyle = ComboBoxStyle.DropDownList
        cmbEquipVisit.DropDownStyle = ComboBoxStyle.DropDownList

        'No se permite escribir más de dos digitos para el numero de goles
        txtGolesLocal.MaxLength = 2
        txtGolesVisit.MaxLength = 2

        cargarEjemplosLista()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

    End Sub

    Private Sub CargarEjemplosLista()
        'Ejemplo 1
        lsvPartidosJugados.Items.Add("04/05/2020")
        lsvPartidosJugados.Items(0).SubItems.Add("River Plate")
        lsvPartidosJugados.Items(0).SubItems.Add("Boca Juniors")
        lsvPartidosJugados.Items(0).SubItems.Add("3")
        lsvPartidosJugados.Items(0).SubItems.Add("1")
        lsvPartidosJugados.Items(0).SubItems.Add("Normal")

        'Ejemplo 2
        lsvPartidosJugados.Items.Add("05/05/2020")
        lsvPartidosJugados.Items(1).SubItems.Add("Independiente")
        lsvPartidosJugados.Items(1).SubItems.Add("Racing")
        lsvPartidosJugados.Items(1).SubItems.Add("0")
        lsvPartidosJugados.Items(1).SubItems.Add("2")
        lsvPartidosJugados.Items(1).SubItems.Add("Susp. Clima")

        'Ejemplo 3
        lsvPartidosJugados.Items.Add("06/05/2020")
        lsvPartidosJugados.Items(2).SubItems.Add("Rosario Central")
        lsvPartidosJugados.Items(2).SubItems.Add("Newell")
        lsvPartidosJugados.Items(2).SubItems.Add("1")
        lsvPartidosJugados.Items(2).SubItems.Add("1")
        lsvPartidosJugados.Items(2).SubItems.Add("Susp. Incidentes")
    End Sub
End Class
