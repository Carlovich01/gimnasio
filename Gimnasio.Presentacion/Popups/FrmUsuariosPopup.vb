Imports Gimnasio.Entidades
Imports Gimnasio.Negocio
Public Class FrmUsuariosPopup
    Private frmPrincipal As FrmUsuarios
    Private esNuevo As Boolean
    Private UsuarioPorActualizar As Usuarios

    Public Sub New(Nuevo As Boolean, frm As FrmUsuarios)
        InitializeComponent()
        esNuevo = Nuevo
        frmPrincipal = frm
    End Sub

    Public Sub New(Nuevo As Boolean, frm As FrmUsuarios, UsuarioActualizado As Usuarios)
        InitializeComponent()
        esNuevo = Nuevo
        frmPrincipal = frm
        UsuarioPorActualizar = UsuarioActualizado
        tbNombreUsuario.Text = UsuarioActualizado.Username
        tbNombreCompleto.Text = UsuarioActualizado.NombreCompleto
        tbEmail.Text = UsuarioActualizado.Email
        cbRol.SelectedIndex = If(UsuarioActualizado.IdRol = 1, 0, 1)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If esNuevo Then
            Try
                Dim nuevoUsuario As New Usuarios()
                If String.IsNullOrWhiteSpace(tbNombreUsuario.Text) OrElse String.IsNullOrWhiteSpace(tbContraseña.Text) OrElse String.IsNullOrWhiteSpace(tbNombreCompleto.Text) OrElse String.IsNullOrWhiteSpace(cbRol.Text) Then
                    MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                    Return
                End If
                nuevoUsuario.Username = tbNombreUsuario.Text
                nuevoUsuario.PasswordHash = tbContraseña.Text
                nuevoUsuario.NombreCompleto = tbNombreCompleto.Text
                nuevoUsuario.Email = If(String.IsNullOrWhiteSpace(tbEmail.Text), Nothing, tbEmail.Text)
                nuevoUsuario.IdRol = If(cbRol.SelectedItem.ToString() = "Administrador", 1, 2)
                frmPrincipal.Insertar(nuevoUsuario)
                Me.Close()
            Catch ex As Exception
                MsgBox("Error al guardar el usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            Try
                Dim usuarioActualizado As New Usuarios()
                If String.IsNullOrWhiteSpace(tbNombreUsuario.Text) OrElse String.IsNullOrWhiteSpace(tbContraseña.Text) OrElse String.IsNullOrWhiteSpace(tbNombreCompleto.Text) Then
                    MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                    Return
                End If
                usuarioActualizado.IdUsuario = UsuarioPorActualizar.IdUsuario
                usuarioActualizado.Username = tbNombreUsuario.Text
                usuarioActualizado.PasswordHash = tbContraseña.Text
                usuarioActualizado.NombreCompleto = tbNombreCompleto.Text
                usuarioActualizado.Email = If(String.IsNullOrWhiteSpace(tbEmail.Text), Nothing, tbEmail.Text)
                usuarioActualizado.IdRol = If(cbRol.SelectedItem.ToString() = "Administrador", 1, 2)
                frmPrincipal.Actualizar(usuarioActualizado)
                Me.Close()
            Catch ex As Exception
                MsgBox("Error al actualizar el usuario: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al cancelar: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub pbOjoContraseña_Click(sender As Object, e As EventArgs) Handles pbOjoCerrado.Click
        Try
            tbContraseña.UseSystemPasswordChar = False
            pbOjoCerrado.Visible = False
            pbOjoAbierto.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub pbOjoAbierto_Click(sender As Object, e As EventArgs) Handles pbOjoAbierto.Click
        Try
            tbContraseña.UseSystemPasswordChar = True
            pbOjoCerrado.Visible = True
            pbOjoAbierto.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class