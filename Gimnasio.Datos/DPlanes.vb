Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DPlanes
    Inherits ConexionBase

    Public Function Listar() As DataTable
        Dim query As String = "SELECT * FROM planes_membresia ORDER BY ultima_modificacion DESC"
        Return ExecuteQuery(query, Nothing)
    End Function

    Public Sub Insertar(Obj As Planes)
        Dim query As String = "INSERT INTO planes_membresia (nombre_plan, descripcion, duracion_dias, precio) VALUES (@nom, @des, @dur, @pre)"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nom", Obj.NombrePlan},
            {"@des", Obj.Descripcion},
            {"@dur", Obj.DuracionDias},
            {"@pre", Obj.Precio}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Actualizar(Obj As Planes)
        Dim query As String = "UPDATE planes_membresia SET nombre_plan = @nom, descripcion = @des, duracion_dias = @dur, precio = @pre WHERE id_plan = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", Obj.IdPlan},
            {"@nom", Obj.NombrePlan},
            {"@des", Obj.Descripcion},
            {"@dur", Obj.DuracionDias},
            {"@pre", Obj.Precio}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Eliminar(id As Integer)
        Dim query As String = "DELETE FROM planes_membresia WHERE id_plan = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Function BuscarPorNombre(nombre As String) As DataTable
        Dim query As String = "SELECT * FROM planes_membresia WHERE nombre_plan LIKE @nombre ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", "%" & nombre & "%"}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorDuracion(duracion As Integer) As DataTable
        Dim query As String = "SELECT * FROM planes_membresia WHERE duracion_dias = @duracion ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@duracion", duracion}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorPrecio(precio As Decimal) As DataTable
        Dim query As String = "SELECT * FROM planes_membresia WHERE precio = @precio ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@precio", precio}
        }
        Return ExecuteQuery(query, parameters)
    End Function
End Class
