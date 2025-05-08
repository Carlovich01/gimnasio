Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DAsistencia
    Inherits Conexion

    Private Function MapearAsistencias(tabla As DataTable) As List(Of Asistencia)
        Dim listaAsistencias As New List(Of Asistencia)()

        For Each row As DataRow In tabla.Rows
            Dim asistencia As New Asistencia() With {
                .IdAsistencia = Convert.ToUInt64(row("id_asistencia")),
                .IdMiembro = If(IsDBNull(row("id_miembro")), Nothing, Convert.ToUInt32(row("id_miembro"))),
                .FechaHoraCheckin = Convert.ToDateTime(row("fecha_hora_checkin")),
                .Resultado = row("resultado").ToString(),
                .IdMembresiaValida = If(IsDBNull(row("id_membresia_valida")), Nothing, Convert.ToUInt32(row("id_membresia_valida")))
            }
            listaAsistencias.Add(asistencia)
        Next

        Return listaAsistencias
    End Function

    Private Function MapearAsistencia(tabla As DataTable) As Asistencia
        If tabla.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim row As DataRow = tabla.Rows(0)
        Return New Asistencia() With {
            .IdAsistencia = Convert.ToUInt64(row("id_asistencia")),
            .IdMiembro = If(IsDBNull(row("id_miembro")), Nothing, Convert.ToUInt32(row("id_miembro"))),
            .FechaHoraCheckin = Convert.ToDateTime(row("fecha_hora_checkin")),
            .Resultado = row("resultado").ToString(),
            .IdMembresiaValida = If(IsDBNull(row("id_membresia_valida")), Nothing, Convert.ToUInt32(row("id_membresia_valida")))
        }
    End Function

    Public Function Listar() As List(Of Asistencia)
        Dim query As String = "SELECT * FROM vista_asistencia"
        Dim resultado As DataTable = ExecuteQuery(query, Nothing)
        Return MapearAsistencias(resultado)
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

    Public Function ListarPorDni(dni As String) As List(Of Asistencia)
        Dim query As String = "SELECT * FROM vista_asistencia WHERE dni_miembro LIKE @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearAsistencias(resultado)
    End Function

    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As List(Of Asistencia)
        Dim query As String = "SELECT * FROM vista_asistencia WHERE fecha_ingreso BETWEEN @fechaInicio AND @fechaFin"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@fechaInicio", fechaInicio},
            {"@fechaFin", fechaFin}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearAsistencias(resultado)
    End Function
End Class

