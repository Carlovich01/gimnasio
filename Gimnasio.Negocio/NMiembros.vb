Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Public Class NMiembros
    Private dMiembros As New DMiembros()
    Public Function Listar() As DataTable
        Dim dvMiembros As DataTable
        Try
            dvMiembros = dMiembros.Listar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return dvMiembros
    End Function

    'insertar
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


    Public Sub Activar(id As Integer)
        Try
            dMiembros.Activar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Desactivar(id As Integer)
        Try
            dMiembros.Desactivar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function BuscarPorNombre(nombre As String) As DataTable
        Try
            Dim dvMiembros As DataTable = dMiembros.BuscarPorNombre(nombre)
            Return dvMiembros
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorDni(dni As String) As DataTable
        Try
            Dim dvMiembros As DataTable = dMiembros.BuscarPorDni(dni)
            Return dvMiembros
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class