<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        PictureBox1 = New PictureBox()
        tbUsuario = New TextBox()
        tbContraseña = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        btIniciarSesion = New Button()
        pbOjoCerrado = New PictureBox()
        pbOjoAbierto = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbOjoCerrado, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbOjoAbierto, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(193, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(302, 253)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' tbUsuario
        ' 
        tbUsuario.Font = New Font("Segoe UI", 16F)
        tbUsuario.Location = New Point(154, 291)
        tbUsuario.Name = "tbUsuario"
        tbUsuario.Size = New Size(438, 36)
        tbUsuario.TabIndex = 2
        tbUsuario.Text = "admin"
        ' 
        ' tbContraseña
        ' 
        tbContraseña.Font = New Font("Segoe UI", 16F)
        tbContraseña.Location = New Point(154, 362)
        tbContraseña.Name = "tbContraseña"
        tbContraseña.Size = New Size(438, 36)
        tbContraseña.TabIndex = 2
        tbContraseña.Text = "1234"
        tbContraseña.UseSystemPasswordChar = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 16F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(48, 291)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 30)
        Label1.TabIndex = 3
        Label1.Text = "Usuario:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(12, 365)
        Label2.Name = "Label2"
        Label2.Size = New Size(127, 30)
        Label2.TabIndex = 3
        Label2.Text = "Contraseña:"
        ' 
        ' btIniciarSesion
        ' 
        btIniciarSesion.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        btIniciarSesion.FlatStyle = FlatStyle.Flat
        btIniciarSesion.Font = New Font("Segoe UI", 16F)
        btIniciarSesion.Location = New Point(260, 432)
        btIniciarSesion.Name = "btIniciarSesion"
        btIniciarSesion.Size = New Size(159, 43)
        btIniciarSesion.TabIndex = 4
        btIniciarSesion.Text = "Iniciar Sesión"
        btIniciarSesion.UseVisualStyleBackColor = False
        ' 
        ' pbOjoCerrado
        ' 
        pbOjoCerrado.Image = CType(resources.GetObject("pbOjoCerrado.Image"), Image)
        pbOjoCerrado.Location = New Point(608, 357)
        pbOjoCerrado.Name = "pbOjoCerrado"
        pbOjoCerrado.Size = New Size(52, 50)
        pbOjoCerrado.SizeMode = PictureBoxSizeMode.Zoom
        pbOjoCerrado.TabIndex = 5
        pbOjoCerrado.TabStop = False
        ' 
        ' pbOjoAbierto
        ' 
        pbOjoAbierto.Image = CType(resources.GetObject("pbOjoAbierto.Image"), Image)
        pbOjoAbierto.Location = New Point(608, 357)
        pbOjoAbierto.Name = "pbOjoAbierto"
        pbOjoAbierto.Size = New Size(52, 50)
        pbOjoAbierto.SizeMode = PictureBoxSizeMode.Zoom
        pbOjoAbierto.TabIndex = 56
        pbOjoAbierto.TabStop = False
        ' 
        ' FrmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(682, 503)
        Controls.Add(btIniciarSesion)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(tbContraseña)
        Controls.Add(tbUsuario)
        Controls.Add(PictureBox1)
        Controls.Add(pbOjoCerrado)
        Controls.Add(pbOjoAbierto)
        Name = "FrmLogin"
        Text = "FrmLogin"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(pbOjoCerrado, ComponentModel.ISupportInitialize).EndInit()
        CType(pbOjoAbierto, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents tbUsuario As TextBox
    Friend WithEvents tbContraseña As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btIniciarSesion As Button
    Friend WithEvents pbOjoCerrado As PictureBox
    Friend WithEvents pbOjoAbierto As PictureBox
End Class
