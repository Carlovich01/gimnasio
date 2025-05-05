Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports System.Data
Imports System.Security.Cryptography.X509Certificates
Public Class NAsistencia
    Private dAsistencias As New DAsistencia()


    Public Function Listar() As DataTable
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

            Dim miembroTabla As DataTable = dAsistencias.ObtenerMiembroPorDNI(dni)
            If miembroTabla.Rows.Count = 0 Then
                resultado = "Fallido_DNI_NoEncontrado"
            Else
                Dim idMiembro As UInteger = miembroTabla.Rows(0)("id_miembro")

                Dim membresiaTabla As DataTable = dAsistencias.ValidarEstadoMembresia(idMiembro)
                If membresiaTabla.Rows.Count = 0 Then
                    resultado = "Fallido_No_Hay_Membresia"
                Else
                    Dim estadoMembresia As String = membresiaTabla.Rows(0)("estado_membresia").ToString()
                    Select Case estadoMembresia
                        Case "Activa"
                            resultado = "Exitoso"
                            idMembresiaValida = membresiaTabla.Rows(0)("id_membresia")
                        Case "Inactiva"
                            resultado = "Fallido_Membresia_Inactiva"
                    End Select
                End If

                Dim asistencia As New Asistencia() With {
                .IdMiembro = idMiembro,
                .FechaHoraCheckin = DateTime.Now,
                .Resultado = resultado,
                .IdMembresiaValida = idMembresiaValida
            }
                dAsistencias.RegistrarAsistencia(asistencia)
            End If

            Return resultado
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BuscarPorDNI(dni As String) As DataTable
        Try
            Dim dt As DataTable = dAsistencias.BuscarPorDNI(dni)
            Return dt
        Catch ex As Exception
            Throw New Exception("Error al buscar por DNI: " & ex.Message)
        End Try
    End Function


    Public Function BuscarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Dim dvPagos As DataTable
            dvPagos = dAsistencias.BuscarPorFecha(fechaInicio, fechaFin)
            Return dvPagos
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
