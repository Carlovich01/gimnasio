Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports System.Data
Imports System.Security.Cryptography.X509Certificates
Public Class NAsistencia
    Private dAsistencias As New DAsistencia()


    Public Function Listar() As List(Of Asistencia)
        Try
            Return dAsistencias.Listar()
        Catch ex As Exception
            Throw New Exception("Error al listar las membresías: " & ex.Message)
        End Try
    End Function

    Public Function RegistrarIngresoPorDNI(dni As String) As String
        Try
            Dim resultado As String = "Fallido_Otro"
            Dim idMembresiaValida As UInteger? = Nothing
            Dim dmiembros As New DMiembros()
            Dim dmembrecias As New DMembresias()
            Dim miembro As Miembros = dmiembros.ObtenerPorDni(dni)
            If miembro Is Nothing Then
                resultado = "Fallido_DNI_NoEncontrado"
            Else

                Dim membresia As Membresias = dmembrecias.ObtenerPorIdMiembroMasReciente(miembro.IdMiembro)
                If membresia Is Nothing Then
                    resultado = "Fallido_No_Hay_Membresia"
                Else
                    Select Case membresia.EstadoMembresia
                        Case "Activa"
                            resultado = "Exitoso"
                        Case "Inactiva"
                            resultado = "Fallido_Membresia_Inactiva"
                    End Select
                End If

                Dim asistencia As New Asistencia() With {
                .IdMiembro = miembro.IdMiembro,
                .FechaHoraCheckin = DateTime.Now,
                .Resultado = resultado,
                .IdMembresiaValida = membresia.IdMembresia
            }
                dAsistencias.RegistrarAsistencia(asistencia)
            End If

            Return resultado
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ListarPorDNI(dni As String) As List(Of Asistencia)
        Try
            Return dAsistencias.ListarPorDni(dni)
        Catch ex As Exception
            Throw New Exception("Error al buscar por DNI: " & ex.Message)
        End Try
    End Function


    Public Function ListarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As List(Of Asistencia)
        Try
            Return dAsistencias.ListarPorFecha(fechaInicio, fechaFin)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
