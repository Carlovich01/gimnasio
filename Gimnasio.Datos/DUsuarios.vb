Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades
Imports Mysqlx.XDevAPI.Relational

Public Class DUsuarios
    Inherits ConexionBase
    Public Function Listar() As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT u.id_usuario, u.username, u.password_hash, u.nombre_completo, u.email, r.nombre_rol, u.fecha_creacion, u.ultima_modificacion FROM usuarios_sistema AS u INNER JOIN roles AS r ON u.id_rol = r.id_rol ORDER BY u.ultima_modificacion DESC"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Usuarios)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "INSERT INTO usuarios_sistema (username, password_hash, nombre_completo, email, id_rol) VALUES (@user, @pass, @nom, @ema, @idr)"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@user", Obj.Username)
                    comando.Parameters.AddWithValue("@pass", Obj.PasswordHash)
                    comando.Parameters.AddWithValue("@nom", Obj.NombreCompleto)
                    comando.Parameters.AddWithValue("@ema", Obj.Email)
                    comando.Parameters.AddWithValue("@idr", Obj.IdRol)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Usuarios)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE usuarios_sistema SET username = @user, password_hash = @pass, nombre_completo = @nom, email = @ema WHERE id_usuario = @id"

                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@idu", Obj.IdUsuario)
                    comando.Parameters.AddWithValue("@user", Obj.Username)
                    comando.Parameters.AddWithValue("@pass", Obj.PasswordHash)
                    comando.Parameters.AddWithValue("@nom", Obj.NombreCompleto)
                    comando.Parameters.AddWithValue("@ema", Obj.Email)
                    comando.Parameters.AddWithValue("@id", Obj.IdUsuario)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Eliminar(id As Integer)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "DELETE FROM usuarios_sistema WHERE id_usuario = @id"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@id", id)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function BuscarPorNombre(nombre As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM usuarios_sistema WHERE nombre_completo LIKE @nombre ORDER BY ultima_modificacion DESC"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@nombre", "%" & nombre & "%")
                    Dim adapter As New MySqlDataAdapter(comando)
                    Dim tabla As New DataTable()
                    adapter.Fill(tabla)
                    Return tabla
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ObtenerPorUsername(username As String) As Usuarios
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM usuarios_sistema WHERE username = @user"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@user", username)
                    Using reader As MySqlDataReader = comando.ExecuteReader()
                        If reader.Read() Then
                            Dim usuario As New Usuarios()
                            usuario.IdUsuario = Convert.ToInt32(reader("id_usuario"))
                            usuario.Username = reader("username").ToString()
                            usuario.PasswordHash = reader("password_hash").ToString()
                            usuario.NombreCompleto = reader("nombre_completo").ToString()
                            usuario.Email = If(IsDBNull(reader("email")), Nothing, reader("email").ToString())
                            usuario.IdRol = Convert.ToInt32(reader("id_rol"))
                            Return usuario
                        End If
                    End Using
                End Using
            End Using
            Return Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class