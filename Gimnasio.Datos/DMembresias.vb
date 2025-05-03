Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades
Imports Mysqlx.XDevAPI.Relational
Public Class DMembresias
    Inherits ConexionBase
    Public Function Listar() As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                ' Consulta con uniones para obtener datos de membresías, miembros y planes
                Dim query As String = "
                SELECT 
                    mm.id_membresia,
                    mm.id_miembro,
                    mm.id_plan,
                    m.dni AS dni_miembro,
                    m.apellido AS apellido_miembro,
                    m.nombre AS nombre_miembro,
                    p.nombre_plan AS nombre_plan,
                    p.precio AS precio_plan,
                    p.duracion_dias AS duracion_dias_plan,
                    mm.fecha_inicio,
                    mm.fecha_fin,
                    mm.estado_membresia,
                    mm.fecha_registro,
                    mm.ultima_modificacion
                FROM 
                    membresias_miembro mm
                INNER JOIN 
                    miembros m ON mm.id_miembro = m.id_miembro
                INNER JOIN 
                    planes_membresia p ON mm.id_plan = p.id_plan
            "
                Dim adapter As New MySqlDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception("Error al listar las membresías: " & ex.Message)
        End Try
    End Function


    Public Sub Insertar(idMiembro As Integer, idPlan As Integer, membresia As Membresias)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "INSERT INTO membresias_miembro (id_miembro,id_plan,fecha_inicio,fecha_fin) VALUES (@idmi,@idpla,@in,@fin)"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@idmi", idMiembro)
                    comando.Parameters.AddWithValue("@idpla", idPlan)
                    comando.Parameters.AddWithValue("@in", membresia.FechaInicio)
                    comando.Parameters.AddWithValue("@fin", membresia.FechaFin)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(miembro As Miembros, plan As Planes, membresia As Membresias)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE membresias_miembro SET estado_membresia=@est, fecha_fin=@fin WHERE id_miembro = @id AND id_plan = @idpla"

                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@fin", membresia.FechaFin)
                    comando.Parameters.AddWithValue("@est", membresia.EstadoMembresia)
                    comando.Parameters.AddWithValue("@id", miembro.IdMiembro)
                    comando.Parameters.AddWithValue("@idpla", plan.IdPlan)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Desactivar(idMiembro As Integer, idPlan As Integer)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "UPDATE membresias_miembro SET estado = 'Inactiva' WHERE id_miembro = @id AND id_plan=@idpla"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@id", idMiembro)
                    comando.Parameters.AddWithValue("@idpla", idPlan)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
