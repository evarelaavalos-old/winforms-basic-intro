<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPresentacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPresentacion))
        Me.pcbPresentacion = New System.Windows.Forms.PictureBox()
        Me.lblPresentacion = New System.Windows.Forms.Label()
        CType(Me.pcbPresentacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pcbPresentacion
        '
        Me.pcbPresentacion.Image = CType(resources.GetObject("pcbPresentacion.Image"), System.Drawing.Image)
        Me.pcbPresentacion.Location = New System.Drawing.Point(45, 25)
        Me.pcbPresentacion.Name = "pcbPresentacion"
        Me.pcbPresentacion.Size = New System.Drawing.Size(560, 304)
        Me.pcbPresentacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbPresentacion.TabIndex = 0
        Me.pcbPresentacion.TabStop = False
        '
        'lblPresentacion
        '
        Me.lblPresentacion.AutoSize = True
        Me.lblPresentacion.Font = New System.Drawing.Font("Arial Rounded MT Bold", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresentacion.Location = New System.Drawing.Point(175, 360)
        Me.lblPresentacion.Name = "lblPresentacion"
        Me.lblPresentacion.Size = New System.Drawing.Size(307, 33)
        Me.lblPresentacion.TabIndex = 1
        Me.lblPresentacion.Text = "Trabajo Practico Nº1"
        '
        'frmPresentacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 450)
        Me.Controls.Add(Me.lblPresentacion)
        Me.Controls.Add(Me.pcbPresentacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPresentacion"
        Me.Text = "frmPresentacion"
        CType(Me.pcbPresentacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pcbPresentacion As PictureBox
    Friend WithEvents lblPresentacion As Label
End Class
