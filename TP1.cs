// See https://aka.ms/new-console-template for more information


bool continuar = true;
while (continuar)
{
    Console.WriteLine("\n Bienvenidos al Sistema de Control de Temperatura");
    Console.WriteLine("---------------------MENU--------------------------");
    Console.WriteLine("1. Para ingresar la Temperatura");
    Console.WriteLine("2. Conocer el pronostico para los proximos cinco dias ");
    Console.WriteLine("3. Salir");
    Console.WriteLine("Ingrese una opcion para continuar");
    int opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion) 
    {
        case 1:
            Console.WriteLine("Ingrese la temperatura");
            double temperatura = double.Parse(Console.ReadLine());
            switch (temperatura) {
                case double n when (n < 0):
                    Console.WriteLine("Hace mucho frío afuera, asegúrate de abrigarte bien.");
                    break;
                case double n when (n >= 0 && n <= 20):
                    Console.WriteLine("El clima está fresco, una chaqueta ligera sería perfecta.");
                    break;
                case double n when (n > 20):
                    Console.WriteLine("Hace calor afuera, no necesitas una chaqueta.");
                    break;
                default:
                    Console.WriteLine("Temperatura no esperada: " + temperatura);
                    break;
            }
            break;
        case 2:
            Random random = new Random();
            
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

            Console.WriteLine("Pronóstico de Temperatura para la Semana:");

            
            foreach (var dia in dias)
            {
                
                double temp = random.NextDouble() * (35 - (-10)) + (-10);


                temperatura = Math.Round(temp, 1);


                Console.WriteLine($"{dia}: {temperatura}°C");
            }
            break;
        case 3:
            Console.WriteLine("¡Gracias por usar el Sistema de Control de Temperatura! ¡Hasta luego!");
            continuar = false;
            break;
    }




}