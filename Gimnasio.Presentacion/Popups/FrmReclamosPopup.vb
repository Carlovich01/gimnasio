Imports Gimnasio.Entidades
Imports Gimnasio.Negocio

Public Class FrmReclamosPopup
    Private frmPrincipal As FrmReclamos
    Private esNuevo As Boolean
    Private reclamoPorActualizar As Reclamos
    Public Sub New(reclamoPorActualizar As Reclamos)
        InitializeComponent()
        Me.reclamoPorActualizar = reclamoPorActualizar
        TbRespuesta.Visible = True
    End Sub
    Public Sub New(Nuevo As Boolean, frm As FrmReclamos)
        InitializeComponent()
        esNuevo = Nuevo
        frmPrincipal = frm

    End Sub
    Public Sub New(Nuevo As Boolean, frm As FrmReclamos, ReclamoActualizado As Reclamos)
        InitializeComponent()
        esNuevo = Nuevo
        frmPrincipal = frm
        reclamoPorActualizar = ReclamoActualizado
        cbTipo.Text = ReclamoActualizado.Tipo
        tbDescripcion.Text = ReclamoActualizado.Descripcion
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If TbRespuesta.Visible = True Then
                If String.IsNullOrEmpty(TbRespuesta.Text.ToString) Then
                    MsgBox("Por favor, complete la respuesta.", MsgBoxStyle.Exclamation, "Aviso")
                Else

                    reclamoPorActualizar.Respuesta = TbRespuesta.Text.ToString
                    Dim nreclamos As New NReclamos()
                    nreclamos.Respuestas(reclamoPorActualizar)
                    Me.Close()
                End If
            ElseIf esNuevo Then
                Try
                    Dim nuevoReclamo As New Reclamos()
                    If String.IsNullOrWhiteSpace(cbTipo.Text) OrElse String.IsNullOrWhiteSpace(tbDescripcion.Text) Then
                        MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                        Return
                    End If
                    nuevoReclamo.Tipo = cbTipo.Text
                    nuevoReclamo.Descripcion = tbDescripcion.Text
                    Dim nmiembro As New NMiembros()
                    Dim tmiembro As DataTable = nmiembro.BuscarPorDni(tbDNI.Text)

                    If tmiembro.Rows.Count > 0 Then
                        nuevoReclamo.IdMiembro = Convert.ToInt32(tmiembro.Rows(0)("id_miembro"))
                    ElseIf tbDNI.Text.ToString IsNot "" Then
                        MsgBox("El DNI no ha sido encontrado.", MsgBoxStyle.Exclamation, "Aviso")
                    End If
                    frmPrincipal.Insertar(nuevoReclamo)
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Error al guardar el reclamo: " & ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            Else
                Try
                    Dim nuevoReclamo As New Reclamos()
                    If String.IsNullOrWhiteSpace(cbTipo.Text) OrElse String.IsNullOrWhiteSpace(tbDescripcion.Text) Then
                        MsgBox("Por favor, complete los campos obligatorios (*).", MsgBoxStyle.Exclamation, "Aviso")
                        Return
                    End If
                    nuevoReclamo.IdReclamos = reclamoPorActualizar.IdReclamos
                    nuevoReclamo.Tipo = cbTipo.Text
                    nuevoReclamo.Descripcion = tbDescripcion.Text
                    Dim nmiembro As New NMiembros()
                    Dim tmiembro As DataTable = nmiembro.BuscarPorDni(tbDNI.Text)

                    If tmiembro.Rows.Count > 0 Then
                        nuevoReclamo.IdMiembro = Convert.ToInt32(tmiembro.Rows(0)("id_miembro"))
                    ElseIf tbDNI.Text.ToString IsNot "" Then
                        MsgBox("El DNI no ha sido encontrado.", MsgBoxStyle.Exclamation, "Aviso")
                    End If
                    frmPrincipal.Actualizar(nuevoReclamo)
                    Me.Close()
                Catch ex As Exception
                    MsgBox("Error al actualizar el reclamo: " & ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("Error al cancelar: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class