Imports Gimnasio.Entidades
Imports Gimnasio.Datos
Imports System.Data

Public Class NMembresias
    Private dMembresias As New DMembresias()

    ' Método para listar todas las membresías con datos relacionados
    Public Function Listar() As DataTable
        Try
            Return dMembresias.Listar()
        Catch ex As Exception
            Throw New Exception("Error al listar las membresías: " & ex.Message)
        End Try
    End Function

    ' Método para insertar una nueva membresía
    Public Sub Insertar(idMiembro As UInteger, idPlan As UInteger, duracion As UInteger)
        Try
            Dim membresia As New Membresias()
            membresia.FechaInicio = DateTime.Now
            membresia.FechaFin = DateTime.Now.AddDays(duracion)
            If membresia.FechaInicio >= membresia.FechaFin Then
                Throw New Exception("La fecha de inicio debe ser anterior a la fecha de fin.")
            End If
            ' Llamar al método de la capa de datos
            dMembresias.Insertar(idMiembro, idPlan, membresia)
        Catch ex As Exception
            Throw New Exception("Error al insertar la membresía: " & ex.Message)
        End Try
    End Sub

    ' Método para actualizar una membresía existente
    Public Sub Actualizar(miembro As Miembros, plan As Planes, membresia As Membresias)
        Try
            ' Validaciones básicas
            If miembro Is Nothing OrElse plan Is Nothing OrElse membresia Is Nothing Then
                Throw New Exception("Los datos de la membresía, miembro o plan no pueden estar vacíos.")
            End If

            If membresia.FechaInicio >= membresia.FechaFin Then
                Throw New Exception("La fecha de inicio debe ser anterior a la fecha de fin.")
            End If

            ' Llamar al método de la capa de datos
            dMembresias.Actualizar(miembro, plan, membresia)
        Catch ex As Exception
            Throw New Exception("Error al actualizar la membresía: " & ex.Message)
        End Try
    End Sub

    ' Método para desactivar una membresía (cambiar su estado a 'Vencida')
    Public Sub Desactivar(idMiembro As Integer, idPlan As Integer)
        Try
            ' Validaciones básicas
            If idMiembro <= 0 OrElse idPlan <= 0 Then
                Throw New Exception("El ID del miembro y el ID del plan deben ser mayores a cero.")
            End If

            ' Llamar al método de la capa de datos
            dMembresias.Desactivar(idMiembro, idPlan)
        Catch ex As Exception
            Throw New Exception("Error al desactivar la membresía: " & ex.Message)
        End Try
    End Sub
End Class

