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
        private static List<Asignatura> asignaturas = new List<Asignatura>();

        private static void agregarAsignatura()
        {
            Console.Write("Digita el nombre de la asignatura: ");
            string nombre = Console.ReadLine();
            Console.Write("Digita los créditos de la asignatura: ");
            int creditos = int.Parse(Console.ReadLine());
            asignaturas.Add(new Asignatura(nombre, creditos));
        }

        private static void elegirAsignatura()
        {
            Console.Write("Digita el nombre de la asignatura: ");
            string nombreAsignatura = Console.ReadLine();
            foreach (Asignatura asignatura in asignaturas)
            {
                if (asignatura.nombre == nombreAsignatura)
                {
                    mostrarMenuAsignatura(asignatura);
                    return;
                }
            }
            Console.WriteLine("La asignatura no existe.");
        }

        private static void mostrarMenuAsignatura(Asignatura asignatura)
        {
            Console.WriteLine("1. Ver nota acumulada");
            Console.WriteLine("2. Ver nota deseada");
            Console.WriteLine("3. Agregar notas");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Console.WriteLine($"Llevas acumulado un {asignatura.notasAcumuladas()}");
                    break;
                case 2:
                    Console.Write("Digita la nota deseada: ");
                    double notaRequerida = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Necesitas sacar en el porcentaje que te queda ({asignatura.contarPorcentaje() * 100}) un {asignatura.notaDeseada(notaRequerida)}");
                    break;
                case 3:
                    AgregarNota(asignatura);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        private static void AgregarNota(Asignatura asignatura)
        {
            Console.Write("Digita el nombre de la nota: ");
            string nombre = Console.ReadLine();
            Console.Write("Digita el valor de la nota: ");
            double valor = double.Parse(Console.ReadLine());
            Console.Write("Digita el porcentaje de la nota: ");
            double porcentaje = double.Parse(Console.ReadLine());
            asignatura.notas.Add(new Nota(nombre, valor, porcentaje));
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Agregar asignatura");
                Console.WriteLine("2. Elegir asignatura");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        agregarAsignatura();
                        break;
                    case 2:
                        elegirAsignatura();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
        }
    }
}
