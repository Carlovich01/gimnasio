Imports MySql.Data.MySqlClient
Imports System.Data
Imports Gimnasio.Entidades
Imports Mysqlx.XDevAPI.Relational
Public Class DPagos
    Inherits ConexionBase
    Public Function Listar() As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_pagos"

                Dim adapter As New MySqlDataAdapter(query, conexion)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub Insertar(pago As Pagos)
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Dim query As String = "INSERT INTO pagos (id_membresia, id_usuario_registro, monto_pagado, metodo_pago, numero_comprobante, notas) VALUES (@idmem, @idus, @mont, @met, @num, @notas)"
                Using comando As New MySqlCommand(query, conexion)
                    comando.Parameters.AddWithValue("@idmem", pago.IdMembresia)
                    comando.Parameters.AddWithValue("@idus", If(pago.IdUsuarioRegistro, DBNull.Value))
                    comando.Parameters.AddWithValue("@mont", pago.MontoPagado)
                    comando.Parameters.AddWithValue("@met", pago.MetodoPago)
                    comando.Parameters.AddWithValue("@num", pago.NumeroComprobante)
                    comando.Parameters.AddWithValue("@notas", pago.Notas)
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Function BuscarPorFecha(fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_pagos WHERE fecha_pago BETWEEN @fechaInicio AND @fechaFin"

                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@fechaInicio", fechaInicio)
                adapter.SelectCommand.Parameters.AddWithValue("@fechaFin", fechaFin)

                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorDni(dni As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_pagos WHERE dni_miembro LIKE @dni"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@dni", "%" & dni & "%")
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function BuscarPorNombrePlan(nombre As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_pagos WHERE nombre_plan LIKE @nombre"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@nombre", "%" & nombre & "%")
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorMetodoPago(metodoPago As String) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "SELECT * FROM vista_pagos WHERE metodo = @metodoPago"
                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@metodoPago", metodoPago)
                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BuscarPorMontos(montoMin As Decimal, montoMax As Decimal) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                Dim query As String = "
            SELECT * 
            FROM vista_pagos
            WHERE monto BETWEEN @montoMin AND @montoMax"

                Dim adapter As New MySqlDataAdapter(query, conexion)
                adapter.SelectCommand.Parameters.AddWithValue("@montoMin", montoMin)
                adapter.SelectCommand.Parameters.AddWithValue("@montoMax", montoMax)

                Dim tabla As New DataTable()
                adapter.Fill(tabla)
                Return tabla
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class

