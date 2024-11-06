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
        CantidadAlumnosCalificados()
        
        
        For indiceAlumno as integer = 0 to cantidadAlumnos-1
            nombreAlumno = NombreAlumnos()
            ValidacionLongitudCampo(nombreAlumno)
            alumnos(indiceAlumno) = nombreAlumno
            CargaNotas(indiceAlumno)
        Next

    End Sub

    Sub Imprimir(cadena As String)
        Console.WriteLine("{0}",cadena)
    End Sub
    
    Sub CantidadAlumnosCalificados()
        Imprimir("ingrese la cantidad de alumnos que evaluara")
        cantidadAlumnos = Cint(Console.ReadLine())
        ReDim alumnos(cantidadAlumnos-1)
        ReDim notasAlumnos(cantidadAlumnos-1,1)
        ReDim notaSimbolicasAlumnos(cantidadAlumnos-1)
        ReDim promediosAlumnos(cantidadAlumnos-1)
    End Sub

    Sub CargaNotas(indiceAlumno As Integer)
        For i as Integer = 0 to 1
            Imprimir(String.Format("ingrese la nota {0}",i))
            notaIngresada = Cint(Console.ReadLine())
            ValidacionNota(notaIngresada)
            notasAlumnos(indiceAlumno,i) = notaIngresada
        Next
        Imprimir("Ingrese la nota simbolica debe ser + o -")
        notaSimbolicaIngresada = Console.ReadLine()
        ValidacionNotaSimbolica(notaSimbolicaIngresada)
        notaSimbolicasAlumnos(indiceAlumno)=notaSimbolicaIngresada
        promedioAlumno = CalculoPromedio(notasAlumnos(indiceAlumno,0),notasAlumnos(indiceAlumno,1))
        promediosAlumnos(indiceAlumno)=promedioAlumno
        ImprimirTabla()

    End Sub

    function NombreAlumnos()
            Imprimir("ingrese el nombre del alumno:")
        return Console.ReadLine()
    End function

    sub ValidacionLongitudCampo(nombreAlumno as String)
        While nombreAlumno.Length < 3
            Imprimir("Error: ingrese un nombre con al menos 3 caracteres")
            nombreAlumno = Console.ReadLine() 
        End While
    End sub

    sub ValidacionNota(notaIngresada as Integer)
        While notaIngresada < 0 Or notaIngresada > 10
            Imprimir("Error: ingrese una nota entre 1 y 10")
            notaIngresada = Console.ReadLine() 
        End While
    End sub

    sub ValidacionNotaSimbolica(notaSimbolicaIngresada as String)
        While notaSimbolicaIngresada <> "+" And notaSimbolicaIngresada <> "-"
            Imprimir("Error: ingrese una nota simbolica + (positiva) o  - (negativa)")
            notaSimbolicaIngresada = Console.ReadLine() 
        End While
    End sub
    function CalculoPromedio(nota1 as Integer, nota2 as Integer) as Double
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
            Imprimir(String.Format("{0},{1},{2},{3},{4}",alumnos(indiceAlumno),notasAlumnos(indiceAlumno,0),notasAlumnos(indiceAlumno,1),promediosAlumnos(indiceAlumno),resutladoFinal))
        Next
        Imprimir(String.Format("El mejor promedio es: {0}",mejorPromedio))
        Imprimir(String.Format("Cantiad de alumnos aprobados: {0}",cantidadAprobados))
        Imprimir(String.Format("Cantiad de alumnos desaprobados: {0}",cantidadDesaprobados))
    End Sub
End Module
