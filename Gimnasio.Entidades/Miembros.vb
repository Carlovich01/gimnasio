Public Class Miembros
    ' Propiedades privadas
    Private _idMiembro As Integer
    Private _dni As String
    Private _nombre As String
    Private _apellido As String
    Private _fechaNacimiento As Date
    Private _genero As String
    Private _telefono As String
    Private _email As String
    Private _fechaRegistro As Date
    Private _estado As String
    Private _ultimaModificacion As Date

    ' Propiedades públicas con encapsulación
    Public Property IdMiembro As Integer
        Get
            Return _idMiembro
        End Get
        Set(value As Integer)
            _idMiembro = value
        End Set
    End Property

    Public Property Dni As String
        Get
            Return _dni
        End Get
        Set(value As String)
            _dni = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Apellido As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _fechaNacimiento
        End Get
        Set(value As Date)
            _fechaNacimiento = value
        End Set
    End Property

    Public Property Genero As String
        Get
            Return _genero
        End Get
        Set(value As String)
            _genero = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property FechaRegistro As Date
        Get
            Return _fechaRegistro
        End Get
        Set(value As Date)
            _fechaRegistro = value
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

    Public Property UltimaModificacion As Date
        Get
            Return _ultimaModificacion
        End Get
        Set(value As Date)
            _ultimaModificacion = value
        End Set
    End Property
End Class
