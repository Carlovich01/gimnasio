' Proyecto: Datos
Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades
Imports Mysqlx.XDevAPI.Relational

Public Class DPlanes
    Inherits ConexionBase
    Public Function Listar() As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM planes_membresia ORDER BY ultima_modificacion DESC"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Planes)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "INSERT INTO planes_membresia (nombre_plan, descripcion, duracion_dias, precio) VALUES (@nom, @des, @dur, @pre)"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@nom", Obj.NombrePlan)
                    comando.Parameters.AddWithValue("@des", Obj.Descripcion)
                    comando.Parameters.AddWithValue("@dur", Obj.DuracionDias)
                    comando.Parameters.AddWithValue("@pre", Obj.Precio)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Planes)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE planes_membresia SET nombre_plan = @nom, descripcion = @des, duracion_dias = @dur, precio = @pre WHERE id_plan = @id"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@id", Obj.IdPlan)
                    comando.Parameters.AddWithValue("@nom", Obj.NombrePlan)
                    comando.Parameters.AddWithValue("@des", Obj.Descripcion)
                    comando.Parameters.AddWithValue("@dur", Obj.DuracionDias)
                    comando.Parameters.AddWithValue("@pre", Obj.Precio)
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
                Dim query As String = "DELETE FROM planes_membresia WHERE id_plan = @id"
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
                Dim query As String = "SELECT * FROM planes_membresia WHERE nombre_plan LIKE @nombre ORDER BY ultima_modificacion DESC"
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

    Public Function BuscarPorDuracion(duracion As Integer) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM planes_membresia WHERE duracion_dias = @duracion ORDER BY ultima_modificacion DESC"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@duracion", duracion)
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

    Public Function BuscarPorPrecio(precio As Decimal) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM planes_membresia WHERE precio = @precio ORDER BY ultima_modificacion DESC"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@precio", precio)
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
