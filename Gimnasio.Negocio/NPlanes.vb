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

    'insertar
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

    Public Sub Eliminar(id As Integer)
        Try
            dPlanes.Eliminar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Activar(id As Integer)
        Try
            dPlanes.Activar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Desactivar(id As Integer)
        Try
            dPlanes.Desactivar(id)
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
End Class
