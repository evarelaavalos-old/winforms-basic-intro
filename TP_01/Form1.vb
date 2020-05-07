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

    Private Sub frmPartidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        cmbEquipVisitante.Items.Add("Aldosivi")
        cmbEquipVisitante.Items.Add("Argentinos")
        cmbEquipVisitante.Items.Add("Arsenal")
        cmbEquipVisitante.Items.Add("Atletico Tucuman")
        cmbEquipVisitante.Items.Add("Banfield")
        cmbEquipVisitante.Items.Add("Boca Juniors")
        cmbEquipVisitante.Items.Add("Central Cordoba")
        cmbEquipVisitante.Items.Add("Colon")
        cmbEquipVisitante.Items.Add("Defensa y Justicia")
        cmbEquipVisitante.Items.Add("Estudiantes")
        cmbEquipVisitante.Items.Add("Gimnasia y Esgrima")
        cmbEquipVisitante.Items.Add("Godoy Cruz")
        cmbEquipVisitante.Items.Add("Huracán")
        cmbEquipVisitante.Items.Add("Independiente")
        cmbEquipVisitante.Items.Add("Lanus")
        cmbEquipVisitante.Items.Add("Newell's Old Boys")
        cmbEquipVisitante.Items.Add("Patronato")
        cmbEquipVisitante.Items.Add("Racing")
        cmbEquipVisitante.Items.Add("River Plate")
        cmbEquipVisitante.Items.Add("Rosario Central")
        cmbEquipVisitante.Items.Add("San Lorenzo")
        cmbEquipVisitante.Items.Add("Talleres")
        cmbEquipVisitante.Items.Add("Union de Santa Fe")
        cmbEquipVisitante.Items.Add("Velez Sarsfield")

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
        cmbEquipVisitante.DropDownStyle = ComboBoxStyle.DropDownList

        'No se permite escribir más de dos digitos para el numero de goles
        txtGolesLocal.MaxLength = 2
        txtGolesVisitante.MaxLength = 2

        CargarEjemplosLista()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim EstadoActualFormulario As EstadoFormulario = CheckearEstadoFormulario()

        Select Case EstadoActualFormulario
            Case EstadoFormulario.Goles_Local_Es_Vacio
                MessageBox.Show("No ha ingresado un numero en los goles del equipo local." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.Goles_Local_No_Numerico
                MessageBox.Show("El valor ingresado en los goles del equipo local es no numerico." _
                & " Por favor, ingrese un numero positivo." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.Goles_Local_Negativo
                MessageBox.Show("El valor ingresado en los goles del equipo local es negativo." _
                & " Por favor, ingrese un numero positivo." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.Goles_Visitante_Es_Vacio
                MessageBox.Show("No ha ingresado un numero en los goles del equipo visitante." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.Goles_Visitante_No_Numerico
                MessageBox.Show("El valor ingresado en los goles del equipo visitante es no numerico." _
                & " Por favor, ingrese un numero positivo." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.Goles_Visitante_Negativo
                MessageBox.Show("El valor ingresado en los goles del equipo visitante es negativo." _
                & " Por favor, ingrese un numero positivo." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.No_Selecciono_Finalizacion
                MessageBox.Show("No ha seleccionado como finalizo el partido." _
                & " Por favor, seleccione una de las opciones." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.Equipos_Duplicados
                MessageBox.Show("No puede seleccionar el mismo equipo en ambos casilleros." _
                & " Por favor, seleccione equipos diferentes como local y visitante." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.Equipos_Enfrentados_Previamente
                MessageBox.Show("Estos equipos ya se han enfrentado en otra ocasion. " _
                & " Por favor, revise la lista de partidos jugados para mas detalles." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Case EstadoFormulario.Correcto
                MessageBox.Show("El partido se ha registrado exitosamente." _
                , "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Select
    End Sub

    Private Function CheckearEstadoFormulario() As EstadoFormulario
        Dim golesLocal As Short
        Dim golesVisitante As Short

        If txtGolesLocal.Text.Trim = String.Empty Then
            Return EstadoFormulario.Goles_Local_Es_Vacio

        ElseIf Not Short.TryParse(txtGolesLocal.Text.Trim, golesLocal) Then
            Return EstadoFormulario.Goles_Local_No_Numerico

        ElseIf golesLocal < 0 Then
            Return EstadoFormulario.Goles_Local_Negativo

        ElseIf txtGolesVisitante.Text.Trim = String.Empty Then
            Return EstadoFormulario.Goles_Visitante_Es_Vacio

        ElseIf Not Short.TryParse(txtGolesVisitante.Text.Trim, golesVisitante) Then
            Return EstadoFormulario.Goles_Visitante_No_Numerico

        ElseIf golesVisitante < 0 Then
            Return EstadoFormulario.Goles_Visitante_Negativo

        ElseIf False Then
            'TODO crear una funcion SeHaSeleccionadoFinalizacion
            Return EstadoFormulario.No_Selecciono_Finalizacion

        ElseIf False Then
            'TODO crear una funcion que determine ambos combobox contienen el mismo equipo
            Return EstadoFormulario.Equipos_Duplicados

        ElseIf False Then
            'TODO crear una funcion que determine, de los equipos que estan en la planilla,
            'si ya se habian enfrentado previamente
            Return EstadoFormulario.Equipos_Enfrentados_Previamente

        Else
            Return EstadoFormulario.Correcto
        End If
    End Function

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
