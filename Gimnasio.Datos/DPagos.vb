Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades

Public Class DPagos
    Inherits Conexion

    Private Function MapearPagos(tabla As DataTable) As List(Of Pagos)
        Dim listaPagos As New List(Of Pagos)()

        For Each row As DataRow In tabla.Rows
            Dim pago As New Pagos() With {
                .IdPago = Convert.ToUInt32(row("id_pago")),
                .IdMembresia = Convert.ToUInt32(row("id_membresia")),
                .IdUsuarioRegistro = If(IsDBNull(row("id_usuario_registro")), Nothing, Convert.ToUInt32(row("id_usuario_registro"))),
                .FechaPago = Convert.ToDateTime(row("fecha_pago")),
                .MontoPagado = Convert.ToDecimal(row("monto")),
                .MetodoPago = row("metodo").ToString(),
                .NumeroComprobante = If(IsDBNull(row("comprobante")), Nothing, row("comprobante").ToString()),
                .Notas = If(IsDBNull(row("notas")), Nothing, row("notas").ToString())
            }
            listaPagos.Add(pago)
        Next

        Return listaPagos
    End Function

    Public Function Listar() As List(Of Pagos)
        Dim query As String = "SELECT * FROM vista_pagos"
        Dim resultado As DataTable = ExecuteQuery(query, Nothing)
        Return MapearPagos(resultado)
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
    Public Function ListarPorFechas(fechaInicio As DateTime, fechaFin As DateTime) As List(Of Pagos)
        Dim query As String = "SELECT * FROM vista_pagos WHERE fecha_pago BETWEEN @fechaInicio AND @fechaFin"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@fechaInicio", fechaInicio},
            {"@fechaFin", fechaFin}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearPagos(resultado)
    End Function

    Public Function ListarPorDni(dni As String) As List(Of Pagos)
        Dim query As String = "SELECT * FROM vista_pagos WHERE dni_miembro LIKE @dni"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@dni", "%" & dni & "%"}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearPagos(resultado)
    End Function

    Public Function ListarPorNombrePlan(nombre As String) As List(Of Pagos)
        Dim query As String = "SELECT * FROM vista_pagos WHERE nombre_plan LIKE @nombre"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nombre", "%" & nombre & "%"}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearPagos(resultado)
    End Function

    Public Function ListarPorMetodoPago(metodoPago As String) As List(Of Pagos)
        Dim query As String = "SELECT * FROM vista_pagos WHERE metodo = @metodoPago"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@metodoPago", metodoPago}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearPagos(resultado)
    End Function

    Public Function ListarPorMontos(montoMin As Decimal, montoMax As Decimal) As List(Of Pagos)
        Dim query As String = "
            SELECT * 
            FROM vista_pagos
            WHERE monto BETWEEN @montoMin AND @montoMax"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@montoMin", montoMin},
            {"@montoMax", montoMax}
        }
        Dim resultado As DataTable = ExecuteQuery(query, parameters)
        Return MapearPagos(resultado)
    End Function
End Class

