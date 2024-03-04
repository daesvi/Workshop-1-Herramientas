 using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Asignatura> asignaturas = new List<Asignatura>();

            while (true)
            {
                Console.Clear();
                try
                {
                    Console.Write("##### Calculadora de Notas ######\n1.Agregar asignatura \n2.Elegir asignatura\n3.Salir\nDigita tu opcion: ");
                    int opcion = int.Parse(Console.ReadLine());
                    if (opcion == 1) agregarAsignatura(asignaturas);
                    else if (opcion == 2)
                    {
                        if (asignaturas.Count > 0)
                        {
                            elgirAsignatura(asignaturas);
                        }
                        else verAsignaturas(asignaturas);
                    }
                    else if (opcion == 3) break;
                    else Console.WriteLine("opcion no valida");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lo siento hubo un error de tipo: {ex.GetType()}\nIntentalo de nuevo");
                    Console.ReadKey();

                }
            }
        }
        public static void agregarAsignatura(List<Asignatura> asignaturas)
        {
            Console.Clear();
            try
            {
                Console.WriteLine("## Agregrar asignatura ##");
                Console.Write("Digita el nombre de la asignatura: ");
                string nombre = Console.ReadLine();
                Console.Write("Digita los creditos de la asignatura: ");
                int creditos = int.Parse(Console.ReadLine());
                asignaturas.Add(new Asignatura(nombre.ToLower(), creditos));
                Console.WriteLine("Asignatura agregada");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lo siento hubo un error de tipo: {ex.GetType()}\nIntentalo de nuevo");
            }
            Console.ReadKey();
        }

        public static void agregarNota(Asignatura asignatura)
        {
            Console.Clear();
            Console.WriteLine("## Agregrar nota ##");
            if (!asignatura.validarPorcentaje())
                Console.WriteLine("El porcentaje actual de la asignatura es 100% por lo cual no puedes agregar mas notas");
            else
            {
                try
                {
                    Console.Write("Digita el nombre de la nota: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Digita el valor de la nota: ");
                    double valor = double.Parse(Console.ReadLine());
                    Console.Write("Digita el porcentaje de la nota: ");
                    double porcentaje = double.Parse(Console.ReadLine());
                    asignatura.notas.Add(new Nota(nombre, valor, porcentaje));
                    Console.WriteLine("Nota agregada");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lo siento hubo un error de tipo: {ex.GetType()}\nIntentalo de nuevo");

                }
            }
        }

        public static void verNotaDeseada(Asignatura asignatura)
        {
            Console.Clear();
            if (asignatura.validarPorcentaje())
            {

                Console.WriteLine("## Nota Deseada ##");
                Console.Write("Digita la nota deseada: ");
                double notaRequerida = double.Parse(Console.ReadLine());
                Console.WriteLine($"necesitas sacar en el porcentaje que te queda ({(1 - asignatura.contarPorcentaje()) * 100}) un {asignatura.notaDeseada(notaRequerida)}");
            }
            else
            {
                Console.WriteLine($"Ya tienie una nota final de {asignatura.notaDeseada(0)}");
            }
        }
        public static void verNotaAcomulada(Asignatura asignatura)
        {
            Console.Clear();
            if (asignatura.validarPorcentaje())
                Console.WriteLine($"## Nota acomulada ##\nLlevas acomulado un {asignatura.notasAcumuladas()}");
            else Console.WriteLine($"## Nota acomulada ##\nTu asignatura tiene una nota final de {asignatura.notasAcumuladas()}");
        }

        public static void verAsignaturas(List<Asignatura> asignaturas)
        {
            Console.Clear();
            Console.WriteLine("## Asignaturas ##");
            if (asignaturas.Count > 0)
            {
                foreach (var asignatura in asignaturas)
                {
                    Console.WriteLine(asignatura.ToString());
                }
            }
            else
            {
                Console.WriteLine("Aun no hay asignaturas Agregadas");
                Console.ReadKey();
            }
        }

        public static Asignatura EncontrarAsignatura(List<Asignatura> asignaturas, string nombreAsignatura)
        {
            Asignatura asignaturaElegida = null;
            foreach (Asignatura asignatura in asignaturas)
            {
                if (asignatura.nombre == nombreAsignatura)
                {
                    asignaturaElegida = asignatura;
                    break;
                }
            }
            return asignaturaElegida;
        }

        public static void menuAsignatura(Asignatura asignaturaElegida)
        {
            int opcion2 = 0;
            while (opcion2 != 5)
            {
                try
                {
                    Console.Write($"## {asignaturaElegida.nombre} ##\n1.Ver nota acomulada \n2.Ver nota deseada \n3.Agregar notas\n4.Ver notas\n5.Salir\nDigite una opcion: ");
                    opcion2 = int.Parse(Console.ReadLine());
                    if (opcion2 == 3) agregarNota(asignaturaElegida);
                    else if (opcion2 == 2) verNotaDeseada(asignaturaElegida);
                    else if (opcion2 == 1) verNotaAcomulada(asignaturaElegida);
                    else if (opcion2 == 4)
                    {
                        Console.Clear();
                        Console.WriteLine(asignaturaElegida.verNotas());
                    }
                    else if (opcion2 == 5)
                    {
                        Console.WriteLine("Volviendo al menu principal");
                    }
                    else Console.WriteLine("opcion no valida");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lo siento hubo un error de tipo: {ex.GetType()}\nIntentalo de nuevo");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void elgirAsignatura(List<Asignatura> asignaturas)
        {
            verAsignaturas(asignaturas);
            Console.Write("Digita el nombre de la asignatura: ");
            string nombreAsignatura = Console.ReadLine();
            Asignatura asignaturaElegida = EncontrarAsignatura(asignaturas, nombreAsignatura.ToLower());
            Console.Clear();
            if (asignaturaElegida != null)
            {
                menuAsignatura(asignaturaElegida);
            }
            else
            {
                Console.WriteLine($"## {nombreAsignatura} ##\n Esta materia no ha sido creada, intenta crearla");
                Console.ReadKey();
            }
        }
    }
}
