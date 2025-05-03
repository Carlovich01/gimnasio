<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMembresiasPopup
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        btnCancelar = New Button()
        btnGuardar = New Button()
        Label2 = New Label()
        Label1 = New Label()
        dgvMiembro = New DataGridView()
        dgvPlan = New DataGridView()
        cbOpcionBuscarMiembro = New ComboBox()
        tbBuscarMiembro = New TextBox()
        tbBuscarPlan = New TextBox()
        cbBuscarOpcionPlan = New ComboBox()
        Panel1 = New Panel()
        Panel2 = New Panel()
        CType(dgvMiembro, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvPlan, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
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
        btnCancelar.Location = New Point(596, 387)
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
        btnGuardar.Location = New Point(287, 387)
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
        Label2.Location = New Point(46, 6)
        Label2.Name = "Label2"
        Label2.Size = New Size(60, 21)
        Label2.TabIndex = 26
        Label2.Text = "Plan(*):"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(12, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 21)
        Label1.TabIndex = 29
        Label1.Text = "Miembro(*):"
        ' 
        ' dgvMiembro
        ' 
        dgvMiembro.AllowUserToAddRows = False
        dgvMiembro.AllowUserToDeleteRows = False
        dgvMiembro.AllowUserToOrderColumns = True
        dgvMiembro.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvMiembro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMiembro.BackgroundColor = Color.FromArgb(CByte(85), CByte(96), CByte(105))
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Window
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvMiembro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvMiembro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMiembro.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvMiembro.Location = New Point(12, 70)
        dgvMiembro.MultiSelect = False
        dgvMiembro.Name = "dgvMiembro"
        dgvMiembro.ReadOnly = True
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvMiembro.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvMiembro.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMiembro.Size = New Size(916, 110)
        dgvMiembro.TabIndex = 36
        ' 
        ' dgvPlan
        ' 
        dgvPlan.AllowUserToAddRows = False
        dgvPlan.AllowUserToDeleteRows = False
        dgvPlan.AllowUserToOrderColumns = True
        dgvPlan.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPlan.BackgroundColor = Color.FromArgb(CByte(85), CByte(96), CByte(105))
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvPlan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvPlan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPlan.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvPlan.Location = New Point(12, 46)
        dgvPlan.Name = "dgvPlan"
        dgvPlan.ReadOnly = True
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Window
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle4.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dgvPlan.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgvPlan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPlan.Size = New Size(916, 108)
        dgvPlan.TabIndex = 37
        ' 
        ' cbOpcionBuscarMiembro
        ' 
        cbOpcionBuscarMiembro.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscarMiembro.FormattingEnabled = True
        cbOpcionBuscarMiembro.Items.AddRange(New Object() {"Buscar por nombre", "Buscar por DNI"})
        cbOpcionBuscarMiembro.Location = New Point(773, 13)
        cbOpcionBuscarMiembro.Name = "cbOpcionBuscarMiembro"
        cbOpcionBuscarMiembro.Size = New Size(155, 29)
        cbOpcionBuscarMiembro.TabIndex = 39
        ' 
        ' tbBuscarMiembro
        ' 
        tbBuscarMiembro.Font = New Font("Segoe UI", 12F)
        tbBuscarMiembro.Location = New Point(125, 13)
        tbBuscarMiembro.Name = "tbBuscarMiembro"
        tbBuscarMiembro.Size = New Size(619, 29)
        tbBuscarMiembro.TabIndex = 38
        ' 
        ' tbBuscarPlan
        ' 
        tbBuscarPlan.Font = New Font("Segoe UI", 12F)
        tbBuscarPlan.Location = New Point(125, 6)
        tbBuscarPlan.Name = "tbBuscarPlan"
        tbBuscarPlan.Size = New Size(619, 29)
        tbBuscarPlan.TabIndex = 40
        ' 
        ' cbBuscarOpcionPlan
        ' 
        cbBuscarOpcionPlan.Font = New Font("Segoe UI", 12F)
        cbBuscarOpcionPlan.FormattingEnabled = True
        cbBuscarOpcionPlan.Items.AddRange(New Object() {"Nombre"})
        cbBuscarOpcionPlan.Location = New Point(773, 6)
        cbBuscarOpcionPlan.Name = "cbBuscarOpcionPlan"
        cbBuscarOpcionPlan.Size = New Size(155, 29)
        cbBuscarOpcionPlan.TabIndex = 41
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(dgvMiembro)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(tbBuscarMiembro)
        Panel1.Controls.Add(cbOpcionBuscarMiembro)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(952, 208)
        Panel1.TabIndex = 42
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(dgvPlan)
        Panel2.Controls.Add(tbBuscarPlan)
        Panel2.Controls.Add(cbBuscarOpcionPlan)
        Panel2.Controls.Add(Label2)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 208)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(952, 162)
        Panel2.TabIndex = 43
        ' 
        ' FrmMembresiasPopup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(952, 450)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(btnCancelar)
        Controls.Add(btnGuardar)
        Name = "FrmMembresiasPopup"
        Text = "FrmMembresiasPopup"
        WindowState = FormWindowState.Maximized
        CType(dgvMiembro, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvPlan, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvMiembro As DataGridView
    Friend WithEvents dgvPlan As DataGridView
    Friend WithEvents cbOpcionBuscarMiembro As ComboBox
    Friend WithEvents tbBuscarMiembro As TextBox
    Friend WithEvents tbBuscarPlan As TextBox
    Friend WithEvents cbBuscarOpcionPlan As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
