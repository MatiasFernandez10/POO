// using System;
// using System.Collections.Generic;

// namespace TestPracticaPOO
// {

//         class Program
//     {
//         static void Main(string[] args)
//         {
//             Banco banco = new Banco();

//             banco.CrearUsuario(new UsuarioBancario("Carlos", 123));
//             banco.CrearUsuario(new UsuarioBancario("Ana", 456));

//             banco.ListarUsuarios();
//         }
//     }
// }
//     public class Banco
//     {
//         private List<UsuarioBancario> usuarios = new();

//         // Método para crear usuario
//         public void CrearUsuario(UsuarioBancario usuario)
//         {
//             usuarios.Add(usuario);
//         }

//         // Método para listar usuarios
//         public void ListarUsuarios()
//         {
//             foreach (var usuario in usuarios)
//             {
//                 Console.WriteLine($"Titular: {usuario.Titular}, CBU: {usuario.Cbu}, Saldo: {usuario.Saldo}");
//             }
//         }
//     }

//     public class UsuarioBancario
//     {
//         public string Titular { get; set; }
//         public int Cbu { get; set; }
//         public decimal Saldo { get; set; }

//         public UsuarioBancario(string titular, int cbu)
//         {
//             Titular = titular;
//             Cbu = cbu;
//             Saldo = 0;
//         }
//     }