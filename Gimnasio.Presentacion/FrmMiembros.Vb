Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmMiembros
    Private nMiembros As New NMiembros()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).HeaderText = "DNI"
            dgvListado.Columns(2).HeaderText = "Nombre"
            dgvListado.Columns(3).HeaderText = "Apellido"
            dgvListado.Columns(4).HeaderText = "Género"
            dgvListado.Columns(5).HeaderText = "Teléfono"
            dgvListado.Columns(6).HeaderText = "Email"
            dgvListado.Columns(7).HeaderText = "Fecha de Registro"
            dgvListado.Columns(8).HeaderText = "Última Modificación"

            cbOpcionBuscar.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("Error al cargar los miembros: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvMiembros As DataTable = nMiembros.Listar()
            dgvListado.DataSource = dvMiembros
            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
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
            MsgBox("Miembro agregado exitosamente.", MsgBoxStyle.Information, "Exito")
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
                Dim miembroPorActualizar As New Miembros()
                miembroPorActualizar.IdMiembro = CUInt(selectedRow.Cells("id_miembro").Value)
                miembroPorActualizar.Dni = selectedRow.Cells("dni").Value.ToString()
                miembroPorActualizar.Nombre = selectedRow.Cells("nombre").Value.ToString()
                miembroPorActualizar.Apellido = selectedRow.Cells("apellido").Value.ToString()
                miembroPorActualizar.Genero = selectedRow.Cells("genero").Value.ToString()
                miembroPorActualizar.Telefono = selectedRow.Cells("telefono").Value.ToString()
                miembroPorActualizar.Email = selectedRow.Cells("email").Value.ToString()
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
            MsgBox("miembro actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al actualizar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvMiembro As DataTable = nMiembros.BuscarPorNombre(tbBuscar.Text)
                dgvListado.DataSource = dvMiembro
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                Dim dvMiembro As DataTable = nMiembros.BuscarPorDni(tbBuscar.Text)
                dgvListado.DataSource = dvMiembro
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMiembro As Integer = CInt(selectedRow.Cells("id_miembro").Value)

                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Miembro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nMiembros.Eliminar(idMiembro)

                    ActualizarDataGridView()
                    MsgBox("Miembro eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un Miembro para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el Miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class