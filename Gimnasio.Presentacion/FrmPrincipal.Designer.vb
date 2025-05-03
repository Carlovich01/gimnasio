<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        ToolStrip1 = New ToolStrip()
        btnPlanes = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        btnMiembros = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        ToolStripSeparator2 = New ToolStripSeparator()
        btnMembresias = New ToolStripButton()
        btnPagos = New ToolStripButton()
        ToolStripSeparator4 = New ToolStripSeparator()
        btnAsistencia = New ToolStripButton()
        ToolStripSeparator5 = New ToolStripSeparator()
        btnReclamos = New ToolStripButton()
        ToolStripSeparator6 = New ToolStripSeparator()
        btnUsuarios = New ToolStripButton()
        ToolStripSeparator7 = New ToolStripSeparator()
        btnRoles = New ToolStripButton()
        ToolStripSeparator8 = New ToolStripSeparator()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        ToolStrip1.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        ToolStrip1.Items.AddRange(New ToolStripItem() {btnPlanes, ToolStripSeparator3, btnMiembros, ToolStripSeparator1, btnMembresias, ToolStripSeparator2, btnPagos, ToolStripSeparator4, btnAsistencia, ToolStripSeparator5, btnReclamos, ToolStripSeparator6, btnUsuarios, ToolStripSeparator7, btnRoles, ToolStripSeparator8})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1008, 28)
        ToolStrip1.TabIndex = 0
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' btnPlanes
        ' 
        btnPlanes.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnPlanes.Font = New Font("Segoe UI", 12F)
        btnPlanes.Image = CType(resources.GetObject("btnPlanes.Image"), Image)
        btnPlanes.ImageTransparentColor = Color.Magenta
        btnPlanes.Name = "btnPlanes"
        btnPlanes.Size = New Size(59, 25)
        btnPlanes.Text = "Planes"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 28)
        ' 
        ' btnMiembros
        ' 
        btnMiembros.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnMiembros.Font = New Font("Segoe UI", 12F)
        btnMiembros.Image = CType(resources.GetObject("btnMiembros.Image"), Image)
        btnMiembros.ImageTransparentColor = Color.Magenta
        btnMiembros.Name = "btnMiembros"
        btnMiembros.Size = New Size(85, 25)
        btnMiembros.Text = "Miembros"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 28)
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 28)
        ' 
        ' btnMembresias
        ' 
        btnMembresias.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnMembresias.Font = New Font("Segoe UI", 12F)
        btnMembresias.Image = CType(resources.GetObject("btnMembresias.Image"), Image)
        btnMembresias.ImageTransparentColor = Color.Magenta
        btnMembresias.Name = "btnMembresias"
        btnMembresias.Size = New Size(99, 25)
        btnMembresias.Text = "Membresías"
        ' 
        ' btnPagos
        ' 
        btnPagos.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnPagos.Font = New Font("Segoe UI", 12F)
        btnPagos.Image = CType(resources.GetObject("btnPagos.Image"), Image)
        btnPagos.ImageTransparentColor = Color.Magenta
        btnPagos.Name = "btnPagos"
        btnPagos.Size = New Size(55, 25)
        btnPagos.Text = "Pagos"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 28)
        ' 
        ' btnAsistencia
        ' 
        btnAsistencia.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnAsistencia.Font = New Font("Segoe UI", 12F)
        btnAsistencia.Image = CType(resources.GetObject("btnAsistencia.Image"), Image)
        btnAsistencia.ImageTransparentColor = Color.Magenta
        btnAsistencia.Name = "btnAsistencia"
        btnAsistencia.Size = New Size(83, 25)
        btnAsistencia.Text = "Asistencia"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(6, 28)
        ' 
        ' btnReclamos
        ' 
        btnReclamos.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnReclamos.Font = New Font("Segoe UI", 12F)
        btnReclamos.Image = CType(resources.GetObject("btnReclamos.Image"), Image)
        btnReclamos.ImageTransparentColor = Color.Magenta
        btnReclamos.Name = "btnReclamos"
        btnReclamos.Size = New Size(81, 25)
        btnReclamos.Text = "Reclamos"
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(6, 28)
        ' 
        ' btnUsuarios
        ' 
        btnUsuarios.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnUsuarios.Font = New Font("Segoe UI", 12F)
        btnUsuarios.Image = CType(resources.GetObject("btnUsuarios.Image"), Image)
        btnUsuarios.ImageTransparentColor = Color.Magenta
        btnUsuarios.Name = "btnUsuarios"
        btnUsuarios.Size = New Size(75, 25)
        btnUsuarios.Text = "Usuarios"
        ' 
        ' ToolStripSeparator7
        ' 
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New Size(6, 28)
        ' 
        ' btnRoles
        ' 
        btnRoles.DisplayStyle = ToolStripItemDisplayStyle.Text
        btnRoles.Font = New Font("Segoe UI", 12F)
        btnRoles.Image = CType(resources.GetObject("btnRoles.Image"), Image)
        btnRoles.ImageTransparentColor = Color.Magenta
        btnRoles.Name = "btnRoles"
        btnRoles.Size = New Size(52, 25)
        btnRoles.Text = "Roles"
        ' 
        ' ToolStripSeparator8
        ' 
        ToolStripSeparator8.Name = "ToolStripSeparator8"
        ToolStripSeparator8.Size = New Size(6, 28)
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 28)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1008, 701)
        Panel1.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(133, 119)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(755, 472)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' FrmPrincipal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        ClientSize = New Size(1008, 729)
        Controls.Add(Panel1)
        Controls.Add(ToolStrip1)
        Name = "FrmPrincipal"
        Text = "Goatym"
        WindowState = FormWindowState.Maximized
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        Panel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnPlanes As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnMembresias As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnMiembros As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnPagos As ToolStripButton
    Friend WithEvents btnAsistencia As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnReclamos As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btnUsuarios As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btnRoles As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
End Class
