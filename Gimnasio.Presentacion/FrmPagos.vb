Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmPagos
    Private nPagos As New NPagos()

    Private Sub FrmPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).Visible = False
            dgvListado.Columns(2).Visible = False
            dgvListado.Columns(0).HeaderText = "ID PAGO"
            dgvListado.Columns(1).HeaderText = "ID MEMBRESIA"
            dgvListado.Columns(2).HeaderText = "ID USUARIO REGISTRO"
            dgvListado.Columns(3).HeaderText = "APELLIDO MIEMBRO"
            dgvListado.Columns(4).HeaderText = "NOMBRE MIEMBRO"
            dgvListado.Columns(5).HeaderText = "DNI MIEMBRO"
            dgvListado.Columns(6).HeaderText = "NOMBRE PLAN"
            dgvListado.Columns(7).HeaderText = "MONTO PAGADO"
            dgvListado.Columns(8).HeaderText = "METODO PAGO"
            dgvListado.Columns(9).HeaderText = "NUMERO COMPROBANTE"
            dgvListado.Columns(10).HeaderText = "FECHA PAGO"
            dgvListado.Columns(11).HeaderText = "ENCARGADO"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar las membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvMembresias As DataTable = nPagos.Listar()
            dgvListado.DataSource = dvMembresias
            lblTotal.Text = "Total Registros: " & dgvListado.Rows.Count.ToString()
            Dim totalIngresos As Decimal = 0
            For Each row As DataGridViewRow In dgvListado.Rows
                totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
            Next

            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()

        Catch ex As Exception
            MsgBox("Error al cargar las membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub BtnBuscarFecha_Click(sender As Object, e As EventArgs) Handles BtnBuscarFecha.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            Dim dvPagos = nPagos.BuscarPorFecha(fechaInicio, fechaFin)
            dgvListado.DataSource = dvPagos

            lblTotal.Text = "Total Registros: " & dgvListado.Rows.Count.ToString

            Dim totalIngresos As Decimal = 0
            For Each row As DataGridViewRow In dgvListado.Rows
                totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
            Next

            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString
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

                Case 1
                    tbBuscar.Visible = True
                    tbBuscar.Enabled = True
                    PanelFecha.Visible = False
                    PanelMonto.Visible = False

                Case 2
                    tbBuscar.Visible = True
                    tbBuscar.Enabled = True
                    PanelFecha.Visible = False
                    PanelMonto.Visible = False

                Case 3
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = False
                    PanelMonto.Visible = True


                Case 4, 5, 6, 7, 8, 9, 10
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = False
                    PanelMonto.Visible = False
                    Dim dvPagos As DataTable = nPagos.BuscarPorMetodoPago(cbOpcionBuscar.SelectedItem.ToString)
                    dgvListado.DataSource = dvPagos
                    lblTotal.Text = "Total Registros: " & dgvListado.Rows.Count.ToString()
                    Dim totalIngresos As Decimal = 0
                    For Each row As DataGridViewRow In dgvListado.Rows
                        totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
                    Next
                    lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()
            End Select
        Catch ex As Exception
            MsgBox("Error al buscar pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try



    End Sub

    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            Select Case cbOpcionBuscar.SelectedIndex
                Case 1
                    Dim dvPagos As DataTable = nPagos.BuscarPorDni(tbBuscar.Text)
                    dgvListado.DataSource = dvPagos
                    lblTotal.Text = "Total Registros: " & dgvListado.Rows.Count.ToString()
                    Dim totalIngresos As Decimal = 0
                    For Each row As DataGridViewRow In dgvListado.Rows
                        totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
                    Next
                    lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()
                Case 2
                    Dim dvPagos As DataTable = nPagos.BuscarPorNombrePlan(tbBuscar.Text)
                    dgvListado.DataSource = dvPagos
                    lblTotal.Text = "Total Registros: " & dgvListado.Rows.Count.ToString()
                    Dim totalIngresos As Decimal = 0
                    For Each row As DataGridViewRow In dgvListado.Rows
                        totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
                    Next
                    lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()
            End Select
        Catch ex As Exception
            MsgBox("Error al buscar pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscarMonto_Click(sender As Object, e As EventArgs) Handles btnBuscarMonto.Click
        Try
            Dim dvPagos As DataTable = nPagos.BuscarPorMontos(CDec(tbMontoInicial.Text), CDec(tbMontoFinal.Text))
            dgvListado.DataSource = dvPagos
            lblTotal.Text = "Total Registros: " & dgvListado.Rows.Count.ToString()
            Dim totalIngresos As Decimal = 0
            For Each row As DataGridViewRow In dgvListado.Rows
                totalIngresos += Convert.ToDecimal(row.Cells("monto").Value)
            Next
            lbIngresosTotales.Text = "Ingresos Totales: $" & totalIngresos.ToString()
        Catch ex As Exception
            MsgBox("Error al buscar pagos por monto: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


End Class