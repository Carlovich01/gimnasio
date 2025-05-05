Imports Gimnasio.Datos
Imports Gimnasio.Entidades
Imports System.Data

Public Class NPagos
    Private dPagos As New DPagos()
    Public Function Listar() As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dPagos.Listar()
            Return dvPagos
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(pago As Pagos)
        Try
            dPagos.Insertar(pago)

            Dim dMembresia As New DMembresias()
            Dim duracionDias As Integer = dMembresia.ObtenerDuracionPorMembresia(pago.IdMembresia)


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

    Public Function BuscarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dPagos.BuscarPorFecha(fechaInicio, fechaFin)
            Return dvPagos
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorDni(dni As String) As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dPagos.BuscarPorDni(dni)
            Return dvPagos
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorNombrePlan(nombre As String) As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dPagos.BuscarPorNombrePlan(nombre)
            Return dvPagos
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorMetodoPago(metodo As String) As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dPagos.BuscarPorMetodoPago(metodo)
            Return dvPagos
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorMontos(montoMin As Decimal, montoMax As Decimal) As DataTable
        Try
            If montoMin > montoMax Then
                Dim temp As Decimal = montoMin
                montoMin = montoMax
                montoMax = temp
            End If
            Return dPagos.BuscarPorMontos(montoMin, montoMax)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function



End Class
