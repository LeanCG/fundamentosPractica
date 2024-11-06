Imports System

Module Program
    dim velocidadMaxima() as intger = {20,40,60,100}
    Enum puntoControl
        altoriesgo 
        calle
        avenida
        autopista
    End Enum

    Sub Main(args As String())
        Console.WriteLine("Hello World!")
    End Sub

    Sub Imprimir(cadena As String)
        Console.WriteLine("{0}",cadena)
    End Sub

    function CondicionSalida()
        Imprimir("Desea Procesar otra Multa? Si/No  escriba Si para continuar. No para Salir")
        Condicion = Console.ReadLine()
        ValidacionCondicionSalida(Condicion)
        If Condicion = "No"
            return break
        End If
    End function
    function ValidacionCondicionSalida(Condicion as String)
        While Condicion <> "Si" And Condicion <> "No"
            Imprimir("Error: escriba Si para continuar. No para Salir ")
            Condicion = Console.ReadLine() 
        End While
    End function
End Module
