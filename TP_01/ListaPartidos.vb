Public Class ListaPartidos
    Private _cantidadPartidos As Integer
    Private _partidosCargados() As PartidoFutbol
    'TODO crear una variable que almacene el numero que se tiene en cuenta para redimensionar
    ' el vector (10 actualmente)

    Public Sub New()
        _cantidadPartidos = 0
        ReDim _partidosCargados(10)
    End Sub

    Public Sub Anexar(partido As PartidoFutbol)
        If EsNecesarioRedimensionarVector() Then
            ReDim Preserve _partidosCargados(_cantidadPartidos + 10)
        End If

        _partidosCargados(_cantidadPartidos) = partido
        _cantidadPartidos += 1
    End Sub

    Public Function Acceder(indice As Integer) As PartidoFutbol
        Return _partidosCargados(indice)
    End Function

    Public Function Contar() As Integer
        Return _cantidadPartidos
    End Function

    Private Function EsNecesarioRedimensionarVector() As Boolean
        Return _cantidadPartidos Mod 10 = 0
    End Function

End Class
