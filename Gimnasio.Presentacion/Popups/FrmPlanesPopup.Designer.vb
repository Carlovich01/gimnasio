<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanesPopup
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
        btnCancelar = New Button()
        btnGuardar = New Button()
        tbDescripcion = New TextBox()
        Label2 = New Label()
        tbPrecio = New TextBox()
        Label4 = New Label()
        tbDuracion = New TextBox()
        Label3 = New Label()
        tbNombre = New TextBox()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' btnCancelar
        ' 
        btnCancelar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnCancelar.FlatAppearance.BorderSize = 0
        btnCancelar.FlatAppearance.MouseDownBackColor = Color.White
        btnCancelar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Font = New Font("Segoe UI", 12F)
        btnCancelar.Location = New Point(364, 399)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(82, 31)
        btnCancelar.TabIndex = 25
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = False
        ' 
        ' btnGuardar
        ' 
        btnGuardar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardar.FlatAppearance.BorderColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btnGuardar.FlatAppearance.MouseDownBackColor = Color.White
        btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnGuardar.FlatStyle = FlatStyle.Flat
        btnGuardar.Font = New Font("Segoe UI", 12F)
        btnGuardar.Location = New Point(104, 399)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(83, 31)
        btnGuardar.TabIndex = 24
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' tbDescripcion
        ' 
        tbDescripcion.Cursor = Cursors.IBeam
        tbDescripcion.Font = New Font("Segoe UI", 12F)
        tbDescripcion.Location = New Point(104, 100)
        tbDescripcion.Multiline = True
        tbDescripcion.Name = "tbDescripcion"
        tbDescripcion.Size = New Size(418, 111)
        tbDescripcion.TabIndex = 19
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(4, 98)
        Label2.Name = "Label2"
        Label2.Size = New Size(94, 21)
        Label2.TabIndex = 15
        Label2.Text = "Descripcion:"
        ' 
        ' tbPrecio
        ' 
        tbPrecio.Font = New Font("Segoe UI", 12F)
        tbPrecio.Location = New Point(104, 315)
        tbPrecio.Name = "tbPrecio"
        tbPrecio.Size = New Size(158, 29)
        tbPrecio.TabIndex = 20
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(5, 265)
        Label4.Name = "Label4"
        Label4.Size = New Size(93, 21)
        Label4.TabIndex = 16
        Label4.Text = "Duracion(*):"
        ' 
        ' tbDuracion
        ' 
        tbDuracion.Font = New Font("Segoe UI", 12F)
        tbDuracion.Location = New Point(104, 263)
        tbDuracion.Name = "tbDuracion"
        tbDuracion.Size = New Size(158, 29)
        tbDuracion.TabIndex = 22
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(20, 315)
        Label3.Name = "Label3"
        Label3.Size = New Size(73, 21)
        Label3.TabIndex = 17
        Label3.Text = "Precio(*):"
        ' 
        ' tbNombre
        ' 
        tbNombre.Cursor = Cursors.IBeam
        tbNombre.Font = New Font("Segoe UI", 12F)
        tbNombre.Location = New Point(104, 56)
        tbNombre.Name = "tbNombre"
        tbNombre.Size = New Size(418, 29)
        tbNombre.TabIndex = 23
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(9, 54)
        Label1.Name = "Label1"
        Label1.Size = New Size(88, 21)
        Label1.TabIndex = 18
        Label1.Text = "Nombre(*):"
        ' 
        ' FrmPlanesPopup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(537, 447)
        Controls.Add(btnCancelar)
        Controls.Add(btnGuardar)
        Controls.Add(tbDescripcion)
        Controls.Add(Label2)
        Controls.Add(tbPrecio)
        Controls.Add(Label4)
        Controls.Add(tbDuracion)
        Controls.Add(Label3)
        Controls.Add(tbNombre)
        Controls.Add(Label1)
        MinimumSize = New Size(553, 486)
        Name = "FrmPlanesPopup"
        Text = "FrmPlanesPopup"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents tbDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbPrecio As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbDuracion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbNombre As TextBox
    Friend WithEvents Label1 As Label
End Class
