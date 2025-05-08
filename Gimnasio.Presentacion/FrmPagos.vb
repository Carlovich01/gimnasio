Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmPagos
    Private nPagos As New NPagos()

    Private Sub FrmPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            dgvListado.Columns("IdPago").Visible = False
            dgvListado.Columns("IdMembresia").Visible = False
            dgvListado.Columns("IdUsuarioRegistro").Visible = False
            dgvListado.Columns("IdPago").HeaderText = "ID PAGO"
            dgvListado.Columns("IdMembresia").HeaderText = "ID MEMBRESIA"
            dgvListado.Columns("IdUsuarioRegistro").HeaderText = "ID USUARIO REGISTRO"
            dgvListado.Columns("ApellidoMiembro").HeaderText = "APELLIDO MIEMBRO"
            dgvListado.Columns("NombreMiembro").HeaderText = "NOMBRE MIEMBRO"
            dgvListado.Columns("DniMiembro").HeaderText = "DNI MIEMBRO"
            dgvListado.Columns("NombrePlan").HeaderText = "NOMBRE PLAN"
            dgvListado.Columns("MontoPagado").HeaderText = "MONTO PAGADO"
            dgvListado.Columns("MetodoPago").HeaderText = "METODO PAGO"
            dgvListado.Columns("NumeroComprobante").HeaderText = "NUMERO COMPROBANTE"
            dgvListado.Columns("FechaPago").HeaderText = "FECHA PAGO"
            dgvListado.Columns("Encargado").HeaderText = "ENCARGADO"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim pagos As List(Of Pagos) = nPagos.Listar()
            dgvListado.DataSource = pagos
            lblTotal.Text = "Total Registros: " & pagos.Count.ToString()

            Dim totalIngresos As Decimal = pagos.Sum(Function(p) p.MontoPagado)
            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString("F2")
        Catch ex As Exception
            MsgBox("Error al cargar los pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnBuscarFecha_Click(sender As Object, e As EventArgs) Handles BtnBuscarFecha.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            Dim pagos As List(Of Pagos) = nPagos.ListarPorFecha(fechaInicio, fechaFin)
            dgvListado.DataSource = pagos

            lblTotal.Text = "Total Registros: " & pagos.Count.ToString()

            Dim totalIngresos As Decimal = pagos.Sum(Function(p) p.MontoPagado)
            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString("F2")
        Catch ex As Exception
            MsgBox("Error al buscar pagos por fecha: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            ActualizarDataGridView()
            Select Case cbOpcionBuscar.SelectedIndex
                Case 0
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = True
                    PanelMonto.Visible = False

                Case 1, 2
                    tbBuscar.Visible = True
                    tbBuscar.Enabled = True
                    PanelFecha.Visible = False
                    PanelMonto.Visible = False

                Case 3
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = False
                    PanelMonto.Visible = True

                Case 4 To 10
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = False
                    PanelMonto.Visible = False
                    Dim pagos As List(Of Pagos) = nPagos.ListarPorMetodoPago(cbOpcionBuscar.SelectedItem.ToString())
                    dgvListado.DataSource = pagos
                    lblTotal.Text = "Total Registros: " & pagos.Count.ToString()

                    Dim totalIngresos As Decimal = pagos.Sum(Function(p) p.MontoPagado)
                    lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString("F2")
            End Select
        Catch ex As Exception
            MsgBox("Error al buscar pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            Dim pagos As List(Of Pagos) = Nothing

            Select Case cbOpcionBuscar.SelectedIndex
                Case 1
                    pagos = nPagos.ListarPorDni(tbBuscar.Text)
                Case 2
                    pagos = nPagos.ListarPorNombrePlan(tbBuscar.Text)
            End Select

            dgvListado.DataSource = pagos
            lblTotal.Text = "Total Registros: " & pagos.Count.ToString()

            Dim totalIngresos As Decimal = pagos.Sum(Function(p) p.MontoPagado)
            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString("F2")
        Catch ex As Exception
            MsgBox("Error al buscar pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscarMonto_Click(sender As Object, e As EventArgs) Handles btnBuscarMonto.Click
        Try
            Dim montoInicial As Decimal = CDec(tbMontoInicial.Text)
            Dim montoFinal As Decimal = CDec(tbMontoFinal.Text)
            Dim pagos As List(Of Pagos) = nPagos.ListarPorMontos(montoInicial, montoFinal)
            dgvListado.DataSource = pagos
            lblTotal.Text = "Total Registros: " & pagos.Count.ToString()

            Dim totalIngresos As Decimal = pagos.Sum(Function(p) p.MontoPagado)
            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString("F2")
        Catch ex As Exception
            MsgBox("Error al buscar pagos por monto: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
