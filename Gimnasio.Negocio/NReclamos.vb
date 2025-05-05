Imports System.Data
Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Public Class NReclamos
    Private dReclamos As New DReclamos()
    Public Function Listar() As DataTable
        Try
            Dim dvDescripcion As DataTable
            dvDescripcion = dReclamos.Listar()
            Return dvDescripcion
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

    Public Sub Eliminar(id As Integer)
        Try
            dReclamos.Eliminar(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub EstadoResuelto(id As Integer)
        Try
            dReclamos.EstadoResuelto(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub EstadoPendiente(id As Integer)
        Try
            dReclamos.EstadoPendiente(id)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function BuscarPorEstado(estado As String) As DataTable
        Try
            Dim dvEstado As DataTable = dReclamos.BuscarPorEstado(estado)
            Return dvEstado
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