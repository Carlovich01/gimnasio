
Imports Gimnasio.Negocio
Imports Gimnasio.Entidades

Public Class FrmPrincipal

    Public Sub New()
        InitializeComponent()
        lblBienvenido.Visible = True
        lblBienvenido.Text = "¡Bienvenido, " & UsuarioLogueado.NombreCompleto & "! Tu rol es " & If(UsuarioLogueado.IdRol = 1, "Administrador", "Recepcionista") & "."
        If UsuarioLogueado.IdRol = 2 Then
            btnUsuarios.Visible = False
            btnUsuarios.Enabled = False
            ToolStripSeparator5.Visible = False
        End If
    End Sub

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim nMembresias As New NMembresias()
            nMembresias.ActualizarEstadosVencidos()
        Catch ex As Exception
            MsgBox("Error al actualizar los estados de las membresías: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub MostrarFormulario(formulario As Form)
        Panel1.Controls.Clear()

        formulario.TopLevel = False
        formulario.FormBorderStyle = FormBorderStyle.None
        formulario.Dock = DockStyle.Fill

        Panel1.Controls.Add(formulario)
        formulario.Show()
    End Sub


    Private Sub btnMembresias_Click(sender As Object, e As EventArgs) Handles btnMembresias.Click
        Dim frmMembresias = New FrmMembresias()
        MostrarFormulario(frmMembresias)
    End Sub

    Private Sub btnPlanes_Click(sender As Object, e As EventArgs) Handles btnPlanes.Click
        Dim frmPlanes = New FrmPlanes()
        MostrarFormulario(frmPlanes)
    End Sub

    Private Sub btnMiembros_Click(sender As Object, e As EventArgs) Handles btnMiembros.Click
        Dim frmMiembros = New FrmMiembros()
        MostrarFormulario(frmMiembros)
    End Sub

    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Dim frmPagos = New FrmPagos()
        MostrarFormulario(frmPagos)
    End Sub

    Private Sub btnAsistencia_Click(sender As Object, e As EventArgs) Handles btnAsistencia.Click
        Dim frmAsistencia = New FrmAsistencias()
        MostrarFormulario(frmAsistencia)
    End Sub

    Private Sub btnReclamos_Click(sender As Object, e As EventArgs) Handles btnReclamos.Click
        Dim frmReclamos = New FrmReclamos()
        MostrarFormulario(frmReclamos)
    End Sub

    Private Sub btRegistroAsistencias_Click(sender As Object, e As EventArgs) Handles btRegistroAsistencias.Click
        Dim frmRegistrosAsistencias = New FrmRegistroAsistencias()
        MostrarFormulario(frmRegistrosAsistencias)
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Dim frmUsuarios = New FrmUsuarios()
        MostrarFormulario(frmUsuarios)
    End Sub
End Class