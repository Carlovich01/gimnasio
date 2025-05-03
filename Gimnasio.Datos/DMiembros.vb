Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades
Imports Mysqlx.XDevAPI.Relational

Public Class DMiembros
    Inherits ConexionBase
    Public Function Listar() As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM miembros"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Miembros)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "INSERT INTO miembros (dni, nombre, apellido, fecha_nacimiento, genero, telefono, email) VALUES (@dni, @nom, @ape, @fecha, @gen, @tel, @ema)"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@dni", Obj.Dni)
                    comando.Parameters.AddWithValue("@nom", Obj.Nombre)
                    comando.Parameters.AddWithValue("@ape", Obj.Apellido)
                    comando.Parameters.AddWithValue("@fecha", Obj.FechaNacimiento)
                    comando.Parameters.AddWithValue("@gen", Obj.Genero)
                    comando.Parameters.AddWithValue("@tel", Obj.Telefono)
                    comando.Parameters.AddWithValue("@ema", Obj.Email)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Miembros)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE miembros SET dni = @dni, nombre = @nom, apellido = @ape, fecha_nacimiento = @fecha, genero = @gen, telefono = @tel, email = @ema WHERE id_miembro = @id"

                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@dni", Obj.Dni)
                    comando.Parameters.AddWithValue("@nom", Obj.Nombre)
                    comando.Parameters.AddWithValue("@ape", Obj.Apellido)
                    comando.Parameters.AddWithValue("@fecha", Obj.FechaNacimiento)
                    comando.Parameters.AddWithValue("@gen", Obj.Genero)
                    comando.Parameters.AddWithValue("@tel", Obj.Telefono)
                    comando.Parameters.AddWithValue("@ema", Obj.Email)
                    comando.Parameters.AddWithValue("@id", Obj.IdMiembro)

                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Activar(id As Integer)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE miembros SET estado = 'Activo' WHERE id_miembro = @id"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@id", id)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Desactivar(id As Integer)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE miembros SET estado = 'Inactivo' WHERE id_miembro = @id"
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
                Dim query As String = "SELECT * FROM miembros WHERE nombre LIKE @nombre"
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

    Public Function BuscarPorDni(dni As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM miembros WHERE dni LIKE @dni"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@dni", "%" & dni & "%")
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

End Class