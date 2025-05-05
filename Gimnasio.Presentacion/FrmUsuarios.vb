Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmUsuarios
    Private nUsuarios As New NUsuarios()
    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()
            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).HeaderText = "NOMBRE DE USUARIO"
            dgvListado.Columns(2).HeaderText = "CONTRASEÑA"
            dgvListado.Columns(3).HeaderText = "NOMBRE COMPLETO"
            dgvListado.Columns(4).HeaderText = "EMAIL"
            dgvListado.Columns(5).HeaderText = "ROL"
            dgvListado.Columns(6).HeaderText = "FECHA CREACION"
            dgvListado.Columns(7).HeaderText = "ULTIMA MODIFICACION"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los usuarios: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvUsuarios As DataTable = nUsuarios.Listar()
            dgvListado.DataSource = dvUsuarios
            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
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
            MsgBox("Usuario agregado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al agregar el usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim usuarioPorActualizar As New Usuarios()
                usuarioPorActualizar.IdUsuario = CInt(selectedRow.Cells("id_usuario").Value)
                usuarioPorActualizar.Username = selectedRow.Cells("username").Value.ToString
                usuarioPorActualizar.NombreCompleto = selectedRow.Cells("nombre_completo").Value.ToString
                usuarioPorActualizar.Email = selectedRow.Cells("email").Value.ToString
                usuarioPorActualizar.IdRol = If(selectedRow.Cells("nombre_rol").Value.ToString() = "Administrador", 1, 2)
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
            MsgBox("Usuario actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al actualizar el usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvUsuaurio As DataTable = nUsuarios.BuscarPorNombre(tbBuscar.Text)
                dgvListado.DataSource = dvUsuaurio
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idUsuario As Integer = CInt(selectedRow.Cells("id_usuario").Value)

                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este Usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nUsuarios.Eliminar(idUsuario)

                    ActualizarDataGridView()
                    MsgBox("Usuario eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un Usuario para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el Usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


End Class