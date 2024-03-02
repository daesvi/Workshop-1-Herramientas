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
            List<Asignaturas> asignaturas = new List<Asignaturas>();
            while (true)
            {
                Console.WriteLine("1.Agregar asignatura \n 2.Elegir asignatura");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Write("Digita el nombre de la asignatura: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Digita los creditos de la asignatura: ");
                    int creditos = int.Parse(Console.ReadLine());
                    asignaturas.Add(new Asignaturas(nombre, creditos));
                }
                else if (opcion == 2)
                {
                    Console.Write("Digita el nombre de la asignatura: ");
                    string nombreAsignatura = Console.ReadLine();
                    foreach (Asignaturas asignatura in asignaturas)
                    {
                        if (asignatura.nombre == nombreAsignatura)
                        {
                            Console.WriteLine("1.Ver nota acomulada \n 2.Ver nota deseada \n 3.Agregar notas");
                            int opcion2 = int.Parse(Console.ReadLine());
                            if (opcion2 == 3)
                            {
                                Console.Write("Digita el nombre de la nota: ");
                                string nombre = Console.ReadLine();
                                Console.Write("Digita el valor de la nota: ");
                                double valor = double.Parse(Console.ReadLine());
                                Console.Write("Digita el porcentaje de la nota: ");
                                double porcentaje = double.Parse(Console.ReadLine());
                                asignatura.notas.Add(new Notas(nombre, valor, porcentaje));
                            }
                            else if (opcion2 == 2)
                            {
                                Console.Write("Digita la nota deseada: ");
                                double notaRequerida = double.Parse(Console.ReadLine());
                                Console.WriteLine($"necesitas sacar en el porcentaje que te queda ({asignatura.ContarPorcentaje() * 100}) un {asignatura.notaDeseada(notaRequerida)}");
                            }
                            else if (opcion2 == 1)
                            {
                                Console.WriteLine($"Llevas acomulado un {asignatura.notasAcomuladas()}");
                            }
                            else
                            {
                                Console.WriteLine("opcion no valida");
                            }
                        }
                    }
                }
                else {
                    Console.WriteLine("opcion no valida");
                }
            }
        }
    }
}
