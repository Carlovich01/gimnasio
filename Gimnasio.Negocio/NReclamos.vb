Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Public Class NReclamos
    Private dReclamos As New DReclamos()
    Public Function Listar() As List(Of Reclamos)
        Try
            Return dReclamos.Listar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(Obj As Reclamos)
        Try
            dReclamos.Insertar(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Actualizar(Obj As Reclamos)
        Try
            dReclamos.Actualizar(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub Eliminar(id As UInteger)
        Try
            dReclamos.Eliminar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub EstadoResuelto(id As UInteger)
        Try
            dReclamos.EstadoResuelto(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub EstadoPendiente(id As UInteger)
        Try
            dReclamos.EstadoPendiente(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorEstado(estado As String) As List(Of Reclamos)
        Try
            Return dReclamos.ListarPorEstado(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Respuestas(Obj As Reclamos)
        Try
            dReclamos.Respuestas(Obj)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class