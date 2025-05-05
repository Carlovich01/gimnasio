Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmMiembrosPopup

    Private frmPrincipal As FrmMiembros
    Private esNuevo As Boolean
    Private MiembroPorActualizar As Miembros


    Public Sub New(Nuevo As Boolean, frm As FrmMiembros)
        InitializeComponent()
        esNuevo = Nuevo
        frmPrincipal = frm
    End Sub

    Public Sub New(Nuevo As Boolean, frm As FrmMiembros, MiembroActualizado As Miembros)
        InitializeComponent()
        esNuevo = Nuevo
        frmPrincipal = frm
        MiembroPorActualizar = MiembroActualizado
        tbDni.Text = MiembroActualizado.Dni
        tbNombre.Text = MiembroActualizado.Nombre
        tbApellido.Text = MiembroActualizado.Apellido
        cbGenero.SelectedItem = MiembroActualizado.Genero
        tbTelefono.Text = MiembroActualizado.Telefono
        tbEmail.Text = MiembroActualizado.Email
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If esNuevo Then
                Try
                    Dim nuevoMiembro As New Miembros()
                    If String.IsNullOrWhiteSpace(tbDni.Text) OrElse String.IsNullOrWhiteSpace(tbNombre.Text) OrElse String.IsNullOrWhiteSpace(tbApellido.Text) Then
                        MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                        Return
                    End If

                    nuevoMiembro.Dni = tbDni.Text
                    nuevoMiembro.Nombre = tbNombre.Text
                    nuevoMiembro.Apellido = tbApellido.Text
                    If cbGenero.SelectedItem IsNot Nothing Then
                        nuevoMiembro.Genero = cbGenero.SelectedItem.ToString()
                    End If
                    nuevoMiembro.Telefono = tbTelefono.Text
                    nuevoMiembro.Email = tbEmail.Text

                    ' Llamar al método Insertar del formulario principal
                    frmPrincipal.Insertar(nuevoMiembro)

                    ' Cerrar el formulario
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Error al guardar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            Else
                Try
                    Dim miembroActualizado As New Miembros()
                    If String.IsNullOrWhiteSpace(tbDni.Text) OrElse String.IsNullOrWhiteSpace(tbNombre.Text) OrElse String.IsNullOrWhiteSpace(tbApellido.Text) Then
                        MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                        Return
                    End If
                    miembroActualizado.Dni = tbDni.Text
                    miembroActualizado.Nombre = tbNombre.Text
                    miembroActualizado.Apellido = tbApellido.Text
                    If cbGenero.SelectedItem IsNot Nothing Then
                        miembroActualizado.Genero = cbGenero.SelectedItem.ToString()
                    End If
                    miembroActualizado.Telefono = tbTelefono.Text
                    miembroActualizado.Email = tbEmail.Text
                    miembroActualizado.IdMiembro = MiembroPorActualizar.IdMiembro

                    ' Llamar al método Actualizar del formulario principal
                    frmPrincipal.Actualizar(miembroActualizado)
                    ' Cerrar el formulario
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Error al actualizar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error al guardar el miembro: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al cancelar: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class