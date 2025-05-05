' Proyecto: Datos
Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades
Imports Mysqlx.XDevAPI.Relational

Public Class DReclamos
    Inherits ConexionBase
    Public Function Listar() As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_reclamos"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception("Error al listar los reclamos: " & ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Reclamos)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "INSERT INTO reclamos (tipo, descripcion, id_miembro) VALUES (@tipo, @des, @idMiembro)"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@tipo", Obj.Tipo)
                    comando.Parameters.AddWithValue("@des", Obj.Descripcion)
                    comando.Parameters.AddWithValue("@idMiembro", If(Obj.IdMiembro.HasValue, Obj.IdMiembro, DBNull.Value))
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Reclamos)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE reclamos SET tipo = @tipo, descripcion = @des, id_miembro =@idMiembro WHERE id_reclamos = @id"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@id", Obj.IdReclamos)
                    comando.Parameters.AddWithValue("@tipo", Obj.Tipo)
                    comando.Parameters.AddWithValue("@des", Obj.Descripcion)
                    comando.Parameters.AddWithValue("@idMiembro", If(Obj.IdMiembro.HasValue, Obj.IdMiembro, DBNull.Value))

                    Dim filasAfectadas As Integer = comando.ExecuteNonQuery()

                    If filasAfectadas = 0 Then
                        Throw New Exception("No se actualizó ningún reclamo. Verifique el ID o los datos ingresados.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Error al actualizar el reclamo: " & ex.Message)
        End Try
    End Sub
    Public Sub Eliminar(id As Integer)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "DELETE FROM reclamos WHERE id_reclamos = @id"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@id", id)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub EstadoResuelto(id As Integer)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE reclamos SET estado = 'resuelto' WHERE id_reclamos = @id"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@id", id)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub EstadoPendiente(id As Integer)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE reclamos SET estado = 'pendiente' WHERE id_reclamos = @id"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@id", id)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Respuestas(Obj As Reclamos)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE reclamos SET respuesta = @respuesta, fecha_respuesta = @fechr WHERE id_reclamos = @id"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@respuesta", Obj.Respuesta)
                    comando.Parameters.AddWithValue("@id", Obj.IdReclamos)
                    comando.Parameters.AddWithValue("@fechr", DateTime.Now)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function BuscarPorEstado(Estado As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM vista_reclamos WHERE estado = @estado"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@estado", Estado)
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


