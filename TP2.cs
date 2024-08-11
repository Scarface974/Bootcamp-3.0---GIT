// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        double[,] temperaturas = {
            { 22, 12, 10, 31, 15, 21, 17 },
            {28, 19, 20, 14, 12, 23, 44 },
            { 1, 34, 47, 38, 29, 12, 21 },
            { 22, 42, 24, 11, 4, 8, 28 },
            { 21, 43, 11, 23, 22, 10, 35 }
        };
        List<double> temperaturasPromedioSemanal = new List<double>();
        List<double> temperaturasPorEncimaUmbral = new List<double>();



        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Menú de Opciones ---");
            Console.WriteLine("1. Ver temperatura de un día específico");
            Console.WriteLine("2. Calcular y ver promedios semanales");
            Console.WriteLine("3. Encontrar y ver temperaturas por encima de 20°C");
            Console.WriteLine("4. Ver temperatura promedio del mes");
            Console.WriteLine("5. Ver temperatura más alta del mes");
            Console.WriteLine("6. Ver temperatura más baja del mes");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    VerTemperaturaDiaEspecifico(temperaturas);
                    break;
                case 2:
                    temperaturasPromedioSemanal = CalcularPromedioSemanal(temperaturas);
                    MostrarPromediosSemanales(temperaturasPromedioSemanal);
                    break;
                case 3:
                    temperaturasPorEncimaUmbral = EncontrarTemperaturasPorEncimaDeUmbral(temperaturas, 20);
                    MostrarTemperaturasPorEncimaDeUmbral(temperaturasPorEncimaUmbral);
                    break;
                case 4:
                    double promedioMes = CalcularPromedioMensual(temperaturas);
                    Console.WriteLine($"El promedio de temperaturas del mes es: {promedioMes:0.00}°C");
                    break;
                case 5:
                    double temperaturaMaxima = EncontrarTemperaturaMaxima(temperaturas);
                    Console.WriteLine($"La temperatura más alta del mes es: {temperaturaMaxima}°C");
                    break;
                case 6:
                    double temperaturaMinima = EncontrarTemperaturaMinima(temperaturas);
                    Console.WriteLine($"La temperatura más baja del mes es: {temperaturaMinima}°C");
                    break;
                case 7:
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                    break;

            }

            static void VerTemperaturaDiaEspecifico(double[,] matriz)
            {
                Console.Write("Ingrese el día del mes (1-31): ");
                int dia = int.Parse(Console.ReadLine());

                // Verificar si el día está dentro del rango válido
                if (dia < 1 || dia > 31)
                {
                    Console.WriteLine("Día inválido. Por favor, ingrese un número entre 1 y 31.");
                    return;
                }

                // Calcular la fila y columna correspondientes en la matriz
                int fila = (dia - 1) / 7; // División entera para determinar la fila
                int columna = (dia - 1) % 7; // Módulo para determinar la columna

                // Obtener la temperatura del día seleccionado
                double temperatura = matriz[fila, columna];

                // Mostrar la temperatura y un mensaje basado en ella
                Console.WriteLine($"La temperatura para el día {dia} fue: {temperatura}°C");

                if (temperatura < 0)
                {
                    Console.WriteLine("Hizo mucho frío.");
                }
                else if (temperatura >= 0 && temperatura <= 20)
                {
                    Console.WriteLine("El clima estaba fresco.");
                }
                else
                {
                    Console.WriteLine("Hizo calor afuera.");
                }
            }


            static List<double> CalcularPromedioSemanal(double[,] matriz)
            {
                List<double> promedios = new List<double>();

                for (int i = 0; i < matriz.GetLength(0); i++) // Recorre las filas (semanas)
                {
                    double suma = 0;
                    int diasEnSemana = 0;

                    for (int j = 0; j < matriz.GetLength(1); j++) // Recorre las columnas (días)
                    {
                        // Solo sumar si el día tiene una temperatura válida
                        if (matriz[i, j] != 0)
                        {
                            suma += matriz[i, j];
                            diasEnSemana++;
                        }
                    }

                    // Calcular el promedio de la semana
                    if (diasEnSemana > 0)
                    {
                        double promedio = suma / diasEnSemana;
                        promedios.Add(promedio);
                    }
                }

                return promedios;
            }

            static void MostrarPromediosSemanales(List<double> promedios)
            {
                for (int i = 0; i < promedios.Count; i++)
                {
                    Console.WriteLine($"Promedio de la semana {i + 1}: {promedios[i]:0.00}°C");
                }
            }

            static List<double> EncontrarTemperaturasPorEncimaDeUmbral(double[,] matriz, double umbral)
            {
                List<double> temperaturas = new List<double>();

                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] > umbral)
                        {
                            temperaturas.Add(matriz[i, j]);
                        }
                    }
                }

                return temperaturas;
            }

            static void MostrarTemperaturasPorEncimaDeUmbral(List<double> temperaturas)
            {
                Console.WriteLine("Temperaturas por encima del umbral:");
                foreach (double temp in temperaturas)
                {
                    Console.WriteLine($"{temp}°C");
                }
            }


            static double CalcularPromedioMensual(double[,] matriz)
            {
                double suma = 0;
                int totalDias = 0;

                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] != 0)
                        {
                            suma += matriz[i, j];
                            totalDias++;
                        }
                    }
                }

                return totalDias > 0 ? suma / totalDias : 0;
            }




            static double EncontrarTemperaturaMaxima(double[,] matriz)
            {
                double maxima = double.MinValue;

                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] > maxima)
                        {
                            maxima = matriz[i, j];
                        }
                    }
                }

                return maxima;
            }

            static double EncontrarTemperaturaMinima(double[,] matriz)
            {
                double minima = double.MaxValue;

                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        if (matriz[i, j] < minima)
                        {
                            minima = matriz[i, j];
                        }
                    }
                }

                return minima;
            }



        }

    }
}


