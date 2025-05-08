Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DPlanes
    Inherits Conexion

    Private Function MapearPlanes(tabla As DataTable) As List(Of Planes)
        Dim listaPlanes As New List(Of Planes)()
        For Each row As DataRow In tabla.Rows
            Dim plan As New Planes() With {
                .IdPlan = Convert.ToUInt32(row("id_plan")),
                .NombrePlan = row("nombre_plan").ToString(),
                .Descripcion = row("descripcion").ToString(),
                .DuracionDias = Convert.ToUInt32(row("duracion_dias")),
                .Precio = Convert.ToDecimal(row("precio")),
                .FechaCreacion = Convert.ToDateTime(row("fecha_creacion")),
                .UltimaModificacion = Convert.ToDateTime(row("ultima_modificacion"))
            }
            listaPlanes.Add(plan)
        Next
        Return listaPlanes
    End Function
    Public Function Listar() As List(Of Planes)
        Dim query As String = "SELECT * FROM planes_membresia ORDER BY ultima_modificacion DESC"
        Dim resultado As DataTable = ExecuteQuery(query, Nothing)
        Return MapearPlanes(resultado)
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

    Public Function ListarPorNombre(nombre As String) As List(Of Planes)
        Dim query As String = "SELECT * FROM planes_membresia WHERE nombre_plan LIKE @nombre ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", "%" & nombre & "%"}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearPlanes(resultado)
    End Function

    Public Function ListarPorDuracion(duracion As Integer) As List(Of Planes)
        Dim query As String = "SELECT * FROM planes_membresia WHERE duracion_dias = @duracion ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@duracion", duracion}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearPlanes(resultado)
    End Function

    Public Function ListarPorPrecio(precio As Decimal) As List(Of Planes)
        Dim query As String = "SELECT * FROM planes_membresia WHERE precio = @precio ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@precio", precio}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearPlanes(resultado)
    End Function
End Class
