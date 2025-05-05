Public Class Reclamos
    ' Propiedades privadas
    Private _idReclamos As Integer
    Private _tipo As String
    Private _descripcion As String
    Private _fechaEnvio As Date
    Private _estado As String
    Private _respuesta As String
    Private _fechaRespuesta As Date
    Private _idMiembro As Integer?

    Public Property IdReclamos As Integer
        Get
            Return _idReclamos
        End Get
        Set(value As Integer)
            _idReclamos = value
        End Set
    End Property
    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property FechaEnvio As Date
        Get
            Return _fechaEnvio
        End Get
        Set(value As Date)
            _fechaEnvio = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Respuesta As String
        Get
            Return _respuesta
        End Get
        Set(value As String)
            _respuesta = value
        End Set
    End Property

    Public Property FechaRespuesta As Date
        Get
            Return _fechaRespuesta
        End Get
        Set(value As Date)
            _fechaRespuesta = value
        End Set
    End Property

    Public Property IdMiembro As Integer?
        Get
            Return _idMiembro
        End Get
        Set(value As Integer?)
            _idMiembro = value
        End Set
    End Property
End Class