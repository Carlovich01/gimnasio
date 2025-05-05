Public Class Pagos
    Private _idPago As Integer
    Private _idMembresia As Integer
    Private _idUsuarioRegistro As Integer?
    Private _fechaPago As DateTime
    Private _montoPagado As Decimal
    Private _metodoPago As String
    Private _numeroComprobante As String
    Private _notas As String

    Public Property IdPago As Integer
        Get
            Return _idPago
        End Get
        Set(value As Integer)
            _idPago = value
        End Set
    End Property

    Public Property IdMembresia As Integer
        Get
            Return _idMembresia
        End Get
        Set(value As Integer)
            _idMembresia = value
        End Set
    End Property

    Public Property IdUsuarioRegistro As Integer?
        Get
            Return _idUsuarioRegistro
        End Get
        Set(value As Integer?)
            _idUsuarioRegistro = value
        End Set
    End Property

    Public Property FechaPago As DateTime
        Get
            Return _fechaPago
        End Get
        Set(value As DateTime)
            _fechaPago = value
        End Set
    End Property

    Public Property MontoPagado As Decimal
        Get
            Return _montoPagado
        End Get
        Set(value As Decimal)
            _montoPagado = value
        End Set
    End Property

    Public Property MetodoPago As String
        Get
            Return _metodoPago
        End Get
        Set(value As String)
            _metodoPago = value
        End Set
    End Property

    Public Property NumeroComprobante As String
        Get
            Return _numeroComprobante
        End Get
        Set(value As String)
            _numeroComprobante = value
        End Set
    End Property

    Public Property Notas As String
        Get
            Return _notas
        End Get
        Set(value As String)
            _notas = value
        End Set
    End Property
End Class

