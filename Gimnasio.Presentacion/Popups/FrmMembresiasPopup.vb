Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Imports Google.Protobuf.WellKnownTypes

Public Class FrmMembresiasPopup
    Private NMiembros As New NMiembros()
    Private NPlan As New NPlanes()
    Private NMembresias As New NMembresias()
    Private nuevoMiembro As Miembros
    Private usuarioLogueado As Usuarios

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(nuevoMiembro As Miembros)
        InitializeComponent()
        Me.nuevoMiembro = nuevoMiembro
    End Sub

    Public Sub New(usuario As Usuarios)
        InitializeComponent()
        usuarioLogueado = usuario
    End Sub

    Private Sub FrmMembresiasPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim dtMiembros As DataTable = NMiembros.Listar()
            dgvMiembro.DataSource = dtMiembros
            dgvMiembro.Columns(0).HeaderText = "ID"
            dgvMiembro.Columns(1).HeaderText = "DNI"
            dgvMiembro.Columns(2).HeaderText = "Nombre"
            dgvMiembro.Columns(3).HeaderText = "Apellido"
            dgvMiembro.Columns(4).HeaderText = "Género"
            dgvMiembro.Columns(5).HeaderText = "Teléfono"
            dgvMiembro.Columns(6).HeaderText = "Email"
            dgvMiembro.Columns(7).HeaderText = "Fecha de Registro"
            dgvMiembro.Columns(8).HeaderText = "Última Modificación"
            cbOpcionBuscarMiembro.SelectedIndex = 1
            If nuevoMiembro IsNot Nothing Then
                tbBuscarMiembro.Text = nuevoMiembro.Dni
                tbBuscarMiembro.Enabled = False
            End If

            Dim dtPlanes As DataTable = NPlan.Listar()
            dgvPlan.DataSource = dtPlanes
            dgvPlan.Columns(0).HeaderText = "ID"
            dgvPlan.Columns(1).HeaderText = "Nombre del Plan"
            dgvPlan.Columns(2).HeaderText = "Descripción"
            dgvPlan.Columns(3).HeaderText = "Duración"
            dgvPlan.Columns(4).HeaderText = "Precio"
            dgvPlan.Columns(5).HeaderText = "Fecha de Creación"
            dgvPlan.Columns(6).HeaderText = "Última Modificación"
            cbBuscarOpcionPlan.SelectedIndex = 0

        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim membresia As New Membresias()
            Dim precio As Decimal
            If dgvMiembro.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvMiembro.SelectedRows(0)
                membresia.IdMiembro = CInt(selectedRow.Cells("id_miembro").Value)
            End If
            If dgvPlan.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvPlan.SelectedRows(0)
                membresia.IdPlan = CInt(selectedRow.Cells("id_plan").Value)
                precio = Convert.ToDecimal(selectedRow.Cells("precio").Value)
            End If
            NMembresias.Insertar(membresia)
            MsgBox("Membresía insertada correctamente.", MsgBoxStyle.Information, "Éxito")
            Dim idMembresia As Integer
            idMembresia = NMembresias.ObtenerIdMembresia(membresia)
            Dim frmPagos As New FrmPagosPopup(idMembresia, precio)
            frmPagos.ShowDialog()
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al obtener el ID del miembro o del plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al cancelar " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarMiembro.TextChanged
        Try
            If cbOpcionBuscarMiembro.SelectedIndex = 0 Then
                Dim dvMiembro As DataTable = NMiembros.BuscarPorNombre(tbBuscarMiembro.Text)
                dgvMiembro.DataSource = dvMiembro

            ElseIf cbOpcionBuscarMiembro.SelectedIndex = 1 Then
                Dim dvMiembro As DataTable = NMiembros.BuscarPorDni(tbBuscarMiembro.Text)
                dgvMiembro.DataSource = dvMiembro

            End If
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscarPlan_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarPlan.TextChanged
        Try
            If cbBuscarOpcionPlan.SelectedIndex = 0 Then
                Dim dvPlan As DataTable = NPlan.BuscarPorNombre(tbBuscarPlan.Text)
                dgvPlan.DataSource = dvPlan
            End If
        Catch ex As Exception
            MsgBox("Error al buscar plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class