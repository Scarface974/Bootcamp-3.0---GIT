using System;

class Program
{

    static void Main(string[] args)
    {
        Pasante pasante1 = new Pasante(12345, "Juan", "Giles", "Pasante");
        Pasante pasante2 = new Pasante(67891, "Roberto", "Benitez", "Pasante");
        Pasante pasante3 = new Pasante(10225, "Gonzalo", "Mamani", "Pasante");

        Profesional profesional1 = new Profesional(102421, "Sebastian", "Gauna", "Profesional");
        Profesional profesional2 = new Profesional(201922, "Julio", "Ortiz", "Profesional");
        Profesional profesional3 = new Profesional(592832, "Manuel", "Acevedo", "Profesional");

        RegistroTemperatura registro1 = new RegistroTemperatura(36.7, pasante1, DateTime.Now.Date, DateTime.Now.TimeOfDay);
        RegistroTemperatura registro2 = new RegistroTemperatura(26.3, profesional1, DateTime.Now.Date, DateTime.Now.TimeOfDay);
        RegistroTemperatura registro3 = new RegistroTemperatura(6.2, pasante2, DateTime.Now.Date, DateTime.Now.TimeOfDay);
        RegistroTemperatura registro4 = new RegistroTemperatura(24.5, profesional2, DateTime.Now.Date, DateTime.Now.TimeOfDay);
        RegistroTemperatura registro5 = new RegistroTemperatura(19.1, pasante3, DateTime.Now.Date, DateTime.Now.TimeOfDay);
        RegistroTemperatura registro6 = new RegistroTemperatura(11.7, profesional3, DateTime.Now.Date, DateTime.Now.TimeOfDay);

        EstacionMeteorologica estacion = new EstacionMeteorologica();

        
        estacion.RegistrarTemperatura(registro1);
        estacion.RegistrarTemperatura(registro2);
        estacion.RegistrarTemperatura(registro3);
        estacion.RegistrarTemperatura(registro4);
        estacion.RegistrarTemperatura(registro5);
        estacion.RegistrarTemperatura(registro6);

        
        List<double> todasLasTemperaturas = estacion.VerTemperaturas();
        Console.WriteLine("Todas las temperaturas registradas:");
        foreach (double temp in todasLasTemperaturas)
        {
            Console.WriteLine(temp);
        }

        
        List<double> temperaturasDeHoy = estacion.VerTemperaturas(DateTime.Now.Date);
        Console.WriteLine("\nTemperaturas registradas hoy:");
        foreach (double temp in temperaturasDeHoy)
        {
            Console.WriteLine(temp);
        }

        
        DateTime fechaEspecifica = DateTime.Now.Date;
        List<RegistroTemperatura> registrosDeDia = estacion.VerTemperaturasDeUnDia(fechaEspecifica);
        Console.WriteLine("\nRegistros de temperatura del día:");
        foreach (RegistroTemperatura registro in registrosDeDia)
        {
            Console.WriteLine($"\n Temperatura: {registro.TemperaturaRegistrada}°C, Persona: {registro.PersonaDeTurno.INFOPERSONA}");
        }
    }




    public abstract class Persona
    {
        public abstract string INFOPERSONA { get; }
    }


    public class Pasante : Persona
    {
        public int NumeroLegajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }

        public Pasante(int numeroLegajo, string nombre, string apellido, string cargo)
        {
            NumeroLegajo = numeroLegajo;
            Nombre = nombre;
            Apellido = apellido;
            Cargo = cargo;
        }

        public override string INFOPERSONA
        {
            get
            {
                return $"Número de Legajo: {NumeroLegajo}\nNombre: {Nombre}\nApellido: {Apellido}\nCargo: {Cargo}";
            }
        }
    }

    public class Profesional : Persona
    {
        public int NumeroMatricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }

        public Profesional(int numeroMatricula, string nombre, string apellido, string cargo)
        {
            NumeroMatricula = numeroMatricula;
            Nombre = nombre;
            Apellido = apellido;
            Cargo = cargo;
        }

        public override string INFOPERSONA
        {
            get
            {
                return $"Número de Matricula: {NumeroMatricula}\nNombre: {Nombre}\nApellido: {Apellido}\nCargo: {Cargo}";
            }
        }
    }




    public class RegistroTemperatura
    {
        public double TemperaturaRegistrada { get; set; }
        public Persona PersonaDeTurno { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public TimeSpan HoraDeRegistro { get; set; }

        public RegistroTemperatura(double temperaturaRegistrada, Persona personaDeTurno, DateTime fechaDeRegistro, TimeSpan horaDeRegistro)
        {
            TemperaturaRegistrada = temperaturaRegistrada;
            PersonaDeTurno = personaDeTurno;
            FechaDeRegistro = fechaDeRegistro;
            HoraDeRegistro = horaDeRegistro;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\nTemperatura: {TemperaturaRegistrada}°C");
            Console.WriteLine($"Persona de Turno: {PersonaDeTurno.INFOPERSONA}");
            Console.WriteLine($"Fecha de Registro: {FechaDeRegistro.ToShortDateString()}");
            Console.WriteLine($"Hora de Registro: {HoraDeRegistro}");
        }
    }



    class EstacionMeteorologica
    {
        
        private List<RegistroTemperatura> registros;

        
        public EstacionMeteorologica()
        {
            registros = new List<RegistroTemperatura>();
        }

        
        public void RegistrarTemperatura(RegistroTemperatura registro)
        {
            registros.Add(registro);
        }

        
        public List<double> VerTemperaturas(DateTime? fecha = null)
        {
            if (fecha.HasValue)
            {
                return registros
                    .Where(r => r.FechaDeRegistro.Date == fecha.Value.Date)
                    .Select(r => r.TemperaturaRegistrada)
                    .ToList();
            }
            else
            {
                return registros
                    .Select(r => r.TemperaturaRegistrada)
                    .ToList();
            }
        }

        
        public List<RegistroTemperatura> VerTemperaturasDeUnDia(DateTime fecha)
        {
            return registros
                .Where(r => r.FechaDeRegistro.Date == fecha.Date)
                .ToList();
        }



    }






}














