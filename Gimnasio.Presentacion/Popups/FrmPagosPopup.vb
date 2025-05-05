Imports Gimnasio.Negocio
Imports Gimnasio.Entidades

Public Class FrmPagosPopup
    Private idMembresia As Integer
    Private monto As Decimal

    Public Sub New(idMembresia As Integer, monto As Decimal)
        InitializeComponent()
        Me.idMembresia = idMembresia
        Me.monto = monto
    End Sub

    Private Sub FrmPagosPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            tbMonto.Text = monto.ToString("F2")
            tbMonto.ReadOnly = True
            cbMetodo.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar el formulario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim pago As New Pagos With {
                .IdMembresia = idMembresia,
                .IdUsuarioRegistro = UsuarioLogueado.IdUsuario,
                .MontoPagado = Convert.ToDecimal(tbMonto.Text),
                .MetodoPago = cbMetodo.SelectedItem.ToString(),
                .NumeroComprobante = tbComprobante.Text,
                .Notas = tbNotas.Text
            }

            Dim nPagos As New NPagos()
            nPagos.Insertar(pago)

            MsgBox("Pago registrado correctamente.", MsgBoxStyle.Information, "Éxito")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al registrar el pago: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al cerrar el formulario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class