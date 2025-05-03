
Public Class FrmPrincipal
    'atributos formularios
    Private frmPlanes As New FrmPlanes()
    Private frmMembresias As New FrmMembresias()
    Private frmMiembros As New FrmMiembros()
    Private FrmPagos As New FrmPagos()

    Private Sub MostrarFormulario(formulario As Form)
        ' Limpiar el contenido actual del Panel1
        Panel1.Controls.Clear()

        ' Configurar el formulario para que se muestre dentro del Panel1
        formulario.TopLevel = False
        formulario.FormBorderStyle = FormBorderStyle.None
        formulario.Dock = DockStyle.Fill

        ' Agregar el formulario al Panel1 y mostrarlo
        Panel1.Controls.Add(formulario)
        formulario.Show()
    End Sub


    Private Sub btnMembresias_Click(sender As Object, e As EventArgs) Handles btnMembresias.Click
        MostrarFormulario(frmMembresias)
    End Sub

    Private Sub btnPlanes_Click(sender As Object, e As EventArgs) Handles btnPlanes.Click
        MostrarFormulario(frmPlanes)
    End Sub

    Private Sub btnMiembros_Click(sender As Object, e As EventArgs) Handles btnMiembros.Click
        MostrarFormulario(frmMiembros)
    End Sub

    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        MostrarFormulario(FrmPagos)
    End Sub

    Private Sub btnAsistencia_Click(sender As Object, e As EventArgs) Handles btnAsistencia.Click

    End Sub

    Private Sub btnReclamos_Click(sender As Object, e As EventArgs) Handles btnReclamos.Click

    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click

    End Sub

    Private Sub btnRoles_Click(sender As Object, e As EventArgs) Handles btnRoles.Click

    End Sub
End Class