Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports System.Security.Cryptography
Imports System.Text
Public Class NUsuarios
    Private dUsuarios As New DUsuarios()

    Private Function GenerarHash(password As String) As String
        Try
            Using sha256 As SHA256 = SHA256.Create()
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
                Dim hash As Byte() = sha256.ComputeHash(bytes)
                Return Convert.ToBase64String(hash)
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function Listar() As List(Of Usuarios)
        Try
            Dim dvUsuarios As List(Of Usuarios)
            dvUsuarios = dUsuarios.Listar()
            Return dvUsuarios
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Usuarios)
        Try
            Obj.PasswordHash = GenerarHash(Obj.PasswordHash)
            dUsuarios.Insertar(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Usuarios)
        Try
            Obj.PasswordHash = GenerarHash(Obj.PasswordHash)
            dUsuarios.Actualizar(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Public Sub Eliminar(id As UInteger)
        Try
            dUsuarios.Eliminar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorNombre(nombre As String) As List(Of Usuarios)
        Try
            Dim dvUsuarios As List(Of Usuarios) = dUsuarios.ListarPorNombre(nombre)
            Return dvUsuarios
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ValidarCredenciales(username As String, password As String) As Usuarios
        Try
            Dim usuario As Usuarios = dUsuarios.ObtenerPorUsername(username)
            If usuario IsNot Nothing Then
                Dim hashIngresado As String = GenerarHash(password)
                If usuario.PasswordHash = hashIngresado Then
                    Return usuario
                End If
            End If
            Return Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class