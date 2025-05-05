Imports Gimnasio.Negocio
Imports Gimnasio.Entidades

Public Class FrmReclamos
    Private nReclamos As New NReclamos()

    Sub New()
        InitializeComponent()
        If UsuarioLogueado.IdRol = 2 Then
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
            btnCambiarEstado.Visible = False
            btnCambiarEstado.Enabled = False
            btnResponder.Visible = False
            btnResponder.Enabled = False
        End If
    End Sub

    Private Sub FrmReclamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(0).HeaderText = "ID RECLAMO"
            dgvListado.Columns(1).HeaderText = "TIPO"
            dgvListado.Columns(2).HeaderText = "DESCRIPCION"
            dgvListado.Columns(3).HeaderText = "FECHA ENVIO"
            dgvListado.Columns(4).HeaderText = "ESTADO"
            dgvListado.Columns(5).HeaderText = "RESPUESTA"
            dgvListado.Columns(6).HeaderText = "FECHA RESPUESTA"
            dgvListado.Columns(7).HeaderText = "DNI MIEMBRO"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los reclamos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvReclamos As DataTable = nReclamos.Listar()
            dgvListado.DataSource = dvReclamos
            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al cargar los reclamos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            Dim frm As New FrmReclamosPopup(True, Me)
            frm.ShowDialog()
            ActualizarDataGridView()
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Insertar(nuevoReclamo As Reclamos)
        Try
            nReclamos.Insertar(nuevoReclamo)
            ActualizarDataGridView()
            MsgBox("Reclamo agregado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al agregar el reclamo: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Actualizar(reclamoActualizado As Reclamos)
        Try
            nReclamos.Actualizar(reclamoActualizado)
            ActualizarDataGridView()
            MsgBox("reclamo actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al actualizar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnActualizar_Click_1(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim reclamoPorActualizar As New Reclamos
                reclamoPorActualizar.IdReclamos = CUInt(selectedRow.Cells("id_reclamos").Value)
                reclamoPorActualizar.Tipo = selectedRow.Cells("tipo").Value.ToString
                reclamoPorActualizar.Descripcion = selectedRow.Cells("descripcion").Value.ToString
                reclamoPorActualizar.Respuesta = selectedRow.Cells("respuesta").Value.ToString
                Dim frm As New FrmReclamosPopup(False, Me, reclamoPorActualizar)
                frm.ShowDialog()
                ActualizarDataGridView()
            Else
                MsgBox("Seleccione un reclamo para actualizar.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de actualización: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click_1(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idReclamo As Integer = selectedRow.Cells("id_reclamos").Value

                Dim confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este reclamo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nReclamos.Eliminar(idReclamo)

                    ActualizarDataGridView()
                    MsgBox("Reclamo eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un reclamo para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el reclamo: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnResponder_Click(sender As Object, e As EventArgs) Handles btnResponder.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim reclamoPorActualizar As New Reclamos
                reclamoPorActualizar.IdReclamos = CUInt(selectedRow.Cells("id_reclamos").Value)
                Dim frm As New FrmReclamosPopup(reclamoPorActualizar)
                frm.ShowDialog()
                ActualizarDataGridView()
            Else
                MsgBox("Seleccione un reclamo para actualizar.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de actualización: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            Dim dvPlanes = nReclamos.BuscarPorEstado(If(cbOpcionBuscar.SelectedIndex = 0, "pendiente", "resuelto"))
            dgvListado.DataSource = dvPlanes
            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString
        Catch ex As Exception
            MsgBox("Error al buscar reclamos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnCambiarEstado_Click(sender As Object, e As EventArgs) Handles btnCambiarEstado.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow = dgvListado.SelectedRows(0)
                Dim idReclamo As Integer = CInt(selectedRow.Cells("id_reclamos").Value)
                Dim estadoActual As String = selectedRow.Cells("estado").Value.ToString().ToLower()

                If estadoActual = "pendiente" Then
                    nReclamos.EstadoResuelto(idReclamo)
                    MsgBox("El estado del reclamo ha sido cambiado a 'resuelto'.", MsgBoxStyle.Information, "Estado actualizado")
                ElseIf estadoActual = "resuelto" Then
                    nReclamos.EstadoPendiente(idReclamo)
                    MsgBox("El estado del reclamo ha sido cambiado a 'pendiente'.", MsgBoxStyle.Information, "Estado actualizado")
                Else
                    MsgBox("El estado actual no es válido para cambiar.", MsgBoxStyle.Exclamation, "Advertencia")
                End If

                ActualizarDataGridView()
            Else
                MsgBox("Seleccione un reclamo para cambiar su estado.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            MsgBox("Error al cambiar el estado del reclamo: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


End Class