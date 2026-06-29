//  using System;
//  using System.Collections.Generic;
//  using System.ComponentModel;
//  using System.Runtime.CompilerServices;

//  namespace TestPracticaPOO
//  {
//      class program3
//     {
//          static void Main(string[] args){

//          Curso nuevocurso = new Curso();

//         Alumno alumno1 = new Alumno("Matias", 17, 10.0m);
//        Alumno alumno2 = new Alumno("Franco", 16, 06.0m);

//        nuevocurso.GuardarAlosUsuarios(alumno1);
//         nuevocurso.GuardarAlosUsuarios(alumno2);
//         Console.WriteLine("Todos los alumnos");
//          Console.WriteLine("Aprobados:");
//         nuevocurso.InsertarALosUsuarios();
        

        
//         }
//      }
//  }
//     class Alumno
//      {
//          public string Nombre
//          {get; set;}
//         public int Edad
//          {get; set;}
//          public decimal Nota
//         {get; set;}

//         public Alumno(string nombre, int edad, decimal nota)
//          {
//              Nombre = nombre;
//             Edad = edad;
//              Nota = nota;
//          }
//      }
//      class Curso
//      {
//          private List<Alumno> alumnos = new();

//          public void GuardarAlosUsuarios(Alumno alumno)
//         {
//              alumnos.Add(alumno);
//        }
//        public void InsertarALosUsuarios()
//          {
//             foreach(var insertar in alumnos)
//              {
//                  Console.WriteLine($"{insertar.Nombre}, Nota:{insertar.Nota}, Edad:{insertar.Edad}");
//              }
//          }
//          public void MostrarAprobados()
//      {
//         foreach(var a in alumnos)
//          {
//             if(a.Nota >= 6)
//            {
//             Console.WriteLine($"{a.Nombre} - Nota: {a.Nota}");
//             }
//          }
//     }
//      }