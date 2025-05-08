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

            dgvListado.Columns("IdPlan").Visible = False
            dgvListado.Columns("NombrePlan").HeaderText = "Nombre del Plan"
            dgvListado.Columns("Descripcion").HeaderText = "Descripción"
            dgvListado.Columns("DuracionDias").HeaderText = "Duración (días)"
            dgvListado.Columns("Precio").HeaderText = "Precio"
            dgvListado.Columns("FechaCreacion").HeaderText = "Fecha de Creación"
            dgvListado.Columns("UltimaModificacion").HeaderText = "Última Modificación"
            cbOpcionBuscar.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error al cargar los planes: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub ActualizarDataGridView()
        Try
            Dim planes As List(Of Planes) = nPlanes.Listar()
            dgvListado.DataSource = planes
            lblTotal.Text = "Total: " & planes.Count.ToString()
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
            MsgBox("Plan agregado exitosamente.", MsgBoxStyle.Information, "Éxito")
        Catch ex As Exception
            MsgBox("Error al agregar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim planPorActualizar As New Planes() With {
                    .IdPlan = CUInt(selectedRow.Cells("IdPlan").Value),
                    .NombrePlan = selectedRow.Cells("NombrePlan").Value.ToString(),
                    .Descripcion = selectedRow.Cells("Descripcion").Value.ToString(),
                    .DuracionDias = CUInt(selectedRow.Cells("DuracionDias").Value),
                    .Precio = CDec(selectedRow.Cells("Precio").Value)
                }

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
            MsgBox("Plan actualizado exitosamente.", MsgBoxStyle.Information, "Éxito")
        Catch ex As Exception
            MsgBox("Error al actualizar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idPlan As UInteger = CUInt(selectedRow.Cells("IdPlan").Value)

                Dim confirmacion As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este plan?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmacion = DialogResult.Yes Then
                    nPlanes.Eliminar(idPlan)

                    ActualizarDataGridView()
                    MsgBox("Plan eliminado exitosamente.", MsgBoxStyle.Information, "Éxito")
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
            Dim planes As List(Of Planes) = Nothing

            If cbOpcionBuscar.SelectedIndex = 0 Then
                planes = nPlanes.ListarPorNombre(tbBuscar.Text)
            End If

            dgvListado.DataSource = planes
            lblTotal.Text = "Total: " & planes.Count.ToString()
        Catch ex As Exception
            MsgBox("Error al buscar plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles tbBuscar.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim planes As List(Of Planes) = Nothing

                If cbOpcionBuscar.SelectedIndex = 1 Then
                    planes = nPlanes.ListarPorDuracion(CUInt(tbBuscar.Text))
                ElseIf cbOpcionBuscar.SelectedIndex = 2 Then
                    planes = nPlanes.ListarPorPrecio(CDec(tbBuscar.Text))
                End If

                dgvListado.DataSource = planes
                lblTotal.Text = "Total: " & planes.Count.ToString()
            End If
        Catch ex As Exception
            MsgBox("Error al buscar plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
