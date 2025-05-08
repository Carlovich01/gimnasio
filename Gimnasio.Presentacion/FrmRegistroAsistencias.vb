Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmRegistroAsistencias
    Private nAsistencias As New NAsistencia()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
            dgvListado.Sort(dgvListado.Columns("FechaHoraCheckin"), System.ComponentModel.ListSortDirection.Descending)
            dgvListado.Columns("IdAsistencia").Visible = False
            dgvListado.Columns("IdMiembro").Visible = False
            dgvListado.Columns("IdMembresiaValida").Visible = False
            dgvListado.Columns("IdAsistencia").HeaderText = "ID ASISTENCIA"
            dgvListado.Columns("IdMiembro").HeaderText = "ID MIEMBRO"
            dgvListado.Columns("IdMembresiaValida").HeaderText = "ID MEMBRESIA"
            dgvListado.Columns("FechaHoraCheckin").HeaderText = "FECHA INGRESO"
            dgvListado.Columns("Resultado").HeaderText = "RESULTADO"
            cbOpcionBuscar.SelectedIndex = 1
        Catch ex As Exception
            MsgBox("Error al cargar las asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim asistencias As List(Of Asistencia) = nAsistencias.Listar()
            dgvListado.DataSource = asistencias
            lblTotal.Text = "Total Registros: " & asistencias.Count.ToString()
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
                Dim asistencias As List(Of Asistencia) = nAsistencias.ListarPorDNI(tbBuscar.Text)
                dgvListado.DataSource = asistencias
                lblTotal.Text = "Total Registros: " & asistencias.Count.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar asistencias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim fechaInicio = dtpFechaInicio.Value.Date
            Dim fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1)
            Dim asistencias As List(Of Asistencia) = nAsistencias.ListarPorFecha(fechaInicio, fechaFin)
            dgvListado.DataSource = asistencias
            lblTotal.Text = "Total Registros: " & asistencias.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al buscar asistencias por fecha: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
