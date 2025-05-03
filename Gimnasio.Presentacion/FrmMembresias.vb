Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmMembresias
    Private nMembresias As New NMembresias()

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            'dgvListado.Columns(0).Visible = False 
            dgvListado.Columns(0).HeaderText = "ID MEMBRESIA"
            dgvListado.Columns(1).HeaderText = "ID MIEMBRO"
            dgvListado.Columns(2).HeaderText = "ID PLAN"
            dgvListado.Columns(3).HeaderText = "DNI MIEMBRO"
            dgvListado.Columns(4).HeaderText = "APELLIDO MIEMBRO"
            dgvListado.Columns(5).HeaderText = "NOMBRE MIEMBRO"
            dgvListado.Columns(6).HeaderText = "NOMBRE PLAN"
            dgvListado.Columns(7).HeaderText = "PRECIO PLAN"
            dgvListado.Columns(8).HeaderText = "DURACION PLAN"
            dgvListado.Columns(9).HeaderText = "FECHA INICIO"
            dgvListado.Columns(10).HeaderText = "FECHA FIN"
            dgvListado.Columns(11).HeaderText = "ESTADO"
            dgvListado.Columns(12).HeaderText = "FECHA REGISTRO"
            dgvListado.Columns(13).HeaderText = "ULTIMA MODIFICACION"

            cbOpcionBuscar.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("Error al cargar las membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvMembresias As DataTable = nMembresias.Listar()
            dgvListado.DataSource = dvMembresias
            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al cargar las membresias: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub btnInsertar_Click_1(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            Dim frm As New FrmMembresiasPopup()
            frm.Dock = DockStyle.Fill
            frm.ShowDialog()
            ActualizarDataGridView()
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Public Sub Insertar(miembro As Miembros, plan As Planes, membresia As Membresias)
    '    Try
    '        nMembresias.Insertar(nuevoMiembro)
    '        ' Actualizar el DataGridView
    '        ActualizarDataGridView()
    '        MsgBox("Miembro agregado exitosamente.", MsgBoxStyle.Information, "Exito")
    '    Catch ex As Exception
    '        MsgBox("Error al agregar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub


    'Private Sub btnActualizar_Click(sender As Object, e As EventArgs)
    '    Try
    '        If dgvListado.SelectedRows.Count > 0 Then
    '            Dim selectedRow = dgvListado.SelectedRows(0)
    '            Dim miembroPorActualizar As New Miembros
    '            miembroPorActualizar.IdMiembro = CUInt(selectedRow.Cells("id_miembro").Value)
    '            miembroPorActualizar.Dni = selectedRow.Cells("dni").Value.ToString
    '            miembroPorActualizar.Nombre = selectedRow.Cells("nombre").Value.ToString
    '            miembroPorActualizar.Apellido = selectedRow.Cells("apellido").Value.ToString
    '            miembroPorActualizar.FechaNacimiento = CDate(selectedRow.Cells("fecha_nacimiento").Value)
    '            miembroPorActualizar.Genero = selectedRow.Cells("genero").Value.ToString
    '            miembroPorActualizar.Telefono = selectedRow.Cells("telefono").Value.ToString
    '            miembroPorActualizar.Email = selectedRow.Cells("email").Value.ToString
    '            Dim frm As New FrmMiembrosPopup(False, Me, miembroPorActualizar)
    '            frm.ShowDialog()
    '        Else
    '            MsgBox("Seleccione un miembro para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al seleccionar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try


    'End Sub


    'Public Sub Actualizar(miembroActualizado As Miembros)
    '    Try
    '        nMembresias.Actualizar(miembroActualizado)
    '        ActualizarDataGridView()
    '        MsgBox("miembro actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
    '    Catch ex As Exception
    '        MsgBox("Error al actualizar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    'Private Sub btnActivar_Click(sender As Object, e As EventArgs)
    '    Try
    '        If dgvListado.SelectedRows.Count > 0 Then
    '            Dim selectedRow = dgvListado.SelectedRows(0)
    '            Dim idMiembro As Integer = selectedRow.Cells("id_miembro").Value
    '            nMembresias.Activar(idMiembro)
    '            ActualizarDataGridView()
    '            MsgBox("Miembro activado exitosamente.", MsgBoxStyle.Information, "Exito")
    '        Else
    '            MsgBox("Seleccione un Miembro para activar.", MsgBoxStyle.Exclamation, "Aviso")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al activar el Miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

    'Private Sub btnDesactivar_Click(sender As Object, e As EventArgs)
    '    Try
    '        If dgvListado.SelectedRows.Count > 0 Then
    '            Dim selectedRow = dgvListado.SelectedRows(0)
    '            Dim idMiembro As Integer = selectedRow.Cells("id_miembro").Value
    '            nMembresias.Desactivar(idMiembro)
    '            ActualizarDataGridView()
    '            MsgBox("Miembro desactivado exitosamente.", MsgBoxStyle.Information, "Exito")
    '        Else
    '            MsgBox("Seleccione un Miembro para desactivar.", MsgBoxStyle.Exclamation, "Aviso")
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al desactivar el Miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub



    'Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs)
    '    Try
    '        ' Verificar si hay un elemento seleccionado en el ComboBox
    '        If cbOpcionBuscar.SelectedIndex = 0 Then
    '            ' Buscar por nombre
    '            Dim dvMiembro As DataTable = nMembresias.BuscarPorNombre(tbBuscar.Text)
    '            dgvListado.DataSource = dvMiembro
    '            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString
    '        ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
    '            ' Buscar por DNI
    '            Dim dvMiembro As DataTable = nMembresias.BuscarPorDni(tbBuscar.Text)
    '            dgvListado.DataSource = dvMiembro
    '            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub


End Class