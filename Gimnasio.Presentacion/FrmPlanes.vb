Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Public Class FrmPlanes
    Private nPlanes As New NPlanes()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            'dgvListado.Columns(0).Visible = False ' Ocultar la columna IdPlan
            dgvListado.Columns(0).HeaderText = "ID"
            dgvListado.Columns(1).HeaderText = "Nombre del Plan"
            dgvListado.Columns(2).HeaderText = "Descripción"
            dgvListado.Columns(3).HeaderText = "Duración"
            dgvListado.Columns(4).HeaderText = "Precio"
            dgvListado.Columns(5).HeaderText = "Estado"
            dgvListado.Columns(6).HeaderText = "Fecha de Creación"
            dgvListado.Columns(7).HeaderText = "Última Modificación"
        Catch ex As Exception
            MsgBox("Error al cargar los planes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvPlanes As DataTable = nPlanes.Listar()
            dgvListado.DataSource = dvPlanes
            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al cargar los planes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            Dim frm As New FrmPlanesPopup(True, Me)
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Insertar(nuevoPlan As Planes)
        Try
            nPlanes.Insertar(nuevoPlan)
            ' Actualizar el DataGridView
            ActualizarDataGridView()
            MsgBox("Plan agregado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al agregar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim planPorActualizar As New Planes()
                planPorActualizar.IdPlan = CUInt(selectedRow.Cells("id_plan").Value)
                planPorActualizar.NombrePlan = selectedRow.Cells("nombre_plan").Value.ToString()
                planPorActualizar.Descripcion = selectedRow.Cells("descripcion").Value.ToString()
                planPorActualizar.DuracionDias = CUInt(selectedRow.Cells("duracion_dias").Value)
                planPorActualizar.Precio = CDec(selectedRow.Cells("precio").Value)

                Dim frm As New FrmPlanesPopup(False, Me, planPorActualizar)
                frm.ShowDialog()
            Else
                MsgBox("Seleccione un plan para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al seleccionar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Sub


    Public Sub Actualizar(planActualizado As Planes)
        Try
            nPlanes.Actualizar(planActualizado)
            ActualizarDataGridView()
            MsgBox("Plan actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al actualizar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            ' Verificar si hay una fila seleccionada
            If dgvListado.SelectedRows.Count > 0 Then
                ' Obtener el ID del plan seleccionado
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idPlan As Integer = CInt(selectedRow.Cells("id_plan").Value)

                ' Confirmar la eliminación
                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este plan?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    ' Llamar al método Eliminar de la capa de negocio
                    nPlanes.Eliminar(idPlan)

                    ' Actualizar el DataGridView
                    ActualizarDataGridView()
                    MsgBox("Plan eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un plan para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnActivar_Click(sender As Object, e As EventArgs) Handles btnActivar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idPlan As Integer = CInt(selectedRow.Cells("id_plan").Value)
                nPlanes.Activar(idPlan)
                ActualizarDataGridView()
                MsgBox("Plan activado exitosamente.", MsgBoxStyle.Information, "Exito")
            Else
                MsgBox("Seleccione un plan para activar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al activar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idPlan As Integer = CInt(selectedRow.Cells("id_plan").Value)
                nPlanes.Desactivar(idPlan)
                ActualizarDataGridView()
                MsgBox("Plan desactivado exitosamente.", MsgBoxStyle.Information, "Exito")
            Else
                MsgBox("Seleccione un plan para desactivar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al desactivar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub



    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            Dim dvPlanes As DataTable = nPlanes.BuscarPorNombre(tbBuscar.Text)
            dgvListado.DataSource = dvPlanes
            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al buscar planes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class


