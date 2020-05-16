<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExportacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.grpFiltro = New System.Windows.Forms.GroupBox()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.rbVisitante = New System.Windows.Forms.RadioButton()
        Me.rbLocal = New System.Windows.Forms.RadioButton()
        Me.cmbEquipoFiltrado = New System.Windows.Forms.ComboBox()
        Me.lsvEquipos = New System.Windows.Forms.ListView()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.grpFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(15, 15)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(56, 17)
        Me.chkTodos.TabIndex = 0
        Me.chkTodos.Text = "Todos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'grpFiltro
        '
        Me.grpFiltro.Controls.Add(Me.btnFiltrar)
        Me.grpFiltro.Controls.Add(Me.rbVisitante)
        Me.grpFiltro.Controls.Add(Me.rbLocal)
        Me.grpFiltro.Controls.Add(Me.cmbEquipoFiltrado)
        Me.grpFiltro.Location = New System.Drawing.Point(15, 35)
        Me.grpFiltro.Name = "grpFiltro"
        Me.grpFiltro.Size = New System.Drawing.Size(550, 70)
        Me.grpFiltro.TabIndex = 1
        Me.grpFiltro.TabStop = False
        Me.grpFiltro.Text = "Filtro"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(400, 28)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 3
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'rbVisitante
        '
        Me.rbVisitante.AutoSize = True
        Me.rbVisitante.Location = New System.Drawing.Point(310, 34)
        Me.rbVisitante.Name = "rbVisitante"
        Me.rbVisitante.Size = New System.Drawing.Size(65, 17)
        Me.rbVisitante.TabIndex = 2
        Me.rbVisitante.TabStop = True
        Me.rbVisitante.Text = "Visitante"
        Me.rbVisitante.UseVisualStyleBackColor = True
        '
        'rbLocal
        '
        Me.rbLocal.AutoSize = True
        Me.rbLocal.Location = New System.Drawing.Point(240, 34)
        Me.rbLocal.Name = "rbLocal"
        Me.rbLocal.Size = New System.Drawing.Size(51, 17)
        Me.rbLocal.TabIndex = 1
        Me.rbLocal.TabStop = True
        Me.rbLocal.Text = "Local"
        Me.rbLocal.UseVisualStyleBackColor = True
        '
        'cmbEquipoFiltrado
        '
        Me.cmbEquipoFiltrado.FormattingEnabled = True
        Me.cmbEquipoFiltrado.Location = New System.Drawing.Point(30, 30)
        Me.cmbEquipoFiltrado.Name = "cmbEquipoFiltrado"
        Me.cmbEquipoFiltrado.Size = New System.Drawing.Size(180, 21)
        Me.cmbEquipoFiltrado.TabIndex = 0
        '
        'lsvEquipos
        '
        Me.lsvEquipos.HideSelection = False
        Me.lsvEquipos.Location = New System.Drawing.Point(15, 114)
        Me.lsvEquipos.Name = "lsvEquipos"
        Me.lsvEquipos.Size = New System.Drawing.Size(550, 288)
        Me.lsvEquipos.TabIndex = 2
        Me.lsvEquipos.UseCompatibleStateImageBehavior = False
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(260, 415)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 3
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmExportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 450)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.lsvEquipos)
        Me.Controls.Add(Me.grpFiltro)
        Me.Controls.Add(Me.chkTodos)
        Me.Name = "frmExportacion"
        Me.Text = "Exportacion"
        Me.grpFiltro.ResumeLayout(False)
        Me.grpFiltro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkTodos As CheckBox
    Friend WithEvents grpFiltro As GroupBox
    Friend WithEvents btnFiltrar As Button
    Friend WithEvents rbVisitante As RadioButton
    Friend WithEvents rbLocal As RadioButton
    Friend WithEvents cmbEquipoFiltrado As ComboBox
    Friend WithEvents lsvEquipos As ListView
    Friend WithEvents btnExportar As Button
End Class
