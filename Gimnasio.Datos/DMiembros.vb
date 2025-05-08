Imports Gimnasio.Entidades
Imports System.Data

Public Class DMiembros
    Inherits Conexion
    Private Function MapearMiembros(tabla As DataTable) As List(Of Miembros)
        Dim listaMiembros As New List(Of Miembros)()

        For Each row As DataRow In tabla.Rows
            Dim miembro As New Miembros() With {
                .IdMiembro = Convert.ToUInt32(row("id_miembro")),
                .Dni = row("dni").ToString(),
                .Nombre = row("nombre").ToString(),
                .Apellido = row("apellido").ToString(),
                .Genero = If(IsDBNull(row("genero")), Nothing, row("genero").ToString()),
                .Telefono = If(IsDBNull(row("telefono")), Nothing, row("telefono").ToString()),
                .Email = If(IsDBNull(row("email")), Nothing, row("email").ToString()),
                .FechaRegistro = Convert.ToDateTime(row("fecha_registro")),
                .UltimaModificacion = Convert.ToDateTime(row("ultima_modificacion"))
            }
            listaMiembros.Add(miembro)
        Next

        Return listaMiembros
    End Function

    Private Function MapearMiembro(tabla As DataTable) As Miembros
        If tabla.Rows.Count = 0 Then
            Return Nothing
        End If

        Dim row As DataRow = tabla.Rows(0)
        Return New Miembros() With {
        .IdMiembro = Convert.ToUInt32(row("id_miembro")),
                .Dni = row("dni").ToString(),
                .Nombre = row("nombre").ToString(),
                .Apellido = row("apellido").ToString(),
                .Genero = If(IsDBNull(row("genero")), Nothing, row("genero").ToString()),
                .Telefono = If(IsDBNull(row("telefono")), Nothing, row("telefono").ToString()),
                .Email = If(IsDBNull(row("email")), Nothing, row("email").ToString()),
                .FechaRegistro = Convert.ToDateTime(row("fecha_registro")),
                .UltimaModificacion = Convert.ToDateTime(row("ultima_modificacion"))
        }
    End Function

    Public Function Listar() As List(Of Miembros)
        Dim query As String = "SELECT * FROM miembros ORDER BY ultima_modificacion DESC"
        Dim resultado As DataTable = ExecuteQuery(query, Nothing)
        Return MapearMiembros(resultado)
    End Function

    Public Sub Insertar(Obj As Miembros)
        Dim query As String = "INSERT INTO miembros (dni, nombre, apellido, genero, telefono, email) VALUES (@dni, @nom, @ape, @gen, @tel, @ema)"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", Obj.Dni},
            {"@nom", Obj.Nombre},
            {"@ape", Obj.Apellido},
            {"@gen", Obj.Genero},
            {"@tel", Obj.Telefono},
            {"@ema", Obj.Email}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Actualizar(Obj As Miembros)
        Dim query As String = "UPDATE miembros SET dni = @dni, nombre = @nom, apellido = @ape, genero = @gen, telefono = @tel, email = @ema WHERE id_miembro = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", Obj.Dni},
            {"@nom", Obj.Nombre},
            {"@ape", Obj.Apellido},
            {"@gen", Obj.Genero},
            {"@tel", Obj.Telefono},
            {"@ema", Obj.Email},
            {"@id", Obj.IdMiembro}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Sub Eliminar(id As Integer)
        Dim query As String = "DELETE FROM miembros WHERE id_miembro = @id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@id", id}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Function ListarPorNombre(nombre As String) As List(Of Miembros)
        Dim query As String = "SELECT * FROM miembros WHERE nombre LIKE @nombre OR apellido LIKE @apellido ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", "%" & nombre & "%"},
            {"@apellido", "%" & nombre & "%"}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearMiembros(resultado)
    End Function

    Public Function ObtenerPorDni(dni As String) As Miembros
        Dim query As String = "SELECT * FROM miembros WHERE dni = @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearMiembro(resultado)
    End Function

    Public Function ListarPorDni(dni As String) As List(Of Miembros)
        Dim query As String = "SELECT * FROM miembros WHERE dni LIKE @dni ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearMiembros(resultado)
    End Function

End Class
