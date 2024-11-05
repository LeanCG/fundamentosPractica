Imports System

Module Program
    dim cantidadAlumno As Integer
    dim alumnos() As String
    dim nombreAlumno As String

    Sub Main(args As String())
        CantidadAlumnos()
        CargaNotas()
    End Sub

    Sub Imprimir(cadena As String)
        Console.WriteLine("{0}",cadena)
    End Sub
    
    Sub CantidadAlumnos()
        Imprimir("ingrese la cantidad de alumnos que evaluara")
        cantidadAlumno = Console.Read()
        Redim alumnos(cantidadAlumno) 
    End Sub

    Sub CargaNotas()
        For i as Integer = 1 to 4
        Imprimir(String.Format("ingrese la nota {0}",i))
        Next
    End Sub

    sub NombreAlumno(cadena as String)
        nombreAlumno = Console.ReadLine()
        if nombreAlumno.Length > 3
        


End Module
