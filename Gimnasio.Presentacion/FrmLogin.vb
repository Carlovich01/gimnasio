Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmLogin
    Private Sub pbOjoCerrado_Click(sender As Object, e As EventArgs) Handles pbOjoCerrado.Click
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

    Private Sub btIniciarSesion_Click(sender As Object, e As EventArgs) Handles btIniciarSesion.Click
        Try
            Dim username As String = tbUsuario.Text.Trim()
            Dim password As String = tbContraseña.Text.Trim()

            If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
                MsgBox("Por favor, ingrese su usuario y contraseña.", MsgBoxStyle.Exclamation, "Aviso")
                Return
            End If
            Dim nUsuarios As New NUsuarios()
            UsuarioLogueado = nUsuarios.ValidarCredenciales(username, password)

            If UsuarioLogueado IsNot Nothing Then
                Dim frmPrincipal As New FrmPrincipal()
                frmPrincipal.Show()
                Me.Hide()
            Else
                MsgBox("Usuario o contraseña incorrectos, o cuenta inactiva.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Error al iniciar sesión: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class