Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmMembresias
    Private nMembresias As New NMembresias()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            'dgvListado.Columns("id_membresia").Visible = False
            'dgvListado.Columns("id_miembro").Visible = False
            'dgvListado.Columns("id_plan").Visible = False
            'dgvListado.Columns("dni_miembro").HeaderText = "DNI MIEMBRO"
            'dgvListado.Columns("apellido_miembro").HeaderText = "APELLIDO MIEMBRO"
            'dgvListado.Columns("nombre_plan").HeaderText = "NOMBRE PLAN"
            'dgvListado.Columns("precio_plan").HeaderText = "PRECIO PLAN"
            'dgvListado.Columns("duracion_dias_plan").HeaderText = "DURACION"
            'dgvListado.Columns("fecha_inicio").HeaderText = "FECHA INICIO"
            'dgvListado.Columns("fecha_fin").HeaderText = "FECHA FIN"
            'dgvListado.Columns("estado_membresia").HeaderText = "ESTADO MEMBRESIA"
            'dgvListado.Columns("fecha_registro").HeaderText = "FECHA REGISTRO"
            'dgvListado.Columns("ultima_modificacion").HeaderText = "ULTIMA MODIFICACION"

            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar las membresías: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim membresias As List(Of Membresias) = nMembresias.Listar()
            dgvListado.DataSource = membresias
            lblTotal.Text = "Total: " & membresias.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al cargar las membresías: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnInsertar_Click_1(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            Dim frm As New FrmMembresiasPopup()
            frm.ShowDialog()
            ActualizarDataGridView()
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMembresia As UInteger = CUInt(selectedRow.Cells("IdMembresia").Value)
                Dim precio As Decimal = Convert.ToDecimal(selectedRow.Cells("PrecioPlan").Value)
                Dim estadoMembresia As String = selectedRow.Cells("EstadoMembresia").Value.ToString()

                If estadoMembresia = "Activa" Then
                    MsgBox("La membresía ya está activa. No es necesario realizar un pago.", MsgBoxStyle.Information, "Información")
                    Return
                ElseIf estadoMembresia = "Inactiva" Then
                    Dim frmPagosPopup As New FrmPagosPopup(idMembresia, precio)
                    frmPagosPopup.ShowDialog()
                    ActualizarDataGridView()
                Else
                    MsgBox("El estado de la membresía no es válido.", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                MsgBox("Por favor, seleccione una fila antes de continuar.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscar_TextChanged_1(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            Dim membresias As List(Of Membresias) = Nothing

            If cbOpcionBuscar.SelectedIndex = 0 Then
                membresias = nMembresias.ListarPorDni(tbBuscar.Text)
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                membresias = nMembresias.ListarPorNombrePlan(tbBuscar.Text)
            End If

            dgvListado.DataSource = membresias
            lblTotal.Text = "Total: " & membresias.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            Dim membresias As List(Of Membresias) = Nothing

            If cbOpcionBuscar.SelectedIndex = 2 Then
                membresias = nMembresias.ListarPorEstado("Activa")
                tbBuscar.Enabled = False
            ElseIf cbOpcionBuscar.SelectedIndex = 3 Then
                membresias = nMembresias.ListarPorEstado("Inactiva")
                tbBuscar.Enabled = False
            Else
                tbBuscar.Enabled = True
            End If

            'si la lista es 0
            If membresias Is Nothing OrElse membresias.Count = 0 Then
                MsgBox("No se encontraron resultados.", MsgBoxStyle.Information, "Información")
                Return
            End If
            dgvListado.DataSource = membresias
            lblTotal.Text = "Total: " & membresias.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
