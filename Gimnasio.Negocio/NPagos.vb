Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports System.Data

Public Class NPagos
    Private dPagos As New DPagos()
    Public Function Listar() As List(Of Pagos)
        Try
            Return dPagos.Listar()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(pago As Pagos)
        Try
            dPagos.Insertar(pago)

            Dim dMembresia As New DMembresias()
            Dim duracionDias As UInteger = dMembresia.ObtenerDuracionPorMembresia(pago.IdMembresia)


            Dim membresia As New Membresias()
            membresia.IdMembresia = pago.IdMembresia
            membresia.FechaInicio = DateTime.Now
            membresia.FechaFin = membresia.FechaInicio.AddDays(duracionDias)
            membresia.EstadoMembresia = "Activa"


            Dim dMembresias As New DMembresias()
            dMembresias.ActualizarEstadoYFechas(membresia)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As List(Of Pagos)
        Try
            Return dPagos.ListarPorFechas(fechaInicio, fechaFin)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorDni(dni As String) As List(Of Pagos)
        Try
            Return dPagos.ListarPorDni(dni)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorNombrePlan(nombre As String) As List(Of Pagos)
        Try
            Return dPagos.ListarPorNombrePlan(nombre)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorMetodoPago(metodo As String) As List(Of Pagos)
        Try
            Return ListarPorMetodoPago(metodo)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ListarPorMontos(montoMin As Decimal, montoMax As Decimal) As List(Of Pagos)
        Try
            If montoMin > montoMax Then
                Dim temp As Decimal = montoMin
                montoMin = montoMax
                montoMax = temp
            End If
            Return dPagos.ListarPorMontos(montoMin, montoMax)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function



End Class
