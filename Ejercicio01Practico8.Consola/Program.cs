using ConsoleTables;
using Ejercicio01Practico8.Utilidades;

namespace Ejercicio01Practico8.Consola
{
    internal class Program
    {
        const double MIN_TEMPERATURA = -10;
        const double MAX_TEMPERATURA = 24;
        enum Orden
        {
            Ascendente=1,
            Descendente
        }
        static void Main(string[] args)
        {
            double[] temperaturas = new double[7];
            bool seguir = true;
            do
            {
                MostrarMenu();
                int opcionSeleccionada =IngresoDatos.PedirIntEnRango("Seleccione:", 1, 9);
                switch (opcionSeleccionada)
                {
                    case 1:
                        GenerarLasTemperaturas(temperaturas);
                        break;
                    case 2:
                        ModificarDatos(temperaturas);
                        break;
                    case 3:
                        ListarTemperaturas(temperaturas);
                        break;
                    case 4:
                        DatosEstadisticos(temperaturas);
                        break;
                    case 5:
                        MarcarMayoresPromedio(temperaturas);
                        break;
                    case 6:
                        MostrarInferioresAlPromedio(temperaturas);
                        break;
                    case 7:
                        Ordenar(temperaturas);
                        break;
                    case 8:
                        Ordenar(temperaturas,Orden.Descendente);
                        break;
                    case 9:
                        seguir = false;
                        break;

                }
            } while (seguir);
            Console.WriteLine("Fin de la Apliación");
        }
        private static void Ordenar(double[] temperaturas, Orden orden = Orden.Ascendente)
        {
            var arrayCopia = new double[temperaturas.Length];
            temperaturas.CopyTo(arrayCopia, 0);
            var arrayOrdenado = OrdenarArray(arrayCopia,orden);
            Console.Clear();
            Console.WriteLine("Array Ordenado de Mayor a Menor");
            ListarTemperaturas(arrayOrdenado);
            TareaFinalizada("Array ordenado ...");

        }
        //private static void OrdenarDesc(double[] temperaturas)
        //{
        //    var arrayCopia = new double[temperaturas.Length];
        //    temperaturas.CopyTo(arrayCopia, 0);
        //    var arrayOrdenado = OrdenarArrayDesc(arrayCopia);
        //    Console.Clear();
        //    Console.WriteLine("Array Ordenado de Mayor a Menor");
        //    ListarTemperaturas(arrayOrdenado);
        //    TareaFinalizada("Array ordenado desc...");
        //}
        //private static void OrdenarAsc(double[] temperaturas)
        //{
        //    var arrayCopia = new double[temperaturas.Length];
        //    temperaturas.CopyTo(arrayCopia, 0);
        //    var arrayOrdenado = OrdenarArrayAsc(arrayCopia);
        //    Console.Clear();
        //    Console.WriteLine("Array Ordenado de Menor a Mayor");
        //    ListarTemperaturas(arrayOrdenado);
        //    TareaFinalizada("Array ordenado asc...");

        //}
        private static double[] OrdenarArray(double[] arrayCopia, Orden orden=Orden.Ascendente)
        {
            for (int i = 0; i < arrayCopia.Length - 1; i++)
            {
                for (int j = i + 1; j < arrayCopia.Length; j++)
                {
                    if (orden==Orden.Ascendente)
                    {
                        if (arrayCopia[i] > arrayCopia[j])
                        {
                            CambiarValores(ref arrayCopia[i], ref arrayCopia[j]);
                            //var aux = arrayCopia[i];
                            //arrayCopia[i] = arrayCopia[j];
                            //arrayCopia[j] = aux;
                        }
                    }
                    else
                    {
                        if (arrayCopia[i] < arrayCopia[j])
                        {
                            CambiarValores(ref arrayCopia[i], ref arrayCopia[j]);
                            //var aux = arrayCopia[i];
                            //arrayCopia[i] = arrayCopia[j];
                            //arrayCopia[j] = aux;
                        }
                    }
                }
            }
            return arrayCopia;
        }
        private static void CambiarValores(ref double a, ref double b)
        {
            var aux = a;
            a = b;
            b = aux;
        }
        //private static double[] OrdenarArrayDesc(double[] arrayCopia)
        //{
        //    for (int i = 0; i < arrayCopia.Length - 1; i++)
        //    {
        //        for (int j = i + 1; j < arrayCopia.Length; j++)
        //        {
        //            if (arrayCopia[i] < arrayCopia[j])
        //            {
        //                var aux = arrayCopia[i];
        //                arrayCopia[i] = arrayCopia[j];
        //                arrayCopia[j] = aux;
        //            }
        //        }
        //    }
        //    return arrayCopia;
        //}
        //private static double[] OrdenarArrayAsc(double[] arrayCopia)
        //{
        //    for (int i = 0; i < arrayCopia.Length-1; i++)
        //    {
        //        for (int j =i+1; j < arrayCopia.Length; j++)
        //        {
        //            if (arrayCopia[i] > arrayCopia[j])
        //            {
        //                var aux = arrayCopia[i];
        //                arrayCopia[i] = arrayCopia[j];
        //                arrayCopia[j] = aux;
        //            }
        //        }
        //    }
        //    return arrayCopia;
        //}

