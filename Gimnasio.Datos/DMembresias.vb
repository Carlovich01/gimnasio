Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades
Imports Mysqlx.XDevAPI.Relational
Public Class DMembresias
    Inherits ConexionBase
    Public Function Listar() As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim actualizarQuery As String = "
                     UPDATE membresias_miembro
                     SET estado_membresia = 'Inactiva'
                     WHERE estado_membresia = 'Activa' AND fecha_fin < CURDATE()"
                Using comandoActualizar As New MySqlCommand(actualizarQuery, conexion)
                    comandoActualizar.ExecuteNonQuery()
                End Using

                Dim query As String = "SELECT * FROM vista_membresias"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Sub Insertar(membresia As Membresias)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()

                Dim verificarQuery As String = "
                SELECT COUNT(*) 
                FROM membresias_miembro 
                WHERE id_miembro = @idMiembro 
                  AND id_plan = @idPlan "
                Using verificarComando As New MySqlCommand(verificarQuery, conexion)
                    verificarComando.Parameters.AddWithValue("@idMiembro", membresia.IdMiembro)
                    verificarComando.Parameters.AddWithValue("@idPlan", membresia.IdPlan)
                    Dim existe As Integer = Convert.ToInt32(verificarComando.ExecuteScalar())

                    If existe > 0 Then
                        Throw New Exception("El usuario ya tiene una membresía activa o pendiente de pago para este plan.")
                    End If
                End Using

                Dim query As String = "INSERT INTO membresias_miembro (id_miembro, id_plan, fecha_inicio, fecha_fin) VALUES (@idmi, @idpla, @in, @fin)"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@idmi", membresia.IdMiembro)
                    comando.Parameters.AddWithValue("@idpla", membresia.IdPlan)
                    comando.Parameters.AddWithValue("@in", membresia.FechaInicio)
                    comando.Parameters.AddWithValue("@fin", membresia.FechaFin)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ObtenerIdMembresia(membresia As Membresias) As Integer
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT id_membresia FROM membresias_miembro WHERE id_miembro = @idmi AND id_plan = @idpla"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@idmi", membresia.IdMiembro)
                    comando.Parameters.AddWithValue("@idpla", membresia.IdPlan)
                    Dim resultado = comando.ExecuteScalar()
                    Return If(resultado IsNot Nothing, Convert.ToInt32(resultado), 0)
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub ActualizarEstadoYFechas(membresia As Membresias)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "
                UPDATE membresias_miembro
                SET estado_membresia = @estado, fecha_inicio = @fechaInicio, fecha_fin = @fechaFin
                WHERE id_membresia = @idMembresia"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@estado", membresia.EstadoMembresia)
                    comando.Parameters.AddWithValue("@fechaInicio", membresia.FechaInicio)
                    comando.Parameters.AddWithValue("@fechaFin", membresia.FechaFin)
                    comando.Parameters.AddWithValue("@idMembresia", membresia.IdMembresia)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub ActualizarEstadosVencidos()
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "
                UPDATE membresias_miembro
                SET estado_membresia = 'Inactiva'
                WHERE estado_membresia = 'Activa' AND fecha_fin < CURDATE()"
                Using comando As New MySqlCommand(query, conexion)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Public Function ObtenerDuracionPorMembresia(idMembresia As Integer) As Integer
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "
                SELECT p.duracion_dias
                FROM membresias_miembro mm
                INNER JOIN planes_membresia p ON mm.id_plan = p.id_plan
                WHERE mm.id_membresia = @idMembresia"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@idMembresia", idMembresia)
                    Return Convert.ToInt32(comando.ExecuteScalar())
                End Using

            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorDni(dni As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_membresias WHERE dni_miembro LIKE @dni"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@dni", "%" & dni & "%")
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorNombrePlan(nombrePlan As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_membresias WHERE nombre_plan LIKE @nombrePlan"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@nombrePlan", "%" & nombrePlan & "%")
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function BuscarPorEstado(estado As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_membresias WHERE estado_membresia = @estado"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@estado", estado)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
