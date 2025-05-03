Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports Google.Protobuf.WellKnownTypes

Public Class FrmMembresiasPopup
    Private NMiembros As New NMiembros()
    Private NPlan As New NPlanes()
    Private NMembresias As New NMembresias()

    Private Sub FrmMembresiasPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim dtMiembros As DataTable = NMiembros.Listar()
            dgvMiembro.DataSource = dtMiembros
            dgvMiembro.Columns(0).HeaderText = "ID"
            dgvMiembro.Columns(1).HeaderText = "DNI"
            dgvMiembro.Columns(2).HeaderText = "Nombre"
            dgvMiembro.Columns(3).HeaderText = "Apellido"
            dgvMiembro.Columns(4).HeaderText = "Fecha de Nacimiento"
            dgvMiembro.Columns(5).HeaderText = "Género"
            dgvMiembro.Columns(6).HeaderText = "Teléfono"
            dgvMiembro.Columns(7).HeaderText = "Email"
            dgvMiembro.Columns(8).HeaderText = "Fecha de Registro"
            dgvMiembro.Columns(9).HeaderText = "Estado"
            dgvMiembro.Columns(10).HeaderText = "Última Modificación"

            Dim dtPlanes As DataTable = NPlan.Listar()
            dgvPlan.DataSource = dtPlanes
            dgvPlan.Columns(0).HeaderText = "ID"
            dgvPlan.Columns(1).HeaderText = "Nombre del Plan"
            dgvPlan.Columns(2).HeaderText = "Descripción"
            dgvPlan.Columns(3).HeaderText = "Duración"
            dgvPlan.Columns(4).HeaderText = "Precio"
            dgvPlan.Columns(5).HeaderText = "Estado"
            dgvPlan.Columns(6).HeaderText = "Fecha de Creación"
            dgvPlan.Columns(7).HeaderText = "Última Modificación"

        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        cbOpcionBuscarMiembro.SelectedIndex = 0
        cbBuscarOpcionPlan.SelectedIndex = 0

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim idMiembro As UInteger
            Dim duracion As UInteger
            Dim idPlan As UInteger
            If dgvMiembro.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvMiembro.SelectedRows(0)
                idMiembro = CUInt(selectedRow.Cells("id_miembro").Value)
            End If
            If dgvPlan.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvPlan.SelectedRows(0)
                idPlan = CUInt(selectedRow.Cells("id_plan").Value)
                duracion = CUInt(selectedRow.Cells("duracion_dias").Value)
            End If
            NMembresias.Insertar(idMiembro, idPlan, duracion)
            MsgBox("Membresía insertada correctamente.", MsgBoxStyle.Information, "Éxito")

        Catch ex As Exception
            MsgBox("Error al obtener el ID del miembro o del plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarMiembro.TextChanged
        Try
            ' Verificar si hay un elemento seleccionado en el ComboBox
            If cbOpcionBuscarMiembro.SelectedIndex = 0 Then
                ' Buscar por nombre
                Dim dvMiembro As DataTable = NMiembros.BuscarPorNombre(tbBuscarMiembro.Text)
                dgvMiembro.DataSource = dvMiembro

            ElseIf cbOpcionBuscarMiembro.SelectedIndex = 1 Then
                ' Buscar por DNI
                Dim dvMiembro As DataTable = NMiembros.BuscarPorDni(tbBuscarMiembro.Text)
                dgvMiembro.DataSource = dvMiembro

            End If
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscarPlan_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarPlan.TextChanged
        Try
            ' Verificar si hay un elemento seleccionado en el ComboBox
            If cbBuscarOpcionPlan.SelectedIndex = 0 Then
                ' Buscar por nombre
                Dim dvPlan As DataTable = NPlan.BuscarPorNombre(tbBuscarPlan.Text)
                dgvPlan.DataSource = dvPlan
            End If
        Catch ex As Exception
            MsgBox("Error al buscar plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class