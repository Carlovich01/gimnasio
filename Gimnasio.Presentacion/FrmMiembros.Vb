Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmMiembros
    Private nMiembros As New NMiembros()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            dgvListado.Columns("IdMiembro").Visible = False
            dgvListado.Columns("Dni").HeaderText = "DNI"
            dgvListado.Columns("Nombre").HeaderText = "Nombre"
            dgvListado.Columns("Apellido").HeaderText = "Apellido"
            dgvListado.Columns("Genero").HeaderText = "Género"
            dgvListado.Columns("Telefono").HeaderText = "Teléfono"
            dgvListado.Columns("Email").HeaderText = "Email"
            dgvListado.Columns("FechaRegistro").HeaderText = "Fecha de Registro"
            dgvListado.Columns("UltimaModificacion").HeaderText = "Última Modificación"

            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los miembros: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim miembros As List(Of Miembros) = nMiembros.Listar()
            dgvListado.DataSource = miembros
            lblTotal.Text = "Total: " & miembros.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al cargar los miembros: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            Dim frm As New FrmMiembrosPopup(True, Me)
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Insertar(nuevoMiembro As Miembros)
        Try
            nMiembros.Insertar(nuevoMiembro)
            ActualizarDataGridView()
            MsgBox("Miembro agregado exitosamente.", MsgBoxStyle.Information, "Éxito")
            Dim FrmMembresiasPopup As New FrmMembresiasPopup(nuevoMiembro)
            FrmMembresiasPopup.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al agregar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim miembroPorActualizar As New Miembros() With {
                    .IdMiembro = CUInt(selectedRow.Cells("IdMiembro").Value),
                    .Dni = selectedRow.Cells("Dni").Value.ToString(),
                    .Nombre = selectedRow.Cells("Nombre").Value.ToString(),
                    .Apellido = selectedRow.Cells("Apellido").Value.ToString(),
                    .Genero = selectedRow.Cells("Genero").Value.ToString(),
                    .Telefono = selectedRow.Cells("Telefono").Value.ToString(),
                    .Email = selectedRow.Cells("Email").Value.ToString()
                }
                Dim frm As New FrmMiembrosPopup(False, Me, miembroPorActualizar)
                frm.ShowDialog()
            Else
                MsgBox("Seleccione un miembro para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al seleccionar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Actualizar(miembroActualizado As Miembros)
        Try
            nMiembros.Actualizar(miembroActualizado)
            ActualizarDataGridView()
            MsgBox("Miembro actualizado exitosamente.", MsgBoxStyle.Information, "Éxito")
        Catch ex As Exception
            MsgBox("Error al actualizar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            Dim miembros As List(Of Miembros) = Nothing

            If cbOpcionBuscar.SelectedIndex = 0 Then
                miembros = nMiembros.ListarPorNombre(tbBuscar.Text)
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                miembros = nMiembros.ListarPorDni(tbBuscar.Text)
            End If

            dgvListado.DataSource = miembros
            lblTotal.Text = "Total: " & miembros.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMiembro As UInteger = CUInt(selectedRow.Cells("IdMiembro").Value)

                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este miembro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nMiembros.Eliminar(idMiembro)

                    ActualizarDataGridView()
                    MsgBox("Miembro eliminado exitosamente.", MsgBoxStyle.Information, "Éxito")
                End If
            Else
                MsgBox("Seleccione un miembro para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
