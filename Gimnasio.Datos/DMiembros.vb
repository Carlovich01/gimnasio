Imports Gimnasio.Entidades
Imports System.Data

Public Class DMiembros
    Inherits ConexionBase

    Public Function Listar() As DataTable
        Dim query As String = "SELECT * FROM miembros ORDER BY ultima_modificacion DESC"
        Return ExecuteQuery(query, Nothing)
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

    Public Function BuscarPorNombre(nombre As String) As DataTable
        Dim query As String = "SELECT * FROM miembros WHERE nombre LIKE @nombre OR apellido LIKE @apellido ORDER BY ultima_modificacion DESC"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", "%" & nombre & "%"},
            {"@apellido", "%" & nombre & "%"}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorDni(dni As String) As DataTable
        Dim query As String = "SELECT * FROM miembros WHERE dni = @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", dni}
        }
        Return ExecuteQuery(query, parameters)
    End Function
End Class
