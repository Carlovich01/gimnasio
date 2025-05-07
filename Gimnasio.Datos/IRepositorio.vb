Public Interface IRepositorio(Of T)
    Function Listar() As IEnumerable(Of T)
    Sub Insertar(entidad As T)
    Sub Actualizar(entidad As T)
    Sub Eliminar(id As Integer)
    Function ObtenerPorId(id As Integer) As T
End Interface
