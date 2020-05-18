Public Class PartidoFutbol
    Private _fechaPartido As DateTime
    Private _equipoLocal As String
    Private _equipoVisitante As String
    Private _golesLocal As Short
    Private _golesVisitante As Short
    Private _finalizacion As String

    Public Sub Parse(registro As String, separador As Char)
        Dim campo(5) As String
        campo = registro.Split(separador)

        _fechaPartido = DateTime.Parse(campo(0))
        _equipoLocal = campo(1)
        _equipoVisitante = campo(2)
        _golesLocal = Short.Parse(campo(3))
        _golesVisitante = Short.Parse(campo(4))
        _finalizacion = campo(5)
    End Sub

    Public Function EnUnaLineaSeparadoPor(separador As Char) As String
        Return _fechaPartido.ToShortDateString() & separador _
        & _equipoLocal & separador _
        & _equipoVisitante & separador _
        & _golesLocal.ToString() & separador _
        & _golesVisitante.ToString() & separador _
        & _finalizacion
    End Function

    Public Function GetFechaPartido() As DateTime
        Return _fechaPartido
    End Function

    Public Function GetEquipoLocal() As String
        Return _equipoLocal
    End Function

    Public Function GetEquipoVisitante() As String
        Return _equipoVisitante
    End Function

    Public Function GetGolesLocal() As Short
        Return _golesLocal
    End Function

    Public Function GetGolesVisitante() As Short
        Return _golesVisitante
    End Function

    Public Function GetFinalizacion() As String
        Return _finalizacion
    End Function
End Class
