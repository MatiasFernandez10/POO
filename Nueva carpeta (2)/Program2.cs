//     using System;
// using System.ComponentModel;
// using System.Diagnostics;
//     using System.Reflection.Metadata;
//     using System.Security.Cryptography.X509Certificates;

//     namespace Test;

//     class Program2
// {
//     static void Main(string[] args)
//     {
//         CuentaBancaria piana = new CuentaBancaria();
//         piana.Depositar(100);
//         piana.Depositar(100);
//         piana.Depositar(100);
//         piana.Mostrar();
//         piana.Mostrar2();
//     }
// }

// class CuentaBancaria
// {
//     public List<int> lista = new();
//     public int depositos = 0;
//     public int saldo;
//     public string usuario;
//     public void Depositar(int monto)
//     {
//         if(saldo >= 0)
//         {
//             saldo += monto;
//             depositos++;
//             lista.Add(depositos);
//         }
//         else
//         {
//             Console.Write("no estudie");
//         }
//     }
//     public void Mostrar()
//     {
//         Console.WriteLine($"el saldo es:{saldo}");
//     }
//     public void Mostrar2()
//     {
//         foreach(int lista1 in lista)
//         {
//             Console.Write(lista1);
//         }
//     }
// }
