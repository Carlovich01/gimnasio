<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReclamos
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
        btnEliminar = New Button()
        cbOpcionBuscar = New ComboBox()
        lblTotal = New Label()
        btnActualizar = New Button()
        btnCambiarEstado = New Button()
        btnResponder = New Button()
        dgvListado = New DataGridView()
        btnInsertar = New Button()
        Label1 = New Label()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(236, 689)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(92, 28)
        btnEliminar.TabIndex = 42
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' cbOpcionBuscar
        ' 
        cbOpcionBuscar.Font = New Font("Segoe UI", 12F)
        cbOpcionBuscar.FormattingEnabled = True
        cbOpcionBuscar.Items.AddRange(New Object() {"pendiente", "resuelto"})
        cbOpcionBuscar.Location = New Point(110, 12)
        cbOpcionBuscar.Name = "cbOpcionBuscar"
        cbOpcionBuscar.Size = New Size(253, 29)
        cbOpcionBuscar.TabIndex = 41
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lblTotal.Font = New Font("Segoe UI", 12F)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(835, 693)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(42, 21)
        lblTotal.TabIndex = 39
        lblTotal.Text = "Total"
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnActualizar.Font = New Font("Segoe UI", 12F)
        btnActualizar.Location = New Point(127, 689)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(92, 28)
        btnActualizar.TabIndex = 36
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' btnCambiarEstado
        ' 
        btnCambiarEstado.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCambiarEstado.Font = New Font("Segoe UI", 12F)
        btnCambiarEstado.Location = New Point(351, 689)
        btnCambiarEstado.Name = "btnCambiarEstado"
        btnCambiarEstado.Size = New Size(138, 28)
        btnCambiarEstado.TabIndex = 37
        btnCambiarEstado.Text = "Cambiar Estado"
        btnCambiarEstado.UseVisualStyleBackColor = True
        ' 
        ' btnResponder
        ' 
        btnResponder.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnResponder.Font = New Font("Segoe UI", 12F)
        btnResponder.Location = New Point(514, 689)
        btnResponder.Name = "btnResponder"
        btnResponder.Size = New Size(96, 28)
        btnResponder.TabIndex = 38
        btnResponder.Text = "Responder"
        btnResponder.UseVisualStyleBackColor = True
        ' 
        ' dgvListado
        ' 
        dgvListado.AllowUserToAddRows = False
        dgvListado.AllowUserToDeleteRows = False
        dgvListado.AllowUserToOrderColumns = True
        dgvListado.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvListado.BackgroundColor = Color.FromArgb(CByte(85), CByte(96), CByte(105))
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Window
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvListado.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvListado.Location = New Point(11, 57)
        dgvListado.MultiSelect = False
        dgvListado.Name = "dgvListado"
        dgvListado.ReadOnly = True
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListado.Size = New Size(986, 618)
        dgvListado.TabIndex = 34
        ' 
        ' btnInsertar
        ' 
        btnInsertar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertar.Font = New Font("Segoe UI", 12F)
        btnInsertar.Location = New Point(12, 689)
        btnInsertar.Name = "btnInsertar"
        btnInsertar.Size = New Size(92, 28)
        btnInsertar.TabIndex = 40
        btnInsertar.Text = "Insertar"
        btnInsertar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(17, 15)
        Label1.Name = "Label1"
        Label1.Size = New Size(87, 21)
        Label1.TabIndex = 45
        Label1.Text = "Buscar por:"
        ' 
        ' FrmReclamos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(Label1)
        Controls.Add(btnEliminar)
        Controls.Add(cbOpcionBuscar)
        Controls.Add(lblTotal)
        Controls.Add(btnActualizar)
        Controls.Add(btnCambiarEstado)
        Controls.Add(dgvListado)
        Controls.Add(btnInsertar)
        Controls.Add(btnResponder)
        Name = "FrmReclamos"
        Text = "FrmReclamos"
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnEliminar As Button
    Friend WithEvents cbOpcionBuscar As ComboBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnCambiarEstado As Button
    Friend WithEvents btnResponder As Button
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents btnInsertar As Button
    Friend WithEvents Label1 As Label
End Class