        private static void MostrarInferioresAlPromedio(double[] temperaturas)
        {
            var promedio = CalcularPromedio(temperaturas);
            Console.Clear();
            Console.WriteLine("Mostrar Inferiores al Promedio");
            Console.WriteLine($"Promedio={promedio.ToString("N2")}");
            var tabla = new ConsoleTable("Celsius");
            foreach (var tempEnArray in temperaturas)
            {
                if (tempEnArray < promedio)
                {
                    tabla.AddRow(tempEnArray);
                }
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizada("Inferiores al promedio...");

        }

        private static void MarcarMayoresPromedio(double[] temperaturas)
        {
            var promedio = CalcularPromedio(temperaturas);
            Console.Clear();
            Console.WriteLine("Marcar Superiores al Promedio");
            Console.WriteLine($"Promedio={promedio.ToString("N2")}");
            var tabla = new ConsoleTable("Celsius", "Sup. al Prom?");
            foreach (var tempEnArray in temperaturas)
            {
                if (tempEnArray>promedio)
                {
                    tabla.AddRow(tempEnArray, "*");
                }
                else
                {
                    tabla.AddRow(tempEnArray, "");
                }
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizada("Superiores al promedio...");
        }

        private static void DatosEstadisticos(double[] temperaturas)
        {
            var maxTemp = HallarMaxTemp(temperaturas);
            var minTemp = HallarMinTemp(temperaturas);
            var promTemp = CalcularPromedio(temperaturas);
            Console.WriteLine($"Mayor temperatura={maxTemp}");
            Console.WriteLine($"Menor temperatura={minTemp}");
            Console.WriteLine($"Promedio temperatura={promTemp}");
            Console.WriteLine();
            TareaFinalizada("Datos Estadísticos...");
        }

        private static double CalcularPromedio(double[] temperaturas)
        {
            double promedio = 0;
            foreach (var tempEnArray in temperaturas)
            {
                promedio += tempEnArray;
            }
            return promedio/temperaturas.Length;
        }

        private static double HallarMinTemp(double[] temperaturas)
        {
            double minimo = MAX_TEMPERATURA;
            foreach (var tempEnArray in temperaturas)
            {
                if (tempEnArray < minimo)
                {
                    minimo = tempEnArray;
                }
            }
            return minimo;
        }

        private static double HallarMaxTemp(double[] temperaturas)
        {
            double maximo = MIN_TEMPERATURA;
            foreach (var tempEnArray in temperaturas)
            {
                if (tempEnArray>maximo)
                {
                    maximo = tempEnArray;
                }
            }
            return maximo;
        }

        private static void ModificarDatos(double[] temperaturas)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Modificación de Datos");
                ListarTemperaturas(temperaturas);

                var index =
                    IngresoDatos.PedirIntEnRango("Ingrese un índice de elemento:", 1, temperaturas.Length);
                Console.WriteLine($"Valor anterior:{temperaturas[index - 1]}");

                double nuevaTemperatura;
                do
                {
                    nuevaTemperatura =
                    IngresoDatos.PedirDoubleEnRango("Ingrese nueva temperatura:",
                            MIN_TEMPERATURA, MAX_TEMPERATURA);
                    if (Existe(nuevaTemperatura, temperaturas))
                    {
                        Console.WriteLine("Temperatura existente!!!");
                    }
                    else
                    {
                        break;
                    }
                } while (true);
                temperaturas[index - 1] = nuevaTemperatura;
                var sigueModificando =
                    IngresoDatos.PedirCharEnRango("¿Desea modificar otro?(S/N)", 's', 'n');
                if (sigueModificando == "N")
                {
                    break;
                }
            } while (true);
            Console.WriteLine();
            TareaFinalizada("Modificación finalizada...");
        }


        private static void ListarTemperaturas(double[] temperaturas)
        {
            Console.Clear();
            Console.WriteLine("Listado de Temperaturas");
            var tabla = new ConsoleTable("Celsius", "Fahrenheit");
            foreach (double tempEnArray in temperaturas)
            {
                var fahrenheit = ConvertToFah(tempEnArray);
                tabla.AddRow(tempEnArray, fahrenheit);
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizada("Listado Finalizado");
        }

        private static double ConvertToFah(double celsius) => 1.8 * celsius + 32;

        private static void GenerarLasTemperaturas(double[] temperaturas)
        {
            Console.Clear();
            Console.WriteLine("Ingreso de temperaturas");
            for (int i = 0; i < temperaturas.Length; i++)
            {
                double tempIngresada;
                do
                {
                    tempIngresada =
                        IngresoDatos.PedirDoubleEnRango("Ingrese una temperatura:", MIN_TEMPERATURA, MAX_TEMPERATURA);
                    if (Existe(tempIngresada, temperaturas))
                    {
                        Console.WriteLine("Temperatura existente!!!");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                temperaturas[i] = tempIngresada;


            }
            TareaFinalizada("Ingreso finalizado");
        }

        private static bool Existe(double tempIngresada, double[] temperaturas)
        {
            foreach (double tempEnArray in temperaturas)
            {
                if (tempIngresada == tempEnArray)
                {
                    return true;
                }
            }
            return false;
        }

        private static void TareaFinalizada(string mensaje)
        {
            Console.WriteLine($"{mensaje}...ENTER para continuar");
            Console.ReadLine();
        }

        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("1-Ingresar Datos");
            Console.WriteLine("2-Modificar Datos");
            Console.WriteLine("3-Listar Temperaturas con Equivalentes");
            Console.WriteLine("4-Datos Estadísticos");
            Console.WriteLine("5-Marcar Superiores al Promedio");
            Console.WriteLine("6-Ver Inferiores al Promedio");
            Console.WriteLine("7-Mostrar Ordenado ASC ");
            Console.WriteLine("8-Mostrar Ordenado DESC ");
            Console.WriteLine("9-Salir");

        }

    }
}