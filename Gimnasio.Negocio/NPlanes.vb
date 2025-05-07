Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Public Class NPlanes
    Private dPlanes As New DPlanes()
    Public Function Listar() As DataTable
        Dim dvPlanes As DataTable
        Try
            dvPlanes = dPlanes.Listar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return dvPlanes
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

    Public Function BuscarPorNombre(nombre As String) As DataTable
        Try
            Dim dvPlanes As DataTable = dPlanes.BuscarPorNombre(nombre)
            Return dvPlanes
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorDuracion(duracion As UInteger) As DataTable
        Try
            Dim dvPlanes As DataTable = dPlanes.BuscarPorDuracion(duracion)
            Return dvPlanes
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorPrecio(precio As Decimal) As DataTable
        Try
            Dim dvPlanes As DataTable = dPlanes.BuscarPorPrecio(precio)
            Return dvPlanes
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
