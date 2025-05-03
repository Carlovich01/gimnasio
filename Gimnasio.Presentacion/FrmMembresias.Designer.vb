<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMembresias
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
        lblTotal = New Label()
        btnActualizar = New Button()
        btnEliminar = New Button()
        btnDesactivar = New Button()
        btnActivar = New Button()
        dgvListado = New DataGridView()
        tbBuscar = New TextBox()
        btnInsertar = New Button()
        CType(dgvListado, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.AutoSize = True
        lblTotal.BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        lblTotal.Font = New Font("Segoe UI", 12F)
        lblTotal.ForeColor = Color.White
        lblTotal.Location = New Point(811, 687)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(42, 21)
        lblTotal.TabIndex = 21
        lblTotal.Text = "Total"
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnActualizar.Font = New Font("Segoe UI", 12F)
        btnActualizar.Location = New Point(118, 687)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(92, 28)
        btnActualizar.TabIndex = 17
        btnActualizar.Text = "Actualizar"
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' btnEliminar
        ' 
        btnEliminar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnEliminar.Font = New Font("Segoe UI", 12F)
        btnEliminar.Location = New Point(227, 687)
        btnEliminar.Name = "btnEliminar"
        btnEliminar.Size = New Size(92, 28)
        btnEliminar.TabIndex = 20
        btnEliminar.Text = "Eliminar"
        btnEliminar.UseVisualStyleBackColor = True
        ' 
        ' btnDesactivar
        ' 
        btnDesactivar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnDesactivar.Font = New Font("Segoe UI", 12F)
        btnDesactivar.Location = New Point(444, 687)
        btnDesactivar.Name = "btnDesactivar"
        btnDesactivar.Size = New Size(92, 28)
        btnDesactivar.TabIndex = 18
        btnDesactivar.Text = "Desactivar"
        btnDesactivar.UseVisualStyleBackColor = True
        ' 
        ' btnActivar
        ' 
        btnActivar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnActivar.Font = New Font("Segoe UI", 12F)
        btnActivar.Location = New Point(334, 687)
        btnActivar.Name = "btnActivar"
        btnActivar.Size = New Size(92, 28)
        btnActivar.TabIndex = 19
        btnActivar.Text = "Activar"
        btnActivar.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvListado.DefaultCellStyle = DataGridViewCellStyle2
        dgvListado.GridColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        dgvListado.Location = New Point(11, 57)
        dgvListado.Name = "dgvListado"
        dgvListado.ReadOnly = True
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvListado.Size = New Size(986, 618)
        dgvListado.TabIndex = 15
        ' 
        ' tbBuscar
        ' 
        tbBuscar.Font = New Font("Segoe UI", 12F)
        tbBuscar.Location = New Point(11, 13)
        tbBuscar.Name = "tbBuscar"
        tbBuscar.Size = New Size(866, 29)
        tbBuscar.TabIndex = 16
        ' 
        ' btnInsertar
        ' 
        btnInsertar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnInsertar.Font = New Font("Segoe UI", 12F)
        btnInsertar.Location = New Point(11, 686)
        btnInsertar.Name = "btnInsertar"
        btnInsertar.Size = New Size(92, 28)
        btnInsertar.TabIndex = 22
        btnInsertar.Text = "Insertar"
        btnInsertar.UseVisualStyleBackColor = True
        ' 
        ' FrmMembresias
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(1008, 729)
        Controls.Add(lblTotal)
        Controls.Add(btnActualizar)
        Controls.Add(btnEliminar)
        Controls.Add(btnDesactivar)
        Controls.Add(btnActivar)
        Controls.Add(dgvListado)
        Controls.Add(tbBuscar)
        Controls.Add(btnInsertar)
        Name = "FrmMembresias"
        Text = "FrmMembresias"
        CType(dgvListado, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblTotal As Label
    Friend WithEvents btnActualizar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnDesactivar As Button
    Friend WithEvents btnActivar As Button
    Friend WithEvents dgvListado As DataGridView
    Friend WithEvents tbBuscar As TextBox
    Friend WithEvents btnInsertar As Button
End Class
