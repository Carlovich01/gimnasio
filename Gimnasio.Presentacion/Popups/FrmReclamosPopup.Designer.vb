<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReclamosPopup
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
        Label1 = New Label()
        cbTipo = New ComboBox()
        tbDNI = New TextBox()
        Label3 = New Label()
        TbRespuesta = New TextBox()
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
        btnCancelar.Location = New Point(370, 344)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(126, 29)
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
        btnGuardar.Location = New Point(137, 344)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(126, 29)
        btnGuardar.TabIndex = 34
        btnGuardar.Text = "Guardar"
        btnGuardar.UseVisualStyleBackColor = False
        ' 
        ' tbDescripcion
        ' 
        tbDescripcion.Cursor = Cursors.IBeam
        tbDescripcion.Font = New Font("Segoe UI", 12F)
        tbDescripcion.Location = New Point(137, 85)
        tbDescripcion.Multiline = True
        tbDescripcion.Name = "tbDescripcion"
        tbDescripcion.Size = New Size(418, 111)
        tbDescripcion.TabIndex = 30
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(20, 88)
        Label2.Name = "Label2"
        Label2.Size = New Size(111, 21)
        Label2.TabIndex = 26
        Label2.Text = "Descripcion(*):"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(71, 16)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 21)
        Label1.TabIndex = 29
        Label1.Text = "Tipo(*):"
        ' 
        ' cbTipo
        ' 
        cbTipo.FormattingEnabled = True
        cbTipo.Items.AddRange(New Object() {"sugerencia", "reclamo"})
        cbTipo.Location = New Point(137, 18)
        cbTipo.Name = "cbTipo"
        cbTipo.Size = New Size(418, 23)
        cbTipo.TabIndex = 36
        ' 
        ' tbDNI
        ' 
        tbDNI.Cursor = Cursors.IBeam
        tbDNI.Font = New Font("Segoe UI", 12F)
        tbDNI.Location = New Point(137, 240)
        tbDNI.Name = "tbDNI"
        tbDNI.Size = New Size(418, 29)
        tbDNI.TabIndex = 37
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(18, 243)
        Label3.Name = "Label3"
        Label3.Size = New Size(113, 21)
        Label3.TabIndex = 38
        Label3.Text = "DNI (opcional):"
        ' 
        ' TbRespuesta
        ' 
        TbRespuesta.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        TbRespuesta.Font = New Font("Segoe UI", 12F)
        TbRespuesta.Location = New Point(18, 12)
        TbRespuesta.Multiline = True
        TbRespuesta.Name = "TbRespuesta"
        TbRespuesta.Size = New Size(570, 301)
        TbRespuesta.TabIndex = 44
        TbRespuesta.Visible = False
        ' 
        ' FrmReclamosPopup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(600, 393)
        Controls.Add(TbRespuesta)
        Controls.Add(Label3)
        Controls.Add(tbDNI)
        Controls.Add(cbTipo)
        Controls.Add(btnCancelar)
        Controls.Add(btnGuardar)
        Controls.Add(tbDescripcion)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "FrmReclamosPopup"
        Text = "FrmReclamosPopup"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents tbDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbTipo As ComboBox
    Friend WithEvents tbDNI As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TbRespuesta As TextBox
End Class
