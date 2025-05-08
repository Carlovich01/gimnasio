Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Public Class NMiembros
    Private dMiembros As New DMiembros()
    Public Function Listar() As List(Of Miembros)
        Try
            Return dMiembros.Listar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Miembros)
        Try
            dMiembros.Insertar(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Miembros)
        Try
            dMiembros.Actualizar(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            dMiembros.Eliminar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorNombre(nombre As String) As List(Of Miembros)
        Try
            Return dMiembros.ListarPorNombre(nombre)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ObtenerPorDni(dni As String) As Miembros
        Try
            Return dMiembros.ObtenerPorDni(dni)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorDni(dni As String) As List(Of Miembros)
        Try
            Return dMiembros.ListarPorDni(dni)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class