Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DMembresias
    Inherits ConexionBase

    Public Function Listar() As DataTable
        ' Actualizar estados de membresías vencidas
        Dim actualizarQuery As String = "
            UPDATE membresias_miembro
            SET estado_membresia = 'Inactiva'
            WHERE estado_membresia = 'Activa' AND fecha_fin < CURDATE()"
        ExecuteNonQuery(actualizarQuery, Nothing)

        ' Listar todas las membresías
        Dim query As String = "SELECT * FROM vista_membresias"
        Return ExecuteQuery(query, Nothing)
    End Function

    Public Sub Insertar(membresia As Membresias)
        ' Verificar si ya existe una membresía activa o pendiente de pago
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

        ' Insertar nueva membresía
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

    Public Function BuscarPorDni(dni As String) As DataTable
        Dim query As String = "SELECT * FROM vista_membresias WHERE dni_miembro LIKE @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorNombrePlan(nombrePlan As String) As DataTable
        Dim query As String = "SELECT * FROM vista_membresias WHERE nombre_plan LIKE @nombrePlan"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombrePlan", "%" & nombrePlan & "%"}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorEstado(estado As String) As DataTable
        Dim query As String = "SELECT * FROM vista_membresias WHERE estado_membresia = @estado"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", estado}
        }
        Return ExecuteQuery(query, parameters)
    End Function
End Class
