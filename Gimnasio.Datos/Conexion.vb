' Proyecto: Datos
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class ConexionBase
    Private connectionString As String = "Server=localhost; Port=3307; Database=goatym2; Uid=root; Pwd=1234;"

    ' Método genérico para ejecutar consultas SELECT y devolver un DataTable
    Public Function ExecuteQuery(query As String, parameters As Dictionary(Of String, Object)) As DataTable
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Using comando As New MySqlCommand(query, conexion)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            comando.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If
                    Dim adapter As New MySqlDataAdapter(comando)
                    Dim tabla As New DataTable()
                    adapter.Fill(tabla)
                    Return tabla
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ' Método genérico para ejecutar comandos INSERT, UPDATE, DELETE
    Public Sub ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object))
        Try
            Using conexion As New MySqlConnection(connectionString)
                conexion.Open()
                Using comando As New MySqlCommand(query, conexion)
                    If parameters IsNot Nothing Then
                        For Each param In parameters
                            comando.Parameters.AddWithValue(param.Key, param.Value)
                        Next
                    End If
                    comando.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
