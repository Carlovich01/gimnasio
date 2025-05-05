Imports Gimnasio.Datos
Imports Gimnasio.Negocio
Public Class FrmRegistroAsistencias
    Private nAsistencias As New NAsistencia()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
            dgvListado.Sort(dgvListado.Columns("fecha_ingreso"), System.ComponentModel.ListSortDirection.Descending)
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).Visible = False
            dgvListado.Columns(2).Visible = False
            dgvListado.Columns(0).HeaderText = "ID ASISTENCIA"
            dgvListado.Columns(1).HeaderText = "ID MIEMBRO"
            dgvListado.Columns(2).HeaderText = "ID MEMBRESIA"
            dgvListado.Columns(3).HeaderText = "DNI MIEMBRO"
            dgvListado.Columns(4).HeaderText = "NOMBRE MIEMBRO"
            dgvListado.Columns(5).HeaderText = "APELLIDO MIEMBRO"
            dgvListado.Columns(6).HeaderText = "FECHA INGRESO"
            dgvListado.Columns(7).HeaderText = "RESULTADO"
            cbOpcionBuscar.SelectedIndex = 1

        Catch ex As Exception
            MsgBox("Error al cargar las membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvAsistencias As DataTable = nAsistencias.Listar()
            dgvListado.DataSource = dvAsistencias

        Catch ex As Exception
            MsgBox("Error al cargar las asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub CbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            ActualizarDataGridView()
            Select Case cbOpcionBuscar.SelectedIndex
                Case 0
                    tbBuscar.Visible = True
                    tbBuscar.Enabled = True
                    PanelFecha.Visible = False
                Case 1
                    tbBuscar.Visible = False
                    tbBuscar.Enabled = False
                    PanelFecha.Visible = True

            End Select
        Catch ex As Exception
            MsgBox("Error al buscar asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvAsistencias As DataTable = nAsistencias.BuscarPorDNI(tbBuscar.Text)
                dgvListado.DataSource = dvAsistencias
                lblTotal.Text = "Total Registros: " & dgvListado.Rows.Count.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            Dim dvAsistencias = nAsistencias.BuscarPorFecha(fechaInicio, fechaFin)
            dgvListado.DataSource = dvAsistencias

            lblTotal.Text = "Total Registros: " & dgvListado.Rows.Count.ToString
        Catch ex As Exception
            MsgBox("Error al buscar asistencias por fecha: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

End Class