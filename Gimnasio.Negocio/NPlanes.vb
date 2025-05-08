Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Public Class NPlanes
    Private dPlanes As New DPlanes()
    Public Function Listar() As List(Of Planes)
        Try
            Return dPlanes.Listar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Planes)
        Try
            dPlanes.Insertar(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Planes)
        Try
            dPlanes.Actualizar(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            dPlanes.Eliminar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorNombre(nombre As String) As List(Of Planes)
        Try
            Return dPlanes.ListarPorNombre(nombre)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorDuracion(duracion As UInteger) As List(Of Planes)
        Try
            Return dPlanes.ListarPorDuracion(duracion)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorPrecio(precio As Decimal) As List(Of Planes)
        Try
            Return dPlanes.ListarPorPrecio(precio)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
