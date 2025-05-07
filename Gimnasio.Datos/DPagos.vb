Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DPagos
    Inherits ConexionBase

    Public Function Listar() As DataTable
        Dim query As String = "SELECT * FROM vista_pagos"
        Return ExecuteQuery(query, Nothing)
    End Function

    Public Sub Insertar(pago As Pagos)
        Dim query As String = "INSERT INTO pagos (id_membresia, id_usuario_registro, monto_pagado, metodo_pago, numero_comprobante, notas) VALUES (@idmem, @idus, @mont, @met, @num, @notas)"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@idmem", pago.IdMembresia},
            {"@idus", If(pago.IdUsuarioRegistro, DBNull.Value)},
            {"@mont", pago.MontoPagado},
            {"@met", pago.MetodoPago},
            {"@num", pago.NumeroComprobante},
            {"@notas", pago.Notas}
        }
        ExecuteNonQuery(query, parameters)
    End Sub

    Public Function BuscarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Dim query As String = "SELECT * FROM vista_pagos WHERE fecha_pago BETWEEN @fechaInicio AND @fechaFin"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@fechaInicio", fechaInicio},
            {"@fechaFin", fechaFin}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorDni(dni As String) As DataTable
        Dim query As String = "SELECT * FROM vista_pagos WHERE dni_miembro LIKE @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorNombrePlan(nombre As String) As DataTable
        Dim query As String = "SELECT * FROM vista_pagos WHERE nombre_plan LIKE @nombre"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", "%" & nombre & "%"}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorMetodoPago(metodoPago As String) As DataTable
        Dim query As String = "SELECT * FROM vista_pagos WHERE metodo = @metodoPago"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@metodoPago", metodoPago}
        }
        Return ExecuteQuery(query, parameters)
    End Function

    Public Function BuscarPorMontos(montoMin As Decimal, montoMax As Decimal) As DataTable
        Dim query As String = "
            SELECT * 
            FROM vista_pagos
            WHERE monto BETWEEN @montoMin AND @montoMax"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@montoMin", montoMin},
            {"@montoMax", montoMax}
        }
        Return ExecuteQuery(query, parameters)
    End Function
End Class

