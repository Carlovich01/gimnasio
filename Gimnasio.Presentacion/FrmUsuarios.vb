Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmUsuarios
    Private nUsuarios As New NUsuarios()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
            dgvListado.Columns("IdUsuario").Visible = False
            dgvListado.Columns("Username").HeaderText = "NOMBRE DE USUARIO"
            dgvListado.Columns("PasswordHash").HeaderText = "CONTRASEÑA"
            dgvListado.Columns("NombreCompleto").HeaderText = "NOMBRE COMPLETO"
            dgvListado.Columns("Email").HeaderText = "EMAIL"
            dgvListado.Columns("IdRol").HeaderText = "ROL"
            dgvListado.Columns("FechaCreacion").HeaderText = "FECHA CREACIÓN"
            dgvListado.Columns("UltimaModificacion").HeaderText = "ÚLTIMA MODIFICACIÓN"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim usuarios As List(Of Usuarios) = nUsuarios.Listar()
            dgvListado.DataSource = usuarios
            lblTotal.Text = "Total: " & usuarios.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al cargar los usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            Dim frm As New FrmUsuariosPopup(True, Me)
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Insertar(nuevoUsuario As Usuarios)
        Try
            nUsuarios.Insertar(nuevoUsuario)
            ActualizarDataGridView()
            MsgBox("Usuario agregado exitosamente.", MsgBoxStyle.Information, "Éxito")
        Catch ex As Exception
            MsgBox("Error al agregar el usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim usuarioPorActualizar As New Usuarios() With {
                    .IdUsuario = CUInt(selectedRow.Cells("IdUsuario").Value),
                    .Username = selectedRow.Cells("Username").Value.ToString(),
                    .NombreCompleto = selectedRow.Cells("NombreCompleto").Value.ToString(),
                    .Email = If(IsDBNull(selectedRow.Cells("Email").Value), Nothing, selectedRow.Cells("Email").Value.ToString()),
                    .IdRol = CUInt(selectedRow.Cells("IdRol").Value)
                }
                Dim frm As New FrmUsuariosPopup(False, Me, usuarioPorActualizar)
                frm.ShowDialog()
            Else
                MsgBox("Seleccione un usuario para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al seleccionar el usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Actualizar(usuarioActualizado As Usuarios)
        Try
            nUsuarios.Actualizar(usuarioActualizado)
            ActualizarDataGridView()
            MsgBox("Usuario actualizado exitosamente.", MsgBoxStyle.Information, "Éxito")
        Catch ex As Exception
            MsgBox("Error al actualizar el usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim usuarios As List(Of Usuarios) = nUsuarios.ListarPorNombre(tbBuscar.Text)
                dgvListado.DataSource = usuarios
                lblTotal.Text = "Total: " & usuarios.Count.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idUsuario As UInteger = CUInt(selectedRow.Cells("IdUsuario").Value)

                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nUsuarios.Eliminar(idUsuario)

                    ActualizarDataGridView()
                    MsgBox("Usuario eliminado exitosamente.", MsgBoxStyle.Information, "Éxito")
                End If
            Else
                MsgBox("Seleccione un Usuario para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el Usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
