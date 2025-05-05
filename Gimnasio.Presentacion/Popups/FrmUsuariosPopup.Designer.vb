<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsuariosPopup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUsuariosPopup))
        tbEmail = New TextBox()
        cbRol = New ComboBox()
        btnCancelar = New Button()
        btnGuardar = New Button()
        Label2 = New Label()
        labelTelefono = New Label()
        Label3 = New Label()
        tbNombreCompleto = New TextBox()
        tbNombreUsuario = New TextBox()
        tbContraseña = New TextBox()
        Label6 = New Label()
        Label1 = New Label()
        pbOjoCerrado = New PictureBox()
        pbOjoAbierto = New PictureBox()
        CType(pbOjoCerrado, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbOjoAbierto, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tbEmail
        ' 
        tbEmail.Cursor = Cursors.IBeam
        tbEmail.Font = New Font("Segoe UI", 12F)
        tbEmail.Location = New Point(188, 193)
        tbEmail.Name = "tbEmail"
        tbEmail.Size = New Size(305, 29)
        tbEmail.TabIndex = 53
        ' 
        ' cbRol
        ' 
        cbRol.Font = New Font("Segoe UI", 12F)
        cbRol.FormattingEnabled = True
        cbRol.Items.AddRange(New Object() {"Administrador", "Recepcionista"})
        cbRol.Location = New Point(188, 249)
        cbRol.Name = "cbRol"
        cbRol.Size = New Size(306, 29)
        cbRol.TabIndex = 51
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
        btnCancelar.Location = New Point(358, 343)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(82, 31)
        btnCancelar.TabIndex = 50
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
        btnGuardar.Location = New Point(187, 343)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(83, 31)
        btnGuardar.TabIndex = 49
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(17, 142)
        Label2.Name = "Label2"
        Label2.Size = New Size(164, 21)
        Label2.TabIndex = 40
        Label2.Text = "Nombre Completo (*):"
        ' 
        ' labelTelefono
        ' 
        labelTelefono.AutoSize = True
        labelTelefono.Font = New Font("Segoe UI", 12F)
        labelTelefono.ForeColor = Color.White
        labelTelefono.Location = New Point(124, 257)
        labelTelefono.Name = "labelTelefono"
        labelTelefono.Size = New Size(53, 21)
        labelTelefono.TabIndex = 42
        labelTelefono.Text = "Rol(*):"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(124, 196)
        Label3.Name = "Label3"
        Label3.Size = New Size(51, 21)
        Label3.TabIndex = 43
        Label3.Text = "Email:"
        ' 
        ' tbNombreCompleto
        ' 
        tbNombreCompleto.Cursor = Cursors.IBeam
        tbNombreCompleto.Font = New Font("Segoe UI", 12F)
        tbNombreCompleto.Location = New Point(187, 134)
        tbNombreCompleto.Name = "tbNombreCompleto"
        tbNombreCompleto.Size = New Size(418, 29)
        tbNombreCompleto.TabIndex = 46
        ' 
        ' tbNombreUsuario
        ' 
        tbNombreUsuario.Cursor = Cursors.IBeam
        tbNombreUsuario.Font = New Font("Segoe UI", 12F)
        tbNombreUsuario.Location = New Point(187, 23)
        tbNombreUsuario.Name = "tbNombreUsuario"
        tbNombreUsuario.Size = New Size(418, 29)
        tbNombreUsuario.TabIndex = 47
        ' 
        ' tbContraseña
        ' 
        tbContraseña.Cursor = Cursors.IBeam
        tbContraseña.Font = New Font("Segoe UI", 12F)
        tbContraseña.Location = New Point(187, 75)
        tbContraseña.Name = "tbContraseña"
        tbContraseña.Size = New Size(418, 29)
        tbContraseña.TabIndex = 48
        tbContraseña.UseSystemPasswordChar = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(13, 23)
        Label6.Name = "Label6"
        Label6.Size = New Size(167, 21)
        Label6.TabIndex = 44
        Label6.Text = "Nombre de Usuario(*):"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(71, 78)
        Label1.Name = "Label1"
        Label1.Size = New Size(109, 21)
        Label1.TabIndex = 45
        Label1.Text = "Contraseña(*):"
        ' 
        ' pbOjoCerrado
        ' 
        pbOjoCerrado.Image = CType(resources.GetObject("pbOjoCerrado.Image"), Image)
        pbOjoCerrado.Location = New Point(620, 65)
        pbOjoCerrado.Name = "pbOjoCerrado"
        pbOjoCerrado.Size = New Size(52, 50)
        pbOjoCerrado.SizeMode = PictureBoxSizeMode.Zoom
        pbOjoCerrado.TabIndex = 54
        pbOjoCerrado.TabStop = False
        ' 
        ' pbOjoAbierto
        ' 
        pbOjoAbierto.Image = CType(resources.GetObject("pbOjoAbierto.Image"), Image)
        pbOjoAbierto.Location = New Point(620, 65)
        pbOjoAbierto.Name = "pbOjoAbierto"
        pbOjoAbierto.Size = New Size(52, 50)
        pbOjoAbierto.SizeMode = PictureBoxSizeMode.Zoom
        pbOjoAbierto.TabIndex = 55
        pbOjoAbierto.TabStop = False
        ' 
        ' FrmUsuariosPopup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(684, 410)
        Controls.Add(tbEmail)
        Controls.Add(cbRol)
        Controls.Add(btnCancelar)
        Controls.Add(btnGuardar)
        Controls.Add(Label2)
        Controls.Add(labelTelefono)
        Controls.Add(Label3)
        Controls.Add(tbNombreCompleto)
        Controls.Add(tbNombreUsuario)
        Controls.Add(tbContraseña)
        Controls.Add(Label6)
        Controls.Add(Label1)
        Controls.Add(pbOjoCerrado)
        Controls.Add(pbOjoAbierto)
        ForeColor = SystemColors.ControlText
        Name = "FrmUsuariosPopup"
        Text = "FrmUsuariosPopup"
        CType(pbOjoCerrado, ComponentModel.ISupportInitialize).EndInit()
        CType(pbOjoAbierto, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents tbEmail As TextBox
    Friend WithEvents cbRol As ComboBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents labelTelefono As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbNombreCompleto As TextBox
    Friend WithEvents tbNombreUsuario As TextBox
    Friend WithEvents tbContraseña As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pbOjoCerrado As PictureBox
    Friend WithEvents pbOjoAbierto As PictureBox
End Class
