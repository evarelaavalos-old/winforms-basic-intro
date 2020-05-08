<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartidos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtpFechaPartido = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblEquipLocal = New System.Windows.Forms.Label()
        Me.lblEquipVisitante = New System.Windows.Forms.Label()
        Me.lblFinalizacion = New System.Windows.Forms.Label()
        Me.cmbEquipLocal = New System.Windows.Forms.ComboBox()
        Me.cmbEquipVisitante = New System.Windows.Forms.ComboBox()
        Me.lblGolesLocal = New System.Windows.Forms.Label()
        Me.lblGolesVisitante = New System.Windows.Forms.Label()
        Me.rbNormal = New System.Windows.Forms.RadioButton()
        Me.rbSuspIncidentes = New System.Windows.Forms.RadioButton()
        Me.rbSuspClima = New System.Windows.Forms.RadioButton()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.lsvPartidosJugados = New System.Windows.Forms.ListView()
        Me.txtGolesLocal = New System.Windows.Forms.TextBox()
        Me.txtGolesVisitante = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'dtpFechaPartido
        '
        Me.dtpFechaPartido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPartido.Location = New System.Drawing.Point(116, 24)
        Me.dtpFechaPartido.Name = "dtpFechaPartido"
        Me.dtpFechaPartido.Size = New System.Drawing.Size(100, 20)
        Me.dtpFechaPartido.TabIndex = 0
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(70, 30)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 1
        Me.lblFecha.Text = "Fecha:"
        '
        'lblEquipLocal
        '
        Me.lblEquipLocal.AutoSize = True
        Me.lblEquipLocal.Location = New System.Drawing.Point(38, 60)
        Me.lblEquipLocal.Name = "lblEquipLocal"
        Me.lblEquipLocal.Size = New System.Drawing.Size(72, 13)
        Me.lblEquipLocal.TabIndex = 2
        Me.lblEquipLocal.Text = "Equipo Local:"
        '
        'lblEquipVisitante
        '
        Me.lblEquipVisitante.AutoSize = True
        Me.lblEquipVisitante.Location = New System.Drawing.Point(24, 90)
        Me.lblEquipVisitante.Name = "lblEquipVisitante"
        Me.lblEquipVisitante.Size = New System.Drawing.Size(86, 13)
        Me.lblEquipVisitante.TabIndex = 3
        Me.lblEquipVisitante.Text = "Equipo Visitante:"
        '
        'lblFinalizacion
        '
        Me.lblFinalizacion.AutoSize = True
        Me.lblFinalizacion.Location = New System.Drawing.Point(45, 120)
        Me.lblFinalizacion.Name = "lblFinalizacion"
        Me.lblFinalizacion.Size = New System.Drawing.Size(65, 13)
        Me.lblFinalizacion.TabIndex = 4
        Me.lblFinalizacion.Text = "Finalización:"
        '
        'cmbEquipLocal
        '
        Me.cmbEquipLocal.FormattingEnabled = True
        Me.cmbEquipLocal.Location = New System.Drawing.Point(116, 52)
        Me.cmbEquipLocal.Name = "cmbEquipLocal"
        Me.cmbEquipLocal.Size = New System.Drawing.Size(175, 21)
        Me.cmbEquipLocal.TabIndex = 5
        '
        'cmbEquipVisitante
        '
        Me.cmbEquipVisitante.FormattingEnabled = True
        Me.cmbEquipVisitante.Location = New System.Drawing.Point(116, 82)
        Me.cmbEquipVisitante.Name = "cmbEquipVisitante"
        Me.cmbEquipVisitante.Size = New System.Drawing.Size(175, 21)
        Me.cmbEquipVisitante.TabIndex = 6
        '
        'lblGolesLocal
        '
        Me.lblGolesLocal.AutoSize = True
        Me.lblGolesLocal.Location = New System.Drawing.Point(300, 60)
        Me.lblGolesLocal.Name = "lblGolesLocal"
        Me.lblGolesLocal.Size = New System.Drawing.Size(37, 13)
        Me.lblGolesLocal.TabIndex = 7
        Me.lblGolesLocal.Text = "Goles:"
        '
        'lblGolesVisitante
        '
        Me.lblGolesVisitante.AutoSize = True
        Me.lblGolesVisitante.Location = New System.Drawing.Point(300, 90)
        Me.lblGolesVisitante.Name = "lblGolesVisitante"
        Me.lblGolesVisitante.Size = New System.Drawing.Size(37, 13)
        Me.lblGolesVisitante.TabIndex = 8
        Me.lblGolesVisitante.Text = "Goles:"
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Location = New System.Drawing.Point(116, 118)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(58, 17)
        Me.rbNormal.TabIndex = 9
        Me.rbNormal.TabStop = True
        Me.rbNormal.Text = "Normal"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'rbSuspIncidentes
        '
        Me.rbSuspIncidentes.AutoSize = True
        Me.rbSuspIncidentes.Location = New System.Drawing.Point(180, 118)
        Me.rbSuspIncidentes.Name = "rbSuspIncidentes"
        Me.rbSuspIncidentes.Size = New System.Drawing.Size(104, 17)
        Me.rbSuspIncidentes.TabIndex = 10
        Me.rbSuspIncidentes.TabStop = True
        Me.rbSuspIncidentes.Text = "Susp. Incidentes"
        Me.rbSuspIncidentes.UseVisualStyleBackColor = True
        '
        'rbSuspClima
        '
        Me.rbSuspClima.AutoSize = True
        Me.rbSuspClima.Location = New System.Drawing.Point(290, 118)
        Me.rbSuspClima.Name = "rbSuspClima"
        Me.rbSuspClima.Size = New System.Drawing.Size(80, 17)
        Me.rbSuspClima.TabIndex = 11
        Me.rbSuspClima.TabStop = True
        Me.rbSuspClima.Text = "Susp. Clima"
        Me.rbSuspClima.UseVisualStyleBackColor = True
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(204, 150)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(75, 23)
        Me.btnRegistrar.TabIndex = 12
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'lsvPartidosJugados
        '
        Me.lsvPartidosJugados.HideSelection = False
        Me.lsvPartidosJugados.Location = New System.Drawing.Point(10, 180)
        Me.lsvPartidosJugados.Name = "lsvPartidosJugados"
        Me.lsvPartidosJugados.Size = New System.Drawing.Size(440, 125)
        Me.lsvPartidosJugados.TabIndex = 13
        Me.lsvPartidosJugados.UseCompatibleStateImageBehavior = False
        '
        'txtGolesLocal
        '
        Me.txtGolesLocal.Location = New System.Drawing.Point(343, 52)
        Me.txtGolesLocal.Name = "txtGolesLocal"
        Me.txtGolesLocal.Size = New System.Drawing.Size(50, 20)
        Me.txtGolesLocal.TabIndex = 14
        '
        'txtGolesVisitante
        '
        Me.txtGolesVisitante.Location = New System.Drawing.Point(343, 83)
        Me.txtGolesVisitante.Name = "txtGolesVisitante"
        Me.txtGolesVisitante.Size = New System.Drawing.Size(50, 20)
        Me.txtGolesVisitante.TabIndex = 15
        '
        'frmPartidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 311)
        Me.Controls.Add(Me.txtGolesVisitante)
        Me.Controls.Add(Me.txtGolesLocal)
        Me.Controls.Add(Me.lsvPartidosJugados)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.rbSuspClima)
        Me.Controls.Add(Me.rbSuspIncidentes)
        Me.Controls.Add(Me.rbNormal)
        Me.Controls.Add(Me.lblGolesVisitante)
        Me.Controls.Add(Me.lblGolesLocal)
        Me.Controls.Add(Me.cmbEquipVisitante)
        Me.Controls.Add(Me.cmbEquipLocal)
        Me.Controls.Add(Me.lblFinalizacion)
        Me.Controls.Add(Me.lblEquipVisitante)
        Me.Controls.Add(Me.lblEquipLocal)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.dtpFechaPartido)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmPartidos"
        Me.Text = "Partidos del Torneo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpFechaPartido As DateTimePicker
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblEquipLocal As Label
    Friend WithEvents lblEquipVisitante As Label
    Friend WithEvents lblFinalizacion As Label
    Friend WithEvents cmbEquipLocal As ComboBox
    Friend WithEvents cmbEquipVisitante As ComboBox
    Friend WithEvents lblGolesLocal As Label
    Friend WithEvents lblGolesVisitante As Label
    Friend WithEvents rbNormal As RadioButton
    Friend WithEvents rbSuspIncidentes As RadioButton
    Friend WithEvents rbSuspClima As RadioButton
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents lsvPartidosJugados As ListView
    Friend WithEvents txtGolesLocal As TextBox
    Friend WithEvents txtGolesVisitante As TextBox
End Class
