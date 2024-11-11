Imports System

Module Program
    Dim velocidadesMaximas() As Integer = {20, 40, 60, 100}
    Dim velocidadIngresada As Integer
    Dim cantidadMultasProcesadas As Integer = 0
    Dim montoTotalRecaudado As Decimal = 0
    Dim opcionDeContinuar As Boolean
    Enum puntoControl
        altoriesgo
        calle
        avenida
        autopista
    End Enum

    Sub Main(args As String())
        Do
            ImprimirPuntoContoles()
            Dim velocidadMaxima As Integer = velocidadesMaximas(inputPuntoControl()) * 1.1
            velocidadIngresada = CInt(InputInstrution("Ingrese la velocidad"))
            Dim verificacion As Boolean = VerificacionDeMulta(velocidadIngresada, velocidadMaxima)

            If verificacion = False Then
                opcionDeContinuar = CondicionSalida()
            Else
                Dim valorInfraccion As Decimal = MontoInfraccion(velocidadIngresada, velocidadMaxima)
                cantidadMultasProcesadas = cantidadMultasProcesadas + 1
                montoTotalRecaudado = montoTotalRecaudado + valorInfraccion
                opcionDeContinuar = CondicionSalida()
            End If
            ImprimirTotales(opcionDeContinuar)
        Loop Until opcionDeContinuar = False
    End Sub

    Sub Imprimir(cadena As String)
        Console.WriteLine("{0}", cadena)
    End Sub

    Function InputInstrution(message As String)
        Imprimir(String.Format("{0}", message))
        Return Console.ReadLine()
    End Function
    Function CondicionSalida()
        Imprimir("Desea Procesar otra Multa? Si/No  escriba Si para continuar. No para Salir")
        Dim condicion As String
        condicion = Console.ReadLine()
        While condicion <> "Si" And condicion <> "No"
            Imprimir("Error: escriba Si para continuar. No para Salir ")
            condicion = Console.ReadLine()
        End While
        If condicion = "Si" Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub ImprimirPuntoContoles()
        Imprimir("puntos de control")
        Imprimir("1. altoriesgo")
        Imprimir("2. calle")
        Imprimir("3. Avenida")
        Imprimir("4. Autopista")
    End Sub
    Function inputPuntoControl()
        Dim puntoContolSeleccionado As Integer = CInt(InputInstrution("seleccione el punto de control ingresando el nro correspondiente"))
        While puntoContolSeleccionado < 1 And puntoContolSeleccionado > 4
            puntoContolSeleccionado = CInt(InputInstrution("Error debe de ingresar un valor entre 1 y 4"))
        End While
        Return puntoContolSeleccionado - 1
    End Function
    Function VerificacionDeMulta(value As Integer, value1 As Integer)
        'value es la velocidad ingresada, value1 es el indice de la velocidad maxima

        If value > value1 Then
            Imprimir("Es infraccion")
            Return True
        End If
        Imprimir("No es infraccion")
        Return False

    End Function
    Sub ImprimirTotales(opcContinuar As Boolean)
        If opcContinuar = False Then
            Imprimir(String.Format("Cantidad de multas procesadas: {0}", cantidadMultasProcesadas))
            Imprimir(String.Format("Monto total recaudado: {0}", montoTotalRecaudado))
        End If
    End Sub
    Function MontoInfraccion(value As Integer, value1 As Integer)
        Return (value - value1) * 1100
    End Function
End Module
