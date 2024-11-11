Imports System

Module Program
    dim cantidadAlumnos As Integer
    dim alumnos() As String
    dim notasAlumnos(,) As Integer
    dim notaSimbolicasAlumnos() As String
    dim promediosAlumnos() As Double
    dim nombreAlumno As String
    dim notaIngresada as integer
    dim notaSimbolicaIngresada as String
    dim promedioAlumno as Double
    dim mejorPromedio as Double
    dim cantidadAprobados as integer
    dim cantidadDesaprobados as integer


    Sub Main(args As String())
        CantidadAlumnosACalificar()

        For indiceAlumno As Integer = 0 To cantidadAlumnos - 1
            alumnos(indiceAlumno) = CargaNombreAlumno()
            CargaNotas(indiceAlumno, promediosAlumnos)
        Next
        ImprimirTabla()

    End Sub

    Sub Imprimir(cadena As String)
        Console.WriteLine("{0}", cadena)
    End Sub

    Sub CantidadAlumnosACalificar()
        Imprimir("ingrese la cantidad de alumnos que evaluara")
        cantidadAlumnos = CInt(Console.ReadLine())
        ReDim alumnos(cantidadAlumnos - 1)
        ReDim notasAlumnos(cantidadAlumnos - 1, 1)
        ReDim notaSimbolicasAlumnos(cantidadAlumnos - 1)
        ReDim promediosAlumnos(cantidadAlumnos - 1)
    End Sub

    Sub CargaNotas(indiceAlumno As Integer, promediosAlumnos As Double())
        For i As Integer = 0 To 1
            Imprimir(String.Format("ingrese la nota {0}", i + 1))
            notasAlumnos(indiceAlumno, i) = CargaNota()
        Next
        notaSimbolicasAlumnos(indiceAlumno) = CargaNotaSimbolica()
        promediosAlumnos(indiceAlumno) = CalculoPromedio(notasAlumnos(indiceAlumno, 0), notasAlumnos(indiceAlumno, 1))
    End Sub

    Function InputInstrution(message As String)
        Imprimir(String.Format("{0}", message))
        Return Console.ReadLine()
    End Function
    Function CargaNombreAlumno()
        nombreAlumno = InputInstrution("ingrese el nombre del alumno")
        While nombreAlumno.Length < 3
            Imprimir("Error: ingrese un nombre con al menos 3 caracteres")
            nombreAlumno = Console.ReadLine()
        End While
        Return nombreAlumno
    End Function

    Function CargaNota()
        notaIngresada = CInt(Console.ReadLine())
        While notaIngresada < 0 Or notaIngresada > 10
            notaIngresada = InputInstrution("Error: ingrese una nota entre 1 y 10")
        End While
        Return notaIngresada
    End Function

    Function CargaNotaSimbolica()
        notaSimbolicaIngresada = InputInstrution("Ingrese la nota simbolica debe ser + o -")
        While notaSimbolicaIngresada <> "+" And notaSimbolicaIngresada <> "-"
            notaSimbolicaIngresada = InputInstrution("Error: ingrese una nota simbolica + (positiva) o  - (negativa)")
        End While
        Return notaSimbolicaIngresada
    End Function
    Function CalculoPromedio(nota1 as Integer, nota2 as Integer) as Double
        return (nota1 + nota2)/ 2
    End function

    function DeterminacionAprobacion(promedio as Double, notaSimbolica as String)
        If promedio > 6 And notaSimbolica = "+"
            return "Aprobado"
        End If
        return "Desaprobado"

    End function
    
    sub GetMejorPromedio(promedio as Double)
        If promedio > mejorPromedio
            mejorPromedio = promedio
        End If
    End sub

    sub CantidadAprobadosDesaprobados(resutladoFinal as String)
        If resutladoFinal = "Aprobado" Then
            cantidadAprobados = cantidadAprobados + 1
        Else
            cantidadDesaprobados = cantidadDesaprobados + 1
        End If
    End sub

    sub ImprimirTabla()
        Imprimir(String.Format("nombre,nota1,nota2,promedio,resultado final"))
        for indiceAlumno as integer = 0 to cantidadAlumnos -1
            promedioAlumno = promediosAlumnos(indiceAlumno)
            GetMejorPromedio(promedioAlumno)
            dim resutladoFinal as String = DeterminacionAprobacion(promedioAlumno,notaSimbolicasAlumnos(indiceAlumno)) 
            CantidadAprobadosDesaprobados(resutladoFinal)
            Imprimir(String.Format("{0},{1},{2},{3},{4}", alumnos(indiceAlumno), notasAlumnos(indiceAlumno, 0), notasAlumnos(indiceAlumno, 1), promediosAlumnos(indiceAlumno), resutladoFinal))
        Next
        Imprimir(String.Format("El mejor promedio es: {0}",mejorPromedio))
        Imprimir(String.Format("Cantiad de alumnos aprobados: {0}",cantidadAprobados))
        Imprimir(String.Format("Cantiad de alumnos desaprobados: {0}",cantidadDesaprobados))
    End Sub
End Module
