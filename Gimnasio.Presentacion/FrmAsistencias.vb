Imports System.Net
Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmAsistencias
    Private nAsistencias As New NAsistencia()

    Private Sub FrmAsistencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgvListado.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub tbDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDNI.KeyPress
        Try
            dgvListado.Visible = False
            If e.KeyChar = ChrW(Keys.Enter) Then
                Dim dni As String = tbDNI.Text.Trim()
                Dim resultado As String = nAsistencias.RegistrarIngresoPorDNI(dni)
                Select Case resultado
                    Case "Exitoso", "Fallido_Membresia_Inactiva"
                        dgvListado.Visible = True

                        Dim nMembresias As New NMembresias()
                        Dim membresias As List(Of Membresias) = nMembresias.ListarPorDni(dni)

                        If membresias.Count = 0 Then
                            labelResultado.Text = "No se encontraron membresías asociadas al DNI."
                            Return
                        End If
                        Dim nmiembro As New NMiembros()
                        Dim nombreMiembro As String = nmiembro.ObtenerPorDni(dni).Nombre

                        labelResultado.Text = If(resultado = "Exitoso",
                                             $"¡Ingreso Exitoso. Bienvenido {nombreMiembro}! El estado de sus planes actualmente es:",
                                             $"Ingreso Erróneo. Posee membresía/s vencidas: {nombreMiembro}. El estado de sus planes actualmente es:")

                        ' Agregar columna de días restantes
                        For Each membresia In membresias
                            Dim diasRestantes As UInteger = If((membresia.FechaFin - DateTime.Now).Days > 0, (membresia.FechaFin - DateTime.Now).Days, 0)
                            membresia.DiasRestantes = diasRestantes
                        Next

                        ' Configurar DataGridView
                        dgvListado.DataSource = membresias
                        dgvListado.DefaultCellStyle.ForeColor = Color.Black
                        dgvListado.DefaultCellStyle.BackColor = Color.White
                        dgvListado.Columns("IdMembresia").Visible = False
                        dgvListado.Columns("IdMiembro").Visible = False
                        dgvListado.Columns("IdPlan").Visible = False
                        dgvListado.Columns("DniMiembro").HeaderText = "DNI"
                        dgvListado.Columns("ApellidoMiembro").HeaderText = "APELLIDO"
                        dgvListado.Columns("NombreMiembro").HeaderText = "NOMBRE"
                        dgvListado.Columns("NombrePlan").HeaderText = "PLAN"
                        dgvListado.Columns("PrecioPlan").Visible = False
                        dgvListado.Columns("DuracionDiasPlan").HeaderText = "DURACION"
                        dgvListado.Columns("FechaInicio").HeaderText = "FECHA INICIO"
                        dgvListado.Columns("FechaFin").HeaderText = "FECHA FIN"
                        dgvListado.Columns("EstadoMembresia").HeaderText = "ESTADO"
                        dgvListado.Columns("FechaRegistro").Visible = False
                        dgvListado.Columns("UltimaModificacion").Visible = False
                        dgvListado.Columns("DiasRestantes").HeaderText = "DIAS RESTANTES"

                        tbDNI.Text = ""

                    Case "Fallido_DNI_NoEncontrado"
                        labelResultado.Text = "DNI no encontrado. Ingrese nuevamente."
                        tbDNI.Text = ""
                    Case "Fallido_No_Hay_Membresia"
                        labelResultado.Text = "No posee membresías. Inscríbase a algún plan."
                        tbDNI.Text = ""
                    Case Else
                        MessageBox.Show("Error desconocido. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
