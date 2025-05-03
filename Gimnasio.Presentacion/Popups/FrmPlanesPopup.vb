Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmPlanesPopup
    Private frmPrincipal As FrmPlanes
    Private esNuevo As Boolean
    Private PlanPorActualizar As Planes

    'constructor para nuevo plan
    Public Sub New(Nuevo As Boolean, frm As FrmPlanes)
        InitializeComponent()
        esNuevo = Nuevo
        frmPrincipal = frm
    End Sub

    Public Sub New(Nuevo As Boolean, frm As FrmPlanes, PlanActualizado As Planes)
        InitializeComponent()
        esNuevo = Nuevo
        frmPrincipal = frm
        PlanPorActualizar = PlanActualizado
        tbNombre.Text = PlanActualizado.NombrePlan
        tbDescripcion.Text = PlanActualizado.Descripcion
        tbDuracion.Text = PlanActualizado.DuracionDias.ToString()
        tbPrecio.Text = PlanActualizado.Precio.ToString()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If esNuevo Then
            Try
                Dim nuevoPlan As New Planes()
                If String.IsNullOrWhiteSpace(tbNombre.Text) OrElse String.IsNullOrWhiteSpace(tbDuracion.Text) OrElse String.IsNullOrWhiteSpace(tbPrecio.Text) Then
                    MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                    Return
                End If

                nuevoPlan.NombrePlan = tbNombre.Text
                nuevoPlan.Descripcion = tbDescripcion.Text
                nuevoPlan.DuracionDias = CUInt(tbDuracion.Text)
                nuevoPlan.Precio = CDec(tbPrecio.Text)

                ' Llamar al método Insertar del formulario principal
                frmPrincipal.Insertar(nuevoPlan)

                ' Cerrar el formulario
                Me.Close()
            Catch ex As Exception
                MsgBox("Error al guardar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            Try
                Dim planActualizado As New Planes()
                If String.IsNullOrWhiteSpace(tbNombre.Text) OrElse String.IsNullOrWhiteSpace(tbDuracion.Text) OrElse String.IsNullOrWhiteSpace(tbPrecio.Text) Then
                    MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                    Return
                End If
                planActualizado.IdPlan = PlanPorActualizar.IdPlan
                planActualizado.NombrePlan = tbNombre.Text
                planActualizado.Descripcion = tbDescripcion.Text
                planActualizado.DuracionDias = CUInt(tbDuracion.Text)
                planActualizado.Precio = CDec(tbPrecio.Text)
                ' Llamar al método Actualizar del formulario principal
                frmPrincipal.Actualizar(planActualizado)
                ' Cerrar el formulario
                Me.Close()
            Catch ex As Exception
                MsgBox("Error al actualizar el plan: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


End Class


