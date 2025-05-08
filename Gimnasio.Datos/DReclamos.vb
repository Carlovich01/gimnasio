Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DReclamos
    Inherits Conexion

    Private Function MapearReclamos(tabla As DataTable) As List(Of Reclamos)
        Dim listaReclamos As New List(Of Reclamos)()

        For Each row As DataRow In tabla.Rows
            Dim reclamo As New Reclamos() With {
                .IdReclamos = Convert.ToInt32(row("id_reclamos")),
                .Tipo = row("tipo").ToString(),
                .Descripcion = row("descripcion").ToString(),
                .FechaEnvio = Convert.ToDateTime(row("fecha_envio")),
                .Estado = row("estado").ToString(),
                .Respuesta = If(IsDBNull(row("respuesta")), Nothing, row("respuesta").ToString()),
                .FechaRespuesta = If(IsDBNull(row("fecha_respuesta")), Nothing, Convert.ToDateTime(row("fecha_respuesta"))),
                .IdMiembro = If(IsDBNull(row("id_miembro")), Nothing, Convert.ToInt32(row("id_miembro")))
            }
            listaReclamos.Add(reclamo)
        Next

        Return listaReclamos
    End Function

    Public Function Listar() As List(Of Reclamos)
        Dim query As String = "SELECT * FROM vista_reclamos"
        Dim resultado As DataTable = ExecuteQuery(query, Nothing)
        Return MapearReclamos(resultado)
    End Function

    Public Sub Insertar(Obj As Reclamos)
        Dim query As String = "INSERT INTO reclamos (tipo, descripcion, id_miembro) VALUES (@tipo, @des, @idMiembro)"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@tipo", Obj.Tipo},
            {"@des", Obj.Descripcion},
            {"@idMiembro", If(Obj.IdMiembro.HasValue, Obj.IdMiembro, DBNull.Value)}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Actualizar(Obj As Reclamos)
        Dim query As String = "UPDATE reclamos SET tipo = @tipo, descripcion = @des, id_miembro = @idMiembro WHERE id_reclamos = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", Obj.IdReclamos},
            {"@tipo", Obj.Tipo},
            {"@des", Obj.Descripcion},
            {"@idMiembro", If(Obj.IdMiembro.HasValue, Obj.IdMiembro, DBNull.Value)}
        }
        ExecuteNonQuery(query, parameters)

    End Sub

    Public Sub Eliminar(id As Integer)
        Dim query As String = "DELETE FROM reclamos WHERE id_reclamos = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub EstadoResuelto(id As Integer)
        Dim query As String = "UPDATE reclamos SET estado = 'resuelto' WHERE id_reclamos = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub EstadoPendiente(id As Integer)
        Dim query As String = "UPDATE reclamos SET estado = 'pendiente' WHERE id_reclamos = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Respuestas(Obj As Reclamos)
        Dim query As String = "UPDATE reclamos SET respuesta = @respuesta, fecha_respuesta = @fechr WHERE id_reclamos = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@respuesta", Obj.Respuesta},
            {"@id", Obj.IdReclamos},
            {"@fechr", DateTime.Now}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Function ListarPorEstado(Estado As String) As List(Of Reclamos)
        Dim query As String = "SELECT * FROM vista_reclamos WHERE estado = @estado"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", Estado}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearReclamos(resultado)
    End Function
End Class
