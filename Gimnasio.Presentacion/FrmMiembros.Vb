Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmMiembros
    Private nMiembros As New NMiembros()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            'dgvListado.Columns(0).Visible = False 
            dgvListado.Columns(0).HeaderText = "ID"
            dgvListado.Columns(1).HeaderText = "DNI"
            dgvListado.Columns(2).HeaderText = "Nombre"
            dgvListado.Columns(3).HeaderText = "Apellido"
            dgvListado.Columns(4).HeaderText = "Fecha de Nacimiento"
            dgvListado.Columns(5).HeaderText = "Género"
            dgvListado.Columns(6).HeaderText = "Teléfono"
            dgvListado.Columns(7).HeaderText = "Email"
            dgvListado.Columns(8).HeaderText = "Fecha de Registro"
            dgvListado.Columns(9).HeaderText = "Estado"
            dgvListado.Columns(10).HeaderText = "Última Modificación"

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
            ' Actualizar el DataGridView
            ActualizarDataGridView()
            MsgBox("Miembro agregado exitosamente.", MsgBoxStyle.Information, "Exito")
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
                miembroPorActualizar.FechaNacimiento = CDate(selectedRow.Cells("fecha_nacimiento").Value)
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

    Private Sub btnActivar_Click(sender As Object, e As EventArgs) Handles btnActivar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMiembro As Integer = CInt(selectedRow.Cells("id_miembro").Value)
                nMiembros.Activar(idMiembro)
                ActualizarDataGridView()
                MsgBox("Miembro activado exitosamente.", MsgBoxStyle.Information, "Exito")
            Else
                MsgBox("Seleccione un Miembro para activar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al activar el Miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMiembro As Integer = CInt(selectedRow.Cells("id_miembro").Value)
                nMiembros.Desactivar(idMiembro)
                ActualizarDataGridView()
                MsgBox("Miembro desactivado exitosamente.", MsgBoxStyle.Information, "Exito")
            Else
                MsgBox("Seleccione un Miembro para desactivar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al desactivar el Miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub



    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            ' Verificar si hay un elemento seleccionado en el ComboBox
            If cbOpcionBuscar.SelectedIndex = 0 Then
                ' Buscar por nombre
                Dim dvMiembro As DataTable = nMiembros.BuscarPorNombre(tbBuscar.Text)
                dgvListado.DataSource = dvMiembro
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                ' Buscar por DNI
                Dim dvMiembro As DataTable = nMiembros.BuscarPorDni(tbBuscar.Text)
                dgvListado.DataSource = dvMiembro
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


End Class