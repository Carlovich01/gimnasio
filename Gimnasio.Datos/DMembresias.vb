Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DMembresias
    Inherits Conexion
    Private Function MapearMembresias(tabla As DataTable) As List(Of Membresias)
        Dim listaMembresias As New List(Of Membresias)()

        For Each row As DataRow In tabla.Rows
            Dim membresia As New Membresias() With {
                .IdMembresia = Convert.ToUInt32(row("id_membresia")),
                .IdMiembro = Convert.ToUInt32(row("id_miembro")),
                .IdPlan = Convert.ToUInt32(row("id_plan")),
                .FechaInicio = Convert.ToDateTime(row("fecha_inicio")),
                .FechaFin = Convert.ToDateTime(row("fecha_fin")),
                .EstadoMembresia = row("estado_membresia").ToString(),
                .FechaRegistro = Convert.ToDateTime(row("fecha_registro")),
                .UltimaModificacion = Convert.ToDateTime(row("ultima_modificacion"))
            }
            listaMembresias.Add(membresia)
        Next

        Return listaMembresias
    End Function

    Private Function MapearMembresia(tabla As DataTable) As Membresias
        If tabla.Rows.Count = 0 Then
            Return Nothing
        End If
        Dim row As DataRow = tabla.Rows(0)

        Return New Membresias() With {
                .IdMembresia = Convert.ToUInt32(row("id_membresia")),
                .IdMiembro = Convert.ToUInt32(row("id_miembro")),
                .IdPlan = Convert.ToUInt32(row("id_plan")),
                .FechaInicio = Convert.ToDateTime(row("fecha_inicio")),
                .FechaFin = Convert.ToDateTime(row("fecha_fin")),
                .EstadoMembresia = row("estado_membresia").ToString(),
                .FechaRegistro = Convert.ToDateTime(row("fecha_registro")),
                .UltimaModificacion = Convert.ToDateTime(row("ultima_modificacion"))
            }
    End Function
    Public Function Listar() As List(Of Membresias)
        Dim actualizarQuery As String = "
            UPDATE membresias_miembro
            SET estado_membresia = 'Inactiva'
            WHERE estado_membresia = 'Activa' AND fecha_fin < CURDATE()"
        ExecuteNonQuery(actualizarQuery, Nothing)

        Dim query As String = "SELECT * FROM vista_membresias"
        Dim resultado As DataTable = ExecuteQuery(query, Nothing)
        Return MapearMembresias(resultado)
    End Function

    Public Sub Insertar(membresia As Membresias)
        Dim verificarQuery As String = "
            SELECT COUNT(*) 
            FROM membresias_miembro 
            WHERE id_miembro = @idMiembro 
              AND id_plan = @idPlan"
        Dim verificarParams As New Dictionary(Of String, Object) From {
            {"@idMiembro", membresia.IdMiembro},
            {"@idPlan", membresia.IdPlan}
        }
        Dim existe As Integer = Convert.ToInt32(ExecuteQuery(verificarQuery, verificarParams).Rows(0)(0))

        If existe > 0 Then
            Throw New Exception("El usuario ya tiene una membresía activa o pendiente de pago para este plan.")
        End If

        Dim query As String = "INSERT INTO membresias_miembro (id_miembro, id_plan, fecha_inicio, fecha_fin) VALUES (@idmi, @idpla, @in, @fin)"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@idmi", membresia.IdMiembro},
            {"@idpla", membresia.IdPlan},
            {"@in", membresia.FechaInicio},
            {"@fin", membresia.FechaFin}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Function ObtenerIdMembresia(membresia As Membresias) As Integer
        Dim query As String = "SELECT id_membresia FROM membresias_miembro WHERE id_miembro = @idmi AND id_plan = @idpla"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@idmi", membresia.IdMiembro},
            {"@idpla", membresia.IdPlan}
        }
        Dim resultado = ExecuteQuery(query, parameters)
        Return If(resultado.Rows.Count > 0, Convert.ToInt32(resultado.Rows(0)("id_membresia")), 0)
    End Function

    Public Function ObtenerPorIdMiembroMasReciente(idMiembro As UInteger) As Membresias
        Dim query As String = "SELECT * FROM membresias_miembro WHERE id_miembro = @idMiembro ORDER BY fecha_hora_checkin DESC LIMIT 1"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMiembro", idMiembro}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearMembresia(resultado)
    End Function

    Public Sub ActualizarEstadoYFechas(membresia As Membresias)
        Dim query As String = "
            UPDATE membresias_miembro
            SET estado_membresia = @estado, fecha_inicio = @fechaInicio, fecha_fin = @fechaFin
            WHERE id_membresia = @idMembresia"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", membresia.EstadoMembresia},
            {"@fechaInicio", membresia.FechaInicio},
            {"@fechaFin", membresia.FechaFin},
            {"@idMembresia", membresia.IdMembresia}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub ActualizarEstadosVencidos()
        Dim query As String = "
            UPDATE membresias_miembro
            SET estado_membresia = 'Inactiva'
            WHERE estado_membresia = 'Activa' AND fecha_fin < CURDATE()"
        ExecuteNonQuery(query, Nothing)
    End Sub

    Public Function ObtenerDuracionPorMembresia(idMembresia As Integer) As Integer
        Dim query As String = "
            SELECT p.duracion_dias
            FROM membresias_miembro mm
            INNER JOIN planes_membresia p ON mm.id_plan = p.id_plan
            WHERE mm.id_membresia = @idMembresia"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@idMembresia", idMembresia}
        }
        Dim resultado = ExecuteQuery(query, parameters)
        Return If(resultado.Rows.Count > 0, Convert.ToInt32(resultado.Rows(0)("duracion_dias")), 0)
    End Function

    Public Function ListarPorDni(dni As String) As List(Of Membresias)
        Dim query As String = "SELECT * FROM vista_membresias WHERE dni_miembro LIKE @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearMembresias(resultado)
    End Function

    Public Function ListarPorNombrePlan(nombrePlan As String) As List(Of Membresias)
        Dim query As String = "SELECT * FROM vista_membresias WHERE nombre_plan LIKE @nombrePlan"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombrePlan", "%" & nombrePlan & "%"}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearMembresias(resultado)
    End Function

    Public Function ListarPorEstado(estado As String) As List(Of Membresias)
        Dim query As String = "SELECT * FROM vista_membresias WHERE estado_membresia = @estado"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", estado}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearMembresias(resultado)
    End Function


End Class
