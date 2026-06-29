using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;


namespace test;
class Program
{
    public static void Main(string[] args)
    {
     CuentaBancaria cuenta1 = new CuentaBancaria("Matias",1943285,29,200.0m);   
     CuentaBancaria cuenta2 = new CuentaBancaria("Fernando",19382544,42,0.0m);

        try
        {
            cuenta1.TransferirA(cuenta2,200.0m);
        }
        catch(MalaTransaccionException Error)
        {
            Error.MostrarInformacionDelError();
        }
        finally
        {
            Console.WriteLine(cuenta1.Saldo);
            Console.WriteLine(cuenta2.Saldo);
        }
    }
}

public abstract class Persona
{
    private string nombre;
    private int dni;
    private int edad;
    public string Nombre
    {
        get{return nombre;}
        set{nombre = value;}
    }
    public int Dni
    {
        get{return dni;}
        set{if(value < 0){
            throw new DniFalsoException("dni falso");
        }
            dni = value;
        }
    }
    public int Edad
    {
        get{return edad;}
        set{edad = value;}
    }

    public Persona(string nombre, int dni, int edad)
    {
        Nombre = nombre;
        Dni = dni;
        Edad = edad;
    }

    public abstract void RealizarAccion();
}

public abstract class Institucion
{
    private string nombre;
    public string Nombre
    {
        get{return nombre;}
        set{nombre = value;}
    }
    private string direccion;
    public string Direccion
    {
        get{return direccion;}
        set{direccion = value;}
    }
    public abstract void PresentarInstitucion();
}
    public class Estudiante : Persona
    {
        private string legajo;
        public string Legajo
        {
            get{return legajo;}
            set{legajo = value;}
    }

    public Estudiante(string nombre, int dni, int edad, string legajo) : base(nombre, dni, edad)
    {
        Legajo = legajo;
    }
    public override void RealizarAccion()
    {
        Console.WriteLine("El estudiante esta estudiando");
    }
}
    public class Medico : Persona
    {
        private string especialidad;
        public string Especialidad
        {
            get{return especialidad;}
            set{especialidad = value;}
        }

        public Medico(string nombre, int dni, int edad, string especialidad): base(nombre, dni, edad)
        {
            Especialidad = especialidad;
        }
        
        public override void RealizarAccion()
        {
            Console.WriteLine("El medico esta atendiendo al paciente");
        }
    }
public class Banco : Institucion
{
    private List<CuentaBancaria> cuentas = new List<CuentaBancaria>();
    public Banco(string nombre, string direccion)
    {
        Nombre = nombre;
        Direccion = direccion;
    } 
    public void AbrirCuenta(CuentaBancaria cliente, decimal depositoInicial)
    {
        cliente.Depositar(depositoInicial);
        cuentas.Add(cliente);
    }
    public override void PresentarInstitucion()
    {
        Console.WriteLine($"el banco se llama"+Nombre+"y esta ubicado en"+Direccion);
    }
 }

public class Escuela : Institucion
    {
        private List<Estudiante> estudiantes = new List<Estudiante>();
        public void MatricularEstudiante(string nombre, int dni, int edad, string legajo)
    {
        estudiantes.Add(new Estudiante(nombre, dni, edad, legajo));
    }        
        public Escuela(string nombre, string direccion)
        {
            Nombre = nombre;
            Direccion = direccion;
        }
            public override void PresentarInstitucion()
        {
            Console.WriteLine("la escuela queda en"+Nombre+"y"+Direccion);
        }
    }

public class Hospital : Institucion
    {
        private List<Medico> medicos = new List<Medico>();

        private string nombre;
        private string direccion;

        public string Nombre
        {
            get{return nombre;}
            set{nombre = value;}
        }

        public string Direccion
        {
            get{return direccion;}
            set{direccion = value;}
        }
        public void ContratarMedico(string nombre, int dni, int edad, string especialidad)
        {
            medicos.Add(new Medico(nombre, dni, edad, especialidad));
        }
        public override void PresentarInstitucion()
        {
            Console.WriteLine("El hospital queda en"+nombre+"y"+direccion);
        }

    }

public class Empleado : Persona
{
    private string legajo;
    public string Legajo
    {
        get{return legajo;}
        set{legajo = value;}
    }
    private string puesto;
    public string Puesto
    {
        get{return puesto;}
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                puesto = value;
            }
        }
    }
    public Empleado(string nombre, int dni, int edad, string legajo): base(nombre, dni, edad)
    {
        Legajo = legajo;
    }
    public override void RealizarAccion()
    {
        Console.WriteLine("el empleado esta trabajando en su puesto");
    }
}
public class CuentaBancaria : Persona
{

    public string Titular
    {
        get{return titular;}
        set{titular = value;}
    }
    public decimal Saldo
    {
        get{return saldo;}
        set{saldo = value;}
    }

    private string titular;
    private decimal saldo;

    public CuentaBancaria(string nombre, int dni, int edad, decimal saldo): base(nombre, dni, edad)
    {
        Saldo = saldo;
    }

    public override void RealizarAccion()
    {
    }

    public void Depositar(decimal monto)
    {
        if(monto < 0)
        {
            throw new NoMontoRealizadoException("el monto debe ser mayor a 0");
        }
        saldo += monto;
   }
    public void Retirar(decimal monto)
    {
        if(monto > saldo)
        {
            throw new NoRetiroSuccessException("No podes retirar mas de lo que ya tenes");
        }
        saldo -= monto;
    }
    
    public void TransferirA(CuentaBancaria cliente, decimal transaccion)
    {
        if(transaccion > saldo)
        {
            throw new MalaTransaccionException("ERROR DE TRANSACCION","404");
        }
        saldo -= transaccion;
        cliente.Depositar(transaccion);
    }

}

public abstract class PruebaException : Exception
{
    private int Error;
    
    public PruebaException(string Message, int error): base(Message)
    {
        Error = error;
    }
}
public class NoMontoRealizadoException : PruebaException
{
    public NoMontoRealizadoException(string Message): base(Message,1)
    {
    }
}

public class NoRetiroSuccessException : PruebaException
{
    public NoRetiroSuccessException(string Message): base(Message,2)
    {
    }
}

public class NoTransaccionException : PruebaException
{
    public NoTransaccionException(string Message): base(Message,3)
    {
    }
}
public class DniFalsoException : PruebaException
    {
        public DniFalsoException(string Message): base(Message, 4)
        {}
    }
public class MalaTransaccionException : PruebaException
    {
        public DateTime FechaDelError;
        public string CodigoDelError;
        public MalaTransaccionException(string Message, string codigo): base(Message, 5)
    {
        FechaDelError = DateTime.Now;
        CodigoDelError = codigo;
    }
    public void MostrarInformacionDelError()
    {
        Console.WriteLine($"[FECHA:{FechaDelError}, CODIGO:{CodigoDelError},DETALLES:{Message}]");
    }
    }
