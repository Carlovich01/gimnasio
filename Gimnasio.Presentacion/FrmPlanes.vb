Imports Gimnasio.Negocio
Imports Gimnasio.Entidades
Public Class FrmPlanes
    Private nPlanes As New NPlanes()

    Sub New()
        InitializeComponent()
        If UsuarioLogueado.IdRol = 2 Then
            btnInsertar.Visible = False
            btnInsertar.Enabled = False
            btnActualizar.Visible = False
            btnActualizar.Enabled = False
            btnEliminar.Visible = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).HeaderText = "Nombre del Plan"
            dgvListado.Columns(2).HeaderText = "Descripción"
            dgvListado.Columns(3).HeaderText = "Duración"
            dgvListado.Columns(4).HeaderText = "Precio"
            dgvListado.Columns(5).HeaderText = "Fecha de Creación"
            dgvListado.Columns(6).HeaderText = "Última Modificación"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los planes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim dvPlanes As DataTable = nPlanes.Listar()
            dgvListado.DataSource = dvPlanes
            lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al cargar los planes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        Try
            Dim frm As New FrmPlanesPopup(True, Me)
            frm.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub Insertar(nuevoPlan As Planes)
        Try
            nPlanes.Insertar(nuevoPlan)
            ActualizarDataGridView()
            MsgBox("Plan agregado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al agregar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim planPorActualizar As New Planes()
                planPorActualizar.IdPlan = CUInt(selectedRow.Cells("id_plan").Value)
                planPorActualizar.NombrePlan = selectedRow.Cells("nombre_plan").Value.ToString()
                planPorActualizar.Descripcion = selectedRow.Cells("descripcion").Value.ToString()
                planPorActualizar.DuracionDias = CUInt(selectedRow.Cells("duracion_dias").Value)
                planPorActualizar.Precio = CDec(selectedRow.Cells("precio").Value)

                Dim frm As New FrmPlanesPopup(False, Me, planPorActualizar)
                frm.ShowDialog()
            Else
                MsgBox("Seleccione un plan para actualizar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al seleccionar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Sub


    Public Sub Actualizar(planActualizado As Planes)
        Try
            nPlanes.Actualizar(planActualizado)
            ActualizarDataGridView()
            MsgBox("Plan actualizado exitosamente.", MsgBoxStyle.Information, "Exito")
        Catch ex As Exception
            MsgBox("Error al actualizar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idPlan As Integer = CInt(selectedRow.Cells("id_plan").Value)

                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este plan?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nPlanes.Eliminar(idPlan)

                    ActualizarDataGridView()
                    MsgBox("Plan eliminado exitosamente.", MsgBoxStyle.Information, "Exito")
                End If
            Else
                MsgBox("Seleccione un plan para eliminar.", MsgBoxStyle.Exclamation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Error al eliminar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvPlanes As DataTable = nPlanes.BuscarPorNombre(tbBuscar.Text)
                dgvListado.DataSource = dvPlanes
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub tbBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles tbBuscar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If cbOpcionBuscar.SelectedIndex = 1 Then
                    Dim dvPlanes As DataTable = nPlanes.BuscarPorDuracion(CInt(tbBuscar.Text))
                    dgvListado.DataSource = dvPlanes
                    lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
                ElseIf cbOpcionBuscar.SelectedIndex = 2 Then
                    Dim dvPlanes As DataTable = nPlanes.BuscarPorPrecio(CDec(tbBuscar.Text))
                    dgvListado.DataSource = dvPlanes
                    lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al buscar plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
End Class


