<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagosPopup
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        tbMonto = New TextBox()
        tbComprobante = New TextBox()
        tbNotas = New TextBox()
        cbMetodo = New ComboBox()
        BtnGuardar = New Button()
        BtnCancelar = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(79, 110)
        Label1.Name = "Label1"
        Label1.Size = New Size(77, 21)
        Label1.TabIndex = 0
        Label1.Text = "Monto (*)"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(79, 167)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 21)
        Label2.TabIndex = 1
        Label2.Text = "Metodo (*)"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(46, 224)
        Label3.Name = "Label3"
        Label3.Size = New Size(128, 21)
        Label3.TabIndex = 2
        Label3.Text = "N° Comprobante"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(100, 275)
        Label4.Name = "Label4"
        Label4.Size = New Size(51, 21)
        Label4.TabIndex = 3
        Label4.Text = "Notas"
        ' 
        ' tbMonto
        ' 
        tbMonto.Font = New Font("Segoe UI", 12F)
        tbMonto.Location = New Point(182, 110)
        tbMonto.Name = "tbMonto"
        tbMonto.ReadOnly = True
        tbMonto.Size = New Size(343, 29)
        tbMonto.TabIndex = 4
        ' 
        ' tbComprobante
        ' 
        tbComprobante.Font = New Font("Segoe UI", 12F)
        tbComprobante.Location = New Point(182, 216)
        tbComprobante.Name = "tbComprobante"
        tbComprobante.Size = New Size(343, 29)
        tbComprobante.TabIndex = 6
        ' 
        ' tbNotas
        ' 
        tbNotas.Font = New Font("Segoe UI", 12F)
        tbNotas.Location = New Point(182, 272)
        tbNotas.Name = "tbNotas"
        tbNotas.Size = New Size(343, 29)
        tbNotas.TabIndex = 7
        ' 
        ' cbMetodo
        ' 
        cbMetodo.Font = New Font("Segoe UI", 12F)
        cbMetodo.FormattingEnabled = True
        cbMetodo.Items.AddRange(New Object() {"Efectivo", "Tarjeta Débito", "Tarjeta Crédito", "Transferencia Bancaria", "Mercado Pago", "Otro"})
        cbMetodo.Location = New Point(182, 167)
        cbMetodo.Name = "cbMetodo"
        cbMetodo.Size = New Size(343, 29)
        cbMetodo.TabIndex = 8
        ' 
        ' BtnGuardar
        ' 
        BtnGuardar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        BtnGuardar.FlatStyle = FlatStyle.Flat
        BtnGuardar.Font = New Font("Segoe UI", 12F)
        BtnGuardar.ForeColor = Color.Black
        BtnGuardar.Location = New Point(182, 364)
        BtnGuardar.Name = "BtnGuardar"
        BtnGuardar.Size = New Size(83, 34)
        BtnGuardar.TabIndex = 9
        BtnGuardar.Text = "Guardar"
        BtnGuardar.UseVisualStyleBackColor = False
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.BackColor = Color.FromArgb(CByte(123), CByte(179), CByte(75))
        BtnCancelar.FlatStyle = FlatStyle.Flat
        BtnCancelar.Font = New Font("Segoe UI", 12F)
        BtnCancelar.ForeColor = Color.Black
        BtnCancelar.Location = New Point(345, 364)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(85, 34)
        BtnCancelar.TabIndex = 10
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = False
        ' 
        ' FrmPagosPopup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(5), CByte(18), CByte(26))
        ClientSize = New Size(591, 465)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnGuardar)
        Controls.Add(cbMetodo)
        Controls.Add(tbNotas)
        Controls.Add(tbComprobante)
        Controls.Add(tbMonto)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        ForeColor = Color.White
        Name = "FrmPagosPopup"
        Text = "FrmPagosPopup"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbMonto As TextBox
    Friend WithEvents tbComprobante As TextBox
    Friend WithEvents tbNotas As TextBox
    Friend WithEvents cbMetodo As ComboBox
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnCancelar As Button
End Class
