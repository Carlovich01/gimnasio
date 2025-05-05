<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMiembrosPopup
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
        Label2 = New Label()
        Label3 = New Label()
        tbNombre = New TextBox()
        Label1 = New Label()
        tbApellido = New TextBox()
        cbGenero = New ComboBox()
        labelTelefono = New Label()
        Label5 = New Label()
        tbEmail = New TextBox()
        Label6 = New Label()
        tbDni = New TextBox()
        tbTelefono = New TextBox()
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
        btnCancelar.Location = New Point(378, 425)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(82, 31)
        btnCancelar.TabIndex = 35
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
        btnGuardar.Location = New Point(156, 425)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(83, 31)
        btnGuardar.TabIndex = 34
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(60, 146)
        Label2.Name = "Label2"
        Label2.Size = New Size(87, 21)
        Label2.TabIndex = 26
        Label2.Text = "Apellido(*):"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(83, 213)
        Label3.Name = "Label3"
        Label3.Size = New Size(64, 21)
        Label3.TabIndex = 28
        Label3.Text = "Genero:"
        ' 
        ' tbNombre
        ' 
        tbNombre.Cursor = Cursors.IBeam
        tbNombre.Font = New Font("Segoe UI", 12F)
        tbNombre.Location = New Point(153, 87)
        tbNombre.Name = "tbNombre"
        tbNombre.Size = New Size(418, 29)
        tbNombre.TabIndex = 33
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(59, 87)
        Label1.Name = "Label1"
        Label1.Size = New Size(88, 21)
        Label1.TabIndex = 29
        Label1.Text = "Nombre(*):"
        ' 
        ' tbApellido
        ' 
        tbApellido.Cursor = Cursors.IBeam
        tbApellido.Font = New Font("Segoe UI", 12F)
        tbApellido.Location = New Point(153, 146)
        tbApellido.Name = "tbApellido"
        tbApellido.Size = New Size(418, 29)
        tbApellido.TabIndex = 33
        ' 
        ' cbGenero
        ' 
        cbGenero.Font = New Font("Segoe UI", 12F)
        cbGenero.FormattingEnabled = True
        cbGenero.Items.AddRange(New Object() {"Masculino", "Femenino", "Otro", "Prefiero no decir"})
        cbGenero.Location = New Point(155, 210)
        cbGenero.Name = "cbGenero"
        cbGenero.Size = New Size(306, 29)
        cbGenero.TabIndex = 37
        ' 
        ' labelTelefono
        ' 
        labelTelefono.AutoSize = True
        labelTelefono.Font = New Font("Segoe UI", 12F)
        labelTelefono.ForeColor = Color.White
        labelTelefono.Location = New Point(69, 268)
        labelTelefono.Name = "labelTelefono"
        labelTelefono.Size = New Size(71, 21)
        labelTelefono.TabIndex = 28
        labelTelefono.Text = "Telefono:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(89, 325)
        Label5.Name = "Label5"
        Label5.Size = New Size(51, 21)
        Label5.TabIndex = 28
        Label5.Text = "Email:"
        ' 
        ' tbEmail
        ' 
        tbEmail.Font = New Font("Segoe UI", 12F)
        tbEmail.Location = New Point(156, 322)
        tbEmail.Name = "tbEmail"
        tbEmail.Size = New Size(419, 29)
        tbEmail.TabIndex = 38
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(83, 35)
        Label6.Name = "Label6"
        Label6.Size = New Size(57, 21)
        Label6.TabIndex = 29
        Label6.Text = "DNI(*):"
        ' 
        ' tbDni
        ' 
        tbDni.Cursor = Cursors.IBeam
        tbDni.Font = New Font("Segoe UI", 12F)
        tbDni.Location = New Point(155, 35)
        tbDni.Name = "tbDni"
        tbDni.Size = New Size(418, 29)
        tbDni.TabIndex = 33
        ' 
        ' tbTelefono
        ' 
        tbTelefono.Cursor = Cursors.IBeam
        tbTelefono.Font = New Font("Segoe UI", 12F)
        tbTelefono.Location = New Point(156, 265)
        tbTelefono.Name = "tbTelefono"
        tbTelefono.Size = New Size(305, 29)
        tbTelefono.TabIndex = 39
        ' 
        ' FrmMiembrosPopup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(619, 507)
        Controls.Add(tbTelefono)
        Controls.Add(tbEmail)
        Controls.Add(cbGenero)
        Controls.Add(btnCancelar)
        Controls.Add(btnGuardar)
        Controls.Add(Label2)
        Controls.Add(Label5)
        Controls.Add(labelTelefono)
        Controls.Add(Label3)
        Controls.Add(tbApellido)
        Controls.Add(tbDni)
        Controls.Add(tbNombre)
        Controls.Add(Label6)
        Controls.Add(Label1)
        MinimumSize = New Size(613, 463)
        Name = "FrmMiembrosPopup"
        Text = "FrmMiembrosPopup"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents tbPrecio As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbApellido As TextBox
    Friend WithEvents cbGenero As ComboBox
    Friend WithEvents labelTelefono As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbDni As TextBox
    Friend WithEvents tbTelefono As TextBox
End Class
