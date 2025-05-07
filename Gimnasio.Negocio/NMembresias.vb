Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports System.Data

Public Class NMembresias
    Private dMembresias As New DMembresias()

    Public Function Listar() As DataTable
        Try
            Return dMembresias.Listar()
        Catch ex As Exception
            Throw New Exception("Error al listar las membresías: " & ex.Message)
        End Try
    End Function

    Public Sub Insertar(membresia As Membresias)
        Try
            membresia.FechaInicio = DateTime.Now
            membresia.FechaFin = DateTime.Now

            dMembresias.Insertar(membresia)
        Catch ex As Exception
            Throw New Exception("Error al insertar la membresía: " & ex.Message)
        End Try
    End Sub

    Public Function ObtenerIdMembresia(membresia As Membresias) As UInteger
        Try
            Dim idMembresia As UInteger = dMembresias.ObtenerIdMembresia(membresia)
            Return idMembresia
        Catch ex As Exception
            Throw New Exception("Error al obtener el ID de la membresía: " & ex.Message)
        End Try
    End Function


    Public Function BuscarPorDni(dni As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.BuscarPorDni(dni)
            Return dvMembresias
        Catch ex As Exception
            Throw New Exception("Error al buscar por DNI: " & ex.Message)
        End Try
    End Function

    Public Function BuscarPorNombrePlan(nombre As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.BuscarPorNombrePlan(nombre)
            Return dvMembresias
        Catch ex As Exception
            Throw New Exception("Error al buscar por plan: " & ex.Message)
        End Try
    End Function

    Public Function BuscarPorEstado(estado As String) As DataTable
        Try
            Dim dvMembresias As DataTable = dMembresias.BuscarPorEstado(estado)
            Return dvMembresias
        Catch ex As Exception
            Throw New Exception("Error al buscar por estado: " & ex.Message)
        End Try
    End Function


    Public Sub ActualizarEstadosVencidos()
        Try
            dMembresias.ActualizarEstadosVencidos()
        Catch ex As Exception
            Throw New Exception("Error al actualizar los estados de las membresías: " & ex.Message)
        End Try
    End Sub


End Class

