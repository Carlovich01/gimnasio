Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

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
            ' Cargar miembros
            Dim miembros As List(Of Miembros) = NMiembros.Listar()
            dgvMiembro.DataSource = miembros
            dgvMiembro.Columns("IdMiembro").HeaderText = "ID"
            dgvMiembro.Columns("Dni").HeaderText = "DNI"
            dgvMiembro.Columns("Nombre").HeaderText = "Nombre"
            dgvMiembro.Columns("Apellido").HeaderText = "Apellido"
            dgvMiembro.Columns("Genero").HeaderText = "Género"
            dgvMiembro.Columns("Telefono").HeaderText = "Teléfono"
            dgvMiembro.Columns("Email").HeaderText = "Email"
            dgvMiembro.Columns("FechaRegistro").HeaderText = "Fecha de Registro"
            dgvMiembro.Columns("UltimaModificacion").HeaderText = "Última Modificación"
            cbOpcionBuscarMiembro.SelectedIndex = 1

            If nuevoMiembro IsNot Nothing Then
                tbBuscarMiembro.Text = nuevoMiembro.Dni
                tbBuscarMiembro.Enabled = False
            End If

            ' Cargar planes
            Dim planes As List(Of Planes) = NPlan.Listar()
            dgvPlan.DataSource = planes
            dgvPlan.Columns("IdPlan").HeaderText = "ID"
            dgvPlan.Columns("NombrePlan").HeaderText = "Nombre del Plan"
            dgvPlan.Columns("Descripcion").HeaderText = "Descripción"
            dgvPlan.Columns("DuracionDias").HeaderText = "Duración"
            dgvPlan.Columns("Precio").HeaderText = "Precio"
            dgvPlan.Columns("FechaCreacion").HeaderText = "Fecha de Creación"
            dgvPlan.Columns("UltimaModificacion").HeaderText = "Última Modificación"
            cbBuscarOpcionPlan.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim membresia As New Membresias()
            Dim precio As Decimal

            ' Obtener miembro seleccionado
            If dgvMiembro.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvMiembro.SelectedRows(0)
                membresia.IdMiembro = CUInt(selectedRow.Cells("IdMiembro").Value)
            End If

            ' Obtener plan seleccionado
            If dgvPlan.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvPlan.SelectedRows(0)
                membresia.IdPlan = CUInt(selectedRow.Cells("IdPlan").Value)
                precio = Convert.ToDecimal(selectedRow.Cells("Precio").Value)
            End If

            ' Insertar membresía
            NMembresias.Insertar(membresia)
            MsgBox("Membresía insertada correctamente.", MsgBoxStyle.Information, "Éxito")

            ' Obtener ID de la membresía y abrir el formulario de pagos
            Dim idMembresia As UInteger = NMembresias.ObtenerIdMembresia(membresia)
            Dim frmPagos As New FrmPagosPopup(idMembresia, precio)
            frmPagos.ShowDialog()
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al guardar la membresía: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al cancelar: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscarMiembro_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarMiembro.TextChanged
        Try
            Dim miembros As List(Of Miembros) = Nothing

            If cbOpcionBuscarMiembro.SelectedIndex = 0 Then
                miembros = NMiembros.ListarPorNombre(tbBuscarMiembro.Text)
            ElseIf cbOpcionBuscarMiembro.SelectedIndex = 1 Then
                Dim miembro As Miembros = NMiembros.ObtenerPorDni(tbBuscarMiembro.Text)
                miembros = If(miembro IsNot Nothing, New List(Of Miembros) From {miembro}, New List(Of Miembros)())
            End If

            dgvMiembro.DataSource = miembros
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscarPlan_TextChanged(sender As Object, e As EventArgs) Handles tbBuscarPlan.TextChanged
        Try
            If cbBuscarOpcionPlan.SelectedIndex = 0 Then
                Dim planes As List(Of Planes) = NPlan.ListarPorNombre(tbBuscarPlan.Text)
                dgvPlan.DataSource = planes
            End If
        Catch ex As Exception
            MsgBox("Error al buscar plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
