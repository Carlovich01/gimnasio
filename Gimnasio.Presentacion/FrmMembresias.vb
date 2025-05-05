Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmMembresias
    Private nMembresias As New NMembresias()


    Private Sub FrmPlanes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ActualizarDataGridView()

            dgvListado.Columns(0).Visible = False
            dgvListado.Columns(1).Visible = False
            dgvListado.Columns(2).Visible = False
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
            frm.ShowDialog()
            ActualizarDataGridView()
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de inserción: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnPagar_Click(sender As Object, e As EventArgs) Handles BtnPagar.Click
        Try
            If dgvListado.SelectedRows.Count > 0 Then
                Dim selectedRow As DataGridViewRow = dgvListado.SelectedRows(0)
                Dim idMembresia As Integer = CInt(selectedRow.Cells("id_membresia").Value)
                Dim precio As Decimal = Convert.ToDecimal(selectedRow.Cells("precio_plan").Value)
                Dim estadoMembresia As String = selectedRow.Cells("estado_membresia").Value.ToString()

                If estadoMembresia = "Activa" Then
                    MsgBox("La membresía ya está activa. No es necesario realizar un pago.", MsgBoxStyle.Information, "Información")
                    Return
                ElseIf estadoMembresia = "Inactiva" Then
                    Dim frmPagosPopup As New FrmPagosPopup(idMembresia, precio)
                    frmPagosPopup.ShowDialog()
                    ActualizarDataGridView()
                Else
                    MsgBox("El estado de la membresía no es válido.", MsgBoxStyle.Exclamation, "Advertencia")
                End If
            Else
                MsgBox("Por favor, seleccione una fila antes de continuar.", MsgBoxStyle.Exclamation, "Advertencia")
            End If
        Catch ex As Exception
            MsgBox("Error al abrir el formulario de pagos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub tbBuscar_TextChanged_1(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 0 Then
                Dim dvMembresia As DataTable = nMembresias.BuscarPorDni(tbBuscar.Text)
                dgvListado.DataSource = dvMembresia
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString
            ElseIf cbOpcionBuscar.SelectedIndex = 1 Then
                Dim dvMembresia As DataTable = nMembresias.BuscarPorNombrePlan(tbBuscar.Text)
                dgvListado.DataSource = dvMembresia
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString
            End If
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cbOpcionBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOpcionBuscar.SelectedIndexChanged
        Try
            If cbOpcionBuscar.SelectedIndex = 2 Then
                Dim dvMembresia As DataTable = nMembresias.BuscarPorEstado("Activa")
                dgvListado.DataSource = dvMembresia
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString
                tbBuscar.Enabled = False
            ElseIf cbOpcionBuscar.SelectedIndex = 3 Then
                Dim dvMembresia As DataTable = nMembresias.BuscarPorEstado("Inactiva")
                dgvListado.DataSource = dvMembresia
                lblTotal.Text = "Total: " & dgvListado.Rows.Count.ToString
                tbBuscar.Enabled = False
            Else
                tbBuscar.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("Error al buscar miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class