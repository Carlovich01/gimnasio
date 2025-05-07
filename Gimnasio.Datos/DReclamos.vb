Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DReclamos
    Inherits ConexionBase

    Public Function Listar() As DataTable
        Dim query As String = "SELECT * FROM vista_reclamos"
        Return ExecuteQuery(query, Nothing)
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

    Public Function BuscarPorEstado(Estado As String) As DataTable
        Dim query As String = "SELECT * FROM vista_reclamos WHERE estado = @estado"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@estado", Estado}
        }
        Return ExecuteQuery(query, parameters)
    End Function
End Class
