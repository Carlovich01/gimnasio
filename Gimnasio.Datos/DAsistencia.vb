Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DAsistencia
    Inherits ConexionBase

    Public Function Listar() As DataTable
        Dim query As String = "SELECT * FROM vista_asistencia"
        Return ExecuteQuery(query, Nothing)
    End Function

    Public Function ObtenerMiembroPorDNI(dni As String) As DataTable
        Dim query As String = "SELECT * FROM miembros WHERE dni = @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function ValidarEstadoMembresia(idMiembro As UInteger) As DataTable
        Dim query As String = "SELECT * FROM membresias_miembro WHERE id_miembro = @idMiembro ORDER BY fecha_fin DESC LIMIT 1"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMiembro", idMiembro}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Sub RegistrarAsistencia(asistencia As Asistencia)
        Dim query As String = "INSERT INTO asistencia (id_miembro, fecha_hora_checkin, resultado, id_membresia_valida) VALUES (@idMiembro, @fechaHoraCheckin, @resultado, @idMembresiaValida)"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMiembro", asistencia.IdMiembro},
            {"@fechaHoraCheckin", asistencia.FechaHoraCheckin},
            {"@resultado", asistencia.Resultado},
            {"@idMembresiaValida", If(asistencia.IdMembresiaValida.HasValue, asistencia.IdMembresiaValida, DBNull.Value)}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Function BuscarPorDNI(dni As String) As DataTable
        Dim query As String = "SELECT * FROM vista_asistencia WHERE dni_miembro LIKE @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Dim query As String = "SELECT * FROM vista_asistencia WHERE fecha_ingreso BETWEEN @fechaInicio AND @fechaFin"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@fechaInicio", fechaInicio},
            {"@fechaFin", fechaFin}
        }
        Return ExecuteQuery(query, parameters)
    End Function
End Class

