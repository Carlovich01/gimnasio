Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DAsistencia
    Inherits ConexionBase
    Public Function Listar() As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_asistencia"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception("Error al listar las asistencias: " & ex.Message)
        End Try
    End Function

    Public Function ObtenerMiembroPorDNI(dni As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM miembros WHERE dni = @dni"

                Dim cmd As New MySqlCommand(query, conexion)
                cmd.Parameters.AddWithValue("@dni", dni)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarEstadoMembresia(idMiembro As UInteger) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM membresias_miembro WHERE id_miembro = @idMiembro ORDER BY fecha_fin DESC LIMIT 1"
                Dim cmd As New MySqlCommand(query, conexion)
                cmd.Parameters.AddWithValue("@idMiembro", idMiembro)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub RegistrarAsistencia(asistencia As Asistencia)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "INSERT INTO asistencia (id_miembro, fecha_hora_checkin, resultado, id_membresia_valida) VALUES (@idMiembro, @fechaHoraCheckin, @resultado, @idMembresiaValida)"
                Dim cmd As New MySqlCommand(query, conexion)
                cmd.Parameters.AddWithValue("@idMiembro", asistencia.IdMiembro)
                cmd.Parameters.AddWithValue("@fechaHoraCheckin", asistencia.FechaHoraCheckin)
                cmd.Parameters.AddWithValue("@resultado", asistencia.Resultado)
                cmd.Parameters.AddWithValue("@idMembresiaValida", If(asistencia.IdMembresiaValida.HasValue, asistencia.IdMembresiaValida, DBNull.Value))
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function BuscarPorDNI(dni As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "SELECT * FROM vista_asistencia WHERE dni_miembro LIKE @dni"
                Dim cmd As New MySqlCommand(query, conexion)
                cmd.Parameters.AddWithValue("@dni", "%" & dni & "%")
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function BuscarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_asistencia WHERE fecha_ingreso BETWEEN @fechaInicio AND @fechaFin"

                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@fechaInicio", fechaInicio)
                adapter.SelectCommand.Parameters.AddWithValue("@fechaFin", fechaFin)

                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class

