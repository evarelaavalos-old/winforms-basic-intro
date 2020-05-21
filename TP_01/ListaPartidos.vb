Imports System.IO
Public Class ListaPartidos
    Private _cantidadPartidos As Integer
    Private _partidosCargados() As PartidoFutbol

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

    Public Sub Importar(rutaArchivo As String, delimitadorCampo As Char)
        If File.Exists(rutaArchivo) Then
            Dim archivo As FileStream = New FileStream(rutaArchivo, FileMode.Open)
            Dim lector As StreamReader = New StreamReader(archivo)

            While Not lector.EndOfStream
                Dim partido As PartidoFutbol = New PartidoFutbol()
                partido.Parse(lector.ReadLine, delimitadorCampo)

                Me.Anexar(partido)
            End While

            lector.Close()
            archivo.Close()
        End If
    End Sub

    Private Function EsNecesarioRedimensionarVector() As Boolean
        Return _cantidadPartidos Mod 10 = 0
    End Function

End Class
